### Example 1: List all role assignment schedule requests for a resource
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d"
Get-AzRoleEligibilityScheduleRequest -Scope $scope 
```

```output
Name                                 Type                                                   Scope
----                                 ----                                                   -----
01b86d0b-2d7d-4ee2-bedb-68417ca9cc6a Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
06425dd7-102c-42c2-90c4-b5c630447356 Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
0988b71a-f813-467b-abc0-cef007eddbb5 Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
0cbb19d3-3804-404a-b74a-2f577f8aecbc Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d
```

Returns all `roleEligibilityScheduleRequests` for the `scope`.

### Example 2: List all My role assignment schedule requests for a resource
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d"
Get-AzRoleEligibilityScheduleRequest -Scope $scope -Filter "asTarget()"
```

```output
Name                                 Type                                                   Scope                                                                       RoleDefinitionId
----                                 ----                                                   -----                                                                       ----------------
2cc018c2-27f8-4730-a0bc-b6a8fcee3e70 Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…
31910719-4f82-443c-9e7a-6bfe4b918e0c Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…
4cd7e26b-8eca-425c-969d-ec708c88bf18 Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…

```

Returns all `roleEligibilityScheduleRequests` for the `scope` which are assigned to the calling user.

### Example 3: List all role assignment schedule requests for a resource where calling user is an approver
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d"
Get-AzRoleEligibilityScheduleRequest -Scope $scope -Filter "asApprover()"
```

```output
Name                                 Type                                                   Scope                                                                       RoleDefinitionId
----                                 ----                                                   -----                                                                       ----------------
2cc018c2-27f8-4730-a0bc-b6a8fcee3e70 Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…
31910719-4f82-443c-9e7a-6bfe4b918e0c Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…
4cd7e26b-8eca-425c-969d-ec708c88bf18 Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d                         /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/prov…

```

Returns all `roleEligibilitySchedules` for the `scope` on which the calling user is an approver.

### Example 4: Get a role assignment schedule request by scope and name

```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d"
Get-AzRoleEligibilityScheduleRequest -Scope $scope -Name "2cc018c2-27f8-4730-a0bc-b6a8fcee3e70"
```

```output
Name                                 Type                                                   Scope                                               RoleDefinitionId
----                                 ----                                                   -----                                               ----------------
2cc018c2-27f8-4730-a0bc-b6a8fcee3e70 Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d /subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/providers/Microsoft.Authoriz… 
```

Use the `Id` property to get `scope` and `name`

