---
external help file: Microsoft.Azure.Commands.Profile.dll-Help.xml
Module Name: AzureRM.Profile
online version: 
schema: 2.0.0
---

# Get-AzureRmDefault

## SYNOPSIS
Get the defaults set by the user in the current context.

## SYNTAX

```
Get-AzureRmDefault [-ResourceGroup]
```

## DESCRIPTION
The Get-AzureRmDefault cmdlet gets the Resource Group that the 
user has set as default in the current context.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzureRmDefault

Id         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup
Name       : myResourceGroup
Properties : Microsoft.Azure.Management.Internal.Resources.Models.ResourceGroupProperties
Location   : eastus
ManagedBy  :
Tags       :
```

This command returns the current defaults if there are defaults set, or returns nothing if no default is set.

### Example 2
```
PS C:\> Get-AzureRmDefault -ResourceGroup

Id         : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/myResourceGroup
Name       : myResourceGroup
Properties : Microsoft.Azure.Management.Internal.Resources.Models.ResourceGroupProperties
Location   : eastus
ManagedBy  :
Tags       :
```

This command returns the current default Resource Group if there is a default set, or returns nothing if no default is set.

## PARAMETERS

### -ResourceGroup
Display Default Resource Group

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

## INPUTS

### System.Management.Automation.SwitchParameter


## OUTPUTS

### Microsoft.Azure.Management.Internal.Resources.Models.ResourceGroup


## NOTES

## RELATED LINKS

