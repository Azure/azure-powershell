### Example 1: Get a signal definition by name
```powershell
Get-AzMonitorHealthModelSignalDefinition -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg -Name cpu-signal
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.CloudHealth/healthmodels/azpwsh-healthmodel1/signaldefinitions/cpu-signal
Name                         : cpu-signal
ProvisioningState            : Succeeded
ResourceGroupName            : azpwsh-test-rg
SystemDataCreatedAt          : 5/1/2026 12:00:35 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 5/1/2026 12:00:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.cloudhealth/healthmodels/signaldefinitions
```

Gets a single signal definition under a health model by name.

### Example 2: List every signal definition in a health model
```powershell
Get-AzMonitorHealthModelSignalDefinition -HealthModelName azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg
```

```output
Name          ProvisioningState ResourceGroupName
----          ----------------- -----------------
cpu-signal Succeeded         azpwsh-test-rg
cpu-signal-2         Succeeded         azpwsh-test-rg
```

Lists all signal definition resources defined on the specified health model.
