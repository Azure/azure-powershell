### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebApp

Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
     East US 2  staticweb-portal02 Microsoft.Web/staticSites
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebApp -ResourceGroupName lucas-rg-test

Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
     East US 2  staticweb-portal02 Microsoft.Web/staticSites
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebApp -ResourceGroupName lucas-rg-test -Name staticweb-portal04

Kind Location   Name               Type
---- --------   ----               ----
     Central US staticweb-portal04 Microsoft.Web/staticSites
```

{{ Add description here }}

{
  "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/Microsoft.Web/staticSites/staticweb-portal04",
  "name": "staticweb-portal04",
  "location": "Central US",
  "type": "Microsoft.Web/staticSites",
  "properties": {
    "defaultHostname": "wonderful-desert-0d05b1d10.azurestaticapps.net",
    "repositoryUrl": "https://github.com/LucasYao93/blazor-starter",
    "branch": "lucas/dev",
    "provider": "GitHub",
    "customDomains": [ ],
    "contentDistributionEndpoint": "https://content-dm1.infrastructure.azurestaticapps.net",
    "keyVaultReferenceIdentity": "SystemAssigned"
  },
  "sku": {
    "name": "Free",
    "tier": "Free"
  }
}


### Example 4: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}


