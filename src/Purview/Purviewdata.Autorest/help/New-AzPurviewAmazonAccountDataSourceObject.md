---
external help file:
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-AzPurviewAmazonAccountDataSourceObject
schema: 2.0.0
---

# New-AzPurviewAmazonAccountDataSourceObject

## SYNOPSIS
Create an in-memory object for AmazonAccountDataSource.

## SYNTAX

```
New-AzPurviewAmazonAccountDataSourceObject -Kind <DataSourceType> [-AwsAccountId <String>]
 [-CollectionReferenceName <String>] [-CollectionType <String>] [-RoleArn <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AmazonAccountDataSource.

## EXAMPLES

### Example 1: Create Amazon Account data source object
```powershell
New-AzPurviewAmazonAccountDataSourceObject -Kind 'AmazonAccount' -AwsAccountId 123456789012 -CollectionReferenceName parv-brs-2 -CollectionType 'CollectionReference'
```

```output
AwsAccountId             : 123456789012
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AmazonAccount
LastModifiedAt           :
Name                     :
RoleArn                  :
Scan                     :
```

Create Amazon Account data source object

## PARAMETERS

### -AwsAccountId


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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.AmazonAccountDataSource

## NOTES

## RELATED LINKS

