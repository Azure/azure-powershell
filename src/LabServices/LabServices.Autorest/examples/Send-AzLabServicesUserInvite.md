### Example 1: Send lab invite to the user.
```powershell
Send-AzLabServicesUserInvite -ResourceGroupName "Group Name" -LabName "Lab Name" -UserName "User Name" -Text "Welcome to the lab."
```

This sends an email invitation to the user with the custom text "Welcome to the lab" in the body of the email.
