@echo off

::Must be without quotes. If you intend to use command line arguments use %~1
set "host=192.115.8.24"
set /a port=22

for /f %%a in ('powershell "$t = New-Object Net.Sockets.TcpClient;try{$t.Connect("""%host%""", %port%)}catch{};$t.Connected"') do set "open=%%a"
:: or simply
:: powershell "$t = New-Object Net.Sockets.TcpClient;try{$t.Connect("""%host%""", %port%)}catch{};$t.Connected"
echo Open: %open%
pause