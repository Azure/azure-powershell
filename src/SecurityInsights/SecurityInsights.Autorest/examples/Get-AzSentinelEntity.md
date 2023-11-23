### Example 1: List all Entities
```powershell
 Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
FriendlyName 	: WIN2019
Kind         	: Host
Name         	: 8d036a2d-f37d-e936-6cca-4e172687cb79

FriendlyName : 186.120.101.12
Kind         : Ip
Name         : bb590b07-5ef5-bf85-1c3e-2a04e1e137d2
```

This command lists all Entities under a Microsoft Sentinel workspace.

### Example 2: Get an Entity
```powershell
 Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "8d036a2d-f37d-e936-6cca-4e172687cb79"
```
```output
FriendlyName 	: WIN2019
Kind         	: Host
Name         	: 8d036a2d-f37d-e936-6cca-4e172687cb79
```

This command gets an Entity.

### Example 3: Get a Entity by object Id
```powershell
 $Entitys = Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
 $Entitys[0] | Get-AzSentinelEntity
```
```output
FriendlyName 	: WIN2019
Kind         	: Host
Name         	: 8d036a2d-f37d-e936-6cca-4e172687cb79
```

This command gets an Entity by object

### Example 4: Get a Entity by kind
```powershell
 Get-AzSentinelEntity -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" | Where-Object {$_.Kind -eq "CloudApplication"} 
```
```output
FriendlyName : Office 365
Kind         : CloudApplication
Name         : 8fceb9c4-abe7-7174-aabf-f1dde96a945e
```

This command gets an Entity by kind