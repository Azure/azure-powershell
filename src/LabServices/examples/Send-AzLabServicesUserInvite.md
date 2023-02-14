### Example 1: Send lab invite to the user.
```powershell
<<<<<<< HEAD
Send-AzLabServicesUserInvite -ResourceGroupName "Group Name" -LabName "Lab Name" -UserName "User Name" -Text "Welcome to the lab."
=======
PS C:\> Send-AzLabServicesUserInvite -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "User Name" -Text "Welcome to the lab."

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
```

This sends an email invitation to the user with the custom text "Welcome to the lab" in the body of the email.
