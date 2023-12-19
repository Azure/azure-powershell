if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzWorkloadsSapVirtualInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzWorkloadsSapVirtualInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzWorkloadsSapVirtualInstance' {
    It 'StopExpanded' {
        $stopResponse = Stop-AzWorkloadsSapVirtualInstance -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName
        $stopResponse.Status | Should -Be $env.ProvisioningState
    }

    It 'StopViaIdentityExpanded' {
        $stopResponseId = Stop-AzWorkloadsSapVirtualInstance -InputObject $env.SapIdSub2
        $stopResponseId.Status | Should -Be $env.ProvisioningState
    }
	
	It 'SoftStopExpanded' {
        $stopResponse = Stop-AzWorkloadsSapVirtualInstance -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -SoftStopTimeoutSecond 300
        $stopResponse.Status | Should -Be $env.ProvisioningState
    }

    It 'SoftStopViaIdentityExpanded' {
        $stopResponseId = Stop-AzWorkloadsSapVirtualInstance -InputObject $env.SapIdSub2 -SoftStopTimeoutSecond 300
        $stopResponseId.Status | Should -Be $env.ProvisioningState
    }

	It 'StopExpandedWithVM' {
        $stopResponse = Stop-AzWorkloadsSapVirtualInstance -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName -DeallocateVM
        $stopResponse.Status | Should -Be $env.ProvisioningState
    }

    It 'StopViaIdentityExpandedWithVM' {
        $stopResponseId = Stop-AzWorkloadsSapVirtualInstance -InputObject $env.SapIdSub2 -DeallocateVM
        $stopResponseId.Status | Should -Be $env.ProvisioningState
    }
}
