### Example 1: Delete a MongoDB Atlas project (preview with -WhatIf)
```powershell
Remove-AzMongoDBProject -ResourceGroupName "myResourceGroup" -OrganizationName "myOrganization" -Name "myProject" -WhatIf
```

```output
What if: Performing the operation "Remove-AzMongoDBProject_Delete" on target "myProject".
```

Previews the delete operation for a MongoDB Atlas project without executing it. Note: project deletion is not yet supported by the partner backend; use -WhatIf to validate parameters.
