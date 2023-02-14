### Example 1: List all Azure Lighthouse registration assignments in a subscription
```powershell
<<<<<<< HEAD
Get-AzManagedServicesAssignment
```

```output
=======
PS C:\> Get-AzManagedServicesAssignment

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name                                 Type
----                                 ----
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationAssignments
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationAssignments
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationAssignments
```

Lists all the Azure Lighthouse registration assignments in a given subscription in context.

### Example 2: Get Azure Lighthouse registration assignment by name with selected properties
```powershell
<<<<<<< HEAD
Get-AzManagedServicesAssignment -Name xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx | Format-List -Property Id, Name, Type, RegistrationDefinitionId, ProvisioningState
```

```output
=======
PS C:\> Get-AzManagedServicesAssignment -Name xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx | Format-List -Property Id, Name, Type, RegistrationDefinitionId, ProvisioningState

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationAssignments/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState        : Succeeded
```

Gets Azure Lighthouse registration assignment by name with selected properties.

### Example 3: List all Azure Lighthouse registration assignments by scope
```powershell
<<<<<<< HEAD
Get-AzManagedServicesAssignment -Scope /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx | Format-List -Property Id, Name, Type, RegistrationDefinitionId, ProvisioningState
```

```output
=======
PS C:\>  Get-AzManagedServicesAssignment -Scope /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx | Format-List -Property Id, Name, Type, RegistrationDefinitionId, ProvisioningState

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationAssignments/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState        : Succeeded

Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationAssignments/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState        : Succeeded

Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationAssignments/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState        : Succeeded
```

Lists all the Azure Lighthouse registration assignments in a given subscription or resource group scope.