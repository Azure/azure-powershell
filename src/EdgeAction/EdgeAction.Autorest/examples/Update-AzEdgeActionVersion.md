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

### Example 2: Clear all tags with an explicit JSON body

```powershell
Update-AzEdgeActionVersion -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -Version "v1" -JsonString '{"tags":{}}'
```

Removes all tags without changing the default version or deployment type. Use the JSON parameter set because the expanded serializer omits an empty `-Tag @{}` object.
