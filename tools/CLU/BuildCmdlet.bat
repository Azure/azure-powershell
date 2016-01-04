echo off
Setlocal EnableDelayedExpansion

set DebugCLU=
set root=%~dp0..\..
if not "%1"=="" (
    @powershell -file %~dp0\BuildDrop.ps1 -commandPackagesToBuild %1 --excludeCluRun
    %root%\drop\clurun\win7-x64\clurun.exe --install %1
) else (
    @powershell -file %~dp0\BuildDrop.ps1 -excludeCluRun
    %root%\drop\clurun\win7-x64\clurun.exe --install
    %root%\drop\clurun\win7-x64\clurun.exe --install Microsoft.Azure.Commands.Profile
    %root%\drop\clurun\win7-x64\clurun.exe --install Microsoft.Azure.Commands.Resources
    %root%\drop\clurun\win7-x64\clurun.exe --install Microsoft.Azure.Commands.Resources.Cmdlets
    %root%\drop\clurun\win7-x64\clurun.exe --install Microsoft.Azure.Commands.Websites
    %root%\drop\clurun\win7-x64\clurun.exe --install Microsoft.Azure.Commands.Network
    %root%\drop\clurun\win7-x64\clurun.exe --install Microsoft.Azure.Commands.Management.Storage
)