#Requires -Modules platyPS

[CmdletBinding()]
Param(
    [Parameter()]
    [Switch]$ValidateMarkdownHelp,

    [Parameter()]
    [Switch]$GenerateMamlHelp
)

Import-Module "$PSScriptRoot\HelpGeneration\HelpGeneration.psm1"

$HelpFolders = Get-ChildItem "help" -Recurse -Directory | where { $_.FullName -like "*Debug*" }

# ---------------------------------------------------------------------------------------------

if ($ValidateMarkdownHelp)
{
    New-Item -Path "$PSScriptRoot\HelpGeneration\Exceptions" -Name NewValidateHelpExceptions.csv -ItemType File -Force | Out-Null

    Add-Content "$PSscriptRoot\HelpGeneration\Exceptions\NewValidateHelpExceptions.csv" "Module,Target,Description"

    $HelpFolders | foreach { Validate-MarkdownHelp $_ }

    $Exceptions = Import-Csv "$PSScriptRoot\HelpGeneration\Exceptions\NewValidateHelpExceptions.csv"

    $Exceptions | ft

    Remove-Item -Path "$PSScriptRoot\HelpGeneration\Exceptions\NewValidateHelpExceptions.csv" -Force
}

if ($GenerateMamlHelp)
{
    $HelpFolders | foreach { Generate-MamlHelp $_ }
}