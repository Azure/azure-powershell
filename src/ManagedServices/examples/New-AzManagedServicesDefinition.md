### Example 1: Create new Azure Lighthouse registration definition object with permanent authorization
```powershell
$permantAuth = New-AzManagedServicesAuthorizationObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -RoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Test user" -DelegatedRoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx","xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"

New-AzManagedServicesDefinition -Name xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx -RegistrationDefinitionName "Test definition" -ManagedByTenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Authorization $permantAuth -Description "Test definition desc" -Scope "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" 
```

```output
Name                                 Type
----                                 ----
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx Microsoft.ManagedServices/registrationDefinitions
```

Creates new Azure Lighthouse registration definition object with permanent authorization.

### Example 2: Create new Azure Lighthouse registration definition object with both permanent and eligible authorizations
```powershell
$approver = New-AzManagedServicesEligibleApproverObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Approver group"

$eligibleAuth = New-AzManagedServicesEligibleAuthorizationObject -PrincipalId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -PrincipalIdDisplayName "Test user" -RoleDefinitionId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -JustInTimeAccessPolicyManagedByTenantApprover $approver -JustInTimeAccessPolicyMultiFactorAuthProvider Azure -JustInTimeAccessPolicyMaximumActivationDuration 0:30

New-AzManagedServicesDefinition -Name "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -RegistrationDefinitionName "Test definition" -ManagedByTenantId "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx" -Authorization $permantAuth -EligibleAuthorization $eligibleAuth -Description "Test definition desc" -Scope "/subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx"
```

```output
Name                                 Type
----                                 ----
xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxMicrosoft.ManagedServices/registrationDefinitions
```

Creates new Azure Lighthouse registration definition object with both permanent and eligible authorizations.