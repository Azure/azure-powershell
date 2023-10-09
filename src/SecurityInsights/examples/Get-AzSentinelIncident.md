### Example 1: List all Incidents
```powershell
Get-AzSentinelIncident -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws"
```

```output
AdditionalDataAlertProductName    : {}
AdditionalDataAlertsCount         : 0
AdditionalDataBookmarksCount      : 0
AdditionalDataCommentsCount       : 0
AdditionalDataProviderIncidentUrl : 
AdditionalDataTactic              : {}
Classification                    : 
ClassificationComment             : 
ClassificationReason              : 
CreatedTimeUtc                    : 8/2/2023 9:40:07 AM
Description                       : My Description
Etag                              : "3403385d-0000-0100-0000-64ca24770000"
FirstActivityTimeUtc              : 
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws 
                                    /providers/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-4814-bd1b-728012a3c95d
Label                             : {}
LastActivityTimeUtc               : 
LastModifiedTimeUtc               : 8/2/2023 9:40:07 AM
Name                              : 9f5c6069-39bc-4814-bd1b-728012a3c95d
Number                            : 1
OwnerAssignedTo                   : 
OwnerEmail                        : 
OwnerObjectId                     : 
OwnerType                         : 
OwnerUserPrincipalName            : 
ProviderIncidentId                : 1
ProviderName                      : Azure Sentinel
RelatedAnalyticRuleId             : {}
ResourceGroupName                 : si-jj-test
Severity                          : Low
Status                            : New
SystemDataCreatedAt               : 
SystemDataCreatedBy               : 
SystemDataCreatedByType           : 
SystemDataLastModifiedAt          : 
SystemDataLastModifiedBy          : 
SystemDataLastModifiedByType      : 
Title                             : NewIncident
Type                              : Microsoft.SecurityInsights/Incidents
Url                               : https://portal.azure.com/#asset/Microsoft_Azure_Security_Insights/Incident/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroup 
                                    s/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/providers/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-481 
                                    4-bd1b-728012a3c95d
```

This command lists all Incidents under a Microsoft Sentinel workspace.

### Example 2: Get an Incident
```powershell
Get-AzSentinelIncident -ResourceGroupName "si-jj-test" -WorkspaceName "si-test-ws" -Id "9f5c6069-39bc-4814-bd1b-728012a3c95d"
```
```output
AdditionalDataAlertProductName    : {}
AdditionalDataAlertsCount         : 0
AdditionalDataBookmarksCount      : 0
AdditionalDataCommentsCount       : 0
AdditionalDataProviderIncidentUrl : 
AdditionalDataTactic              : {}
Classification                    : 
ClassificationComment             : 
ClassificationReason              : 
CreatedTimeUtc                    : 8/2/2023 9:40:07 AM
Description                       : My Description
Etag                              : "3403385d-0000-0100-0000-64ca24770000"
FirstActivityTimeUtc              : 
Id                                : /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws 
                                    /providers/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-4814-bd1b-728012a3c95d
Label                             : {}
LastActivityTimeUtc               : 
LastModifiedTimeUtc               : 8/2/2023 9:40:07 AM
Name                              : 9f5c6069-39bc-4814-bd1b-728012a3c95d
Number                            : 1
OwnerAssignedTo                   : 
OwnerEmail                        : 
OwnerObjectId                     : 
OwnerType                         : 
OwnerUserPrincipalName            : 
ProviderIncidentId                : 1
ProviderName                      : Azure Sentinel
RelatedAnalyticRuleId             : {}
ResourceGroupName                 : si-jj-test
Severity                          : Low
Status                            : New
SystemDataCreatedAt               : 
SystemDataCreatedBy               : 
SystemDataCreatedByType           : 
SystemDataLastModifiedAt          : 
SystemDataLastModifiedBy          : 
SystemDataLastModifiedByType      : 
Title                             : NewIncident
Type                              : Microsoft.SecurityInsights/Incidents
Url                               : https://portal.azure.com/#asset/Microsoft_Azure_Security_Insights/Incident/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroup 
                                    s/si-jj-test/providers/Microsoft.OperationalInsights/workspaces/si-test-ws/providers/Microsoft.SecurityInsights/Incidents/9f5c6069-39bc-481 
                                    4-bd1b-728012a3c95d
```

This command gets an Incident.