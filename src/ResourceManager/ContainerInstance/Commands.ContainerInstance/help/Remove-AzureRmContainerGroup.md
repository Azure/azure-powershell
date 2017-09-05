---
external help file: Microsoft.Azure.Commands.ContainerInstance.dll-Help.xml
Module Name: AzureRM.ContainerInstance
online version: 
schema: 2.0.0
---

# Remove-AzureRmContainerGroup

## SYNOPSIS
Removes a container group.

## SYNTAX

### RemoveContainerGroupByResourceGroupAndNameParamSet
```
Remove-AzureRmContainerGroup [-ResourceGroupName] <String> [-Name] <String> [-WhatIf] [-Confirm]
```

### RemoveContainerGroupByPSContainerGroupParamSet
```
Remove-AzureRmContainerGroup -InputObject <PSContainerGroup> [-WhatIf] [-Confirm]
```

### RemoveContainerGroupByResourceIdParamSet
```
Remove-AzureRmContainerGroup -ResourceId <String> [-WhatIf] [-Confirm]
```

## DESCRIPTION
The **Remove-AzureRmContainerGroup** cmdlet removes a container group.

## EXAMPLES

### Example 1: Removes a container group
```
PS C:\> Remove-AzureRmContainerGroup -ResourceGroupName MyResourceGroup -Name MyContainer
```

This command removes the specified container group.

### Example 2: Removes a container group by piping
```
PS C:\> Get-AzureRmContainerGroup -ResourceGroupName MyResourceGroup -Name MyContainer | Remove-AzureRmContainerGroup
```

This command removes a container group by piping.

### Example 3: Removes a container group by resource Id.
```
PS C:\> Find-AzureRmResource -ResourceGroupEquals MyResourceGroup -ResourceNameEquals MyContainer | Remove-AzureRmContainerGroup
```

This command removes a container group by resource Id.

## PARAMETERS

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

### -InputObject
The container group to remove.

```yaml
Type: PSContainerGroup
Parameter Sets: RemoveContainerGroupByPSContainerGroupParamSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The container group name.

```yaml
Type: String
Parameter Sets: RemoveContainerGroupByResourceGroupAndNameParamSet
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group name.

```yaml
Type: String
Parameter Sets: RemoveContainerGroupByResourceGroupAndNameParamSet
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: RemoveContainerGroupByResourceIdParamSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
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

## INPUTS

### System.String
Microsoft.Azure.Commands.ContainerInstance.Models.PSContainerGroup


## OUTPUTS

### Microsoft.Azure.Commands.ContainerInstance.Models.PSContainerGroup


## NOTES

## RELATED LINKS

