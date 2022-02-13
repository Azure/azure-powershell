### Example 1: Delete a purview account

```powershell
PS C:\> Remove-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg

```

Delete a purview account named 'test-pa'

### Example 2: Delete a purview account by InputObject
```powershell
PS C:\> $get = Get-AzPurviewAccount -Name test-pa -ResourceGroupName test-rg
PS C:\> Remove-AzPurviewAccount -InputObject $get

```

Delete a purview account named 'test-pa' by InputObject
