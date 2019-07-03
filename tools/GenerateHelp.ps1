#Requires -Modules platyPS
[CmdletBinding()]
Param(
    [Parameter()]
    [Switch]$ValidateMarkdownHelp,
    [Parameter()]
    [Switch]$GenerateMamlHelp,
    [Parameter()]
    [string]$BuildConfig,
    [Parameter()]
    [string]$FilteredModules
)

$ResourceManagerFolders = Get-ChildItem -Directory -Path "$PSScriptRoot\..\src" | Where-Object { $_.Name -ne 'lib' -and $_.Name -ne 'Package' -and $_.Name -ne 'packages' }
Import-Module "$PSScriptRoot\HelpGeneration\HelpGeneration.psm1"
$UnfilteredHelpFolders = Get-ChildItem -Include 'help' -Path "$PSScriptRoot\..\artifacts" -Recurse -Directory | where { $_.FullName -like "*$BuildConfig*" -and $_.FullName -notlike "*Stack*" }
$FilteredHelpFolders = $UnfilteredHelpFolders
if (![string]::IsNullOrEmpty($FilteredModules))
{
    $FilteredModulesList = $FilteredModules -split ';'
    $FilteredHelpFolders = @()
    foreach ($HelpFolder in $UnfilteredHelpFolders)
    {
        if (($FilteredModulesList | where { $HelpFolder -like "*\$($_)\*" }) -ne $null)
        {
            $FilteredHelpFolders += $HelpFolder
        }
    }
}

# ---------------------------------------------------------------------------------------------

if ($ValidateMarkdownHelp)
{
    $SuppressedExceptionsPath = "$PSScriptRoot\StaticAnalysis\Exceptions"
    if (!(Test-Path -Path $SuppressedExceptionsPath))
    {
        New-Item -Path "$PSScriptRoot\..\artifacts" -Name "Exceptions" -ItemType Directory
    }

    $Exceptions = @()
    foreach ($ServiceFolder in $ResourceManagerFolders)
    {
        $HelpFolder = (Get-ChildItem -Path $ServiceFolder.FullName -Filter "help" -Recurse -Directory)
        if ($HelpFolder -eq $null)
        {
            $Exceptions += $ServiceFolder.Name
        }
    }

    if ($Exceptions.Count -gt 0)
    {
        $Services = $Exceptions -Join ", "
        throw "No help folder found in the following services: $Services"
    }

    $NewExceptionsPath = "$PSScriptRoot\..\artifacts\StaticAnalysisResults"
    if (!(Test-Path -Path $NewExceptionsPath))
    {
        New-Item -Path "$PSScriptRoot\..\artifacts" -Name "StaticAnalysisResults" -ItemType Directory
    }
    
    Copy-Item -Path "$PSScriptRoot\HelpGeneration\Exceptions\ValidateHelpIssues.csv" -Destination $SuppressedExceptionsPath
    New-Item -Path $NewExceptionsPath -Name ValidateHelpIssues.csv -ItemType File -Force | Out-Null
    Add-Content "$NewExceptionsPath\ValidateHelpIssues.csv" "Target,Description"
    $FilteredHelpFolders | foreach { Test-AzMarkdownHelp $_.FullName $SuppressedExceptionsPath $NewExceptionsPath }
    $Exceptions = Import-Csv "$NewExceptionsPath\ValidateHelpIssues.csv"
    if (($Exceptions | Measure-Object).Count -gt 0)
    {
        $Exceptions | ft
        throw "A markdown file containing the help for a cmdlet is incomplete. Please check the exceptions provided for more details."
    }
    else
    {
        New-Item -Path $NewExceptionsPath -Name NoHelpIssues -ItemType File -Force | Out-Null
        Remove-Item -Path "$SuppressedExceptionsPath\ValidateHelpIssues.csv" -Force
        Remove-Item -Path "$NewExceptionsPath\ValidateHelpIssues.csv" -Force
    }
}

if ($GenerateMamlHelp)
{
    $FilteredHelpFolders | foreach { New-AzMamlHelp $_.FullName }
}