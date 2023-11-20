### Example 1: Get a Storage Path
```powershell
Get-AzStackHCIVMStoragePath -Name  "testStoragePath" -ResourceGroupName "test-rg"
```
```output
Name            ResourceGroupName
----            -----------------
testStoragePath       test-rg
```

This command gets a specific storage path in the specified resource group. 

### Example 2: List all Storage Paths in a Resource Group
```powershell
Get-AzStackHCIVMStoragePath  -ResourceGroupName "test-rg"
```
```output
Name            ResourceGroupName
----            -----------------
testStoragePath       test-rg
```

This command lists all storage paths in the specified resource group. 