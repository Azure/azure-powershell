@echo on

cd /d "%~dp0"

if "%EMULATED%"== "true" exit /b 0

echo Granting permissions for Network Service to the web root directory...
icacls ..\ /grant "Network Service":(OI)(CI)W
if %ERRORLEVEL% neq 0 goto error
echo OK

echo Configuring powershell permissions
powershell -c "set-executionpolicy unrestricted"

echo Copying web.cloud.config to web.config...
copy /y ..\Web.cloud.config ..\Web.config
if %ERRORLEVEL% neq 0 goto error
echo OK

echo Downloading and installing runtime components
powershell .\download.ps1 '%RUNTIMEURL%' '%RUNTIMEURLOVERRIDE%'
if %ERRORLEVEL% neq 0 goto error

echo SUCCESS
exit /b 0

:error
echo FAILED
exit /b -1