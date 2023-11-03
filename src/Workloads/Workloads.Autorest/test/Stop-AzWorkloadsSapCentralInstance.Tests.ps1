if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzWorkloadsSapCentralInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzWorkloadsSapCentralInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzWorkloadsSapCentralInstance' {
    It 'StopExpanded' {
        $stopResponse = Stop-AzWorkloadsSapCentralInstance -Name $env.SapCentralInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $stopResponse.Status | Should -Be $env.ProvisioningState
    }

    It 'StopViaIdentityExpanded' {
        $stopResponseId = Stop-AzWorkloadsSapCentralInstance -InputObject $env.CsServerIdSub2
        $stopResponseId.Status | Should -Be $env.ProvisioningState
    }
}
