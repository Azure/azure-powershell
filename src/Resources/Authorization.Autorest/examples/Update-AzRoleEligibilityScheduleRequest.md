### Example 1: Update a new role eligibile schedule request as Admin
```powershell
$guid = "12f8978c-5d8d-4fbf-b4b6-2f43eeb43eca"
$startTime = Get-Date -Format o 
$scope = "/subscriptions/11111111-2222-3333-4444-123456789101/"
Update-AzRoleEligibilityScheduleRequest -Name $guid -Scope $scope -ExpirationDuration PT1H -ExpirationType AfterDuration -PrincipalId 5a4bdd72-ab3e-4d8e-ab0f-8dd8917481a2 -RequestType AdminAssign -RoleDefinitionId subscriptions/11111111-2222-3333-4444-123456789101/providers/Microsoft.Authorization/roleDefinitions/acdd72a7-3385-48ef-bd42-f606fba81ae7 -ScheduleInfoStartDateTime $startTime
```

```output
Name                                 Type                                                    Scope                                               RoleDefinitionId
----                                 ----                                                    -----                                               ----------------                                                                 
12f8978c-5d8d-4fbf-b4b6-2f43eeb43eca Microsoft.Authorization/roleEligibilityScheduleRequests /subscriptions/11111111-2222-3333-4444-123456789101 /subscriptions/11111111-2222-3333-4444-123456789101/providers/Microsoft.Authori… 
```

Updates a request to provision an eligible assignment of `roleDefinition` on the `scope` for the specified `principal`
