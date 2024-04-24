---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://learn.microsoft.com/powershell/module/Az.Purview/new-AzPurviewAmazonSqlDataSourceObject
schema: 2.0.0
---

# New-AzPurviewAmazonSqlDataSourceObject

## SYNOPSIS
Create an in-memory object for AmazonSqlDataSource.

## SYNTAX

```
New-AzPurviewAmazonSqlDataSourceObject -Kind <DataSourceType> [-CollectionReferenceName <String>]
 [-CollectionType <String>] [-Port <Int32>] [-ServerEndpoint <String>] [-VpcEndpointServiceName <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AmazonSqlDataSource.

## EXAMPLES

### Example 1: Create Amazon SQL data source object
```powershell
New-AzPurviewAmazonSqlDataSourceObject -Kind 'AmazonSql' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -Port 1433 -ServerEndpoint DummyEdnpoint -VpcEndpointServiceName com.amazonaws.ypce.wus.123456789
```

```output
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AmazonSql
LastModifiedAt           :
Name                     :
Port                     : 1433
Scan                     :
ServerEndpoint           : DummyEdnpoint
VpcEndpointServiceName   : com.amazonaws.ypce.wus.123456789
```

Create Amazon SQL data source object

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

### -Port

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerEndpoint

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

### -VpcEndpointServiceName

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.AmazonSqlDataSource

## NOTES

## RELATED LINKS
