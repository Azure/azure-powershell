### Example 1: Updates a workbook that has already been added
```powershell
Update-AzApplicationInsightsWorkbook -ResourceGroupName appinsights-hkrs2v-test -Name cc18e5e4-9558-4be1-b333-20b28aaca021 -DisplayName "workbook-portal"
```

```output
ResourceGroupName       Name                                 DisplayName     Location Kind   Category
-----------------       ----                                 -----------     -------- ----   --------
appinsights-hkrs2v-test cc18e5e4-9558-4be1-b333-20b28aaca021 workbook-portal eastus   shared workbook
```

Updates a workbook that has already been added

### Example 2: Updates a workbook that has already been added by pipeline
```powershell
Get-AzApplicationInsightsWorkbook -ResourceGroupName appinsights-hkrs2v-test -Name cc18e5e4-9558-4be1-b333-20b28aaca021 | Update-AzApplicationInsightsWorkbook -Tag @{'k1'='v1'}
```

```output
ResourceGroupName       Name                                 DisplayName     Location Kind   Category
-----------------       ----                                 -----------     -------- ----   --------
appinsights-hkrs2v-test cc18e5e4-9558-4be1-b333-20b28aaca021 workbook-portal eastus   shared workbook
```

Updates a workbook that has already been added by pipeline.