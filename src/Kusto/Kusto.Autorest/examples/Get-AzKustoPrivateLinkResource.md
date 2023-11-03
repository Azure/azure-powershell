## EXAMPLES

### Example 1: List all PrivateLinkResource in a cluster
```powershell
Get-AzKustoPrivateLinkResource -ClusterName "mycluster" -ResourceGroupName "testrg"
```

```output
Name                                                       Type
----                                                       ----
mycluster/cluster                                		   Microsoft.Kusto/Clusters/PrivateLinkResources
```

The above command returns all PrivateLinkResource in the cluster "mycluster" found in the resource group "testrg".

### Example 2: Get a specific PrivateLinkResource by name
```powershell
Get-AzKustoPrivateLinkResource -ClusterName "mycluster" -ResourceGroupName "testrg" -Name "ManagedPrivateEndpointName"
```

```output
Name                                                       Type
----                                                       ----
mycluster/cluster                                		   Microsoft.Kusto/Clusters/PrivateLinkResources
```

The above command returns the PrivateLinkResource named "mycluster/cluster" in the cluster "mycluster" found in the resource group "testrg".
