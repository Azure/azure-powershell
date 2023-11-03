### Example 1: Assign user role to the data product.

```powershell
 Add-AzNetworkAnalyticsDataProductUserRole -DataProductName "dataProductName" -ResourceGroupName "ResourceGroupName" -PrincipalId user@microsoft.com -Role Reader -RoleId " " -UserName "User Name" -PrincipalType user  -DataTypeScope "dataProductName"
```

```output
PrincipalId            PrincipalType Role   RoleAssignmentId RoleId UserName
-----------            ------------- ----   ---------------- ------ --------
user@microsoft.com     user          Reader confmq0f0zpu            User Name
```

Assign user role to the data product.
