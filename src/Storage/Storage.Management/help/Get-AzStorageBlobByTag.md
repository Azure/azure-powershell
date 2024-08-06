---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Storage.dll-Help.xml
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/get-azstorageblobbytag
schema: 2.0.0
---

# Get-AzStorageBlobByTag

## SYNOPSIS
Lists blobs in a storage account across containers, with a blob tag filter sql expression.

## SYNTAX

```
Get-AzStorageBlobByTag -TagFilterSqlExpression <String> [-MaxCount <Int32>]
 [-ContinuationToken <BlobContinuationToken>] [-GetBlobProperty] [-Container <String>]
 [-Context <IStorageContext>] [-ServerTimeoutPerRequest <Int32>] [-ClientTimeoutPerRequest <Int32>]
 [-DefaultProfile <IAzureContextContainer>] [-ConcurrentTaskCount <Int32>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzStorageBlobByTag** cmdlet lists blobs in a storage account across containers, with a blob tag filter sql expression.

## EXAMPLES

### Example 1: List all blobs match a specific blob tag, across containers.
```powershell
Get-AzStorageBlobByTag -TagFilterSqlExpression """tag1""='value1'" -Context $ctx
```

```output
AccountName: storageaccountname, ContainerName: containername1

Name                 BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime                 IsDeleted  VersionId                     
----                 --------  ------          -----------                    ------------         ---------- ------------                 ---------  ---------                     
testblob                                                                                                                                   False                                    
testblob2                                                                                                                                  False                                    

   AccountName: storageaccountname, ContainerName: containername2

Name                 BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime                 IsDeleted  VersionId                     
----                 --------  ------          -----------                    ------------         ---------- ------------                 ---------  ---------                     
testblob3                                                                                                                                   False                                    
testblob4                                                                                                                                   False
```

This command lists all blobs in a storage account, which contains a tag with name "tag1" and value "value1".

### Example 2: List blobs in a specific container and match a specific blob tag
```powershell
Get-AzStorageBlobByTag -Container 'containername' -TagFilterSqlExpression """tag1""='value1'" -Context $ctx
```

```output
AccountName: storageaccountname, ContainerName: containername

Name                 BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime                 IsDeleted  VersionId                     
----                 --------  ------          -----------                    ------------         ---------- ------------                 ---------  ---------                     
test1                                                                                                                                      False                                    
test2                                                                                                                                      False
```

This command lists blobs in a container and match a specific blob tag.

### Example 3: List all blobs match a specific blob tag, across containers, and get the blob properties.
```powershell
Get-AzStorageBlobByTag -TagFilterSqlExpression """tag1""='value1'" -GetBlobProperty
```

```output
AccountName: storageaccountname, ContainerName: containername1

Name                 BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime                 IsDeleted  VersionId                     
----                 --------  ------          -----------                    ------------         ---------- ------------                 ---------  ---------                     
testblob             BlockBlob 2097152         application/octet-stream       2020-07-23 09:35:02Z Hot                                     False      2020-07-23T09:35:02.8527357Z *                                   
testblob2            BlockBlob 1048012         application/octet-stream       2020-07-23 09:35:05Z Hot                                     False      2020-07-23T09:35:05.2504530Z *                             

   AccountName: storageaccountname, ContainerName: containername2

Name                 BlobType  Length          ContentType                    LastModified         AccessTier SnapshotTime                 IsDeleted  VersionId                     
----                 --------  ------          -----------                    ------------         ---------- ------------                 ---------  ---------                     
testblob3            BlockBlob 100             application/octet-stream       2020-07-01 09:55:14Z Hot                                     False      2020-07-01T09:55:14.6507341Z *                      
testblob4            BlockBlob 2024            application/octet-stream       2020-07-01 09:42:11Z Hot                                     False      2020-07-01T09:42:11.4283807Z *
```

This command lists all blobs in a storage account, which contains a tag with name "tag1" and value "value1"， and get the blob properties.
Please note, to get blob properties with parameter -GetBlobProperty, each blob will need an addtional request, so the cmdlet runs show when there are many blobs.

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
Container name, specify this parameter to only return all blobs whose tags match a search expression in the container.

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

### -GetBlobProperty
As the blobs get by tag don't contain blob proeprties, specify tis parameter to get blob properties with an additional request on each blob.

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

### -TagFilterSqlExpression
Filters the result set to only include blobs whose tags match the specified expression.
See details in https://learn.microsoft.com/en-us/rest/api/storageservices/find-blobs-by-tags#remarks.

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

### Microsoft.Azure.Commands.Common.Authentication.Abstractions.IStorageContext

## OUTPUTS

### Microsoft.WindowsAzure.Commands.Common.Storage.ResourceModel.AzureStorageBlob

## NOTES

## RELATED LINKS
