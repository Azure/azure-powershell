---
external help file: Az.SecurityInsights-help.xml
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/update-azsentinelincident
schema: 2.0.0
---

# Update-AzSentinelIncident

## SYNOPSIS
Creates or updates the incident.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzSentinelIncident -Id <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 -WorkspaceName <String> [-Classification <IncidentClassification>] [-ClassificationComment <String>]
 [-ClassificationReason <IncidentClassificationReason>] [-Description <String>]
 [-FirstActivityTimeUtc <DateTime>] [-Label <IIncidentLabel[]>] [-LastActivityTimeUtc <DateTime>]
 [-OwnerAssignedTo <String>] [-OwnerEmail <String>] [-OwnerObjectId <String>]
 [-OwnerUserPrincipalName <String>] [-ProviderIncidentId <String>] [-ProviderName <String>]
 [-Severity <IncidentSeverity>] [-Status <IncidentStatus>] [-Title <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzSentinelIncident -InputObject <ISecurityInsightsIdentity> [-Classification <IncidentClassification>]
 [-ClassificationComment <String>] [-ClassificationReason <IncidentClassificationReason>]
 [-Description <String>] [-FirstActivityTimeUtc <DateTime>] [-Label <IIncidentLabel[]>]
 [-LastActivityTimeUtc <DateTime>] [-OwnerAssignedTo <String>] [-OwnerEmail <String>] [-OwnerObjectId <String>]
 [-OwnerUserPrincipalName <String>] [-ProviderIncidentId <String>] [-ProviderName <String>]
 [-Severity <IncidentSeverity>] [-Status <IncidentStatus>] [-Title <String>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the incident.

## EXAMPLES

### Example 1: Update an Incident
```powershell
Update-AzSentinelIncident -ResourceGroupName "myResourceGroupName" -WorkspaceName "myWorkspaceName" -Id "4a21e485-75ae-48b3-a7b9-e6a92bcfe434" -OwnerAssignedTo "user@mydomain.local"
```

This command updates an incident by assigning an owner.

## PARAMETERS

### -Classification
The reason the incident was closed

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.IncidentClassification
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClassificationComment
Describes the reason the incident was closed

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ClassificationReason
The classification reason the incident was closed with

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.IncidentClassificationReason
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Description
The description of the incident

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FirstActivityTimeUtc
The time of the first activity in the incident

```yaml
Type: System.DateTime
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
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
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Label
List of labels relevant to this incident
To construct, see NOTES section for LABEL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncidentLabel[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LastActivityTimeUtc
The time of the last activity in the incident

```yaml
Type: System.DateTime
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OwnerAssignedTo
The name of the user the incident is assigned to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OwnerEmail
The email of the user the incident is assigned to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OwnerObjectId
The object id of the user the incident is assigned to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OwnerUserPrincipalName
The user principal name of the user the incident is assigned to.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderIncidentId
The incident ID assigned by the incident provider

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProviderName
The name of the source provider that generated the incident

```yaml
Type: System.String
Parameter Sets: (All)
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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Severity
The severity of the incident

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.IncidentSeverity
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Status
The status of the incident

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Support.IncidentStatus
Parameter Sets: (All)
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
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Title
The title of the incident

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
The name of the workspace.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IIncident

## NOTES

## RELATED LINKS
