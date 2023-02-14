### Example 1: Update-AzLabServicesQuota
```powershell
<<<<<<< HEAD
Update-AzLabServicesQuota -ResourceGroupName "Group Name" -LabName "Lab Name" -LabQuota $(New-TimeSpan -Hours 3)
```

```output
=======
PS C:\> Update-AzLabServicesQuota -ResourceGroupName "Group Name" -LabName "Lab Name" -LabQuota $(New-TimeSpan -Hours 3)

>>>>>>> 97176e9029ae7684a4ab56b6bec6966b134d4f91
Location Name
-------- ----
westus2  Lab Name
```

This example updates the lab adding an additional 3 hours to the lab quota.
