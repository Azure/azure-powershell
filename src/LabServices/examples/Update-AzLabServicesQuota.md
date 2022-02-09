### Example 1: Update-AzLabServicesQuota
```powershell
PS C:\> Update-AzLabServicesQuota -ResourceGroupName "Group Name" -LabName "Lab Name" -LabQuota $(New-TimeSpan -Hours 3)

Location Name
-------- ----
westus2  Lab Name
```

This example updates the lab adding an additional 3 hours to the lab quota.
