### Example 1: List all Incident Comments for a given Incident 
```powershell
 Get-AzSentinelIncidentComment -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "7a4c27ea-d61a-496b-b5c3-246770c857c1"
```
```output
AuthorEmail             : john@contoso.com
AuthorName              : John Contoso
AuthorUserPrincipalName : john@contoso.com
CreatedTimeUtc          : 1/6/2022 2:15:44 PM
Message                 : This is my comment
Name                    : da0957c9-2f1a-44a2-bc83-a2c0696b2bf1

```

This command lists all Incident Comments for a given Incident.

### Example 2: Get an Incident Comment
```powershell
 Get-AzSentinelIncidentComment -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "7a4c27ea-d61a-496b-b5c3-246770c857c1" -Id "da0957c9-2f1a-44a2-bc83-a2c0696b2bf1"
```
```output
AuthorEmail             : john@contoso.com
AuthorName              : John Contoso
AuthorUserPrincipalName : john@contoso.com
CreatedTimeUtc          : 1/6/2022 2:15:44 PM
Message                 : This is my comment
Name                    : da0957c9-2f1a-44a2-bc83-a2c0696b2bf1
```

This command gets an Incident Comment.