### Example 1: List all Edge Action Versions
```powershell
Get-AzCdnEdgeActionVersion -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001
```

```output
Name       ResourceGroupName EdgeActionName
----       ----------------- --------------
version001 testps-rg-da16jm  edgeaction001
version002 testps-rg-da16jm  edgeaction001
```

List all versions of the specified Edge Action

### Example 2: Get a specific Edge Action Version by name
```powershell
Get-AzCdnEdgeActionVersion -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Name version001
```

```output
Name       ResourceGroupName EdgeActionName
----       ----------------- --------------
version001 testps-rg-da16jm  edgeaction001
```

Get a specific Edge Action Version by name

