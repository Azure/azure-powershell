---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/get-azsentinelincident
schema: 2.0.0
---

# Get-AzSentinelIncident

## SYNOPSIS
Gets a given incident.

## SYNTAX

### List (Default)
```
Get-AzSentinelIncident -ResourceGroupName <String> -WorkspaceName <String> [-SubscriptionId <String[]>]
 [-Filter <String>] [-Orderby <String>] [-SkipToken <String>] [-Top <Int32>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzSentinelIncident -Id <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSentinelIncident -InputObject <ISecurityInsightsIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentityWorkspace
```
Get-AzSentinelIncident -Id <String> -WorkspaceInputObject <ISecurityInsightsIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets a given incident.

## EXAMPLES

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

## PARAMETERS

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Filters the results, based on a Boolean condition.
Optional.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Incident ID

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityWorkspace
Aliases: IncidentId

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Orderby
Sorts the results.
Optional.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkipToken
Skiptoken is only used if a previous operation returned a partial result.
If a previous response contains a nextLink element, the value of the nextLink element will include a skiptoken parameter that specifies a starting point to use for subsequent calls.
Optional.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Returns only the first n results.
Optional.

```yaml
Type: System.Int32
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceInputObject
Identity Parameter
To construct, see NOTES section for WORKSPACEINPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity
Parameter Sets: GetViaIdentityWorkspace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.ISecurityInsightsIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.IIncident

## NOTES

## RELATED LINKS

