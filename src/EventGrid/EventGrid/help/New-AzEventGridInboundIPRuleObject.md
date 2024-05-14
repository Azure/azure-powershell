---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridinboundipruleobject
schema: 2.0.0
---

# New-AzEventGridInboundIPRuleObject

## SYNOPSIS
Create an in-memory object for InboundIPRule.

## SYNTAX

```
New-AzEventGridInboundIPRuleObject [-Action <String>] [-IPMask <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for InboundIPRule.

## EXAMPLES

### Example 1: Create an in-memory object for InboundIPRule.
```powershell
New-AzEventGridInboundIPRuleObject -Action Allow -IPMask "12.18.176.1"
```

```output
Action IPMask
------ ------
Allow  12.18.176.1
```

Create an in-memory object for InboundIPRule.

## PARAMETERS

### -Action
Action to perform based on the match or no match of the IpMask.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPMask
IP Address in CIDR notation e.g., 10.0.0.0/8.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.InboundIPRule

## NOTES

## RELATED LINKS
