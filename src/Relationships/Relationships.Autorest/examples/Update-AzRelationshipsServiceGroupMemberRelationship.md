### Example 1: Update a ServiceGroupMember relationship target
```powershell
Update-AzRelationshipsServiceGroupMemberRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG" -Name "myMembership" -TargetId "/providers/Microsoft.Management/serviceGroups/newServiceGroup"
```

Updates the ServiceGroupMember relationship to point to a different Service Group.

