### Example 1: List datastores in a private cloud cluster.
```powershell
Get-AzVMwareDatastore -ClusterName azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name                 Status     ProvisioningState ResourceGroupName
----                 ------     ----------------- -----------------
azps_test_datastore  Accessible Succeeded         azps_test_group
azps_test_datastore1 Accessible Succeeded         azps_test_group
```

List datastores in a private cloud cluster.

### Example 2: Get a datastore in a data store name.
```powershell
Get-AzVMwareDatastore -ClusterName azps_test_cluster -Name azps_test_datastore -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name                Status     ProvisioningState ResourceGroupName
----                ------     ----------------- -----------------
azps_test_datastore Accessible Succeeded         azps_test_group
```

Get a datastore in a data store name.