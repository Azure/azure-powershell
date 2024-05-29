

# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
    .SYNOPSIS
    Tests File-only related commands.
#>
function Test-File
{        
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try{
        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue

        $localSrcFile = "localsrcfiletestfile.psd1" #The file need exist before test, and should be 512 bytes aligned
        New-Item $localSrcFile -ItemType File -Force
        $localDestFile = "localdestfiletestfile1.txt"    

        $objectName1 = "filetest1.txt." 
        $objectName2 = "filetest2.txt"  
        $shareName = "filetestshare" 

        #Create a file share 
        New-AzStorageShare $shareName -Context $storageContext
        $Share = Get-AzStorageShare -Name $shareName -Context $storageContext
        Assert-AreEqual $Share.Count 1
        Assert-AreEqual $Share[0].Name $shareName

        # upload file
        $t = Set-AzStorageFileContent -source $localSrcFile -ShareName $shareName -Path $objectName1 -Force -Context $storageContext -asjob
        $t | wait-job
        Assert-AreEqual $t.State "Completed"
        Assert-AreEqual $t.Error $null

        # upload/remove file/dir with -DisAllowTrailingDot            
        $dirName1WithTrailingDot = "testdir1.."      
        $dirName1WithOutTrailingDot = "testdir1" 
        $objectPathWithoutTrailingDot  = "testdir1/filetest1.txt"    
        New-AzStorageDirectory -ShareName $shareName -Path $dirName1WithTrailingDot -Context $storageContext -DisAllowTrailingDot
        $file11 = Set-AzStorageFileContent -source $localSrcFile -ShareName $shareName -Path "$($dirName1WithTrailingDot)/$($objectName1)" -Force -Context $storageContext -DisAllowTrailingDot
        $file = Get-AzStorageFile -ShareName $shareName -Path $objectPathWithoutTrailingDot -Context $storageContext -DisAllowTrailingDot
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].ShareFileClient.Path $objectPathWithoutTrailingDot
        Remove-AzStorageFile -ShareName $shareName -Path "$($dirName1WithTrailingDot)/$($objectName1)" -Context $storageContext -DisAllowTrailingDot
        Remove-AzStorageDirectory -ShareName $shareName -Path $dirName1WithTrailingDot -Context $storageContext -DisAllowTrailingDot

        # list file        
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName1
        Assert-NotNull $file[0].ListFileProperties.Properties.ETag

        if ($Env:OS -eq "Windows_NT")
        {
            Set-AzStorageFileContent -source $localSrcFile -ShareName $shareName -Path $objectName1  -PreserveSMBAttribute -Force -Context $storageContext
        }
        else
        {
            Set-AzStorageFileContent -source $localSrcFile -ShareName $shareName -Path $objectName1 -Force -Context $storageContext
        }
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext 
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName1
        Assert-NotNull $file[0].ListFileProperties.Properties.ETag
        if ($Env:OS -eq "Windows_NT")
        {
            $localFileProperties = Get-ItemProperty $localSrcFile
            Assert-AreEqual $localFileProperties.CreationTime.ToUniversalTime().Ticks $file[0].ListFileProperties.Properties.CreatedOn.ToUniversalTime().Ticks
            Assert-AreEqual $localFileProperties.LastWriteTime.ToUniversalTime().Ticks $file[0].ListFileProperties.Properties.LastWrittenOn.ToUniversalTime().Ticks
            Assert-AreEqual $localFileProperties.Attributes.ToString() $file[0].ListFileProperties.FileAttributes.ToString()
        }

        Start-AzStorageFileCopy -SrcShareName $shareName -SrcFilePath $objectName1 -DestShareName $shareName -DestFilePath $objectName2 -Force -Context $storageContext -DestContext $storageContext
        Get-AzStorageFileCopyState -ShareName $shareName -FilePath $objectName2 -Context $storageContext -WaitForComplete
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 2
        Assert-AreEqual $file[0].Name $objectName1
        Assert-AreEqual $file[1].Name $objectName2

        $t = Get-AzStorageFileContent -ShareName $shareName -Path $objectName1 -Destination $localDestFile -Force -Context $storageContext -asjob
        $t | wait-job
        Assert-AreEqual $t.State "Completed"
        Assert-AreEqual $t.Error $null   
        Assert-AreEqual (Get-FileHash -Path $localDestFile -Algorithm MD5).Hash (Get-FileHash -Path $localSrcFile -Algorithm MD5).Hash
                
        if ($Env:OS -eq "Windows_NT")
        {
            Get-AzStorageFileContent -ShareName $shareName -Path $objectName1 -Destination $localDestFile -PreserveSMBAttribute -Force -Context $storageContext
        }
        else
        {
            Get-AzStorageFileContent -ShareName $shareName -Path $objectName1 -Destination $localDestFile -Force -Context $storageContext
        }
        Assert-AreEqual (Get-FileHash -Path $localDestFile -Algorithm MD5).Hash (Get-FileHash -Path $localSrcFile -Algorithm MD5).Hash
        if ($Env:OS -eq "Windows_NT")
        {
            $file = Get-AzStorageFile -ShareName $shareName -Path $objectName1 -Context $storageContext
            $localFileProperties = Get-ItemProperty $localSrcFile
            Assert-AreEqual $localFileProperties.CreationTime.ToUniversalTime().Ticks $file[0].FileProperties.SmbProperties.FileCreatedOn.ToUniversalTime().Ticks
            Assert-AreEqual $localFileProperties.LastWriteTime.ToUniversalTime().Ticks $file[0].FileProperties.SmbProperties.FileLastWrittenOn.ToUniversalTime().Ticks
            Assert-AreEqual $localFileProperties.Attributes.ToString() $file[0].FileProperties.SmbProperties.FileAttributes.ToString()
        }

        $fileName1 = "new" + $objectName1
        $file = Get-AzStorageFile -ShareName $shareName -Path $objectName1 -Context $storageContext

        $file2 = Rename-AzStorageFile -ShareName $shareName -SourcePath $objectName1 -DestinationPath $fileName1 -Context $storageContext
        Assert-AreEqual $file2.Name $fileName1 
        Assert-AreEqual $file.FileProperties.ContentType $file2.FileProperties.ContentType
        Assert-AreEqual $file.FileProperties.ContentLength $file2.FileProperties.ContentLength

        $file3 = $file2 | Rename-AzStorageFile -DestinationPath $fileName1 -Context $storageContext -Force
        Assert-AreEqual $file3.Name $fileName1 
        Assert-AreEqual $file2.FileProperties.ContentType $file3.FileProperties.ContentType
        Assert-AreEqual $file2.FileProperties.ContentLength $file3.FileProperties.ContentLength
        
        Remove-AzStorageFile -ShareName $shareName -Path $fileName1 -Context $storageContext
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName2

        $dirName = "filetestdir"
        New-AzStorageDirectory -ShareName $shareName -Path $dirName -Context $storageContext    
        $file = Get-AzStorageShare -Name $shareName -Context $storageContext | Get-AzStorageFile -ExcludeExtendedInfo
        Assert-AreEqual $file.Count 2
        Assert-AreEqual $file[0].Name $dirName
        Assert-AreEqual $file[0].GetType().Name "AzureStorageFileDirectory"
        Assert-Null $file[0].ListFileProperties.Properties.ETag
        Assert-AreEqual $file[1].Name $objectName2
        Assert-AreEqual $file[1].GetType().Name "AzureStorageFile"
        Assert-Null $file[1].ListFileProperties.Properties.ETag

        $newDir = "new" + $dirName + ".."
        $dir = Get-AzStorageFile -ShareName $shareName -Path $dirName -Context $storageContext
        $dir2 = Rename-AzStorageDirectory -ShareName $shareName -SourcePath $dirName -DestinationPath $newDir -Context $storageContext
        Assert-AreEqual $newDir $dir2.Name
        Assert-AreEqual $dir.ListFileProperties.IsDirectory $dir2.ListFileProperties.IsDirectory
        Assert-AreEqual $dir.ListFileProperties.FileAttributes $dir2.ListFileProperties.FileAttributes

        $newDir2 = "new2" + $dirName
        $dir3 = $dir2 | Rename-AzStorageDirectory -DestinationPath $newDir2 -Context $storageContext
        Assert-AreEqual $newDir2 $dir3.Name
        Assert-AreEqual $dir2.ListFileProperties.IsDirectory $dir3.ListFileProperties.IsDirectory
        Assert-AreEqual $dir2.ListFileProperties.FileAttributes $dir3.ListFileProperties.FileAttributes

        $dir3 | Remove-AzStorageDirectory
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName2
        Assert-AreEqual $file[0].GetType().Name "AzureStorageFile"

        # Clean Storage Account
        Remove-AzStorageShare -Name $shareName -Force -Context $storageContext
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }
    
}

