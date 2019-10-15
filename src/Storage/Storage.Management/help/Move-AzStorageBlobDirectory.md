---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/move-azstorageblobdirectory
schema: 2.0.0
---

# Move-AzStorageBlobDirectory

## SYNOPSIS
Move a Storage blob directory and all its content to another Storage blob directory.

## SYNTAX

### ReceiveManual (Default)
```
Move-AzStorageBlobDirectory -SrcContainer <String> -SrcPath <String> -DestContainer <String> -DestPath <String>
 [-Umask <String>] [-PathRenameMode <PathRenameMode>] [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ContainerPipeline
```
Move-AzStorageBlobDirectory -CloudBlobContainer <CloudBlobContainer> -SrcPath <String> -DestContainer <String>
 -DestPath <String> [-Umask <String>] [-PathRenameMode <PathRenameMode>] [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### BlobDirPipeline
```
Move-AzStorageBlobDirectory -CloudBlobDirectory <CloudBlobDirectory> -DestContainer <String> -DestPath <String>
 [-Umask <String>] [-PathRenameMode <PathRenameMode>] [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Move-AzStorageBlobDirectory** cmdlet moves a Storage blob directory and all its content to another Storage blob directory.
This cmdlet only works if Hierarchical Namespace is enabled for the Storage account.

## EXAMPLES

### Example 1: Move a Blob Directory to another Blob Directory in same Storage Account
```
PS C:\> Move-AzStorageBlobDirectory -Context $ctx -SrcContainer "testcontainer" -SrcPath "dir1" -DestContainer "testcontainer2" -DestPath "dir2" -Umask rwxrwxrwx

   Container Uri: https://testaccount.blob.core.windows.net/testcontainer2

Name                 IsDirectory  BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime         IsDeleted  Permissions 
----                 -----------  --------  ------          -----------                    ------------         ---------- ------------         ---------  ----------- 
dir2/                True                                                                  2019-10-15 03:30:05Z                                 False      rwxrwxrwx  
```

This command update owner and group on a Blob Directory, and then show them

## PARAMETERS

### -ClientTimeoutPerRequest
The client side maximum execution time for each request in seconds.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases: ClientTimeoutPerRequestInSeconds

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CloudBlobContainer
Azure Container Object

```yaml
Type: Microsoft.Azure.Storage.Blob.CloudBlobContainer
Parameter Sets: ContainerPipeline
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -CloudBlobDirectory
Source Azure Blob Directory Object

```yaml
Type: Microsoft.Azure.Storage.Blob.CloudBlobDirectory
Parameter Sets: BlobDirPipeline
Aliases: SrcCloudBlobDirectory, SourceCloudBlobDirectory

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -ConcurrentTaskCount
The total amount of concurrent async tasks.
The default value is 10.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Context
Azure Storage Context Object

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DestContainer
Dest Container name

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

### -DestPath
Dest Blob Directory path

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

### -PathRenameMode
This parameter determines the behavior of the rename operation.
The value must be "legacy" or "posix", and the default value will be "posix".

```yaml
Type: Microsoft.Azure.Storage.Blob.PathRenameMode
Parameter Sets: (All)
Aliases:
Accepted values: Legacy, Posix

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerTimeoutPerRequest
The server time out for each request in seconds.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases: ServerTimeoutPerRequestInSeconds

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SrcContainer
Container name

```yaml
Type: System.String
Parameter Sets: ReceiveManual
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SrcPath
Source Blob Directory path

```yaml
Type: System.String
Parameter Sets: ReceiveManual, ContainerPipeline
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Umask
The umask restricts the permissions of the file or directory to be created.
The resulting permission is given by p & ^u, where p is the permission and u is the umask.
Symbolic (rwxrw-rw-) is supported.

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

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Storage.Blob.CloudBlobContainer

### Microsoft.Azure.Storage.Blob.CloudBlobDirectory

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.Azure.Storage.Blob.CloudBlobDirectory

## NOTES

## RELATED LINKS
