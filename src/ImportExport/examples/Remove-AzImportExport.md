### Example 1: Remove ImportExport job by resourceGroup and server name
```powershell
PS C:\> Remove-AzImportExport -Name test-job -ResourceGroupName ImportTestRG
```

This cmdlet removes ImportExport job by resourceGroup and server name.

### Example 2: Remove ImportExport job by identity
```powershell
PS C:\> Get-AzImportExport -Name test-job -ResourceGroupName ImportTestRG | Remove-AzImportExport
 
```

These cmdlet removes ImportExport job by identity.