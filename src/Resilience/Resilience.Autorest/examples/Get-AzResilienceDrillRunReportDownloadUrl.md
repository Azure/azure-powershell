### Example 1: Get a download URL for a drill run report
```powershell
Get-AzResilienceDrillRunReportDownloadUrl `
  -DrillName 'drill-zonal-payments' `
  -DrillRunName '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41' `
  -ServiceGroupName 'azcmdlet-testing' `
  -OperationId '7f3a9c21-4e6b-4d88-9a15-2c8b0e5f7d41'
```

Returns a short-lived, read-only URL for downloading the report of the specified drill run.
