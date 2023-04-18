if(($null -eq $TestName) -or ($TestName -contains 'Start-AzWorkloadsSapCentralInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzWorkloadsSapCentralInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzWorkloadsSapCentralInstance' {
    It 'Start' {
        $startResponse = Start-AzWorkloadsSapCentralInstance -Name $env.SapCentralInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $startResponse.Status | Should -Be $env.ProvisioningState
    }

    It 'StartViaIdentity' {
        $startResponseId = Start-AzWorkloadsSapCentralInstance -InputObject $env.CsServerIdSub2
        $startResponseId.Status | Should -Be $env.ProvisioningState
    }
}
