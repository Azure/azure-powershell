if "%EMULATED%"=="true" goto :EOF

::Install PHP Runtime

cd "%~dp0"

md "%~dp0appdata"
cd "%~dp0appdata"
cd "%~dp0"

reg add "hku\.default\software\microsoft\windows\currentversion\explorer\user shell folders" /v "Local AppData" /t REG_EXPAND_SZ /d "%~dp0appdata" /f

".\webpicmdline" /Products:PHP53,SQLDriverPHP53IIS,PHPManager /AcceptEula  >> ..\startup-tasks-log.txt 2>>..\startup-tasks-error-log.txt

reg add "hku\.default\software\microsoft\windows\currentversion\explorer\user shell folders" /v "Local AppData" /t REG_EXPAND_SZ /d %%USERPROFILE%%\AppData\Local /f

::Path, php.ini handling

powershell.exe Set-ExecutionPolicy Unrestricted
powershell.exe .\setup.ps1

::IIS regs

icacls %RoleRoot%\approot /grant "Everyone":F /T
if "%WORKER%"=="false" (
%WINDIR%\system32\inetsrv\appcmd.exe set config -section:system.webServer/fastCgi /-"[fullPath='%ProgramFiles(x86)%\PHP\v5.3\php-cgi.exe'].environmentVariables.[name='RoleRoot']" /commit:apphost
%WINDIR%\system32\inetsrv\appcmd.exe set config -section:system.webServer/fastCgi /+"[fullPath='%ProgramFiles(x86)%\PHP\v5.3\php-cgi.exe'].environmentVariables.[name='RoleRoot',value='%RoleRoot%']" /commit:apphost
%WINDIR%\system32\inetsrv\appcmd.exe set config -section:system.webServer/fastCgi /+"[fullPath='%ProgramFiles(x86)%\PHP\v5.3\php-cgi.exe'].environmentVariables.[name='PATH',value='%PATH%;%RoleRoot%\base\x86']" /commit:apphost 
)

SET ERRORLEVEL=0