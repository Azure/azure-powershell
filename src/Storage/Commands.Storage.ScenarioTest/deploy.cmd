@echo off
setlocal
 
if "%~1" == "" (
    echo Usage: deploy [Destination Directory]
    echo Example: copies test files into test run folder :
    echo   deploy "C:\test"
    exit /b 1
)
 
set dest=%~1
if %dest:~-1%==\ set dest=%dest:~0,-1%
 
  rem %~d0 expands the drive letter
  rem %~p0 expands the path to this file
set localdir=%~d0%~p0

set commonPath=..\..\..\common
set binPath=..\..\..\..\bin
set symbolPath=..\..\..\Symbols.pri
 
mkdir "%dest%"

rem deploy the test cases
xcopy /y /e /c "%localdir%*"  "%dest%"\
mkdir "%dest%"\Data\Upload
mkdir "%dest%"\Data\Download

rem deploy pdb files
xcopy /y /e /c "%localdir%"%symbolPath%\tests\dll\StorageTestLib.pdb "%dest%"\
xcopy /y /e /c "%localdir%"%symbolPath%\tests\dll\PowerShellTest.pdb "%dest%"\
xcopy /y /e /c "%localdir%"%symbolPath%\tests\dll\MsTest.pdb "%dest%"\
xcopy /y /e /c "%localdir%"%symbolPath%\tests\dll\MsTestLib.pdb "%dest%"\
xcopy /y /e /c "%localdir%"%symbolPath%\tests\exe\MsTest2.pdb "%dest%"\

endlocal
