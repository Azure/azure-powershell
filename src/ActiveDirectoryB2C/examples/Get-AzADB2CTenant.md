### Example 1: Get all tenants of the AzureActiveDirectory under a subscription
```powershell
PS C:\> Get-AzADB2CTenant

Location      Name                            Type
--------      ----                            ----
United States klaskkdls.onmicrosoft.com       Microsoft.AzureActiveDirectory/b2cDirectories
United States asdsdsadsad.onmicrosoft.com     Microsoft.AzureActiveDirectory/b2cDirectories
United States yishiTestTenant.onmicrosoft.com Microsoft.AzureActiveDirectory/b2cDirectories
```

This command gets all tenants of the AzureActiveDirectory under a subscription.

### Example 2: Get all tenants of the AzureActiveDirectory under a resource group
```powershell
PS C:\> Get-AzADB2CTenant -ResourceGroupName azure-rg-test

Location      Name                        Type
--------      ----                        ----
United States klaskkdls.onmicrosoft.com   Microsoft.AzureActiveDirectory/b2cDirectories
United States asdsdsadsad.onmicrosoft.com Microsoft.AzureActiveDirectory/b2cDirectories
```

This command gets all tenants of the AzureActiveDirectory under a resource group.

### Example 3: Get a tenant of the AzureActiveDirectory by name
```powershell
PS C:\> Get-AzADB2CTenant -ResourceGroupName azure-rg-test -Name klaskkdls.onmicrosoft.com

Location      Name                        Type
--------      ----                        ----
United States klaskkdls.onmicrosoft.com   Microsoft.AzureActiveDirectory/b2cDirectories
```

This command gets a tenant of the AzureActiveDirectory by name.


### Example 3: Get a tenant of the AzureActiveDirectory by pipeline
```powershell
PS C:\>New-AzADB2CTenant -ResourceGroupName azure-rg-test -Name asdsdsadsad.onmicrosoft.com -Location 'United States' -Sku Standard -CountryCode US -DisplayName "azure.onmicrosoft.com" |  Get-AzADB2CTenant

Location      Name                        Type
--------      ----                        ----
United States asdsdsadsad.onmicrosoft.com   Microsoft.AzureActiveDirectory/b2cDirectories
```

This command gets a tenant of the AzureActiveDirectory by pipeline.
