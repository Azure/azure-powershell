### Example 1: Update a datastore in a private cloud cluster.
```powershell
Update-AzVMwareDatastore -ClusterName azps_test_cluster -Name azps_test_datastore -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -NetAppVolumeId "/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/azps_test_group/providers/Microsoft.NetApp/netAppAccounts/NetAppAccount1/capacityPools/CapacityPool1/volumes/NFSVol1"
```
```output
Name                Status     ProvisioningState ResourceGroupName
----                ------     ----------------- -----------------
azps_test_datastore Accessible Succeeded         azps_test_group
```

Update a datastore in a private cloud cluster.