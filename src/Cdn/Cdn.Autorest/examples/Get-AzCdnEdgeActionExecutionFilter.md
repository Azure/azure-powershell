### Example 1: List all Edge Action Execution Filters
```powershell
Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001
```

```output
Name      ResourceGroupName EdgeActionName
----      ----------------- --------------
filter001 testps-rg-da16jm  edgeaction001
filter002 testps-rg-da16jm  edgeaction001
```

List all Execution Filters of the specified Edge Action

### Example 2: Get a specific Edge Action Execution Filter by name
```powershell
Get-AzCdnEdgeActionExecutionFilter -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Name filter001
```

```output
Name      ResourceGroupName EdgeActionName
----      ----------------- --------------
filter001 testps-rg-da16jm  edgeaction001
```

Get a specific Edge Action Execution Filter by name

