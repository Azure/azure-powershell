### Example 1: {{ Add title here }}
```powershell
PS C:\> New-AzStaticWebApp -ResourceGroupName lucas-rg-test -Name staticweb-pwsh01 -Location eastus2 -RepositoryUrl 'https://github.com/username/RepoName' -RepositoryToken 'repoToken123' -Branch 'master' -AppLocation 'Client' -ApiLocation 'Api' -OutputLocation 'wwwroot' -SkuName 'free' -SkuTier 'free'

Kind Location  Name             Type
---- --------  ----             ----
     East US 2 staticweb-pwsh01 Microsoft.Web/staticSites
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

