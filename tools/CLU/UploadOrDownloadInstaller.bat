echo off
setlocal enabledelayedexpansion
set root=%~dp0..\..

set action=%1
set storageUrl=%2
set key=%3
set downloadFolder=%4
set dropBaseName=ubuntu.14.04-x64
set archiveFileName=%dropBaseName%.latest.tar
set archive=%root%\drop\%archiveFileName%

if "%1" == "upload" (
    del /Q /F %root%\drop\*.gz
    %~dp0\7-Zip\7z.exe a -ttar -so %archive% %root%\drop\clurun\ubuntu.14.04-x64 | %~dp0\7-Zip\7z.exe a -si %archive%.gz
    if ERRORLEVEL 1 (
        echo failed to create tar.gz file "%archive%.gz"
        exit /B 1  
    )
    %~dp0\AzCopy\AzCopy.exe /Source:%root%\drop /Dest:%storageUrl% /DestKey:%key% /Pattern:%archiveFileName%.gz /Y

    if ERRORLEVEL 1 (
        echo failed to upload installers from "%root%\drop\%archiveFileName%.gz" to "%storageUrl%"
        exit /B 1
    )
) 

if "%1" == "download" (
    echo download the latest installer
    %~dp0\AzCopy\AzCopy.exe /Source:%storageUrl% /SourceKey:%key% /Dest:%downloadFolder% /Pattern:%archiveFileName%.gz /Y /S
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
