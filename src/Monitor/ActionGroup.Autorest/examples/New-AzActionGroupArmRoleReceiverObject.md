### Example 1: create action group arm role receiver
```powershell
New-AzActionGroupArmRoleReceiverObject -Name "sample arm role" -RoleId "8e3af657-a8ff-443c-a75c-2fe8c4bcb635" -UseCommonAlertSchema $true
```

```output
Name            RoleId                               UseCommonAlertSchema
----            ------                               --------------------
sample arm role 8e3af657-a8ff-443c-a75c-2fe8c4bcb635                 True
```

This command creates action group arm role receiver object.

