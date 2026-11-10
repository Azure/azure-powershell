### Example 1: Reprotect a recovery plan
```powershell
Invoke-AzResiliencyRecoveryPlanReprotect -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid
```

Reprotects the failed-over resources of the recovery plan. `-OperationId` is a client-generated GUID that identifies this long-running operation.
