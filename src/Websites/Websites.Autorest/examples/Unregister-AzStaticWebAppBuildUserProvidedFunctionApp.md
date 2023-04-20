### Example 1: Unregister the user provided function app from the static site build
```powershell
Unregister-AzStaticWebAppBuildUserProvidedFunctionApp -ResourceGroupName 'resourceGroup' -Name 'staticweb00' -EnvironmentName 'default' -FunctionAppName 'functionAppName01'

```

This command unregisters the user provided function app from the static site build.

### Example 2: Unregister the user provided function app from the static site build by pipeline
```powershell
Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName 'resourceGroup' -Name 'staticweb00' -EnvironmentName 'default' -FunctionAppName 'functionAppName01' -FunctionAppResourceId 'functionAppId01' -FunctionAppRegion 'eastus' -Forced | Unregister-AzStaticWebAppBuildUserProvidedFunctionApp

```

This command unregisters the user provided function app from the static site build by pipeline.