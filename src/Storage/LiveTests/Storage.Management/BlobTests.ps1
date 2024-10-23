Invoke-LiveTestScenario -Name "Blob basics" -Description "Test blob basic operation" -ScenarioScript `
{
    param ($rg)

    $rgName = $rg.ResourceGroupName
    $storageAccountName = New-LiveTestStorageAccountName
    $containerName = New-LiveTestResourceName
    $location = $rg.Location
    $ContentType = "image/jpeg"
    $ContentMD5 = "i727sP7HigloQDsqadNLHw=="
    $testfile512path = "$PSScriptRoot\TestFiles\testfile512"

    $account = New-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Location $location -SkuName Standard_GRS -AllowBlobPublicAccess $true -AllowSharedKeyAccess $true -Tag @{"Az.Sec.DisableAllowSharedKeyAccess::Skip" = "For Powershell test."}
    $ctx = $account.Context
    $ctx1 = New-AzStorageContext -StorageAccountName $storageAccountName -StorageAccountKey (Get-AzStorageAccountKey -ResourceGroupName $rgName -Name $storageAccountName)[0].Value

    $container = New-AzStorageContainer -Name $containerName -Context $ctx
    $containerSAS = New-AzStorageContainerSASToken -Name $containerName -Permission radwl -ExpiryTime 5000-01-01 -Context $ctx
    $sasCtx = New-AzStorageContext -SasToken $containerSAS -StorageAccountName $storageAccountName

    # container ACL and stored access policy
    $accessPolicyName = "policy1"
    New-AzStorageContainerStoredAccessPolicy -Container $containerName -Policy $accessPolicyName -Context $ctx -Permission rw
    $accessPolicy = Get-AzStorageContainerStoredAccessPolicy -Container $containerName -Context $ctx
    Assert-AreNotEqual $null $accessPolicy
    Assert-AreEqual $accessPolicyName $accessPolicy.Policy
    Set-AzStorageContainerAcl -Name $containerName -Permission Blob -Context $ctx
    $container = Get-AzStorageContainer -Name $containerName -Context $ctx
    Assert-AreEqual "Blob" $container.Permission.PublicAccess

    # upload
    $blobName = New-LiveTestResourceName
    $blobName2 = New-LiveTestResourceName
    $blobName3 = "blob3" + $blobName
    $b = Set-AzStorageBlobContent -File $testfile512path -Container $containerName -Blob $blobName -StandardBlobTier Cool -Properties @{"ContentType" = $ContentType; "ContentMD5" = $ContentMD5 } -Context $ctx -Force
    Assert-AreEqual $blobName $b.Name
    Assert-AreEqual 512 $b.Length
    Assert-AreEqual $ContentType $b.BlobProperties.ContentType
    Assert-AreEqual "Cool" $b.BlobProperties.AccessTier
    $blobs = Get-AzStorageBlob -Container $containerName -Context $ctx
    Assert-AreEqual 1 $blobs.Count
    Assert-AreEqual $blobName $blobs[0].Name
    Assert-AreEqual $ContentType $blobs[0].BlobProperties.ContentType
    Assert-AreEqual "Cool" $blobs[0].BlobProperties.AccessTier

    $blob = Get-AzStorageBlob -Container $containerName -Blob $blobName -Context $sasCtx
    Assert-AreEqual $blobName $blob.Name
    Assert-AreEqual 512 $blob.Length
    Assert-AreEqual $ContentType $blob.BlobProperties.ContentType

    $b.BlobBaseClient.SetAccessTier("Hot")
    $b.FetchAttributes()
    Assert-AreEqual "Hot" $b.BlobProperties.AccessTier

    $b2 = Set-AzStorageBlobContent -File $testfile512path -Container $containerName -Blob $blobName2 -Force -Context $ctx1
    $blobs = Get-AzStorageBlob -Container $containerName -Context $ctx
    Assert-AreEqual 2 $blobs.Count
    $b3 = Set-AzStorageBlobContent -File $testfile512path -Container $containerName -Blob $blobName3 -Force -Context $sasCtx
    $b2.BlobBaseClient.CreateSnapshot()

    $blobs = Get-AzStorageBlob -Container $containerName -Prefix "blob3" -Context $ctx1
    Assert-AreEqual 1 $blobs.Count
    Assert-AreEqual $blobName3 $blobs[0].Name

    $blobs = Get-AzStorageBlob -Container $containerName -Context $ctx
    $snapshotblob = $blobs | ? { $_.SnapshotTime -ne $null } | Select-Object -First 1
    $blob = Get-AzStorageBlob -Container $containerName -Blob $blobName2 -SnapshotTime $snapshotblob.SnapshotTime -Context $ctx
    Assert-AreEqual $blobName2 $blob.Name
    Assert-AreEqual $snapshotblob.SnapshotTime $blob.SnapshotTime

    $blob = Set-AzStorageBlobContent -File $testfile512path -Container $containerName -Blob $blobName3 -Tag @{"Tag1" = "Value2"; "Tag2" = "Value2" } -Context $ctx1 -Force
    $blob = Get-AzStorageBlob -Blob $blobName3 -Container $containerName -IncludeTag -Context $ctx
    Assert-AreEqual $blobName3 $blob.Name
    Assert-AreEqual 2 $blob.TagCount
    Assert-AreEqual 2 $blob.Tags.Count

    Update-AzStorageBlobServiceProperty -ResourceGroupName $rgName -StorageAccountName $storageAccountName -IsVersioningEnabled $true
    sleep 30
    $blob = Set-AzStorageBlobContent -File $testfile512path -Container $containerName -Blob $blobName3 -Context $sasctx -Force
    $blobs = Get-AzStorageBlob -Container $containerName -Context $ctx -IncludeVersion
    $versionBlob = $blobs | ? { $_.VersionId -ne $null } | Select-Object -First 1
    $blob = Get-AzStorageBlob -Container $containerName -Blob $blobName3 -VersionId $versionBlob.VersionId -Context $ctx1
    Assert-AreEqual $blobName3 $blob.Name
    Assert-AreEqual $versionBlob.VersionId $blob.VersionId

    $b2 | Remove-AzStorageBlob -Force
    $blobs = Get-AzStorageBlob -Container $containerName -Context $ctx
    Assert-AreEqual 2 $blobs.Count

    $container = Get-AzStorageContainer -Name $containerName -Context $ctx1
    $containerProperties = $container.BlobContainerClient.GetProperties().Value
    Assert-AreEqual $container.BlobContainerProperties.ETag $containerProperties.ETag
    Set-AzStorageContainerAcl -Name $containerName -Permission Blob -Context $ctx1
    $containerProperties = $container.BlobContainerClient.GetProperties().Value
    Assert-AreNotEqual $container.BlobContainerProperties.ETag $containerProperties.ETag
    $container.FetchAttributes()
    Assert-AreEqual $container.BlobContainerProperties.ETag $containerProperties.ETag

    # sync copy
    $copyBlobName1 = New-LiveTestResourceName
    $copyBlobName2 = New-LiveTestResourceName
    $b = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob $blobName -DestContainer $containerName -DestBlob $copyBlobName1 -Context $ctx -StandardBlobTier Hot -RehydratePriority High -Force
    Assert-AreEqual $copyBlobName1 $b.Name
    Assert-AreEqual "Hot" $b.AccessTier
    Assert-AreEqual 512 $b.Length
    $job = Copy-AzStorageBlob -SrcContainer $containerName -SrcBlob $blobName -DestContainer $containerName -DestBlob $copyBlobName1 -Context $ctx -StandardBlobTier Hot -RehydratePriority High -Force -AsJob
    $bcopy = Receive-Job -Job $job -Wait -AutoRemoveJob
    Assert-AreEqual $copyBlobName1 $bcopy.Name

    $blobSASUri = $b | New-AzStorageBlobSASToken -Permission rt -ExpiryTime 9999-01-01 -FullUri
    $b2 = Copy-AzStorageBlob -AbsoluteUri $blobSASUri -DestContainer $containerName -DestBlob $copyBlobName2 -Context $ctx -Force
    Assert-AreEqual $copyBlobName2 $b2.Name
    Assert-AreEqual 512 $b2.Length

    # async copy
    Start-AzStorageBlobCopy -SrcContainer $containerName -SrcBlob $blobName -DestContainer $containerName -DestBlob $copyBlobName1 -StandardBlobTier Cool -RehydratePriority High -Context $ctx -DestContext $ctx -Force
    Get-AzStorageBlobCopyState -Container $containerName -Blob $copyBlobName1 -Context $ctx
    sleep 5
    $b = Get-AzStorageBlob -Blob $copyBlobName1 -Container $containerName -Context $ctx
    Assert-AreEqual $copyBlobName1 $b.Name
    Assert-AreEqual "Cool" $b.AccessTier
}
