---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/new-azstorageblobdirectory
schema: 2.0.0
---

# New-AzStorageBlobDirectory

## SYNOPSIS
Create a Storage blob directory.

## SYNTAX

### ReceiveManual (Default)
```
New-AzStorageBlobDirectory -Container <String> -Path <String> [-Umask <String>] [-Permission <String>]
 [-Property <Hashtable>] [-Metadata <Hashtable>] [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ContainerPipeline
```
New-AzStorageBlobDirectory -CloudBlobContainer <CloudBlobContainer> -Path <String> [-Umask <String>]
 [-Permission <String>] [-Property <Hashtable>] [-Metadata <Hashtable>] [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzStorageDirectory** cmdlet creates a Storage blob directory.
This cmdlet only works if Hierarchical Namespace is enabled for the Storage account.

## EXAMPLES

### Example 1: Create a Blob Directory
```
PS C:\>New-AzStorageBlobDirectory -Container "testcontainer" -Path "dir1/dir2"

   Container Uri: https://weisanity1.blob.core.windows.net/testcontainer

Name                 IsDirectory  BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime         IsDeleted  Permissions 
----                 -----------  --------  ------          -----------                    ------------         ---------- ------------         ---------  ----------- 
dir1/dir2/           True                                   application/octet-stream       2019-10-14 07:53:41Z                                 False      rwxr-x--- 
```

This command creates a Blob Directory

### Example 2: Create a Blob Directory with specified Permission, Umask
```
PS C:\>New-AzStorageBlobDirectory -Container "testcontainer" -Path "dir1/dir2" -Permission rwxrwxrwx -Umask ---rw----

   Container Uri: https://weisanity1.blob.core.windows.net/testcontainer

Name                 IsDirectory  BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime         IsDeleted  Permissions 
----                 -----------  --------  ------          -----------                    ------------         ---------- ------------         ---------  ----------- 
dir1/dir2/           True                                   application/octet-stream       2019-10-14 07:54:47Z                                 False      rwx--xrwx 
```

This command creates a Blob Directory with specified Permission, Umask

### Example 3: Create a Blob Directory with specified Properties, Metadata, and then show them
```
PS C:\> $dir = New-AzStorageBlobDirectory -Container "testcontainer" -Path "dir1/dir2"  -Properties @{"ContentEncoding" = "UDF8"; "CacheControl" = "READ"; "ContentDisposition" = "True"; "ContentLanguage" = "EN-US"} -Metadata @{"tag1" = "value1"; "tag2" = "value2" }

PS C:\> $dir.CloudBlobDirectory.Properties

CacheControl                       : READ
ContentDisposition                 : True
ContentEncoding                    : UDF8
ContentLanguage                    : EN-US
Length                             : 0
ContentMD5                         : 
ContentType                        : application/octet-stream
ETag                               : "0x8D7507CE126EC96"
Created                            : 10/14/2019 8:02:37 AM +00:00
LastModified                       : 10/14/2019 8:02:37 AM +00:00
BlobType                           : BlockBlob
LeaseStatus                        : Unlocked
LeaseState                         : Available
LeaseDuration                      : Unspecified
PageBlobSequenceNumber             : 
AppendBlobCommittedBlockCount      : 
IsServerEncrypted                  : True
IsIncrementalCopy                  : False
StandardBlobTier                   : Cool
RehydrationStatus                  : 
PremiumPageBlobTier                : 
BlobTierInferred                   : True
BlobTierLastModifiedTime           : 
DeletedTime                        : 
RemainingDaysBeforePermanentDelete : 

PS C:\> $dir.CloudBlobDirectory.Metadata

Key          Value  
---          -----  
hdi_isfolder true   
tag1         value1 
tag2         value2
```

This command creates a Blob Directory with specified Properties, Metadata

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
Parameter Sets: ReceiveManual
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

### -Metadata
Blob Directory Metadata

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Path
Blob Directory path

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

### -Permission
Sets POSIX access permissions for the file owner, the file owning group, and others.
Each class may be granted read, write, or execute permission.
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

### -Property
Blob Directory Properties

```yaml
Type: System.Collections.Hashtable
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

### -Umask
When creating blob directory and the parent folder does not have a default ACL, the umask restricts the permissions of the file or directory to be created.
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

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.Azure.Storage.Blob.CloudBlobDirectory

## NOTES

## RELATED LINKS
