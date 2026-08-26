if(($null -eq $TestName) -or ($TestName -contains 'New-AzDocumentDBMongoClusterCmk'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDocumentDBMongoClusterCmk.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDocumentDBMongoClusterCmk' {
    BeforeAll {
        $rg = $env.cmkRg
        $cluster = $env.cmkCluster
        $loc = $env.location
        # Pre-provisioned shared user-assigned identity and key-vault key (referenced by
        # id/url) so this scenario only calls Az.DocumentDB cmdlets and replays cleanly.
        $script:miId = $env.cmkMiId
        $script:keyUrl = $env.cmkKeyUrl
        if ($TestMode -ne 'playback') { New-AzResourceGroup -Name $rg -Location $loc | Out-Null }
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rg -ErrorAction SilentlyContinue | Out-Null }
    }

    It 'creates a cluster with customer-managed key encryption at rest' {
        $password = ConvertTo-SecureString 'CliTest2026!Pw' -AsPlainText -Force
        $created = New-AzDocumentDBMongoCluster -Name $cluster -ResourceGroupName $rg -Location $loc `
            -AdministratorUserName $env.adminUser -AdministratorPassword $password `
            -ComputeTier M30 -StorageSizeGb 128 -StorageType PremiumSSD `
            -ShardingShardCount 1 -HighAvailabilityTargetMode Disabled -ServerVersion 8.0 `
            -UserAssignedIdentity $script:miId `
            -KeyEncryptionKeyIdentityType UserAssignedIdentity `
            -KeyEncryptionKeyIdentityUserAssignedIdentityResourceId $script:miId `
            -CustomerManagedKeyEncryptionKeyUrl $script:keyUrl
        $created.Name | Should -Be $cluster
        $created.ProvisioningState | Should -Be 'Succeeded'
        $created.KeyEncryptionKeyIdentityType | Should -Be 'UserAssignedIdentity'
        $created.KeyEncryptionKeyIdentityUserAssignedIdentityResourceId | Should -Be $script:miId
        $created.CustomerManagedKeyEncryptionKeyUrl | Should -Be $script:keyUrl

        # CMK is the only scenario that uses a managed identity on the cluster today, so
        # validate that the user-assigned identity is actually assigned.
        $identity = Get-AzDocumentDBMongoClusterIdentity -Name $cluster -ResourceGroupName $rg
        $identity.Type | Should -Be 'UserAssigned'
        @($identity.UserAssignedIdentity.Keys) | Should -Contain $script:miId
    }
}
