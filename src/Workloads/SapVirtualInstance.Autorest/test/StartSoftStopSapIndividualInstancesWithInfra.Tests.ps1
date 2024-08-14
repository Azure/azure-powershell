if(($null -eq $TestName) -or ($TestName -contains 'StartSoftStopSapIndividualInstancesWithInfra'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'StartSoftStopSapIndividualInstancesWithInfra.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'StartSoftStopSapIndividualInstancesWithInfra' {
    It 'SoftStopSapApplicationInstanceWithInfra' {
        $SoftStopSapApplicationInstanceWithInfraResponse = Stop-AzWorkloadsSapApplicationInstance -Name $env.SapApplicationInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -SoftStopTimeoutSecond $env.SoftStopTimeoutSecond -DeallocateVM
        $SoftStopSapApplicationInstanceWithInfraResponse.Status | Should -Be $env.ProvisioningState
        Start-TestSleep -Seconds 300
    }

    It 'StopSapDatabaseInstanceWithInfra' {
        $SoftStopSapDatabaseInstanceWithInfraResponse = Stop-AzWorkloadsSapDatabaseInstance -Name $env.SapDatabseInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -SoftStopTimeoutSecond $env.SoftStopTimeoutSecond -DeallocateVM
        $SoftStopSapDatabaseInstanceWithInfraResponse.Status | Should -Be $env.ProvisioningState
        Start-TestSleep -Seconds 1000
    }

    It 'StopSapCentralInstanceWithInfra' {
        $StopSapCentralInstanceWithInfraResponse = Stop-AzWorkloadsSapCentralInstance -Name $env.SapCentralInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName -DeallocateVM
        $StopSapCentralInstanceWithInfraResponse.Status | Should -Be $env.ProvisioningState
    }

    It 'StartSapCentralInstanceWithInfra' {
        $StartSapCentralInstanceWithInfraResponse = Start-AzWorkloadsSapCentralInstance -Name $env.SapCentralInstanceName -SapVirtualInstanceName $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -StartVM
        $StartSapCentralInstanceWithInfraResponse.Status | Should -Be $env.ProvisioningStateSucceeded
    }

    It 'StartSapDatabaseInstanceWithInfra' {
        $StartSapDatabaseInstanceWithInfraResponse = Start-AzWorkloadsSapDatabaseInstance -Name $env.SapDatabseInstanceName -SapVirtualInstanceName $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -StartVM
        $StartSapDatabaseInstanceWithInfraResponse.Status | Should -Be $env.ProvisioningStateSucceeded
    }

    It 'StartSapApplicationInstanceWithInfra' {
        $StartSapApplicationInstanceWithInfraResponse = Start-AzWorkloadsSapApplicationInstance -Name $env.SapApplicationInstanceName -SapVirtualInstanceName $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -StartVM
        $StartSapApplicationInstanceWithInfraResponse.Status | Should -Be $env.ProvisioningStateSucceeded
    }
}
