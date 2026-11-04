### Example 1: Validate that a drill can run
```powershell
Test-AzResiliencyDrillExecutionValidation -DrillName contoso-zonal-drill -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid
```

Checks that the drill and its resources are ready to run. `-OperationId` is a client-generated GUID that identifies this long-running operation.
