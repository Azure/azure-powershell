---
external help file: Microsoft.Azure.PowerShell.Cmdlets.EventGrid.dll-Help.xml
Module Name: Az.EventGrid
online version:
schema: 2.0.0
---

# Update-AzEventGridPartnerTopic

## SYNOPSIS
Updates the properties of an Event Grid partner topic.

## SYNTAX

### PartnerTopicNameParameterSet (Default)
```
Update-AzEventGridPartnerTopic [-ResourceGroupName] <String> [-Name] <String> [-Tag <Hashtable>]
 [-IdentityType <String>] [-IdentityId <String[]>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### PartnerTopicInputObjectParameterSet
```
Update-AzEventGridPartnerTopic [-InputObject] <PSPartnerTopic> [-Tag <Hashtable>] [-IdentityType <String>]
 [-IdentityId <String[]>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Updates the properties of an Event Grid partner topic. Can be used to update the identity and tags of a partner topic.

## EXAMPLES

### Example 1
```powershell
Update-AzEventGridPartnerTopic -ResourceGroup MyResourceGroupName -Name Topic1 -Tag @{ Department="Finance"; Environment="Test" }
```

Sets the properties of the Event Grid Partner topic \`Topic1\` in resource group \`MyResourceGroupName\` to replace the tags with the specified tags "Department" and "Environment".

### Example 2
```powershell
Update-AzEventGridPartnerTopic -ResourceGroup MyResourceGroupName -Name Topic1 -IdentityType "SystemAssigned"
```

Sets the properties of the Event Grid Partner topic \`Topic1\` in resource group \`MyResourceGroupName\` to change identity type to \`SystemAssigned\`.

### Example 3
```powershell
$id1 = '/subscriptions/{subscriptionId}/resourceGroups/{resourcegroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName'
$id2 = '/subscriptions/{subscriptionId}/resourceGroups/{resourcegroup}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/MSIName'

Update-AzEventGridPartnerTopic -ResourceGroup MyResourceGroupName -Name Topic1 -IdentityType "UserAssigned" -IdentityId $id1,$id2
```

Sets the properties of the Event Grid Partner topic \`Topic1\` in resource group \`MyResourceGroupName\` to change identity type to \`UserAssigned\` with given identity ids.


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

### -IdentityId
The list of user assigned identities

```yaml
Type: String[]
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases:
Accepted values: SystemAssigned, UserAssigned, SystemAssigned, UserAssigned, None

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -InputObject
PartnerTopic object.

```yaml
Type: PSPartnerTopic
Parameter Sets: PartnerTopicInputObjectParameterSet
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Event Grid partner topic name.

```yaml
Type: String
Parameter Sets: PartnerTopicNameParameterSet
Aliases: PartnerTopicName

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
Parameter Sets: PartnerTopicNameParameterSet
Aliases: ResourceGroup

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Hashtable which represents resource Tags.

```yaml
Type: Hashtable
Parameter Sets: (All)
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

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerTopic

### System.Collections.Hashtable

### System.String[]

## OUTPUTS

### Microsoft.Azure.Commands.EventGrid.Models.PSPartnerTopic

## NOTES

## RELATED LINKS
