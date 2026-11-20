### Example 1: Create a Microsoft Entra group administrator
```powershell
New-AzHorizonDbMicrosoftEntraAdministrator -ResourceGroupName 'example-resource-group' -ClusterName 'example-cluster' -ObjectId '11111111-1111-1111-1111-111111111111' -PrincipalName 'database.administrators@contoso.com' -PrincipalType 'Group' -TenantId '22222222-2222-2222-2222-222222222222' | Format-List -Property Name, PrincipalName, PrincipalType, TenantId, ProvisioningState
```

```output
Name              : 11111111-1111-1111-1111-111111111111
PrincipalName     : database.administrators@contoso.com
PrincipalType     : Group
TenantId          : 22222222-2222-2222-2222-222222222222
ProvisioningState : Provisioning
```

Sample output from the HTTP 200 response.
Values are illustrative REST response data, not a live execution result.
