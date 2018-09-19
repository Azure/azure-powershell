@echo on

cd /d "%~dp0"

if "%EMULATED%"=="true" if DEFINED APPCMD goto emulator_setup
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

:emulator_setup
echo Running in emulator adding iisnode to application host config
FOR /F "tokens=1,2 delims=/" %%a in ("%APPCMD%") DO set FN=%%a&set OPN=%%b
if "%OPN%"=="%OPN:apphostconfig:=%" (
    echo "Could not parse appcmd '%appcmd% for configuration file, exiting"
    goto error
)

set IISNODE_BINARY_DIRECTORY=%programfiles(x86)%\iisnode-dev\release\x64
set IISNODE_SCHEMA=%programfiles(x86)%\iisnode-dev\release\x64\iisnode_schema.xml

if "%PROCESSOR_ARCHITECTURE%"=="AMD64" goto start
set IISNODE_BINARY_DIRECTORY=%programfiles%\iisnode-dev\release\x86
set IISNODE_SCHEMA=%programfiles%\iisnode-dev\release\x86\iisnode_schema_x86.xml


:start
set

echo Using iisnode binaries location '%IISNODE_BINARY_DIRECTORY%'
echo installing iisnode module using AppCMD alias %appcmd%
%appcmd% install module /name:"iisnode" /image:"%IISNODE_BINARY_DIRECTORY%\iisnode.dll"

set apphostconfigfile=%OPN:apphostconfig:=%
powershell -c "set-executionpolicy unrestricted"
powershell .\ChangeConfig.ps1 %apphostconfigfile%
if %ERRORLEVEL% neq 0 goto error

copy /y "%IISNODE_SCHEMA%" "%programfiles%\IIS Express\config\schema\iisnode_schema.xml"
if %ERRORLEVEL% neq 0 goto error
exit /b 0
