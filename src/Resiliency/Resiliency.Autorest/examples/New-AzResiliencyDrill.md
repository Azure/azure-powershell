### Example 1: Create a zonal drill
```powershell
New-AzResiliencyDrill -ServiceGroupName contoso-sg -Name contoso-zonal-drill -DrillType Zonal -UserAssignedIdentity "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/contoso-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/contoso-identity"
```

Creates a zonal drill that uses a user-assigned managed identity.
