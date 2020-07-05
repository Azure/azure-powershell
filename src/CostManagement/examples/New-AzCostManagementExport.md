### Example 1: Create a cost management export for a subscription
```powershell
PS C:\> $storageAccount = Get-AzStorageAccount -ResourceGroupName "RG01" -Name "mystorageaccount"
PS C:\> New-AzCostManagementExport -Scope "subscriptions/9e223dbe-3388-4e19-88eb-0975f02ac87f" -Name costexport-test -ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom (Get-Date).ToString() -RecurrencePeriodTo (Get-Date).AddDays(20).ToString() -Format "Csv" -DestinationResourceId $storageAccount.Id -DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" -DatasetGranularity "Daily"

Name       Type
----       ----
costexport-test Microsoft.CostManagement/exports
```

This command creates a cost management export for the resource group for a subscription.

### Example 2: Create a cost management export with custom column for the resource group
```powershell
PS C:\> $storageAccount = Get-AzStorageAccount -ResourceGroupName "RG01" -Name "mystorageaccount"
PS C:\> New-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps-rg-t" -Name "ps-customcolum-t" -ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom "2020-06-29T13:00:00Z" -RecurrencePeriodTo "2020-07-01T00:00:00Z" -Format "Csv" -DestinationResourceId $storageAccount.Id -DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" -DatasetGranularity "Daily" -ConfigurationColumn @('SubscriptionGuid', 'MeterId', 'InstanceId', 'ResourceGroup', 'PreTaxCost')

Name       Type
----       ----
ps-customcolum-t Microsoft.CostManagement/exports
```

This command creates a cost management export with custom column for the resource group.

### Example 3: Create a cost management export with custom column for the resource group
```powershell
PS C:\> $storageAccount = Get-AzStorageAccount -ResourceGroupName "RG01" -Name "mystorageaccount"
PS C:\> New-AzCostManagementExport -Scope "subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/azps-rg-t" -Name "ps-customcolum-t" -ScheduleStatus "Active" -ScheduleRecurrence "Daily" -RecurrencePeriodFrom "2020-06-29T13:00:00Z" -RecurrencePeriodTo "2020-07-01T00:00:00Z" -Format "Csv" -DestinationResourceId $storageAccount.Id -DestinationContainer "exports" -DestinationRootFolderPath "ad-hoc" -DefinitionType "Usage" -DefinitionTimeframe "MonthToDate" -DatasetGranularity "Daily" -ConfigurationColumn @('SubscriptionGuid', 'MeterId', 'InstanceId', 'ResourceGroup', 'PreTaxCost')

Name       Type
----       ----
ps-customcolum-t Microsoft.CostManagement/exports
```

This command creates a cost management export with custom column for the resource group.


