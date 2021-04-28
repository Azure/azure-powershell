### Example 1: {{ Add title here }}
```powershell
PS C:\> New-AzStaticWebAppSetting -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 -Property @{'function01' = 'value01'; 'function02' = 'value02' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> Get-AzStaticWebAppSetting -ResourceGroupName $env.resourceGroup -Name $env.staticweb01 | New-AzStaticWebAppSetting -Property @{'function01' = 'value01'; 'function02' = 'value02' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/config
```

{{ Add description here }}

