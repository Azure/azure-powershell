### Example 1: List all Relay dedicated clusters in a subscription
```powershell
Get-AzRelayCluster
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
East US  relaycluster01 lucas-relay-rg
West US  relaycluster02 lucas-relay-rg2
```

The cmdlet lists every Relay dedicated cluster in the current subscription.

### Example 2: List Relay dedicated clusters in a resource group
```powershell
Get-AzRelayCluster -ResourceGroupName lucas-relay-rg
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
East US  relaycluster01 lucas-relay-rg
```

The cmdlet lists the Relay dedicated clusters in the specified resource group.

### Example 3: Get a specific Relay dedicated cluster
```powershell
Get-AzRelayCluster -ResourceGroupName lucas-relay-rg -Name relaycluster01
```

```output
Location Name           ResourceGroupName
-------- ----           -----------------
East US  relaycluster01 lucas-relay-rg
```

The cmdlet gets a single Relay dedicated cluster by name.
