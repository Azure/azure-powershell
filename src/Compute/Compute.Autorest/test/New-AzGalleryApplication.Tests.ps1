if(($null -eq $TestName) -or ($TestName -contains 'New-AzGalleryApplication'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzGalleryApplication.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzGalleryApplication' -Tag 'LiveOnly'{
    It 'CreateExpanded' {
        $galleryName = "testgallery" + $env.RandomString
        $galleryApplicationName = "testgalapp" + $env.RandomString
        New-AzGallery -ResourceGroupName $env.ResourceGroupName -Name $galleryName -Location $env.Location
        New-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName -Location $env.Location -SupportedOSType Windows

        $galApp = Get-AzGalleryApplication -ResourceGroupName $env.ResourceGroupName -GalleryName $galleryName -Name $galleryApplicationName
        $galApp.Count | Should BeGreaterThan 0
    }
}
