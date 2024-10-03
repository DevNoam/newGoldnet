using GoldnetWrapper.Core.Properties;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using System.IO;
using System.Linq;
using GoldnetWrapper.Core.UserControls;

public class RepManager : IDisposable
{
    private List<RepData> enabledReps = new List<RepData>();
    private List<RepData> disabledReps = new List<RepData>();
    private FlowLayoutPanel enabledContainer;
    private FlowLayoutPanel disabledContainer;
    private FileSystemWatcher fileWatcher;
    private bool isLoading = false; // Flag to prevent re-entrant loading

    public RepManager(FlowLayoutPanel enabledContainer, FlowLayoutPanel disabledContainer)
    {
        this.enabledContainer = enabledContainer;
        this.disabledContainer = disabledContainer;
        InitializeFileWatcher();
    }

    public void LoadReps()
    {
        // Load REP files from the directory
        var repFiles = Directory.GetFiles(Application.StartupPath, "*.rep");

        // Clear existing lists and containers
        enabledReps.Clear();
        disabledReps.Clear();
        enabledContainer.Controls.Clear();
        disabledContainer.Controls.Clear();

        foreach (var repFile in repFiles)
        {
            var repData = ReadRepFile(repFile);
            if (repData != null)
            {
                if (repData.Enabled == 1) enabledReps.Add(repData);
                else disabledReps.Add(repData);
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

        // Adding a slight delay to allow the file system to settle
        System.Threading.Thread.Sleep(100);

        if (enabledContainer.IsDisposed || disabledContainer.IsDisposed)
        {
            isLoading = false;
            return;
        }

        if (enabledContainer.InvokeRequired)
        {
            enabledContainer.Invoke((MethodInvoker)(() => HandleFileChange(e)));
        }
        else
        {
            HandleFileChange(e);
        }

        isLoading = false;
    }

    private void HandleFileChange(FileSystemEventArgs e)
    {
        Console.WriteLine($"File changed: {e.ChangeType}, Path: {e.FullPath}");

        if (Path.GetExtension(e.FullPath).Equals(".rep", StringComparison.OrdinalIgnoreCase))
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    AddNewRep(e.FullPath);
                    break;
                case WatcherChangeTypes.Deleted:
                    RemoveRep(e.FullPath);
                    break;
            }
        }
    }

    private void AddNewRep(string fullPath)
    {
        var newRepData = ReadRepFile(fullPath);
        if (newRepData != null)
        {
            if (newRepData.Enabled == 1)
            {
                enabledReps.Add(newRepData);
                AddRepsToContainer(new List<RepData> { newRepData }, enabledContainer);
            }
            else
            {
                disabledReps.Add(newRepData);
                AddRepsToContainer(new List<RepData> { newRepData }, disabledContainer);
            }
        }
    }

    private void RemoveRep(string fullPath)
    {
        var repName = Path.GetFileNameWithoutExtension(fullPath);
        var repToRemove = enabledReps.FirstOrDefault(rep => rep.repName == repName) ??
                          disabledReps.FirstOrDefault(rep => rep.repName == repName);

        if (repToRemove != null)
        {
            if (repToRemove.Enabled == 1)
            {
                enabledReps.Remove(repToRemove);
                RefreshContainer(enabledContainer, enabledReps);
            }
            else
            {
                disabledReps.Remove(repToRemove);
                RefreshContainer(disabledContainer, disabledReps);
            }
        }
    }

    private void RefreshContainer(FlowLayoutPanel container, List<RepData> reps)
    {
        container.Controls.Clear();
        AddRepsToContainer(reps, container);
    }

    private void AddRepsToContainer(List<RepData> reps, FlowLayoutPanel container)
    {
        foreach (var rep in reps)
        {
            var child = new RepSelector(rep);
            child.RepStateChanged += OnRepStateChanged;
            container.Controls.Add(child);
        }
    }

    private void AddRepsToContainers()
    {
        AddRepsToContainer(enabledReps, enabledContainer);
        AddRepsToContainer(disabledReps, disabledContainer);
    }

