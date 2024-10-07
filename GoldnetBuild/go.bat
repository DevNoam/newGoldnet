@echo off
:: ///////////////////////////////////////////
:: // BEZEQ INTERNATIONAL - bezeqint.net    //
:: // NOAM SAPIR - noamsapir.me             //
:: // DO NOT MODIFY THIS CODE CONTENTS      //
:: ///////////////////////////////////////////
REM Variables  (Can be modified)
:: ----------------------------
set EnableBackup=true
set EnableEDIConverter=true
:: ----------------------------

setlocal ENABLEEXTENSIONS
setlocal enabledelayedexpansion
set dir=%~dp0

echo [1;34mBezeq International, MultiBill services[0m
echo LOG: Starting fetching process  

set TGMSPath=NULL
set DB_PATH=NULL

REM Find database from registry
set KEY_NAME=HKCU\SOFTWARE\GoldNET\Setup
set VALUE_NAME=DatabaseDir
for /F "usebackq tokens=1,2,*" %%A IN (`reg query "%KEY_NAME%" /v "%VALUE_NAME%" 2^>nul ^| find "%VALUE_NAME%"`) do (
  set DB_PATH=%%C
  echo [1;31mFound Database, starting process..[0m
)
if %DB_PATH% == NULL (
  echo "[1;31mCan't find database directory[0m"
  echo ERROR: Database not found! 
  pause
  exit
)

REM Find TGMS path from registry
set VALUE_NAME=TGMSPath
for /F "usebackq tokens=1,2,*" %%A IN (`reg query "%KEY_NAME%" /v "%VALUE_NAME%" 2^>nul ^| find "%VALUE_NAME%"`) do (
  set TGMSPath=%%C
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
if not "!TGMSRunBat!"=="NULL" if exist "!TGMSRunBat!" (
   echo [36mCalling TGMS..[0m
   echo STARTTGMS 
   CALL "!TGMSRunBat!\run.bat"
   echo ENDTGMS 
   echo [36mTGMS finished.[0m
)


REM Convert files from EDI
if /i "!EnableEDIConverter!"=="true" (
   echo LOG: Converting files..

   if exist "!DB_PATH!\Mivzaq\In\*.msu" (
      echo [35mConverting Mivzaq..[0m
      cd %dir%\System\account\
      CALL STATRECN.exe %DB_PATH%\Mivzaq\ %DB_PATH%\Mivzaq\Msgs\
   )
   if exist "!DB_PATH!\Currency\In\*.msu" (
      echo LOG: Converting MATAH files..  
      cd %dir%\System\Currency\
      CALL PAYXREC1.exe %DB_PATH%\Currency\ %DB_PATH%\Currency\Msgs\   
   )

   echo LOG: Converting ended.
   cd %dir%
)


REM Import Mivzaq
if exist "!DB_PATH!\Mivzaq\Msgs\*.msq" (
  set "bkpnumMivzaq=0"
  for %%f in ("!DB_PATH!\Mivzaq\Bak\*.arj") do (
    for /f "delims=." %%n in ("%%~nf") do if %%n gtr !bkpnumMivzaq! set /a bkpnumMivzaq=%%n
  )
  set /a bkpnumMivzaq+=1
  if /i "!EnableBackup!"=="true" (
      echo LOG: Archiving Mivzaq..  
     CALL "!dir!\arj.exe" a -y "!DB_PATH!\Mivzaq\Bak\!bkpnumMivzaq!.arj" "!DB_PATH!\Mivzaq\Msgs\*.ms*"
   )
  echo LOG: Importing Mivzaq..  
  CALL "%dir%\EAccount.exe" -i "%DB_PATH%\Mivzaq\Msgs\*.msq" -E
)

REM Import Currency
if exist "!DB_PATH!\Currency\Msgs\*.msq" (
  set "bkpnumCurrency=0"
  for %%f in ("!DB_PATH!\Currency\Bak\*.arj") do (
    for /f "delims=." %%n in ("%%~nf") do if %%n gtr !bkpnumCurrency! set /a bkpnumCurrency=%%n
  )
  set /a bkpnumCurrency+=1
  if /i "!EnableBackup!"=="true" (
   echo LOG: Archiving Matah..    
   CALL "!dir!\arj.exe" a -y "!DB_PATH!\Currency\Bak\!bkpnumCurrency!.arj" "!DB_PATH!\Currency\Msgs\*.ms*"
  ) 
 echo LOG: Importing Matah..  
 CALL "!dir!\ECurrency.exe" -i "!DB_PATH!\Currency\Msgs\*.msq" -W
)

echo [1;32mFinish .[0m
echo LOG: Fetching ended.
pause