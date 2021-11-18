### Example 1: List all Incident Relations for a given Incident 
```powershell
PS C:\> Get-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId"

{{ Add output here }}
```

This command lists all Incident Relations for a given Incident.

### Example 2: Get a Incident Relation
```powershell
PS C:\> Get-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId" -Id "myIncidentRelationId"

{{ Add output here }}
```

This command gets a Incident Relation.

### Example 3: Get a Incident Relation by object Id
```powershell
PS C:\> $Incidentrelations = Get-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -IncidentId "myIncidentId"
PS C:\> $Incidentrelations[0] | Get-AzSentinelIncidentRelation

{{ Add output here }}
```

This command gets a Incident by object