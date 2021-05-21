### Example 1: List all existing custom domains for a particular static site
```powershell
PS C:\> Get-AzStaticWebAppCustomDomain -ResourceGroupName azure-rg-test -Name staticweb00

Kind Name               Type
---- ----               ----
     www01.azpstest.net Microsoft.Web/staticSites/customDomains
```

This command lists all existing custom domains for a particular static site.

### Example 2: Get an existing custom domain for a particular static site
```powershell
PS C:\>  Get-AzStaticWebAppCustomDomain -ResourceGroupName azure-rg-test -Name staticweb00 -DomainName 'www02.azpstest.net'

Kind Name               Type
---- ----               ----
     www02.azpstest.net Microsoft.Web/staticSites/customDomains
```

This command gets an existing custom domain for a particular static site.

### Example 3: Get an existing custom domain for a particular static site by pipeline
```powershell
PS C:\>  New-AzStaticWebAppCustomDomain -ResourceGroupName azure-rg-test -Name staticweb00 -DomainName 'www02.azpstest.net' | Get-AzStaticWebAppCustomDomain

Kind Name               Type
---- ----               ----
     www02.azpstest.net Microsoft.Web/staticSites/customDomains
```

This command gets an existing custom domain for a particular static site by pipeline.

