### Example 1: Update an execution filter with tags

```powershell
Update-AzEdgeActionExecutionFilter -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -ExecutionFilter "myFilter" -Tag @{ Environment = "Production" }
```

```output
Name     Location ProvisioningState
----     -------- -----------------
myFilter global   Succeeded
```

Updates the specified execution filter with the provided tags.

### Example 2: Clear all tags with an explicit JSON body

```powershell
Update-AzEdgeActionExecutionFilter -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -ExecutionFilter "myFilter" -JsonString '{"tags":{}}'
```

Removes all tags without changing the execution filter properties. Use the JSON parameter set because the expanded serializer omits an empty `-Tag @{}` object.
