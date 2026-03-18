#Requires -Modules Microsoft.PowerShell.PlatyPS
[CmdletBinding()]
Param(
    [Parameter()]
    [string]$ArtifactFolder,
    [Parameter()]
    [string]$HelpFolder,
    [Parameter()]
    [string]$ModuleName
)

$ModuleFolder = Join-Path -Path $ArtifactFolder -ChildPath $ModuleName
Import-Module $ModuleFolder
$cmdHelp = Import-MarkdownCommandHelp -Path (Join-Path $HelpFolder '*-*.md')
Export-MamlCommandHelp -CommandHelp $cmdHelp -OutputFolder $ModuleFolder -Force