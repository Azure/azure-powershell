### Example 1: Run the input conditions against input object metadata properties and designates matched objects
```powershell
#create first blob
$creationTime = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Creation-Time" -Value "Wed, 07 Jun 2023 05:23:29 GMT"
$lastModified = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Last-Modified" -Value "Wed, 07 Jun 2023 05:23:29 GMT"
$etag = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Etag" -Value "0x8DB67175454D36D"
$contentLength = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Content-Length" -Value "38619"
$contentType = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Content-Type" -Value "text/xml"
$contentEncoding = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Content-Encoding" -Value ""
$contentLanguage = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Content-Language" -Value ""
$contentCRC64 = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Content-CRC64" -Value ""
$contentMD5 = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Content-MD5" -Value "njr6iDrmU9+FC89WMK22EA=="
$cacheControl = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Cache-Control" -Value ""
$contentDisposition = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Content-Disposition" -Value ""
$blobType = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "BlobType" -Value "BlockBlob"
$accessTier = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "AccessTier" -Value "Hot"
$accessTierInferred = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "AccessTierInferred" -Value "true"
$leaseStatus = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "LeaseStatus" -Value "unlocked"
$leaseState = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "LeaseState" -Value "available"
$serverEncrypted = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "ServerEncrypted" -Value "true"
$tagCount = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "TagCount" -Value "1"
$metadata = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "mKey1" -Value "mValue1"
$tags = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "tKey1" -Value "tValue1"
$blob1 = New-AzStorageActionTaskPreviewBlobPropertiesObject -Name 'folder1/file1.txt' -Metadata $metadata -Property $creationTime -Tag $tags
#create second blob
$creationTime2 = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Creation-Time" -Value "Wed, 06 Jun 2023 05:23:29 GMT"
$metadata2 = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "mKey2" -Value "mValue2"
$tags2 = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "tKey2" -Value "tValue2"
$blob2 = New-AzStorageActionTaskPreviewBlobPropertiesObject -Name 'folder2/file1.txt' -Metadata $metadata2 -Property $creationTime2 -Tag $tags2

$conmetadata = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "mContainerKey1" -Value "mContainerValue1"
Invoke-AzStorageActionTaskPreviewAction -Location eastus2euap -ActionElseBlockExist -Blob $blob1,$blob2 -ContainerMetadata $conmetadata -ContainerName firstContainer -IfCondition "[[equals(AccessTier, 'Hot')]]"
```

```output
ActionElseBlockExist : True
Blob                 : {{
                         "name": "folder1/file1.txt",
                         "properties": [
                           {
                             "key": "Creation-Time",
                             "value": "Wed, 07 Jun 2023 05:23:29 GMT"
                           },
                           {
                             "key": "Last-Modified",
                             "value": "Wed, 07 Jun 2023 05:23:29 GMT"
                           },
                           {
                             "key": "Etag",
                             "value": "0x8DB67175454D36D"
                           },
                           {
                             "key": "Content-Length",
                             "value": "38619"
                           },
                           {
                             "key": "Content-Type",
                             "value": "text/xml"
                           },
                           {
                             "key": "Content-Encoding",
                             "value": ""
                           },
                           {
                             "key": "Content-Language",
                             "value": ""
                           },
                           {
                             "key": "Content-CRC64",
                             "value": ""
                           },
                           {
                             "key": "Content-MD5",
                             "value": "njr6iDrmU9+FC89WMK22EA=="
                           },
                           {
                             "key": "Cache-Control",
                             "value": ""
                           },
                           {
                             "key": "Content-Disposition",
                             "value": ""
                           },
                           {
                             "key": "BlobType",
                             "value": "BlockBlob"
                           },
                           {
                             "key": "AccessTier",
                             "value": "Hot"
                           },
                           {
                             "key": "AccessTierInferred",
                             "value": "true"
                           },
                           {
                             "key": "LeaseStatus",
                             "value": "unlocked"
                           },
                           {
                             "key": "LeaseState",
                             "value": "available"
                           },
                           {
                             "key": "ServerEncrypted",
                             "value": "true"
                           },
                           {
                             "key": "TagCount",
                             "value": "1"
                           }
                         ],
                         "metadata": [
                           {
                             "key": "mKey1",
                             "value": "mValue1"
                           }
                         ],
                         "tags": [
                           {
                             "key": "tKey1",
                             "value": "tValue1"
                           }
                         ],
                         "matchedBlock": "If"
                       }, {
                         "name": "folder2/file1.txt",
                         "properties": [
                           {
                             "key": "Creation-Time",
                             "value": "Wed, 06 Jun 2023 05:23:29 GMT"
                           },
                           {
                             "key": "Last-Modified",
                             "value": "Wed, 06 Jun 2023 05:23:29 GMT"
                           },
                           {
                             "key": "Etag",
                             "value": "0x6FB67175454D36D"
                           }
                         ],
                         "metadata": [
                           {
                             "key": "mKey2",
                             "value": "mValue2"
                           }
                         ],
                         "tags": [
                           {
                             "key": "tKey2",
                             "value": "tValue2"
                           }
                         ],
                         "matchedBlock": "Else"
                       }}
ContainerMetadata    : {{
                         "key": "mContainerKey1",
                         "value": "mContainerValue1"
                       }}
ContainerName        : firstContainer
IfCondition          : [[equals(AccessTier, 'Hot')]]
```

This command runs the input conditions against input object metadata properties and designates matched objects.

