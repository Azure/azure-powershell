if(($null -eq $TestName) -or ($TestName -contains 'Update-AzOracleNetworkAnchor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzOracleNetworkAnchor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzOracleNetworkAnchor' {
    $rgName = 'PowerShellTestRg'
    $name   = 'OFake_PowerShellTestNetworkAnchor'

    It 'Update' {
        {
            # Minimal PATCH via JsonString; adjust fields to match recording
            $json = @"
{
  "properties": {
    "displayName": "$name"
  }
}
"@
            $updated = Update-AzOracleNetworkAnchor -Name $name -ResourceGroupName $rgName -JsonString $json
            $updated | Should -Not -BeNullOrEmpty
            $updated.Name | Should -Be $name
        } | Should -Not -Throw
    }
}
