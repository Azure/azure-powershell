### Example 1: Scale a Relay dedicated cluster
```powershell
Update-AzRelayCluster -ResourceGroupName lucas-relay-rg -Name relaycluster01 -SkuCapacity 2
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
East US  relaycluster01 lucas-relay-rg
```

The cmdlet updates the capacity of an existing Relay dedicated cluster.

### Example 2: Update the tags on a Relay dedicated cluster
```powershell
Update-AzRelayCluster -ResourceGroupName lucas-relay-rg -Name relaycluster01 -Tag @{env='prod'; team='messaging'}
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
East US  relaycluster01 lucas-relay-rg
```

The cmdlet replaces the tags on an existing Relay dedicated cluster.
