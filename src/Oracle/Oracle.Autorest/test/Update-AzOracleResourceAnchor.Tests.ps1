if(($null -eq $TestName) -or ($TestName -contains 'Update-AzOracleResourceAnchor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzOracleResourceAnchor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzOracleResourceAnchor' {
    $rgName = 'PowerShellTestRg'
    $name   = 'OFake_PowerShellTestResourceAnchor'

    It 'Update' {
        {
            # Minimal PATCH body per your API spec (ResourceAnchorUpdate)
            $json = @"
{
  "properties": {
    "displayName": "$name"
  }
}
"@
            $updated = Update-AzOracleResourceAnchor -Name $name -ResourceGroupName $rgName -JsonString $json
            $updated | Should -Not -BeNullOrEmpty
            $updated.Name | Should -Be $name
        } | Should -Not -Throw
    }
}
