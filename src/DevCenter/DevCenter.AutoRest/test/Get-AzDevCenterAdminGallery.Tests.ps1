if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminGallery'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminGallery.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminGallery' {
    It 'List' {
        $listOfGalleries = Get-AzDevCenterAdminGallery -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName
        $listOfGalleries.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get' {
        $gallery = Get-AzDevCenterAdminGallery -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name "Default"
        $gallery.Name | Should -Be "Default"
    }

    It 'GetViaIdentity' {
        $gallery = Get-AzDevCenterAdminGallery -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -Name "Default"
        $gallery = Get-AzDevCenterAdminGallery -InputObject $gallery
        $gallery.Name | Should -Be "Default"
    }
}
