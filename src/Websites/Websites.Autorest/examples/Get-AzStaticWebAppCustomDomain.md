### Example 1: List all domains under a static web app
```powershell
PS C:\> Get-AzStaticWebAppCustomDomain -ResourceGroupName azure-rg-test -Name staticweb00

Kind Name               Type
---- ----               ----
     www01.azpstest.net Microsoft.Web/staticSites/customDomains
```

This command lists all domains under a static web app.

### Example 2: Get domain of the static web app by name
```powershell
PS C:\>  Get-AzStaticWebAppCustomDomain -ResourceGroupName azure-rg-test -Name staticweb00 -DomainName 'www02.azpstest.net'

Kind Name               Type
---- ----               ----
     www02.azpstest.net Microsoft.Web/staticSites/customDomains
```

This command gets domain of the static web app by name.

### Example 3: Get domain of the static web app by pipeline
```powershell
PS C:\>  New-AzStaticWebAppCustomDomain -ResourceGroupName azure-rg-test -Name staticweb00 -DomainName 'www02.azpstest.net' | Get-AzStaticWebAppCustomDomain

Kind Name               Type
---- ----               ----
     www02.azpstest.net Microsoft.Web/staticSites/customDomains
```

This command gets domain of the static web app by pipeline.

