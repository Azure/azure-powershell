if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzMarketplaceOrderingAgreementsSignMarketplaceAgreement'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzMarketplaceOrderingAgreementsSignMarketplaceAgreement.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzMarketplaceOrderingAgreementsSignMarketplaceAgreement' {
    It 'Sign' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'SignViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
