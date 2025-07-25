if(($null -eq $TestName) -or ($TestName -contains 'Get-AzStackHciExtension'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzStackHciExtension.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzStackHciExtension' {
    It 'Get' {
        $job = Get-AzStackHciExtension -Name $env.ExtensionName -ClusterName $env.ClusterName -ArcSettingName $env.ArcSettingName -ResourceGroupName $env.ResourceGroup  
        $job.Name | should -be $env.ExtensionName
    }
}
