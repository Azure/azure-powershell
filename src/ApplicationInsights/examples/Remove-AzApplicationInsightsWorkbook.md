### Example 1: Delete a workbook
```powershell
Remove-AzApplicationInsightsWorkbook -ResourceGroupName appinsights-hkrs2v-test -Name 7d195dcc-7d02-459f-a181-5b46662e4060
```

```output
```

Delete a workbook.

### Example 2: Delete a workbook by pipeline
```powershell
Get-AzApplicationInsightsWorkbook -ResourceGroupName appinsights-hkrs2v-test -Name 7d195dcc-7d02-459f-a181-5b46662e4060 | Remove-AzApplicationInsightsWorkbook
```

```output
```

Delete a workbook by pipeline