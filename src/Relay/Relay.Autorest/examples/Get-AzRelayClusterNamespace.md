### Example 1: List the namespaces assigned to a Relay dedicated cluster
```powershell
Get-AzRelayClusterNamespace -ResourceGroupName lucas-relay-rg -ClusterName relaycluster01
```

```output
Id
--
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace-pwsh01
/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/lucas-relay-rg/providers/Microsoft.Relay/namespaces/namespace-pwsh02
```

The cmdlet lists the Relay namespaces currently assigned to the specified dedicated cluster.
