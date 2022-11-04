### Example 1: {{ Add title here }}
```powershell
Update-AzApplicationInsightsWorkbookTemplate -ResourceGroupName resourceGroup -Name workbooktemplate-pwsh01 -Tag @{'k1'='v1'}
```

```output
ResourceGroupName       Name                    Location
-----------------       ----                    --------
appinsights-hkrs2v-test workbooktemplate-pwsh01 westus2
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
Get-AzApplicationInsightsWorkbookTemplate -ResourceGroupName resourceGroup -Name workbooktemplate-pwsh01  | Update-AzApplicationInsightsWorkbookTemplate -Tag @{'k1'='v1'}
```

```output
ResourceGroupName       Name                    Location
-----------------       ----                    --------
appinsights-hkrs2v-test workbooktemplate-pwsh01 westus2
```

{{ Add description here }}

