# ----------------------------------------------------------------------------------
#
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

#Requires -Modules PSExcel
[CmdletBinding()]
Param(
    [Parameter()]
    [string]$ExcelPath
)
$ExcelPath = Resolve-Path -Path $ExcelPath
If (Test-Path $ExcelPath) {
    Remove-Item $ExcelPath
}
$Path = [System.IO.Path]::Combine($PSScriptRoot, '..', '..')
Set-Location -Path $Path
Get-ChildItem -Path .\tools\StaticAnalysis\Exceptions\ -Filter BreakingChangeIssues.csv -Recurse
dotnet msbuild /t:Clean
dotnet msbuild /t:Build
dotnet msbuild /t:StaticAnalysis
$BreakingChangeItems = Import-Csv .\artifacts\StaticAnalysisResults\BreakingChangeIssues.csv
$TotalTable = @{}
foreach ($BreakingChangeItem in $BreakingChangeItems) {
    $ModuleName = 'Az' + $BreakingChangeItem.AssemblyFileName.Replace("Microsoft.Azure.PowerShell.Cmdlets", "").Replace('.dll', '')
    $CmdletName = $BreakingChangeItem.Target
    $Description = $BreakingChangeItem.Description
    if (-not $TotalTable.ContainsKey($ModuleName)) {
        $TotalTable.Add($ModuleName, @{})
    }
    if (-not $TotalTable[$ModuleName].ContainsKey($CmdletName)) {
        $TotalTable[$ModuleName].Add($CmdletName, "")
    }
    $TotalTable[$ModuleName][$CmdletName] = $TotalTable[$ModuleName][$CmdletName] + "$Description`n"
}

$Data = New-Object System.Collections.ArrayList
foreach ($ModuleName in $TotalTable.Keys) {
    foreach ($CmdletName in $TotalTable[$ModuleName].Keys) {
        $Tmp = New-Object -TypeName PSObject -Property @{
            ModuleName = $ModuleName
            CmdletName = $CmdletName
            Description = $TotalTable[$ModuleName][$CmdletName]
            Before = $Null
            After = $Null
            TeamMember = $Null
            PR = $Null
        } | Select ModuleName, CmdletName, Description, Before, After, TeamMember, PR
        $Null = $Data.Add($Tmp)
    }
}
$Data | Export-XLSX -Path $ExcelPath
Write-Host "Excel is generated at $ExcelPath. Please goto edit it."