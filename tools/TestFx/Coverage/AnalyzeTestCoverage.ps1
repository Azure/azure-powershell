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
        The test coverage will be calculated and displayed at cmdlet, parameterset and parameter levels.
#>

param (
    [Parameter()]
    [ValidateScript({ Test-Path -LiteralPath $_ -PathType Container })]
    [string] $DataLocation
)

$psCommonParameters = @("-Break", "-Confirm", "-Debug", "-DefaultProfile", "-ErrorAction", "-ErrorVariable", "-HttpPipelineAppend", "-HttpPipelinePrepend", "-InformationAction", "-InformationVariable",
    "-OutBuffer", "-OutVariable", "-PassThru", "-PipelineVariable", "-Proxy", "-ProxyCredential", "-ProxyUseDefaultCredentials", "-Verbose", "-WarningAction", "-WarningVariable", "-WhatIf")

$repoDir = $PSScriptRoot | Split-Path | Split-Path | Split-Path
$debugDir = Join-Path -Path $repoDir -ChildPath "artifacts" | Join-Path -ChildPath "Debug"

$accountsModuleName = "Az.Accounts"
$accountsModuleFullPath = Join-Path -Path $debugDir -ChildPath $accountsModuleName | Join-Path -ChildPath "$accountsModuleName.psd1"
Import-Module $accountsModuleFullPath

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
    New-Item -Path $cvgRootDir -Name "Results" -ItemType Directory -Force
}
else {
    Get-ChildItem -Path $cvgResultsDir | Remove-Item -Force
}

$cvgReportCsv = Join-Path -Path $cvgResultsDir -ChildPath "TestCoverageReport.csv"
({} | Select-Object "Module", "TotalCommands", "TestedCommands", "CommandsCoverage", "TotalParameterSets", "TestedParameterSets", "ParameterSetsCoverage", "TotalParameters", "TestedParameters", "ParametersCoverage" | ConvertTo-Csv -NoTypeInformation)[0] | Out-File -LiteralPath $cvgReportCsv -Encoding utf8 -Force

$overallCmdletsCount = 0
$overallExecutedCmdletsCount = 0

