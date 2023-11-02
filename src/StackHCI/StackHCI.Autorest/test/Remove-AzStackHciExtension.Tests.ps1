if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStackHciExtension'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStackHciExtension.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzStackHciExtension' {
    It 'Delete' {
        Remove-AzStackHciExtension -ClusterName $env.ClusterName -ArcSettingName $env.ArcSettingName -Name $env.ExtensionName -ResourceGroupName $env.ResourceGroup
    }
}
