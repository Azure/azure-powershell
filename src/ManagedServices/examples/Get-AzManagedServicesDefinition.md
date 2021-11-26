### Example 1: List all Azure Lighthouse registration definitions in a subscription
```powershell
PS C:\> Get-AzManagedServicesDefinition

Name                                 Type
----                                 ----
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationDefinitions
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationDefinitions
```

Lists all the Azure Lighthouse registration definitions in a given subscription in context.

### Example 2: Get Azure Lighthouse registration definition by name with selected properties
```powershell
PS C:\>  Get-AzManagedServicesDefinition -Name xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx |Format-List -Property Id, Name, Type, ManagedByTenantId, Authorization, EligibleAuthorization

Id                    : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                  : Microsoft.ManagedServices/registrationDefinitions
ManagedByTenantId     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Authorization         : {Test user}
EligibleAuthorization : {Test user}
```

Gets Azure Lighthouse registration definition by name with selected properties.

### Example 3: List all Azure Lighthouse registration definitions by scope
```powershell
PS C:\> Get-AzManagedServicesDefinition -Scope /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx | Format-List -Property Id, Name, Type, ManagedByTenantId, Authorization, EligibleAuthorization

Id                    : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                  : Microsoft.ManagedServices/registrationDefinitions
ManagedByTenantId     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Authorization         : {Test user}
EligibleAuthorization : {Test user}

Id                    : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/providers/Microsoft.ManagedServices/registrationDefinitions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Name                  : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Type                  : Microsoft.ManagedServices/registrationDefinitions
ManagedByTenantId     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
Authorization         : {}
EligibleAuthorization :
```

Lists all Azure Lighthouse registration definitions by given subscription scope.