if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzGalleryApplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzGalleryApplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzGalleryApplication' -Tag 'LiveOnly'{
    BeforeAll { 
        $galleryName = "testgallery" + $env.RandomString
        $galleryApplicationName1 = "testgalapp1" + $env.RandomString
        $galleryApplicationName2 = "testgalapp2" + $env.RandomString
        New-AzGallery -ResourceGroupName $env.ResourceGroupName -Name $galleryName -Location $env.Location
        New-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName1 -Location $env.Location -SupportedOSType Windows
        New-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName2 -Location $env.Location -SupportedOSType Windows
    }
    
    It 'Delete' {
        Remove-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName1
        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName
        $galApp.Count | Should BeGreaterThan 0
    }

    It 'DeleteViaIdentity' {
        $galAppGet = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName2
        $galApp1 = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName
        Remove-AzGalleryApplication -InputObject $galAppGet.Id
        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName
        $galApp.Count | Should BeLessThan $galApp1.Count
    }
}
