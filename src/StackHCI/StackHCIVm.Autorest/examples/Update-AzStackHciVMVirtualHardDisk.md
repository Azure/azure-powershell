### Example 1: Update a Virtual Hard Disk.
```powershell
PS C:\> Update-AzStackHCIVmVirtualHardDisk  -Name "testVhd" -ResourceGroupName "test-rg" -Tags @{TagName = TagValue }
```

```output
Name            ResourceGroupName
----            -----------------
testVhd       test-rg
```

This command updates an exisiting virtual hard disk in the specified resource group.


