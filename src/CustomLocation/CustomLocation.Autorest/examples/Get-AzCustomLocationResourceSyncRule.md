### Example 1: List Resource Sync Rule by Custom Location name.
```powershell
Get-AzCustomLocationResourceSyncRule -ResourceGroupName azps_test_cluster -CustomLocationName azps-customlocation
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-resourcesyncrule azps_test_cluster
```

List Resource Sync Rule by Custom Location name.

### Example 2: Get the detail of the resourceSyncRule with a specified resource group, subscription id Custom Location resource name and Resource Sync Rule name.
```powershell
Get-AzCustomLocationResourceSyncRule -ResourceGroupName azps_test_cluster -CustomLocationName azps-customlocation -Name azps-resourcesyncrule
```

```output
Location Name                  ResourceGroupName
-------- ----                  -----------------
eastus   azps-resourcesyncrule azps_test_cluster
```

Get the detail of the resourceSyncRule with a specified resource group, subscription id Custom Location resource name and Resource Sync Rule name.