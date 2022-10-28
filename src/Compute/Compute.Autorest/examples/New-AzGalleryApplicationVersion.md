### Example 1: Create a gallery application version.
```powershell
$ctx = New-AzStorageContext -StorageAccountName $storAccName
$SASToken = New-AzStorageBlobSASToken -Context $ctx -Container $containerName -blob $blobName -Permission r
$storAcc = Get-AzStorageAccount -ResourceGroupName $rgName -Name $storAccName
$blob = Get-AzStorageBlob -Container $containerName -Blob $blobName -Context $storAcc.Context
$SASToken = New-AzStorageBlobSASToken -Container $containerName -Blob $blobName -Permission rwd -Context $storAcc.Context
$SASUri = $blob.ICloudBlob.Uri.AbsoluteUri + $SASToken 
New-AzGalleryApplicationVersion -ResourceGroupName $rgname -Location EastUS -GalleryName $galleryName -GalleryApplicationName $galleryApplicationName -name "0.1.0" -PackageFileLink $SASUri -Install "powershell -command 'Expand-Archive -Path package.zip -DestinationPath C:\\package\'" -Remove "del C:\\package" 
```

Creating a Gallery Application Version. Using SAS Uri for the blob for PackageFileLink.


