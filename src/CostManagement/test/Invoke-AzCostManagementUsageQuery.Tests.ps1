$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzCostManagementUsageQuery.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzCostManagementUsageQuery' {
    It 'UsageExpanded' -Skip {
        # The record file not generated, Because using Invoke-AzRest when call Invoke-AzCostManagementUsageQuery.
        # TODO: When Invoke-AzRest support record model.
        { Invoke-AzCostManagementUsageQuery -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Timeframe MonthToDate -Type Usage  -DatasetGranularity 'daily' } | Should -Not -Throw
    }
}
