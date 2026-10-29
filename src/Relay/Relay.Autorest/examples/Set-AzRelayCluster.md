### Example 1: Update a Relay dedicated cluster
```powershell
Set-AzRelayCluster -ResourceGroupName lucas-relay-rg -Name relaycluster01 -SkuCapacity 2
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
East US  relaycluster01 lucas-relay-rg
```

 The cmdlet updates the capacity of the existing Relay dedicated cluster while preserving its location and other properties.
