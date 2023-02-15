### Example 1: create linker's auth info with user assigned identity type
```powershell
New-AzServiceLinkerUserAssignedIdentityAuthInfoObject -ClientId 00000000-0000-0000-0000-000000000000 -SubscriptionId 00000000-0000-0000-0000-000000000000
```

```output
AuthType             ClientId                             SubscriptionId
--------             --------                             --------------
userAssignedIdentity 00000000-0000-0000-0000-000000000000 00000000-0000-0000-0000-0000… 
```

create linker's auth info with user assigned identity type
