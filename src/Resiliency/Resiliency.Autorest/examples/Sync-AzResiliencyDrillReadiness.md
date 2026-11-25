### Example 1: Resync drill readiness
```powershell
Sync-AzResiliencyDrillReadiness -DrillName contoso-zonal-drill -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid
```

Resyncs the drill resources and re-runs the readiness check. `-OperationId` is a client-generated GUID that identifies this long-running operation.
