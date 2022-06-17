### Example 1: List members by group display name
```powershell
Get-AzADGroupMember -GroupDisplayName $name
```

List members by group display name

### Example 2: List members by pipeline input
```powershell
Get-AzADGroup -DisplayName $name | Get-AzADGroupMember
```

List members by pipeline input