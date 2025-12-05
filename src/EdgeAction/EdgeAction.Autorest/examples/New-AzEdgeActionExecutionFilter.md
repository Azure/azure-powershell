### Example 1: Create an execution filter for an edge action

```powershell
New-AzEdgeActionExecutionFilter -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Name "myFilter" -Location "global" -Order 1
```

```output
Name     Location ProvisioningState Order
----     -------- ----------------- -----
myFilter global   Succeeded         1
```

Creates a new execution filter that controls when the edge action is executed.

