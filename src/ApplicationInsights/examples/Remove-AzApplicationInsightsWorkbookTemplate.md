### Example 1: Delete a workbook template
```powershell
Remove-AzApplicationInsightsWorkbookTemplate -ResourceGroupName $env.resourceGroup -Name workbooktemplate-pwsh01

```output
```

Delete a workbook template.

### Example 2: Delete a workbook template by pipeline
```powershell
Get-AzApplicationInsightsWorkbookTemplate -ResourceGroupName $env.resourceGroup -Name workbooktemplate-pwsh01 | Remove-AzApplicationInsightsWorkbookTemplate
```

```output
```

Delete a workbook template by pipeline