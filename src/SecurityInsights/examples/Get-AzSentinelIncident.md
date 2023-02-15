### Example 1: List all Incidents
```powershell
 Get-AzSentinelIncident -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
```
```output
Title        	: (Preview) TI map IP entity to AzureActivity
Description  	: Identifies a match in AzureActivity from any IP IOC from TI
Severity     	: Medium
Number      	: 754
Label        	: {}
ProviderName  : Azure Sentinel
Name         	: f5409f55-7dd8-4c73-9981-4627520b2db
```

This command lists all Incidents under a Microsoft Sentinel workspace.

### Example 2: Get an Incident
```powershell
 Get-AzSentinelIncident -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "f5409f55-7dd8-4c73-9981-4627520b2db"
```
```output
Title        	: (Preview) TI map IP entity to AzureActivity
Description  	: Identifies a match in AzureActivity from any IP IOC from TI
Severity     	: Medium
Number      	: 754
Label        	: {}
ProviderName  : Azure Sentinel
Name         	: f5409f55-7dd8-4c73-9981-4627520b2db
```

This command gets an Incident.