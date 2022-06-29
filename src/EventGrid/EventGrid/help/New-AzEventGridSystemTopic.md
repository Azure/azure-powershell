---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# New-AzEventGridSystemTopic

## SYNOPSIS
Creates a new Azure Event Grid System Topic.

## SYNTAX

### TopicNameParameterSet (Default)
```
New-AzEventGridSystemTopic [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SystemTopicNameParameterSet
```
New-AzEventGridSystemTopic -ResourceGroupName <String> -Name <String> -Source <String> -TopicType <String>
 [-Location <String>] [-IdentityType <String>] [-IdentityId <String[]>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Creates a new Azure Event System Grid Topic. Once the system topic is created, an azure service application can publish events to the system topic.

## EXAMPLES

### Example 1
```powershell
New-AzEventGridSystemTopic -ResourceGroupName MyResourceGroupName -Name Topic1 -Source ServiceBusNamespaceResourceId -TopicType 'Microsoft.ServiceBus.Namespaces' -Location westus2
```

Creates an Event Grid System topic \`Topic1\`  for the Azure ServiceBus namespace with resource id \`ServiceBusNamespaceResourceId\`  in the specified geographic location \`westus2\`, in resource group \`MyResourceGroupName\`.

### Example 2
```powershell
New-AzEventGridSystemTopic -ResourceGroupName MyResourceGroupName -Name Topic1 -Source ServiceBusNamespaceResourceId -TopicType 'Microsoft.ServiceBus.Namespaces' -Location westus2 -Tag @{ Department="Finance"; Environment="Test" }
```

Creates an Event Grid System topic \`Topic1\` for the Azure ServiceBus namespace with resource id \`ServiceBusNamespaceResourceId\` in the specified geographic location \`westus2\`, in resource group \`MyResourceGroupName\` with the specified tags "Department" and "Environment".

### Example 3
```powershell
$id1 = '/subscriptions/{subscriptionId}/resourceGroups/{resourcegroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName'
$id2 = '/subscriptions/{subscriptionId}/resourceGroups/{resourcegroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName'

New-AzEventGridSystemTopic -ResourceGroupName MyResourceGroupName -Name Topic1 -Source ServiceBusNamespaceResourceId -TopicType 'Microsoft.ServiceBus.Namespaces' -Location westus2 -IdentityType "UserAssigned" -IdentityId $id1,$id2
```

Creates an Event Grid System topic \`Topic1\`  for the Azure ServiceBus namespace with resource id \`ServiceBusNamespaceResourceId\`  in the specified geographic location \`westus2\`, in resource group \`MyResourceGroupName\` with \`UserAssigned\` identity type with given identity ids.

### Example 4
```powershell
New-AzEventGridSystemTopic -ResourceGroupName MyResourceGroupName -Name Topic1 -Source ServiceBusNamespaceResourceId -TopicType 'Microsoft.ServiceBus.Namespaces' -Location westus2 -IdentityType "SystemAssigned"
```

Creates an Event Grid System topic \`Topic1\`  for the Azure ServiceBus namespace with resource id \`ServiceBusNamespaceResourceId\`  in the specified geographic location \`westus2\`, in resource group \`MyResourceGroupName\` with \`SystemAssigned\` identity type.

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

### -IdentityId
The list of user assigned identities

```yaml
Type: System.String[]
Parameter Sets: SystemTopicNameParameterSet
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
Type: System.String
Parameter Sets: SystemTopicNameParameterSet
Aliases:
Accepted values: SystemAssigned, UserAssigned, SystemAssigned, UserAssigned, None

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
The location of the topic.

```yaml
Type: System.String
Parameter Sets: SystemTopicNameParameterSet
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
Type: System.String
Parameter Sets: SystemTopicNameParameterSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

### -Source
Source for a system topic

```yaml
Type: System.String
Parameter Sets: SystemTopicNameParameterSet
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
Type: System.Collections.Hashtable
Parameter Sets: SystemTopicNameParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -TopicType
EventGrid topic type name.

```yaml
Type: System.String
Parameter Sets: SystemTopicNameParameterSet
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

### System.String[]

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSSystemTopic

## NOTES

## RELATED LINKS
