if(($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminGallery'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminGallery.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminGallery' {
    It 'CreateExpanded' {
        $gallery = New-AzDevCenterAdminGallery -DevCenterName $env.devCenterName -Name $env.galleryNew -ResourceGroupName $env.resourceGroup -GalleryResourceId $env.sigId4
        $gallery.Name | Should -Be $env.galleryNew
        $gallery.ResourceId | Should -Be $env.sigId4

    }

}
