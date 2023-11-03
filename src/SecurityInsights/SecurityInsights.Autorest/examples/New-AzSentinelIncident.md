### Example 1: Create an Incident
```powershell
 New-AzSentinelIncident -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -Title "NewIncident" -Description "My Description" -Severity Low -Status New
```
```output
Title          : NewIncident
Description    : My Description
Severity       : Low
Status         : New
Number         : 779
CreatedTimeUtc : 2/3/2022 7:47:03 PM
Name           : c831b5a7-5644-403f-9dc3-96d651e04c6d
Url            : https://portal.azure.com/#asset/Microsoft_Azure_Security_Insights/Incident/subscriptions/274b1a41-c53c-4092-8d4a-7210f6a44a0c/resourceGroups/cyber-soc/providers/Microsoft.OperationalInsights/workspaces/myworkspace/providers/Microsoft.SecurityInsights/Incidents/c831b5a7-5644-403f-9dc3-96d651e04c6d
```

This command creates an Incident.
