---
external help file: Microsoft.Azure.Commands.DataLakeAnalytics.dll-Help.xml
ms.assetid: A38D8BF6-D302-4586-B7AF-4C80B546E96F
online version: 
schema: 2.0.0
---

# Add-AzureRmDataLakeAnalyticsDataSource

## SYNOPSIS
Adds a data source to a Data Lake Analytics account.

## SYNTAX

### Add a Data Lake storage account
```
Add-AzureRmDataLakeAnalyticsDataSource [-Account] <String> [-DataLakeStore] <String>
 [[-ResourceGroupName] <String>] [<CommonParameters>]
```

### Add a Blob storage account
```
Add-AzureRmDataLakeAnalyticsDataSource [-Account] <String> [-Blob] <String> [-AccessKey] <String>
 [[-ResourceGroupName] <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmDataLakeAnalyticsDataSource** cmdlet adds a data source to an Azure Data Lake Analytics account.

## EXAMPLES

### Example 1: Add a data source to an account
```
PS C:\>Add-AzureRmDataLakeAnalyticsDataSource -Account "ContosoAdlA" -DataLakeStore "ContosoAdlS"
```

This command adds a Data Lake Store data source to a Data Lake Analytics account.

## PARAMETERS

### -AccessKey
Specifies the access key of the Azure Blob storage account to add.

```yaml
Type: String
Parameter Sets: Add a Blob storage account
Aliases: 

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Account
Specifies the Data Lake Analytics account name.

```yaml
Type: String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Blob
Specifies the name of the Azure Blob Storage account to add.

```yaml
Type: String
Parameter Sets: Add a Blob storage account
Aliases: AzureBlob

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DataLakeStore
Specifies the name of the Azure Data Lake Store account to add.

```yaml
Type: String
Parameter Sets: Add a Data Lake storage account
Aliases: 

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the resource group name of the Data Lake Analytics account.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### None

## NOTES

## RELATED LINKS

[Remove-AzureRmDataLakeAnalyticsDataSource](./Remove-AzureRmDataLakeAnalyticsDataSource.md)

[Set-AzureRmDataLakeAnalyticsDataSource](./Set-AzureRmDataLakeAnalyticsDataSource.md)


