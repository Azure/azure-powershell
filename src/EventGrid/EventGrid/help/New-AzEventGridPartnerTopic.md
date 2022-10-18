---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# New-AzEventGridPartnerTopic

## SYNOPSIS
Creates a new Azure Event Grid Partner Topic.

## SYNTAX

### TopicNameParameterSet (Default)
```
New-AzEventGridPartnerTopic [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### PartnerTopicNameParameterSet
```
New-AzEventGridPartnerTopic -ResourceGroupName <String> -Name <String> -Source <String> [-Location <String>]
 [-IdentityType <String>] [-IdentityId <String[]>] [-Tag <Hashtable>]
 [-PartnerTopicFriendlyDescription <String>] [-MessageForActivation <String>]
 [-ExpirationTimeIfNotActivatedUtc <DateTime>] [-PartnerRegistrationImmutableId <Guid>]
 [-EventTypeKind <String>] [-InlineEvent <Hashtable>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Azure Event Partner Topic.

## EXAMPLES

### Example 1
```powershell
New-AzEventGridPartnerTopic -ResourceGroupName MyResourceGroupName -Name PartnerTopic1 -Source ContosoCorp.Accounts.User1 -Location westus2 -PartnerRegistrationImmutableId 23e0092b-f336-4833-9ab3-9353a15650fc
```

Creates a new Event Grid partner topic \`PartnerTopic\` in resource group \`MyResourceGroupName\`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EventTypeKind
The kind of event type used.
Possible values include: 'Inline'

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet
Aliases:
Accepted values: Inline

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ExpirationTimeIfNotActivatedUtc
Expiration time of the partner topic.
If this timer expires while the partner topic is still never activated, the partner topic and corresponding event channel are deleted.

```yaml
Type: DateTime
Parameter Sets: PartnerTopicNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentityId
The list of user assigned identities

```yaml
Type: String[]
Parameter Sets: PartnerTopicNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IdentityType
Different identity types.
Could be either  of following 'SystemAssigned', 'UserAssigned', 'SystemAssigned, UserAssigned', 'None'

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet
Aliases:
Accepted values: SystemAssigned, UserAssigned, SystemAssigned, UserAssigned, None

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InlineEvent
Hashtable representing information on inline events.
The inline event keys are of type string which represents the name of the event.The inline event values are Hashtables containing the optional keys description, displayName, documentationUrl, and dataSchemaUrl which define the information about the inline event.

```yaml
Type: Hashtable
Parameter Sets: PartnerTopicNameParameterSet
Aliases:
Accepted values: Inline

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
The location of the topic.

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -MessageForActivation
Context or helpful message that can be used during the approval process by the subscriber.

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
EventGrid topic name.

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet
Aliases: PartnerTopicName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerRegistrationImmutableId
Immutable id of the corresponding partner registration

```yaml
Type: Guid
Parameter Sets: PartnerTopicNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerTopicFriendlyDescription
Hashtable which represents resource Tags.

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet
Aliases: ResourceGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Source
Source for a system topic

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Hashtable which represents resource Tags.

```yaml
Type: Hashtable
Parameter Sets: PartnerTopicNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: SwitchParameter
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
Type: SwitchParameter
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

### System.String

### System.String[]

### System.Collections.Hashtable

### System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Nullable`1[[System.Guid, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerTopic

## NOTES

## RELATED LINKS
