---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Update-AzEventGridChannel

## SYNOPSIS
Updates the properties of an Event Grid channel.

## SYNTAX

### ChannelNameParameterSet (Default)
```
Update-AzEventGridChannel [-ResourceGroupName] <String> [-PartnerNamespaceName] <String> [-Name] <String>
 [-EventTypeKind <String>] [-InlineEvent <Hashtable>] [-ExpirationTimeIfNotActivatedUtc <DateTime>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ChannelInputObjectParameterSet
```
Update-AzEventGridChannel [-InputObject] <PSChannel> [-EventTypeKind <String>] [-InlineEvent <Hashtable>]
 [-ExpirationTimeIfNotActivatedUtc <DateTime>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of an Event Grid channel.

## EXAMPLES

### Example 1
```powershell
Update-AzEventGridChannel -ResourceGroupName MyResourceGroupName -PartnerNamespaceName PartnerNamespace1 -Name Channel1 -ExpirationTimeIfNotActivatedUtc (Get-Date).AddDays(8)
```

Updates the Event Grid channel so partner topics will expire 8 days from the current time if not activated.

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

### -InputObject
Channel object

```yaml
Type: PSChannel
Parameter Sets: ChannelInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
The name of the Event Grid channel.

```yaml
Type: String
Parameter Sets: ChannelNameParameterSet
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
Parameter Sets: ChannelNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: ChannelNameParameterSet
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

### Microsoft.Azure.Commands.EventGrid.Models.PSChannel

### System.Collections.Hashtable

### System.Nullable`1[[System.DateTime, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSChannel

## NOTES

## RELATED LINKS