    private RepData ReadRepFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var repData = new RepData { repName = Path.GetFileNameWithoutExtension(filePath) };

        foreach (var line in lines)
        {
            if (line.StartsWith("Enabled="))
            {
                repData.Enabled = int.Parse(line.Substring("Enabled=".Length));
            }
            else if (line.StartsWith("OutputFileName="))
            {
                var outputFilePath = line.Substring("OutputFileName=".Length).Trim();
                repData.OutputFolder = string.IsNullOrWhiteSpace(outputFilePath) ? string.Empty : Path.GetDirectoryName(outputFilePath);
            }
        }

        return repData;
    }

    private void ValidateGNEXPORT()
    {
        var lines = File.ReadAllLines(Path.Combine(Application.StartupPath, "GNEXPORT.ini")).ToList();
        if (lines.Count > 0 && lines[0] != "[Exports]")
        {
            throw new InvalidOperationException("Invalid GNEXPORT.ini format.");
        }

        var currentExports = lines.Skip(1).Select(line => line.Split('=')[1]).Distinct().ToList();
        var activeReps = new HashSet<string>(enabledReps.Select(rep => rep.repName).Concat(disabledReps.Select(rep => rep.repName)));

        currentExports.RemoveAll(export => !activeReps.Contains(export));
        currentExports.AddRange(enabledReps.Where(rep => !currentExports.Contains(rep.repName)).Select(rep => rep.repName));

        File.WriteAllLines(Path.Combine(Application.StartupPath, "GNEXPORT.ini"), new[] { "[Exports]" }.Concat(currentExports.Select((name, index) => $"{index}={name}")));
    }

    public void OnRepStateChanged(object sender, EventArgs e)
    {
        var child = sender as RepSelector;
        var repData = child.GetRepData();

        if (repData.Enabled == 1)
        {
            MoveChild(child, disabledContainer, enabledContainer, disabledReps, enabledReps);
        }
        else
        {
            MoveChild(child, enabledContainer, disabledContainer, enabledReps, disabledReps);
        }
    }

    private void MoveChild(RepSelector child, FlowLayoutPanel fromContainer, FlowLayoutPanel toContainer, List<RepData> fromList, List<RepData> toList)
    {
        var repData = child.GetRepData();
        fromList.Remove(repData);
        toList.Add(repData);
        fromContainer.Controls.Remove(child);
        toContainer.Controls.Add(child);
    }

    public void SaveReps()
    {
        foreach (var rep in enabledReps) SaveRepFile(rep, true);
        foreach (var rep in disabledReps) SaveRepFile(rep, false);
        ValidateGNEXPORT();
    }

    private void SaveRepFile(RepData rep, bool isEnabled)
    {
        string filePath = Path.Combine(Application.StartupPath, $"{rep.repName}.rep");
        var lines = File.Exists(filePath) ? File.ReadAllLines(filePath).ToList() : new List<string>();
        bool enabledUpdated = false, outputFileNameUpdated = false;

        for (int i = 0; i < lines.Count; i++)
        {
            if (lines[i].StartsWith("Enabled="))
            {
                lines[i] = $"Enabled={(isEnabled ? 1 : 0)}";
                enabledUpdated = true;
            }
            else if (lines[i].StartsWith("OutputFileName="))
            {
                var currentOutputFileName = lines[i].Substring("OutputFileName=".Length);
                var newOutputFileName = Path.Combine(rep.OutputFolder, Path.GetFileName(currentOutputFileName));
                lines[i] = $"OutputFileName={newOutputFileName}";
                outputFileNameUpdated = true;
            }
        }

        if (!enabledUpdated) lines.Add($"Enabled={(isEnabled ? 1 : 0)}");
        if (!outputFileNameUpdated) lines.Add($"OutputFileName={Path.Combine(rep.OutputFolder, $"{rep.repName}.dat")}");

        File.WriteAllLines(filePath, lines);
    }

    public void Dispose()
    {
        fileWatcher?.Dispose();
    }
}
