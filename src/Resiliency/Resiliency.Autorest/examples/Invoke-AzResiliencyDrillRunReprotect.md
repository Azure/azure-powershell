### Example 1: Reprotect a drill run
```powershell
Invoke-AzResiliencyDrillRunReprotect -DrillName contoso-zonal-drill -DrillRunName contoso-drill-run -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid
```

Starts the reprotect stage of the drill run. `-OperationId` is a client-generated GUID that identifies this long-running operation.
