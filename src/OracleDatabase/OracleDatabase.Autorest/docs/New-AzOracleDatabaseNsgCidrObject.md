---
external help file:
Module Name: Az.OracleDatabase
online version: https://learn.microsoft.com/powershell/module/Az.OracleDatabase/new-azoracledatabasensgcidrobject
schema: 2.0.0
---

# New-AzOracleDatabaseNsgCidrObject

## SYNOPSIS
Create an in-memory object for NsgCidr.

## SYNTAX

```
New-AzOracleDatabaseNsgCidrObject -Source <String> [-DestinationPortRangeMax <Int32>]
 [-DestinationPortRangeMin <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NsgCidr.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -DestinationPortRangeMax
The maximum port number, which must not be less than the minimum port number.
To specify a single port number, set both the min and max to the same value.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestinationPortRangeMin
The minimum port number, which must not be greater than the maximum port number.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Source
Conceptually, this is the range of IP addresses that a packet coming into the instance can come from.

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

### Microsoft.Azure.PowerShell.Cmdlets.OracleDatabase.Models.NsgCidr

## NOTES

## RELATED LINKS

