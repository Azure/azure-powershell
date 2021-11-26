### Example 1: List all Azure Lighthouse registration assignments in a subscription.
```powershell
PS C:\> Get-AzManagedServicesAssignment

Name                                 Type
----                                 ----
8e3e94f0-c85f-4788-8dff-c138b3fecc82 Microsoft.ManagedServices/registrationAssignments
7b261470-e3d4-4d89-bc95-ad90449f159e Microsoft.ManagedServices/registrationAssignments
0bcab95b-ad60-4c48-9414-38987bc63ef5 Microsoft.ManagedServices/registrationAssignments
```

Lists all the Azure Lighthouse registration assignments in a given subscription in context.

### Example 2: Get Azure Lighthouse registration assignment by name with selected properties.
```powershell
PS C:\> Get-AzManagedServicesAssignment -Name 8e3e94f0-c85f-4788-8dff-c138b3fecc82 | Format-List -Property Id, Name, Type, RegistrationDefinitionId, ProvisioningState

Id                       : /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationAssignments/8e3e94f0-c85f-4788-8dff-c138b3fecc82
Name                     : 8e3e94f0-c85f-4788-8dff-c138b3fecc82
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationDefinitions/093a9d0e-7ec5-4436-a678-d88115036134
ProvisioningState        : Succeeded
```

Gets Azure Lighthouse registration assignment by name with selected properties.

### Example 3: List all Azure Lighthouse registration assignments by scope
```powershell
PS C:\>  Get-AzManagedServicesAssignment -Scope /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8 | Format-List -Property Id, Name, Type, RegistrationDefinitionId, ProvisioningState

Id                       : /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationAssignments/8e3e94f0-c85f-4788-8dff-c138b3fecc82
Name                     : 8e3e94f0-c85f-4788-8dff-c138b3fecc82
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationDefinitions/0f8a5cea-02b5-4952-9596-5661db36a24c
ProvisioningState        : Succeeded

Id                       : /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationAssignments/7b261470-e3d4-4d89-bc95-ad90449f159e
Name                     : 7b261470-e3d4-4d89-bc95-ad90449f159e
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationDefinitions/6f5bc359-c729-4b12-8385-55bb987901ac
ProvisioningState        : Succeeded

Id                       : /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationAssignments/0bcab95b-ad60-4c48-9414-38987bc63ef5
Name                     : 0bcab95b-ad60-4c48-9414-38987bc63ef5
Type                     : Microsoft.ManagedServices/registrationAssignments
RegistrationDefinitionId : /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationDefinitions/093a9d0e-7ec5-4436-a678-d88115036134
ProvisioningState        : Succeeded
```

Lists all the Azure Lighthouse registration assignments in a given subscription or resource group scope.