<#
    .SYNOPSIS
    Tests Blob-only related commands.
#>
function Test-Blob
{
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try{
        $location = Get-ProviderLocation ResourceManagement    
        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue

        $localSrcFile = "localsrcblobtestfile.psd1" #The file need exist before test, and should be 512 bytes aligned
        New-Item $localSrcFile -ItemType File -Force
        $localDestFile = "localdestblobtestfile.txt"
        $localDestFile2 = "localdestblobtestfile2.txt"

        $containerName = "blobtestcontainer"    
        $storageAccountName2 = $storageAccountName + "2"
        New-AzStorageAccount -Name $storageAccountName2 -ResourceGroupName $ResourceGroupName -Location $location -Type 'Standard_LRS' 
        $storageAccountKeyValue2 = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName2)[0].Value
        $storageContext2 = New-AzStorageContext -StorageAccountName $StorageAccountName2 -StorageAccountKey $storageAccountKeyValue2
        $containerName3 = "blobtestcontainer2"
        New-AzStorageContainer $containerName3 -Context $storageContext
        New-AzStorageContainer $containerName3 -Context $storageContext2

        $objectName1 = "blobtest1.txt"
        $objectName2 = "blobtest2.txt"
        $ContentType = "image/jpeg"
        $ContentMD5 = "i727sP7HigloQDsqadNLHw=="
        $StandardBlobTier = "Cool"
        $StandardBlobTier2 = "Hot"

        # Create Container for blob
        New-AzStorageContainer $containerName -Context $storageContext

        # verify set container ACL and Stored Access Policy
        $accessPolicyName = "policy1"
        New-AzStorageContainerStoredAccessPolicy -Name $containerName -Context $storageContext -Policy $accessPolicyName -Permission rw
        $accessPolicy = Get-AzStorageContainerStoredAccessPolicy -Name $containerName -Context $storageContext
        Assert-AreNotEqual $null $accessPolicy
        Assert-AreEqual $accessPolicyName $accessPolicy.Policy
        Set-AzStorageContainerAcl -Name $containerName -Context $storageContext -Permission Blob
        $accessPolicy = Get-AzStorageContainerStoredAccessPolicy -Name $containerName -Context $storageContext
        Assert-AreNotEqual $null $accessPolicy
        Assert-AreEqual $accessPolicyName $accessPolicy.Policy
        $container = Get-AzStorageContainer -Name $containerName -Context $storageContext
        Assert-AreEqual 'Blob' $container.Permission.PublicAccess

        # Upload local file to Azure Storage Blob.
        $t = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob $objectName1 -StandardBlobTier $StandardBlobTier -Force -Properties @{"ContentType" = $ContentType; "ContentMD5" = $ContentMD5} -Context $storageContext -asjob
        $t | wait-job
        Assert-AreEqual $t.State "Completed"
        Assert-AreEqual $t.Error $null
        $blob = Get-AzStorageContainer -Name $containerName -Context $storageContext | Get-AzStorageBlob
        Assert-AreEqual $blob.Count 1
        Assert-AreEqual $blob.Name $objectName1
        Assert-AreEqual $blob.BlobProperties.ContentType $ContentType
        Assert-AreEqual $blob.BlobProperties.AccessTier $StandardBlobTier
        $contentHash = [System.Convert]::ToBase64String($blob.BlobProperties.ContentHash)
        Assert-AreEqual $contentHash $ContentMD5

        $blob.BlobBaseClient.SetAccessTier($StandardBlobTier2)
        $blob.ICloudBlob.FetchAttributes()
        Assert-AreEqual $blob.ICloudBlob.Properties.StandardBlobTier $StandardBlobTier2
        Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob $objectName2 -Force -Properties @{"ContentType" = $ContentType; "ContentMD5" = $ContentMD5} -Context $storageContext
        $blob = Get-AzStorageContainer -Name $containerName -Context $storageContext | Get-AzStorageBlob
        Assert-AreEqual $blob.Count 2
        Get-AzStorageBlob -Container $containerName -Blob $objectName2 -Context $storageContext | Remove-AzStorageBlob -Force 

        #check XSCL Track2 Items works for container
        $container = Get-AzStorageContainer $containerName -Context $storageContext
        $containerProperties = $container.BlobContainerClient.GetProperties().Value
        Assert-AreEqual $container.BlobContainerProperties.ETag $containerProperties.ETag
        Set-AzStorageContainerAcl $containerName -Context $storageContext -Permission Blob
        $containerProperties = $container.BlobContainerClient.GetProperties().Value
        Assert-AreNotEqual $container.BlobContainerProperties.ETag $containerProperties.ETag
        $container.FetchAttributes()
        Assert-AreEqual $container.BlobContainerProperties.ETag $containerProperties.ETag

        #check XSCL Track2 Items works for Blob
        $blob = Get-AzStorageBlob -Container $containerName -Blob $objectName1 -Context $storageContext
        $blobProperties = $blob.BlobClient.GetProperties().Value
        Assert-AreEqual $blob.BlobProperties.ETag $blobProperties.ETag
        Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob $objectName1 -Force -Context $storageContext
        $blobProperties = $blob.BlobClient.GetProperties().Value
        Assert-AreNotEqual $blob.BlobProperties.ETag $blobProperties.ETag
        $blob.FetchAttributes()
        Assert-AreEqual $blob.BlobProperties.ETag $blobProperties.ETag

        # Copy blob to the same container, but with a different name.
        Start-AzStorageBlobCopy -srcContainer $containerName -SrcBlob $objectName1 -DestContainer $containerName -DestBlob $objectName2 -StandardBlobTier $StandardBlobTier -RehydratePriority High -Context $storageContext -DestContext $storageContext
        Get-AzStorageBlobCopyState -Container $containerName -Blob $objectName2 -Context $storageContext
        $blob = Get-AzStorageBlob -Container $containerName -Context $storageContext
        Assert-AreEqual $blob.Count 2
        Assert-AreEqual $blob[0].Name $objectName1
        Assert-AreEqual $blob[1].Name $objectName2
        Assert-AreEqual $blob[1].BlobProperties.AccessTier $StandardBlobTier

        # Download storage blob to compare with the local file.
        Get-AzStorageBlobContent -Container $containerName -Blob $objectName2 -Destination $localDestFile -Force -Context $storageContext
        Assert-AreEqual (Get-FileHash -Path $localDestFile -Algorithm MD5).Hash (Get-FileHash -Path $localSrcFile -Algorithm MD5).Hash
        $t = Get-AzStorageBlobContent -Container $containerName -Blob $objectName2 -Destination $localDestFile2 -Force -Context $storageContext -asjob
        $t | wait-job
        Assert-AreEqual $t.State "Completed"
        Assert-AreEqual $t.Error $null
        Assert-AreEqual (Get-FileHash -Path $localDestFile2 -Algorithm MD5).Hash (Get-FileHash -Path $localSrcFile -Algorithm MD5).Hash

        # upload/download blob which name include "/"
        $blobNameWithFolder = "aa/bb/cc/dd.txt"
        $localFileNameWithFolder= "aa\bb\cc\dd.txt"
        Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob $blobNameWithFolder -Force -Context $storageContext
        Get-AzStorageBlobContent -Container $containerName -Blob $blobNameWithFolder -Destination . -Force -Context $storageContext 
        Assert-AreEqual (Get-FileHash -Path $localFileNameWithFolder -Algorithm MD5).Hash (Get-FileHash -Path $localSrcFile -Algorithm MD5).Hash
        Remove-Item -Path "aa" -Force -Recurse
        Remove-AzStorageBlob -Container $containerName -Blob $blobNameWithFolder -Force -Context $storageContext

        Remove-AzStorageBlob -Container $containerName -Blob $objectName2 -Force -Context $storageContext
        $blob = Get-AzStorageBlob -Container $containerName -Context $storageContext
        Assert-AreEqual $blob.Count 1
        Assert-AreEqual $blob[0].Name $objectName1
        
        $pageBlobName1 = "blobpage1"
        $pageBlobName2 = "blobpage2"
        $b = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob $pageBlobName1 -Force -BlobType page -Context $storageContext
        $task = $b.ICloudBlob.SnapshotAsync() 
        $task.Wait()
        $snapshot = $task.Result  
        $blob = Get-AzStorageBlob -Container $containerName -Context $storageContext | Where-Object {$_.Name -eq $pageBlobName1}
        Assert-AreEqual $blob.Count 2
        Assert-AreEqual $blob[0].ICloudBlob.IsSnapshot $true
        Assert-AreEqual $blob[1].ICloudBlob.IsSnapshot $false

        # Copy snapshot of the source page blob to a destination page blob. The snapshot is copied such that only differential changes 
        # between the previously copied snapshot are transferred to the destination.
        Start-AzStorageBlobIncrementalCopy -srcContainer $containerName -SrcBlob $pageBlobName1 -SrcBlobSnapshotTime $snapshot.SnapshotTime -DestContainer $containerName -DestBlob $pageBlobName2 -Context $storageContext -DestContext $storageContext
        Get-AzStorageBlobCopyState -WaitForComplete -Container $containerName -Blob $pageBlobName2 -Context $storageContext
        $blob = Get-AzStorageBlob -Container $containerName -Context $storageContext | Where-Object {$_.Name -eq $pageBlobName2}
        Assert-AreEqual $blob.Count 2
        Assert-AreEqual $blob[0].ICloudBlob.IsSnapshot $true
        Assert-AreEqual $blob[1].ICloudBlob.IsSnapshot $false
        
        #Upload Blob with properties to container which enabled Immutability Policy
        Set-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName -ContainerName $containerName -ImmutabilityPeriod 1        
        Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob immublob -Force -Properties @{"CacheControl" = "max-age=31536000, private"; "ContentEncoding" = "gzip"; "ContentDisposition" = "123"; "ContentLanguage" = "1234"; "ContentType" = "abc/12345"; } -Metadata @{"tag1" = "value1"; "tag2" = "value22" } -Context $storageContext
        
        $immutabilityPolicy = Get-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName -ContainerName $containerName
        Remove-AzRmStorageContainerImmutabilityPolicy -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName -ContainerName $containerName -Etag $immutabilityPolicy.Etag
        
        # Encryption Scope Test
        $scopename = "testscope" 
        $scopename2 = "testscope2"
        $containerName2 = "testscopecontainer"
        New-AzStorageEncryptionScope -ResourceGroupName $ResourceGroupName -StorageAccountName $storageAccountName -EncryptionScopeName $scopename -StorageEncryption
        New-AzStorageEncryptionScope -ResourceGroupName $ResourceGroupName -StorageAccountName $storageAccountName -EncryptionScopeName $scopename2 -StorageEncryption
        $container = New-AzStorageContainer -Name $containerName2 -Context $storageContext -DefaultEncryptionScope $scopeName -PreventEncryptionScopeOverride $true
        Assert-AreEqual $scopename $container.BlobContainerProperties.DefaultEncryptionScope
        Assert-AreEqual $true $container.BlobContainerProperties.PreventEncryptionScopeOverride
        $blob = Set-AzStorageBlobContent -Context $storageContext -File $localSrcFile -Container $containerName -Blob encryscopetest  -EncryptionScope $scopename
        Assert-AreEqual $scopename $blob.BlobProperties.EncryptionScope
        $blob = Copy-AzStorageBlob -Context $storageContext -SrcContainer $containerName -SrcBlob encryscopetest -DestContainer $containerName -DestBlob encryscopetest -Force  -EncryptionScope $scopename2
        Assert-AreEqual $scopename2 $blob.BlobProperties.EncryptionScope
        $blob = Copy-AzStorageBlob -Context $storageContext -SrcContainer $containerName -SrcBlob encryscopetest -DestContainer $containerName2 -DestBlob "encryscopetest01234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789012345678901234567890123456789" -Force
        Assert-AreEqual $scopename $blob.BlobProperties.EncryptionScope
        Remove-AzStorageContainer -Name $containerName2 -Force -Context $storageContext

        # container softdelete test
        ## Enabled container softdelete,then create and delete a container
        Enable-AzStorageContainerDeleteRetentionPolicy -ResourceGroupName $ResourceGroupName -Name $StorageAccountName -RetentionDays 3
        $containerNamesoftdelete = "softdeletecontainer"
        New-AzStorageContainer -Name $containerNamesoftdelete -Context $storageContext
        Remove-AzStorageContainer -Name $containerNamesoftdelete -Context $storageContext -Force
        ## Get container without -IncludeDeleted, won't list out deleted containers
        $deletedcontainer = Get-AzStorageContainer -Context $storageContext | ?{$_.IsDeleted}
        Assert-AreEqual 0 $deletedcontainer.Count
        ## Get container with -IncludeDeleted, will list out deleted containers
        $deletedcontainer = Get-AzStorageContainer -Context $storageContext -IncludeDeleted | ?{$_.IsDeleted}
        Assert-AreEqual 1 $deletedcontainer.Count
        Assert-AreEqual $true $deletedcontainer.IsDeleted
        Assert-NotNull $deletedcontainer.VersionId
        ## restore container with pipeline, to same container name
        sleep 60 # need wait for some time, or restore will fail with 409 (The specified container is being deleted.)
        $deletedcontainer | Restore-AzStorageContainer  
        $container =  Get-AzStorageContainer -Name $containerNamesoftdelete -Context $storageContext
        Assert-AreEqual 1 $container.Count
        Assert-Null $container.IsDeleted
        Assert-Null $container.VersionId        
        Disable-AzStorageContainerDeleteRetentionPolicy -ResourceGroupName $ResourceGroupName -Name $StorageAccountName 
        Remove-AzStorageContainer -Name $containerNamesoftdelete -Context $storageContext -Force

        # VLW
        ## enabled versioning
        Update-AzStorageBlobServiceProperty -ResourceGroupName $ResourceGroupName -Name $StorageAccountName -IsVersioningEnabled $true
        $containerNamevlw = "vlwcontainer"
        # create container with ImmutableStorageWithVersioning
        New-AzRmStorageContainer -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName -Name $containerNamevlw -EnableImmutableStorageWithVersioning
        # upload a blob
        $objectName = "testblob"
        Set-AzStorageBlobContent -File $localSrcFile -Container $containerNamevlw -Blob $objectName -Force -Context $storageContext
        # manage ImmutabilityPolicy
        $policy = Set-AzStorageBlobImmutabilityPolicy -Container $containerNamevlw -Blob $objectName -ExpiresOn (Get-Date).AddDays(1) -PolicyMode Unlocked -Context $storageContext
        $blob = Get-AzStorageBlob -Container $containerNamevlw -Blob $objectName  -Context $storageContext
        Remove-AzStorageBlobImmutabilityPolicy -Container $containerNamevlw -Blob $objectName  -Context $storageContext 
        $blob = Get-AzStorageBlob -Container $containerNamevlw -Blob $objectName  -Context $storageContext
        # manage legalhold
        Set-AzStorageBlobLegalHold -Container $containerNamevlw -Blob $objectName  -Context $storageContext  -EnableLegalHold
        $blob = Get-AzStorageBlob -Container $containerNamevlw -Blob $objectName  -Context $storageContext
        Set-AzStorageBlobLegalHold -Container $containerNamevlw -Blob $objectName  -Context $storageContext  -DisableLegalHold
        $blob = Get-AzStorageBlob -Container $containerNamevlw -Blob $objectName  -Context $storageContext
        
        $blobTypes = @("Block","Page","Append")
        # Upload blob for all 3 types of blobs 
        foreach ($blobType in $blobTypes) {
            $blobName = $blobType + "SrcBlob"
            $t = Set-AzStorageBlobContent -File $localSrcFile -Container $containerName3 -Blob $blobName -Force -Properties @{"ContentType" = $ContentType} -Context $storageContext -BlobType $blobType
        }
        # Test all 9 directions of copy 
        foreach ($srcType in $blobTypes) {
            foreach ($destType in $blobTypes) {
                $srcBlobName = $srcType + "SrcBlob"
                $destBlobName = $srcType + "To" + $destType + "Blob"
                $copiedBlob = Copy-AzStorageBlob -SrcContainer $containerName3 -SrcBlob $srcBlobName -Context $storageContext -DestContainer $containerName3 -DestBlob $destBlobName -DestContext $storageContext2 -DestBlobType $destType -Force
                Assert-AreEqual $copiedBlob.BlobProperties.BlobType $destType
                Assert-AreEqual $copiedBlob.Name $destBlobName
                Assert-AreEqual $copiedBlob.BlobBaseClient.AccountName $storageAccountName2
            }
        }

        # Clean Storage Account
        Remove-AzStorageContainer -Name $containerName -Force -Context $storageContext
        Remove-AzStorageContainer -Name $containerName3 -Force -Context $storageContext
        Remove-AzStorageContainer -Name $containerName3 -Force -Context $storageContext2
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }
}

