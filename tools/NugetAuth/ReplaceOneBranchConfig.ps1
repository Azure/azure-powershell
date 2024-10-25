$oneBranchConfigPath = Join-Path $PSScriptRoot 'OneBranchNuget.Config'
$devConfigPath = Join-Path ($PSScriptRoot | Split-path -Parent | Split-path -Parent) 'Nuget.Config'

$oneBranchContent = Get-Content $oneBranchConfigPath -Raw
$devContent = Get-Content $devConfigPath -Raw

$oneBranchContent | Set-Content $devConfigPath -Force
$devContent | Set-Content oneBranchConfigPath -Force