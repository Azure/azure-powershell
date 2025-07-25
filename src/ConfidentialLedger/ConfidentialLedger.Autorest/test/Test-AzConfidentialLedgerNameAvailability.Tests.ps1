if(($null -eq $TestName) -or ($TestName -contains 'Test-AzConfidentialLedgerNameAvailability'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Test-AzConfidentialLedgerNameAvailability.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Test-AzConfidentialLedgerNameAvailability' {
    It 'CheckExpanded' {
        $availabilityResult = Test-AzConfidentialLedgerNameAvailability `
            -SubscriptionId $env.SubscriptionId `
            -Name $env.LedgerName `
            -Type "Microsoft.ConfidentialLedger/ledgers"

        $availabilityResult.NameAvailable | Should -Be $false

        $availabilityResult = Test-AzConfidentialLedgerNameAvailability `
            -SubscriptionId $env.SubscriptionId `
            -Name $env.AvailableName `
            -Type "Microsoft.ConfidentialLedger/ledgers"

        $availabilityResult.NameAvailable | Should -Be $true
    }
}
