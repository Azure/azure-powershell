### Example 1: Get API permission
```powershell
Get-AzADAppPermission -ObjectId 18797549-86a9-4906-b2a9-54f08cd3c427
```
```output
ApiId                                Id                                   Type
-----                                --                                   ----
00000003-0000-0000-c000-000000000000 df021288-bdef-4463-88db-98f22de89214 Scope
00000003-0000-0000-c000-000000000000 5b567255-7703-4780-807c-7be8301ae99b Scope
```

Fetches all API permissions of Azure AD object 18797549-86a9-4906-b2a9-54f08cd3c427