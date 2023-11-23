### Example 1: Updates a private workbook that has already been added
```powershell
$myWorkbook = Get-AzApplicationInsightsMyWorkbook -ResourceGroupName "appinsights-hkrs2v-test" -Name "2e47417f-c136-44c0-b78f-7a4ca35fd9d1"
$myWorkbook.DisplayName = "pwsh01"
Update-AzApplicationInsightsMyWorkbook -ResourceGroupName "appinsights-hkrs2v-test" -Name "2e47417f-c136-44c0-b78f-7a4ca35fd9d1" -WorkbookProperty $myWorkbook
```

```output
ResourceGroupName       Name                                 DisplayName Location Kind Category
-----------------       ----                                 ----------- -------- ---- --------
appinsights-hkrs2v-test 2e47417f-c136-44c0-b78f-7a4ca35fd9d1 pwsh01      westus2  user workbook
```

Updates a private workbook that has already been added.