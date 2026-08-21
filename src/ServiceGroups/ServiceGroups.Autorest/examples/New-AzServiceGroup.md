### Example 1: Create a service group under the root
```powershell
New-AzServiceGroup -Name "Contoso" -DisplayName "Contoso Group" -ParentResourceId "/providers/Microsoft.Management/serviceGroups/00000000-0000-0000-0000-000000000000"
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

Creates a new service group named 'Contoso' under the root service group (tenant ID). The groupId is a unique identifier that cannot be changed after creation. The ParentResourceId must be the full Azure Resource Manager ID of the parent service group.

### Example 2: Create a child service group under an existing parent
```powershell
New-AzServiceGroup -Name "ContosoChild" -DisplayName "Contoso Child Group" -ParentResourceId "/providers/Microsoft.Management/serviceGroups/Contoso"
```

```output
DisplayName   : Contoso Child Group
Id            : /providers/Microsoft.Management/serviceGroups/ContosoChild
Kind          :
Name          : ContosoChild
ParentResourceId : /providers/Microsoft.Management/serviceGroups/Contoso
ProvisioningState : Succeeded
Type          : Microsoft.Management/serviceGroups
```

Creates a child service group nested under the 'Contoso' parent service group. Service groups support hierarchical organization where access controls applied to the parent are inherited by child service groups.

