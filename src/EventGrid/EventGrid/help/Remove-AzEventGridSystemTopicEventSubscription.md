---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Remove-AzEventGridSystemTopicEventSubscription

## SYNOPSIS
Removes an Azure Event Grid system topic event subscription.

## SYNTAX

### TopicNameParameterSet (Default)
```
Remove-AzEventGridSystemTopicEventSubscription [-Force] [-PassThru] [-DefaultProfile <IAzureContextContainer>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SystemTopicEventSuscriptionParameterSet
```
Remove-AzEventGridSystemTopicEventSubscription -EventSubscriptionName <String> -ResourceGroupName <String>
 -SystemTopicName <String> [-Force] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Removes an Azure Event Grid event subscription for an Azure Event Grid system topic.

## EXAMPLES

### Example 1
```powershell
Remove-AzEventGridSystemTopicEventSubscription -ResourceGroup MyResourceGroup -SystemTopicName Topic1 -EventSubscriptionName EventSubscription1
```

Removes the event subscription \`EventSubscription1\` to an Azure Event Grid system topic \`Topic1\` in resource group \`MyResourceGroupName\`.

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

### -EventSubscriptionName
EventGrid event subscription name.

```yaml
Type: String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Indicates that the cmdlet does not prompt you for confirmation.
By default, this cmdlet prompts you to confirm that you want to delete the resource

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PassThru
Returns the status of the Remove operation. By default, this cmdlet does not generate any output.

```yaml
Type: SwitchParameter
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
Type: String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SystemTopicName
EventGrid topic name.

```yaml
Type: String
Parameter Sets: SystemTopicEventSuscriptionParameterSet
Aliases:

Required: True
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

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
