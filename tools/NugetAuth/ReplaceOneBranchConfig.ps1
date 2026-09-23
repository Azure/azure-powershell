# Exchange the contents of OneBranchNuget.Config and Nuget.Config

$oneBranchConfigPath = Join-Path $PSScriptRoot 'OneBranchNuget.Config'
$devConfigPath = Join-Path ($PSScriptRoot | Split-path -Parent | Split-path -Parent) 'Nuget.Config'

# Read content as byte arrays to preserve exact formatting
$oneBranchContent = [System.IO.File]::ReadAllText($oneBranchConfigPath, [System.Text.Encoding]::UTF8)
$devContent = [System.IO.File]::ReadAllText($devConfigPath, [System.Text.Encoding]::UTF8)

# Write content as byte arrays to preserve exact formatting
[System.IO.File]::WriteAllText($devConfigPath, $oneBranchContent, [System.Text.Encoding]::UTF8)
[System.IO.File]::WriteAllText($oneBranchConfigPath, $devContent, [System.Text.Encoding]::UTF8)
