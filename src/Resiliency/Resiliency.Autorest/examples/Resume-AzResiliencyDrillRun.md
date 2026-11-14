### Example 1: Resume a paused drill run
```powershell
Resume-AzResiliencyDrillRun -DrillName contoso-zonal-drill -ServiceGroupName contoso-sg -Name contoso-drill-run -OperationId (New-Guid).Guid
```

Resumes a failover workflow that is paused after the fault stage. `-OperationId` is a client-generated GUID that identifies this long-running operation.
