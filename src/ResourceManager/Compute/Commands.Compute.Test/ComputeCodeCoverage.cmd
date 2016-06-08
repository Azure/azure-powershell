@echo off

set "ROOTDIR=..\..\..\..\"
set "VSTOOLSDIR=C:\Program Files (x86)\Microsoft Visual Studio 12.0\Team Tools\Performance Tools\"

set "VSINSTR="%VSTOOLSDIR%vsinstr.exe""
set "VSPERFCMD="%VSTOOLSDIR%VSPerfCmd.exe""
set "RESULT="%ROOTDIR%Project.coverage""
set "DLL="%ROOTDIR%src\ResourceManager\Compute\Commands.Compute.Test\bin\Debug\Microsoft.Azure.Commands.Compute.dll""
set "TEST="%ROOTDIR%src\ResourceManager\Compute\Commands.Compute.Test\bin\Debug\Microsoft.Azure.Commands.Compute.Test.dll""
set "XUNIT="%ROOTDIR%packages\xunit.runner.console.2.0.0\tools\xunit.console.x86.exe""

%VSINSTR% /COVERAGE %DLL%

%VSPERFCMD% /start:COVERAGE /OUTPUT:%RESULT%

%XUNIT% %TEST%

%VSPERFCMD% /SHUTDOWN
