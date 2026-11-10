### Example 1: List the jobs of a recovery plan
```powershell
Get-AzResiliencyRecoveryJob -ServiceGroupName contoso-sg -RecoveryPlanName contoso-recovery-plan
```

Lists the recovery jobs of recovery plan `contoso-recovery-plan`.

### Example 2: Get a recovery job
```powershell
Get-AzResiliencyRecoveryJob -ServiceGroupName contoso-sg -RecoveryPlanName contoso-recovery-plan -Name contoso-recovery-job
```

Gets recovery job `contoso-recovery-job`.
