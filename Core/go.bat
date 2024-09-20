@echo off
setlocal ENABLEEXTENSIONS

set KEY_NAME=HKCU\SOFTWARE\GoldNET\Setup
set VALUE_NAME=DatabaseDir
set DB_PATH=NULL
set dir="%~dp0"
for /F "usebackq tokens=1,2,*" %%A IN (`reg query "%KEY_NAME%" /v "%VALUE_NAME%" 2^>nul ^| find "%VALUE_NAME%"`) do (
  set DB_PATH=%%C
)
if %DB_PATH% == NULL (
echo "Can't find database directory"
exit
)

REM Download new data from Server
REM CALL c:\mutltibill\tgms\run.bat

REM Convert files from EDI
cd %dir%\System\account\
CALL STATRECN.exe %DB_PATH%\Mivzaq\ %DB_PATH%\Mivzaq\Msgs\
cd %dir%\System\Currency\
PAYXREC1.exe %DB_PATH%\Currency\ %DB_PATH%\Currency\Msgs\
cd %dir%

REM Backup to archive by finding the latest BAK number
set "bkpnum=0"
for /f "delims=.arj" %%f in ('dir /b /o-n "%DB_PATH%\mivzaq\bak\*.arj"') do (
    set /a "bkpnum=%%f"
    set /a bkpnum+=1
    :: Create the BAK
    Arj a -y %DB_PATH%\mivzaq\bak\%bkpnum%.arj %DB_PATH%\mivzaq\Msgs\*.ms*
)

REM Import to Databases if there is msq files
for %%f in ("%DB_PATH%\Currency\Msgs\*.msq") do (
  CALL %dir%\ecurrency.exe -i %DB_PATH%\Currency\Msgs\*.msq -W
)
for %%f in ("%DB_PATH%\Mivzaq\Msgs\*.msq") do (
  CALL %dir%\EAccount.exe -i %DB_PATH%\Mivzaq\Msgs\*.msq -E   
)