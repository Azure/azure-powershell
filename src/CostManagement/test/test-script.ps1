<#
New-AzCostManagementExport -Debug -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name "LucasTestExport" `
-ScheduleStatus "Active" -ScheduleRecurrence "Daily" `
-RecurrencePeriodFrom "2020-06-20T20:00:00Z" ` 
-RecurrencePeriodTo "2020-06-24T00:00:00Z" `
-Format "Csv" `
-DestinationResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-costmanagement/providers/Microsoft.Storage/storageAccounts/wyunchistorageaccount" `
-DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" `
-DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" -DatasetGranularity "Daily" `
#-ConfigurationColumn @('SubscriptionGuid', 'MeterId', 'InstanceId', 'ResourceGroup', 'PreTaxCost')
-DatasetAggregation $AggregationDict `
-DatasetGrouping @(@{type='Dimension'; name='SubscriptionName'}; @{type='Tag'; name='Environment'}) `
#-DatasetFilter $fileter 
#>

<# export all info pass
New-AzCostManagementExport -Debug -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name "ps-exportall-t" `
-ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom "2020-06-29T13:00:00Z" `
-RecurrencePeriodTo "2020-07-01T00:00:00Z" -Format "Csv" `
-DestinationResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-manual-test/providers/Microsoft.Storage/storageAccounts/lucasstorageaccount" `
-DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
-DatasetGranularity "Daily"
#>

<# custom colum pass
New-AzCostManagementExport -Debug -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name "ps-customcolum-t" `
-ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom "2020-06-29T13:00:00Z" `
-RecurrencePeriodTo "2020-07-01T00:00:00Z" -Format "Csv" `
-DestinationResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-manual-test/providers/Microsoft.Storage/storageAccounts/lucasstorageaccount" `
-DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
-DatasetGranularity "Daily" `
-ConfigurationColumn @('SubscriptionGuid', 'MeterId', 'InstanceId', 'ResourceGroup', 'PreTaxCost')
#>

<# Aggregation: The data not generate in the storage account
$Aggregation1 = @{ name = 'PreTaxCost'; function='sum'}
$Aggregation2 = @{ name = 'Cost'; function='sum'}
$AggregationDict = @{costsum=$aggregation1; cost=$aggregation2}

New-AzCostManagementExport -Debug -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name "ps-aggregation-t" `
-ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom "2020-06-29T13:00:00Z" `
-RecurrencePeriodTo "2020-07-01T00:00:00Z" -Format "Csv" `
-DestinationResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-manual-test/providers/Microsoft.Storage/storageAccounts/lucasstorageaccount" `
-DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
-DatasetGranularity "Daily" `
-DatasetAggregation $AggregationDict
#>

<#Group pass
New-AzCostManagementExport -Debug -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name "ps-group-t" `
-ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom "2020-06-29T15:00:00Z" `
-RecurrencePeriodTo "2020-07-01T00:00:00Z" -Format "Csv" `
-DestinationResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-manual-test/providers/Microsoft.Storage/storageAccounts/lucasstorageaccount" `
-DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
-DatasetGranularity "Daily" `
-DatasetGrouping @(@{type='Dimension'; name='ResourceGroup'})
 #>

<#Group Aggregation: No data generated in the storage account
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
<#
$orDimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Operator In -Value @('East US', 'West Europe') 
$queryOrDimension = New-AzCostManagementQueryFilterObject -Dimension $orDimension
$orTag = New-AzCostManagementQueryComparisonExpressionObject -Name 'Environment' -Operator In -Value @('UAT', 'Prod') 
$queryOrTag = New-AzCostManagementQueryFilterObject -Tag $orTag
$andOr = New-AzCostManagementQueryFilterObject -or @((New-AzCostManagementQueryFilterObject -Dimension $orDimension), (New-AzCostManagementQueryFilterObject -Tag $orTag))

$dimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceGroup' -Operator In -Value 'API'
$andDimension = New-AzCostManagementQueryFilterObject -Dimension $dimension
$fileter = New-AzCostManagementQueryFilterObject -And @($andOr, $andDimension) 
#>
New-AzCostManagementExport -Debug -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name "ps-filter-t01" `
-ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom "2020-07-05T00:00:00Z" `
-RecurrencePeriodTo "2020-07-30T00:00:00Z" -Format "Csv" `
-DestinationResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-manual-test/providers/Microsoft.Storage/storageAccounts/lucasstorageaccount" `
-DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
-DatasetGranularity "Daily" `
-DatasetFilter $fileter

