### Example 1: Validate a reprotect
```powershell
Test-AzResiliencyRecoveryPlanReprotectValidation -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid
```

Validates that the failed-over resources can be reprotected. `-OperationId` is a client-generated GUID that identifies this long-running operation.
