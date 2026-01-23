### Example 1: Create an execution filter for an edge action

```powershell
New-AzEdgeActionExecutionFilter -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -ExecutionFilter "myFilter" -Location "global" -VersionId "/subscriptions/{sub}/resourceGroups/{rg}/providers/Microsoft.Cdn/edgeActions/myEdgeAction/versions/v1"
```

```output
Name     Location ProvisioningState
----     -------- -----------------
myFilter global   Succeeded
```

Creates a new execution filter that controls when the edge action is executed.

