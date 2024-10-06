using GoldnetWrapper.Core.Properties;
using GoldnetWrapper.Core.UserControls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

public class RepManager : IDisposable
{
    private readonly List<RepData> enabledReps = new List<RepData>();
    private readonly List<RepData> disabledReps = new List<RepData>();
    private readonly FlowLayoutPanel enabledContainer;
    private readonly FlowLayoutPanel disabledContainer;
    private FileSystemWatcher fileWatcher;
    private bool isLoading;

    private Encoding encodingHebrew = Encoding.GetEncoding("Windows-1255");

    public RepManager(FlowLayoutPanel enabledContainer, FlowLayoutPanel disabledContainer)
    {
        this.enabledContainer = enabledContainer;
        this.disabledContainer = disabledContainer;

        InitializeFileWatcher();
    }

    public void LoadReps()
    {
        var repFiles = Directory.GetFiles(Application.StartupPath, "*.rep");
        ClearReps();

        foreach (var repFile in repFiles)
        {
            var repData = ReadRepFile(repFile);
            if (repData != null)
            {
                (repData.Enabled == 1 ? enabledReps : disabledReps).Add(repData);
            }
        }

        ValidateGNEXPORT();
        AddRepsToContainers();
    }

    private void InitializeFileWatcher()
    {
        fileWatcher = new FileSystemWatcher
        {
            Path = Application.StartupPath,
            Filter = "*.rep",
            NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite
        };

        fileWatcher.Changed += OnRepFileChanged;
        fileWatcher.Created += OnRepFileChanged;
        fileWatcher.Deleted += OnRepFileChanged;
        fileWatcher.EnableRaisingEvents = true;
    }

    private void OnRepFileChanged(object sender, FileSystemEventArgs e)
    {
        if (isLoading) return;

        isLoading = true;
        System.Threading.Thread.Sleep(100); // Delay to let filesystem settle

        if (enabledContainer.IsDisposed || disabledContainer.IsDisposed)
        {
            isLoading = false;
            return;
        }

        SafeInvoke(() => HandleFileChange(e));
        isLoading = false;
    }

    private void SafeInvoke(Action action)
    {
        try
        {
            if (enabledContainer.InvokeRequired)
            {
                enabledContainer.Invoke((MethodInvoker)(() =>
                {
                    if (!enabledContainer.IsDisposed && !disabledContainer.IsDisposed)
                    {
                        action();
                    }
                }));
            }
            else
            {
                action();
            }
        }
        catch (ObjectDisposedException)
        {
            Console.WriteLine("Containers disposed during invocation.");
        }
    }

    private void HandleFileChange(FileSystemEventArgs e)
    {
        var filePath = e.FullPath;

        if (Path.GetExtension(filePath).Equals(".rep", StringComparison.OrdinalIgnoreCase))
        {
            if (e.ChangeType == WatcherChangeTypes.Created) AddNewRep(filePath);
            else if (e.ChangeType == WatcherChangeTypes.Deleted) RemoveRep(filePath);
        }
    }

    private void AddNewRep(string fullPath)
    {
        var newRepData = ReadRepFile(fullPath);
        if (newRepData == null) return;

        var targetList = newRepData.Enabled == 1 ? enabledReps : disabledReps;
        var targetContainer = newRepData.Enabled == 1 ? enabledContainer : disabledContainer;

        targetList.Add(newRepData);
        AddRepsToContainer(new List<RepData> { newRepData }, targetContainer);
    }

    private void RemoveRep(string fullPath)
    {
        var repName = Path.GetFileNameWithoutExtension(fullPath);
        var repToRemove = enabledReps.FirstOrDefault(rep => rep.repName == repName) ??
                          disabledReps.FirstOrDefault(rep => rep.repName == repName);

        if (repToRemove == null) return;

        var targetList = repToRemove.Enabled == 1 ? enabledReps : disabledReps;
        var targetContainer = repToRemove.Enabled == 1 ? enabledContainer : disabledContainer;

        targetList.Remove(repToRemove);
        RefreshContainer(targetContainer, targetList);
    }

    private void RefreshContainer(FlowLayoutPanel container, List<RepData> reps)
    {
        container.Controls.Clear();
        AddRepsToContainer(reps, container);
    }

    private void AddRepsToContainers()
    {
        AddRepsToContainer(enabledReps, enabledContainer);
        AddRepsToContainer(disabledReps, disabledContainer);
    }

    private void AddRepsToContainer(IEnumerable<RepData> reps, FlowLayoutPanel container)
    {
        foreach (var rep in reps)
        {
            var repSelector = new RepSelector(rep);
            repSelector.RepStateChanged += OnRepStateChanged;
            container.Controls.Add(repSelector);
        }
    }

