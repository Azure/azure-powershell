### Example 1: Replace a recovery plan
```powershell
Set-AzResiliencyRecoveryPlan -ServiceGroupName contoso-sg -Name contoso-recovery-plan -PlanType Zonal -PlanDescription "Zonal recovery for contoso" -UserAssignedIdentity "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/contoso-identity"
```

Replaces the recovery plan with the supplied definition (PUT).
