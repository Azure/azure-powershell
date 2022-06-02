---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Remove-AzEventGridSystemTopic

## SYNOPSIS
Removes an Azure Event Grid System Topic.

## SYNTAX

### TopicNameParameterSet (Default)
```
Remove-AzEventGridSystemTopic [-Force] [-PassThru] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### SystemTopicNameParameterSet
```
Remove-AzEventGridSystemTopic -ResourceGroupName <String> -Name <String> [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ResourceIdEventSubscriptionParameterSet
```
Remove-AzEventGridSystemTopic -ResourceId <String> [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### TopicInputObjectParameterSet
```
Remove-AzEventGridSystemTopic -InputObject <PSSystemTopic> [-Force] [-PassThru]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Removes an Azure Event Grid System Topic either by using name of system topic or by piping system topic object.

## EXAMPLES

### Example 1
```powershell
Remove-AzEventGridSystemTopic -ResourceGroupName MyResourceGroupName -Name Topic1
```

Removes the Event Grid System topic \`Topic1\` in resource group \`MyResourceGroupName\`.

### Example 2
```powershell
Get-AzResource -ResourceId "/subscriptions/$subscriptionId/resourceGroups/MyResourceGroupName/providers/Microsoft.EventGrid/systemTopics/Topic1" | Remove-AzEventGridSystemTopic
```

Removes the Event Grid System topic \`Topic1\` in resource group \`MyResourceGroupName\`.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Force
Indicates that the cmdlet does not prompt you for confirmation. By default, this cmdlet prompts you to confirm that you want to delete the resource

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

### -InputObject
EventGrid Topic object.

```yaml
Type: Microsoft.Azure.Commands.EventGrid.Models.PSSystemTopic
Parameter Sets: TopicInputObjectParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
EventGrid topic name.

```yaml
Type: System.String
Parameter Sets: SystemTopicNameParameterSet
Aliases: SystemTopicName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PassThru
Returns the status of the Remove operation. By default, this cmdlet does not generate any output.

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

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: SystemTopicNameParameterSet
Aliases: ResourceGroup

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
EventGrid System Topic ResourceID.

```yaml
Type: System.String
Parameter Sets: ResourceIdEventSubscriptionParameterSet
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

### System.String

### Microsoft.Azure.Commands.EventGrid.Models.PSSystemTopic

## OUTPUTS

### System.Boolean

## NOTES

## RELATED LINKS
