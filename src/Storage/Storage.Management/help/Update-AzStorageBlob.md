---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/update-azstorageblob
schema: 2.0.0
---

# Update-AzStorageBlob

## SYNOPSIS
Update the properties and ACLs of a Storage blob.

## SYNTAX

### ReceiveManual (Default)
```
Update-AzStorageBlob -Container <String> -Path <String> [-Permission <String>] [-Owner <String>]
 [-Group <String>] [-Property <Hashtable>] [-Metadata <Hashtable>] [-ACL <PSPathAccessControlEntry[]>]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### ContainerPipeline
```
Update-AzStorageBlob -CloudBlobContainer <CloudBlobContainer> -Path <String> [-Permission <String>]
 [-Owner <String>] [-Group <String>] [-Property <Hashtable>] [-Metadata <Hashtable>]
 [-ACL <PSPathAccessControlEntry[]>] [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>]
 [-ClientTimeoutPerRequest <Int32>] [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### BlobPipeline
```
Update-AzStorageBlob -CloudBlob <CloudBlob> [-Permission <String>] [-Owner <String>] [-Group <String>]
 [-Property <Hashtable>] [-Metadata <Hashtable>] [-ACL <PSPathAccessControlEntry[]>]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzStorageBlob** cmdlet updates the properties and ACLs of a Storage blob.
This permission, ACLs, owner and group update only works if Hierarchical Namespace is enabled for the Storage account.

## EXAMPLES

### Example 1: Create an ACL object with 3 acl entry, and update ACL on all Blobs under a container
```
PS C:\>$acl = New-AzStorageBlobPathACL -AccessControlType user -Permission rwx
PS C:\>$acl = New-AzStorageBlobPathACL -AccessControlType group -Permission rw- -InputObject $acl 
PS C:\>$acl = New-AzStorageBlobPathACL -AccessControlType other -Permission "rw-" -InputObject $acl
PS C:\>Get-AzStorageBlob -Container "testcontainer" | ? {$_.IsDirectory -eq $false} | Update-AzStorageBlob -ACL $acl

   Container Uri: https://testaccount.blob.core.windows.net/testcontainer

Name                 IsDirectory  BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime         IsDeleted  Permissions 
----                 -----------  --------  ------          -----------                    ------------         ---------- ------------         ---------  ----------- 
dir1/dir2/text.txt   False        BlockBlob 2097152         application/octet-stream       2019-10-14 08:34:00Z Cool                            False      rwxrw-rw-  
dir1/dir2/text2.txt  False        BlockBlob 2097152         application/octet-stream       2019-10-14 08:34:00Z Cool                            False      rwxrw-rw-  
```

This command creates an ACL object with 3 acl entry, and updates ACL on all Blobs under a container

### Example 2: Get all blobs in a Blob Directory, and update permission on them
```
PS C:\>Get-AzStorageBlobFromDirectory -Container "testcontainer"  -BlobDirectoryPath dir1/dir2 | ? {$_.IsDirectory -eq $false} | Update-AzStorageBlob -Permission rwxrwxrwx

   Container Uri: https://testaccount.blob.core.windows.net/testcontainer

Name                 IsDirectory  BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime         IsDeleted  Permissions 
----                 -----------  --------  ------          -----------                    ------------         ---------- ------------         ---------  ----------- 
dir1/dir2/text.txt   False        BlockBlob 2097152         application/octet-stream       2019-10-14 08:34:00Z Cool                            False      rwxrwxrwx   
dir1/dir2/text2.txt  False        BlockBlob 2097152         application/octet-stream       2019-10-14 08:52:11Z Cool                            False      rwxrwxrwx   
```

This command gets all blobs in a Blob Directory, and updates permission on them

### Example 3: Update owner and group on a Blob, and then show them
```
PS C:\>$blob = Update-AzStorageBlob -Container "testcontainer" -Path "dir1/dir1/text.txt" -Owner '$superuser' -Group '$superuser'

PS C:\> $blob.ICloudBlob.PathProperties.Owner
$superuser

PS C:\> $blob.ICloudBlob.PathProperties.Group
$superuser
```

This command update owner and group on a Blob Directory, and then show them

### Example 4: Update  Properties and Metadata on a Blob Directory, and then show them
```
PS C:\>$blob = Update-AzStorageBlob -Container "testcontainer" -Path "dir1/dir1/text.txt" -Properties @{"ContentEncoding" = "UDF8"; "CacheControl" = "READ"; "ContentDisposition" = "True"; "ContentLanguage" = "EN-US"} -Metadata @{"tag1" = "value1"; "tag2" = "value2" }

PS C:\>$blob.ICloudBlob.Properties


CacheControl                       : READ
ContentDisposition                 : True
ContentEncoding                    : UDF8
ContentLanguage                    : EN-US
Length                             : 0
ContentMD5                         : 
ContentType                        : application/octet-stream
ETag                               : "0x8D7507F2201A970"
Created                            : 10/14/2019 8:02:37 AM +00:00
LastModified                       : 10/14/2019 8:18:45 AM +00:00
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

PS C:\>$blob.ICloudBlob.Metadata

Key          Value 
---          ----- 
tag1         value1
tag2         value2
hdi_isfolder true  
```

This command update owner and group on a Blob Directory, and then show them

## PARAMETERS

### -ACL
Sets POSIX access control rights on files and directories.
Create this object with New-AzStorageBlobPathACL.

```yaml
Type: Microsoft.WindowsAzure.Commands.Storage.Model.ResourceModel.PSPathAccessControlEntry[]
Parameter Sets: (All)
Aliases:

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

### -CloudBlob
Azure Blob Object

```yaml
Type: Microsoft.Azure.Storage.Blob.CloudBlob
Parameter Sets: BlobPipeline
Aliases: ICloudBlob

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
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

### -Group
Sets the owning group of the blob.

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

### -Metadata
Blob Metadata

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

### -Owner
Sets the owner of the blob.

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

### -Path
Blob path

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

### -Permission
Sets POSIX access permissions for the file owner, the file owning group, and others.
Each class may be granted read, write, or execute permission.
Symbolic (rwxrw-rw-) is supported.
Invalid in conjunction with ACL.

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
Blob Properties

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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.Storage.Blob.CloudBlob

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob

## NOTES

## RELATED LINKS
