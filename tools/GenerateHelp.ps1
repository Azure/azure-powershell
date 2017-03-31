#Requires -Modules platyPS

[CmdletBinding()]
Param(
    [Parameter()]
    [Switch]$ValidateMarkdownHelp,

    [Parameter()]
    [Switch]$GenerateMamlHelp,

    [Parameter()]
    [string]$BuildConfig
)

Import-Module "$PSScriptRoot\HelpGeneration\HelpGeneration.psm1"

$HelpFolders = Get-ChildItem "help" -Recurse -Directory | where { $_.FullName -like "*$BuildConfig*" }

# ---------------------------------------------------------------------------------------------

if ($ValidateMarkdownHelp)
{
    if (!(Test-Path -Path "$PSScriptRoot\..\src\Package\Exceptions"))
    {
        New-Item -Path "$PSScriptRoot\..\src\Package" -Name "Exceptions" -ItemType Directory
    }

    Copy-Item -Path "$PSScriptRoot\HelpGeneration\Exceptions\ValidateHelpExceptions.csv" -Destination "$PSScriptRoot\..\src\Package\Exceptions"

    New-Item -Path "$PSScriptRoot\..\src\Package" -Name ValidateHelpExceptions.csv -ItemType File -Force | Out-Null

    Add-Content "$PSScriptRoot\..\src\Package\ValidateHelpExceptions.csv" "Module,Target,Description"

    $HelpFolders | foreach { Validate-MarkdownHelp $_ }

    $Exceptions = Import-Csv "$PSScriptRoot\..\src\Package\ValidateHelpExceptions.csv"
    
    if (($Exceptions | Measure-Object).Count -gt 0)
    {
        $Exceptions | ft
        throw "A markdown file containing the help for a cmdlet is incomplete. Please check the exceptions provided for more details."
    }

    Remove-Item -Path "$PSScriptRoot\..\src\Package\ValidateHelpExceptions.csv" -Force
}

if ($GenerateMamlHelp)
{
    $HelpFolders | foreach { Generate-MamlHelp $_ }
}