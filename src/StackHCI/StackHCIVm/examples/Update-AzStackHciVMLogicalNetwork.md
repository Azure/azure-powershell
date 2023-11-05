### Example 1: Update a Logical Network.
```powershell
Update-AzStackHCIVmVLogicalNetwork  -Name "testLnet" -ResourceGroupName "test-rg" -Tags @{TagName = TagValue }
```

```output
Name            ResourceGroupName
----            -----------------
testLnet      test-rg
```

This command updates an exisiting logical network in the specified resource group.

