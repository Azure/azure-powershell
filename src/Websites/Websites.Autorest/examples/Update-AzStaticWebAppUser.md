### Example 1: {{ Add title here }}
```powershell
PS C:\> Update-AzStaticWebAppUser -ResourceGroupName lucas-rg-test -Name staticweb-portal01 -Authprovider 'github' -Userid 'fa4eba85fa9f4a42b5300dc4c7bb45aa' -Role 'contributor'

Kind Name                             Type
---- ----                             ----
     fa4eba85fa9f4a42b5300dc4c7bb45aa Microsoft.Web/staticSites/users
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebAppUser -ResourceGroupName lucas-rg-test -Name staticweb-portal01 -Authprovider 'all'  | Update-AzStaticWebAppUser -Role 'contributor'

Kind Name                             Type
---- ----                             ----
     fa4eba85fa9f4a42b5300dc4c7bb45aa Microsoft.Web/staticSites/users
     8bcf2cef5f3c4c8e9a58386d62bba7c3 Microsoft.Web/staticSites/users
```

{{ Add description here }}

