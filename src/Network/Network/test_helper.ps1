#Requires -PSEdition Core
[CmdletBinding()]
param(
    [string]$RepoRoot = (Resolve-Path (Join-Path $PSScriptRoot '..' '..' '..')).Path,
    [string]$OutputFolder = (Join-Path ([System.IO.Path]::GetTempPath()) 'Md')
)

$NetworkTestRoot = Join-Path $RepoRoot 'src' 'Network' 'Network.Test'
$CommonScript = Join-Path $NetworkTestRoot 'ScenarioTests' 'Common.ps1'
if (Test-Path $CommonScript) { Import-Module $CommonScript }

# Prefer the freshly built module under artifacts/Debug; fall back to an installed module.
function Import-AzModuleForHelp {
    param([Parameter(Mandatory)] [string] $Name)
    $builtManifest = Join-Path $RepoRoot 'artifacts' 'Debug' $Name "$Name.psd1"
    if (Test-Path $builtManifest) {
        Import-Module $builtManifest -Force
    }
    else {
        Import-Module $Name -Force
    }
}
Import-AzModuleForHelp -Name 'Az.Accounts'
Import-AzModuleForHelp -Name 'Az.Network'

Import-Module Microsoft.PowerShell.PlatyPS -MinimumVersion 1.0.2 -Force

New-MarkdownCommandHelp -ModuleInfo (Get-Module Az.Network) -OutputFolder $OutputFolder -Force
# To refresh the module page from the generated markdown:
# $help = Import-MarkdownCommandHelp -Path (Join-Path $RepoRoot 'src' 'Network' 'Network' 'help' '*-*.md')
# Update-MarkdownModuleFile -Path (Join-Path $RepoRoot 'src' 'Network' 'Network' 'help' 'Az.Network.md') -CommandHelp $help -NoBackup