<#
    .SYNOPSIS
    Tests Queue related commands.
#>
function Test-Queue
{
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try
    {
        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue

        $queueName = "queue-test"
        New-AzStorageQueue -Name $queueName -Context $storageContext
        $queue = Get-AzStorageQueue -Name $queueName -Context $storageContext
        Assert-AreEqual $queue.Count 1
        Assert-AreEqual $queue[0].Name $queueName

        $queueMessage =  "This is message 1"
        $queue.QueueClient.SendMessage($queueMessage)
        
        $queueCount1 = (Get-AzStorageQueue -Context $storageContext).Count
        Remove-AzStorageQueue -Name $queueName -Force -Context $storageContext
        $queue2 = Get-AzStorageQueue -Context $storageContext # modified, it did not assign to anything 
        if ($null -eq $queue2) { # modified, PS guidelines require null on the left side
            $queueCount2 = 0
        }
        else {
            $queueCount2 = $queue2.Count
        }    
        Assert-AreEqual ($queueCount1-$queueCount2) 1
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }
}

<#
    .SYNOPSIS
    Tests Table related commands.
#>
function Test-Table
{
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try
    {
        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue
        
        # Create Table
        $tableName = "tabletest"
        New-AzStorageTable -Name $tableName -Context $storageContext
        $table =Get-AzStorageTable -Name $tableName -Context $storageContext
        Assert-AreEqual $table.Count 1
        Assert-AreEqual $table[0].Name $tableName

        #Test run Table query - Insert Entity
        $partitionKey = "p123"
        $rowKey = "row123"
        $entity = New-Object -TypeName Microsoft.Azure.Cosmos.Table.DynamicTableEntity -ArgumentList $partitionKey, $rowKey
        $entity.Properties.Add("Name", "name1")
        $entity.Properties.Add("ID", 4567)
        $result = $table.CloudTable.ExecuteAsync([Microsoft.Azure.Cosmos.Table.TableOperation]::Insert($entity)) 
        
        # Create Table Object - which reference to exist Table with SAS
        $tableSASUri = New-AzureStorageTableSASToken -Name $tablename  -Permission "raud" -ExpiryTime (([DateTime]::UtcNow.AddDays(10))) -FullUri -Context $storageContext
        $uri = [System.Uri]$tableSASUri
        $sasTable = New-Object -TypeName Microsoft.Azure.Cosmos.Table.CloudTable $uri 

        #Test run Table query - Query Entity
        $query = New-Object Microsoft.Azure.Cosmos.Table.TableQuery
        ## Define columns to select.
        $list = New-Object System.Collections.Generic.List[string]
        $list.Add("RowKey")
        $list.Add("ID")
        $list.Add("Name")
        ## Set query details.
        $query.FilterString = "ID gt 0"
        $query.SelectColumns = $list
        $query.TakeCount = 20
        ## Execute the query.
        $result = $sasTable.ExecuteQuerySegmentedAsync($query, $null) 
        Assert-AreEqual $result.Result.Results.Count 1

        # Get/Remove Table
        $tableCount1 = (Get-AzStorageTable -Context $storageContext).Count
        Remove-AzStorageTable -Name $tableName -Force -Context $storageContext
        $table2 = Get-AzStorageTable -Context $storageContext
        if ($null -eq $table2) { 
        $tableCount2 = 0
        }
        else {
        $tableCount2 = $table2.Count
        }    
        Assert-AreEqual ($tableCount1-$tableCount2) 1
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }
}

