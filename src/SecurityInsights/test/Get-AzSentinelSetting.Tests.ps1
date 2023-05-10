if(($null -eq $TestName) -or ($TestName -contains 'Get-AzSentinelSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSentinelSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSentinelSetting' {
    It 'List' {
        $settings = Get-AzSentinelSetting -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $settings.Count | Should -BeGreaterorEqual 1
    }

    It 'Get' {
        $setting = Get-AzSentinelSetting -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -SettingsName "Anomalies"
        $setting.Name | Should -Be "Anomalies"
    }

    It 'GetViaIdentity' -skip {
        $setting = Get-AzSentinelSetting -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -SettingsName "Anomalies"
        $settingViaId = Get-AzSentinelonboardingState -InputObject $setting
        $settingViaId.Name | Should -Be "Anomalies"
    }
}
