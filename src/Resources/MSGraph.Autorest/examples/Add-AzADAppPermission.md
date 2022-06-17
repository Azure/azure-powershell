### Example 1: Add API Permission
```powershell
Add-AzADAppPermission -ObjectId 9cc74d5e-1162-4b90-8696-65f3d6a3f7d0 -ApiId 00000003-0000-0000-c000-000000000000 -PermissionId 5f8c59db-677d-491f-a6b8-5f174b11ec1d
```

Add delegated permission "Group.Read.All" of Microsoft Graph API to AD Application (9cc74d5e-1162-4b90-8696-65f3d6a3f7d0)


### Example 2: Add API Permission
```powershell
Add-AzADAppPermission -ObjectId 9cc74d5e-1162-4b90-8696-65f3d6a3f7d0 -ApiId 00000003-0000-0000-c000-000000000000 -PermissionId 1138cb37-bd11-4084-a2b7-9f71582aeddb -Type Role
```

Add application permission "Device.ReadWrite.All" of Microsoft Graph API to AD Application (9cc74d5e-1162-4b90-8696-65f3d6a3f7d0)