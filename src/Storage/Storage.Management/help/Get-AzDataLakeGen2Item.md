---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://docs.microsoft.com/en-us/powershell/module/az.storage/get-azdatalakegen2item
schema: 2.0.0
---

# Get-AzDataLakeGen2Item

## SYNOPSIS
Gets the details of a file or folder in a container.

## SYNTAX

```
Get-AzDataLakeGen2Item [-Container] <String> [-Path] <String> [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzDataLakeGen2Item** cmdlet gets the details of a file or folder in a container in an Azure storage account.
This cmdlet only works if Hierarchical Namespace is enabled for the Storage account.

## EXAMPLES

### Example 1: Get a folder from a container, and show the details
```
PS C:\> $dir1 = Get-AzDataLakeGen2tem -Container "container1" -Path "dir1/"
PS C:\> $dir1

   Container Uri: https://storageaccountname.blob.core.windows.net/container1

Path                 IsDirectory  Length          ContentType                    LastModified         Permissions  Owner      Group               
----                 -----------  ------          -----------                    ------------         -----------  -----      -----               
dir1/                True                         application/octet-stream       2019-10-29 04:23:05Z rw-rw--wx    $superuser $superuser  
 
PS C:\> $dir1.ACL

DefaultScope AccessControlType EntityId Permissions
------------ ----------------- -------- -----------
False        User                       rw-        
False        Group                      rw-        
False        Other                      -wx   

PS C:\> $dir1.CloudBlobDirectory.Metadata

Key          Value  
---          -----  
tag1         value1 
hdi_isfolder true 

PS C:\WINDOWS\system32> $dir1.CloudBlobDirectory.Properties

CacheControl                       : READ
ContentDisposition                 : True
ContentEncoding                    : UDF8
ContentLanguage                    : EN-US
Length                             : 0
ContentMD5                         : 
ContentType                        : application/octet-stream
ETag                               : "0x8D75C27B2338204"
Created                            : 10/29/2019 4:09:34 AM +00:00
LastModified                       : 10/29/2019 4:23:05 AM +00:00
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
```

This command gets a folder from a container, and show the details.

### Example 2: Get a file from a container
```
PS C:\> Get-AzDataLakeGen2Item -Container "container1" -Path "dir1/file1"

   Container Uri: https://storageaccountname.blob.core.windows.net/container1

Path                 IsDirectory  Length          ContentType                    LastModified         Permissions  Owner      Group               
----                 -----------  ------          -----------                    ------------         -----------  -----      -----               
dir1/file1           False        14400000        application/octet-stream       2019-10-29 07:40:28Z rwx---rwx    $superuser $superuser
```

This command gets the details of a file from a container.

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
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
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

### -Path
The path in the specified container that should be retrieved.
Can be a file or folder In the format 'folder/file.txt' or 'folder1/folder2/'

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByValue)
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

### System.String

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob

## NOTES

## RELATED LINKS
