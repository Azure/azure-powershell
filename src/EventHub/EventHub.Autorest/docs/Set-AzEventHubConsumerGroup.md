---
external help file:
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/set-azeventhubconsumergroup
schema: 2.0.0
---

# Set-AzEventHubConsumerGroup

## SYNOPSIS
Sets an EventHub Consumer Group

## SYNTAX

### SetExpanded (Default)
```
Set-AzEventHubConsumerGroup -EventHubName <String> -Name <String> -NamespaceName <String>
 -ResourceGroupName <String> -UserMetadata <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### SetViaIdentityExpanded
```
Set-AzEventHubConsumerGroup -InputObject <IEventHubIdentity> -UserMetadata <String>
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Sets an EventHub Consumer Group

## EXAMPLES

### Example 1: Update EventHub Consumer Group
```powershell
Set-AzEventHubConsumerGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name myConsumerGroup -UserMetadata "Example Metadata"
```

```output
CreatedAt                    : 9/13/2022 9:20:47 AM
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
                               /eventhubs/eh1/consumergroups/myConsumerGroup
Location                     : australiaeast
Name                         : myConsumerGroup
ResourceGroupName            : myResourceGroup
UpdatedAt                    : 9/13/2022 9:20:47 AM
UserMetadata                 : Example Metadata
```

Updates consumer group `myConsumerGroup` created under EventHub entity `myEventHub`.

### Example 2: Update EventHub Consumer Group using InputObject parameter set
```powershell
$consumerGroup = Get-AzEventHubConsumerGroup -ResourceGroupName myResourceGroup -NamespaceName myNamespace -EventHubName myEventHub -Name myConsumerGroup
Set-AzEventHubConsumerGroup -InputObject $consumerGroup -UserMetadata "Example Metadata"
```

```output
CreatedAt                    : 9/13/2022 9:20:47 AM
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
                               /eventhubs/eh1/consumergroups/myConsumerGroup
Location                     : australiaeast
Name                         : myConsumerGroup
ResourceGroupName            : myResourceGroup
UpdatedAt                    : 9/13/2022 9:20:47 AM
UserMetadata                 : Example Metadata
```

Updates consumer group `myConsumerGroup` created under EventHub entity `myEventHub`.

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

### -EventHubName
The name of EventHub

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity parameter.
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: SetViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Consumer Group.

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases: ConsumerGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The name of EventHub namespace

```yaml
Type: System.String
Parameter Sets: SetExpanded
Aliases:

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: SetExpanded
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
Parameter Sets: SetExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserMetadata
User Metadata is a placeholder to store user-defined string data with maximum length 1024.
e.g.
it can be used to store descriptive data, such as list of teams and their contact information also user-defined configuration settings can be stored.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IConsumerGroup

## NOTES

## RELATED LINKS

