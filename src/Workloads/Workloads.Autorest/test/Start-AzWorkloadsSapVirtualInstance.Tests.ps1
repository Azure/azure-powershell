if(($null -eq $TestName) -or ($TestName -contains 'Start-AzWorkloadsSapVirtualInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzWorkloadsSapVirtualInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzWorkloadsSapVirtualInstance' {
    It 'Start' {
        $startResponse = Start-AzWorkloadsSapVirtualInstance -Name $env.SapVirtualInstanceName -ResourceGroupName $env.ResourceGroupName
        $startResponse.Status | Should -Be $env.ProvisioningState
    }

    It 'StartViaIdentity' {
        $startResponseId = Start-AzWorkloadsSapVirtualInstance -InputObject $env.SapIdSub2
        $startResponseId.Status | Should -Be $env.ProvisioningState
    }
}
