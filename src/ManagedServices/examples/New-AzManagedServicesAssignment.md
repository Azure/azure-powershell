### Example 1: Create new Azure Lighthouse registration assignment at subscription scope.
```powershell
PS C:\> New-AzManagedServicesAssignment -Name 13e437f5-393d-4041-840f-25b26b7a1efc -Scope "/subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8" -RegistrationDefinitionId  "/subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationDefinitions/158d82c0-d6c4-441f-a3a2-d8c230badd2c"

Name                                 Type
----                                 ----
13e437f5-393d-4041-840f-25b26b7a1efc Microsoft.ManagedServices/registrationAssignments
```

Creates new Azure Lighthouse registration assignment at subscription scope with the registration definition.

### Example 2: Create new Azure Lighthouse registration assignment at resource group scope.
```powershell
PS C:\> New-AzManagedServicesAssignment -Name ca63aca5-31a4-4120-88a1-526088173628 -Scope "/subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/resourceGroups/testgroup" -RegistrationDefinitionId  "/subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationDefinitions/158d82c0-d6c4-441f-a3a2-d8c230badd2c"

Name                                 Type
----                                 ----
ca63aca5-31a4-4120-88a1-526088173628 Microsoft.ManagedServices/registrationAssignments
```

Creates new Azure Lighthouse registration assignment at resource group scope with the registration definition.