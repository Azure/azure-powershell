### Example 1: Update a Pure Storage policy in a private cloud
```powershell
Update-AzVMwarePureStoragePolicy -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -StoragePolicyName azps_test_policy
```

```output
Name             Type                                           ResourceGroupName ProvisioningState StoragePolicyDefinition
----             ----                                           ----------------- ----------------- ----------------------
azps_test_policy Microsoft.AVS/privateClouds/pureStoragePolicies azps_test_group   Succeeded         azps_test_policy_definition
```

Updates the Pure Storage policy in the specified private cloud and resource group. 