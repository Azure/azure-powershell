### Example 1: End a drill with an attestation
```powershell
Stop-AzResiliencyDrill -ServiceGroupName contoso-sg -Name contoso-zonal-drill -OperationId (New-Guid).Guid -Attestation Success -AttestationNote "Workload stayed available during the zone outage."
```

Ends the drill and records whether it succeeded. `-OperationId` is a client-generated GUID that identifies this long-running operation.
