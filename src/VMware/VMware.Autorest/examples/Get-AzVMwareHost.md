### Example 1: List all hosts in a cluster
```powershell
Get-AzVMwareHost -ClusterName azps_test_cluster -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name                                                       Type                                       SkuName ResourceGroupName Kind          Maintenance
----                                                       ----                                       ------- ----------------- ------------- -----------
esx03-r52.1111111111111111111.westcentralus.prod.azure.com Microsoft.AVS/privateClouds/clusters/hosts av64    azps_test_group    General
esx03-r60.1111111111111111111.westcentralus.prod.azure.com Microsoft.AVS/privateClouds/clusters/hosts av64    azps_test_group    General      Replacement
esx03-r65.1111111111111111111.westcentralus.prod.azure.com Microsoft.AVS/privateClouds/clusters/hosts         azps_test_group    Specialized              
```

Lists all hosts in the specified cluster within the private cloud and resource group.

### Example 2: Get a host by ID in a cluster
```powershell
Get-AzVMwareHost -ClusterName azps_test_cluster -Id esx03-r52.1111111111111111111.westcentralus.prod.azure.com -PrivateCloudName azps_test_cloud -ResourceGroupName azps_test_group
```

```output
Name                                                       Type                                       ResourceGroupName SkuName Kind
----                                                       ----                                       ----------------- ------- ----
esx03-r52.1111111111111111111.westcentralus.prod.azure.com Microsoft.AVS/privateClouds/clusters/hosts azps_test_group   av64    General
```

Gets a specific host by its ID in the specified cluster, private cloud, and resource group.
