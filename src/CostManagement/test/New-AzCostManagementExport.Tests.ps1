$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'New-AzCostManagementExport.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'New-AzCostManagementExport' {
    It 'CreateExpandedBySubscription' {
        # Create export cost management by subscription
        $export = New-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName02 `
        -ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom $env.fromDate `
        -RecurrencePeriodTo $env.toDate -Format "Csv" `
        -DestinationResourceId $env.storageAccountId `
        -DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
        -DatasetGranularity "Daily"

        $export.ScheduleStatus | Should -Be 'Active'
    }
    It 'CreateExpandedByResourceGroup' {
        # Create export cost management by resource group
        $export =  New-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)" -Name $env.exportName03 `
        -ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom $env.fromDate `
        -RecurrencePeriodTo $env.toDate -Format "Csv" `
        -DestinationResourceId $env.storageAccountId `
        -DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
        -DatasetGranularity "Daily"

        $export.ScheduleStatus | Should -Be 'Active'
    }
    It 'CreateExpandedByColumn' {
        $export =  New-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName04 `
        -ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom $env.fromDate `
        -RecurrencePeriodTo $env.toDate -Format "Csv" `
        -DestinationResourceId $env.storageAccountId `
        -DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
        -DatasetGranularity "Daily" `
        -ConfigurationColumn @('SubscriptionGuid', 'MeterId', 'InstanceId', 'ResourceGroup', 'PreTaxCost')

        $export.ScheduleStatus | Should -Be 'Active'
    }
}
