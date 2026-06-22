### Example 1: Update EdgeAction tags
```powershell
Update-AzCdnEdgeAction -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Tag @{Environment="Staging"}
```

Updates tags on the specified EdgeAction resource.
