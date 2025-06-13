### Example 1: List all provisioned networks in a private cloud
```powershell
Get-AzVMwareProvisionedNetwork -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name     Type                                            AddressPrefix   NetworkType ResourceGroupName
----     ----                                            -------------   ----------  -----------------
vsan     Microsoft.AVS/privateClouds/provisionedNetworks 10.0.2.128/25   vsan        azps_test_group
esxvmot  Microsoft.AVS/privateClouds/provisionedNetworks 10.0.1.128/25   esxvmot     azps_test_group
mgmtvnet Microsoft.AVS/privateClouds/provisionedNetworks 10.0.3.128/26   mgmtvnet    azps_test_group
```

Lists all provisioned networks in the specified private cloud and resource group.

### Example 2:  Get a provisioned network by name
```powershell
Get-AzVMwareProvisionedNetwork -Name vsan -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name     Type                                            AddressPrefix   NetworkType ResourceGroupName
----     ----                                            -------------   ----------  -----------------
vsan     Microsoft.AVS/privateClouds/provisionedNetworks 10.0.2.128/25   vsan        azps_test_group
```

Gets a specific provisioned network by name in the specified private cloud and resource group

