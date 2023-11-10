### Example 1: List user role associated with the data product.

```powershell
 $UserRoles=Get-AzNetworkAnalyticsDataProductRoleAssignment -ResourceGroupName "ResourceGroupName" -DataProductName "pwshdp01"

 $UserRoles.RoleAssignmentResponse| select PrincipalId,PrincipalType,RoleId,Role
```

```output
PrincipalId            PrincipalType RoleId                                   Role
-----------            ------------- ------                                   ----
user1@microsoft.com    User          opinsightsdpqjydom/pwshdp01/confc9uee8dm Viewer
user2@microsoft.com    User          opinsightsdpqjydom/pwshdp01/confmq0f0zpu Viewer
```

List user role associated with the data product.