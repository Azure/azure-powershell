### Example 1: List all Azure Lighthouse registration definitions in a subscription.
```powershell
PS C:\> Get-AzManagedServicesDefinition

Name                                 Type
----                                 ----
093a9d0e-7ec5-4436-a678-d88115036134 Microsoft.ManagedServices/registrationDefinitions
0f8a5cea-02b5-4952-9596-5661db36a24c Microsoft.ManagedServices/registrationDefinitions
```

Lists all the Azure Lighthouse registration definitions in a given subscription in context.

### Example 2: Get Azure Lighthouse registration definition by name with selected properties.
```powershell
PS C:\>  Get-AzManagedServicesDefinition -Name 093a9d0e-7ec5-4436-a678-d88115036134 |Format-List -Property Id, Name, Type, ManagedByTenantId, Authorization, EligibleAuthorization

Id                    : /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationDefinitions/093a9d0e-7ec5-4436-a678-d88115036134
Name                  : 093a9d0e-7ec5-4436-a678-d88115036134
Type                  : Microsoft.ManagedServices/registrationDefinitions
ManagedByTenantId     : fbcdd0f3-dc82-4cee-bcde-7311d24e9bf6
Authorization         : {Test user}
EligibleAuthorization : {Test user}
```

Gets Azure Lighthouse registration definition by name with selected properties.

### Example 3: List all Azure Lighthouse registration definitions by scope.
```powershell
PS C:\> Get-AzManagedServicesDefinition -Scope /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8 | Format-List -Property Id, Name, Type, ManagedByTenantId, Authorization, EligibleAuthorization

Id                    : /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationDefinitions/093a9d0e-7ec5-4436-a678-d88115036134
Name                  : 093a9d0e-7ec5-4436-a678-d88115036134
Type                  : Microsoft.ManagedServices/registrationDefinitions
ManagedByTenantId     : fbcdd0f3-dc82-4cee-bcde-7301d24e9bf6
Authorization         : {Test user}
EligibleAuthorization : {Test user}

Id                    : /subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8/providers/Microsoft.ManagedServices/registrationDefinitions/0f8a5cea-02b5-4952-9596-5661db36a24c
Name                  : 0f8a5cea-02b5-4952-9596-5661db36a24c
Type                  : Microsoft.ManagedServices/registrationDefinitions
ManagedByTenantId     : 72f988bf-86f1-41af-91ab-2d7cd011db47
Authorization         : {}
EligibleAuthorization :
```

Lists all Azure Lighthouse registration definitions by given subscription scope.