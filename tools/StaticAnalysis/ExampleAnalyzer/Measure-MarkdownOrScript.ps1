<#
    .SYNOPSIS
        The script to find examples in ".md" and analyze the examples by custom rules.
    .NOTES
        File Name: Measure-MarkdownOrScript.ps1
#>

#Requires -Modules PSScriptAnalyzer

[CmdletBinding(DefaultParameterSetName = "Markdown")]
param (
    [Parameter(Mandatory, HelpMessage = "Markdown searching paths. Empty for current path. Supports wildcard.", ParameterSetName = "Markdown")]
    [AllowEmptyString()]
    [string[]]$MarkdownPaths,
    [Parameter(Mandatory, HelpMessage = "PowerShell scripts searching paths. Empty for current path. Supports wildcard.", ParameterSetName = "Script")]
    [AllowEmptyString()]
    [string[]]$ScriptPaths,
    [Parameter(HelpMessage = "PSScriptAnalyzer custom rules paths. Empty for current path. Supports wildcard.")]
    [string[]]$RulePaths,
    [string]$CodeMapPath,
    [switch]$Recurse,
    [switch]$IncludeDefaultRules,
    [string]$OutputFolder = "$PSScriptRoot\..\..\..\artifacts\StaticAnalysisResults\ExampleAnalysis",
    [switch]$AnalyzeScriptsInFile,
    [switch]$OutputScriptsInFile,
    [switch]$CleanScripts
)

. $PSScriptRoot\utils.ps1

$analysisResultsTable = @()
$codeMap = @()
$totalLine = 1

# Find examples in "help\*.md", output ".ps1"
if ($PSCmdlet.ParameterSetName -eq "Markdown") {
    # Clean caches, remove files in "output" folder
    if ($OutputScriptsInFile.IsPresent) {
        Remove-Item $OutputFolder\TempScript.ps1 -ErrorAction SilentlyContinue
        Remove-Item $OutputFolder\TempCodeMap.csv -ErrorAction SilentlyContinue
        Remove-Item $PSScriptRoot\..\..\..\artifacts\StaticAnalysisResults\ExampleIssues.csv -ErrorAction SilentlyContinue
        Remove-Item $OutputFolder -ErrorAction SilentlyContinue
    }
    $null = New-Item -ItemType Directory -Path $OutputFolder -ErrorAction SilentlyContinue
    $null = New-Item -ItemType File  $OutputFolder\TempScript.ps1
    # When the input $MarkdownPaths is the path of txt file
    if ($MarkdownPaths -cmatch ".*\.txt") {
        $MarkdownPath = Get-Content $MarkdownPaths
    }
    # When the input $MarkdownPaths is the path of a folder
    else{
        $MarkdownPath = $MarkdownPaths
    }
    foreach($_ in Get-ChildItem $MarkdownPath -Recurse:$Recurse.IsPresent){
        # Filter the .md of overview in "\help\"
        if ((Get-Item -Path $_.FullName).Directory.Name -eq "help" -and $_.FullName -cmatch ".*\.md" -and $_.BaseName -cmatch "^[A-Z][a-z]+-([A-Z][a-z0-9]*)+$") {
            if((Get-Item -Path $_.FullName).Directory.Parent.Name -eq "netcoreapp3.1"){
                continue
            }
            Write-Output "Searching in file $($_.FullName) ..."
            if((Get-Item -Path $_.FullName).Directory.Parent.Parent.Name -ne "src"){
                $module = (Get-Item -Path $_.FullName).Directory.Parent.Parent.Name
            }
            else{
               $module = (Get-Item -Path $_.FullName).Directory.Parent.Name 
            }
            $cmdlet = $_.BaseName
            $result = Measure-SectionMissingAndOutputScript $module $cmdlet $_.FullName `
                -OutputScriptsInFile:$OutputScriptsInFile.IsPresent `
                -OutputFolder $OutputFolder `
                -TotalLine $totalLine
            $analysisResultsTable += $result.Errors
            $codeMap += $result.CodeMap
            $totalLine = $result.TotalLine
        }
    }
    $codeMap| Export-Csv "$OutputFolder\TempCodeMap.csv" -NoTypeInformation
    if ($AnalyzeScriptsInFile.IsPresent) {
        $ScriptPaths = "$OutputFolder\TempScript.ps1"
        $CodeMapPath = "$OutputFolder\TempCodeMap.csv"
    }
}

# Analyze scripts
if ($PSCmdlet.ParameterSetName -eq "Script" -or $AnalyzeScriptsInFile.IsPresent) {
    # Read code map from file
    $codeMap = Import-Csv $CodeMapPath
    # Read and analyze ".ps1" in \ScriptsByExample
    Write-Output "Analyzing file ..."
    $analysisResultsTable += Get-ScriptAnalyzerResult (Get-Item -Path $ScriptPaths) $RulePaths -IncludeDefaultRules:$IncludeDefaultRules.IsPresent $codeMap -ErrorAction Continue
    
    # Summarize analysis results, output in Result.csv
    if($analysisResultsTable){
        $analysisResultsTable| Where-Object {$_ -ne $null} | Export-Csv "$PSScriptRoot\..\..\..\artifacts\StaticAnalysisResults\ExampleIssues.csv" -NoTypeInformation
    }
}

# Clean caches
if ($CleanScripts.IsPresent) {
    Remove-Item $ScriptPaths -Exclude *.csv -Recurse -ErrorAction Continue
}