    private RepData ReadRepFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var repData = new RepData { repName = Path.GetFileNameWithoutExtension(filePath) };

        foreach (var line in lines)
        {
            if (line.StartsWith("Enabled=", StringComparison.OrdinalIgnoreCase))
            {
                repData.Enabled = int.Parse(line.Substring("Enabled=".Length));
            }
            else if (line.StartsWith("OutputFileName=", StringComparison.OrdinalIgnoreCase))
            {
                repData.OutputFolder = Path.GetDirectoryName(line.Substring("OutputFileName=".Length).Trim()) ?? string.Empty;
            }
        }

        return repData;
    }

    private void ValidateGNEXPORT()
    {
        var gNExportFilePath = Path.Combine(Application.StartupPath, "GNEXPORT.ini");

        if (!File.Exists(gNExportFilePath)) return;

        var lines = File.ReadAllLines(gNExportFilePath).ToList();
        var currentExports = lines.Skip(1).Where(line => line.Contains('=')).Select(line => line.Split('=')[1]).ToList();
        var activeEnabledReps = new HashSet<string>(enabledReps.Select(rep => rep.repName));

        currentExports.RemoveAll(export => !activeEnabledReps.Contains(export));
        currentExports.AddRange(enabledReps.Select(rep => rep.repName).Where(rep => !currentExports.Contains(rep)));

        File.WriteAllLines(gNExportFilePath, new[] { "[Exports]" }.Concat(currentExports.Select((name, i) => $"{i}={name}")));

        // Optional logging
    }

    private void ClearReps()
    {
        enabledReps.Clear();
        disabledReps.Clear();
        enabledContainer.Controls.Clear();
        disabledContainer.Controls.Clear();
    }

    public void OnRepStateChanged(object sender, EventArgs e)
    {
        var child = sender as RepSelector;
        var repData = child?.GetRepData();
        if (repData == null) return;

        if (repData.Enabled == 1)
        {
            MoveRep(child, disabledContainer, enabledContainer, disabledReps, enabledReps);
        }
        else
        {
            MoveRep(child, enabledContainer, disabledContainer, enabledReps, disabledReps);
        }
    }

    private void MoveRep(RepSelector child, FlowLayoutPanel fromContainer, FlowLayoutPanel toContainer, List<RepData> fromList, List<RepData> toList)
    {
        var repData = child.GetRepData();
        fromList.Remove(repData);
        toList.Add(repData);

        fromContainer.Controls.Remove(child);
        toContainer.Controls.Add(child);
    }

    public void SaveReps()
    {
        enabledReps.ForEach(rep => SaveRepFile(rep, true));
        disabledReps.ForEach(rep => SaveRepFile(rep, false));

        ValidateGNEXPORT();
    }

    private void SaveRepFile(RepData rep, bool isEnabled)
    {
        var filePath = Path.Combine(Application.StartupPath, $"{rep.repName}.rep");
        var lines = File.ReadAllLines(filePath, encodingHebrew).ToList(); // Reading without encoding for speed
        var updatedLines = new List<string>();

        bool changesDetected = false;  // Flag to track if changes are made

        foreach (var line in lines)
        {
            if (line.StartsWith("Enabled="))
            {
                var newEnabledLine = $"Enabled={(isEnabled ? 1 : 0)}";
                updatedLines.Add(newEnabledLine);
                if (!line.Equals(newEnabledLine)) changesDetected = true; // Mark if there are changes
            }
            else if (line.StartsWith("OutputFileName="))
            {
                var currentOutputFileName = line.Substring("OutputFileName=".Length).Trim();
                var newOutputFileNameLine = $"OutputFileName={Path.Combine(rep.OutputFolder, Path.GetFileName(currentOutputFileName))}";
                updatedLines.Add(newOutputFileNameLine);
                if (!line.Equals(newOutputFileNameLine)) changesDetected = true; // Mark if there are changes
            }
            else if (line.StartsWith("Description="))
            {
                // Read the Description for registry update but do not modify or overwrite
                var repDescriptionName = line.Substring("Description=".Length).Trim();
                if (isEnabled)
                {
                    RegistryHelper.SetValue(repDescriptionName, 1, "Export");
                }
                else
                {
                    RegistryHelper.DeleteValue(repDescriptionName, "Export");
                }
                updatedLines.Add(line); // Retain original Description line
            }
            else
            {
                updatedLines.Add(line); // Keep all other lines unchanged
            }
        }

        // Only write the file with Windows-1255 encoding if changes were detected
        if (changesDetected)
        {
            File.WriteAllLines(filePath, updatedLines, encodingHebrew); // Write using Windows-1255 encoding
        }
    }

    public void Dispose()
    {
        fileWatcher?.Dispose();
    }
}
