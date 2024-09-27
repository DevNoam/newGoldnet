@echo off
setlocal ENABLEEXTENSIONS
setlocal enabledelayedexpansion
set dir=%~dp0

REM Variables
:: ----------------------------
set EnableECurrency=true
set EnableEAccount=true
set EnableBackup=true
set EnableEDIConverter=true
set TGMSRunBat="%dir%\..\tgms\run.bat"
:: TGMS run will be disabled if bath is null
:: ----------------------------

echo [1;34mBezeq International, MultiBill services[0m
echo LOG: Starting fetching process  

REM Find database from registry
set KEY_NAME=HKCU\SOFTWARE\GoldNET\Setup
set VALUE_NAME=DatabaseDir
set DB_PATH=NULL
for /F "usebackq tokens=1,2,*" %%A IN (`reg query "%KEY_NAME%" /v "%VALUE_NAME%" 2^>nul ^| find "%VALUE_NAME%"`) do (
  set DB_PATH=%%C
  echo [1;31mFound Database, starting process..[0m
)
if %DB_PATH% == NULL (
echo "[1;31mCan't find database directory[0m"
echo ERROR: Databbase not found! 
pause
exit
)

tasklist | find /i "EAccount.exe" > nul
if %errorlevel% equ 0 (
    	echo ERROR: Mivzaq is open! 
)
tasklist | find /i "ECurrency.exe" > nul
if %errorlevel% equ 0 (
    	echo ERROR: Matah is open! 
)


REM Download new data from Server
if not "!TGMSRunBat!"=="" if exist "!TGMSRunBat!" (
   echo [36mCalling TGMS..[0m
   echo STARTTGMS 
   CALL "!TGMSRunBat!"
   echo ENDTGMS 
   echo [36mTGMS finished.[0m
)


REM Convert files from EDI
if /i "!EnableEDIConverter!"=="true" (
   echo LOG: Converting MIVZAQ files..  
   echo [35mConverting EDI..[0m
   cd %dir%\System\account\
   CALL STATRECN.exe %DB_PATH%\Mivzaq\ %DB_PATH%\Mivzaq\Msgs\
   echo LOG: Converting MATAH files..  
   cd %dir%\System\Currency\
   CALL PAYXREC1.exe %DB_PATH%\Currency\ %DB_PATH%\Currency\Msgs\   
   cd %dir%
)


REM Import Mivzaq
if exist "!DB_PATH!\Mivzaq\Msgs\*.msq" if /i "!EnableEAccount!"=="true" (
  set "bkpnumMivzaq=0"
  for %%f in ("!DB_PATH!\Mivzaq\Bak\*.arj") do (
    for /f "delims=." %%n in ("%%~nf") do if %%n gtr !bkpnumMivzaq! set /a bkpnumMivzaq=%%n
  )
  set /a bkpnumMivzaq+=1
  if /i "!EnableBackup!"=="true" (
      echo LOG: Backingup Mivzaq..  
     CALL "!dir!\ARJ.exe" a -y "!DB_PATH!\Mivzaq\Bak\!bkpnumMivzaq!.arj" "!DB_PATH!\Mivzaq\Msgs\*.ms*"
   )
  echo LOG: Importing Mivzaq..  
  CALL "%dir%\EAccount.exe" -i "%DB_PATH%\Mivzaq\Msgs\*.msq" -E
)

REM Import Currency
if exist "!DB_PATH!\Currency\Msgs\*.msq" if /i "!EnableECurrency!"=="true" (
  set "bkpnumCurrency=0"
  for %%f in ("!DB_PATH!\Currency\Bak\*.arj") do (
    for /f "delims=." %%n in ("%%~nf") do if %%n gtr !bkpnumCurrency! set /a bkpnumCurrency=%%n
  )
  set /a bkpnumCurrency+=1
  if /i "!EnableBackup!"=="true" (
   echo LOG: Backingup Matah..    
   CALL "!dir!\ARJ.exe" a -y "!DB_PATH!\Currency\Bak\!bkpnumCurrency!.arj" "!DB_PATH!\Currency\Msgs\*.ms*"
  ) 
 echo LOG: Importing Matah..  
 CALL "!dir!\ECurrency.exe" -i "!DB_PATH!\Currency\Msgs\*.msq"
)


echo [1;32mFinish .[0m
echo LOG: Fetching ended.  
pause