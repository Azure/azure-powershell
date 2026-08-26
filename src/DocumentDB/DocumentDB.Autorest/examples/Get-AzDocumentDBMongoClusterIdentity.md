### Example 1: Get the managed identities assigned to a mongo cluster
```powershell
Get-AzDocumentDBMongoClusterIdentity -Name myCluster -ResourceGroupName myResourceGroup
```

```output
Type         PrincipalId TenantId
----         ----------- --------
UserAssigned
```

Get the managed identity configuration of a mongo cluster, including the identity type
and the set of user-assigned managed identities currently assigned to it.
