$QueryOrDimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceLocation' -Operator In -Value @('East US', 'West Europe')
$QueryOrTag = New-AzCostManagementQueryComparisonExpressionObject -Name 'Environment' -Operator In -Value @('UAT', 'Prod')
$QueryFilterOr = New-AzCostManagementQueryFilterObject -or @((New-AzCostManagementQueryFilterObject -Dimension $QueryOrDimension), (New-AzCostManagementQueryFilterObject -Tag $QueryOrTag))
$QueryAndDimension = New-AzCostManagementQueryComparisonExpressionObject -Name 'ResourceGroup' -Operator In -Value 'API'
$a = New-AzCostManagementQueryFilterObject -Dimension $QueryAndDimension
$tag = New-AzCostManagementQueryFilterObject -Tag $QueryAndDimension
$QueryFileterAnd = New-AzCostManagementQueryFilterObject -And @($QueryFilterOr, $a) 

$Aggregation1 = @{ name = 'PreTaxCost'; function='sum'}
$Aggregation2 = @{ name = 'Cost'; function='sum'}
$AggregationDict = @{costsum=$aggregation1; cost=$aggregation2}

New-AzCostManagementExport -Debug -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Name "TestExportDatasetAggregationInfo" `
    -ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom "2020-11-03T20:00:00Z" `
    -RecurrencePeriodTo "2020-11-10T00:00:00Z" -Format "Csv" `
    -DestinationResourceId "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-costmanagement/providers/Microsoft.Storage/storageAccounts/wyunchistorageaccount" `
    -DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" `
    -DatasetGranularity "Daily" -ETag "test"
# Invoke-AzCostManagementUsageQuery -Type AmortizedCost -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f" -Timeframe 'MonthToDate' -DatasetGranularity 'Daily'
    # -DatasetFilter $QueryFilterOr -DatasetGranularity 'Daily'