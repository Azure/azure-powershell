if(($null -eq $TestName) -or ($TestName -contains 'New-AzStackHciExtension'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStackHciExtension.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStackHciExtension' {
    It 'CreateExpanded' {
        New-AzStackHciExtension -ArcSettingName $env.ArcSettingName -ClusterName $env.ClusterName -Name $env.ExtensionName -ResourceGroupName $env.ResourceGroup -ExtensionParameterPublisher $env.ExtensionPublisher
    }
}
