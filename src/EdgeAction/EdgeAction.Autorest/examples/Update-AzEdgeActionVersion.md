### Example 1: Update an edge action version with tags

```powershell
Update-AzEdgeActionVersion -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -Tag @{ Environment = "Production"; Team = "Platform" }
```

```output
Name Location ProvisioningState
---- -------- -----------------
v1   global   Succeeded
```

Updates the specified edge action version with the provided tags.

