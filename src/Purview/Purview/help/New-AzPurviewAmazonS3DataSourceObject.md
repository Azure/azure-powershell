---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-azpurviewamazons3datasourceobject
schema: 2.0.0
---

# New-AzPurviewAmazonS3DataSourceObject

## SYNOPSIS
Create an in-memory object for AmazonS3DataSource.

## SYNTAX

```
New-AzPurviewAmazonS3DataSourceObject [-CollectionReferenceName <String>] [-CollectionType <String>]
 [-RoleArn <String>] [-ServiceUrl <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AmazonS3DataSource.

## EXAMPLES

### Example 1: Create AmazonS3 data source object
```powershell
New-AzPurviewAmazonS3DataSourceObject -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -ServiceUrl s3://multicloud-e2e-2
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AmazonS3
LastModifiedAt           :
Name                     :
RoleArn                  :
Scan                     :
ServiceUrl               : s3://multicloud-e2e-2
```

Create AmazonS3 data source object

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

### -RoleArn

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

### -ServiceUrl

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.AmazonS3DataSource

## NOTES

## RELATED LINKS
