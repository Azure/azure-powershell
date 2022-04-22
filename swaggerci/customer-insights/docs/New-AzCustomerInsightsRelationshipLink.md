---
external help file:
Module Name: Az.CustomerInsights
online version: https://docs.microsoft.com/en-us/powershell/module/az.customerinsights/new-azcustomerinsightsrelationshiplink
schema: 2.0.0
---

# New-AzCustomerInsightsRelationshipLink

## SYNOPSIS
Creates a relationship link or updates an existing relationship link within a hub.

## SYNTAX

```
New-AzCustomerInsightsRelationshipLink -HubName <String> -Name <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Description <Hashtable>] [-DisplayName <Hashtable>] [-InteractionType <String>]
 [-Mapping <IRelationshipLinkFieldMapping[]>]
 [-ProfilePropertyReference <IParticipantProfilePropertyReference[]>]
 [-RelatedProfilePropertyReference <IParticipantProfilePropertyReference[]>] [-RelationshipName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a relationship link or updates an existing relationship link within a hub.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
Localized descriptions for the Relationship Link.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DisplayName
Localized display name for the Relationship Link.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HubName
The name of the hub.

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

### -InteractionType
The InteractionType associated with the Relationship Link.

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

### -Mapping
The mappings between Interaction and Relationship fields.
To construct, see NOTES section for MAPPING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IRelationshipLinkFieldMapping[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the relationship link.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: RelationshipLinkName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProfilePropertyReference
The property references for the Profile of the Relationship.
To construct, see NOTES section for PROFILEPROPERTYREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IParticipantProfilePropertyReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelatedProfilePropertyReference
The property references for the Related Profile of the Relationship.
To construct, see NOTES section for RELATEDPROFILEPROPERTYREFERENCE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IParticipantProfilePropertyReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RelationshipName
The Relationship associated with the Link.

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
Gets subscription credentials which uniquely identify Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CustomerInsights.Models.Api20170426.IRelationshipLinkResourceFormat

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


MAPPING <IRelationshipLinkFieldMapping[]>: The mappings between Interaction and Relationship fields.
  - `InteractionFieldName <String>`: The field name on the Interaction Type.
  - `RelationshipFieldName <String>`: The field name on the Relationship metadata.
  - `[LinkType <LinkTypes?>]`: Link type.

PROFILEPROPERTYREFERENCE <IParticipantProfilePropertyReference[]>: The property references for the Profile of the Relationship.
  - `InteractionPropertyName <String>`: The source interaction property that maps to the target profile property.
  - `ProfilePropertyName <String>`: The target profile property that maps to the source interaction property.

RELATEDPROFILEPROPERTYREFERENCE <IParticipantProfilePropertyReference[]>: The property references for the Related Profile of the Relationship.
  - `InteractionPropertyName <String>`: The source interaction property that maps to the target profile property.
  - `ProfilePropertyName <String>`: The target profile property that maps to the source interaction property.

## RELATED LINKS

