### Example 1: Update an execution filter with tags

```powershell
Update-AzEdgeActionExecutionFilter -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Name "myFilter" -Tag @{ Environment = "Production" }
```

```output
Name     Location ProvisioningState
----     -------- -----------------
myFilter global   Succeeded
```

Updates the specified execution filter with the provided tags.

