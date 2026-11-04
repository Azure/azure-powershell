### Example 1: Create a zonal recovery plan
```powershell
New-AzResiliencyRecoveryPlan -ServiceGroupName contoso-sg -Name contoso-recovery-plan -PlanType Zonal -PlanDescription "Zonal recovery for contoso" -UserAssignedIdentity "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/contoso-identity"
```

Creates a zonal recovery plan that uses a user-assigned managed identity.
