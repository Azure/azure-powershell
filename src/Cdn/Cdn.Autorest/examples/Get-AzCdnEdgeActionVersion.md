### Example 1: List EdgeAction versions
```powershell
Get-AzCdnEdgeActionVersion -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001
```

Lists versions under the specified EdgeAction resource.

### Example 2: Get an EdgeAction version
```powershell
Get-AzCdnEdgeActionVersion -ResourceGroupName testps-rg-da16jm -EdgeActionName edgeaction001 -Version v1
```

Gets the specified EdgeAction version.
