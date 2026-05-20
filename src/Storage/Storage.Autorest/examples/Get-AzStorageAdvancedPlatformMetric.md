### Example 1: Get advanced platform metrics rule for a storage account
```powershell
Get-AzStorageAdvancedPlatformMetric -AccountName mystorageaccount -ResourceGroupName myresourcegroup
```

```output
Enabled                      : False
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/weitry/providers/Microsoft.Storage/storageAccounts/mystorageaccount/advancedPlatformMetrics/ContainerLevelCapacityMetrics
LastModifiedTime             : 5/20/2026 6:46:04 AM
MetricsEmitted               : {ContainerUsedSize, ContainerBlobCount}
Name                         : DefaultAdvancedPlatformMetricsRule
ResourceGroupName            : myresourcegroup
RuleConfigFilterType         : ContainerListFilter
RuleConfigFilterValue        : {container1, container2, container3}
RuleType                     : ContainerLevelCapacityMetrics
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Storage/storageAccounts/advancedPlatformMetrics
```

This command gets the advanced platform metrics rule configuration for the storage account mystorageaccount in resource group myresourcegroup.



