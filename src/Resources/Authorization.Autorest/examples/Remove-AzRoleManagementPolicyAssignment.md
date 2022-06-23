### Example 1: Delete a role management policy assignment
```powershell
$scope = "/subscriptions/38ab2ccc-3747-4567-b36b-9478f5602f0d/"
Remove-AzRoleManagementPolicyAssignment -Scope $scope -Name "588b80cc-f50c-4616-acc9-0003872624db_00493d72-78f6-4148-b6c5-d3ce8e4799dd"
```

```output
Remove-AzRoleManagementPolicyAssignment_Delete: The requested resource does not support http method 'DELETE'.
```

This operation is currently not supported

