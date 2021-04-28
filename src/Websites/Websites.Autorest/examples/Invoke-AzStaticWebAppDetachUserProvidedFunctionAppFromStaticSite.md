### Example 1: {{ Add title here }}
```powershell
PS C:\> Invoke-AzStaticWebAppDetachUserProvidedFunctionAppFromStaticSite -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -FunctionAppName 'functionApp-z7utni'

```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebAppUserProvidedFunctionApp -ResourceGroupName $env.resourceGroup -Name $env.staticweb00 -FunctionAppName $env.functionAppName01 | Invoke-AzStaticWebAppDetachUserProvidedFunctionAppFromStaticSite

```

{{ Add description here }}

