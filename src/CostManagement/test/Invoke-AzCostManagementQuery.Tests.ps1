$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzCostManagementQuery.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Invoke-AzCostManagementQuery' {
    It 'UsageExpanded' -skip {
        $invbokeQueryResult = Invoke-AzCostManagementQuery -Scope "/subscriptions/$($env.SubscriptionId)" -Timeframe MonthToDate -Type Usage -DatasetGranularity 'Daily'
        $invbokeQueryResult.Column.Name.Contains('UsageDate') | Should -Be $true
    }

    # It 'UsageExpanded1' -skip {
    #     #$DimensionObject = new-AzCostManagementQueryComparisonExpressionObject -name 'ResourceGroup' -Value 'API'
    #     #$FilterObject = New-AzCostManagementQueryFilterObject -Dimension $DimensionObject
    #     #Invoke-AzCostManagementQuery -ExternalCloudProviderId 'Microsoft.Compute' -ExternalCloudProviderType externalBillingAccounts -Timeframe MonthToDate -type Usage -DatasetFilter $FilterObject -DatasetGranularity Daily -debug
    # }
}
