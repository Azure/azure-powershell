if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAppConfigurationSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAppConfigurationSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAppConfigurationSnapshot' {
    It 'List' {
        # List all snapshots
        $results = Get-AzAppConfigurationSnapshot -Endpoint $env.endpoint
        $results | Should -Not -BeNullOrEmpty
    }

    It 'GetByName' {
        # Create a snapshot then get it by name
        $snapshotName = "getsnap-test1"
        $filter = @{ Key = $env.key }
        New-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName -Filter $filter
        $result = Get-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $snapshotName
        $result.Status | Should -Be "ready"
    }
}
