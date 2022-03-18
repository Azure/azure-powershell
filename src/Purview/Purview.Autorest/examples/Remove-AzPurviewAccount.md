### Example 1: Delete a purview account

```powershell
Remove-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg
```

Delete a purview account named 'test-pa'

### Example 2: Delete a purview account by InputObject
```powershell
$get = Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg
Remove-AzPurviewAccount -InputObject $get
```

Delete a purview account named 'test-pa' by InputObject
