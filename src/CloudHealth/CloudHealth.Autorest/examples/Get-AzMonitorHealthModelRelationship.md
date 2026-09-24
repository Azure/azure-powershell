### Example 1: Get a health model relationship by name
```powershell
# Get the relationship frontend-to-backend
Get-AzMonitorHealthModelRelationship -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name frontend-to-backend
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.CloudHealth/healthmodels/azpwsh-healthmodel1/relationships/frontend-to-backend
Name                         : frontend-to-backend
ProvisioningState            : Succeeded
ResourceGroupName            : azpwsh-test-rg
SystemDataCreatedAt          : 5/1/2026 12:00:35 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 5/1/2026 12:00:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.cloudhealth/healthmodels/relationships
```

Gets a single health model relationship under a health model by name.

### Example 2: List every health model relationship in a health model
```powershell
# List all relationships in the health model
Get-AzMonitorHealthModelRelationship -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg
```

```output
Name          ProvisioningState ResourceGroupName
----          ----------------- -----------------
frontend-to-backend Succeeded         azpwsh-test-rg
frontend-to-backend-2         Succeeded         azpwsh-test-rg
```

Lists all health model relationship resources defined on the specified health model.
