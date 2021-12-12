if(($null -eq $TestName) -or ($TestName -contains 'Update-AzSentinelSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzSentinelSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzSentinelSetting' {
    It 'UpdateExpanded' {
        Update-AzSentinelSetting -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -SettingsName Anomalies -Disabled 
        $settings = get-AzSentinelSetting -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $sttings.Name | Should -Not -Contain "Anomalies"
    }

    It 'UpdateViaIdentityExpanded'  {
        $setting = Get-AzSentinelSetting -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName -SettingsName EyesOn 
        Update-AzSentinelSetting -InputObject $setting -Disabled 
        $settings = get-AzSentinelSetting -ResourceGroupName $env.resourceGroupName -WorkspaceName $env.workspaceName
        $sttings.Name | Should -Not -Contain "EyesOn"
    }
}
