### Example 1: List all Incident Relations for a given Incident 
```powershell
PS C:\> Get-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId"

Name                : 8969f5ea-4e92-433a-9b67-2f9233d8113f_457a48b2-9dfc-7054-64a5-e8a9d17489d7
RelatedResourceName : 457a48b2-9dfc-7054-64a5-e8a9d17489d7
RelatedResourceKind : SecurityAlert
RelatedResourceType : Microsoft.SecurityInsights/entities

Name                : 076bda5c-7d94-b6d8-8ef4-b0b2a0830dac_df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceName : df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceKind : SecurityAlert
RelatedResourceType : Microsoft.SecurityInsights/entities
```

This command lists all Incident Relations for a given Incident.

### Example 2: Get a Incident Relation
```powershell
PS C:\> Get-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId" -Id "myIncidentRelationId"

Name                : 076bda5c-7d94-b6d8-8ef4-b0b2a0830dac_df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceName : df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceKind : SecurityAlert
RelatedResourceType : Microsoft.SecurityInsights/entities
```

This command gets a Incident Relation.

### Example 3: Get a Incident Relation by object Id
```powershell
PS C:\> $Incidentrelations = Get-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId"
PS C:\> $Incidentrelations[0] | Get-AzSentinelIncidentRelation

Name                : 076bda5c-7d94-b6d8-8ef4-b0b2a0830dac_df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceName : df9493a7-4f2e-84da-1f41-4914e8c029ba
RelatedResourceKind : SecurityAlert
RelatedResourceType : Microsoft.SecurityInsights/entities
```

This command gets a Incident by object