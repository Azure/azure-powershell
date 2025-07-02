if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWvdSessionHostConfiguration'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWvdSessionHostConfiguration.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWvdSessionHostConfiguration' {
    It 'UpdateExpanded' {    
        $configuration = Update-AzWvdSessionHostConfiguration -SubscriptionId $env.SubscriptionId `
        -ResourceGroupName $env.ResourceGroupPersistent `
        -HostPoolName $env.AutomatedHostpoolPersistent `
        -VMNamePrefix "updateTest" `
        -MarketplaceInfoExactVersion $env.MarketplaceImageVersion

        $configuration.VMNamePrefix | Should -Be "updateTest"
    }
}
