if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageDiscoveryScopeObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  # Note: New-AzStorageDiscoveryScopeObject is a local object creation cmdlet and doesn't require recording
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageDiscoveryScopeObject' {
    It '__AllParameterSets' {
        {
            New-AzStorageDiscoveryScopeObject -DisplayName "testScope" -ResourceType "Microsoft.Storage/storageAccounts" -TagKeysOnly "key1" -Tag @{"tag1" = "value1"; "tag2" = "value2"}
        } | Should -Not -Throw
    }
}
