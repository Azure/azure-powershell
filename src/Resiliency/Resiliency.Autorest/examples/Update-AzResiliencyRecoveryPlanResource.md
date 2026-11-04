### Example 1: Remove a resource from a recovery plan
```powershell
Update-AzResiliencyRecoveryPlanResource -RecoveryPlanName contoso-recovery-plan -ServiceGroupName contoso-sg -OperationId (New-Guid).Guid -ResourcesToRemove "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.Compute/virtualMachines/contoso-vm2"
```

Removes a resource from the recovery plan. `-OperationId` is a client-generated GUID that identifies this long-running operation.
