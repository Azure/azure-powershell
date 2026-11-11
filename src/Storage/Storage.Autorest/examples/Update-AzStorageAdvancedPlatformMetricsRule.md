### Example 1: Disable the metrics rule
```powershell
Update-AzStorageAdvancedPlatformMetricsRule -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -Enabled:$false
```

Disables container-level capacity metrics without deleting the rule.
