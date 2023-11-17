### Example 1: Update a user entry with the listed roles
```powershell
Update-AzStaticWebAppUser -ResourceGroupName azure-rg-test -Name staticweb-portal01 -Authprovider 'github' -Userid 'fa4eba85fa9f4a42b5300dc4c7bb45aa' -Role 'contributor'
```
```output
Kind Name                             Type
---- ----                             ----
     fa4eba85fa9f4a42b5300dc4c7bb45aa Microsoft.Web/staticSites/users
```

This command updates a user entry with the listed roles.

### Example 2: Update a user entry with the listed roles by pipeline
```powershell
Get-AzStaticWebAppUser -ResourceGroupName azure-rg-test -Name staticweb-portal01 -Authprovider 'all'  | Update-AzStaticWebAppUser -Role 'contributor'
```
```output
Kind Name                             Type
---- ----                             ----
     fa4eba85fa9f4a42b5300dc4c7bb45aa Microsoft.Web/staticSites/users
     8bcf2cef5f3c4c8e9a58386d62bba7c3 Microsoft.Web/staticSites/users
```

This command updates a user entry with the listed roles by pipeline.