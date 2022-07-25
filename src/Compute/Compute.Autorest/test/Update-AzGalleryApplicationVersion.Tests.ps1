if(($null -eq $TestName) -or ($TestName -contains 'Update-AzGalleryApplicationVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzGalleryApplicationVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzGalleryApplicationVersion' -Tag 'LiveOnly'{
    BeforeAll {
        $env.RandomString = $env.RandomString + "3"
        $galleryName = "testgallery" + $env.RandomString
        $galleryApplicationName = "testgalapp" + $env.RandomString
        $galleryApplicationVersionName = "0.1.0"
        New-AzGallery -ResourceGroupName $env.ResourceGroupName -Name $galleryName -Location $env.Location
        New-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName -Location $env.Location -SupportedOSType Windows

        # create storage account, add container, upload file 
        Import-Module Az.storage
        $storageAccountName = "storacc" + $env.RandomString
        $containerName = "container" + $env.RandomString
        $storacc = New-AzStorageAccount -ResourceGroupName $env.ResourceGroupName -Name $storageAccountName -SkuName Standard_RAGRS -Location $env.Location
        $container = New-AzStorageContainer -Name $containerName -Context $storacc.Context -Permission Container
        $blob = Set-AzStorageBlobContent -File "./test/testfile.txt" -Blob "testfile.txt" -Container $containerName -Context $storacc.Context -BlobType Page
        
        # Create GalleryApplicationVersion 
        New-AzGalleryApplicationVersion -ResourceGroupName $env.ResourceGroupName -Location $env.Location -GalleryName $galleryName -GalleryApplicationName $galleryApplicationName -name $galleryApplicationVersionName -PackageFileLink $blob.ICloudBlob.Uri.AbsoluteUri -Install "powershell -command 'Expand-Archive -Path package.zip -DestinationPath C:\\package\'" -Remove "del C:\\package" 
    }

    It 'UpdateExpanded' {
        $replicaCount1 = 3
        Update-AzGalleryApplicationVersion -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -GalleryApplicationName $galleryApplicationName -Name $galleryApplicationVersionName -ReplicaCount $replicaCount1 -PackageFileLink $blob.ICloudBlob.Uri.AbsoluteUri
        $galAppV = Get-AzGalleryApplicationVersion -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -GalleryApplicationName $galleryApplicationName -Name $galleryApplicationVersionName
        $galAppV.ReplicaCount | Should Be $replicaCount1
    }
    It 'UpdateViaIdentityExpanded' {
        $replicaCount2 = 4
        $galAppV = Get-AzGalleryApplicationVersion -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -GalleryApplicationName $galleryApplicationName -Name $galleryApplicationVersionName
        Update-AzGalleryApplicationVersion -InputObject $galAppV -ReplicaCount $replicaCount2 -PackageFileLink $blob.ICloudBlob.Uri.AbsoluteUri
        $galAppV = Get-AzGalleryApplicationVersion -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -GalleryApplicationName $galleryApplicationName -Name $galleryApplicationVersionName
        $galAppV.ReplicaCount | Should Be $replicaCount2
    }
}
