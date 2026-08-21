### Example 1: Update the display name of a service group
```powershell
Update-AzServiceGroup -Name "Contoso" -DisplayName "Contoso Group Updated"
```

```output
DisplayName   : Contoso Group Updated
Id            : /providers/Microsoft.Management/serviceGroups/Contoso
Kind          :
Name          : Contoso
ParentResourceId : /providers/Microsoft.Management/serviceGroups/00000000-0000-0000-0000-000000000000
ProvisioningState : Succeeded
Type          : Microsoft.Management/serviceGroups
```

Updates the display name of the 'Contoso' service group. The update operation is asynchronous.

### Example 2: Move a service group under a different parent
```powershell
Update-AzServiceGroup -Name "ContosoChild" -ParentResourceId "/providers/Microsoft.Management/serviceGroups/NewParent"
```

```output
DisplayName   : Contoso Child Group
Id            : /providers/Microsoft.Management/serviceGroups/ContosoChild
Kind          :
Name          : ContosoChild
ParentResourceId : /providers/Microsoft.Management/serviceGroups/NewParent
ProvisioningState : Succeeded
Type          : Microsoft.Management/serviceGroups
```

Moves the 'ContosoChild' service group under a different parent service group by updating the ParentResourceId property.

