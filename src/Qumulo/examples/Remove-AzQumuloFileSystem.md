### Example 1: Remove specific resource with specified resource group
```powershell
Remove-AzQumuloFileSystem -Name qumulo01 -ResourceGroupName ps-joyer-test02
```

Remove specific resource with specified resource group

### Example 2: Get and remove specific resource with specified resource group by pipeline
```powershell
Get-AzQumuloFileSystem -ResourceGroupName ps-joyer-test -Name qumulo-resource-01 | Remove-AzQumuloFileSystem
```

Remove specific file system resource with specified resource group by pipeline