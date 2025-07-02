### Example 1: Update a Storage Path.
```powershell
Update-AzStackHCIVMStoragePath  -Name "testVhd" -ResourceGroupName "test-rg" -Tag @{"tagname" = "tagvalue"}
```

```output
Name            ResourceGroupName
----            -----------------
testStoragePath       test-rg
```

This command updates an existing storage path in the specified resource group.