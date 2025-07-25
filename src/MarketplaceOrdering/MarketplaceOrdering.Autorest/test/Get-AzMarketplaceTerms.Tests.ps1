if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMarketplaceTerms'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMarketplaceTerms.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMarketplaceTerms' {
    It 'Get' {
        { Get-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" } | Should -Not -Throw
    }

    It 'Get1' {
        { Get-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -OfferType 'virtualmachine' } | Should -Not -Throw
    }
}
