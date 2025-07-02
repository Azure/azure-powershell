if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWvdSessionHostConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWvdSessionHostConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWvdSessionHostConfiguration' {


    It 'List'  {
        $sessionHostConfig = Get-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
            -ResourceGroupName $env.ResourceGroupPersistent `
            -HostPoolName $env.AutomatedHostpoolPersistent 
        $sessionHostConfig.Name | Should -Be "default"
    }
}
