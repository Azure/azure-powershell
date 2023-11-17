---
external help file:
Module Name: Az.DataBox
online version: https://learn.microsoft.com/powershell/module/Az.DataBox/new-AzDataBoxTransferConfigurationObject
schema: 2.0.0
---

# New-AzDataBoxTransferConfigurationObject

## SYNOPSIS
Create an in-memory object for TransferConfiguration.

## SYNTAX

```
New-AzDataBoxTransferConfigurationObject -Type <TransferConfigurationType>
 [-TransferAllDetail <ITransferConfigurationTransferAllDetails>]
 [-TransferFilterDetail <ITransferConfigurationTransferFilterDetails>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for TransferConfiguration.

## EXAMPLES

### Example 1: In-memory object for export job transfer configuration 
```powershell
New-AzDataBoxTransferConfigurationObject -Type "TransferAll" -TransferAllDetail @{"IncludeDataAccountType"="StorageAccount";"IncludeTransferAllBlob"= "True"; "IncludeTransferAllFile"="True"}
```

Create a in-memory object for export jobs TransferConfiguration

## PARAMETERS

### -TransferAllDetail
Map of filter type and the details to transfer all data.
This field is required only if the TransferConfigurationType is given as TransferAll.
To construct, see NOTES section for TRANSFERALLDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.ITransferConfigurationTransferAllDetails
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TransferFilterDetail
Map of filter type and the details to filter.
This field is required only if the TransferConfigurationType is given as TransferUsingFilter.
To construct, see NOTES section for TRANSFERFILTERDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.ITransferConfigurationTransferFilterDetails
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Type
Type of the configuration for transfer.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Support.TransferConfigurationType
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.Api20221201.TransferConfiguration

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`TRANSFERALLDETAIL <ITransferConfigurationTransferAllDetails>`: Map of filter type and the details to transfer all data. This field is required only if the TransferConfigurationType is given as TransferAll.
  - `[IncludeDataAccountType <DataAccountType?>]`: Type of the account of data
  - `[IncludeTransferAllBlob <Boolean?>]`: To indicate if all Azure blobs have to be transferred
  - `[IncludeTransferAllFile <Boolean?>]`: To indicate if all Azure Files have to be transferred

`TRANSFERFILTERDETAIL <ITransferConfigurationTransferFilterDetails>`: Map of filter type and the details to filter. This field is required only if the TransferConfigurationType is given as TransferUsingFilter.
  - `[AzureFileFilterDetailFilePathList <String[]>]`: List of full path of the files to be transferred.
  - `[AzureFileFilterDetailFilePrefixList <String[]>]`: Prefix list of the Azure files to be transferred.
  - `[AzureFileFilterDetailFileShareList <String[]>]`: List of file shares to be transferred.
  - `[BlobFilterDetailBlobPathList <String[]>]`: List of full path of the blobs to be transferred.
  - `[BlobFilterDetailBlobPrefixList <String[]>]`: Prefix list of the Azure blobs to be transferred.
  - `[BlobFilterDetailContainerList <String[]>]`: List of blob containers to be transferred.
  - `[IncludeDataAccountType <DataAccountType?>]`: Type of the account of data.
  - `[IncludeFilterFileDetail <IFilterFileDetails[]>]`: Details of the filter files to be used for data transfer.
    - `FilterFilePath <String>`: Path of the file that contains the details of all items to transfer.
    - `FilterFileType <FilterFileType>`: Type of the filter file.

## RELATED LINKS

