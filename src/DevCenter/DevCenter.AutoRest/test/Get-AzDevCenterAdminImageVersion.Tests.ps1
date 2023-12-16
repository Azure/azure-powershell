if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminImageVersion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminImageVersion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminImageVersion' {
    It 'List' {
        $listOfImageVersions = Get-AzDevCenterAdminImageVersion -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -ImageName $env.imageName -GalleryName "Default"
        $listOfImageVersions.Count | Should -Be 1

    }

    It 'Get' {
        $imageVersion = Get-AzDevCenterAdminImageVersion -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -ImageName $env.imageName -VersionName $env.imageVersion -GalleryName "Default"
        $imageVersion.Name | Should -Be $env.imageVersion

    }

    It 'GetViaIdentity' {
        $imageVersion = Get-AzDevCenterAdminImageVersion -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -ImageName $env.imageName -VersionName $env.imageVersion -GalleryName "Default"
        $imageVersion = Get-AzDevCenterAdminImageVersion -InputObject $imageVersion
        $imageVersion.Name | Should -Be $env.imageVersion
    }
}
