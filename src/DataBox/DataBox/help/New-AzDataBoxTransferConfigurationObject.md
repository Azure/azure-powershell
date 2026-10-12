---
external help file: Az.DataBox-help.xml
Module Name: Az.DataBox
online version: https://learn.microsoft.com/powershell/module/Az.DataBox/new-azdataboxtransferconfigurationobject
schema: 2.0.0
---

# New-AzDataBoxTransferConfigurationObject

## SYNOPSIS
Create an in-memory object for TransferConfiguration.

## SYNTAX

```
New-AzDataBoxTransferConfigurationObject -Type <String> [-AzureFileFilterDetailFilePathList <String[]>]
 [-AzureFileFilterDetailFilePrefixList <String[]>] [-AzureFileFilterDetailFileShareList <String[]>]
 [-BlobFilterDetailBlobPathList <String[]>] [-BlobFilterDetailBlobPrefixList <String[]>]
 [-BlobFilterDetailContainerList <String[]>] [-IncludeFilterFileDetail <IFilterFileDetails[]>]
 [-IncludeTransferAllBlob <Boolean>] [-IncludeTransferAllFile <Boolean>]
 [-TransferAllDetailsIncludeDataAccountType <String>] [-TransferFilterDetailsIncludeDataAccountType <String>]
 [<CommonParameters>]
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

### -AzureFileFilterDetailFilePathList
List of full path of the files to be transferred.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureFileFilterDetailFilePrefixList
Prefix list of the Azure files to be transferred.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureFileFilterDetailFileShareList
List of file shares to be transferred.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobFilterDetailBlobPathList
List of full path of the blobs to be transferred.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobFilterDetailBlobPrefixList
Prefix list of the Azure blobs to be transferred.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobFilterDetailContainerList
List of blob containers to be transferred.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeFilterFileDetail
Details of the filter files to be used for data transfer.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.IFilterFileDetails[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTransferAllBlob
To indicate if all Azure blobs have to be transferred.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IncludeTransferAllFile
To indicate if all Azure Files have to be transferred.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TransferAllDetailsIncludeDataAccountType
Type of the account of data.

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

### -TransferFilterDetailsIncludeDataAccountType
Type of the account of data.

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

### -Type
Type of the configuration for transfer.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DataBox.Models.TransferConfiguration

## NOTES

## RELATED LINKS