<#
    .SYNOPSIS
    Tests Copy commands between Blobs and Files.
#>
function Test-BlobFileCopy
{
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try
    {
        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue
    
        $localSrcFile = "localsrcblobfilecopytestfile.psd1" #The file need exist before test, and should be 512 bytes aligned
        New-Item $localSrcFile -ItemType File -Force     

        $objectName1 = "blobfilecopytest1.txt"
        $objectName2 = "blobfilecopytest2.txt"
        $objectName3 = "blobfilecopytest3.txt"

        #Blob Creation
        $ContentType = "image/jpeg"
        $ContentMD5 = "i727sP7HigloQDsqadNLHw=="
        
        $containerName = "blobfilecopytestcontainer"  
        New-AzStorageContainer $containerName -Context $storageContext
        Set-AzStorageBlobContent -File $localSrcFile -Container $containerName -Blob $objectName1 -Force -Properties @{"ContentType" = $ContentType; "ContentMD5" = $ContentMD5} -Context $storageContext
        $blob = Get-AzStorageContainer -Name $containerName -Context $storageContext |Get-AzStorageBlob
        Assert-AreEqual $blob.Count 1
        Assert-AreEqual $blob.Name $objectName1
        Assert-AreEqual $blob.BlobProperties.ContentType $ContentType
        $contentHash = [System.Convert]::ToBase64String($blob.BlobProperties.ContentHash)
        Assert-AreEqual $contentHash $ContentMD5

        $shareName = "blobfilecopytestshare"
        #File Creation
        New-AzStorageShare $shareName -Context $storageContext
        $Share = Get-AzStorageShare -Name $shareName -Context $storageContext
        Assert-AreEqual $Share.Count 1
        Assert-AreEqual $Share[0].Name $shareName

        Set-AzStorageFileContent -source $localSrcFile -ShareName $shareName -Path $objectName2 -Force -Context $storageContext
        $file = Get-AzStorageFile -ShareName $shareName -Context $storageContext
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName2

        #blob<->File Copy
        Start-AzStorageBlobCopy  -SrcShareName $shareName -SrcFilePath $objectName2 -DestContainer $containerName -DestBlob $objectName3 -Force -Context $storageContext -DestContext $storageContext
        Get-AzStorageBlobCopyState -Container $containerName -Blob $objectName3 -Context $storageContext    
        $blob = Get-AzStorageBlob -Container $containerName -Blob $objectName3 -Context $storageContext
        Assert-AreEqual $blob.Count 1
        Assert-AreEqual $blob[0].Name $objectName3

        Start-AzStorageFileCopy  -SrcContainerName $containerName -SrcBlobName $objectName1  -DestShareName $shareName -DestFilePath $objectName3 -Force -Context $storageContext -DestContext $storageContext
        Get-AzStorageFileCopyState -ShareName $shareName -FilePath $objectName3 -Context $storageContext    
        $file = Get-AzStorageFile -ShareName $shareName -Path $objectName3 -Context $storageContext
        Assert-AreEqual $file.Count 1
        Assert-AreEqual $file[0].Name $objectName3

        # Clean Storage Account
        Remove-AzStorageShare -Name $shareName -Force -Context $storageContext
        Remove-AzStorageContainer -Name $containerName -Force -Context $storageContext
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }
}

