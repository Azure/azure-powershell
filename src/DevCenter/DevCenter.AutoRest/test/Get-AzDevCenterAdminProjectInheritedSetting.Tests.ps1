if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminProjectInheritedSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminProjectInheritedSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminProjectInheritedSetting' {
    It 'Get' {
        $settings = Get-AzDevCenterAdminProjectInheritedSetting -ProjectName $env.projectName20 -ResourceGroupName $env.resourceGroupName20 -SubscriptionId $env.SubscriptionId2
        $settings.ProjectCatalogSettingCatalogItemSyncEnableStatus | Should -Be "Enabled"
    }
}
