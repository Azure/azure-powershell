### Example 1: Generate a drill run report
```powershell
New-AzResiliencyDrillRunReport -DrillName contoso-zonal-drill -DrillRunName contoso-drill-run -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid
```

Generates the report for the drill run. `-OperationId` is a client-generated GUID that identifies this long-running operation.
