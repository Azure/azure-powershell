### Example 1: Check the readiness of a recovery plan
```powershell
Test-AzResiliencyRecoveryPlanReadiness -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid
```

Checks whether the resources of the recovery plan are ready for recovery. `-OperationId` is a client-generated GUID that identifies this long-running operation.
