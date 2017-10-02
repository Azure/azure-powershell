---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
Module Name: AzureRM.Profile
online version: 
schema: 2.0.0
---

# Clear-AzureRmDefault

## SYNOPSIS
Clears the defaults set by the user in the current context.

## SYNTAX

```
Clear-AzureRmDefault [-ResourceGroup] [-WhatIf] [-Confirm]
```

## DESCRIPTION
The Clear-AzureRmDefault cmdlet removes the defaults set by 
the user depending on the switch parameters specified by the user.

## EXAMPLES

### Example 1
```
PS C:\> Clear-AzureRmDefault
```

This command removes all the defaults set by the user in the current context.

### Example 1
```
PS C:\> Clear-AzureRmDefault -ResourceGroup
```

This command removes the default resource group set by the user in the current context.

## PARAMETERS

### -ResourceGroup
Clear Default Resource Group

```yaml
Type: SwitchParameter
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

## INPUTS

### System.Management.Automation.SwitchParameter


## OUTPUTS

### System.Object

## NOTES

## RELATED LINKS

