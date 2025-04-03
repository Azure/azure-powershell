---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-AzPurviewPowerBIDataSourceObject
schema: 2.0.0
---

# New-AzPurviewPowerBIDataSourceObject

## SYNOPSIS
Create an in-memory object for PowerBIDataSource.

## SYNTAX

```
New-AzPurviewPowerBIDataSourceObject -Kind <DataSourceType> [-CollectionReferenceName <String>]
 [-CollectionType <String>] [-Tenant <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for PowerBIDataSource.

## EXAMPLES

### Example 1: Create PowerBI data source object
```powershell
New-AzPurviewPowerBIDataSourceObject -Kind 'PowerBI' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -Tenant 'xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxx'
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : PowerBI
LastModifiedAt           :
Name                     :
Scan                     :
Tenant                   : xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxx
```

Create PowerBI data source object

## PARAMETERS

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

### -Tenant


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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.PowerBiDataSource

## NOTES

## RELATED LINKS

