echo off
Setlocal EnableDelayedExpansion

set root=%~dp0..\..
if not "%1"=="" (
    @powershell -file %~dp0\BuildDrop.ps1 -packageName %1 --excludeCluRun
) else (
    @powershell -file %~dp0\BuildDrop.ps1 -excludeCluRun
)
set DebugCLU=
%root%\drop\clurun\win7-x64\clurun.exe --install %1
set DebugCLU=1
