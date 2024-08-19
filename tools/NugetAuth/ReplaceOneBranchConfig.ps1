$oneBranchConfigPath = Join-Path $PSScriptRoot 'OneBranchNuget.Config'
$devConfigPath = Join-Path ($PSScriptRoot | Split-path -Parent | Split-path -Parent) 'Nuget.Config'

Get-Content $oneBranchConfigPath -Raw | Set-Content $devConfigPath -Force