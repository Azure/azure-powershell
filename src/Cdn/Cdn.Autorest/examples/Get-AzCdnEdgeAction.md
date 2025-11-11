### Example 1: List all Edge Actions in a resource group
```powershell
Get-AzCdnEdgeAction -ResourceGroupName "testps-rg-da16jm"
```

```output
Location Name          Kind ResourceGroupName
-------- ----          ---- -----------------
Global   edgeaction001      testps-rg-da16jm
Global   edgeaction002      testps-rg-da16jm
```

List all Edge Actions under the resource group

### Example 2: Get a specific Edge Action by name
```powershell
Get-AzCdnEdgeAction -ResourceGroupName "testps-rg-da16jm" -Name "edgeaction001"
```

```output
Location Name          Kind ResourceGroupName
-------- ----          ---- -----------------
Global   edgeaction001      testps-rg-da16jm
```

Get a specific Edge Action by name under the resource group

