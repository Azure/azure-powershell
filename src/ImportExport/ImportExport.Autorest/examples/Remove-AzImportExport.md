### Example 1: Remove ImportExport job by resourceGroup and server name
```powershell
Remove-AzImportExport -Name test-job -ResourceGroupName ImportTestRG
```

This cmdlet removes ImportExport job by resourceGroup and server name.

### Example 2: Remove ImportExport job by identity
```powershell
Get-AzImportExport -Name test-job -ResourceGroupName ImportTestRG | Remove-AzImportExport
```

These cmdlet removes ImportExport job by identity.