### Example 1: {{ Add title here }}
```powershell
PS C:\> New-AzStaticWebAppBuildFunctionAppSetting -ResourceGroupName lucas-rg-test -Name staticweb-pwsh01 -EnvironmentName 'default' -Property @{'functionapp01' = 'value01'; 'functionapp02' = 'value02' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/builds/config
```

{{ Add description here }}