<#
    .SYNOPSIS
    Tests Azure storage service loggin property, service metrics property and CORSRule commands.
#>
function Test-Common
{
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName

    try
    {
        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue

        # wait at most 120*5s=600s for the set sevice property updated on server.
        $retryTimes = 120
        
        # B/F/Q Service properties, in same code path
        $version = "1.0"
        $retentionDays = 2
        $LoggingOperations = "All"

        Set-AzStorageServiceLoggingProperty -ServiceType blob -RetentionDays $retentionDays -Version $version -LoggingOperations $LoggingOperations -Context $storageContext
        $i = 0
        $propertyUpdated = $false
        while (($i -lt $retryTimes ) -and ($propertyUpdated -eq $false))
        {
            $property = Get-AzStorageServiceLoggingProperty -ServiceType blob -Context $storageContext
            if (($property.RetentionDays -eq $retentionDays) -and ($property.Version -eq $version) -and ($property.LoggingOperations -eq $LoggingOperations))
            {
                $propertyUpdated = $true
            }
            else
            {
                sleep 5
                $i = $i + 5
            }
        } 
        $property = Get-AzStorageServiceLoggingProperty -ServiceType blob -Context $storageContext
        Assert-AreEqual $LoggingOperations $property.LoggingOperations.ToString() 
        Assert-AreEqual $version $property.Version 
        Assert-AreEqual $retentionDays $property.RetentionDays  

        $MetricsLevel = "Service"
        Set-AzStorageServiceMetricsProperty -ServiceType blob -Version $version -MetricsType Hour -RetentionDays $retentionDays -MetricsLevel $MetricsLevel -Context $storageContext
        $i = 0
        $propertyUpdated = $false
        while (($i -lt $retryTimes ) -and ($propertyUpdated -eq $false))
        {
            $property = Get-AzStorageServiceMetricsProperty -ServiceType Blob -MetricsType Hour -Context $storageContext
            if (($property.RetentionDays -eq $retentionDays) -and ($property.Version -eq $version) -and ($property.MetricsLevel.ToString()  -eq $MetricsLevel))
            {
                $propertyUpdated = $true
            }
            else
            {
                sleep 5
                $i = $i + 5
            }
        } 				
        $property = Get-AzStorageServiceMetricsProperty -ServiceType Blob -MetricsType Hour -Context $storageContext
        Assert-AreEqual $MetricsLevel $property.MetricsLevel.ToString() 
        Assert-AreEqual $version $property.Version 
        Assert-AreEqual $retentionDays $property.RetentionDays 

        Set-AzStorageCORSRule -ServiceType blob -Context $storageContext -CorsRules (@{
            AllowedHeaders=@("x-ms-blob-content-type","x-ms-blob-content-disposition");
            AllowedOrigins=@("*");
            MaxAgeInSeconds=30;
            AllowedMethods=@("Get","Connect")},
            @{
            AllowedOrigins=@("http://www.fabrikam.com","http://www.contoso.com"); 
            ExposedHeaders=@("x-ms-meta-data*","x-ms-meta-customheader"); 
            AllowedHeaders=@("x-ms-meta-target*","x-ms-meta-customheader");
            MaxAgeInSeconds=30;
            AllowedMethods=@("Put")})
        $i = 0
        $corsRuleUpdated = $false
        while (($i -lt $retryTimes ) -and ($corsRuleUpdated -eq $false))
        {
            $cors = Get-AzStorageCORSRule -ServiceType blob -Context $storageContext
            if ($cors.Count -eq 2)
            {
                $corsRuleUpdated = $true
            }
            else
            {
                sleep 5
                $i = $i + 5
            }
        }
        $cors = Get-AzStorageCORSRule -ServiceType blob -Context $storageContext
        Assert-AreEqual 2 $cors.Count 

        Remove-AzStorageCORSRule -ServiceType blob -Context $storageContext
        $i = 0
        $corsRuleUpdated = $false
        while (($i -lt $retryTimes ) -and ($corsRuleUpdated -eq $false))
        {
            $cors = Get-AzStorageCORSRule -ServiceType blob -Context $storageContext
            if ($cors.Count -eq 0)
            {
                $corsRuleUpdated = $true
            }
            else
            {
                sleep 5
                $i = $i + 5
            }
        }
        $cors = Get-AzStorageCORSRule -ServiceType blob -Context $storageContext
        Assert-AreEqual 0 $cors.Count    
        
        # Table Service properties
        $version = "1.0"
        $retentionDays = 3
        $LoggingOperations = "Delete"

        Set-AzStorageServiceLoggingProperty -ServiceType table -RetentionDays $retentionDays -Version $version -LoggingOperations $LoggingOperations -Context $storageContext
        $i = 0
        $propertyUpdated = $false
        while (($i -lt $retryTimes ) -and ($propertyUpdated -eq $false))
        {
            $property = Get-AzStorageServiceLoggingProperty -ServiceType table -Context $storageContext
            if (($property.RetentionDays -eq $retentionDays) -and ($property.Version -eq $version) -and ($property.LoggingOperations -eq $LoggingOperations))
            {
                $propertyUpdated = $true
            }
            else
            {
                sleep 5
                $i = $i + 5
            }
        } 
        $property = Get-AzStorageServiceLoggingProperty -ServiceType table -Context $storageContext
        Assert-AreEqual $LoggingOperations $property.LoggingOperations.ToString() 
        Assert-AreEqual $version $property.Version 
        Assert-AreEqual $retentionDays $property.RetentionDays  

        $MetricsLevel = "ServiceAndApi"
        Set-AzStorageServiceMetricsProperty -ServiceType table -Version $version -MetricsType Minute -RetentionDays $retentionDays -MetricsLevel $MetricsLevel -Context $storageContext
        $i = 0
        $propertyUpdated = $false
        while (($i -lt $retryTimes ) -and ($propertyUpdated -eq $false))
        {
            $property = Get-AzStorageServiceMetricsProperty -ServiceType table -MetricsType Minute -Context $storageContext
            if (($property.RetentionDays -eq $retentionDays) -and ($property.Version -eq $version) -and ($property.MetricsLevel.ToString()  -eq $MetricsLevel))
            {
                $propertyUpdated = $true
            }
            else
            {
                sleep 5
                $i = $i + 5
            }
        } 				
        $property = Get-AzStorageServiceMetricsProperty -ServiceType table -MetricsType Minute -Context $storageContext
        Assert-AreEqual $MetricsLevel $property.MetricsLevel.ToString() 
        Assert-AreEqual $version $property.Version 
        Assert-AreEqual $retentionDays $property.RetentionDays 

        Set-AzStorageCORSRule -ServiceType table -Context $storageContext -CorsRules (@{
            AllowedHeaders=@("x-ms-blob-content-type");
            AllowedOrigins=@("*");
            MaxAgeInSeconds=20;
            AllowedMethods=@("Get","Connect")})
        $i = 0
        $corsRuleUpdated = $false
        while (($i -lt $retryTimes ) -and ($corsRuleUpdated -eq $false))
        {
            $cors = Get-AzStorageCORSRule -ServiceType table -Context $storageContext
            if ($cors.Count -eq 1)
            {
                $corsRuleUpdated = $true
            }
            else
            {
                sleep 5
                $i = $i + 5
            }
        }
        $cors = Get-AzStorageCORSRule -ServiceType table -Context $storageContext
        Assert-AreEqual 1 $cors.Count 

        Remove-AzStorageCORSRule -ServiceType table -Context $storageContext
        $i = 0
        $corsRuleUpdated = $false
        while (($i -lt $retryTimes ) -and ($corsRuleUpdated -eq $false))
        {
            $cors = Get-AzStorageCORSRule -ServiceType table -Context $storageContext
            if ($cors.Count -eq 0)
            {
                $corsRuleUpdated = $true
            }
            else
            {
                sleep 5
                $i = $i + 5
            }
        }
        $cors = Get-AzStorageCORSRule -ServiceType table -Context $storageContext
        Assert-AreEqual 0 $cors.Count   
    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }    
}

