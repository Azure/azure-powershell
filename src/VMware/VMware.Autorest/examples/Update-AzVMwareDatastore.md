### Example 1: Update a datastore in a private cloud cluster.
```powershell
Update-AzVMwareDatastore -ClusterName azps_test_cluster -Name azps_test_datastore -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```
```output
Name                Status     ProvisioningState ResourceGroupName
----                ------     ----------------- -----------------
azps_test_datastore Accessible Succeeded         azps_test_group
```

Update a datastore in a private cloud cluster.