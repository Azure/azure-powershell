### Example 1: List all static web applications under a subscription
```powershell
PS C:\> Get-AzStaticWebApp

Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
     East US 2  staticweb-portal02 Microsoft.Web/staticSites
```

This commands list all static web applications under a subscription.

### Example 2: List all static web applications under a resource group
```powershell
PS C:\> Get-AzStaticWebApp -ResourceGroupName azure-rg-test

Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
     East US 2  staticweb-portal02 Microsoft.Web/staticSites
```

This commands list all static web applications under a resource group.

### Example 3: Get a satic web application by name
```powershell
PS C:\> Get-AzStaticWebApp -ResourceGroupName azure-rg-test -Name staticweb-portal04

Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
```

This commands gets a satic web application by name.


### Example 4: Get a satic web application by pipline
```powershell
PS C:\> New-AzStaticWebApp -ResourceGroupName azure-rg-test -Name staticweb-pwsh01 -Location eastus2 -RepositoryUrl 'https://github.com/username/RepoName' -RepositoryToken 'repoToken123' -Branch 'master' -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'free' -SkuTier 'free'  | Get-AzStaticWebApp -InputObejct 

Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
```

This commands gets a satic web application by pipline.


