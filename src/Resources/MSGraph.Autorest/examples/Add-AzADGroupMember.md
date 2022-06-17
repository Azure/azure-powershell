### Example 1: Add members to group
```powershell
$groupid=(Get-AzADGroup -DisplayName $gname).Id
$members=@()
$members+=(Get-AzADUser -DisplayName $uname).Id
$members+=(Get-AzADServicePrincipal -ApplicationId $appid).Id
Add-AzADGroupMember -TargetGroupObjectId $groupid -MemberObjectId $members
```

Add members to group