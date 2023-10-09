### Example 1: Create an Incident Comment
```powershell
New-AzSentinelIncidentComment -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -IncidentId "9f5c6069-39bc-4814-bd1b-728012a3c95d" -Message "IncidentCommentGoesHere"
```

```output
AuthorEmail                  : v-jiaji@microsoft.com
AuthorName                   : Joyer Jin (Wicresoft North America Ltd)
AuthorObjectId               : 6205f759-1234-453c-9712-34d7671bceff
AuthorUserPrincipalName      : v-jiaji@microsoft.com
CreatedTimeUtc               : 8/2/2023 9:50:38 AM
Etag                         : "3503c21a-0000-0100-0000-64ca26ee0000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-4814-bd1b-728012a3c95d/Comments/418b3920-c025-4631-92b3-3e9cc489317f
LastModifiedTimeUtc          : 8/2/2023 9:50:38 AM
Message                      : IncidentCommentGoesHere
Name                         : 418b3920-c025-4631-92b3-3e9cc489317f
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/Incidents/Comments
```

This command creates an Incident Comment.
