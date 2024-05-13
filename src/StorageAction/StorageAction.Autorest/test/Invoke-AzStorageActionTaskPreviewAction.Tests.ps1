if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzStorageActionTaskPreviewAction'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzStorageActionTaskPreviewAction.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzStorageActionTaskPreviewAction' {
    It 'PreviewExpanded' {
        {
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
            $blob1 = New-AzStorageActionTaskPreviewBlobPropertiesObject -Name 'folder1/file1.txt' -Metadata $metadata -Tag $tags -Property $creationTime,$lastModified,$etag,$contentLength,$contentType,$contentEncoding,$contentLanguage,$contentCRC64,$contentMD5,$cacheControl,$contentDisposition,$blobType,$accessTier,$accessTierInferred,$leaseStatus,$leaseState,$serverEncrypted,$tagCount

            $creationTime2 = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Creation-Time" -Value "Wed, 06 Jun 2023 05:23:29 GMT"
            $lastModified2 = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Last-Modified" -Value "Wed, 06 Jun 2023 05:23:29 GMT"
            $etag2 = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Etag" -Value "0x6FB67175454D36D"
            $metadata2 = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "mKey2" -Value "mValue2"
            $tags2 = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "tKey2" -Value "tValue2"
            $blob2 = New-AzStorageActionTaskPreviewBlobPropertiesObject -Name 'folder2/file1.txt' -Metadata $metadata2 -Property $creationTime2,$lastModified2,$etag2 -Tag $tags2
            
            $conmetadata = New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "mContainerKey1" -Value "mContainerValue1"
            Invoke-AzStorageActionTaskPreviewAction -Location $env.region -ActionElseBlockExist -Blob $blob1,$blob2 -ContainerMetadata $conmetadata -ContainerName firstContainer -IfCondition "[[equals(AccessTier, 'Hot')]]"
        } | Should -Not -Throw
    }

    It 'PreviewViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PreviewViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'PreviewViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
