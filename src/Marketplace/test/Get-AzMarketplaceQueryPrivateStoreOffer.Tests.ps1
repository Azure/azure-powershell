if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMarketplaceQueryPrivateStoreOffer'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMarketplaceQueryPrivateStoreOffer.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMarketplaceQueryPrivateStoreOffer' {
    It 'Query'  {
       $res = Get-AzMarketplaceQueryPrivateStoreOffer -PrivateStoreId a260d38c-96cf-492d-a340-404d0c4b3ad6
	$res.Count | Should -BeGreaterOrEqual 2
    }

}
