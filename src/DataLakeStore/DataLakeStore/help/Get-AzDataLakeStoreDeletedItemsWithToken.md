---
external help file: Microsoft.Azure.PowerShell.Cmdlets.DataLakeStore.dll-Help.xml
Module Name: Az.DataLakeStore
online version: https://learn.microsoft.com/powershell/module/az.datalakestore/get-azdatalakestoredeleteditemswithtoken
schema: 2.0.0
---

# Get-AzDataLakeStoreDeletedItemsWithToken

## SYNOPSIS
Searches for deleted entries in the Data Lake Store trash using pagination support.

## SYNTAX

```
Get-AzDataLakeStoreDeletedItemsWithToken [-Account] <String> [-Filter] <String> [-Count <Int32>]
 [-ListAfter <String>] [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDataLakeStoreDeletedItemsWithToken** cmdlet searches for deleted files or folders in Azure Data Lake Store that match the specified filter criteria. This cmdlet provides pagination support for handling large result sets.

The cmdlet returns the following attributes for each deleted item:
- **OriginalPath**: The original location of the deleted item
- **TrashDirPath**: The current location in the trash directory
- **Type**: The item type (FILE or DIRECTORY)
- **CreationTime**: When the item was originally created
- **Continuation Token**: Token for pagination (if more results exist)

This operation may take considerable time when searching through millions of deleted files and can be run as a background job using the `-AsJob` parameter. When all results fit in a single page (1-4000 entries), the continuation token will be empty.

> **⚠️ Important**: 
> - File restoration is a best-effort operation with no guarantees
> - This feature requires account allowlisting
> - Non-allowlisted accounts will receive a "Not implemented" exception
> - Contact Microsoft support for enablement and assistance

## EXAMPLES

### Example 1: Search for deleted items.
```powershell
Get-AzDataLakeStoreDeletedItemsWithToken -Account "ml1ptrashtest" -Filter "test0/file_123"
```

```output
TrashDirPath                         OriginalPath                                          Type CreationTime         Continuation Token
------------                         ------------                                          ---- ------------         ------------------
cd6ad5ce-792b-4812-8a33-8f9ed19eb532 adl://ml1ptrashtest.azuredatalake.com/test0/file_1230 FILE 2/8/2019 8:12:18 AM
356cfd42-39c7-451e-96cb-9f47883d91e2 adl://ml1ptrashtest.azuredatalake.com/test0/file_1232 FILE 2/8/2019 8:12:18 AM
e7b30ac8-2dbc-43a3-8ca6-2d420ac0c488 adl://ml1ptrashtest.azuredatalake.com/test0/file_1237 FILE 2/8/2019 8:12:18 AM

```

This example searches for deleted items matching the pattern "test0/file_123".

### Example 2: Search for deleted items with pagination.
```powershell
Get-AzDataLakeStoreDeletedItemsWithToken -Account "ml1ptrashtest" -Filter "test0/file_123" -ListAfter "133862976000000000/co3aa1020309024/"
```

```output
TrashDirPath                         OriginalPath                                          Type CreationTime         Continuation Token
------------                         ------------                                          ---- ------------         ------------------
cd6ad5ce-792b-4812-8a33-8f9ed19eb532 adl://ml1ptrashtest.azuredatalake.com/test0/file_1230 FILE 2/8/2019 8:12:18 AM
356cfd42-39c7-451e-96cb-9f47883d91e2 adl://ml1ptrashtest.azuredatalake.com/test0/file_1232 FILE 2/8/2019 8:12:18 AM
e7b30ac8-2dbc-43a3-8ca6-2d420ac0c488 adl://ml1ptrashtest.azuredatalake.com/test0/file_1237 FILE 2/8/2019 8:12:18 AM
                                                                                                                     133862976000000000/co3aa1020309024/
```

This example searches for deleted items matching the pattern "test0/file_123" and continues from a previous pagination token.

## PARAMETERS

### -Account
The Data Lake Store account to execute the filesystem operation in

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AccountName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Count
Minimum number of entries to search for

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
The query string to match during search

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ListAfter
Token returned by system in the previous invocation

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Int32

## OUTPUTS

### Microsoft.Azure.Commands.DataLakeStore.Models.DataLakeStoreDeletedItemsWithToken

## NOTES
This cmdlet extends the functionality of `Get-AzDataLakeStoreDeletedItem` by adding pagination support. When dealing with large result sets, use the continuation token from the previous invocation with the `-ListAfter` parameter to retrieve subsequent pages of results.

## RELATED LINKS
[Get-AzDataLakeStoreDeletedItem](./Get-AzDataLakeStoreDeletedItem.md),  [Restore-AzDataLakeStoreDeletedItem](./Restore-AzDataLakeStoreDeletedItem.md)
