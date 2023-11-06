if(($null -eq $TestName) -or ($TestName -contains 'AzContainerAppSecret'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'AzContainerAppSecret.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'AzContainerAppSecret' {
    It 'AzContainerAppSecretList' {
        {
            $config = Get-AzContainerAppSecret -ContainerAppName $env.containerApp1 -ResourceGroupName $env.resourceGroupManaged
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
