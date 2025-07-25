if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzMarketplacePrivateStoreCollectionAllItem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzMarketplacePrivateStoreCollectionAllItem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzMarketplacePrivateStoreCollectionAllItem' {
    It 'Approve' {
        $response = Enable-AzMarketplacePrivateStoreCollectionAllItem -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6 -CollectionId fdb889a1-cf3e-49f0-95b8-2bb012fa0188
        $response | Should -Not -Be $null
        $response.ApproveAllItem | Should -Be $true
    }
}
