### Example 1: List the resources of a recovery job
```powershell
Get-AzResiliencyRecoveryJobResource -ServiceGroupName contoso-sg -RecoveryPlanName contoso-recovery-plan -RecoveryJobName contoso-recovery-job
```

Lists the resources processed by recovery job `contoso-recovery-job`.

### Example 2: Get a recovery job resource
```powershell
Get-AzResiliencyRecoveryJobResource -ServiceGroupName contoso-sg -RecoveryPlanName contoso-recovery-plan -RecoveryJobName contoso-recovery-job -Name contoso-recovery-job-resource
```

Gets a single recovery job resource.
