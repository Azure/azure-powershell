### Example 1: List the SKUs supported by a Relay dedicated cluster
```powershell
Get-AzRelayClusterSku -ResourceGroupName lucas-relay-rg -ClusterName relaycluster01
```

```output
ResourceType
------------
Microsoft.Relay/clusters
```

The cmdlet lists the SKUs available to the specified Relay dedicated cluster, including the capacity range each SKU supports.
