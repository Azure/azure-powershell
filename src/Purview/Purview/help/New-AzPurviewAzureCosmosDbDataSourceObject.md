---
external help file: Az.Purview-help.xml
Module Name: Az.Purview
online version: https://docs.microsoft.com/powershell/module/az.Purview/new-AzPurviewAzureCosmosDbDataSourceObject
schema: 2.0.0
---

# New-AzPurviewAzureCosmosDbDataSourceObject

## SYNOPSIS
Create an in-memory object for AzureCosmosDbDataSource.

## SYNTAX

```
New-AzPurviewAzureCosmosDbDataSourceObject -Kind <DataSourceType> [-AccountUri <String>]
 [-CollectionReferenceName <String>] [-CollectionType <String>] [-Location <String>] [-ResourceGroup <String>]
 [-ResourceName <String>] [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for AzureCosmosDbDataSource.

## EXAMPLES

### Example 1: Create Azure CosmosDB data source object
```powershell
New-AzPurviewAzureCosmosDbDataSourceObject -Kind 'AzureCosmosDb' -CollectionReferenceName 'parv-brs-2' -CollectionType 'CollectionReference' -AccountUri 'https://cosmosd.documents.azure.com'
```

```output
AccountUri               : https://cosmosd.documents.azure.com
CollectionLastModifiedAt :
CollectionReferenceName  : parv-brs-2
CollectionType           : CollectionReference
CreatedAt                :
Id                       :
Kind                     : AzureCosmosDb
LastModifiedAt           :
Location                 :
Name                     :
ResourceGroup            :
ResourceName             :
Scan                     :
SubscriptionId           :
```

Create Azure CosmosDB data source object

## PARAMETERS

### -AccountUri

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

### -Location

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

### -ResourceGroup

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

### -ResourceName

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

### -SubscriptionId

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

### Microsoft.Azure.PowerShell.Cmdlets.Purviewdata.Models.Api20211001Preview.AzureCosmosDbDataSource

## NOTES

ALIASES

## RELATED LINKS
