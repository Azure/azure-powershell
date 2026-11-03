### Example 1: Create a Relay dedicated cluster
```powershell
New-AzRelayCluster -ResourceGroupName lucas-relay-rg -Name relaycluster01 -Location eastus -SkuCapacity 1
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
East US  relaycluster01 lucas-relay-rg
```

The cmdlet creates a new Relay dedicated cluster in the specified resource group and location.

### Example 2: Create a zone redundant Relay dedicated cluster with tags
```powershell
New-AzRelayCluster -ResourceGroupName lucas-relay-rg -Name relaycluster02 -Location eastus -SkuCapacity 2 -ZoneRedundant -Tag @{env='prod'}
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
East US  relaycluster02 lucas-relay-rg
```

The cmdlet creates a zone redundant Relay dedicated cluster with a capacity of 2 and a tag applied.
