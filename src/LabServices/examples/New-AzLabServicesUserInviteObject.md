### Example 1: Create the user invite body.
```powershell
PS C:\> $inviteBody = New-AzLabServicesUserInviteObject -Text "Text Body"
PS C:\> Send-AzLabServicesUserInvite -LabName "Lab Name" -ResourceGroupName "Group Name" -UserName "User Name" -Body $inviteBody

```

This cmdlet creates the minimum information to invite users using the body parameter.
