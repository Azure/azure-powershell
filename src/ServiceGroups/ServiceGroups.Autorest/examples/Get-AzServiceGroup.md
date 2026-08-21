### Example 1: Get a service group by name
```powershell
Get-AzServiceGroup -Name "Contoso"
```

```output
DisplayName   : Contoso Group
Id            : /providers/Microsoft.Management/serviceGroups/Contoso
Kind          :
Name          : Contoso
ParentResourceId : /providers/Microsoft.Management/serviceGroups/00000000-0000-0000-0000-000000000000
ProvisioningState : Succeeded
Type          : Microsoft.Management/serviceGroups
```

Gets the details of the service group named 'Contoso', including its display name, parent, and provisioning state.

### Example 2: Get a service group using identity input
```powershell
$inputObject = @{ServiceGroupName = "Contoso"}
Get-AzServiceGroup -InputObject $inputObject
```

```output
DisplayName   : Contoso Group
Id            : /providers/Microsoft.Management/serviceGroups/Contoso
Kind          :
Name          : Contoso
ParentResourceId : /providers/Microsoft.Management/serviceGroups/00000000-0000-0000-0000-000000000000
ProvisioningState : Succeeded
Type          : Microsoft.Management/serviceGroups
```

Gets a service group by constructing an identity object as input.

