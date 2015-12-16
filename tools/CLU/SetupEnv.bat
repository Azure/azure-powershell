echo off
setlocal
set root=%~dp0..\..

REM build cmdlets packages
set DebugCLU=
call %~dp0\BuildAndInstallClu.bat
set Path=%Path%;%root%\drop\clurun\win7-x64
REM run 'azure help' to verify all are wired up
azure.bat help
if ERRORLEVEL 1 (
   echo Build and deploy clu package failed
   exit /B 1
) 
set DebugCLU=1

