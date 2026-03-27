### Example 1: Update Edge Action tags
```powershell
$tags = @{"Environment" = "Staging"; "Owner" = "Team2"}
Update-AzCdnEdgeAction -ResourceGroupName testps-rg-da16jm -Name edgeaction001 -Tag $tags
```

```output
Location Name          Kind ResourceGroupName
-------- ----          ---- -----------------
Global   edgeaction001      testps-rg-da16jm
```

Update an Edge Action's tags under the resource group

### Example 2: Update Edge Action using JSON string
```powershell
$jsonString = '{"tags":{"Environment":"Development","Team":"DevOps"}}'
Update-AzCdnEdgeAction -ResourceGroupName testps-rg-da16jm -Name edgeaction001 -JsonString $jsonString
```

```output
Location Name          Kind ResourceGroupName
-------- ----          ---- -----------------
Global   edgeaction001      testps-rg-da16jm
```

Update an Edge Action using JSON string configuration

