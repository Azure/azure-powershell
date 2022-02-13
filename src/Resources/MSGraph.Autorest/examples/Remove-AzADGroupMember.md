### Example 1: Remove members from group
```powershell
PS C:\> $members = @()
PS C:\> $members += (Get-AzADUser -DisplayName $uname).Id
PS C:\> $members += (Get-AzADServicePrincipal -ApplicationId $appid).Id
PS C:\> Get-AzADGroupMember -DisplayName $gname | Remove-AzADGroupMember -MemberObjectId $member
```

Remove members from group