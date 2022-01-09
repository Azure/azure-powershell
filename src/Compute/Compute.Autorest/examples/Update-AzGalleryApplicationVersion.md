### Example 1: Update Replica Count of Gallery Application Version
```powershell
PS C:\> $ctx = New-AzStorageContext -StorageAccountName $storAccName
PS C:\> $SASToken = new-azstorageblobsastoken -Context $ctx -Container $containerName -blob $blobName -Permission r
PS C:\> $storAcc = Get-AzStorageAccount -ResourceGroupName $rgName -Name $storAccName
PS C:\> $blob = Get-AzStorageBlob -Container $containerName -Blob $blobName -Context $storAcc.Context
PS C:\> $SASToken = New-AzStorageBlobSASToken -Container $containerName -Blob $blobName -Permission rwd -Context $storAcc.Context
PS C:\> $SASUri = $blob.ICloudBlob.Uri.AbsoluteUri + "?" +$SASToken 
PS C:\> Update-AzGalleryApplicationVersion -ResourceGroupName $rgname -Location EastUS -GalleryName $galleryName -GalleryApplicationName $galleryApplicationName -name "0.1.0" -PackageFileLink $SASUri -ReplicaCount 3 
```

Updating a Gallery Application Version's replica count. Using SAS Uri for the blob for PackageFileLink.