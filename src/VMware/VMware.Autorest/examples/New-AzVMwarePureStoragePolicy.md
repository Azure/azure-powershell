### Example 1: Create a new Pure Storage policy in a private cloud
```powershell
New-AzVMwarePureStoragePolicy -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -StoragePolicyName storagePolicy1 -StoragePolicyDefinition storagePolicyDefinition1 -StoragePoolId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/group1/providers/PureStorage.Block/storagePools/storagePool1"
```

```output
Name             Type                                           ResourceGroupName ProvisioningState StoragePolicyDefinition
----             ----                                           ----------------- ----------------- ----------------------
storagePolicy1   Microsoft.AVS/privateClouds/pureStoragePolicies azps_test_group   Succeeded         storagePolicyDefinition1
```

Creates a new Pure Storage policy in the specified private cloud and resource group.
