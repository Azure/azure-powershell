### Example 1: Remove a user-assigned managed identity from a mongo cluster
```powershell
$identityId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/myResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/myIdentity'
Remove-AzDocumentDBMongoClusterIdentity -Name myCluster -ResourceGroupName myResourceGroup -UserAssignedIdentity $identityId
```

```output
Type PrincipalId TenantId
---- ----------- --------
None
```

Remove a user-assigned managed identity from a mongo cluster. Only the supplied
identity is removed; any other identities already assigned to the cluster are
preserved. The `-UserAssigned` alias can be used in place of `-UserAssignedIdentity`.
