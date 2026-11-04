### Example 1: Get the report download URL of a drill run
```powershell
Get-AzResiliencyDrillRunReportDownloadUrl -DrillName contoso-zonal-drill -DrillRunName contoso-drill-run -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -Format Html
```

Returns a short-lived, read-only URL to download the HTML report of the drill run. `-OperationId` is a client-generated GUID that identifies this long-running operation.
