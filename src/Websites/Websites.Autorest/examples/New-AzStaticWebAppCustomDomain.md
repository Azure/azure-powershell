### Example 1: Create a new static site custom domain in an existing resource group and static site
```powershell
PS C:\> New-AzStaticWebAppCustomDomain -ResourceGroupName resourceGroup -Name staticweb00 -DomainName 'www01.azpstest.net'

Kind Name               Type
---- ----               ----
     www01.azpstest.net Microsoft.Web/staticSites/customDomains
```

This command creates a new static site custom domain in an existing resource group and static site.
First, Need to [configure dns provider](https://docs.microsoft.com/en-us/azure/static-web-apps/custom-domain#configure-dns-provider) for static site. 
