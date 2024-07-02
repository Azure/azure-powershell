if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMarketplacePrivateStoreUserRule'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMarketplacePrivateStoreUserRule.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMarketplacePrivateStoreUserRule' {
    It 'QueryExpanded' {
        $response = Get-AzMarketplacePrivateStoreUserRule -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -SubscriptionId 1f58b5dd-313c-42ed-84fc-f1e351bba7fb
        $response | Should -Not -Be $null
        $response.Count | Should -BeGreaterThan 0
    }
}
