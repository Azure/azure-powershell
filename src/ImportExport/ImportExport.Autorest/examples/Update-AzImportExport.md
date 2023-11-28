### Example 1: Update ImportExport job by resource group and server name
```powershell
Update-AzImportExport -Name test-job -ResourceGroupName ImportTestRG -DeliveryPackageCarrierName pwsh -DeliveryPackageTrackingNumber pwsh20200000
```

```output
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet updates ImportExport job by resource group and server name.

### Example 2: Update ImportExport job by identity.
```powershell
Get-AzImportExport -Name test-job -ResourceGroupName ImportTestRG | Update-AzImportExport -CancelRequested
```

```output
Location Name     Type
-------- ----     ----
East US  test-job Microsoft.ImportExport/jobs
```

This cmdlet updates ImportExport job by identity.