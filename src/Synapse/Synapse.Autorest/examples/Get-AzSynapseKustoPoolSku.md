### Example 1: Lists eligible SKUs
```powershell
Get-AzSynapseKustoPoolSku
```

```output
Location             Name              ResourceType          Size
--------             ----              ------------          ----
{australiacentral}   Compute optimized workspaces/kustoPools Extra small
{australiacentral2}  Compute optimized workspaces/kustoPools Extra small
{australiaeast}      Compute optimized workspaces/kustoPools Extra small
{australiasoutheast} Compute optimized workspaces/kustoPools Extra small
{brazilsouth}        Compute optimized workspaces/kustoPools Extra small
...
```

The above command lists eligible SKUs.

### Example 2: Lists eligible SKUs for specific kusto pool
```powershell
Get-AzSynapseKustoPoolSku -ResourceGroupName testrg -WorkspaceName testws -KustoPoolName testnewkustopool
```

```output
ResourceType
------------
Microsoft.Synapse/workspaces/kustoPools
Microsoft.Synapse/workspaces/kustoPools
Microsoft.Synapse/workspaces/kustoPools
Microsoft.Synapse/workspaces/kustoPools
Microsoft.Synapse/workspaces/kustoPools
Microsoft.Synapse/workspaces/kustoPools
```

The above command lists eligible SKUs for specific kusto pool.
