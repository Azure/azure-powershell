### Example 1: Remove members from group
```powershell
$members = @()
$members += (Get-AzADUser -DisplayName $uname).Id
$members += (Get-AzADServicePrincipal -ApplicationId $appid).Id
Get-AzADGroupMember -GroupDisplayName $gname | Remove-AzADGroupMember -MemberObjectId $member
```

Remove members from group