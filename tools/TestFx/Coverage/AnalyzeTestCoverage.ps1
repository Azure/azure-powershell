# ----------------------------------------------------------------------------------
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
    .SYNOPSIS
        The script is used to perform test coverage calculation.

    .DESCRIPTION
        The script will calculate the test coverage for each module based on the raw data generated during test run.
        The test coverage will be calculated and displayed at command, parameterset and parameter levels.
#>

param (
    [Parameter()]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $DataLocation,

    [Parameter()]
    [switch] $CalcBaseline
)

$psCommonParameters = @("-Break", "-Confirm", "-Debug", "-DefaultProfile", "-ErrorAction", "-ErrorVariable", "-HttpPipelineAppend", "-HttpPipelinePrepend", "-InformationAction", "-InformationVariable",
    "-OutBuffer", "-OutVariable", "-PassThru", "-PipelineVariable", "-Proxy", "-ProxyCredential", "-ProxyUseDefaultCredentials", "-Verbose", "-WarningAction", "-WarningVariable", "-WhatIf")

$repoDir = $PSScriptRoot | Split-Path | Split-Path | Split-Path
$debugDir = Join-Path -Path $repoDir -ChildPath "artifacts" | Join-Path -ChildPath "Debug"

$accountsModuleName = "Az.Accounts"
$accountsModulePsd1 = Join-Path -Path $debugDir -ChildPath $accountsModuleName | Join-Path -ChildPath "$accountsModuleName.psd1"
Import-Module $accountsModulePsd1 -Force

if ($PSBoundParameters.ContainsKey("DataLocation")) {
    $cvgDir = $DataLocation
}
else {
    $cvgDir = (Get-AzConfig -TestCoverageLocation).Value
}
$cvgRootDir = Join-Path -Path $cvgDir -ChildPath "TestCoverageAnalysis"
$cvgRawDir = Join-Path -Path $cvgRootDir -ChildPath "Raw"
$cvgResultsDir = Join-Path -Path $cvgRootDir -ChildPath "Results"

if (!(Test-Path -LiteralPath $cvgResultsDir -PathType Container)) {
    New-Item -Path $cvgRootDir -Name "Results" -ItemType Directory -Force | Out-Null
}
else {
    Get-ChildItem -Path $cvgResultsDir | Remove-Item -Force
}

$cvgReportCsv = Join-Path -Path $cvgResultsDir -ChildPath "Report.csv"
({} | Select-Object "Module", "TotalCommands", "TestedCommands", "CommandCoverage", "TotalParameterSets", "TestedParameterSets", "ParameterSetCoverage", "TotalParameters", "TestedParameters", "ParameterCoverage" | ConvertTo-Csv -NoTypeInformation)[0] | Out-File -LiteralPath $cvgReportCsv -Encoding utf8 -Force

if ($CalcBaseline.IsPresent) {
    $cvgBaselineCsv = Join-Path -Path $cvgResultsDir -ChildPath "Baseline.csv"
    ({} | Select-Object "Module", "CommandCoverage" | ConvertTo-Csv -NoTypeInformation)[0] | Out-File -LiteralPath $cvgBaselineCsv -Encoding utf8 -Force
}

$overallCommandsCount = 0
$overallTestedCommandsCount = 0

