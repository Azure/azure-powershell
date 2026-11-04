### Example 1: Add a note to a drill run
```powershell
Add-AzResiliencyDrillRunNote -DrillName contoso-zonal-drill -DrillRunName contoso-drill-run -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -Note "Zone 2 fault injected at 10:00 UTC."
```

Adds a note to the drill run. `-OperationId` is a client-generated GUID that identifies this long-running operation.
