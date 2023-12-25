if(($null -eq $TestName) -or ($TestName -contains 'Search-AzDataProtectionBackupVaultInAzGraph'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Search-AzDataProtectionBackupVaultInAzGraph.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Search-AzDataProtectionBackupVaultInAzGraph' -Tag 'LiveOnly' {
    It '__AllParameterSets' {
        $resourceGroupName  = $env.TestCrossRegionRestoreScenario.ResourceGroupName
        $vaultName = $env.TestCrossRegionRestoreScenario.VaultName
        $subscriptionId = $env.TestCrossRegionRestoreScenario.SubscriptionId

        $vault = Search-AzDataProtectionBackupVaultInAzGraph -ResourceGroup $resourceGroupName -Subscription $subscriptionId -Vault $vaultName

        ($vault -ne $null) | Should be $true
        ($vault.Name -eq $vaultName) | Should be $true
    }
}
