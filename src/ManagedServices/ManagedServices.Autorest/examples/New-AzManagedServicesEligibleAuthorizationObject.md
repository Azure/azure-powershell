### Example 1: Creates new Azure Lighthouse eligible authorization object to use with Registration definition
```powershell
New-AzManagedServicesEligibleAuthorizationObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Test user" -RoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```

```output
PrincipalId                          PrincipalIdDisplayName RoleDefinitionId
-----------                          ---------------------- ----------------
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Test user              xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
```

Creates new Azure Lighthouse eligible authorization object to use with Registration definition.

### Example 2: Create new Azure Lighthouse eligible authorization with JustInTime settings
```powershell
$approver = New-AzManagedServicesEligibleApproverObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Approver group"

$eligibleAuth = New-AzManagedServicesEligibleAuthorizationObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Test user" -RoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -JustInTimeAccessPolicyManagedByTenantApprover $approver -JustInTimeAccessPolicyMultiFactorAuthProvider Azure -JustInTimeAccessPolicyMaximumActivationDuration 0:30

$eligibleAuth | Format-List -Property PrinciPalId, PrincipalIdDisplayName, RoleDefinitionId, JustInTimeAccessPolicyManagedByTenantApprover, JustInTimeAccessPolicyMultiFactorAuthProvider, JustInTimeAccessPolicyMaximumActivationDuration
```

```output
PrincipalId                                     : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
PrincipalIdDisplayName                          : Test user
RoleDefinitionId                                : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx
JustInTimeAccessPolicyManagedByTenantApprover   : {Approver group}
JustInTimeAccessPolicyMultiFactorAuthProvider   : Azure
JustInTimeAccessPolicyMaximumActivationDuration : 00:30:00
```

Creates new Azure Lighthouse eligible authorization object with JustInTime (JIT) settings.