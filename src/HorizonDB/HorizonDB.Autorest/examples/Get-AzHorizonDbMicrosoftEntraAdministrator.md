### Example 1: List Microsoft Entra administrators
```powershell
Get-AzHorizonDbMicrosoftEntraAdministrator -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' | Format-List -Property Name, PrincipalName, PrincipalType, TenantId, ProvisioningState
```

```output
Name              : 33333333-3333-3333-3333-333333333333
PrincipalName     : admin@contoso.com
PrincipalType     : User
TenantId          : 22222222-2222-2222-2222-222222222222
ProvisioningState : Succeeded

Name              : 44444444-4444-4444-4444-444444444444
PrincipalName     : horizondb-automation@contoso.com
PrincipalType     : ServicePrincipal
TenantId          : 22222222-2222-2222-2222-222222222222
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.

### Example 2: Get a Microsoft Entra administrator
```powershell
Get-AzHorizonDbMicrosoftEntraAdministrator -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -ObjectId '11111111-1111-1111-1111-111111111111' | Format-List -Property Name, PrincipalName, PrincipalType, TenantId, ProvisioningState
```

```output
Name              : 11111111-1111-1111-1111-111111111111
PrincipalName     : Database Administrators
PrincipalType     : Group
TenantId          : 22222222-2222-2222-2222-222222222222
ProvisioningState : Succeeded
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
