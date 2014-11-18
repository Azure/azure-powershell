@echo on
cd /d "%~dp0"

if "%EMULATED%"=="true" goto setup_emulator

:start_cache
WindowsAzure.Caching.MemcacheShim\ClientPerfCountersInstaller.exe install
WindowsAzure.Caching.MemcacheShim\MemcacheShimInstaller.exe
if %ERRORLEVEL% neq 0 goto error

echo SUCCESS
exit /b 0

:setup_emulator
echo Downloading and installing cache runtime
powershell .\download.ps1 '%CACHERUNTIMEURL%'
if %ERRORLEVEL% neq 0 goto error

goto start_cache

:error
echo FAILED
exit /b -1