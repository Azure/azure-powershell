---
external help file: Azs.Subscriptions.Admin-help.xml
Module Name: Azs.Subscriptions.Admin
online version: 
schema: 2.0.0
---

# Get-AzsLocation

## SYNOPSIS
Get a list of all AzureStack location.

## SYNTAX

### List (Default)
```
Get-AzsLocation [<CommonParameters>]
```

### Get
```
Get-AzsLocation [-Name] <String> [<CommonParameters>]
```

## DESCRIPTION
Get a list of all AzureStack location.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsLocation
```

Get a list of all AzureStack locations.

## PARAMETERS

### -Name
The AzureStack location.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Subscriptions.Admin.Models.Location

## NOTES

## RELATED LINKS

