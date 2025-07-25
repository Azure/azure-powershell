### Example 1: Register a user provided function app with a static site
```powershell
Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName azure-rg-test -Name staticweb-pwsh02 -FunctionAppName funcapp-portal01-test -FunctionAppResourceId '/subscriptions/xxxxxxxxxxxxx/resourcegroups/azure-rg-test/providers/Microsoft.Web/sites/funcapp-portal01-test' -FunctionAppRegion 'Central US'
```
```output
Kind Name                  Type
---- ----                  ----
     funcapp-portal01-test Microsoft.Web/staticSites/userProvidedFunctionApps
```

This command registers a user provided function app with a static site. The -FunctionAppRegion is region of the function app.

### Example 2: Register a user provided function app with a static site build
```powershell
Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName azure-rg-test -Name staticweb-pwsh02 -FunctionAppName functionapp-portal02 -FunctionAppResourceId '/subscriptions/xxxxxxxxx/resourcegroups/azure-rg-test/providers/Microsoft.Web/sites/functionapp-portal02' -FunctionAppRegion 'Central US' -EnvironmentName 5
```
```output
Kind Name                 Type
---- ----                 ----
     functionapp-portal02 Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

This command registers a user provided function app with a static site build. The -FunctionAppRegion is region of the function app.