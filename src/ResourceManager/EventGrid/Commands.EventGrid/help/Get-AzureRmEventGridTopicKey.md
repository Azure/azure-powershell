---
external help file: Microsoft.Azure.Commands.EventGrid.dll-Help.xml
Module Name: AzureRM.EventGrid
online version: 
schema: 2.0.0
---

# Get-AzureRmEventGridTopicKey

## SYNOPSIS
Gets the shared access keys used to publish events to an Event Grid topic.

## SYNTAX

### TopicNameParameterSet (Default)
```
Get-AzureRmEventGridTopicKey [-ResourceGroupName] <String> [-Name] <String> [<CommonParameters>]
```

### TopicInputObjectParameterSet
```
Get-AzureRmEventGridTopicKey [-InputObject] <PSTopic> [<CommonParameters>]
```

## DESCRIPTION
Gets the shared access keys used to publish events to an Event Grid topic.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmEventGridTopicKey -ResourceGroup MyResourceGroupName -Name Topic1
```

Gets the shared access keys of Event Grid topic \`Topic1\` in resource group \`MyResourceGroupName\`.

### Example 2
```
PS C:\> Get-AzureRmEventGridTopic -ResourceGroup MyResourceGroupName -Name Topic1 | Get-AzureRmEventGridTopicKey
```

Gets the shared access keys of Event Grid topic \`Topic1\` in resource group \`MyResourceGroupName\`.

## PARAMETERS

### -InputObject
EventGrid Topic object.```yaml
Type: PSTopic
Parameter Sets: TopicInputObjectParameterSet
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
EventGrid Topic Name.

```yaml
Type: String
Parameter Sets: TopicNameParameterSet
Aliases: TopicName

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: TopicNameParameterSet
Aliases: ResourceGroup

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

## OUTPUTS

### Microsoft.Azure.Management.EventGrid.Models.TopicSharedAccessKeys

## NOTES

## RELATED LINKS

