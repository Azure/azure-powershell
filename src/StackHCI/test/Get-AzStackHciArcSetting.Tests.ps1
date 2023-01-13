if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStackHciArcSetting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStackHciArcSetting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStackHciArcSetting' {
    It 'Get' {
        $job = Get-AzStackHciArcSetting -ClusterName $env.ClusterName -ResourceGroupName $env.ResourceGroup   
        $job.Name | should -be $env.ArcSettingName
    }
}
