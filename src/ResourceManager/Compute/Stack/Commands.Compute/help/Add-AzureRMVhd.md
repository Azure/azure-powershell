---
external help file: Microsoft.Azure.Commands.Compute.dll-Help.xml
ms.assetid: D08DAA8B-B7BF-4167-AB16-F2723985A0B7
online version: 
schema: 2.0.0
---

# Add-AzureRmVhd

## SYNOPSIS
Uploads a virtual hard disk from an on-premises virtual machine to a blob in a cloud storage account in Azure.

## SYNTAX

```
Add-AzureRmVhd [[-ResourceGroupName] <String>] [-Destination] <Uri> [-LocalFilePath] <FileInfo>
 [[-NumberOfUploaderThreads] <Int32>] [[-BaseImageUriToPatch] <Uri>] [-OverWrite] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzureRmVhd** cmdlet uploads on-premises virtual hard disks, in .vhd file format, to a blob storage account as fixed virtual hard disks.
You can configure the number of uploader threads that will be used or overwrite an existing blob in the specified destination URI.
Also supported is the ability to upload a patched version of an on-premises .vhd file.
When a base virtual hard disk has already been uploaded, you can upload differencing disks that use the base image as the parent.
Shared access signature (SAS) URI is supported also.

## EXAMPLES

### Example 1: Add a VHD file
```
PS C:\> Add-AzureRmVhd -Destination "http://contosoaccount.blob.core.windows.net/vhdstore/win7baseimage.vhd" -LocalFilePath "C:\vhd\Win7Image.vhd"
```

This command adds a .vhd file to a storage account.

### Example 2: Add a VHD file and overwrite the destination
```
PS C:\> Add-AzureRmVhd -Destination "http://contosoaccount.blob.core.windows.net/vhdstore/win7baseimage.vhd" -LocalFilePath "C:\vhd\Win7Image.vhd" -Overwrite
```

This command adds a .vhd file to a storage account.
The command overwrites an existing file.

### Example 3: Add a VHD file and specify the number of threads
```
PS C:\> Add-AzureRmVhd -Destination "http://contosoaccount.blob.core.windows.net/vhdstore/win7baseimage.vhd" -LocalFilePath "C:\vhd\Win7Image.vhd" -NumberOfUploaderThreads 32
```

This command adds a .vhd file to a storage account.
The command specifies the number of threads to use to upload the file.

### Example 4: Add a VHD file and specify the SAS URI
```
PS C:\> Add-AzureRmVhd -Destination "http://contosoaccount.blob.core.windows.net/vhdstore/win7baseimage.vhd?st=2013-01 -09T22%3A15%3A49Z&amp;se=2013-01-09T23%3A10%3A49Z&amp;sr=b&amp;sp=w&amp;sig=13T9Ow%2FRJAMmhfO%2FaP3HhKKJ6AY093SmveO SIV4%2FR7w%3D" -LocalFilePath "C:\vhd\win7baseimage.vhd"
```

This command adds a .vhd file to a storage account and specifies the SAS URI.

## PARAMETERS

### -BaseImageUriToPatch
Specifies the URI to a base image blob in Azure Blob Storage.
An SAS can be specified as the value for this parameter.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases: bs

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Destination
Specifies the URI of a blob in Blob Storage.
The parameter supports SAS URI, although patching scenarios destination cannot be an SAS URI.

```yaml
Type: Uri
Parameter Sets: (All)
Aliases: dst

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LocalFilePath
Specifies the path of the local .vhd file.

```yaml
Type: FileInfo
Parameter Sets: (All)
Aliases: lf

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NumberOfUploaderThreads
Specifies the number of uploader threads to be used when uploading the .vhd file.

```yaml
Type: Int32
Parameter Sets: (All)
Aliases: th

Required: False
Position: 3
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -OverWrite
Indicates that this cmdlet overwrites an existing blob in the specified destination URI, if one exists.

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: o

Required: False
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group of the virtual machine.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None
This cmdlet does not accept any input.

## OUTPUTS

## NOTES

## RELATED LINKS

[Save-AzureRmVhd](./Save-AzureRmVhd.md)


