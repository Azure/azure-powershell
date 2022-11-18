### Example 1: Delete a workbook template
```powershell
Remove-AzApplicationInsightsWorkbookTemplate -ResourceGroupName appinsights-hkrs2v-test -Name workbooktemplate-pwsh01
```

```output
```

Delete a workbook template.

### Example 2: Delete a workbook template by pipeline
```powershell
Get-AzApplicationInsightsWorkbookTemplate -ResourceGroupName appinsights-hkrs2v-test -Name workbooktemplate-pwsh01 | Remove-AzApplicationInsightsWorkbookTemplate
```

```output
```

Delete a workbook template by pipeline