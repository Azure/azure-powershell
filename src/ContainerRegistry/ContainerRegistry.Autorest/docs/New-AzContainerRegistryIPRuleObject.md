---
external help file:
Module Name: Az.ContainerRegistry
online version: https://learn.microsoft.com/powershell/module/az.ContainerRegistry/new-AzContainerRegistryIPRuleObject
schema: 2.0.0
---

# New-AzContainerRegistryIPRuleObject

## SYNOPSIS
Create an in-memory object for IPRule.

## SYNTAX

```
New-AzContainerRegistryIPRuleObject -IPAddressOrRange <String> [-Action <Action>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for IPRule.

## EXAMPLES

### Example 1: Create a IP network rule.
```powershell
 New-AzContainerRegistryIPRuleObject -IPAddressOrRange 0.0.0.0 -Action 'Allow'
```

```output
Action IPAddressOrRange
------ ----------------
Allow  0.0.0.0
```

Create a IP network rule.

## PARAMETERS

### -Action
The action of IP ACL rule.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Support.Action
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAddressOrRange
Specifies the IP or IP range in CIDR format.
Only IPV4 address is allowed.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerRegistry.Models.Api202301Preview.IPRule

## NOTES

ALIASES

## RELATED LINKS

