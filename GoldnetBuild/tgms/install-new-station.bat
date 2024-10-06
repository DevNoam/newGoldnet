@echo off
color 0F
    echo [94mBezeq international TGMS migration for Buisness net[0m
net session >nul 2>&1 
set "AppPath=%~dp0"
cd /d "%~dp0"

setlocal enabledelayedexpansion
    dir /b "%AppPath%\ssh" | findstr /r "^" >nul
    if errorlevel 1 (
       echo [91m[1mInstallation aborted: [0m[91mSSH keypair must be located inside the 'ssh' folder. For new accounts, please procceed with install.bat"
       pause
       exit    
    )
)
endlocal



if /I "%AppPath%" neq "C:\goldnet\tgms\" (
    echo [91mALERT!, your installation path is not under the recomended path: [4m[33mC:\goldnet\tgms[0m[91m[0m
    echo -------------------------------------------------------------------------
    echo Press any key to confirm the path.
    pause >nul
    cls
    echo [94mBezeq international 2023 TGMS communicator wizard for BuisnessNet[0m
)

echo TGMS installer, provide account information.
set /p "AccountMailBox=Account Mail Box: "
If "%AccountMailBox%"=="" goto Abort
call :CheckUserNameInBusinessNet "%AccountMailBox%"

set /p "AccountUsrn=sFTP Account username: "

If "%AccountMailBox%"=="" goto Abort
If "%AccountUsrn%"=="" goto Abort

echo [103m[30mContinue with the data above?[0m
choice /C:YN /M:""
IF %ERRORLEVEL% EQU 1 goto Install
IF %ERRORLEVEL% EQU 2 goto Abort
exit
:Abort
    echo [31mInstallation aborted, did you missed something?.
    pause
    exit
:Install
    echo Installing tgms client.....
	call %AppPath%jre-9.0.4\bin\java.exe -jar %AppPath%tgms.jar setAccountMailbox=%AccountMailBox% setAccountUserName=%AccountUsrn% keypair=false makeDirs=true getPaths=true
    echo [30m [102mInstallation wizard has been completed.[0m
    echo Press any key to quit the wizard.
    pause >nul
    exit


:CheckUserNameInBusinessNet
set "userInput=%~1"
set "registryPath=HKCU\SOFTWARE\GoldNET\Setup"
set "registryValue="
call :TOUPPERCASE userInput

REM Query the registry key
for /f "tokens=2,*" %%A in ('reg query "%registryPath%" /v "UserName" 2^>nul') do (
    set "registryValue=%%B"
)
call :TOUPPERCASE registryValue

REM Check if the registry value is null and write the uppercase user input
if not defined registryValue (
    echo BusinessNet Username is null. Writing username to registry...
    reg add "%registryPath%" /v "UserName" /t REG_SZ /d %userInput% /f
    echo Username updated.
    exit /b 0
)


REM Check if user input matches the registry value
if %userInput% equ %registryValue% (
    REM USERNAME MATCH BUSINESSNET
) else (
    echo [31mInstallation aborted, Account Mail Box doesn't match the BusinessNet username [33m%registryValue%[31m!!![0m
    pause
    exit
)

:TOUPPERCASE
if not defined %~1 exit /b
for %%a in ("a=A" "b=B" "c=C" "d=D" "e=E" "f=F" "g=G" "h=H" "i=I" "j=J" "k=K" "l=L" "m=M" "n=N" "o=O" "p=P" "q=Q" "r=R" "s=S" "t=T" "u=U" "v=V" "w=W" "x=X" "y=Y" "z=Z") do (
call set %~1=%%%~1:%%~a%%
)