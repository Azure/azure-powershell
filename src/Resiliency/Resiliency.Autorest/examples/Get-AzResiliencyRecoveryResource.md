### Example 1: List the resources of a recovery plan
```powershell
Get-AzResiliencyRecoveryResource -ServiceGroupName contoso-sg -RecoveryPlanName contoso-recovery-plan
```

Lists the resources of recovery plan `contoso-recovery-plan`.

### Example 2: Get a recovery resource
```powershell
Get-AzResiliencyRecoveryResource -ServiceGroupName contoso-sg -RecoveryPlanName contoso-recovery-plan -Name contoso-recovery-resource
```

Gets a single recovery resource.
