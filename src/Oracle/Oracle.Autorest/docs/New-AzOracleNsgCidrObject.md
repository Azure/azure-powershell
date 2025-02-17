---
external help file:
Module Name: Az.Oracle
online version: https://learn.microsoft.com/powershell/module/Az.Oracle/new-azoraclensgcidrobject
schema: 2.0.0
---

# New-AzOracleNsgCidrObject

## SYNOPSIS
Create an in-memory object for NsgCidr.

## SYNTAX

```
New-AzOracleNsgCidrObject -Source <String> [-DestinationPortRangeMax <Int32>]
 [-DestinationPortRangeMin <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NsgCidr.

## EXAMPLES

### Example 1: Create an in-memory object for NsgCidr
```powershell
New-AzOracleNsgCidrObject -Source "source" -DestinationPortRangeMax 0 -DestinationPortRangeMin 1
```

Create an in-memory object for NsgCidr.
For more information, execute `Get-Help New-AzOracleNsgCidrObject`.

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

### Microsoft.Azure.PowerShell.Cmdlets.Oracle.Models.NsgCidr

## NOTES

## RELATED LINKS

