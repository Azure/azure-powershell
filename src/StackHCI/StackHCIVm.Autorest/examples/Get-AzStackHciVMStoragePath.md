### Example 1: Get a Storage Path
```powershell
PS C:\> Get-AzStackHCIVmStoragePath -Name  "testStoragePath" -ResourceGroupName "test-rg"
```
```output
Name            ResourceGroupName
----            -----------------
testStoragePath       test-rg
```

This command gets a specific storage path in the specified resource group. 

### Example 2: List all Storage Paths in a Resource Group
```powershell
PS C:\> Get-AzStackHCIVmStoragePath  -ResourceGroupName "test-rg"
```
```output
Name            ResourceGroupName
----            -----------------
testStoragePath       test-rg
```

This command lists all storage paths in the specified resource group. 



