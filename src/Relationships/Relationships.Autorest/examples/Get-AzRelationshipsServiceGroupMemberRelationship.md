### Example 1: Get a ServiceGroupMember relationship by name
```powershell
Get-AzRelationshipsServiceGroupMemberRelationship -ResourceUri "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG" -Name "myMembership"
```

Retrieves the ServiceGroupMember relationship named 'myMembership' scoped to the resource group 'myRG'.

### Example 2: Get a ServiceGroupMember relationship using identity input
```powershell
$identity = @{ ResourceUri = "/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/myRG"; Name = "myMembership" }
Get-AzRelationshipsServiceGroupMemberRelationship -InputObject $identity
```

Retrieves the relationship by constructing an identity hashtable with ResourceUri and Name keys.

