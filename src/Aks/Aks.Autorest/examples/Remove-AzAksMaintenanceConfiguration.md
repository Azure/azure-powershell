### Example 1: Remove a maintenance configuration
```powershell
Remove-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName mycluster -ConfigName 'aks_maintenance_config'
```

### Example 2: Remove a maintenance configuration via identity 
```powershell
$MaintenanceConfig = Get-AzAksMaintenanceConfiguration -ResourceGroupName mygroup -ResourceName myCluster -ConfigName 'aks_maintenance_config'
$MaintenanceConfig | Remove-AzAksMaintenanceConfiguration
```


