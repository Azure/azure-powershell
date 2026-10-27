### Example 1: Update an edge action with tags

```powershell
Update-AzEdgeAction -ResourceGroupName "myResourceGroup" -Name "myEdgeAction" -Tag @{ Environment = "Production"; Team = "Platform" }
```

```output
Name         Location ProvisioningState SkuName  SkuTier
----         -------- ----------------- -------  -------
myEdgeAction global   Succeeded         Standard Standard
```

Updates the specified edge action with the provided tags.

### Example 2: Clear all tags with an explicit JSON body

```powershell
Update-AzEdgeAction -ResourceGroupName "myResourceGroup" -Name "myEdgeAction" -JsonString '{"tags":{}}'
```

Removes all tags from the edge action. Use the JSON parameter set for this operation: the current expanded serializer omits an empty `-Tag @{}` object, producing an empty PATCH that the service rejects.
