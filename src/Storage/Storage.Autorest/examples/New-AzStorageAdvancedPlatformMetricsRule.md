### Example 1: Enable capacity metrics for selected containers
```powershell
New-AzStorageAdvancedPlatformMetricsRule -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -Enabled -RuleConfigFilterType ContainerListFilter -RuleConfigFilterValue "documents","images"
```

Creates the container-level capacity metrics rule for the specified containers.
