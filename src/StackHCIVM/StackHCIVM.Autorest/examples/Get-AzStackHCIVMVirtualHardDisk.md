### Example 1: Get a Virtual Hard Disk
```powershell
Get-AzStackHCIVMVirtualHardDisk -Name  "testVhd" -ResourceGroupName "test-rg"
```
```output
Name            ResourceGroupName
----            -----------------
testVhd       test-rg
```

This command gets a specific virtual hard disk in the specified resource group. 

### Example 2: List all Virtual Hard Disks in a Resource Group
```powershell
Get-AzStackHCIVMVirtualHardDisk -ResourceGroupName "test-rg"
```
```output
Name            ResourceGroupName
----            -----------------
testVhd       test-rg
```

This command lists all virtual hard disks in the specified resource group. 