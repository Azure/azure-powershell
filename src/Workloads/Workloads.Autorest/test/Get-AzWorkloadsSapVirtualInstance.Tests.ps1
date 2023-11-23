if(($null -eq $TestName) -or ($TestName -contains 'Get-AzWorkloadsSapVirtualInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzWorkloadsSapVirtualInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzWorkloadsSapVirtualInstance' {
    It 'List1' {
        $sviResponseList = Get-AzWorkloadsSapVirtualInstance -SubscriptionId  $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $sviResponseList.Count | Should -BeGreaterOrEqual 1
    }

    It 'Get' {
        $sviResponse = Get-AzWorkloadsSapVirtualInstance -SubscriptionId  $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $sviResponse.sapProduct | Should -Be $env.SapProduct
        $sviResponse.provisioningState | Should -Be $env.ProvisioningState
    }

    It 'List1' {
        $sviResponseRg = Get-AzWorkloadsSapVirtualInstance -SubscriptionId  $env.WaaSSubscriptionId -ResourceGroupName $env.ResourceGroupName
        $sviResponseRg.Count | Should -BeGreaterOrEqual 1
        $sviResponseRg[0].name | Should -Be $env.SapVirtualInstanceName
    }

    It 'GetViaIdentity' {
        $sviResponse = Get-AzWorkloadsSapVirtualInstance -InputObject $env.SapIdSub2
        $sviResponse.Count | Should -BeGreaterOrEqual 1
    }
}
