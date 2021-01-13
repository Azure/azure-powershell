### Example 1: Remove a tenant of the AzureActiveDirectory by name 
```powershell
PS C:\> Remove-AzADB2CTenant -ResourceGroupName lucas-rg-test -Name 'klaskkdls.onmicrosoft.com'

```

This command removes a tenant of the AzureActiveDirectory by name.

### Example 2: Remove a tenant of the AzureActiveDirectory by pipeline 
```powershell
PS C:\> Get-AzADB2CTenant -ResourceGroupName lucas-rg-test -Name 'asdsdsadsad.onmicrosoft.com' | Remove-AzADB2CTenant

```

This command removes a tenant of the AzureActiveDirectory by pipeline. 

