@echo on
cd /d "%~dp0"

echo Granting permissions for Network Service to the web root directory...
icacls ..\ /grant "Network Service":(OI)(CI)W
if %ERRORLEVEL% neq 0 goto error
echo OK

if "%EMULATED%"=="true" exit /b 0

echo Configuring powershell permissions
powershell -c "set-executionpolicy unrestricted"

echo Downloading and installing runtime components
powershell .\download.ps1 '%RUNTIMEURL%' '%RUNTIMEURLOVERRIDE%'
if %ERRORLEVEL% neq 0 goto error

echo SUCCESS
exit /b 0

:error

echo FAILED
exit /b -1