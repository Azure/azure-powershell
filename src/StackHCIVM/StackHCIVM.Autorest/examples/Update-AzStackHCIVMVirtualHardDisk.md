### Example 1: Update a Virtual Hard Disk.
```powershell
Update-AzStackHCIVMVirtualHardDisk  -Name "testVhd" -ResourceGroupName "test-rg" -Tag @{"tagname" = "tagvalue"}
```

```output
Name            ResourceGroupName
----            -----------------
testVhd       test-rg
```

This command updates an exisiting virtual hard disk in the specified resource group.