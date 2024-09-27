@echo off
cd /d "%~dp0" && ( if exist "%temp%\getadmin.vbs" del "%temp%\getadmin.vbs" ) && fsutil dirty query %systemdrive% 1>nul 2>nul || (  echo Set UAC = CreateObject^("Shell.Application"^) : UAC.ShellExecute "cmd.exe", "/k cd ""%~sdp0"" && ""%~s0"" %params%", "", "runas", 1 >> "%temp%\getadmin.vbs" && "%temp%\getadmin.vbs" && exit /B )


set "AppPath=%~dp0"

color 0F
    echo [94mGoldnet installer[0m

REM REG ADD "HKEY_USERS\%myvar%\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers" /v "%AppPath%\Core\EAccount.exe" /t REG_SZ /d "RUNASADMIN" /f
REM REG ADD "HKEY_USERS\%myvar%\Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers" /v "%AppPath%\Core\ECurrency.exe" /t REG_SZ /d "RUNASADMIN" /f
color 0F
echo Copying DLL's[0m
xcopy "%AppPath%\InstallDependancies\dll\*" "C:\Windows\SysWOW64\" /E /H /C /I /Q /Y

color 0F
echo Adding registry values.[0m

regedit.exe /S "%AppPath%\InstallDependancies\Registry.reg"
color 0F
echo Adding Win8 network patch.[0m
regedit.exe /S "%AppPath%\InstallDependancies\NetworkDrives.reg"

color 0F
echo Adding catav variables to system var.[0m
setx EDIHOST_DIR "%AppPath%Core\System\account" /M
setx EDIHOST1_DIR "%AppPath%Core\System\currency" /M

REM Set database path.
reg add "HKEY_CURRENT_USER\Software\GoldNET\Setup" /f /v DatabaseDir /t REG_SZ /d "%AppPath%Data


echo Installing fonts...[0m
set "fontPath=%AppPath%\Fonts"
color 0F
for %%f in ("%AppPath%\InstallDependancies\Fonts\*.fon") do (
    echo Copying %%~nxf to %fontPath%...
    copy /Y "%%f" "%fontPath%" >nul 2>&1
    if %errorlevel% neq 0 (
        echo Failed to install %%~nxf. Access denied.
    ) else (
        echo Installed %%~nxf successfully.
    )
)

REM RESERVED, ADD PROGRAM SHORTCUTS TO WINDOWS


color 0F
echo Hlp installation..[0m
CALL "%AppPath%\InstallDependancies\hlpInstaller\Install.bat" >nul 2>&1

color 0F
echo BDE instllation..[0m
CALL %AppPath%\InstallDependancies\dBASE_BDE.exe /S


    echo -------------------------------------------------------------------------
    echo If there is no errors above, installation has been completed.
    echo Finish installation by configuring TGMS and configurations.
    echo -------------------------------------------------------------------------
pause
exit