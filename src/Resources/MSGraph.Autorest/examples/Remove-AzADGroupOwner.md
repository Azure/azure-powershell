### Example 1: Unassign an owner for a group
```powershell
$groupId = (Get-AzADGroup -DisplayName "someGroup").Id
$ownerId = (Get-AzADGroupOwner -GroupId $groupId)[0].Id
Remove-AzADGroupOwner -GroupId $groupId -OwnerId $ownerId
```

Unassign an owner for a group. Notice: 1.this cmdlet does not delete the owner directory object. 2.a group does not have a onwer by default, but has to have at least one owner once had one.