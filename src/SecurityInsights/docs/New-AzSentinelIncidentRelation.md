---
external help file:
Module Name: Az.SecurityInsights
online version: https://learn.microsoft.com/powershell/module/az.securityinsights/new-azsentinelincidentrelation
schema: 2.0.0
---

# New-AzSentinelIncidentRelation

## SYNOPSIS
Creates or updates the incident relation.

## SYNTAX

### CreateExpanded (Default)
```
New-AzSentinelIncidentRelation -IncidentId <String> -ResourceGroupName <String> -WorkspaceName <String>
 [-RelationName <String>] [-SubscriptionId <String>] [-RelatedResourceId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzSentinelIncidentRelation -IncidentId <String> -ResourceGroupName <String> -WorkspaceName <String>
 -Relation <IRelation> [-RelationName <String>] [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates or updates the incident relation.

## EXAMPLES

### Example 1: Create a Incident Relation
```powershell
 $bookmark = Get-AzSentinelBookmark -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -Id "myBookmarkId"
 New-AzSentinelIncidentRelation -ResourceGroupName "myResourceGroup" -WorkspaceName "myWorkspaceName" -IncidentId "myIncidentId" -RelationName ((New-Guid).Guid) -RelatedResourceId ($bookmark.Id)
```

```output
Name                : 4b112bd9-a6b5-44f6-b89d-8bcbf021fbdf
RelatedResourceName : a636a51c-471a-468d-89ed-d7f4b2a7a569
RelatedResourceKind :
RelatedResourceType : Microsoft.SecurityInsights/Bookmarks
```

This command creates a Incident Relation connecting the Bookmark to the Incident.

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

### -RelatedResourceId
The resource ID of the related resource

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

### -Relation
Represents a relation between two resources
To construct, see NOTES section for RELATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelation
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -RelationName
Relation Name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (New-Guid).Guid
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

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelation

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SecurityInsights.Models.Api20210901Preview.IRelation

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`RELATION <IRelation>`: Represents a relation between two resources
  - `[Etag <String>]`: Etag of the azure resource
  - `[SystemDataCreatedAt <DateTime?>]`: The timestamp of resource creation (UTC).
  - `[SystemDataCreatedBy <String>]`: The identity that created the resource.
  - `[SystemDataCreatedByType <CreatedByType?>]`: The type of identity that created the resource.
  - `[SystemDataLastModifiedAt <DateTime?>]`: The timestamp of resource last modification (UTC)
  - `[SystemDataLastModifiedBy <String>]`: The identity that last modified the resource.
  - `[SystemDataLastModifiedByType <CreatedByType?>]`: The type of identity that last modified the resource.
  - `[RelatedResourceId <String>]`: The resource ID of the related resource

## RELATED LINKS

