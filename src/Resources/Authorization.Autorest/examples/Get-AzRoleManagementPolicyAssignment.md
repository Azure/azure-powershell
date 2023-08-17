### Example 1: List all role management policy assignments under a resource scope
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
Get-AzRoleManagementPolicyAssignment -Scope $scope
```

```output
Name                                                                      Type                                                   Scope                                               RoleDefinitionId
----                                                                      ----                                                   -----                                               ----------------
588b80cc-f50c-4616-acc9-0003872624db_00493d72-78f6-4148-b6c5-d3ce8e4799dd Microsoft.Authorization/roleManagementPolicyAssignment /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f… 
8dbbf139-4d46-4ad4-a56b-004156c117d2_056cd41c-7e88-42e1-933e-88ba6a50c9c3 Microsoft.Authorization/roleManagementPolicyAssignment /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f… 
1c8bc687-402c-4e62-b38b-009d6fc244d3_b97fb8bc-a8b2-4522-a38b-dd33c7e65ead Microsoft.Authorization/roleManagementPolicyAssignment /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f… 
5d582357-e60a-4322-a299-00ab23713a07_70bbe301-9835-447d-afdd-19eb3167307c Microsoft.Authorization/roleManagementPolicyAssignment /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f… 
```

Returns all `roleManagementPolicyAssignment` for the `scope`

### Example 2: Get a role management policy assignment by Scope and Name
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
$name = "588b80cc-f50c-4616-acc9-0003872624db_00493d72-78f6-4148-b6c5-d3ce8e4799dd"
Get-AzRoleManagementPolicyAssignment -Scope $scope -Name $name
```

```output
Name                                                                      Type                                                   Scope                                               RoleDefinitionId
----                                                                      ----                                                   -----                                               ----------------
588b80cc-f50c-4616-acc9-0003872624db_00493d72-78f6-4148-b6c5-d3ce8e4799dd Microsoft.Authorization/roleManagementPolicyAssignment /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f…
```

Use the `Id` property to get `scope` and `name`

