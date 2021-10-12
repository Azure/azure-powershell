### Example 1: Validate a particular custom domain can be added to a static site
```powershell
PS C:\> Test-AzStaticWebAppCustomDomain -ResourceGroupName resourceGroup -Name staticweb00 -DomainName 'www01.azpstest.net'

```

This commnad validates a particular custom domain can be added to a static site

### Example 2: Validate a particular custom domain can be added to a static site by pipeline
```powershell
PS C:\> Get-AzStaticWebAppCustomDomain -ResourceGroupName resourceGroup -Name staticweb00 -DomainName 'www01.azpstest.net' | Get-AzStaticWebAppCustomDomain

```

This commnad validates a particular custom domain can be added to a static site by pipeline.

