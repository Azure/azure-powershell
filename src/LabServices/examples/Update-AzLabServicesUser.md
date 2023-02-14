### Example 1: Update Lab User information.
```powershell
<<<<<<< HEAD
Update-AzLabServicesUser -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "User Name" -AdditionalUsageQuota $(New-TimeSpan -Hours 2)
```

```output
=======
PS C:\> Update-AzLabServicesUser -ResourceGroupName "Group Name" -LabName "Lab Name" -Name "User Name" -AdditionalUsageQuota $(New-TimeSpan -Hours 2)

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Name
----
User Name
```

This cmdlet will add additional quota of two hours to the user.
