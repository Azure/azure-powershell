---
external help file: Az.ApplicationInsights-help.xml
Module Name: Az.ApplicationInsights
online version: https://learn.microsoft.com/powershell/module/az.ApplicationInsights/new-AzApplicationInsightsWebTestHeaderFieldObject
schema: 2.0.0
---

# New-AzApplicationInsightsWebTestHeaderFieldObject

## SYNOPSIS
Create a in-memory object for HeaderField

## SYNTAX

```
New-AzApplicationInsightsWebTestHeaderFieldObject [-Name <String>] [-Value <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for HeaderField

## EXAMPLES

### Example 1: Create a in-memory object for HeaderField
```powershell
New-AzApplicationInsightsWebTestHeaderFieldObject -Name 'version' -Value '2.0.1'
```

```output
Name    Value
----    -----
version 2.0.1
```

This command creates a in-memory object for HeaderField,  As value of the `RequestHeader` parameter in `New-AzApplicationInsightsWebTest`.

## PARAMETERS

### -Name
The name of the header.

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
The value of the header.

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

### Microsoft.Azure.PowerShell.Cmdlets.ApplicationInsights.Models.Api20220615.HeaderField

## NOTES

## RELATED LINKS
