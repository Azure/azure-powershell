---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/new-azsentinelincidentteam
schema: 2.0.0
---

# New-AzSentinelIncidentTeam

## SYNOPSIS
Creates a Microsoft team to investigate the incident by sharing information and insights between participants.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSentinelIncidentTeam -IncidentId <String> -ResourceGroupName <String> -WorkspaceName <String>
 -TeamName <String> [-SubscriptionId <String>] [-GroupId <String[]>] [-MemberId <String[]>]
 [-TeamDescription <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzSentinelIncidentTeam -IncidentId <String> -ResourceGroupName <String> -WorkspaceName <String>
 -TeamProperty <ITeamProperties> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a Microsoft team to investigate the incident by sharing information and insights between participants.

## EXAMPLES

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

### -GroupId
List of group IDs to add their members to the team

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncidentId
Incident ID

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MemberId
List of member IDs to add to the team

```yaml
Type: System.String[]
Parameter Sets: CreateExpanded
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
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -TeamDescription
The description of the team

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TeamName
The name of the team

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TeamProperty
Describes team properties
To construct, see NOTES section for TEAMPROPERTY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ITeamProperties
Parameter Sets: Create
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
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ITeamProperties

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.ITeamInformation

## NOTES

## RELATED LINKS