<#
    .SYNOPSIS
    Tests DatalakeGen-only related commands.
#>
function Test-DatalakeGen2
{
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName
    ) 

    New-TestResourceGroupAndStorageAccount -ResourceGroupName $ResourceGroupName -StorageAccountName $StorageAccountName -EnableHNFS $true

    try{

        $storageAccountKeyValue = $(Get-AzStorageAccountKey -ResourceGroupName $ResourceGroupName -Name $StorageAccountName)[0].Value
        $storageContext = New-AzStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $storageAccountKeyValue

        $localSrcFile = "localsrcDatalakeGen2testfile.psd1" #The file need exist before test, and should be 512 bytes aligned
        New-Item $localSrcFile -ItemType File -Force
        $localDestFile = "localdestDatalakeGen2testfile.txt"
        
        $filesystemName = "adlsgen2testfilesystem" 
        $directoryPath1 = "dir1"
        $directoryPath2 = "dir2"
        $directoryPath3 = "dir3"
        $filePath1 = "dir1/Item1.txt"
        $filePath2 = "dir2/Item2.txt"
        $filePath3 = "dir2/Item3.txt"
        $ContentType = "image/jpeg"
        $ContentMD5 = "i727sP7HigloQDsqadNLHw=="

        # Create FileSystem (actually a container)
        New-AzDatalakeGen2FileSystem $filesystemName -Context $storageContext

        # enable soft delete
        Enable-AzStorageDeleteRetentionPolicy -RetentionDays 1  -Context $storageContext

        # Create folders
        $dir1 = New-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $directoryPath1 -Directory -Permission rwxrwxrwx -Umask ---rwx---  -Property @{"ContentEncoding" = "UDF8"; "CacheControl" = "READ"} -Metadata  @{"tag1" = "value1"; "tag2" = "value2" }
        Assert-AreEqual $dir1.Path $directoryPath1
        Assert-AreEqual $dir1.Permissions.ToSymbolicPermissions() "rwx---rwx"
        $dir2 = New-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $directoryPath2 -Directory -Permission r---wx-wT -Umask --x-wx--x
        Assert-AreEqual $dir2.Path $directoryPath2
        Assert-AreEqual $dir2.Permissions.ToSymbolicPermissions() "r------wT"

        # Create (upload) File
        $t = New-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $filePath1 -Source $localSrcFile -Force -AsJob
        $t | wait-job
        Assert-AreEqual $t.State "Completed"
        Assert-AreEqual $t.Error $null
        $file2 = New-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $filePath2 -Source $localSrcFile -Permission rwxrwxrwx -Umask ---rwx--- -Property @{"ContentType" = $ContentType; "ContentMD5" = $ContentMD5}  -Metadata  @{"tag1" = "value1"; "tag2" = "value2" }
        Assert-AreEqual $file2.Path $filePath2
        Assert-AreEqual $file2.Properties.ContentType $ContentType
        Assert-AreEqual $file2.Properties.Metadata.Count 2
        Assert-AreEqual $file2.Permissions.ToSymbolicPermissions() "rwx---rwx"

        # update Blob and Directory
        $ContentType = "application/octet-stream"
        $ContentMD5 = "NW/H9Zxr2md6L1/yhNKdew=="
        $ContentEncoding = "UDF8"
        ## create ACL with 3 ACEs
        $acl = New-AzDataLakeGen2ItemAclObject -AccessControlType user -Permission rw- 
        $acl = New-AzDataLakeGen2ItemAclObject -AccessControlType group -Permission rw- -InputObject $acl 
        $acl = New-AzDataLakeGen2ItemAclObject -AccessControlType other -Permission "-wt" -InputObject $acl
        ##Update File with pipeline		
        $file1 = Get-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $filePath1 | Update-AzDataLakeGen2Item  `
                -Acl $acl `
                -Property @{"ContentType" = $ContentType; "ContentMD5" = $ContentMD5} `
                -Metadata  @{"tag1" = "value1"; "tag2" = "value2" } `
                -Permission rw-rw--wt `
                -Owner '$superuser' `
                -Group '$superuser'
        $sas = New-AzDataLakeGen2SasToken -FileSystem $filesystemName -Path $filePath1 -Permission rw -Context $storageContext
        $ctxsas = New-AzStorageContext -StorageAccountName $StorageAccountName -SasToken $sas
        $file1 = Get-AzDataLakeGen2Item -Context $ctxsas -FileSystem $filesystemName -Path $filePath1
        Assert-AreEqual $file1.Path $filePath1
        Assert-AreEqual $file1.Permissions.ToSymbolicPermissions() "rw-rw--wt"
        Assert-AreEqual $file1.Properties.ContentType $ContentType
        Assert-AreEqual $file1.Properties.Metadata.Count 2
        Assert-AreEqual $file1.Owner '$superuser'
        Assert-AreEqual $file1.Group '$superuser'
        ## Update Directory
        $dir1 = Update-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $directoryPath1 `
                 -Acl $acl `
                 -Property @{"ContentEncoding" = $ContentEncoding} `
                 -Metadata  @{"tag1" = "value1"; "tag2" = "value2" } `
                 -Permission rw-rw--wx `
                 -Owner '$superuser' `
                 -Group '$superuser' 
        $dir1 = Get-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $directoryPath1
        Assert-AreEqual $dir1.Path $directoryPath1
        Assert-AreEqual $dir1.Permissions.ToSymbolicPermissions() "rw-rw--wx"
        Assert-AreEqual $dir1.Properties.ContentEncoding $ContentEncoding
        Assert-AreEqual $dir1.Properties.Metadata.Count 3  # inlucde "hdi_isfolder" which is handle by server
        Assert-AreEqual $dir1.Owner '$superuser'
        Assert-AreEqual $dir1.Group '$superuser'

        #list Items
        ## List direct Items from FileSystem
        $items = Get-AzDataLakeGen2ChildItem -Context $storageContext -FileSystem $filesystemName -FetchPermission
        Assert-AreEqual $items.Count 2
        Assert-NotNull $items[0].Permissions
        $items = Get-AzDataLakeGen2ChildItem -Context $storageContext -FileSystem $filesystemName -Recurse 
        Assert-AreEqual $items.Count 4
        Assert-AreEqual "rw-rw--wx" $items[0].Permissions.ToSymbolicPermissions()

        #download File
        $t  = Get-AzDataLakeGen2ItemContent -Context $storageContext -FileSystem $filesystemName -Path $filePath1 -Destination $localDestFile -AsJob -Force
        $t  | Wait-Job
        Assert-AreEqual $t.State "Completed"
        Assert-AreEqual $t.Error $null
        Assert-AreEqual (Get-FileHash -Path $localDestFile -Algorithm MD5).Hash (Get-FileHash -Path $localSrcFile -Algorithm MD5).Hash

        # Move Items
        ## Move File
        $file3 = Move-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $filePath2 -DestFileSystem $filesystemName -DestPath $filePath3 -Force
        $file3 = Get-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $filePath3
        Assert-AreEqual $file3.Path $filePath3
        Assert-AreEqual $file3.Permissions.ToSymbolicPermissions() $file2.Permissions.ToSymbolicPermissions()
        $file2 = $file3 | Move-AzDataLakeGen2Item -DestFileSystem $filesystemName -DestPath $filePath2
        $file2 = Get-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $filePath2
        Assert-AreEqual $file2.Path $filePath2
        Assert-AreEqual $file2.Permissions.ToSymbolicPermissions() $file3.Permissions.ToSymbolicPermissions()
        ## Move Folder
        $dir3 = Move-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $directoryPath1 -DestFileSystem $filesystemName -DestPath $directoryPath3 
        $dir3 = Get-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $directoryPath3
        Assert-AreEqual $dir3.Path $directoryPath3
        Assert-AreEqual $dir3.Permissions.ToSymbolicPermissions() $dir1.Permissions.ToSymbolicPermissions()
        $dir1 = $dir3 | Move-AzDataLakeGen2Item -DestFileSystem $filesystemName -DestPath $directoryPath1
        $dir1 = Get-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $directoryPath1
        Assert-AreEqual $dir1.Path $directoryPath1

        # Set ACL recusive
        $result = Set-AzDataLakeGen2AclRecursive -Context $storageContext -FileSystem $filesystemName -Acl $acl
        Assert-Null $result.FailedEntries
        Assert-AreEqual 0 $result.TotalFailureCount
        Assert-AreEqual 2 $result.TotalFilesSuccessfulCount
        Assert-AreEqual 3 $result.TotalDirectoriesSuccessfulCount
        $result = Update-AzDataLakeGen2AclRecursive -Context $storageContext -FileSystem $filesystemName -Path $directoryPath1 -Acl $acl -BatchSize 2 -MaxBatchCount 2 
        Assert-Null $result.FailedEntries
        Assert-AreEqual 0 $result.TotalFailureCount
        Assert-AreEqual 1 $result.TotalFilesSuccessfulCount
        Assert-AreEqual 1 $result.TotalDirectoriesSuccessfulCount
        $acl2 = Set-AzDataLakeGen2ItemAclObject -AccessControlType user -Permission rwx -DefaultScope 
        $result = Remove-AzDataLakeGen2AclRecursive -Context $storageContext -FileSystem $filesystemName  -Acl $acl2 
        Assert-Null $result.FailedEntries
        Assert-AreEqual 0 $result.TotalFailureCount
        Assert-AreEqual 2 $result.TotalFilesSuccessfulCount
        Assert-AreEqual 3 $result.TotalDirectoriesSuccessfulCount

        # Remove Items with delete only SAS
        $sas = New-AzStorageContainerSASToken -Name $filesystemName -Permission d -Context $storageContext
        $storageContextSas = New-AzStorageContext -StorageAccountName $storageContext.StorageAccountName -SasToken $sas 
        Remove-AzDataLakeGen2Item -Context $storageContextSas -FileSystem $filesystemName -Path $filePath1 -Force
        Remove-AzDataLakeGen2Item -Context $storageContextSas -FileSystem $filesystemName -Path $directoryPath1 -Force

        # get deleted items from dir and restore with pipeline
        $deletedItems = Get-AzDataLakeGen2DeletedItem -Context $storageContext -FileSystem $filesystemName -Path $directoryPath1 
        Assert-AreEqual 2 $deletedItems.Count
        $restoredItems = $deletedItems | Restore-AzDataLakeGen2DeletedItem
        Assert-AreEqual 2 $restoredItems.Count
        $items = Get-AzDataLakeGen2ChildItem -Context $storageContext -FileSystem $filesystemName -Path $directoryPath1 -Recurse
        Assert-AreEqual 2 $deletedItems.Count # the folder itself won't be list, so the count will be restored item count -1
        
        # get deleted items from filesystem and restore single
        Remove-AzDataLakeGen2Item -Context $storageContext -FileSystem $filesystemName -Path $filePath1 -Force
        $deletedItems = Get-AzDataLakeGen2DeletedItem -Context $storageContext -FileSystem $filesystemName 
        Assert-AreEqual $filePath1 $deletedItems[0].Name 
        Assert-AreEqual 1 $deletedItems.Count
        $restoredItems = Restore-AzDataLakeGen2DeletedItem -Context $storageContext -FileSystem $filesystemName  -Path $deletedItems[0].Path -DeletionId $deletedItems[0].DeletionId 
        Assert-AreEqual 1 $restoredItems.Count
        Assert-AreEqual $deletedItems.Name $restoredItems.Path		

        # Clean Storage Account
        Get-AzDataLakeGen2ChildItem -Context $storageContext -FileSystem $filesystemName | Remove-AzDataLakeGen2Item -Force

        # remove File system (actually a container)
        Remove-AzDatalakeGen2FileSystem $filesystemName -Context $storageContext

    }
    finally
    {
        Clean-ResourceGroup $ResourceGroupName
    }
}

function New-TestResourceGroupAndStorageAccount
{ 
    Param(
        [Parameter(Mandatory = $True)]
        [string]
        $StorageAccountName,
        [Parameter(Mandatory = $True)]
        [string]
        $ResourceGroupName,
        [Parameter(Mandatory = $false)]
        [bool]
        $EnableHNFS = $false
    ) 

    $location = Get-ProviderLocation ResourceManagement    
    $storageAccountType = 'Standard_LRS'# Standard Geo-Reduntand Storage
    New-AzResourceGroup -Name $ResourceGroupName -Location $location
    New-AzStorageAccount -Name $storageAccountName -ResourceGroupName $ResourceGroupName -Location $location -Type $storageAccountType -EnableHierarchicalNamespace $EnableHNFS
}
