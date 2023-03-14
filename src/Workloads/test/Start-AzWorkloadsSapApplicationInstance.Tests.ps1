if(($null -eq $TestName) -or ($TestName -contains 'Start-AzWorkloadsSapApplicationInstance'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Start-AzWorkloadsSapApplicationInstance.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Start-AzWorkloadsSapApplicationInstance' {
    It 'Start' {
        $startResponse = Start-AzWorkloadsSapApplicationInstance -Name $env.SapApplicationInstanceName -ResourceGroupName $env.ResourceGroupName -SapVirtualInstanceName $env.SapVirtualInstanceName
        $startResponse.Status | Should -Be $env.ProvisioningState
    }

    It 'StartViaIdentity' {
        $startResponseId = Start-AzWorkloadsSapApplicationInstance -InputObject $env.AppServerIdSub2
        $startResponseId.Status | Should -Be $env.ProvisioningState
    }
}
