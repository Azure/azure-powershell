if(($null -eq $TestName) -or ($TestName -contains 'New-AzAppConfigurationSnapshot'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzAppConfigurationSnapshot.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzAppConfigurationSnapshot' {
    It 'CreateExpanded' {
        $snapshotName = "newsnap-test1"
        $filter = @{ Key = $env.key }
        $result = New-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName -Filter $filter
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $snapshotName
        $result.PSObject.Properties.Name | Should -Contain 'Description'
    }

    It 'CreateViaJsonString' {
        $snapshotName = "newsnap-test2"
        $jsonString = '{"filters": [{"key": "' + $env.key + '"}]}'
        $result = New-AzAppConfigurationSnapshot -Endpoint $env.endpoint -Name $snapshotName -JsonString $jsonString
        $result | Should -Not -BeNullOrEmpty
        $result.Name | Should -Be $snapshotName
        $result.PSObject.Properties.Name | Should -Contain 'Description'
    }
}
