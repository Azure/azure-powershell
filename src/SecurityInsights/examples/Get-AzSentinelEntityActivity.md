### Example 1: Get Insights and Activities for an Entity
```powershell
 Get-AzSentinelEntityActivity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "myEntityId"
```
```output
FriendlyName : WIN2019
Kind         : Host
Name         : 8d036a2d-f37d-e936-6cca-4e172687cb79

FriendlyName : HackTool:Win32/Mimikatz.gen!H
Kind         : Malware
Name         : 876fda24-fe06-62b7-7dca-bced167a0ca3

FriendlyName : 52.166.111.66
Kind         : Ip
Name         : 4ebb68f3-a435-fac0-d3b6-94712d246f0a
```

This command gets insights and activities for an Entity.

### Example 2: Get Insights and Activities for an Entity by Id
```powershell
 $Entity = Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -EntityId "4ebb68f3-a435-fac0-d3b6-94712d246f0a"
 $Entity | Get-AzSentinelEntityActivity
```

This command gets insights and activies for an Entity by object