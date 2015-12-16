echo off
setlocal
set root=%~dp0..\..
echo Build all clu source projects
"%ProgramFiles(x86)%\MSBuild\14.0\Bin\msbuild" %root%\build.proj /t:build >NUL

if ERRORLEVEL 1 (
   echo Build source project failed. To repro, run: msbuild build.proj /t:build
   exit /B 1
) 

REM build cmdlets packages
set DebugCLU=
call %~dp0\BuildAndInstallClu.bat
set Path=%Path%;%root%\drop\clurun\win7-x64
REM run 'azure help' to verify all are wired up
azure help
if ERRORLEVEL 1 (
   echo Build and deploy clu package failed
   exit /B 1
) 
set DebugCLU=1

