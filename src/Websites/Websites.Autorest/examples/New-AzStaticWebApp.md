### Example 1: Create a new static site in an existing resource group, or updates an existing static site
```powershell
PS C:\>New-AzStaticWebApp -ResourceGroupName 'azure-rg-test' -Name 'staticweb-45asde' -Location 'Central US' -RepositoryUrl 'https://github.com/LucasYao93/blazor-starter' -RepositoryToken 'githubAccessToken' -Branch 'branch02' -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'Standard'

Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb-45asde Microsoft.Web/staticSites
```

This command creates a new static site in an existing resource group, or updates an existing static site.

