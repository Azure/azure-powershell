### Example 1: List owners of a group
```powershell
$groupId = (Get-AzADGroup -DisplayName "someGroup").Id
Get-AzADGroupOwner -GroupId $groupId
```

List owners of a group