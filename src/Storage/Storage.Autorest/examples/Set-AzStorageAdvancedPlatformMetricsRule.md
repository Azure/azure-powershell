### Example 1: Replace a metrics rule with an all-containers rule
```powershell
Set-AzStorageAdvancedPlatformMetricsRule -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -Enabled -RuleConfigFilterType AllContainersFilter
```

Creates or replaces the container-level capacity metrics rule. Use Update-AzStorageAdvancedPlatformMetricsRule to change individual settings.
