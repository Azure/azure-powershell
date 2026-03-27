$module = 'AzDev'
$artifacts = Join-Path $PSScriptRoot ".." ".." "artifacts"
$moduleOut = Join-Path $artifacts $module

if (Test-Path $moduleOut) { Remove-Item $moduleOut -Recurse -Force }
dotnet publish (Join-Path $PSScriptRoot "src") --sc -o (Join-Path $moduleOut "bin")
Copy-Item (Join-Path $PSScriptRoot $module "*") $moduleOut -Recurse -Force