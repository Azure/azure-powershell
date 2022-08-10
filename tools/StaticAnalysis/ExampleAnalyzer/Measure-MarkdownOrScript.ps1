<#
    .SYNOPSIS
        The script to find examples in ".md" and analyze the examples by custom rules.
    .PARAMETER MarkdownPaths
    Markdown searching paths. Empty for current path. Supports wildcard.
    .PARAMETER ScriptPath
    PowerShell script searching paths. Empty for current path. Supports wildcard.
    .PARAMETER RulePaths
    PSScriptAnalyzer custom rules paths. Empty for current path. Supports wildcard.
    .PARAMETER MarkdownRecurse
    To search markdowns recursively in the folders.
    .PARAMETER ScriptRecurse
    To search scripts recursively in the folders.
    .PARAMETER IncludeDefaultRules
    To analyze default rules provided by PSScriptAnalyzer.
    .PARAMETER OutputFolder
    Folder path storing output files.
    .PARAMETER SkipAnalyzing
    To skip analyzing step. Only extracting example codes from markdowns to the temp script.
    .PARAMETER CleanScripts
    To clean the temp script.
    .NOTES
        File Name: Measure-MarkdownOrScript.ps1
#>

#Requires -Modules PSScriptAnalyzer

[CmdletBinding(DefaultParameterSetName = "Markdown")]
param (
    [Parameter(Mandatory, ParameterSetName = "Markdown")]
    [AllowEmptyString()]
    [string[]]$MarkdownPaths,
    [Parameter(Mandatory, ParameterSetName = "Script")]
    [AllowEmptyString()]
    [string[]]$ScriptPaths,
    [string[]]$RulePaths,
    [Parameter(ParameterSetName = "Markdown")]
    [switch]$MarkdownRecurse,
    [Parameter(ParameterSetName = "Script")]
    [switch]$ScriptRecurse,
    [switch]$IncludeDefaultRules,
    [string]$OutputFolder = "$PSScriptRoot\..\..\..\artifacts\StaticAnalysisResults\ExampleAnalysis",
    [Parameter(ParameterSetName = "Markdown")]
    [switch]$SkipAnalyzing,
    [switch]$CleanScripts
)

. $PSScriptRoot\utils.ps1

$analysisResultsTable = @()
$codeMap = @()
$totalLine = 1

# Clean caches, remove files in "output" folder
Remove-Item $OutputFolder\TempScript.ps1 -ErrorAction SilentlyContinue
Remove-Item $OutputFolder\TempCodeMap.csv -ErrorAction SilentlyContinue
Remove-Item $PSScriptRoot\..\..\..\artifacts\StaticAnalysisResults\ExampleIssues.csv -ErrorAction SilentlyContinue
Remove-Item $OutputFolder -ErrorAction SilentlyContinue
# Create output folder and temp script
$null = New-Item -ItemType Directory -Path $OutputFolder -ErrorAction SilentlyContinue
$null = New-Item -ItemType File  $OutputFolder\TempScript.ps1

# Find examples in "help\*.md", output ".ps1"
if ($PSCmdlet.ParameterSetName -eq "Markdown") {
    # When the input $MarkdownPaths is the path of txt file contained markdown paths
    if ($MarkdownPaths -cmatch ".*\.txt") {
        $MarkdownPath = Get-Content $MarkdownPaths
    }
    # When the input $MarkdownPaths is the path of a folder
    else{
        $MarkdownPath = $MarkdownPaths
    }
    foreach($_ in Get-ChildItem $MarkdownPath -Recurse:$MarkdownRecurse.IsPresent){
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
                -OutputFolder $OutputFolder `
                -TotalLine $totalLine
            $analysisResultsTable += $result.Errors
            $codeMap += $result.CodeMap
            $totalLine = $result.TotalLine
        }
    }
    $codeMap| Export-Csv "$OutputFolder\TempCodeMap.csv" -NoTypeInformation
}

# Analyze scripts
if ($PSCmdlet.ParameterSetName -eq "Script" -or !$SkipAnalyzing.IsPresent) {
    $TempScriptPath = "$OutputFolder\TempScript.ps1"
    if ($PSCmdlet.ParameterSetName -eq "Script"){
        $codeMap = Set-ScriptsIntoSingleScript -ScriptPaths $ScriptPaths -Recurse:$ScriptRecurse.IsPresent -OutputFolder $OutputFolder
        $codeMap| Export-Csv "$OutputFolder\TempCodeMap.csv" -NoTypeInformation
    }
    # Read and analyze ".ps1" in \ScriptsByExample
    Write-Output "Analyzing file ..."
    $analysisResultsTable += Get-ScriptAnalyzerResult -ScriptPath $TempScriptPath -RulePaths $RulePaths -IncludeDefaultRules:$IncludeDefaultRules.IsPresent -CodeMap $codeMap -ErrorAction Continue
    
    # Summarize analysis results, output in Result.csv
    if($analysisResultsTable){
        $analysisResultsTable| Where-Object {$_ -ne $null} | Export-Csv "$PSScriptRoot\..\..\..\artifacts\StaticAnalysisResults\ExampleIssues.csv" -NoTypeInformation
    }
}

# Clean caches
if ($CleanScripts.IsPresent) {
    Remove-Item $OutputFolder\TempScript.ps1 -ErrorAction Continue
    Remove-Item $OutputFolder\TempCodeMap.csv -ErrorAction Continue
}