---
external help file: Microsoft.Azure.Commands.EventGrid.dll-Help.xml
Module Name: AzureRM.EventGrid
online version:
schema: 2.0.0
---

# Get-AzureRmEventGridDomainTopic

## SYNOPSIS
Gets the details of an Event Grid domain topic, or gets a list of all Event Grid domain topics under specific Event Grid domain in the current Azure subscription.

## SYNTAX

### DomainTopicNameParameterSet (Default)
```
Get-AzureRmEventGridDomainTopic [-ResourceGroupName] <String> [-DomainName] <String>
 [[-DomainTopicName] <String>] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### ResourceIdEventSubscriptionParameterSet
```
Get-AzureRmEventGridDomainTopic [-ResourceId] <String> [-DefaultProfile <IAzureContextContainer>]
 [<CommonParameters>]
```

## DESCRIPTION
The Get-AzureRmEventGridDomainTopic cmdlet gets either the details of a specified Event Grid domain topic, or a list of all Event Grid domain topics under a specific domain in the current Azure subscription.
If the domain topic name is provided, the details of a single Event Grid domain topic is returned. 
If the domain topic name is not provided, a list of domain topics under the specified domain name is returned.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmEventGridDomainTopic -ResourceGroup MyResourceGroupName -DomainName Domain1 -DomainTopicName DomainTopic1
```

Gets the details of Event Grid domain topic \`DomainTopic1\` under Event Grid domain \`Domain1\` in resource group \`MyResourceGroupName\`.

### Example 2
```
PS C:\> Get-AzureRmEventGridDomainTopic -ResourceGroup MyResourceGroupName -DomainName Domain1
```

List all the Event Grid domain topics under Event Grid domain \`Domain1\` in resource group \`MyResourceGroupName\`.

### Example 3
```
PS C:\> Get-AzureRmEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/MyResourceGroupName/providers/Microsoft.EventGrid/domains/Domain1/topics/DomainTopic1"
```

Gets the details of Event Grid domain topic \`DomainTopic1\` under Event Grid domain \`Domain1\` in resource group \`MyResourceGroupName\`.

### Example 4
```
PS C:\> Get-AzureRmEventGridDomain -ResourceId "/subscriptions/$subscriptionId/resourceGroups/MyResourceGroupName/providers/Microsoft.EventGrid/domains/Domain1"
```

List all the Event Grid domain topics under Event Grid domain \`Domain1\` in resource group \`MyResourceGroupName\`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DomainName
EventGrid domain name.

```yaml
Type: String
Parameter Sets: DomainTopicNameParameterSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DomainTopicName
EventGrid domain topic name.

```yaml
Type: String
Parameter Sets: DomainTopicNameParameterSet
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: String
Parameter Sets: DomainTopicNameParameterSet
Aliases: ResourceGroup

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
Resource Identifier representing the Event Grid Domain or Grid Domain Topic.

```yaml
Type: String
Parameter Sets: ResourceIdEventSubscriptionParameterSet
Aliases:

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

### Microsoft.Azure.Commands.EventGrid.Models.PSDomainTopic

### System.Collections.Generic.List`1[[Microsoft.Azure.Commands.EventGrid.Models.PSDomainTopicListInstance, Microsoft.Azure.Commands.EventGrid, Version=0.3.3.0, Culture=neutral, PublicKeyToken=null]]

## NOTES

## RELATED LINKS
