### Example 1: Get Solution metadata from the workspace
```powershell
 Get-AzSentinelMetadata -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
Etag    Name                                                SystemDataCreatedAt     SystemDataCreatedBy SystemDataCreatedByType
----    ----                                                -------------------     ------------------- -----------
        azuresentinel.azure-sentinel-solution-slackaudit    3/11/2022 11:20:19 PM   user@domain.local   User       
```

This command lists all Solution metadata for a workspace.