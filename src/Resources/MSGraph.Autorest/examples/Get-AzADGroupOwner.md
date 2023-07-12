### Example 1: List owners of a group
```powershell
$groupId = (Get-AzADGroup -DispalyName "someGroup").Id
Get-AzADGroupOwner -GroupId $groupId
```

List owners of a group