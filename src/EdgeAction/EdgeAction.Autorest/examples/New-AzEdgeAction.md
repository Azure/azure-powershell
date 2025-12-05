### Example 1: Create a new edge action

```powershell
New-AzEdgeAction -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -SkuName "Standard" -SkuTier "Standard" -Location "global"
```

Creates a new edge action with Standard SKU in the global location.

### Example 2: Create an edge action with tags

```powershell
New-AzEdgeAction -ResourceGroupName "myResourceGroup" -EdgeActionName "myEdgeAction" -SkuName "Standard" -SkuTier "Standard" -Location "global" -Tag @{Environment="Production"; Team="EdgeTeam"}
```

Creates a new edge action with custom tags for organization and tracking.

