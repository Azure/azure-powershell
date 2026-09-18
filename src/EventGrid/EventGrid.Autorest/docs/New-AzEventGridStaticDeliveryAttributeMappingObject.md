---
external help file:
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgridstaticdeliveryattributemappingobject
schema: 2.0.0
---

# New-AzEventGridStaticDeliveryAttributeMappingObject

## SYNOPSIS
Create an in-memory object for StaticDeliveryAttributeMapping.

## SYNTAX

```
New-AzEventGridStaticDeliveryAttributeMappingObject [-IsSecret <Boolean>] [-Name <String>] [-Value <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for StaticDeliveryAttributeMapping.

## EXAMPLES

### Example 1: Create an in-memory object for StaticDeliveryAttributeMapping.
```powershell
New-AzEventGridStaticDeliveryAttributeMappingObject -IsSecret:$true -Name "testName" -Value "testValue"
```

```output
Name
----
testName
```

Create an in-memory object for StaticDeliveryAttributeMapping.

## PARAMETERS

### -IsSecret
Boolean flag to tell if the attribute contains sensitive information .

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -Value
Value of the delivery attribute.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.StaticDeliveryAttributeMapping

## NOTES

## RELATED LINKS

