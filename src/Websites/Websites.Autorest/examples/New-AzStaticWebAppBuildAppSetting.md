### Example 1: {{ Add title here }}
```powershell
PS C:\> New-AzStaticWebAppBuildAppSetting -ResourceGroupName lucas-rg-test -Name staticweb-pwsh01 -EnvironmentName 'default'  -Property @{'buildsetting1' = 'someval'; 'buildsetting2' = 'someval2' }

Kind Name        Type
---- ----        ----
     appsettings Microsoft.Web/staticSites/builds/config
```

{{ Add description here }}

