### Example 1: Create a new Edge Action with Standard SKU
```powershell
New-AzCdnEdgeAction -ResourceGroupName "testps-rg-da16jm" -Name "edgeaction001" -Location "Global" -SkuName "Standard" -SkuTier "Standard"
```

```output
Location Name          Kind ResourceGroupName
-------- ----          ---- -----------------
Global   edgeaction001      testps-rg-da16jm
```

Create a new Edge Action with Standard Azure Front Door SKU under the resource group
