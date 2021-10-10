### Example 1: List all Kusto ManagedPrivateEndpoint in a cluster
```powershell
PS C:\> Get-AzKustoManagedPrivateEndpoint -ClusterName "mycluster" -ResourceGroupName "testrg"

Name                                                       Type
----                                                       ----
ManagedPrivateEndpointName1                                Microsoft.Kusto/Clusters/ManagedPrivateEndpoints
ManagedPrivateEndpointName2                                Microsoft.Kusto/Clusters/ManagedPrivateEndpoints
```

The above command returns all Kusto ManagedPrivateEndpoint in the cluster "mycluster" found in the resource group "testrg".

### Example 2: Get a specific Kusto ManagedPrivateEndpoint by name
```powershell
PS C:\> Get-AzKustoManagedPrivateEndpoint -ClusterName "mycluster" -ResourceGroupName "testrg" -SubscriptionId "12345678-1234-1234-1234-123456789098" -Name "ManagedPrivateEndpointName"

Name                                                       Type
----                                                       ----
ManagedPrivateEndpointName                                 Microsoft.Kusto/Clusters/ManagedPrivateEndpoints
```

The above command returns the Kusto ManagedPrivateEndpoint named "ManagedPrivateEndpointName" in the cluster "mycluster" found in the resource group "testrg".
