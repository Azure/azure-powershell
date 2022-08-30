if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzConfidentialLedger'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzConfidentialLedger.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzConfidentialLedger' {
    It 'Delete' {
        New-AzConfidentialLedger `
            -Name $env.RemoveLedgerName `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId `
            -AadBasedSecurityPrincipal `
                @{
                    LedgerRoleName=$env.AadPrincipalRole; 
                    PrincipalId=$env.AadPrincipalId; 
                    TenantId=$env.AadPrincipalTenantId
                } `
            -CertBasedSecurityPrincipal `
                @{
                    Cert=$env.CertPrincipalCert; 
                    LedgerRoleName=$env.CertPrincipalRole
                } `
            -LedgerType $env.LedgerType `
            -Location $env.Location `
            -Tag @{Tag0=$env.Tag0}
        Remove-AzConfidentialLedger -Name $env.RemoveLedgerName -ResourceGroupName $env.ResourceGroup

        $ledgerList = Get-AzConfidentialLedger -ResourceGroupName $env.ResourceGroup
        $ledgerList.Name | Should -Not -Contain $env.RemoveLedgerName
    }

    It 'DeleteViaIdentity' {
        $ledger = New-AzConfidentialLedger `
            -Name $env.RemoveLedgerName `
            -ResourceGroupName $env.ResourceGroup `
            -SubscriptionId $env.SubscriptionId `
            -AadBasedSecurityPrincipal `
                @{
                    LedgerRoleName=$env.AadPrincipalRole; 
                    PrincipalId=$env.AadPrincipalId; 
                    TenantId=$env.AadPrincipalTenantId
                } `
            -CertBasedSecurityPrincipal `
                @{
                    Cert=$env.CertPrincipalCert; 
                    LedgerRoleName=$env.CertPrincipalRole
                } `
            -LedgerType $env.LedgerType `
            -Location $env.Location `
            -Tag @{Tag0=$env.Tag0}
        Remove-AzConfidentialLedger -InputObject $ledger

        $ledgerList = Get-AzConfidentialLedger -ResourceGroupName $env.ResourceGroup
        $ledgerList.Name | Should -Not -Contain $env.RemoveLedgerName
    }
}
