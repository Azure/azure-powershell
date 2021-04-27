### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebApp

Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
     East US 2  staticweb-portal02 Microsoft.Web/staticSites
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebApp -ResourceGroupName lucas-rg-test

Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
     East US 2  staticweb-portal02 Microsoft.Web/staticSites
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebApp -ResourceGroupName lucas-rg-test -Name staticweb-portal04

Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
```

{{ Add description here }}



### Example 4: {{ Add title here }}
```powershell
PS C:\> $web = New-AzStaticWebApp -ResourceGroupName lucas-rg-test -Name staticweb-pwsh01 -Location eastus2 -RepositoryUrl 'https://github.com/username/RepoName' -RepositoryToken 'repoToken123' -Branch 'master' -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'free' -SkuTier 'free'
PS C:\> Get-AzStaticWebApp -InputObejct $web 

Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
```


{{ Add description here }}


