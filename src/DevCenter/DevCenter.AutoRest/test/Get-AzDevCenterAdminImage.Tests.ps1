if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminImage' {
    It 'List' {
        $listOfImages = Get-AzDevCenterAdminImage -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName
        $listOfImages.Count | Should -BeGreaterOrEqual 19
    }

    It 'List1' {
        $listOfImages = Get-AzDevCenterAdminImage -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -GalleryName "Default"
        $listOfImages.Count | Should -Be 18
    }

    It 'Get' {
        $image = Get-AzDevCenterAdminImage -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName -GalleryName "Default" -Name $env.imageName
        $image.Description | Should -Be "Windows 11 Enterprise + OS Optimizations 22H2"
        $image.HibernateSupport | Should -Be "Enabled"
        $image.Name | Should -Be "microsoftwindowsdesktop_windows-ent-cpc_win11-22h2-ent-cpc-os"
        $image.Offer | Should -Be "windows-ent-cpc"
        $image.Publisher | Should -Be "MicrosoftWindowsDesktop"
        $image.Sku | Should -Be "win11-22h2-ent-cpc-os"
    }
}
