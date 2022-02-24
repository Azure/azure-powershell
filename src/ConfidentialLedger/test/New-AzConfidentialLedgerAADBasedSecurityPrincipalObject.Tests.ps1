if(($null -eq $TestName) -or ($TestName -contains 'New-AzConfidentialLedgerAADBasedSecurityPrincipalObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConfidentialLedgerAADBasedSecurityPrincipalObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzConfidentialLedgerAADBasedSecurityPrincipalObject' {
    It '__AllParameterSets' {
        $aadSecurityPrincipal = New-AzConfidentialLedgerAadBasedSecurityPrincipalObject `
            -LedgerRoleName "Administrator" `
            -PrincipalId "34621747-6fc8-4771-a2eb-72f31c461f2e" `
            -TenantId "bce123b9-2b7b-4975-8360-5ca0b9b1cd08"
        
        $aadSecurityPrincipal.LedgerRoleName | Should -Be "Administrator"
        $aadSecurityPrincipal.PrincipalId | Should -Be "34621747-6fc8-4771-a2eb-72f31c461f2e"
        $aadSecurityPrincipal.TenantId | Should -Be "bce123b9-2b7b-4975-8360-5ca0b9b1cd08"
    }
}
