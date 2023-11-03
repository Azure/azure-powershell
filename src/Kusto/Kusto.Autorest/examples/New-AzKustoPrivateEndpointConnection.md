## EXAMPLES

### Example 1: Create a new PrivateEndpointConnection in a cluster
```powershell
New-AzKustoPrivateEndpointConnection -ClusterName "mycluster" -ResourceGroupName "testrg" -SubscriptionId "12345678-1234-1234-1234-123456789098" -Parameter $privateEndpointConnection -Name "testprivateconnection-12345678-1234-1234-1234-123456789098"
```

```output
Name                                                       	Type
----                                                       	----
testprivateconnection-12345678-1234-1234-1234-123456789098  Microsoft.Kusto/Clusters/PrivateEndpointConnections
```

The above command creates a new PrivateEndpointConnection in the cluster "mycluster" found in the resource group "testrg".
