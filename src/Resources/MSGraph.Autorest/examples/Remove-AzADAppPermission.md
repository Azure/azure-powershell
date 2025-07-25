### Example 1: Remove API Permission
```powershell
Remove-AzADAppPermission -ObjectId 9cc74d5e-1162-4b90-8696-65f3d6a3f7d0 -PermissionId 5f8c59db-677d-491f-a6b8-5f174b11ec1d
```

Remove delegated permission "Group.Read.All" of Microsoft Graph API from AD Application (9cc74d5e-1162-4b90-8696-65f3d6a3f7d0)