echo off
setlocal enabledelayedexpansion
set root=%~dp0..\..

set action=%1
set storageUrl=%2
set key=%3
set downloadFolder=%4

if "%1" == "upload" (
    
    IF EXIST %root%\drop\*.tar.* del /Q /F %root%\drop\*.tar.*

    %~dp0\AzCopy\AzCopy.exe /Source:https://azuresdktools.blob.core.windows.net/7-zip  /S /Dest:%~dp0\7-zip  /Y
    if ERRORLEVEL 1 (
        echo failed to download 7-zip to local 7-zip folder
        exit /B 1  
    )
     
    %~dp0\7-Zip\7z.exe a -ttar -so %root%\drop\ubuntu.14.04-x64.latest.tar %root%\drop\clurun\ubuntu.14.04-x64 | %~dp0\7-Zip\7z.exe a -si %root%\drop\ubuntu.14.04-x64.latest.tar.gz
    if ERRORLEVEL 1 (
        echo failed to create tar.gz file ubuntu.14.04-x64.latest.tar.gz
        exit /B 1  
    )

    %~dp0\7-Zip\7z.exe a -ttar -so %root%\drop\win7-x64.latest.tar %root%\drop\clurun\win7-x64 | %~dp0\7-Zip\7z.exe a -si %root%\drop\win7-x64.latest.tar.gz
    if ERRORLEVEL 1 (
        echo failed to create tar.gz file win7-x64.latest.tar.gz
        exit /B 1  
    )

    %~dp0\7-Zip\7z.exe a -ttar -so %root%\drop\osx.10.10-x64.latest.tar %root%\drop\clurun\osx.10.10-x64 | %~dp0\7-Zip\7z.exe a -si %root%\drop\osx.10.10-x64.latest.tar.gz
    if ERRORLEVEL 1 (
        echo failed to create tar.gz file osx.10.10-x64.latest.tar.gz
        exit /B 1  
    )

    %~dp0\AzCopy\AzCopy.exe /Source:%root%\drop /Dest:%storageUrl% /DestKey:%key% /Pattern:*.tar.gz /Y
    if ERRORLEVEL 1 (
        echo failed to upload installers from "%root%\drop" to "%storageUrl%"
        exit /B 1
    )
) 

if "%1" == "download" (
    echo download the latest installer
    echo  %~dp0\AzCopy\AzCopy.exe /Source:%storageUrl% /SourceKey:%key% /Dest:%downloadFolder% /Pattern:*.gz /Y /S
    %~dp0\AzCopy\AzCopy.exe /Source:%storageUrl% /SourceKey:%key% /Dest:%downloadFolder% /Pattern:*.gz /Y /S
    if ERRORLEVEL 1 (
        echo failed to download installers from "%storageUrl%" to "%downloadFolder%"
        exit /B 1
    )
)

if not "%1" == "download" (
    if not "%1" == "upload" (
        echo Invalid command line arguments, examples
        echo %0 upload storage-blob-url "storage-key"
        echo %0 download storage-blob-url "storage-key" download-folder
    )
)
