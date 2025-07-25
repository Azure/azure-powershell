### Example 1: Updates a workbook template that has already been added
```powershell
Update-AzApplicationInsightsWorkbookTemplate -ResourceGroupName resourceGroup -Name workbooktemplate-pwsh01 -Tag @{'k1'='v1'}
```

```output
ResourceGroupName       Name                    Location
-----------------       ----                    --------
appinsights-hkrs2v-test workbooktemplate-pwsh01 westus2
```

Updates a workbook template that has already been added.

### Example 2: Updates a workbook template that has already been added by pipeline
```powershell
Get-AzApplicationInsightsWorkbookTemplate -ResourceGroupName resourceGroup -Name workbooktemplate-pwsh01  | Update-AzApplicationInsightsWorkbookTemplate -Tag @{'k1'='v1'}
```

```output
ResourceGroupName       Name                    Location
-----------------       ----                    --------
appinsights-hkrs2v-test workbooktemplate-pwsh01 westus2
```

Updates a workbook template that has already been added by pipeline.