if(($null -eq $TestName) -or ($TestName -contains 'StartSoftStopSapVirtualInstancesWithInfra'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'StartSoftStopSapVirtualInstancesWithInfra.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'StartSoftStopSapVirtualInstancesWithInfra' {
    It 'SoftStopSapVirtualInstancesWithInfra' {
        $SoftStopSapVirtualInstancesWithInfraResponse = Stop-AzWorkloadsSapVirtualInstance -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -SoftStopTimeoutSecond $env.SoftStopTimeoutSecond -DeallocateVM
        $SoftStopSapVirtualInstancesWithInfraResponse.Status | Should -Be $env.ProvisioningStateSucceeded
        Start-TestSleep -Seconds 300
    }

    It 'StartSapVirtualInstancesWithInfra' {
        $StartSapVirtualInstancesWithInfraResponse = Start-AzWorkloadsSapVirtualInstance -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -StartVM
        $StartSapVirtualInstancesWithInfraResponse.Status | Should -Be $env.ProvisioningStateSucceeded
    }

    It 'SoftStopSapVirtualInstancesWithInfraAlias' {
        $SoftStopSapVirtualInstancesWithInfraAliasResponse = Stop-AzVIS -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -SoftStopTimeoutSecond $env.SoftStopTimeoutSecond -DeallocateVM
        $SoftStopSapVirtualInstancesWithInfraAliasResponse.Status | Should -Be $env.ProvisioningStateSucceeded
        Start-TestSleep -Seconds 300
    }

    It 'StartSapVirtualInstancesWithInfraAlias' {
        $StartSapVirtualInstancesWithInfraAliasResponse = Start-AzVIS -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -StartVM
        $StartSapVirtualInstancesWithInfraAliasResponse.Status | Should -Be $env.ProvisioningStateSucceeded
    }
}
