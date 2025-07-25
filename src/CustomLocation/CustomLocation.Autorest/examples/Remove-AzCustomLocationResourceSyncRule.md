### Example 1: Deletes the Resource Sync Rule with the specified Resource Sync Rule Name, Custom Location Resource Name, Resource Group, and Subscription Id.
```powershell
Remove-AzCustomLocationResourceSyncRule -CustomLocationName azps-customlocation -Name azps-resourcesyncrule -ResourceGroupName azps_test_cluster
```

Deletes the Resource Sync Rule with the specified Resource Sync Rule Name, Custom Location Resource Name, Resource Group, and Subscription Id.

### Example 2: Deletes the Resource Sync Rule with the specified Resource Sync Rule Name, Custom Location Resource Name, Resource Group, and Subscription Id.
```powershell
$obj = Get-AzCustomLocationResourceSyncRule -ResourceGroupName azps_test_cluster -CustomLocationName azps-customlocation -Name azps-resourcesyncrule
Remove-AzCustomLocationResourceSyncRule -InputObject $obj
```

Deletes the Resource Sync Rule with the specified Resource Sync Rule Name, Custom Location Resource Name, Resource Group, and Subscription Id.

### Example 3: Deletes the Resource Sync Rule with the specified Resource Sync Rule Name, Custom Location Resource Name, Resource Group, and Subscription Id.
```powershell
$obj = Get-AzCustomLocation -ResourceGroupName azps_test_cluster -Name azps-customlocation
Remove-AzCustomLocationResourceSyncRule -CustomlocationInputObject $obj -Name azps-resourcesyncrule
```

Deletes the Resource Sync Rule with the specified Resource Sync Rule Name, Custom Location Resource Name, Resource Group, and Subscription Id.