### Example 1: Creates new Azure Lighthouse eligible authorization object to use with Registration definition.
```powershell
PS C:\> New-AzManagedServicesEligibleAuthorizationObject -PrincipalId "3571937d-942e-4f6d-8b63-4ae855f685e1" -PrincipalIdDisplayName "Test user" -RoleDefinitionId "9980e02c-c2be-4d73-94e8-173b1dc7cf3c"

PrincipalId                          PrincipalIdDisplayName RoleDefinitionId
-----------                          ---------------------- ----------------
3571937d-942e-4f6d-8b63-4ae855f685e1 Test user              9980e02c-c2be-4d73-94e8-173b1dc7cf3c
```

Creates new Azure Lighthouse eligible authorization object to use with Registration definition.

### Example 2: Create new Azure Lighthouse eligible authorization with JustInTime settings.
```powershell
PS C:\> $approver = New-AzManagedServicesEligibleApproverObject -PrincipalId "3571937d-942e-4f6d-8b63-4ae855f685e1" -PrincipalIdDisplayName "Approver group"

PS C:\> $eligibleAuth = New-AzManagedServicesEligibleAuthorizationObject -PrincipalId "3571937d-942e-4f6d-8b63-4ae855f685e1" -PrincipalIdDisplayName "Test user" -RoleDefinitionId "9980e02c-c2be-4d73-94e8-173b1dc7cf3c" -JustInTimeAccessPolicyManagedByTenantApprover $approver -JustInTimeAccessPolicyMultiFactorAuthProvider Azure -JustInTimeAccessPolicyMaximumActivationDuration 0:30

PS C:\> $eligibleAuth | Format-List -Property PrinciPalId, PrincipalIdDisplayName, RoleDefinitionId, JustInTimeAccessPolicyManagedByTenantApprover, JustInTimeAccessPolicyMultiFactorAuthProvider, JustInTimeAccessPolicyMaximumActivationDuration

PrincipalId                                     : 3571937d-942e-4f6d-8b63-4ae855f685e1
PrincipalIdDisplayName                          : Test user
RoleDefinitionId                                : 9980e02c-c2be-4d73-94e8-173b1dc7cf3c
JustInTimeAccessPolicyManagedByTenantApprover   : {Approver group}
JustInTimeAccessPolicyMultiFactorAuthProvider   : Azure
JustInTimeAccessPolicyMaximumActivationDuration : 00:30:00
```

Creates new Azure Lighthouse eligible authorization object with JustInTime (JIT) settings.