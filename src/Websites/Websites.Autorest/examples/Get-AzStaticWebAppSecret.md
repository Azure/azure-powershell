### Example 1: List the secrets for an existing static site
```powershell
Get-AzStaticWebAppSecret -ResourceGroupName resourceGroup -Name staticweb-portal04
```
```output
Kind Name    Type
---- ----    ----
     secrets Microsoft.Web/staticSites/secrets
```

This command lists the secrets for an existing static site.

