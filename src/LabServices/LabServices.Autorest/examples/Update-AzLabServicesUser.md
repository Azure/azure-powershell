### Example 1: Update Lab User information.
```powershell
PS C:\> Update-AzLabServicesUser -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "User Name" -AdditionalUsageQuota $(New-TimeSpan -Hours 2)

Name
----
User Name
```

This cmdlet will add additional quota of two hours to the user.
