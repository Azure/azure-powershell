---
external help file: Az.EventHub-help.xml
Module Name: Az.EventHub
online version: https://learn.microsoft.com/powershell/module/az.eventhub/new-azeventhubconsumergroup
schema: 2.0.0
---

# New-AzEventHubConsumerGroup

## SYNOPSIS
Create an Event Hubs consumer group as a nested resource within a Namespace.

## SYNTAX

### CreateExpanded (Default)
```
New-AzEventHubConsumerGroup -Name <String> -EventHubName <String> -NamespaceName <String>
 -ResourceGroupName <String> [-SubscriptionId <String>] [-UserMetadata <String>] [-DefaultProfile <PSObject>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNamespaceExpanded
```
New-AzEventHubConsumerGroup -Name <String> -EventHubName <String> -NamespaceInputObject <IEventHubIdentity>
 [-UserMetadata <String>] [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityNamespace
```
New-AzEventHubConsumerGroup -Name <String> -EventHubName <String> -NamespaceInputObject <IEventHubIdentity>
 -Parameter <IConsumerGroup> [-DefaultProfile <PSObject>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityEventhubExpanded
```
New-AzEventHubConsumerGroup -Name <String> -EventhubInputObject <IEventHubIdentity> [-UserMetadata <String>]
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaIdentityEventhub
```
New-AzEventHubConsumerGroup -Name <String> -EventhubInputObject <IEventHubIdentity> -Parameter <IConsumerGroup>
 [-DefaultProfile <PSObject>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create an Event Hubs consumer group as a nested resource within a Namespace.

## EXAMPLES

### Example 1: Create an EventHub ConsumerGroup
```powershell
New-AzEventHubConsumerGroup -Name myConsumerGroup -NamespaceName myNamespace -ResourceGroupName myResourceGroup -EventHubName myEventHub -UserMetadata "Test ConsumerGroup"
```

```output
CreatedAt                    : 9/13/2022 9:20:47 AM
Id                           : /subscriptions/subscriptionId/resourceGroups/myResourceGroup/providers/Microsoft.EventHub/namespaces/myNamespace
                               /eventhubs/eh1/consumergroups/myConsumerGroup
Location                     : australiaeast
Name                         : myConsumerGroup
ResourceGroupName            : myResourceGroup
UpdatedAt                    : 9/13/2022 9:20:47 AM
UserMetadata                 : Test ConsumerGroup
```

Creates a new consumer group `myConsumerGroup` for EventHubs entity `myEventHub`.

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

### -EventhubInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: CreateViaIdentityEventhubExpanded, CreateViaIdentityEventhub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -EventHubName
The Event Hub name

```yaml
Type: System.String
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The consumer group name

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ConsumerGroupName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity
Parameter Sets: CreateViaIdentityNamespaceExpanded, CreateViaIdentityNamespace
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -NamespaceName
The Namespace name

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Parameter
Single item in List or Get Consumer group operation

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IConsumerGroup
Parameter Sets: CreateViaIdentityNamespace, CreateViaIdentityEventhub
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Name of the resource group within the azure subscription.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
Subscription credentials that uniquely identify a Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
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
Parameter Sets: CreateExpanded, CreateViaIdentityNamespaceExpanded, CreateViaIdentityEventhubExpanded
Aliases:

Required: False
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

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IConsumerGroup

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IEventHubIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventHub.Models.IConsumerGroup

## NOTES

## RELATED LINKS
