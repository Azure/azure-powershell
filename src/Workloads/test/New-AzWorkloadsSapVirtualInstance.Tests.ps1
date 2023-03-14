if(($null -eq $TestName) -or ($TestName -contains 'New-AzWorkloadsSapVirtualInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWorkloadsSapVirtualInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWorkloadsSapVirtualInstance' {
    It 'CreateWithDiscovery' {
        $discoveryResponse = New-AzWorkloadsSapVirtualInstance -Name $env.DiscoverSVI -ResourceGroupName $env.DiscoverRG -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -CentralServerVmId $env.CentralServerVmId
        $discoveryResponse.provisioningState | Should -Be $env.ProvisioningState
    }

    It 'CreateWithConfiguration' {
        $configPath = Join-Path $PSScriptRoot $env.ConfigPath
        $createResponse = New-AzWorkloadsSapVirtualInstance -Name $env.CreateSVI -ResourceGroupName $env.ResourceGroupCreateSVI -Environment $env.EnviornmentNonProd -Location $env.Location -SapProduct $env.SapProduct -Configuration $configPath
        $createResponse.provisioningState | Should -Be $env.ProvisioningState
    }

    It 'CreateWithJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
