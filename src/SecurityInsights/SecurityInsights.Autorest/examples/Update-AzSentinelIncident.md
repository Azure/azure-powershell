### Example 1: Update an Incident
```powershell
Update-AzSentinelIncident -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Id "4a21e485-75ae-48b3-a7b9-e6a92bcfe434" -Title "Suspicious login activity" -Status "Active" -Severity "Medium" -OwnerAssignedTo "user@mydomain.local"
```

This command updates an incident by assigning an owner.
Note: The `-Title`, `-Status`, and `-Severity` parameters are required by the underlying API even though they are listed as optional. Omitting any of them will result in an error. When updating an incident, always include these three parameters.

### Example 2: Update an Incident using the InputObject (pipeline) pattern
```powershell
$incident = Get-AzSentinelIncident -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Id "4a21e485-75ae-48b3-a7b9-e6a92bcfe434"
$labels = $incident.Label + [Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IncidentLabel]::new()
$labels[-1].LabelName = "Reviewed"
Update-AzSentinelIncident -InputObject $incident -Title $incident.Title -Status $incident.Status -Severity $incident.Severity -Label $labels
```

This command adds a label to an existing incident using the pipeline pattern. When using `-InputObject`, you must still supply `-Title`, `-Status`, and `-Severity` (pass the original values to keep them unchanged).
