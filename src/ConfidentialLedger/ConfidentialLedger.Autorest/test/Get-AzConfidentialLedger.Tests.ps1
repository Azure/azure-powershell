if(($null -eq $TestName) -or ($TestName -contains 'Get-AzConfidentialLedger'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzConfidentialLedger.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzConfidentialLedger' {
    It 'List' {
        $ledgerList = Get-AzConfidentialLedger
        $ledgerList.Count | Should -BeGreaterOrEqual 1
    }

    It 'List1' {
        $ledgerList = Get-AzConfidentialLedger -ResourceGroupName $env.ResourceGroup
        $ledgerList.Count | Should -Be 1
    }

    It 'Get' {
        $ledger = Get-AzConfidentialLedger -ResourceGroupName $env.ResourceGroup -Name $env.LedgerName
        $ledger.Name | Should -Be $env.LedgerName
        $ledger.Tag["Tag0"] | Should -Be $env.Tag0
    }

    It 'GetViaIdentity' {
        $ledger = Get-AzConfidentialLedger -ResourceGroupName $env.ResourceGroup -Name $env.LedgerName
        $ledger = Get-AzConfidentialLedger -InputObject $ledger 
        $ledger.Name | Should -Be $env.LedgerName
    }
}
