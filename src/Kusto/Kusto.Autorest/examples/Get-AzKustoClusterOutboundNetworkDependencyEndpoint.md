## EXAMPLES

### Example 1: List all Kusto ManagedPrivateEndpoint in a cluster
```powershell
Get-AzKustoClusterOutboundNetworkDependencyEndpoint -ClusterName "mycluster" -ResourceGroupName "testrg"
```

```output
Name                                     Type                                                          Etag
----                                     ----                                                          ----
mycluster/AzureActiveDirectory           Microsoft.Kusto/Clusters/OutboundNetworkDependenciesEndpoints
mycluster/AzureMonitor                   Microsoft.Kusto/Clusters/OutboundNetworkDependenciesEndpoints
mycluster/CertificateAuthority           Microsoft.Kusto/Clusters/OutboundNetworkDependenciesEndpoints
mycluster/AzureStorage                   Microsoft.Kusto/Clusters/OutboundNetworkDependenciesEndpoints
```

The above command returns all Kusto OutboundNetworkDependenciesEndpoints in the cluster "mycluster" found in the resource group "testrg".