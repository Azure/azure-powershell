### Example 1: Update a Storage Path.
```powershell
Update-AzStackHCIVmStoragePath  -Name "testVhd" -ResourceGroupName "test-rg" -Tags @{TagName = TagValue }
```

```output
Name            ResourceGroupName
----            -----------------
testStoragePath       test-rg
```

This command updates an exisiting storage path in the specified resource group.

