### Example 1: Add members to group
```powershell
PS C:\> $groupid=(Get-AzADGroup -DisplayName $gname).Id
PS C:\> $members=@()
PS C:\> $members+=(Get-AzADUser -DisplayName $uname).Id
PS C:\> $members+=(Get-AzADServicePrincipal -ApplicationId $appid).Id
PS C:\> Add-AzADGroupMember -TargetGroupObjectId $groupid MemberObjectId $members
```

Add members to group