### Example 1: List all Kusto PrivateEndpointConnection in a cluster by name
```powershell
Get-AzKustoPrivateEndpointConnection -ClusterName "mycluster" -ResourceGroupName "testrg" -SubscriptionId "12345678-1234-1234-1234-123456789098"
```

```output
Name                                                       Type
----                                                       ----
privateEndpointConnectionName1                             Microsoft.Kusto/Clusters/PrivateEndpointConnections
privateEndpointConnectionName2                             Microsoft.Kusto/Clusters/PrivateEndpointConnections
```

The above command returns all Kusto PrivateEndpointConnection in the cluster "mycluster" found in the resource group "testrg".

### Example 2: Get a specific Kusto PrivateEndpointConnection by name
```powershell
Get-AzKustoPrivateEndpointConnection -ClusterName "mycluster" -ResourceGroupName "testrg" -SubscriptionId "12345678-1234-1234-1234-123456789098" -Name "privateEndpointConnectionName"
```

```output
Name                                                       Type
----                                                       ----
privateEndpointConnectionName                              Microsoft.Kusto/Clusters/PrivateEndpointConnections
```

The above command returns the Kusto PrivateEndpointConnection named "privateEndpointConnectionName" in the cluster "mycluster" found in the resource group "testrg".
