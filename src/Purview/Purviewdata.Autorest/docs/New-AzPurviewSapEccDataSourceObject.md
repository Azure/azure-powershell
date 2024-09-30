---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-AzPurviewSapEccDataSourceObject
schema: 2.0.0
---

# New-AzPurviewSapEccDataSourceObject

## SYNOPSIS
Create an in-memory object for SapEccDataSource.

## SYNTAX

```
New-AzPurviewSapEccDataSourceObject -Kind <DataSourceType> [-ApplicationServer <String>]
 [-CollectionReferenceName <String>] [-CollectionType <String>] [-SystemNumber <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SapEccDataSource.

## EXAMPLES

### Example 1: Create SAPECC data source object
```powershell
New-AzPurviewSapEccDataSourceObject -Kind 'SapEcc' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -ApplicationServer '12.13.14.12' -SystemNumber 32
```

```output
ApplicationServer        : 12.13.14.12
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : SapEcc
LastModifiedAt           :
Name                     :
Scan                     :
SystemNumber             : 32
```

Create SAPECC data source object

## PARAMETERS

### -ApplicationServer


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

### -CollectionReferenceName


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

### -CollectionType


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

### -Kind


```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Support.DataSourceType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SystemNumber


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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.SapEccDataSource

## NOTES

## RELATED LINKS

