pushd %~dp0
rmdir /s /q .\lib
mkdir .\lib\net45
pushd ..\..
del /q /f *.nupkg
copy .\lib\bin\Release\Microsoft.WindowsAzure.Storage.DataMovement.dll .\tools\nupkg\lib\net45
.\.nuget\nuget.exe pack .\tools\nupkg\Microsoft.Azure.Storage.DataMovement.nuspec
popd
rmdir /s /q .\lib
popd