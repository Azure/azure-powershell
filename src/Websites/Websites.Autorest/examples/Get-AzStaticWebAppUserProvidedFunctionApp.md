### Example 1: List the details of the user provided function apps registered with a static site
```powershell
PS C:\> Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName resourceGroup -Name staticweb00

Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/userProvidedFunctionApps
```

This command lists the details of the user provided function apps registered with a static site

### Example 2: List the details of the user provided function apps registered with a static site build
```powershell
PS C:\> Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName resourceGroup -Name staticweb00 -EnvironmentName 'default'

Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

This command lists the details of the user provided function apps registered with a static site build.

### Example 3: List the details of the user provided function apps registered
```powershell
PS C:\> Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName resourceGroup -Name staticweb00 -FunctionAppName $env.functionAppName01

Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

This command lists the details of the user provided function apps registered.

### Example 4: Get the details of the user provided function app registered with a static site build
```powershell
PS C:\> Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName resourceGroup -Name staticweb00 -EnvironmentName 'default' -FunctionAppName $env.functionAppName01

Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

This command gets the details of the user provided function app registered with a static site build.

### Example 5: Get the details of the user provided function apps registered with a static site build by pipeline
```powershell
PS C:\> Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName lucas-rg-test -Name staticweb-pwsh02 -FunctionAppName functionapp-portal02 -FunctionAppResourceId '/subscriptions/xxxxxx-xx-xxx-xxxx-xxxxx/resourcegroups/xxx-xx-xxxx/providers/Microsoft.Web/sites/functionapp-portal02' -FunctionAppRegion 'Central US' -EnvironmentName 5 | Get-AzStaticWebAppUserProvidedFunctionApp 

Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

This command gets the details of the user provided function app registered with a static site build by pipeline.
