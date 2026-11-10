### Example 1: Fail over a drill run
```powershell
Invoke-AzResiliencyDrillRunFailover -DrillName contoso-zonal-drill -DrillRunName contoso-drill-run -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -AutoFailover Enable -ExecutionConfigurationUserConsent Allowed
```

Starts the failover stage of the drill run. `-OperationId` is a client-generated GUID that identifies this long-running operation.
