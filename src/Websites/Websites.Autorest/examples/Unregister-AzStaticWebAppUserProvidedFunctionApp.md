### Example 1: Unregister the user provided function app from the static site
```powershell
PS C:\> Unregister-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName 'resourceGroup' -Name 'staticweb00' -FunctionAppName 'functionAppName01'

```

This command unregisters the user provided function app from the static site.

### Example 2: Unregister the user provided function app from the static site by pipeline
```powershell
PS C:\> Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -FunctionAppName $env.functionAppName01 -FunctionAppResourceId $env.functionAppId01 -FunctionAppRegion $env.location -IsForced | Unregister-AzStaticWebAppUserProvidedFunctionApp 

```

This command unregisters the user provided function app from the static site by pipeline.
