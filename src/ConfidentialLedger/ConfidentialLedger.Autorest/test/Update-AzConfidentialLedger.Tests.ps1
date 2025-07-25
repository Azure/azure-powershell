if(($null -eq $TestName) -or ($TestName -contains 'Update-AzConfidentialLedger'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzConfidentialLedger.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzConfidentialLedger' {
    It 'UpdateExpanded' {
        $ledger = Update-AzConfidentialLedger `
            -Name $env.LedgerName `
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
            -Tag @{Tag0=$env.Tag0; Tag1=$env.Tag1}

        $ledger.Tag["Tag0"] | Should -Be $env.Tag0
        $ledger.Tag["Tag1"] | Should -Be $env.Tag1
    }

    It 'UpdateViaIdentityExpanded' {
        $ledger = Get-AzConfidentialLedger -ResourceGroupName $env.ResourceGroup -Name $env.LedgerName
        $ledger = Update-AzConfidentialLedger `
            -InputObject $ledger `
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
            -Tag @{Tag0=$env.Tag0; Tag1=$env.Tag1; Tag2=$env.Tag2}

        $ledger.Tag["Tag0"] | Should -Be $env.Tag0
        $ledger.Tag["Tag1"] | Should -Be $env.Tag1
        $ledger.Tag["Tag2"] | Should -Be $env.Tag2
    }
}
