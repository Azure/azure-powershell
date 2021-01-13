### Example 1:Update a tenant of the AzureActiveDirectory by name 
```powershell
PS C:\> Update-AzADB2CTenant -ResourceGroupName lucas-rg-test -Name 'klaskkdls.onmicrosoft.com' -Tag @{"key1" = 1; "key2" = 2}

Location      Name                      Type
--------      ----                      ----
United States klaskkdls.onmicrosoft.com Microsoft.AzureActiveDirectory/b2cDirectories
```

This command updates a tenant of the AzureActiveDirectory by name.

### Example 2: Update a tenant of the AzureActiveDirectory by pipeline 
```powershell
PS C:\> Get-AzADB2CTenant -ResourceGroupName lucas-rg-test -Name 'klaskkdls.onmicrosoft.com' | Update-AzADB2CTenant -Tag @{"key1"=1; "key"=2;"key3"=3}

Location      Name                      Type
--------      ----                      ----
United States klaskkdls.onmicrosoft.com Microsoft.AzureActiveDirectory/b2cDirectories
```

This command updates a tenant of the AzureActiveDirectory by pipeline.

