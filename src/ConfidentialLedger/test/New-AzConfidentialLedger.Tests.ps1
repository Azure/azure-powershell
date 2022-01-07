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
        New-AzConfidentialLedger `
            -Name $env.NewLedgerName `
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
            -Tag @{Location=$env.Tag0}

        $ledger = Get-AzConfidentialLedger -ResourceGroupName $env.ResourceGroup -Name $env.NewLedgerName
        Write-Host ($ledger | Format-List | Out-String)
        
        $ledger.ProvisioningState | Should -Be "Succeeded"

        Remove-AzConfidentialLedger -InputObject $ledger
    }
}
