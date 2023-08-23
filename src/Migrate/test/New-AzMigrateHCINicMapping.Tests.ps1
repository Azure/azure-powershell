if(($null -eq $TestName) -or ($TestName -contains 'New-AzMigrateHCINicMapping'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMigrateHCINicMapping.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMigrateHCINicMapping' {
    It '__AllParameterSets' {
        $output = New-AzMigrateHCINicMapping -NicID a -TargetNetworkId "/subscriptions/xxx-xxx-xxx/resourceGroups/hciclus-rg/providers/Microsoft.AzureStackHCI/virtualnetworks/external"
        $output.Count | Should -BeGreaterOrEqual 1 
        $output.NicID | Should -Be a
    }
}