$allModules = Get-ChildItem -Path $debugDir -Filter "Az.*" -Directory -Name
foreach ($moduleName in $allModules) {
    $simpleModuleName = $moduleName.Substring(3)
    $hasRawData = $true

    $cvgRawCsv = Join-Path -Path $cvgRawDir -ChildPath "$moduleName.csv"
    if (!(Test-Path $cvgRawCsv)) {
        Write-Warning "The module `"$moduleName`" has no test coverage data found."
        $hasRawData = $false
    }

    if ($moduleName -ne $accountsModuleName) {
        $modulePsd1 = Join-Path -Path $debugDir -ChildPath $moduleName | Join-Path -ChildPath "$moduleName.psd1"
        Import-Module $modulePsd1 -Force
    }

    $module = Get-Module -Name $moduleName
    $moduleCommands = $module.ExportedCmdlets.Keys + $module.ExportedFunctions.Keys

    $totalCommandsCount = $moduleCommands.Count
    $overallCommandsCount += $totalCommandsCount

    $totalParameterSetsCount = 0
    $totalParametersCount = 0
    $moduleCommands | ForEach-Object {
        $cmd = Get-Command -Name $_
        $totalParameterSetsCount += $cmd.ParameterSets.Count

        $cmdParams = $cmd.Parameters
        $cmdParams.Keys | ForEach-Object {
            if ($_ -notin $psCommonParameters) {
                $totalParametersCount += $cmdParams[$_].ParameterSets.Count
            }
        }
    }

    $commandExec = [PSCustomObject]@{
        TestedCommands   = @()
        UntestedCommands = @()
    }

    if ($hasRawData) {
        (Import-Csv -Path $cvgRawCsv) |
        Select-Object `
        @{ Name = "Module"; Expression = { $simpleModuleName } }, `
        @{ Name = "CommandName"; Expression = { $_.CommandName } }, `
        @{ Name = "TotalCommands"; Expression = { $totalCommandsCount } }, `
        @{ Name = "ParameterSetName"; Expression = { $_.ParameterSetName } }, `
        @{ Name = "TotalParameterSets"; Expression = { $totalParameterSetsCount } }, `
        @{ Name = "Parameters"; Expression = { $_.Parameters } }, `
        @{ Name = "TotalParameters"; Expression = { $totalParametersCount } }, `
        @{ Name = "SourceScript"; Expression = { $_.SourceScript } }, `
        @{ Name = "LineNumber"; Expression = { $_.LineNumber } }, `
        @{ Name = "StartDateTime"; Expression = { $_.StartDateTime } }, `
        @{ Name = "EndDateTime"; Expression = { $_.EndDateTime } }, `
        @{ Name = "IsSuccess"; Expression = { $_.IsSuccess } } |
        Export-Csv -Path $cvgRawCsv -Encoding utf8 -NoTypeInformation -Force

        $rawCsv = Import-Csv -LiteralPath $cvgRawCsv | Where-Object IsSuccess -eq $true | Select-Object CommandName, ParameterSetName, Parameters -Unique

        $csvGroupByCommand = $rawCsv | Where-Object CommandName -in $moduleCommands | Sort-Object CommandName | Select-Object -ExpandProperty CommandName -Unique
        $totalTestedCommandsCount = $csvGroupByCommand.Count
        $overallTestedCommandsCount += $totalTestedCommandsCount

        $csvGroupByParameterSet = $rawCsv | Where-Object CommandName -in $moduleCommands | Sort-Object CommandName, ParameterSetName | Select-Object CommandName, ParameterSetName -Unique | Group-Object CommandName
        $totalTestedParameterSetsCount = ($csvGroupByParameterSet | Measure-Object -Property Count -Sum).Sum

        $csvGroupByParameterSet | ForEach-Object {
            $_.Group | ForEach-Object {
                $commandExec.TestedCommands += [PSCustomObject]@{
                    Command      = $_.CommandName
                    ParameterSet = $_.ParameterSetName
                }
            }
        }

        $moduleCommands | Where-Object { $_ -notin $csvGroupByCommand } | ForEach-Object {
            $commandExec.UntestedCommands += $_
        }

        $csvGroupByParameter = $rawCsv | Where-Object CommandName -in $moduleCommands | Sort-Object CommandName, ParameterSetName, Parameters | Select-Object CommandName, ParameterSetName, Parameters -Unique | Group-Object CommandName, ParameterSetName
        $totalTestedParametersCount = 0
        $csvGroupByParameter | ForEach-Object {
            $testedParams = @()
            $_.Group | ForEach-Object {
                $testedParams += $_.Parameters -split "\*\*\*\s*"
            }
            $totalTestedParametersCount += ($testedParams | Where-Object { ![string]::IsNullOrWhiteSpace($_) -and $_ -notin $psCommonParameters } | Select-Object -Unique).Count
        }

        ConvertTo-Json $commandExec -Depth 3 | Out-File -FilePath ([System.IO.Path]::Combine($cvgResultsDir, "$moduleName.json")) -Encoding utf8 -NoNewline -Force
    }
    else {
        $totalTestedCommandsCount = 0
        $totalTestedParameterSetsCount = 0
        $totalTestedParametersCount = 0
    }

    $cvgCommand = ($totalTestedCommandsCount / $totalCommandsCount).ToString("P2")
    $cvgParameterSet = ($totalTestedParameterSetsCount / $totalParameterSetsCount).ToString("P2")
    $cvgParameter = ($totalTestedParametersCount / $totalParametersCount).ToString("P2")

    $cvgReport = [PSCustomObject]@{
        Module               = $moduleName
        TotalCommands        = $totalCommandsCount
        TestedCommands       = $totalTestedCommandsCount
        CommandCoverage      = $cvgCommand
        TotalParameterSets   = $totalParameterSetsCount
        TestedParameterSets  = $totalTestedParameterSetsCount
        ParameterSetCoverage = $cvgParameterSet
        TotalParameters      = $totalParametersCount
        TestedParameters     = $totalTestedParametersCount
        ParameterCoverage    = $cvgParameter
    }
    $cvgReport | Export-Csv -Path $cvgReportCsv -Encoding utf8 -NoTypeInformation -Append -Force

    if ($CalcBaseline.IsPresent) {
        $cvgBaseline = [PSCustomObject]@{
            Module               = $moduleName
            CommandCoverage      = $cvgCommand
        }
        $cvgBaseline | Export-Csv -Path $cvgBaselineCsv -Encoding utf8 -NoTypeInformation -Append -Force
    }

    Write-Host "##[section]`"$moduleName`" total commands # : $totalCommandsCount" -ForegroundColor Green
    Write-Host "##[section]`"$moduleName`" tested commands # : $totalTestedCommandsCount" -ForegroundColor Green
    Write-Host "##[section]`"$moduleName`" test coverage % : $cvgCommand" -ForegroundColor Green

    Write-Host
}

$cvgOverall = ($overallTestedCommandsCount / $overallCommandsCount).ToString("P2")
$cvgReportOverall = [PSCustomObject]@{
    Module          = "Total"
    TotalCommands   = $overallCommandsCount
    TestedCommands  = $overallTestedCommandsCount
    CommandCoverage = $cvgOverall
}
$cvgReportOverall | Export-Csv -Path $cvgReportCsv -Encoding utf8 -NoTypeInformation -Append -Force

Write-Host "##[section]Overall commands # : $overallCommandsCount" -ForegroundColor Magenta
Write-Host "##[section]Overall tested commands # : $overallTestedCommandsCount" -ForegroundColor Magenta
Write-Host "##[section]Overall test coverage % : $cvgOverall" -ForegroundColor Magenta
