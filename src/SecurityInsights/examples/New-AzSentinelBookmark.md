### Example 1: Create a Bookmark
```powershell
$queryStartTime = (Get-Date).AddDays(-1).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
$queryEndTime = (Get-Date).ToUniversalTime() | Get-Date -Format "yyyy-MM-ddThh:00:00.000Z"
New-AzSentinelBookmark -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -DisplayName "Incident Evidence" -Query "SecurityEvent | take 1" -QueryStartTime $queryStartTime -QueryEndTime $queryEndTime -EventTime $queryEndTime
```

```output
Created                      : 8/2/2023 9:34:31 AM
CreatedByEmail               : v-jiaji@microsoft.com
CreatedByName                : Joyer Jin (Wicresoft North America Ltd)
CreatedByObjectId            : 6205f759-1234-453c-9712-34d7671bceff
DisplayName                  : Incident Evidence
Etag                         : "5a0a5305-0000-0100-0000-64ca23270000"
EventTime                    : 8/2/2023 9:00:00 AM
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/Bookmarks/70aaef57-7165-444b-959d-67e6668d57d0
IncidentInfoIncidentId       : 
IncidentInfoRelationName     : 
IncidentInfoSeverity         : 
IncidentInfoTitle            : 
Label                        : {}
Name                         : 70aaef57-7165-444b-959d-67e6668d57d0
Note                         : 
Query                        : SecurityEvent | take 1
QueryEndTime                 : 8/2/2023 9:00:00 AM
QueryResult                  : 
QueryStartTime               : 8/1/2023 9:00:00 AM
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/Bookmarks
Updated                      : 8/2/2023 9:34:31 AM
UpdatedByEmail               : v-jiaji@microsoft.com
UpdatedByName                : Joyer Jin (Wicresoft North America Ltd)
UpdatedByObjectId            : 6205f759-1234-453c-9712-34d7671bceff
```

This command creates a Bookmark.

