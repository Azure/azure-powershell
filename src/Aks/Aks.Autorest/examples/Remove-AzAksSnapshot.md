### Example 1: Remove an AKS snapshot
```powershell
Remove-AzAksSnapshot -ResourceGroupName mygroup -ResourceName 'snapshot1'
```

### Example 2: Remove an AKS snapshot via identity
```powershell
$Snapshot = Get-AzAksSnapshot -ResourceGroupName mygroup -ResourceName 'snapshot1'
$Snapshot | Remove-AzAksSnapshot
```


