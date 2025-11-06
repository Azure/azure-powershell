### Example 1: List all Pure Storage policies in a private cloud
```powershell
Get-AzVMwarePureStoragePolicy -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name             Type                                           ResourceGroupName ProvisioningState StoragePolicyDefinition
----             ----                                           ----------------- ----------------- ----------------------
azps_test_policy Microsoft.AVS/privateClouds/pureStoragePolicies azps_test_group   Succeeded         azps_test_policy_definition
```

Lists all Pure Storage policies in the specified private cloud and resource group.

### Example 2: Get a Pure Storage policy by name
```powershell
Get-AzVMwarePureStoragePolicy -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group -StoragePolicyName azps_test_policy
```

```output
Name             Type                                           ResourceGroupName ProvisioningState StoragePolicyDefinition
----             ----                                           ----------------- ----------------- ----------------------
azps_test_policy Microsoft.AVS/privateClouds/pureStoragePolicies azps_test_group   Succeeded         azps_test_policy_definition
```

Gets a specific Pure Storage policy by name in the specified private cloud and resource group.

