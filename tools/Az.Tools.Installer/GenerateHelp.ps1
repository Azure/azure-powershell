#Requires -Modules Microsoft.PowerShell.PlatyPS
[CmdletBinding()]
Param(
    [Parameter()]
    [string]$ArtifactFolder,
    [Parameter()]
    [string]$ModuleName
)

$ModuleFolder = Join-Path -Path $ArtifactFolder -ChildPath $ModuleName
$TempDocFolder = Join-Path -Path $ModuleFolder -ChildPath 'help'
Import-Module $ModuleFolder
New-MarkdownCommandHelp -ModuleInfo (Get-Module $ModuleName) -OutputFolder $TempDocFolder -Force
$cmdHelp = Import-MarkdownCommandHelp -Path (Join-Path $TempDocFolder '*-*.md')
Export-MamlCommandHelp -CommandHelp $cmdHelp -OutputFolder $ModuleFolder -Force