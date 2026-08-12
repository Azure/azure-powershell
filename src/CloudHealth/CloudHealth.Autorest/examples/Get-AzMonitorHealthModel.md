### Example 1: Get a health model by name
```powershell
# Get the health model azpwsh-healthmodel1
Get-AzMonitorHealthModel -Name azpwsh-healthmodel1 -ResourceGroupName azpwsh-test-rg
```

```output
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/azpwsh-test-rg/providers/Microsoft.CloudHealth/healthmodels/azpwsh-healthmodel1
Location                     : eastus2
Name                         : azpwsh-healthmodel1
ProvisioningState            : Succeeded
ResourceGroupName            : azpwsh-test-rg
SystemDataCreatedAt          : 5/1/2026 12:00:35 AM
SystemDataCreatedBy          : contoso@microsoft.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 5/1/2026 12:00:35 AM
SystemDataLastModifiedBy     : contoso@microsoft.com
SystemDataLastModifiedByType : User
Type                         : microsoft.cloudhealth/healthmodels
```

Gets a single health model by its name and the resource group it belongs to.

### Example 2: List all health models in a resource group
```powershell
# List all health models in the resource group azpwsh-test-rg
Get-AzMonitorHealthModel -ResourceGroupName azpwsh-test-rg
```

```output
Location Name                 SystemDataCreatedAt   SystemDataCreatedByType ResourceGroupName
-------- ----                 -------------------   ----------------------- -----------------
eastus2  azpwsh-healthmodel1 5/1/2026 12:00:35 AM  User                    azpwsh-test-rg
eastus2  azpwsh-healthmodel2  5/1/2026 12:01:06 AM  User                    azpwsh-test-rg
```

Lists all health models in the specified resource group.
