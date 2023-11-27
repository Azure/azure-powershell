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
    [string]$ExcelPath,
    [Parameter()]
    [string]$TargetAzVersion
)

$BreakingChangeItems = Import-XLSX -Path $ExcelPath -RowStart 1
$TotalTable = @{}
foreach ($BreakingChangeItem in $BreakingChangeItems) {
    $ModuleName = $BreakingChangeItem.ModuleName
    if (-not $TotalTable.ContainsKey($ModuleName)) {
        $Tmp = New-Object System.Collections.ArrayList
        $TotalTable.Add($ModuleName, $Tmp)
    }
    $Null = $TotalTable[$ModuleName].Add($BreakingChangeItem)
}

$MigrationGuidePath = [System.IO.Path]::Combine($PSScriptRoot, '..', '..', 'documentation', 'migration-guides')
$MigrationGuidePath = Resolve-Path -Path $MigrationGuidePath
$MigrationGuidePath = [System.IO.Path]::Combine($MigrationGuidePath, "Az.$TargetAzVersion.0-migration-guide.md")
Set-Content -Path $MigrationGuidePath -Value "# Migration Guide for Az $TargetAzVersion.0`n"

foreach ($Module in ($TotalTable.Keys | Sort-Object)) {
    Add-Content -Path $MigrationGuidePath -Value "## $Module`n"
    foreach ($BreakingChangeItem in $TotalTable[$Module]) {
        $CmdletName = $BreakingChangeItem.CmdletName
        $Description = $BreakingChangeItem.Description
        $Before = $BreakingChangeItem.Before
        $After = $BreakingChangeItem.After
        Add-Content -Path $MigrationGuidePath -Value "### ``${CmdletName}```n${Description}`n"
        if ($Null -ne $Before) {
            if (-not $Before.StartsWith("``````")) {
                $Before = "``````powershell`n" + $Before + "`n``````"
            }
        
            if ($Null -ne $After -and -not $After.StartsWith("``````")) {
                $After = "``````powershell`n" + $After + "`n``````"
            }
            Add-Content -Path $MigrationGuidePath -Value "#### Before`n${Before}`n#### After`n${After}`n`n"
        }
    }
}
Write-Host "Migration guide is generated at: $MigrationGuidePath"
