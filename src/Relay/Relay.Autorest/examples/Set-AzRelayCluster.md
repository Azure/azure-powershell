### Example 1: Update a Relay dedicated cluster
```powershell
Set-AzRelayCluster -ResourceGroupName lucas-relay-rg -Name relaycluster01 -Location eastus -SkuCapacity 2
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
East US  relaycluster01 lucas-relay-rg
```

The cmdlet replaces the properties of an existing Relay dedicated cluster. `-Location` is mandatory because this cmdlet performs a full update; supply the cluster's existing location.
