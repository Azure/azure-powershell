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

    $account = New-AzStorageAccount -ResourceGroupName $rgName -Name $storageAccountName -Location $location -SkuName Standard_GRS -AllowBlobPublicAccess $true
    $ctx = $account.Context 
    $container = New-AzStorageContainer -Name $containerName -Context $ctx 

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
    $b = Set-AzStorageBlobContent -File $testfile512path -Container $containerName -Blob $blobName -StandardBlobTier Cool -Properties @{"ContentType" = $ContentType; "ContentMD5" = $ContentMD5} -Context $ctx -Force
    Assert-AreEqual $blobName $b.Name 
    Assert-AreEqual 512 $b.Length
    Assert-AreEqual $ContentType $b.BlobProperties.ContentType
    Assert-AreEqual "Cool" $b.BlobProperties.AccessTier
    $blobs = Get-AzStorageBlob -Container $containerName -Context $ctx 
    Assert-AreEqual 1 $blobs.Count
    Assert-AreEqual $blobName $blobs[0].Name
    Assert-AreEqual $ContentType $blobs[0].BlobProperties.ContentType
    Assert-AreEqual "Cool" $blobs[0].BlobProperties.AccessTier

    $b.BlobBaseClient.SetAccessTier("Hot")
    $b.FetchAttributes()
    Assert-AreEqual "Hot" $b.BlobProperties.AccessTier

    $b2 = Set-AzStorageBlobContent -File $testfile512path -Container $containerName -Blob $blobName2 -Force -Context $ctx
    $blobs = Get-AzStorageBlob -Container $containerName -Context $ctx 
    Assert-AreEqual 2 $blobs.Count

    $b2 | Remove-AzStorageBlob -Force 
    $blobs = Get-AzStorageBlob -Container $containerName -Context $ctx 
    Assert-AreEqual 1 $blobs.Count

    $container = Get-AzStorageContainer -Name $containerName -Context $ctx
    $containerProperties = $container.BlobContainerClient.GetProperties().Value
    Assert-AreEqual $container.BlobContainerProperties.ETag $containerProperties.ETag
    Set-AzStorageContainerAcl -Name $containerName -Permission Blob -Context $ctx 
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