### Example 1: Create a gallery application version.
```powershell
PS C:\> $ctx = New-AzStorageContext -StorageAccountName $storAccName
PS C:\> $SASToken = new-azstorageblobsastoken -Context $ctx -Container $containerName -blob $blobName -Permission r
PS C:\> $storAcc = Get-AzStorageAccount -ResourceGroupName $rgName -Name $storAccName
PS C:\> $blob = Get-AzStorageBlob -Container $containerName -Blob $blobName -Context $storAcc.Context
PS C:\> $SASToken = New-AzStorageBlobSASToken -Container $containerName -Blob $blobName -Permission rwd -Context $storAcc.Context
PS C:\> $SASUri = $blob.ICloudBlob.Uri.AbsoluteUri + "?" +$SASToken 
PS C:\> New-AzGalleryApplicationVersion -ResourceGroupName $rgname -Location EastUS -GalleryName $galleryName -GalleryApplicationName $galleryApplicationName -name "0.1.0" -PackageFileLink $SASUri -Install "powershell -command 'Expand-Archive -Path package.zip -DestinationPath C:\\package\'" -Remove "del C:\\package" 

```

Creating a Gallery Application Version. Using SAS Uri for the blob for PackageFileLink.


