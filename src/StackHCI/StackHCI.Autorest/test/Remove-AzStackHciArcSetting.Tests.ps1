if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStackHciArcSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStackHciArcSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzStackHciArcSetting' {
    It 'Delete' {
        Remove-AzStackHciArcSetting -Name $env.ArcSettingName -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroup
    }
}
