### Example 1: Create a Incident Relation
```powershell 
$bookmark = Get-AzSentinelBookmark -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Id "70aaef57-7165-444b-959d-67e6668d57d0"
New-AzSentinelIncidentRelation -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -IncidentId "9f5c6069-39bc-4814-bd1b-728012a3c95d" -RelationName ((New-Guid).Guid) -RelatedResourceId ($bookmark.Id)
```

```output
Etag                         : "9403d27f-0000-0100-0000-64cb1f890000"
Id                           : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-4814-bd1b-728012a3c95d/relations/f94951bd-6491-4c71-a3f4-dfeaaf98047e
Name                         : f94951bd-6491-4c71-a3f4-dfeaaf98047e
RelatedResourceId            : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/prov 
                               iders/Microsoft.SecurityInsights/Bookmarks/70aaef57-7165-444b-959d-67e6668d57d0
RelatedResourceKind          : 
RelatedResourceName          : 70aaef57-7165-444b-959d-67e6668d57d0
RelatedResourceType          : Microsoft.SecurityInsights/Bookmarks
ResourceGroupName            : si-jj-test
SystemDataCreatedAt          : 
SystemDataCreatedBy          : 
SystemDataCreatedByType      : 
SystemDataLastModifiedAt     : 
SystemDataLastModifiedBy     : 
SystemDataLastModifiedByType : 
Type                         : Microsoft.SecurityInsights/Incidents/relations
```

This command creates a Incident Relation connecting the Bookmark to the Incident.

