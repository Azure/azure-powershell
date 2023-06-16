### Example 1: Remove special resource with sepecial group
```powershell
Remove-AzQumuloFileSystem -Name qumulo01 -ResourceGroupName ps-joyer-test02
```

Remove special File System Resource with sepecial group

### Example 2: Get and remove special resource with sepecial group
```powershell
$fileSystem = Get-AzQumuloFileSystem -ResourceGroupName ps-joyer-test -Name qumulo-resource-01
Remove-AzQumuloFileSystem -InputObject $fileSystem
```

Remove special File System Resource with sepecial group