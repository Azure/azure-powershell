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

$MigrationGuidePath = [System.IO.Path]::Combine($PSScriptRoot, '..', '..', 'documentation', 'migration-guides', "Az.$TargetAzVersion.0-migration-guide.md")
$MigrationGuidePath = Resolve-Path -Path $MigrationGuidePath
Set-Content -Path $MigrationGuidePath -Value "# Migration Guide for Az $TargetAzVersion.0`n"

foreach ($Module in $TotalTable.Keys) {
    Add-Content -Path $MigrationGuidePath -Value "## $Module`n"
    foreach ($BreakingChangeItem in $TotalTable[$Module]) {
        $CmdletName = $BreakingChangeItem.CmdletName
        $Description = $BreakingChangeItem.Description
        $Before = $BreakingChangeItem.Before
        $After = $BreakingChangeItem.After
        Add-Content -Path $MigrationGuidePath -Value "### ``${CmdletName}```n${Description}`n"
        if ($Null -ne $Before) {
            Add-Content -Path $MigrationGuidePath -Value "#### Before`n${Before}`n#### After`n${After}`n`n"
        }
    }
}
Write-Host "Migration guide is generated at: $MigrationGuidePath"