### Example 1: Get an authentication setting by name
```powershell
# Get the authentication setting default
Get-AzMonitorHealthModelAuthenticationSetting -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name default
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.CloudHealth/healthmodels/azpwsh-healthmodel1/authenticationsettings/default
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : azpwsh-test-rg
SystemDataCreatedAt          : 5/1/2026 12:00:35 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 5/1/2026 12:00:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.cloudhealth/healthmodels/authenticationsettings
```

Gets a single authentication setting under a health model by name.

### Example 2: List every authentication setting in a health model
```powershell
# List all authentication settings in the health model
Get-AzMonitorHealthModelAuthenticationSetting -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg
```

```output
Name          ProvisioningState ResourceGroupName
----          ----------------- -----------------
default Succeeded         azpwsh-test-rg
default-2         Succeeded         azpwsh-test-rg
```

Lists all authentication setting resources defined on the specified health model.
