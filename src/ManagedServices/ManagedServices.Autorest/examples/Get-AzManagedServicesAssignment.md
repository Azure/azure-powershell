### Example 1: List all Azure Lighthouse registration assignments in a subscription
```powershell
PS C:\> Get-AzManagedServicesAssignment

Name                                 Type
----                                 ----
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationAssignments
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationAssignments
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationAssignments
```

Lists all the Azure Lighthouse registration assignments in a given subscription in context.

### Example 2: Get Azure Lighthouse registration assignment by name with selected properties
```powershell
PS C:\> Get-AzManagedServicesAssignment -Name xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx | Format-List -Property Id, Name, Type, RegistrationDefinitionId, ProvisioningState

Id                       : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationAssignments/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
ProvisioningState        : Succeeded
```

Gets Azure Lighthouse registration assignment by name with selected properties.

### Example 3: List all Azure Lighthouse registration assignments by scope
```powershell
PS C:\>  Get-AzManagedServicesAssignment -Scope /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx | Format-List -Property Id, Name, Type, RegistrationDefinitionId, ProvisioningState

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