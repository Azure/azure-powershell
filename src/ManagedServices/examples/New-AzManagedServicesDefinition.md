### Example 1: Create new Azure Lighthouse registration definition object with permanent authorization.
```powershell
PS C:\> $permantAuth = New-AzManagedServicesAuthorizationObject -PrincipalId "3571937d-942e-4f6d-8b63-4ae855f685e1" -RoleDefinitionId "18d7d88d-d35e-4fb5-a5c3-7773c20a72d9" -PrincipalIdDisplayName "Test user" -DelegatedRoleDefinitionId "b24988ac-6180-42a0-ab88-20f7382dd24c","92aaf0da-9dab-42b6-94a3-d43ce8d16293"

PS C:\> New-AzManagedServicesDefinition -Name fbe677f9-abd4-493f-a8bd-61b219a295c3 -RegistrationDefinitionName "Test definition" -ManagedByTenantId "fbcdd0f3-dc82-4cee-bcde-7311d24e9bf6" -Authorization $permantAuth -Description "Test definition desc" -Scope "/subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8" 

Name                                 Type
----                                 ----
fbe677f9-abd4-493f-a8bd-61b219a295c3 Microsoft.ManagedServices/registrationDefinitions
```

Creates new Azure Lighthouse registration definition object with permanent authorization.

### Example 2: Create new Azure Lighthouse registration definition object with both permanent and eligible authorizations.
```powershell
PS C:\> $approver = New-AzManagedServicesEligibleApproverObject -PrincipalId "3571937d-942e-4f6d-8b63-4ae855f685e1" -PrincipalIdDisplayName "Approver group"

PS C:\> $eligibleAuth = New-AzManagedServicesEligibleAuthorizationObject -PrincipalId "3571937d-942e-4f6d-8b63-4ae855f685e1" -PrincipalIdDisplayName "Test user" -RoleDefinitionId "9980e02c-c2be-4d73-94e8-173b1dc7cf3c" -JustInTimeAccessPolicyManagedByTenantApprover $approver -JustInTimeAccessPolicyMultiFactorAuthProvider Azure -JustInTimeAccessPolicyMaximumActivationDuration 0:30

PS C:\> New-AzManagedServicesDefinition -Name 158d82c0-d6c4-441f-a3a2-d8c230badd2c -RegistrationDefinitionName "Test definition" -ManagedByTenantId "fbcdd0f3-dc82-4cee-bcde-7311d24e9bf6" -Authorization $permantAuth -EligibleAuthorization $eligibleAuth -Description "Test definition desc" -Scope "/subscriptions/24ab6047-da91-48c0-88e5-20a8c6daafc8"

Name                                 Type
----                                 ----
158d82c0-d6c4-441f-a3a2-d8c230badd2c Microsoft.ManagedServices/registrationDefinitions
```

Creates new Azure Lighthouse registration definition object with both permanent and eligible authorizations.