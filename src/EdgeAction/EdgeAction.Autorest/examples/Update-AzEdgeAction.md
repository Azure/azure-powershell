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

