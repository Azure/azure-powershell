### Example 1: Create a new static site in an existing resource group, or updates an existing static site
```powershell
New-AzStaticWebApp -ResourceGroupName 'azure-rg-test' -Name 'staticweb-45asde' -Location 'Central US' -RepositoryUrl 'https://github.com/LucasYao93/blazor-starter' -RepositoryToken 'githubAccessToken' -Branch 'branch02' -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'Standard'
```
```output
Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb-45asde Microsoft.Web/staticSites
```

This command creates a new static site in an existing resource group, or updates an existing static site.

### Example 2: Create a new static site in an existing resource group through specified template repository
```powershell
New-AzStaticWebApp -ResourceGroupName 'azure-rg-test' -Name staticweb-pwsh01 -Location "Central US" -RepositoryToken  'xxxxxxxxxxxxxxxxx' -TemplateRepositoryUrl 'https://github.com/staticwebdev/blazor-starter' -ForkRepositoryDescription "Test template repository function of the azure static web." -ForkRepositoryName "test-blazor-starter" -ForkRepositoryOwner 'LucasYao93' -Branch 'main' -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'Standard'
```
```output
Kind Location   Name             Type
---- --------   ----             ----
     Central US staticweb-pwsh01 Microsoft.Web/staticSites
```

This command creates a new static site in an existing resource group, or updates an existing static site through specified template repository.