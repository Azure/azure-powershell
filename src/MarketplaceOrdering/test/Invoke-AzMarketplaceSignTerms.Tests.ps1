if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzMarketplaceSignTerms'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzMarketplaceSignTerms.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzMarketplaceSignTerms' {
    It 'Sign' {
        { Invoke-AzMarketplaceSignTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016"} | Should -Not -Throw
    }

    It 'SignViaIdentity' {
        { 
            $terms = Get-AzMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016"
            Invoke-AzMarketplaceSignTerms -InputObject $terms
        } | Should -Not -Throw
    }
}
