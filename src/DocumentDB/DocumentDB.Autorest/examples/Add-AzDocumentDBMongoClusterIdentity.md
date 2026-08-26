### Example 1: Assign a user-assigned managed identity to a mongo cluster
```powershell
$identityId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myIdentity'
Add-AzDocumentDBMongoClusterIdentity -Name myCluster -ResourceGroupName myResourceGroup -UserAssignedIdentity $identityId
```

```output
Type         PrincipalId TenantId
----         ----------- --------
UserAssigned
```

Assign a user-assigned managed identity to a mongo cluster. The supplied identity is
merged with any identities already assigned to the cluster. The `-UserAssigned` alias
can be used in place of `-UserAssignedIdentity`.
