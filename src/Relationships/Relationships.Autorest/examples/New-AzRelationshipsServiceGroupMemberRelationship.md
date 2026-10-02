### Example 1: Make a resource group a member of a Service Group
```powershell
New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG" -Name "myMembership" -SourceId "/providers/Microsoft.Management/serviceGroups/myServiceGroup"
```

Creates a ServiceGroupMember relationship that makes the resource group 'myRG' a member of the existing Service Group 'myServiceGroup'.

### Example 2: Make a subscription a member of a Service Group
```powershell
New-AzRelationshipsServiceGroupMemberRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001" -Name "subMembership" -SourceId "/providers/Microsoft.Management/serviceGroups/myServiceGroup"
```

Makes the subscription a direct member of the Service Group 'myServiceGroup'.

