---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
Module Name: AzureRM.Profile
online version: 
schema: 2.0.0
---

# Set-AzureRmDefault

## SYNOPSIS
Sets a default in the current context

## SYNTAX

```
Set-AzureRmDefault [-ResourceGroupName <String>] [-WhatIf] [-Confirm]
```

## DESCRIPTION
The Set-AzureRmDefault cmdlet adds or changes the defaults in the current context.

## EXAMPLES

### Example 1
```
PS C:\> Set-AzureRmDefault -ResourceGroupName myResourceGroup

Id         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup
Name       : myResourceGroup
Properties : Microsoft.Azure.Management.Internal.Resources.Models.ResourceGroupProperties
Location   : eastus
ManagedBy  :
Tags       :
```

This command sets the default resource group to the resource group specified by the user.

## PARAMETERS

### -ResourceGroupName
Name of the resource group being set as default

```yaml
Type: String
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

### System.String


## OUTPUTS

### Microsoft.Azure.Management.Internal.Resources.Models.ResourceGroup


## NOTES

## RELATED LINKS

