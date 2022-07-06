---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: D08DAA8B-B7BF-4167-AB16-F2723985A0B7
online version: https://docs.microsoft.com/powershell/module/az.compute/add-azvhd
schema: 2.0.0
---

# Add-AzVhd

## SYNOPSIS
Uploads a virtual hard disk from an on-premises machine to Azure (managed disk or blob).

## SYNTAX

### DefaultParameterSet (Default)
```
Add-AzVhd [-ResourceGroupName] <String> [-Destination] <Uri> [-LocalFilePath] <FileInfo>
 [[-NumberOfUploaderThreads] <Int32>] [[-BaseImageUriToPatch] <Uri>] [-OverWrite] [-SkipResizing]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

### DirectUploadToManagedDiskSet
```
Add-AzVhd [-ResourceGroupName] <String> [-LocalFilePath] <FileInfo> -DiskName <String> [-Location] <String>
 [-DiskSku <String>] [-DiskZone <String[]>] [-DiskHyperVGeneration <String>]
 [-DiskOsType <OperatingSystemTypes>] [[-NumberOfUploaderThreads] <Int32>] [-DataAccessAuthMode <String>]
 [-AsJob] [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Add-AzVhd** cmdlet uploads an on-premise virtual hard disk to a managed disk or a blob storage account.<br/>

The virtual hard disk being uploaded needs to be a .vhd file and in size N * Mib + 512 bytes. Using [Hyper-V](https://docs.microsoft.com/en-us/windows-server/virtualization/hyper-v/hyper-v-technology-overview) 
functionality, **Add-AzVhd** will convert any .vhdx file to a .vhd file and resize before uploading. 
To allow this functionality, you will need to [enable Hyper-V](https://docs.microsoft.com/en-us/windows-server/virtualization/hyper-v/get-started/install-the-hyper-v-role-on-windows-server). 
If you are using a Linux machine or choose to not use this functionality, you will need to [resize the VHD file manually](https://docs.microsoft.com/en-us/azure/virtual-machines/linux/create-upload-generic?branch=pr-en-us-185925#resizing-vhds). 
Additionally, **Add-AzVhd** will convert dynamically sized VHD files to fixed size during upload. Use `-Verbose` to follow all the process. 

For Default Parameter set (upload to blob), also supported is the ability to upload a patched version of an on-premises .vhd file.
When a base virtual hard disk has already been uploaded, you can upload differencing disks that use the base image as the parent.
Shared access signature (SAS) URI is supported also. <br/>

For Direct Upload to Managed Disk Parameter set, parameters: ResourceGroupName, DiskName, Location, DiskSku, and Zone will be used to 
create a new disk, then the virtual hard disk will be uploaded to it. <br/>

More information on [using Add-AzVhd to directly upload to a managed disk](https://docs.microsoft.com/en-us/azure/virtual-machines/windows/disks-upload-vhd-to-managed-disk-powershell#use-add-azvhd).

For VHD files greater than 50 GB, we recommend using [AzCopy](https://docs.microsoft.com/en-us/azure/storage/common/storage-use-azcopy-v10?toc=/azure/storage/blobs/toc.json) for faster upload.

## EXAMPLES

### Example 1: Add a VHD file to a blob
```powershell
Add-AzVhd -Destination "http://contosoaccount.blob.core.windows.net/vhdstore/win7baseimage.vhd" -LocalFilePath "C:\vhd\Win7Image.vhd"
```

This command adds a .vhd file to a storage account.

### Example 2: Add a VHD file to a blob and overwrite the destination
```powershell
Add-AzVhd -Destination "http://contosoaccount.blob.core.windows.net/vhdstore/win7baseimage.vhd" -LocalFilePath "C:\vhd\Win7Image.vhd" -Overwrite
```

This command adds a .vhd file to a storage account.
The command overwrites an existing file.

### Example 3: Add a VHD file to a blob with number of threads specified
```powershell
Add-AzVhd -Destination "http://contosoaccount.blob.core.windows.net/vhdstore/win7baseimage.vhd" -LocalFilePath "C:\vhd\Win7Image.vhd" -NumberOfUploaderThreads 32
```

This command adds a .vhd file to a storage account.
The command specifies the number of threads to use to upload the file.

### Example 4: Add a VHD file to a blob and specify the SAS URI
```powershell
Add-AzVhd -Destination "http://contosoaccount.blob.core.windows.net/vhdstore/win7baseimage.vhd?st=2013-01 -09T22%3A15%3A49Z&amp;se=2013-01-09T23%3A10%3A49Z&amp;sr=b&amp;sp=w&amp;sig=13T9Ow%2FRJAMmhfO%2FaP3HhKKJ6AY093SmveO SIV4%2FR7w%3D" -LocalFilePath "C:\vhd\win7baseimage.vhd"
```

This command adds a .vhd file to a storage account and specifies the SAS URI.

### Example 5: Add a VHD file directly to a managed disk.
```powershell
Add-AzVhd -LocalFilePath C:\data.vhd -ResourceGroupName rgname -Location eastus -DiskName newDisk
```

This command create a managed disk with given ResourceGroupName, Location, and DiskName; and uploads the VHD file to it.

### Example 6: Add a VHD file directly to a more configured disk.
```powershell
Add-AzVhd -LocalFilePath C:\Data.vhdx -ResourceGroupName rgname -Location eastus -DiskName newDisk -Zone 1 -DiskSku Premium_LRS
```

This command will tried to convert vhdx file to vhd file first using Hyper-V. If Hyper-V is not found, it will return an error asking to use a vhd file. After successful conversion, it will create a managed disk with provided parameters, then upload the vhd file. 

## PARAMETERS

### -AsJob
Run cmdlet in the background and return a Job to track progress.

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

### -BaseImageUriToPatch
Specifies the URI to a base image blob in Azure Blob Storage.
An SAS can be specified as the value for this parameter.

```yaml
Type: System.Uri
Parameter Sets: DefaultParameterSet
Aliases: bs

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DataAccessAuthMode
Additional authentication requirements when exporting or uploading to a disk or snapshot. Possible options are: "AzureActiveDirectory" and "None".

```yaml
Type: System.String
Parameter Sets: DirectUploadToManagedDiskSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

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

### -Destination
Specifies the URI of a blob in Blob Storage.
The parameter supports SAS URI, although patching scenarios destination cannot be an SAS URI.

```yaml
Type: System.Uri
Parameter Sets: DefaultParameterSet
Aliases: dst

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DiskHyperVGeneration
The hypervisor generation of the Virtual Machine. Applicable to OS disks only. Posssible values are: 'V1', 'V2'.

```yaml
Type: System.String
Parameter Sets: DirectUploadToManagedDiskSet
Aliases: HyperVGeneration

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DiskName
Name of the new managed Disk

```yaml
Type: System.String
Parameter Sets: DirectUploadToManagedDiskSet
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DiskOsType
The Operating System type of the managed disk. Possible values are: 'Windows', 'Linux'.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.OperatingSystemTypes
Parameter Sets: DirectUploadToManagedDiskSet
Aliases: OsType
Accepted values: Windows, Linux

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DiskSku
Sku for managed disk. Options: Standard_LRS, Premium_LRS, StandardSSD_LRS, UltraSSD_LRS

```yaml
Type: System.String
Parameter Sets: DirectUploadToManagedDiskSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DiskZone
The Logical zone list for Disk.

```yaml
Type: System.String[]
Parameter Sets: DirectUploadToManagedDiskSet
Aliases: Zone

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LocalFilePath
Specifies the path of the local .vhd file.

```yaml
Type: System.IO.FileInfo
Parameter Sets: (All)
Aliases: lf

Required: True
Position: 2
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Location of new Managed Disk

```yaml
Type: System.String
Parameter Sets: DirectUploadToManagedDiskSet
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -NumberOfUploaderThreads
Specifies the number of uploader threads to be used when uploading the .vhd file.

```yaml
Type: System.Nullable`1[System.Int32]
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
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DefaultParameterSet
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
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SkipResizing
Skips the resizing of the VHD file. 
Users that wish to upload a VHD files that has its size misaligned (not N * Mib + 512 bytes) to a blob can use this switch parameter.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: DefaultParameterSet
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

### System.String

### System.Uri

### System.IO.FileInfo

### System.Nullable`1[[System.Int32, System.Private.CoreLib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]

### System.Management.Automation.SwitchParameter

## OUTPUTS

### Microsoft.Azure.Commands.Compute.Models.VhdUploadContext

## NOTES

## RELATED LINKS

[Save-AzVhd](./Save-AzVhd.md)
