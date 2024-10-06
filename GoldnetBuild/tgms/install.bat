@echo off
color 0F
    echo [94mBezeq international 2023 TGMS communicator wizard for BuisnessNet[0m
set "AppPath=%~dp0"


REM check if there is ssh keys under SSH folder
>nul 2>nul dir /a-d "ssh\*" && (
     echo [91m[1mInstallation aborted: [0m[91m TGMS installed?"
     echo [33m[1m Backup SSH keypairs if using clean install![0m
     pause
     exit
)


REM Give account credentials
echo TGMS installer, provide account information.
set /p "AccountMailBox=Account Mail Box: "
If "%AccountMailBox%"=="" goto Abort

set /p "AccountUsrn=sFTP Account username: "
If "%AccountMailBox%"=="" goto Abort
If "%AccountUsrn%"=="" goto Abort

echo [103m[30mContinue with the data above?[0m
choice /C:YN /M:""
IF %ERRORLEVEL% EQU 1 goto Install
IF %ERRORLEVEL% EQU 2 goto Abort
exit
:Abort
    echo [31mInstallation aborted.
    pause
    exit
:Install
    echo Installing tgms client.....
	call %AppPath%jre-9.0.4\bin\java.exe -jar %AppPath%tgms.jar setAccountMailbox=%AccountMailBox% setAccountUserName=%AccountUsrn% keypair=true makeDirs=true getPaths=true
    echo [30m [102mInstallation wizard has been completed.[0m
    echo Press any key to quit the wizard.
    pause >nul
    exit