$allModules = Get-ChildItem -Path $debugDir -Filter "Az.*" -Directory -Name
foreach ($moduleName in $allModules) {
    Write-Host "Start to analyze test coverage for the module `"$moduleName`"" -ForegroundColor Cyan

    $hasRawData = $true

    $moduleCsvFullPath = Join-Path -Path $cvgRawDir -ChildPath "$moduleName.csv"
    if (!(Test-Path $moduleCsvFullPath)) {
        Write-Warning "The module '$moduleName' has no test coverage data generated."
        $hasRawData = $false
    }

    $moduleTxtReportContent = [System.Text.StringBuilder]::new()
    [void]$moduleTxtReportContent.AppendLine("Command execution report for module `"$moduleName`" :")
    [void]$moduleTxtReportContent.AppendLine()

    if ($moduleName -ne $accountsModuleName) {
        $moduleFullPath = Join-Path -Path $debugDir -ChildPath $moduleName | Join-Path -ChildPath "$moduleName.psd1"
        Import-Module $moduleFullPath -Force
    }

    $module = Get-Module -Name $moduleName
    $moduleCmdlets = $module.ExportedCmdlets.Keys + $module.ExportedFunctions.Keys

    $totalCmdletsCount = $moduleCmdlets.Count
    $overallCmdletsCount += $totalCmdletsCount

    $totalParameterSetsCount = 0
    $totalParametersCount = 0
    $moduleCmdlets | ForEach-Object {
        $cmdlet = Get-Command -Name $_
        $totalParameterSetsCount += $cmdlet.ParameterSets.Count

        $cmdletParams = $cmdlet.Parameters
        $cmdletParams.Keys | ForEach-Object {
            if ($_ -notin $psCommonParameters) {
                $totalParametersCount += $cmdletParams[$_].ParameterSets.Count
            }
        }
    }

    if ($hasRawData) {
        $rawCsv = Import-Csv -LiteralPath $moduleCsvFullPath | Select-Object CommandName, ParameterSetName, Parameters -Unique

        Write-Host "Start to calculate cmdlets." -ForegroundColor Green

        $csvGroupByCmdlet = $rawCsv | Select-Object -ExpandProperty CommandName -Unique | Sort-Object CommandName | Where-Object { $_ -in $moduleCmdlets }
        $totalExecutedCmdletsCount = $csvGroupByCmdlet.Count
        $overallExecutedCmdletsCount += $totalExecutedCmdletsCount

        Write-Host "Finished calculating cmdlets." -ForegroundColor Green

        Write-Host "Start to calculate parameter sets." -ForegroundColor Green

        $csvGroupByParameterSet = $rawCsv | Select-Object CommandName, ParameterSetName -Unique | Sort-Object CommandName, ParameterSetName | Where-Object CommandName -In $moduleCmdlets | Group-Object CommandName
        $totalExecutedParameterSetsCount = ($csvGroupByParameterSet | Measure-Object -Property Count -Sum).Sum

        [void]$moduleTxtReportContent.AppendLine("Following cmdlets were tested :")
        $csvGroupByParameterSet | ForEach-Object {
            $_.Group | ForEach-Object {
                [void]$moduleTxtReportContent.AppendLine("  -->  Cmdlet $($_.CommandName) with parameter set $($_.ParameterSetName) was tested")
            }
        }

        [void]$moduleTxtReportContent.AppendLine()

        [void]$moduleTxtReportContent.AppendLine("Following cmdlets were not tested :")
        $moduleCmdlets | Where-Object { $_ -notin $csvGroupByCmdlet } | ForEach-Object {
            [void]$moduleTxtReportContent.AppendLine("  -->  $_")
        }

        Write-Host "Finished calculating parameter sets." -ForegroundColor Green

        Write-Host "Start to calculate parameters." -ForegroundColor Green

        $csvGroupByParameter = $rawCsv | Select-Object CommandName, ParameterSetName, Parameters -Unique | Sort-Object CommandName, ParameterSetName, Parameters | Where-Object CommandName -In $moduleCmdlets | Group-Object CommandName, ParameterSetName
        $totalExecutedParametersCount = 0
        $csvGroupByParameter | ForEach-Object {
            $executedParams = @()
            $_.Group | ForEach-Object {
                $executedParams += $_.Parameters -split "\*\*\*\s*"
            }
            $totalExecutedParametersCount += ($executedParams | Where-Object { $_ -and $_ -notin $psCommonParameters } | Select-Object -Unique).Count
        }

        Write-Host "Finished calculating parameters." -ForegroundColor Green

        $moduleTxtReportContent.ToString() | Out-File -LiteralPath ([System.IO.Path]::Combine($cvgResultsDir, "$moduleName.txt")) -NoNewline

    }
    else {
        $totalExecutedCmdletsCount = 0
        $totalExecutedParameterSetsCount = 0
        $totalExecutedParametersCount = 0
    }

    $cvgCmdlets = ($totalExecutedCmdletsCount / $totalCmdletsCount).ToString("P2")
    $cvgParameterSets = ($totalExecutedParameterSetsCount / $totalParameterSetsCount).ToString("P2")
    $cvgParameters = ($totalExecutedParametersCount / $totalParametersCount).ToString("P2")

    $moduleCsvReport = [PSCustomObject]@{
        Module                = $moduleName
        TotalCommands         = $totalCmdletsCount
        TestedCommands        = $totalExecutedCmdletsCount
        CommandsCoverage      = $cvgCmdlets
        TotalParameterSets    = $totalParameterSetsCount
        TestedParameterSets   = $totalExecutedParameterSetsCount
        ParameterSetsCoverage = $cvgParameterSets
        TotalParameters       = $totalParametersCount
        TestedParameters      = $totalParameterSetsCount
        ParametersCoverage    = $cvgParameters
    }
    $moduleCsvReport | Export-Csv -Path $cvgReportCsv -Encoding utf8 -NoTypeInformation -Append -Force

    Write-Host "Successfully analyzed module `"$moduleName`"." -ForegroundColor Cyan
    Write-Host
}

Write-Host "Total tested cmdlets count: $overallExecutedCmdletsCount" -ForegroundColor Magenta
Write-Host "Total cmdlets count: $overallCmdletsCount" -ForegroundColor Magenta

$cvgOverall = ($overallExecutedCmdletsCount / $overallCmdletsCount).ToString("P2")

$overallCsvReport = [PSCustomObject]@{
    Module           = "Total"
    TotalCommands    = $overallCmdletsCount
    TestedCommands   = $overallExecutedCmdletsCount
    CommandsCoverage = $cvgOverall
}
$overallCsvReport | Export-Csv -Path $cvgReportCsv -Encoding utf8 -NoTypeInformation -Append -Force
