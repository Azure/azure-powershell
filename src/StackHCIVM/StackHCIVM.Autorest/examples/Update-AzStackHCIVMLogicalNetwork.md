### Example 1: Update a Logical Network.
```powershell
Update-AzStackHCIVMLogicalNetwork  -Name "testLnet" -ResourceGroupName "test-rg" -Tag  @{"tagname" = "tagvalue"}
```

```output
Name            ResourceGroupName
----            -----------------
testLnet      test-rg
```

This command updates an existing logical network in the specified resource group.