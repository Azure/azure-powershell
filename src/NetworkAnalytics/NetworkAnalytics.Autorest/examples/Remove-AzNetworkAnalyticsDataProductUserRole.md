### Example 1: Remove user role from the data product.

```powershell
 Remove-AzNetworkAnalyticsDataProductUserRole -DataProductName "dataProductName" -ResourceGroupName "resourceGroupName" -Role Reader -PrincipalType user -RoleId "opinsightsdpqjydom/dataProductName/confmq0f0zpu" -PrincipalId "user@microsoft.com" -DataTypeScope "dataProductName" -RoleAssignmentId "confmq0f0zpu" -UserName "User Name"
```

 Remove user role from the data product.
