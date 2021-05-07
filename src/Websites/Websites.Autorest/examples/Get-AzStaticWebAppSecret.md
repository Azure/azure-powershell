### Example 1: List the secrets for an existing static site
```powershell
PS C:\> Get-AzStaticWebAppSecret -ResourceGroupName resourceGroup -Name staticweb-portal04

Kind Name    Type
---- ----    ----
     secrets Microsoft.Web/staticSites/secrets
```

This command lists the secrets for an existing static site.

