### Example 1: Start a drill
```powershell
Start-AzResiliencyDrill -ServiceGroupName contoso-sg -Name contoso-zonal-drill -OperationId (New-Guid).Guid
```

Starts a new run of the drill. `-OperationId` is a client-generated GUID that identifies this long-running operation.
