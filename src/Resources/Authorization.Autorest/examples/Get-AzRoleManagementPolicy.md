### Example 1: List all role management policies under a resource scope
```powershell
PS C:\> $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
PS C:\> Get-AzRoleManagementPolicy -Scope $scope

Name                                 Type                                           Scope
----                                 ----                                           -----
588b80cc-f50c-4616-acc9-0003872624db Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
8dbbf139-4d46-4ad4-a56b-004156c117d2 Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
1c8bc687-402c-4e62-b38b-009d6fc244d3 Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
```

Returns all `roleManagementPolicies` for the `scope`

### Example 2: Get a role management policy by Scope and Name
```powershell
PS C:\> $scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
PS C:\> $name = "33b520ea-3544-4abc-8565-3588deb8e68e"
PS C:\> Get-AzRoleManagementPolicy -Scope $scope -Name $name

Name                                 Type                                           Scope
----                                 ----                                           -----
33b520ea-3544-4abc-8565-3588deb8e68e Microsoft.Authorization/roleManagementPolicies /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
```

Use the `Id` property to get `scope` and `name`