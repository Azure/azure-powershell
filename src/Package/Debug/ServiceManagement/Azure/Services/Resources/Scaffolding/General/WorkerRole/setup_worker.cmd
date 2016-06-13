@echo off

echo Granting permissions for Network Service to the deployment directory...
icacls . /grant "Users":(OI)(CI)F
if %ERRORLEVEL% neq 0 goto error
echo OK

if "%EMULATED%"=="true" exit /b 0

echo Configuring powershell permissions
powershell -c "set-executionpolicy unrestricted"

echo Downloading runtime components
powershell .\download.ps1 '%RUNTIMEURL%' '%RUNTIMEURLOVERRIDE%'
if %ERRORLEVEL% neq 0 goto error

echo SUCCESS
exit /b 0

:error

echo FAILED
exit /b -1