---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgriddynamicroutingenrichmentobject
schema: 2.0.0
---

# New-AzEventGridDynamicRoutingEnrichmentObject

## SYNOPSIS
Create an in-memory object for DynamicRoutingEnrichment.

## SYNTAX

```
New-AzEventGridDynamicRoutingEnrichmentObject [-Key <String>] [-Value <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DynamicRoutingEnrichment.

## EXAMPLES

### Example 1: Create an in-memory object for DynamicRoutingEnrichment.
```powershell
New-AzEventGridDynamicRoutingEnrichmentObject -Key key1 -Value vaule1
```

```output
Key  Value
---  -----
key1 vaule1
```

Create an in-memory object for DynamicRoutingEnrichment.

## PARAMETERS

### -Key
Dynamic routing enrichment key.

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

### -Value
Dynamic routing enrichment value.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.DynamicRoutingEnrichment

## NOTES

## RELATED LINKS

