@echo on
cd /d "%~dp0"

if "%EMULATED%"=="true" goto emulator

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

:emulator

icacls %RoleRoot%\approot /grant "Everyone":F /T

:: Detect PHP Runtime Path
where php-cgi.exe > tmpFile
set /p phprt= < tmpFile
del tmpFile
if DEFINED phprt goto setup_iis
SET phprt=%ProgramFiles%\PHP\v5.3\php-cgi.exe
if DEFINED ProgramFiles(x86) SET phprt=%ProgramFiles(x86)%\PHP\v5.3\php-cgi.exe

:setup_iis
%appcmd% set config -section:system.webServer/fastCgi /+"[fullPath='%phprt%',arguments='',maxInstances='4',idleTimeout='300',activityTimeout='30',requestTimeout='90',queueLength='1000',instanceMaxRequests='200',protocol='NamedPipe',flushNamedPipe='False',rapidFailsPerMinute='10']" /commit:apphost
%appcmd% set config -section:system.webServer/handlers /+"[name='PHP-FastCGI',path='*.php',modules='FastCgiModule',verb='*', scriptProcessor='%phprt%']" /commit:apphost

exit /b 0

:error

echo FAILED
exit /b -1