if(($null -eq $TestName) -or ($TestName -contains 'Set-AzMarketplaceTerms'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzMarketplaceTerms.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzMarketplaceTerms' {
    It 'TermsAccept' {
        { Set-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -Accept } | Should -Not -Throw
    }

    It 'TermsReject' {
        { Set-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -Reject } | Should -Not -Throw
    }

    It 'TermsAcceptViaIdentity' {
        { 
            $terms = Get-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -OfferType 'virtualmachine' 
            Set-AzMarketplaceTerms -Terms $terms -Accept
        } | Should -Not -Throw
    }

    It 'TermsRejectViaIdentity' {
        { 
            $terms = Get-AzMarketplaceTerms  -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" -OfferType 'virtualmachine' 
            Set-AzMarketplaceTerms -Terms $terms -Reject
        } | Should -Not -Throw
    }
}
