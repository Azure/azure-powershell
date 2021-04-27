### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00

Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/userProvidedFunctionApps
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -EnvironmentName 'default'

Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

{{ Add description here }}

### Example 3: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -FunctionAppName $env.functionAppName01

Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

{{ Add description here }}

### Example 4: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -EnvironmentName 'default' -FunctionAppName $env.functionAppName01

Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

{{ Add description here }}

### Example 5: {{ Add title here }}
```powershell
PS C:\> Register-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName lucas-rg-test -Name staticweb-pwsh02 -FunctionAppName functionapp-portal02 -FunctionAppResourceId '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourcegroups/lucas-rg-test/providers/Microsoft.Web/sites/functionapp-portal02' -FunctionAppRegion 'Central US' -EnvironmentName 5 | Get-AzStaticWebAppUserProvidedFunctionApp 

Kind Name               Type
---- ----               ----
     functionApp-5enjko Microsoft.Web/staticSites/builds/userProvidedFunctionApps
```

{{ Add description here }}

