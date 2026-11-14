### Example 1: Mark a drill run stage as complete
```powershell
Complete-AzResiliencyDrillRun -DrillName contoso-zonal-drill -ServiceGroupName contoso-sg -Name contoso-drill-run -OperationId (New-Guid).Guid -DrillRunStage Failover
```

Marks the failover stage of the drill run as complete, so it is not retried. `-OperationId` is a client-generated GUID that identifies this long-running operation.
