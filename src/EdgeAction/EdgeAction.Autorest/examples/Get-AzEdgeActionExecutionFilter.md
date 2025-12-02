### Example 1: List all execution filters for an edge action

```powershell
Get-AzEdgeActionExecutionFilter -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction"
```

```output
Name      Location ProvisioningState
----      -------- -----------------
filter1   global   Succeeded
filter2   global   Succeeded
```

Lists all execution filters configured for the specified edge action.

### Example 2: Get a specific execution filter

```powershell
Get-AzEdgeActionExecutionFilter -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Name "filter1"
```

```output
Name    Location ProvisioningState
----    -------- -----------------
filter1 global   Succeeded
```

Gets details of the specified execution filter.

