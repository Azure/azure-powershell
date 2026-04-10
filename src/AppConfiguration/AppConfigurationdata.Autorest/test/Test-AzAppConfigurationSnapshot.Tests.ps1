if(($null -eq $TestName) -or ($TestName -contains 'Test-AzAppConfigurationSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzAppConfigurationSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzAppConfigurationSnapshot' {
    It 'Check' {
        # Test if any snapshots exist (HEAD on snapshots collection)
        $result = Test-AzAppConfigurationSnapshot -Endpoint $env.endpoint -PassThru
        $result | Should -BeTrue
    }

    It 'CheckByName' {
        # Create a snapshot then test it exists
        $snapshotName = "testsnap-" + (RandomString -allChars $false -len 6)
        $filter = @{ Key = $env.key }
        New-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName -Filter $filter
        $result = Test-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName -PassThru
        $result | Should -BeTrue
    }
}
