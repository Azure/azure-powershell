if(($null -eq $TestName) -or ($TestName -contains 'Stop-AzMarketplaceTerms'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Stop-AzMarketplaceTerms.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Stop-AzMarketplaceTerms' {
    It 'Cancel' {
        { Stop-AzMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016" } | Should -Not -Throw
    }

    It 'CancelViaIdentity' {
        { 
            $terms = Get-AzMarketplaceTerms -Publisher "microsoft-ads" -Product "windows-data-science-vm" -Name "windows2016"
            Stop-AzMarketplaceTerms -InputObject $terms
        } | Should -Not -Throw
    }
}
