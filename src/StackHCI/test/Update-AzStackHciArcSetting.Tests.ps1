if(($null -eq $TestName) -or ($TestName -contains 'Update-AzStackHciArcSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzStackHciArcSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzStackHciArcSetting' {
    It 'UpdateExpanded' {
        Update-AzStackHciArcSetting -ClusterName $env.ClusterName -Name $env.ArcSettingName -ResourceGroupName $env.ResourceGroup
    }

    It 'UpdateViaIdentityExpanded' {
        $arcSetting = Get-AzStackHciArcSetting -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroup 
        Update-AzStackHciArcSetting -InputObject $arcSetting
    }
}
