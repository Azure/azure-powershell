---
external help file:
Module Name: Az.HdInsightOnAks
online version: https://learn.microsoft.com/powershell/module/Az.HdInsightOnAks/new-azhdinsightonaksclusterpypilibraryobject
schema: 2.0.0
---

# New-AzHdInsightOnAksClusterPyPiLibraryObject

## SYNOPSIS
Create an in-memory object for PyPiLibraryProperties.

## SYNTAX

```
New-AzHdInsightOnAksClusterPyPiLibraryObject -Name <String> [-Remark <String>] [-Version <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PyPiLibraryProperties.

## EXAMPLES

### Example 1: Create a library object for pypi.
```powershell
New-AzHdInsightOnAksClusterPyPiLibraryObject -Name pandas -Version 2.2.2 -Remark "Pandas Lib."
```

```output
PropertiesType               : pypi
Property                     : {
                                 "type": "pypi",
                                 "remarks": "test add pandas",
                                 "name": "pandas",
                                 "version": "2.2.2"
                               }
Remark                       : test add pandas
```

Create a library object for pypi.

## PARAMETERS

### -Name
Name of the PyPi package.

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

### -Remark
Remark of the latest library management operation.

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

### -Version
Version of the PyPi package.

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

### Microsoft.Azure.PowerShell.Cmdlets.HdInsightOnAks.Models.IClusterLibrary

## NOTES

## RELATED LINKS

