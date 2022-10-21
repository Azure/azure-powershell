---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# New-AzEventGridChannel

## SYNOPSIS
Creates a new Event Grid channel.

## SYNTAX

```
New-AzEventGridChannel [-ResourceGroupName] <String> [-PartnerNamespaceName] <String> [-Name] <String>
 [-ChannelType] <String> [-PartnerTopicSource <String>] [-MessageForActivation <String>]
 [-PartnerTopicName <String>] [-EventTypeKind <String>] [-InlineEvent <Hashtable>]
 [-ExpirationTimeIfNotActivatedUtc <DateTime>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Creates a new Event Grid channel based in the provided channel type.

## EXAMPLES

### Example 1
```powershell
New-AzEventGridChannel -ResourceGroupName MyResourceGroupName -PartnerNamespaceName PartnerNamespace1 -Name Channel1 -ChannelType PartnerTopic -PartnerTopicSource PartnerTopicSource1 -PartnerTopicName PartnerTopic1
```

Creates an Event Grid channel \`Channel\` under the partner namespace \`PartnerNamespace\` under the resource group \`MyResourceGroupName\`.
The channel will be of type PartnerTopic and the partner topic \`PartnerTopic1\` will be created with the specified source.

## PARAMETERS

### -ChannelType
The type of the event channel which represents the direction flow of events.
Possible values include: 'PartnerTopic'

```yaml
Type: String
Parameter Sets: (All)
Aliases:
Accepted values: PartnerTopic

Required: True
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

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
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
Aliases:

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
Parameter Sets: (All)
Aliases:
Accepted values: Inline

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
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the Event Grid channel.

```yaml
Type: String
Parameter Sets: (All)
Aliases: ChannelName

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerNamespaceName
Event Grid partner namespace name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerTopicName
Event Grid partner topic name.

```yaml
Type: String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PartnerTopicSource
Source information provided by the publisher to determine the scope or context from which the events are originating.

```yaml
Type: String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases: ResourceGroup

Required: True
Position: 0
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

### System.Collections.Hashtable

### System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSChannel

## NOTES

## RELATED LINKS
