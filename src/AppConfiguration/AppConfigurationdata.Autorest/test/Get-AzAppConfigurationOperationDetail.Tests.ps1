if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAppConfigurationOperationDetail'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppConfigurationOperationDetail.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAppConfigurationOperationDetail' {
    It 'Get' {
        # Create a snapshot to generate a long-running operation, then query its status
        $snapshotName = "opdetail-test1"
        $filter = @{ Key = $env.key }
        New-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName -Filter $filter
        $result = Get-AzAppConfigurationOperationDetail -Endpoint $env.endpoint -Snapshot $snapshotName
        $result | Should -Not -BeNullOrEmpty
        $result.Status | Should -Be "Succeeded"
    }
}
