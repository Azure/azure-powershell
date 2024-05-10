### Example 1: Create blob property object
```powershell
$creationTime = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Creation-Time" -Value "Wed, 07 Jun 2023 05:23:29 GMT"
$metadata = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "mKey1" -Value "mValue1"
$tags = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "tKey1" -Value "tValue1"
New-AzStorageActionTaskPreviewBlobPropertiesObject -Name 'folder1/file1.txt' -Metadata $metadata -Property $creationTime -Tag $tags
```

```output
MatchedBlock : 
Metadata     : {{
                 "key": "mKey1",
                 "value": "mValue1"
               }}
Name         : folder1/file1.txt
Property     : {{
                 "key": "Creation-Time",
                 "value": "Wed, 07 Jun 2023 05:23:29 GMT"
               }}
Tag          : {{
                 "key": "tKey1",
                 "value": "tValue1"
               }}
```

This command create a blob property object.

