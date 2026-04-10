if(($null -eq $TestName) -or ($TestName -contains 'Update-AzAppConfigurationSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAppConfigurationSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzAppConfigurationSnapshot' {
    It 'UpdateExpanded' {
        # Create a snapshot, then archive it
        $snapshotName = "updsnap-" + (RandomString -allChars $false -len 6)
        $filter = @{ Key = $env.key }
        New-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName -Filter $filter
        $result = Update-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName -Status "archived"
        $result | Should -Not -BeNullOrEmpty
        $result.Status | Should -Be "archived"
    }

    It 'ArchiveAndRecover' {
        # Create, archive, then recover a snapshot
        $snapshotName = "updsnap2-" + (RandomString -allChars $false -len 6)
        $filter = @{ Key = $env.key }
        New-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName -Filter $filter
        Update-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName -Status "archived"
        $result = Update-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName -Status "ready"
        $result | Should -Not -BeNullOrEmpty
        $result.Status | Should -Be "ready"
    }
}
