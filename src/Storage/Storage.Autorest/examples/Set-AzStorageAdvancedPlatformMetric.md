### Example 1: Enable advanced platform metrics for all containers
```powershell
Set-AzStorageAdvancedPlatformMetric -AccountName mystorageaccount -ResourceGroupName myresourcegroup -Enabled -RuleConfigFilterType AllContainersFilter -Enabled
```

```output
Enabled                      : True
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount/advancedPlatformMetrics/ContainerLevelCapacityMetrics
LastModifiedTime             : 5/20/2026 7:00:10 AM
MetricsEmitted               : {ContainerUsedSize, ContainerBlobCount}
Name                         : DefaultAdvancedPlatformMetricsRule
ResourceGroupName            : myresourcegroup
RuleConfigFilterType         : AllContainersFilter
RuleConfigFilterValue        :
RuleType                     : ContainerLevelCapacityMetrics
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Storage/storageAccounts/advancedPlatformMetrics
```

This command enables advanced platform metrics for all containers in the storage account mystorageaccount.

### Example 2: Enable advanced platform metrics with container prefix filter
```powershell
Set-AzStorageAdvancedPlatformMetric -AccountName mystorageaccount -ResourceGroupName myresourcegroup -RuleConfigFilterType ContainerPrefixFilter -RuleConfigFilterValue @("logs", "data") -Enabled 
```

```output
Enabled                      : True
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount/advancedPlatformMetrics/ContainerLevelCapacityMetrics
LastModifiedTime             : 5/20/2026 6:57:59 AM
MetricsEmitted               : {ContainerUsedSize, ContainerBlobCount}
Name                         : DefaultAdvancedPlatformMetricsRule
ResourceGroupName            : myresourcegroup
RuleConfigFilterType         : ContainerPrefixFilter
RuleConfigFilterValue        : {logs, data}
RuleType                     : ContainerLevelCapacityMetrics
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.Storage/storageAccounts/advancedPlatformMetrics
```

This command enables advanced platform metrics for containers with prefixes "logs" and "data" in the storage account mystorageaccount.

### Example 3: Enable advanced platform metrics with specific container list
```powershell
Set-AzStorageAdvancedPlatformMetric -AccountName mystorageaccount -ResourceGroupName myresourcegroup -RuleConfigFilterType ContainerListFilter -RuleConfigFilterValue @("container1", "container2", "container3") -Enabled 
```

```output
Enabled                      : True
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myresourcegroup/providers/Microsoft.Storage/storageAccounts/mystorageaccount/advancedPlatformMetrics/ContainerLevelCapacityMetrics
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

This command enables advanced platform metrics for specific containers (container1, container2, and container3) in the storage account mystorageaccount.

