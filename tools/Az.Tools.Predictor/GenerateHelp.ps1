#Requires -Modules @{ ModuleName = 'Microsoft.PowerShell.PlatyPS'; ModuleVersion = '1.0.2' }
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
# Export-MamlCommandHelp appends a '<ModuleName>' subfolder under -OutputFolder, so target the
# artifact folder; the help lands at $ArtifactFolder/<ModuleName>/, i.e. the module folder.
Export-MamlCommandHelp -CommandHelp $cmdHelp -OutputFolder $ArtifactFolder -Force