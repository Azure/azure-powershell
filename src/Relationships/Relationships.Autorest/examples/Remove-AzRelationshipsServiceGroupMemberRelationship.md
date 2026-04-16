### Example 1: Remove a ServiceGroupMember relationship
```powershell
Remove-AzRelationshipsServiceGroupMemberRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG" -Name "myMembership"
```

Removes the ServiceGroupMember relationship, detaching the resource group from the Service Group. The delete operation is asynchronous.

