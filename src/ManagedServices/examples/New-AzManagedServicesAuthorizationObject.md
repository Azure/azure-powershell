### Example 1: Create new Azure Lighthouse Authorization object to use with Registration definition
```powershell
New-AzManagedServicesAuthorizationObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -RoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Test user"
```

```output
DelegatedRoleDefinitionId PrincipalId                          PrincipalIdDisplayName RoleDefinitionId
------------------------- -----------                          ---------------------- ----------------
                          xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Test user              xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

Creates new Azure Lighthouse authorization object to use with Registration definition.

### Example 2: Create new Azure Lighthouse Authorization object with delegatedRoleDefinitionIds
```powershell
New-AzManagedServicesAuthorizationObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -RoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Test user" -DelegatedRoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```

```output
DelegatedRoleDefinitionId                                                    PrincipalId                          PrincipalIdDisplayName RoleDefinitionId
-------------------------                                                    -----------                          ---------------------- ----------------
{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx, xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx} xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Test user              xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

Creates new Azure Lighthouse authorization object with delegatedRoleDefinitionIds.