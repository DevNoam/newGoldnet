SET APP_PATH=C:\Goldnet\tgms\
CD /D %APP_PATH%
call %APP_PATH%\tgupdate.bat %APP_PATH% >> tgupdate.log
%APP_PATH%jre-9.0.4\bin\java.exe -jar %APP_PATH%tgms.jar
