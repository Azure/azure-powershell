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
    It 'UsageExpanded' {
        #Import-Module -Name D:\azure-service\_AzurePowershellTest\azure-powershell\src\CostManagement\generated\modules\Az.Accounts\1.9.0 -Verbose
        { Invoke-AzCostManagementUsageQuery -Scope "subscriptions/$($env.SubscriptionId)" -Timeframe MonthToDate -Type Usage  -DatasetGranularity 'daily' } | Should -Not -Throw
    }
}
