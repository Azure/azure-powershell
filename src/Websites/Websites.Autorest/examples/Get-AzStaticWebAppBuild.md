### Example 1: {{ Add title here }}
```powershell
PS C:\>  Get-AzStaticWebAppBuild -ResourceGroupName lucas-rg-test -Name staticweb-portal04

Kind Name    Type
---- ----    ----
     default Microsoft.Web/staticSites/builds
```

{{ Add description here }}

{
  "id": "/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/lucas-rg-test/providers/Microsoft.Web/staticSites/staticweb-portal04/builds/default",
  "name": "default",
  "type": "Microsoft.Web/staticSites/builds",
  "properties": {
    "buildId": "default",
    "sourceBranch": "lucas/dev",
    "hostname": "wonderful-desert-0d05b1d10.azurestaticapps.net",
    "createdTimeUtc": "2021-04-06T08:59:33.3694276",
    "lastUpdatedOn": "2021-04-06T09:02:01.2965166",
    "status": "Ready"
  }
}


### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebAppBuild -ResourceGroupName lucas-rg-test -Name staticweb-portal04 -EnvironmentName 'default'

Kind Name    Type
---- ----    ----
     default Microsoft.Web/staticSites/builds
```

{{ Add description here }}
