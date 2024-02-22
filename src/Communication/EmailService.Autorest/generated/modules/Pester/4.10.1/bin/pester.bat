@echo off
SET DIR=%~dp0%
SET ARGS=%*
if NOT '%1'=='' SET ARGS=%ARGS:"=\"%
if '%1'=='/?' goto usage
if '%1'=='-?' goto usage
if '%1'=='?' goto usage
if '%1'=='/help' goto usage
if '%1'=='help' goto usage

@PowerShell -NonInteractive -NoProfile -ExecutionPolicy Bypass -Command ^
 "& Import-Module '%DIR%..\Pester.psm1';  & { Invoke-Pester -EnableExit %ARGS%}"

goto finish
:usage
if NOT '%2'=='' goto help

echo To run pester for tests, just call pester or runtests with no arguments
echo.
echo Example: pester
echo.
echo For Detailed help information, call pester help with a help topic. See
echo help topic about_Pester for a list of all topics at the end
echo.
echo Example: pester help about_Pester
echo.
goto finish

:help
@PowerShell -NonInteractive -NoProfile -ExecutionPolicy Bypass -Command ^
  "& Import-Module '%DIR%..\Pester.psm1'; & { Get-Help %2}"

:finish
exit /B %errorlevel%
