### Example 1: {{ Add title here }}
```powershell
PS C:\> New-AzStaticWebAppFunctionAppSetting -ResourceGroupName lucas-rg-test -Name staticweb-pwsh01  -Property @{'function01' = 'value01'; 'function02' = 'value02' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

{{ Add description here }}

### Example 1: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebAppFunctionAppSetting -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 | New-AzStaticWebAppFunctionAppSetting -Property @{'function01' = 'value01'; 'function02' = 'value02' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

{{ Add description here }}

