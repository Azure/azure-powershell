### Example 1: List recovery plans of a service group
```powershell
Get-AzResiliencyRecoveryPlan -ServiceGroupName contoso-sg
```

Lists all recovery plans of service group `contoso-sg`.

### Example 2: Get a recovery plan
```powershell
Get-AzResiliencyRecoveryPlan -ServiceGroupName contoso-sg -Name contoso-recovery-plan
```

Gets recovery plan `contoso-recovery-plan`.
