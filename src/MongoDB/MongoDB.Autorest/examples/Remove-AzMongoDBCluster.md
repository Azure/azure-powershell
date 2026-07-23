### Example 1: Delete a MongoDB Atlas cluster (preview with -WhatIf)
```powershell
Remove-AzMongoDBCluster -ResourceGroupName "myResourceGroup" -OrganizationName "myOrganization" -ProjectName "myProject" -Name "myCluster" -WhatIf
```

```output
What if: Performing the operation "Remove-AzMongoDBCluster_Delete" on target "myCluster".
```

Previews the delete operation for a MongoDB Atlas cluster without executing it. Note: cluster deletion is not yet supported by the partner backend; use -WhatIf to validate parameters.
