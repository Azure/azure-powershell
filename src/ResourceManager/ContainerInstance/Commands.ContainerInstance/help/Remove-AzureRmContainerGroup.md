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

```
Remove-AzureRmContainerGroup [-ResourceGroupName] <String> [-Name] <String>
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

## PARAMETERS

### -Name
The container group name.

```yaml
Type: String
Parameter Sets: (All)
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
Parameter Sets: (All)
Aliases: 

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

## INPUTS

### System.String


## OUTPUTS

### Microsoft.Azure.Commands.ContainerInstance.Models.PSContainerGroup


## NOTES

## RELATED LINKS

