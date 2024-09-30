---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
ms.assetid: E54BFD3A-CD54-4E6B-9574-92B8D3E88FF3
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstorageblob
schema: 2.0.0
---

# Get-AzStorageBlob

## SYNOPSIS
Lists blobs in a container.

## SYNTAX

### BlobName (Default)
```
Get-AzStorageBlob [[-Blob] <String>] [-Container] <String> [-IncludeDeleted] [-IncludeTag] [-MaxCount <Int32>]
 [-ContinuationToken <BlobContinuationToken>] [-TagCondition <String>] [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### SingleBlobSnapshotTime
```
Get-AzStorageBlob [-Blob] <String> [-Container] <String> [-IncludeDeleted] [-IncludeTag]
 -SnapshotTime <DateTimeOffset> [-MaxCount <Int32>] [-ContinuationToken <BlobContinuationToken>]
 [-TagCondition <String>] [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>]
 [-ClientTimeoutPerRequest <Int32>] [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### SingleBlobVersionID
```
Get-AzStorageBlob [-Blob] <String> [-Container] <String> [-IncludeDeleted] [-IncludeTag] -VersionId <String>
 [-MaxCount <Int32>] [-ContinuationToken <BlobContinuationToken>] [-TagCondition <String>]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### BlobPrefix
```
Get-AzStorageBlob [-Prefix <String>] [-Container] <String> [-IncludeDeleted] [-IncludeVersion] [-IncludeTag]
 [-MaxCount <Int32>] [-ContinuationToken <BlobContinuationToken>] [-Context <IStorageContext>]
 [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzStorageBlob** cmdlet lists blobs in the specified container in an Azure storage account.

## EXAMPLES

### Example 1: Get a blob by blob name
```powershell
Get-AzStorageBlob -Container "ContainerName" -Blob blob*
```

This command uses a blob name and wildcard to get a blob.

### Example 2: Get blobs in a container by using the pipeline
```powershell
Get-AzStorageContainer -Name container* | Get-AzStorageBlob -IncludeDeleted
```

```output
Container Uri: https://storageaccountname.blob.core.windows.net/container1

Name                 BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime         IsDeleted 
----                 --------  ------          -----------                    ------------         ---------- ------------         --------- 
test1                BlockBlob 403116          application/octet-stream       2017-11-08 07:53:19Z            2017-11-08 08:19:32Z True      
test1                BlockBlob 403116          application/octet-stream       2017-11-08 09:00:29Z                                 True      
test2                BlockBlob 403116          application/octet-stream       2017-11-08 07:53:00Z                                 False
```

This command uses the pipeline to get all blobs (include blobs in Deleted status) in a container.

### Example 3: Get blobs by name prefix
```powershell
Get-AzStorageBlob -Container "ContainerName" -Prefix "blob"
```

This command uses a name prefix to get blobs.

### Example 4: List blobs in multiple batches
```powershell
$MaxReturn = 10000
$ContainerName = "abc"
$Total = 0
$Token = $Null
do
 {
     $Blobs = Get-AzStorageBlob -Container $ContainerName -MaxCount $MaxReturn  -ContinuationToken $Token
     $Total += $Blobs.Count
     if($Blobs.Length -le 0) { Break;}
     $Token = $Blobs[$blobs.Count -1].ContinuationToken;
 }
 While ($null -ne $Token)
Echo "Total $Total blobs in container $ContainerName"
```

This example uses the *MaxCount* and *ContinuationToken* parameters to list Azure Storage blobs in multiple batches.
The first four commands assign values to variables to use in the example.
The fifth command specifies a **Do-While** statement that uses the **Get-AzStorageBlob** cmdlet to get blobs.
The statement includes the continuation token stored in the $Token variable.
$Token changes value as the loop runs.
For more information, type `Get-Help About_Do`.
The final command uses the **Echo** command to display the total.

### Example 5: Get all blobs in a container include blob version
```powershell
Get-AzStorageBlob -Container "containername"  -IncludeVersion
```

```output
AccountName: storageaccountname, ContainerName: containername

Name                 BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime                 IsDeleted  VersionId                     
----                 --------  ------          -----------                    ------------         ---------- ------------                 ---------  ---------                     
blob1                BlockBlob 2097152         application/octet-stream       2020-07-06 06:56:06Z Hot                                     False      2020-07-06T06:56:06.2432658Z  
blob1                BlockBlob 2097152         application/octet-stream       2020-07-06 06:56:06Z Hot        2020-07-06T06:56:06.8588431Z False                                    
blob1                BlockBlob 2097152         application/octet-stream       2020-07-06 06:56:06Z Hot                                     False      2020-07-06T06:56:06.8598431Z *  
blob2                BlockBlob 2097152         application/octet-stream       2020-07-03 16:19:16Z Hot                                     False      2020-07-03T16:19:16.2883167Z  
blob2                BlockBlob 2097152         application/octet-stream       2020-07-03 16:19:35Z Hot                                     False      2020-07-03T16:19:35.2381110Z *
```

This command gets all blobs in a container include blob version.

### Example 6: Get a single blob version
```powershell
Get-AzStorageBlob -Container "containername" -Blob blob2 -VersionId "2020-07-03T16:19:16.2883167Z"
```

```output
AccountName: storageaccountname, ContainerName: containername

Name                 BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime                 IsDeleted  VersionId                     
----                 --------  ------          -----------                    ------------         ---------- ------------                 ---------  ---------                     
blob2                BlockBlob 2097152         application/octet-stream       2020-07-03 16:19:16Z Hot                                     False      2020-07-03T16:19:16.2883167Z
```

This command gets a single blobs verion with VersionId.

### Example 7: Get a single blob snapshot
```powershell
Get-AzStorageBlob -Container "containername" -Blob blob1 -SnapshotTime "2020-07-06T06:56:06.8588431Z"
```

```output
AccountName: storageaccountname, ContainerName: containername

Name                 BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime                 IsDeleted  VersionId                     
----                 --------  ------          -----------                    ------------         ---------- ------------                 ---------  ---------                     
blob1                BlockBlob 2097152         application/octet-stream       2020-07-06 06:56:06Z Hot        2020-07-06T06:56:06.8588431Z False
```

This command gets a single blobs snapshot with SnapshotTime.

### Example 8: Get blob include blob tags
<!-- Skip: Output cannot be splitted from code -->


```
$blobs = Get-AzStorageBlob -Container "containername" -IncludeTag

$blobs

   AccountName: storageaccountname, ContainerName: containername

Name                 BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime                 IsDeleted  VersionId                     
----                 --------  ------          -----------                    ------------         ---------- ------------                 ---------  ---------                     
testblob             BlockBlob 2097152         application/octet-stream       2020-07-23 09:35:02Z Hot                                     False      2020-07-23T09:35:02.8527357Z *
testblob2            BlockBlob 2097152         application/octet-stream       2020-07-23 09:35:04Z Hot                                     False      2020-07-23T09:35:04.0856187Z *


$blobs[0].Tags
Name          Value 
----          -----
tag1          value1
tag2          value2
```

This command lists blobs from a container with blob tags, and show the tags of the first blob.

### Example 9: Get a single blob with blob tag condition
```powershell
Get-AzStorageBlob -Container "containername" -Blob testblob -TagCondition """tag1""='value1'"
```

```output
AccountName: storageaccountname, ContainerName: containername

Name                 BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime                 IsDeleted  VersionId                     
----                 --------  ------          -----------                    ------------         ---------- ------------                 ---------  ---------                     
testblob             BlockBlob 2097152         application/octet-stream       2020-07-23 09:35:02Z Hot                                     False      2020-07-23T09:35:02.8527357Z *
```

This command gets a single blob with blob tag condition. 
The cmdlet will only success when the blob contains a tag with name "tag1" and value "value1", else the cmdlet will fail with error code 412.

### Example 10: Get blob properties (example: ImmutabilityPolicy) of a single blob
```powershell
$blobProperties = (Get-AzStorageBlob -Container "ContainerName" -Blob "blob" -Context $ctx).BlobProperties
$blobProperties.ImmutabilityPolicy
```

```output
ExpiresOn                   PolicyMode
---------                   ----------
9/17/2024 2:49:32 AM +00:00   Unlocked
```

This example command gets the immutability property of a single blob. You can get a detailed list of blob prTooperties from the **BlobProperties** property, including but not limited to: LastModified, ContentLength, ContentHash, BlobType, LeaseState, AccessTier, ETag, ImmutabilityPolicy, etc...
To list multiple blobs (execute the cmdlet without blob name), use **ListBlobProperties.Properties** instead of **BlobProperties** for better performance.

## PARAMETERS

### -Blob
Specifies a name or name pattern, which can be used for a wildcard search.
If no blob name is specified, the cmdlet lists all the blobs in the specified container.
If a value is specified for this parameter, the cmdlet lists all blobs with names that match this parameter. This parameter supports wildcards anywhere in the string.

```yaml
Type: System.String
Parameter Sets: BlobName
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

```yaml
Type: System.String
Parameter Sets: SingleBlobSnapshotTime, SingleBlobVersionID
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: False
Accept wildcard characters: True
```

### -ClientTimeoutPerRequest
Specifies the client-side time-out interval, in seconds, for one service request.
If the previous call fails in the specified interval, this cmdlet retries the request.
If this cmdlet does not receive a successful response before the interval elapses, this cmdlet returns an error.

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
Specifies the maximum concurrent network calls.
You can use this parameter to limit the concurrency to throttle local CPU and bandwidth usage by specifying the maximum number of concurrent network calls.
The specified value is an absolute count and is not multiplied by the core count.
This parameter can help reduce network connection problems in low bandwidth environments, such as 100 kilobits per second.
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
Specifies the name of the container.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: N, Name

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Context
Specifies the Azure storage account from which you want to get a list of blobs.
You can use the New-AzStorageContext cmdlet to create a storage context.

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
Specifies a continuation token for the blob list.
Use this parameter and the *MaxCount* parameter to list blobs in multiple batches.

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

### -IncludeDeleted
Include Deleted Blob, by default get blob won't include deleted blob.

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

### -IncludeTag
Include blob tags, by default get blob won't include blob tags.

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

### -IncludeVersion
Blob versions will be listed only if this parameter is present, by default get blob won't include blob versions.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: BlobPrefix
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -MaxCount
Specifies the maximum number of objects that this cmdlet returns.

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

### -Prefix
Specifies a prefix for the blob names that you want to get.
This parameter does not support using regular expressions or wildcard characters to search.
This means that if the container has only blobs named "My", "MyBlob1", and "MyBlob2" and you specify "-Prefix My*", the cmdlet returns no blobs.
However, if you specify "-Prefix My", the cmdlet returns "My", "MyBlob1", and "MyBlob2".

```yaml
Type: System.String
Parameter Sets: BlobPrefix
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServerTimeoutPerRequest
Specifies the service side time-out interval, in seconds, for a request.
If the specified interval elapses before the service processes the request, the storage service returns an error.

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

### -SnapshotTime
Blob SnapshotTime

```yaml
Type: System.Nullable`1[System.DateTimeOffset]
Parameter Sets: SingleBlobSnapshotTime
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TagCondition
Optional Tag expression statement to check match condition. 
The blob request will fail when the blob tags does not match the given expression.
See details in https://learn.microsoft.com/en-us/rest/api/storageservices/specifying-conditional-headers-for-blob-service-operations#tags-conditional-operations.

```yaml
Type: System.String
Parameter Sets: BlobName, SingleBlobSnapshotTime, SingleBlobVersionID
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -VersionId
Blob VersionId

```yaml
Type: System.String
Parameter Sets: SingleBlobVersionID
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

### System.String

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob

## NOTES

## RELATED LINKS

[Get-AzStorageBlobContent](./Get-AzStorageBlobContent.md)

[Remove-AzStorageBlob](./Remove-AzStorageBlob.md)

[Set-AzStorageBlobContent](./Set-AzStorageBlobContent.md)
