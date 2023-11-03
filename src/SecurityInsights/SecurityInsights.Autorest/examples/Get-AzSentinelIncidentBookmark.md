### Example 1: List all Bookmarks for a given Incident
```powershell
 Get-AzSentinelIncidentBookmark -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "7f40bbbc-e205-404b-bc2b-5d71cd1017a8"
```
```output
DisplayName    : My 2021 Bookmark
FriendlyName   : My 2021 Bookmark
Label          : {my Tags}
Note           : my notes
                 2nd line notes
CreatedByEmail : luke@contoso.com
CreatedByName  : Luke
Name           : 4557d832-41f0-456f-977e-78a2e129b8d0 
```

This command lists all Bookmarks for a given Incident.