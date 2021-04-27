### Example 1: {{ Add title here }}
```powershell
PS C:\> Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName lucas-rg-test -Name staticweb-pwsh02 -FunctionAppName funcapp-portal01-test -FunctionAppResourceId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lucas-rg-test/providers/Microsoft.Web/sites/funcapp-portal01-test' -FunctionAppRegion 'Central US'

Kind Name                  Type
---- ----                  ----
     funcapp-portal01-test Microsoft.Web/staticSites/userProvidedFunctionApps
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName lucas-rg-test -Name staticweb-pwsh02 -FunctionAppName functionapp-portal02 -FunctionAppResourceId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lucas-rg-test/providers/Microsoft.Web/sites/functionapp-portal02' -FunctionAppRegion 'Central US' -EnvironmentName 5

Kind Name                 Type
---- ----                 ----
     functionapp-portal02 Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

{{ Add description here }}

