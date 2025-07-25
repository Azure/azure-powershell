### Example 1: Assign a user as owner of a group
```powershell
$userId = (Get-AzADUser -DisplayName "John Doe").Id
$groupId = (Get-AzADGroup -DisplayName "someGroup").Id
New-AzADGroupOwner -GroupId $groupId -OwnerId $userId
```

Assign a user as owner of a group
