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

    It 'CreateExpandedByGroup' {
        $export =  New-AzCostManagementExport -Scope "subscriptions/$($env.SubscriptionId)" -Name $env.exportName05 `
        -ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom $env.fromDate `
        -RecurrencePeriodTo $env.toDate -Format "Csv" `
        -DestinationResourceId $env.storageAccountId `
        -DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
        -DatasetGranularity "Daily" `
        -DatasetGrouping @(@{type='Dimension'; name='ResourceGroup'})
        $export.ScheduleStatus | Should -Be 'Active'
    }
    It 'CreateExpandedByGroupAggregation' -skip {
        #Group Aggregation: Created successfully, No data generated in the storage account
        #TODO: The issue fix
        <#
        $Aggregation1 = @{ name = 'PreTaxCost'; function='sum'}
        $Aggregation2 = @{ name = 'Cost'; function='sum'}
        $AggregationDict = @{costsum=$aggregation1; cost=$aggregation2}

        New-AzCostManagementExport -Debug -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name "ps-groupaggregation-t" `
        -ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom "2020-06-29T13:00:00Z" `
        -RecurrencePeriodTo "2020-07-01T00:00:00Z" -Format "Csv" `
        -DestinationResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-manual-test/providers/Microsoft.Storage/storageAccounts/lucasstorageaccount" `
        -DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
        -DatasetGranularity "Daily" `
        -DatasetGrouping @(@{type='Dimension'; name='ResourceGroup'}) `
        -DatasetAggregation $AggregationDict
        #>
    }

    It 'CreateExpandedByFilter' -skip {
        #Filter: Create failed, Invalid dataset filter; on a QueryFilter one and only one of and/or/not/dimension/tag can be set. Invalid dataset
        #        filter; on a QueryFilter one and only one of and/or/not/dimension/tag can be set.
        #TODO: The issue fix.
        <#
        $orDimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Operator In -Value @('East US', 'West Europe') 
        $queryOrDimension = New-AzCostManagementQueryFilterObject -Dimension $orDimension
        $orTag = New-AzCostManagementQueryComparisonExpressionObject -Name 'Environment' -Operator In -Value @('UAT', 'Prod') 
        $queryOrTag = New-AzCostManagementQueryFilterObject -Tag $orTag
        $andOr = New-AzCostManagementQueryFilterObject -or @((New-AzCostManagementQueryFilterObject -Dimension $orDimension), (New-AzCostManagementQueryFilterObject -Tag $orTag))

        $dimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceGroup' -Operator In -Value 'API'
        $andDimension = New-AzCostManagementQueryFilterObject -Dimension $dimension
        $fileter = New-AzCostManagementQueryFilterObject -And @($andOr, $andDimension) 

        New-AzCostManagementExport -Debug -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name "ps-filter-t01" `
        -ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom "2020-06-29T13:00:00Z" `
        -RecurrencePeriodTo "2020-07-01T00:00:00Z" -Format "Csv" `
        -DestinationResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-manual-test/providers/Microsoft.Storage/storageAccounts/lucasstorageaccount" `
        -DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
        -DatasetGranularity "Daily" `
        -DatasetFilter $fileter
        #>
    }

}
