---
external help file: Microsoft.Azure.Commands.ContainerRegistry.dll-Help.xml
online version: 
schema: 2.0.0
---

# Remove-AzureRmContainerRegistry

## SYNOPSIS
Removes a container registry.

## SYNTAX

### NameResourceGroupParameterSet (Default)
```
Remove-AzureRmContainerRegistry [-ResourceGroupName] <String> [-Name] <String> [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### RegistryObjectParameterSet
```
Remove-AzureRmContainerRegistry -Registry <PSContainerRegistry> [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Remove-AzureRmContainerRegistry** cmdlet removes a container registry.

## EXAMPLES

### Example 1: Remove a specified container registry
```
PS C:\>Remove-AzureRmContainerRegistry -ResourceGroupName "MyResourceGroup" -Name "MyRegistry"
```

This command removes the specified container registry.

## PARAMETERS

### -Name
Container Registry Name.

```yaml
Type: String
Parameter Sets: NameResourceGroupParameterSet
Aliases: ContainerRegistryName, RegistryName, ResourceName

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Registry
Container Registry Object.

```yaml
Type: PSContainerRegistry
Parameter Sets: RegistryObjectParameterSet
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
Resource Group Name.

```yaml
Type: String
Parameter Sets: NameResourceGroupParameterSet
Aliases: 

Required: True
Position: 0
Default value: None
Accept pipeline input: False
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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PSContainerRegistry

Parameter 'Registry' accepts value of type 'PSContainerRegistry' from the pipeline

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[New-AzureRmContainerRegistry](./New-AzureRmContainerRegistry.md)

[Get-AzureRmContainerRegistry](./Get-AzureRmContainerRegistry.md)

[Update-AzureRmContainerRegistry](./Update-AzureRmContainerRegistry.md)

