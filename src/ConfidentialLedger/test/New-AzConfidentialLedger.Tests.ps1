if(($null -eq $TestName) -or ($TestName -contains 'New-AzConfidentialLedger'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzConfidentialLedger.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzConfidentialLedger' {
    It 'CreateExpanded' {
        $aadSecurityPrincipal = New-AzConfidentialLedgerAadBasedSecurityPrincipalObject `
            -LedgerRoleName $env.AadPrincipalRole `
            -PrincipalId $env.AadPrincipalId `
            -TenantId $env.AadPrincipalTenantId

        $certSecurityPrincipal = New-AzConfidentialLedgerCertBasedSecurityPrincipalObject `
            -Cert $env.CertPrincipalCert `
            -LedgerRoleName $env.CertPrincipalRole

        New-AzConfidentialLedger `
            -Name $env.NewLedgerName `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId `
            -AadBasedSecurityPrincipal $aadSecurityPrincipal `
            -CertBasedSecurityPrincipal $certSecurityPrincipal `
            -LedgerType $env.LedgerType `
            -Location $env.Location `
            -Tag @{Location=$env.Tag0}

        $ledger = Get-AzConfidentialLedger -ResourceGroupName $env.ResourceGroup -Name $env.NewLedgerName       
        $ledger.Name | Should -Be $env.NewLedgerName   

        Remove-AzConfidentialLedger -InputObject $ledger
    }
}
