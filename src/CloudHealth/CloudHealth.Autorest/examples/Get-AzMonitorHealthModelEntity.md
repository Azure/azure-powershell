### Example 1: Get a health model entity by name
```powershell
# Get the entity app-frontend
Get-AzMonitorHealthModelEntity -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name app-frontend
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.CloudHealth/healthmodels/azpwsh-healthmodel1/entities/app-frontend
Name                         : app-frontend
ProvisioningState            : Succeeded
ResourceGroupName            : azpwsh-test-rg
SystemDataCreatedAt          : 5/1/2026 12:00:35 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 5/1/2026 12:00:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.cloudhealth/healthmodels/entities
```

Gets a single health model entity under a health model by name.

### Example 2: List every health model entity in a health model
```powershell
# List all entities in the health model
Get-AzMonitorHealthModelEntity -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg
```

```output
Name          ProvisioningState ResourceGroupName
----          ----------------- -----------------
app-frontend Succeeded         azpwsh-test-rg
app-frontend-2         Succeeded         azpwsh-test-rg
```

Lists all health model entity resources defined on the specified health model.
