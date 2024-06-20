---
external help file: Az.EventGrid-help.xml
Module Name: Az.EventGrid
online version: https://learn.microsoft.com/powershell/module/Az.EventGrid/new-azeventgriddeliveryattributemappingobject
schema: 2.0.0
---

# New-AzEventGridDeliveryAttributeMappingObject

## SYNOPSIS
Create an in-memory object for DeliveryAttributeMapping.

## SYNTAX

```
New-AzEventGridDeliveryAttributeMappingObject -Type <String> [-Name <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeliveryAttributeMapping.

## EXAMPLES

### Example 1: Create an in-memory object for DeliveryAttributeMapping.
```powershell
New-AzEventGridDeliveryAttributeMappingObject -Type "TestType" -Name "TestName"
```

```output
Name
----
TestName
```

Create an in-memory object for DeliveryAttributeMapping.

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

### -Type
Type of the delivery attribute or header name.

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

### Microsoft.Azure.PowerShell.Cmdlets.EventGrid.Models.DeliveryAttributeMapping

## NOTES

## RELATED LINKS
