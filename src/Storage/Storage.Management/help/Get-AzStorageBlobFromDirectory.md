---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/get-azstorageblobfromdirectory
schema: 2.0.0
---

# Get-AzStorageBlobFromDirectory

## SYNOPSIS
Lists blobs and blob directories in a blob directory.

## SYNTAX

### ListDirPath (Default)
```
Get-AzStorageBlobFromDirectory [-BlobRelativePath <String>] -Container <String> -BlobDirectoryPath <String>
 [-IncludeDeleted] [-MaxCount <Int32>] [-ContinuationToken <BlobContinuationToken>] [-FetchPermission]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [<CommonParameters>]
```

### ListDirObject
```
Get-AzStorageBlobFromDirectory [-BlobRelativePath <String>] -CloudBlobDirectory <CloudBlobDirectory>
 [-IncludeDeleted] [-MaxCount <Int32>] [-ContinuationToken <BlobContinuationToken>] [-FetchPermission]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzStorageBlob** cmdlet lists blobs and blob directories in the specified blob directory in an Azure storage account.
This cmdlet only works if Hierarchical Namespace is enabled for the Storage account.

## EXAMPLES

### Example 1: Get all blob and blob directories under a blob directory with permission
```
PS C:\>Get-AzStorageBlobFromDirectory -Container "container1"  -BlobDirectoryPath dir1 -FetchPermission

   Container Uri: https://storageaccountname.blob.core.windows.net/container1

Name                 IsDirectory  BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime         IsDeleted  Permissions 
----                 -----------  --------  ------          -----------                    ------------         ---------- ------------         ---------  ----------- 
dir1/dir2/           True                                   application/octet-stream       2019-10-15 07:34:45Z Cool                            False      rwxr-x--- 
dir1/text1.txt       False        BlockBlob 2097152         application/octet-stream       2019-10-15 03:49:37Z Cool                            False      rw-r-----  
dir1/text2.txt       False        BlockBlob 2097152         application/octet-stream       2019-10-15 07:34:19Z Cool                            False      rw-r-----   

```

This command gets all blobs and blob directories under a blob directory dir1 with permission

### Example 2: Get all blob and blob directories under a blob directory with specific name pattern
```
PS C:\>Get-AzStorageBlobFromDirectory -Container "container1"  -BlobDirectoryPath dir1 -BlobRelativePath te*

   Container Uri: https://storageaccountname.blob.core.windows.net/container1

Name                 IsDirectory  BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime         IsDeleted  Permissions 
----                 -----------  --------  ------          -----------                    ------------         ---------- ------------         ---------  ----------- 
dir1/text1.txt       False        BlockBlob 2097152         application/octet-stream       2019-10-15 03:49:37Z Cool                            False                  
dir1/text2.txt       False        BlockBlob 2097152         application/octet-stream       2019-10-15 07:34:19Z Cool                            False                   

```

This command gets all blobs and blob directories under a blob directory dir1 with name pattern "te*"

## PARAMETERS

### -BlobDirectoryPath
Blob Directory Path to list from.

```yaml
Type: System.String
Parameter Sets: ListDirPath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BlobRelativePath
Blob or Blob Directory Relative Path in the specified Blob Directory.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: BlobDirectoryRelativePath, RelativePath

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -CloudBlobDirectory
Azure Blob Directory Object to list from.

```yaml
Type: Microsoft.Azure.Storage.Blob.CloudBlobDirectory
Parameter Sets: ListDirObject
Aliases:

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

### -Container
Container name

```yaml
Type: System.String
Parameter Sets: ListDirPath
Aliases:

Required: True
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

### -ContinuationToken
Continuation Token.

```yaml
Type: Microsoft.Azure.Storage.Blob.BlobContinuationToken
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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

### -FetchPermission
Fetch Blob Permission.
This only works if Hierarchical Namespace is enabled for the account.

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

### -IncludeDeleted
Include deleted blobs, by default get blob won't include deleted blobs

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

### -MaxCount
The max count of the blobs that can return.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Storage.Blob.CloudBlobDirectory

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob

## NOTES

## RELATED LINKS
