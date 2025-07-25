---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgriddynamicdeliveryattributemappingobject
schema: 2.0.0
---

# New-AzEventGridDynamicDeliveryAttributeMappingObject

## SYNOPSIS
Create an in-memory object for DynamicDeliveryAttributeMapping.

## SYNTAX

```
New-AzEventGridDynamicDeliveryAttributeMappingObject [-Name <String>] [-SourceField <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DynamicDeliveryAttributeMapping.

## EXAMPLES

### Example 1: Create an in-memory object for DynamicDeliveryAttributeMapping.
```powershell
New-AzEventGridDynamicDeliveryAttributeMappingObject -Name "testname" -SourceField "testfield"
```

```output
Name
----
testname
```

Create an in-memory object for DynamicDeliveryAttributeMapping.

## PARAMETERS

### -Name
Name of the delivery attribute or header.

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

### -SourceField
JSON path in the event which contains attribute value.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.DynamicDeliveryAttributeMapping

## NOTES

## RELATED LINKS

