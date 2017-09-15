param([string] $Config="Release")

$outPath = Join-Path $PSScriptRoot -ChildPath "..\..\src\Package\$Config\ResourceManager\AzureResourceManager\AzureRM.Compute.Experiments\"
Write-Host $outPath
Copy-Item -Path $PSScriptRoot -Destination $outPath -Recurse -Exclude "AzureRM.Compute.Experiments.Tests.ps1", "publish-dev.ps1", "copy-dev.ps1" -Force


