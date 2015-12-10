echo off

where dotnet.exe
if ERRORLEVEL 1 (
    echo Please install 'dotnet', say from 'https://azureclu.blob.core.windows.net/tools/dotnet-win-x64.latest.zip', unzip, then add its bin folder to the PATH
    exit /B
)

set root=%~dp0..\..
echo Build all clu source projects
"%ProgramFiles(x86)%\MSBuild\14.0\Bin\msbuild" %root%\build.proj /t:build >NUL

if ERRORLEVEL 1 (
   echo Build source project failed. To repro, run: msbuild build.proj /t:build
) 

@powershell -file %~dp0\BuildDrop.ps1
set mscluCfg=%root%\drop\clurun\win7-x64\msclu.cfg
if not exist %mscluCfg% (
    copy /Y %root%\src\CLU\clurun\msclu.cfg %root%\drop\clurun\win7-x64
)

echo ^(Get-Content "%mscluCfg%"^) ^| ForEach-Object { $_ -replace "TOFILL", "%root%\drop\CommandRepo" } ^| Set-Content "%mscluCfg%"^ >"%temp%\Rep.ps1"
@powershell -file %temp%\Rep.ps1

set DebugCLU=
%root%\drop\clurun\win7-x64\clurun.exe --install
%root%\drop\clurun\win7-x64\clurun.exe --install Microsoft.Azure.Commands.Profile
%root%\drop\clurun\win7-x64\clurun.exe --install Microsoft.Azure.Commands.Resources
%root%\drop\clurun\win7-x64\clurun.exe --install Microsoft.Azure.Commands.Websites
%root%\drop\clurun\win7-x64\clurun.exe --install Microsoft.Azure.Commands.Management.Storage
set DebugCLU=1
set Path=%Path%;%root%\drop\clurun\win7-x64
