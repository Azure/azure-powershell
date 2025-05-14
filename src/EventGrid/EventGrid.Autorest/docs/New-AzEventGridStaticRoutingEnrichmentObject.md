---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridstaticroutingenrichmentobject
schema: 2.0.0
---

# New-AzEventGridStaticRoutingEnrichmentObject

## SYNOPSIS
Create an in-memory object for StaticRoutingEnrichment.

## SYNTAX

```
New-AzEventGridStaticRoutingEnrichmentObject [-Key <String>] [-ValueType <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StaticRoutingEnrichment.

## EXAMPLES

### Example 1: Create an in-memory object for StaticRoutingEnrichment.
```powershell
New-AzEventGridStaticRoutingEnrichmentObject -Key "TestKey" -ValueType "TestType"
```

```output
Key     ValueType
---     ---------
TestKey TestType
```

Create an in-memory object for StaticRoutingEnrichment.

## PARAMETERS

### -Key
Static routing enrichment key.

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

### -ValueType
Static routing enrichment value type.
For e.g.
this property value can be 'String'.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.StaticRoutingEnrichment

## NOTES

## RELATED LINKS

