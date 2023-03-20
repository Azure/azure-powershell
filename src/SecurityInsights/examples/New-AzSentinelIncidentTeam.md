### Example 1: Create an Incident Teams Room
```powershell
 $incident = Get-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id "myIncidentId"
 New-AzSentinelIncidentTeam -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -IncidentId ($incident.Name) -TeamName ("Incident "+$incident.incidentNumber+": "+$incident.title)
```
```output
Description         :
Name                : Incident : NewIncident3
PrimaryChannelUrl   : https://teams.microsoft.com/l/team/19:vYoGjeGlZmTEDmu0gTbrk9T_eDS4pKIkEU7UuM1IyZk1%40thread.tacv2/conversations?groupId=3c637cc5-caf1-46c7-93ac-069c6
                      4b05395&tenantId=8f21ced5-2eff-4f8d-aff1-4dbb4cee8e3d
TeamCreationTimeUtc : 2/4/2022 3:02:03 PM
TeamId              : 3c637cc5-caf1-46c7-93ac-069c64b05395
```

This command creates a Teams group for the Incident.
