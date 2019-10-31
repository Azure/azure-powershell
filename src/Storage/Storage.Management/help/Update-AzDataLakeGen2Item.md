---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/update-azdatalakegen2item
schema: 2.0.0
---

# Update-AzDataLakeGen2Item

## SYNOPSIS
Update a file or directory on properties, metadata, permission, ACL, and owner.

## SYNTAX

### ReceiveManual (Default)
```
Update-AzDataLakeGen2Item [-FileSystem] <String> [-Path] <String> [-Permission <String>] [-Owner <String>]
 [-Group <String>] [-Property <Hashtable>] [-Metadata <Hashtable>] [-Acl <PSPathAccessControlEntry[]>]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### ItemPipeline
```
Update-AzDataLakeGen2Item -InputObject <AzureDataLakeGen2Item> [-Permission <String>] [-Owner <String>]
 [-Group <String>] [-Property <Hashtable>] [-Metadata <Hashtable>] [-Acl <PSPathAccessControlEntry[]>]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzDataLakeGen2Item** cmdlet updates a file or directory on properties, metadata, permission, ACL, and owner.
This cmdlet only works if Hierarchical Namespace is enabled for the Storage account. This kind of account can be created by run "New-AzStorageAccount" cmdlet with "-EnableHierarchicalNamespace $true".

## EXAMPLES

### Example 1: Create an ACL object with 3 ACL entry, and update ACL to all items in a Filesystem recursively
```
PS C:\>$acl = New-AzDataLakeGen2ItemAclObject -AccessControlType user -Permission rwx -DefaultScope
PS C:\>$acl = New-AzDataLakeGen2ItemAclObject -AccessControlType group -Permission rw- -InputObject $acl 
PS C:\>$acl = New-AzDataLakeGen2ItemAclObject -AccessControlType other -Permission "rw-" -InputObject $acl
PS C:\>Get-AzDataLakeGen2ChildItem -FileSystem "testfilesystem" -Recurse | Update-AzDataLakeGen2Item -ACL $acl

   FileSystem Uri: https://testaccount.blob.core.windows.net/testfilesystem

Path                 IsDirectory  Length          ContentType                    LastModified         Permissions  Owner      Group               
----                 -----------  ------          -----------                    ------------         -----------  -----      -----               
dir1/                True                         application/octet-stream       2019-10-30 02:43:09Z rw-rw--wx    $superuser $superuser          
dir1/file1           False        14400000        image/jpeg                     2019-10-30 02:50:27Z rw-rw--wx    $superuser $superuser          
dir2/                True                         application/octet-stream       2019-10-30 01:32:45Z rw-rw--wx    $superuser $superuser
```

This command creates an ACL object with 3 acl entry (use -InputObject parameter to add acl entry to existing acl object), and updates ACL on a file.

### Example 2: Update all properties on a file, and show them
```
PS C:\> Update-AzDataLakeGen2Item -FileSystem "testfilesystem" -Path "dir1/file1" `
                 -Acl $acl `
                 -Property @{"ContentType" = "image/jpeg"; "ContentMD5" = "i727sP7HigloQDsqadNLHw=="; "ContentEncoding" = "UDF8"; "CacheControl" = "READ"; "ContentDisposition" = "True"; "ContentLanguage" = "EN-US"} `
                 -Metadata  @{"tag1" = "value1"; "tag2" = "value2" } `
                 -Permission rw-rw-rwx `
                 -Owner '$superuser' `
                 -Group '$superuser'

PS C:\> $file

   FileSystem Uri: https://testaccount.blob.core.windows.net/testfilesystem

Path                 IsDirectory  Length          ContentType                    LastModified         Permissions  Owner      Group               
----                 -----------  ------          -----------                    ------------         -----------  -----      -----               
dir1/file1           False        14400000        image/jpeg                     2019-10-30 02:56:54Z rw-rw--wx    $superuser $superuser  

PS C:\> $file.ACL

DefaultScope AccessControlType EntityId Permissions
------------ ----------------- -------- -----------
False        User                       rw-        
False        Group                      rw-        
False        Other                      -wx 

PS C:\> $file.ICloudBlob.Metadata

Key  Value 
---  ----- 
tag2 value2
tag1 value1

PS C:\> $file.ICloudBlob.Properties

CacheControl                       : READ
ContentDisposition                 : True
ContentEncoding                    : UDF8
ContentLanguage                    : EN-US
Length                             : 14400000
ContentMD5                         : i727sP7HigloQDsqadNLHw==
ContentType                        : image/jpeg
ETag                               : "0x8D75CE53D2207B7"
Created                            : 10/30/2019 2:50:22 AM +00:00
LastModified                       : 10/30/2019 2:59:53 AM +00:00
BlobType                           : BlockBlob
LeaseStatus                        : Unlocked
LeaseState                         : Available
LeaseDuration                      : Unspecified
PageBlobSequenceNumber             : 
AppendBlobCommittedBlockCount      : 
IsServerEncrypted                  : False
IsIncrementalCopy                  : False
StandardBlobTier                   : Cool
RehydrationStatus                  : 
PremiumPageBlobTier                : 
BlobTierInferred                   : True
BlobTierLastModifiedTime           : 
DeletedTime                        : 
RemainingDaysBeforePermanentDelete :
```

This command updates all properties on a file (ACL, permission,owner, group, metadata, property can be updated with any conbination), and show them in Powershell console.

### Example 3: Add an ACL entry to a directory
```
## Get the origin ACL
$acl = (Get-AzDataLakeGen2Item -FileSystem "testfilesystem" -Path 'dir1/dir2/').ACL

# Add a new ACL entry
$acl = New-AzDataLakeGen2ItemAclObject -AccessControlType Other -EntityId $id -Permission rw- -InputObject $acl  

# set the new acl to the directory
update-AzDataLakeGen2Item -FileSystem "testfilesystem" -Path 'dir1/dir2/' -ACL $acl
```

This command gets ACL from a directory, adds an ACL entry, and sets back to the directory.

## PARAMETERS

### -Acl
Sets POSIX access control rights on files and directories.
Create this object with New-AzDataLakeGen2ItemAclObject.

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

### -FileSystem
FileSystem name

```yaml
Type: System.String
Parameter Sets: ReceiveManual
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### -InputObject
Azure Datalake Gen2 Item Object to update

```yaml
Type: Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2Item
Parameter Sets: ItemPipeline
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Metadata
Specifies metadata for the directory or file.

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
The path in the specified Filesystem that should be updated.
Can be a file or directory In the format 'directory/file.txt' or 'directory1/directory2/'

```yaml
Type: System.String
Parameter Sets: ReceiveManual
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Permission
Sets POSIX access permissions for the file owner, the file owning group, and others.
Each class may be granted read, write, or execute permission.
Symbolic (rwxrw-rw-) is supported.
Invalid in conjunction with Acl.

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
Specifies properties for the directory or file. 
The supported properties for file are: CacheControl, ContentDisposition, ContentEncoding, ContentLanguage, ContentMD5, ContentType.
The supported properties for directory are: CacheControl, ContentDisposition, ContentEncoding, ContentLanguage.

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

### System.String

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2Item

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureDataLakeGen2Item

## NOTES

## RELATED LINKS
