## EXAMPLES

### Example 1: Create a new Kusto ManagedPrivateEndpoint in a cluster
```powershell
New-AzKustoManagedPrivateEndpoint -ClusterName "mycluster" -ResourceGroupName "testrg" -Name "ManagedPrivateEndpointName" -GroupId "namespace" -RequestMessage "Please approve" -PrivateLinkResourceRegion "Australia Central" -PrivateLinkResourceId "/subscriptions/12345678-1234-1234-1234-123456789098/resourceGroups/testrg/providers/Microsoft.EventHub/namespaces/testclientsns22"
```

```output
Name                                                       Type
----                                                       ----
ManagedPrivateEndpointName                                 Microsoft.Kusto/Clusters/ManagedPrivateEndpoints
```

The above command creates a new Kusto ManagedPrivateEndpoint in the cluster "mycluster" found in the resource group "testrg".
