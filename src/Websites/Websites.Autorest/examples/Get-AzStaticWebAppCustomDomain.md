### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00

Kind Name               Type
---- ----               ----
     www01.azpstest.net Microsoft.Web/staticSites/customDomains
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\>  New-AzStaticWebAppCustomDomain -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -DomainName 'www02.azpstest.net' | Get-AzStaticWebAppCustomDomain

Kind Name               Type
---- ----               ----
     www02.azpstest.net Microsoft.Web/staticSites/customDomains
```

{{ Add description here }}

