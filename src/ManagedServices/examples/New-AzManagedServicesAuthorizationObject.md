### Example 1: Create new Azure Lighthouse Authorization object to use with Registration definition.
```powershell
PS C:\> New-AzManagedServicesAuthorizationObject -PrincipalId "3571937d-942e-4f6d-8b63-4ae855f685e1" -RoleDefinitionId "18d7d88d-d35e-4fb5-a5c3-7773c20a72d9" -PrincipalIdDisplayName "Test user"

DelegatedRoleDefinitionId PrincipalId                          PrincipalIdDisplayName RoleDefinitionId
------------------------- -----------                          ---------------------- ----------------
                          3571937d-942e-4f6d-8b63-4ae855f685e1 Test user              18d7d88d-d35e-4fb5-a5c3-7773c20a72d9
```

Creates new Azure Lighthouse authorization object to use with Registration definition.

### Example 2: Create new Azure Lighthouse Authorization object with delegatedRoleDefinitionIds.
```powershell
PS C:\> New-AzManagedServicesAuthorizationObject -PrincipalId "3571937d-942e-4f6d-8b63-4ae855f685e1" -RoleDefinitionId "18d7d88d-d35e-4fb5-a5c3-7773c20a72d9" -PrincipalIdDisplayName "Test user" -DelegatedRoleDefinitionId "b24988ac-6180-42a0-ab88-20f7382dd24c","92aaf0da-9dab-42b6-94a3-d43ce8d16293"

DelegatedRoleDefinitionId                                                    PrincipalId                          PrincipalIdDisplayName RoleDefinitionId
-------------------------                                                    -----------                          ---------------------- ----------------
{b24988ac-6180-42a0-ab88-20f7382dd24c, 92aaf0da-9dab-42b6-94a3-d43ce8d16293} 3571937d-942e-4f6d-8b63-4ae855f685e1 Test user              18d7d88d-d35e-4fb5-a5c3-7773c20a72d9
```

Creates new Azure Lighthouse authorization object with delegatedRoleDefinitionIds.