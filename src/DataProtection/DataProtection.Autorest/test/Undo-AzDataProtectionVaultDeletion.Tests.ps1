if(($null -eq $TestName) -or ($TestName -contains 'Undo-AzDataProtectionVaultDeletion'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Undo-AzDataProtectionVaultDeletion.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Undo-AzDataProtectionVaultDeletion' {
    It 'Test DPP vault soft delete' {
        try {
            # Step 1: Get soft deleted vault
            $deletedVaults = Get-AzDataProtectionSoftDeletedBackupVault -Location $env.TestDPPVaultSoftDelete.Location -SubscriptionId $env.TestDPPVaultSoftDelete.SubscriptionId
            $targetVault = $deletedVaults | Where-Object { $_.OriginalBackupVaultName -eq $env.TestDPPVaultSoftDelete.DeletedVaultName }

            if ($null -eq $targetVault) {
                $activeVault = Get-AzDataProtectionBackupVault -SubscriptionId $env.TestDPPVaultSoftDelete.SubscriptionId -ResourceGroupName $env.TestDPPVaultSoftDelete.ResourceGroupName | Where-Object { $_.Name -eq $env.TestDPPVaultSoftDelete.DeletedVaultName }
                if ($null -eq $activeVault) {
                    $storageSetting = New-AzDataProtectionBackupVaultStorageSettingObject -Type LocallyRedundant -DataStoreType VaultStore
                    New-AzDataProtectionBackupVault -SubscriptionId $env.TestDPPVaultSoftDelete.SubscriptionId -ResourceGroupName $env.TestDPPVaultSoftDelete.ResourceGroupName -VaultName $env.TestDPPVaultSoftDelete.DeletedVaultName -Location $env.TestDPPVaultSoftDelete.Location -StorageSetting $storageSetting -SoftDeleteState AlwaysOn -SoftDeleteRetentionDurationInDay 14
                }
                Remove-AzDataProtectionBackupVault -SubscriptionId $env.TestDPPVaultSoftDelete.SubscriptionId -ResourceGroupName $env.TestDPPVaultSoftDelete.ResourceGroupName -VaultName $env.TestDPPVaultSoftDelete.DeletedVaultName

                $maxRetries = 30
                $retryCount = 0
                while ($null -eq $targetVault -and $retryCount -lt $maxRetries) {
                    Start-TestSleep -Seconds 10
                    $retryCount++
                    $deletedVaults = Get-AzDataProtectionSoftDeletedBackupVault -Location $env.TestDPPVaultSoftDelete.Location -SubscriptionId $env.TestDPPVaultSoftDelete.SubscriptionId
                    $targetVault = $deletedVaults | Where-Object { $_.OriginalBackupVaultName -eq $env.TestDPPVaultSoftDelete.DeletedVaultName }
                }
            }

            $deletedVaults | Should -Not -BeNullOrEmpty
            $targetVault | Should -Not -BeNullOrEmpty
            $targetVault.Name | Should -Not -BeNullOrEmpty
            $targetVault.OriginalBackupVaultName | Should -Not -BeNullOrEmpty
            $targetVault.OriginalBackupVaultResourceGroup | Should -Not -BeNullOrEmpty
            
            # Step 2: Search for soft deleted backup instances in the deleted vault (skip in playback - requires Az.ResourceGraph module)
            $deletedBI = $null
            if ($TestMode -ne 'playback') {
                $deletedBI = Search-AzDataProtectionSoftDeletedVaultBackupInstanceInAzGraph -DeletedVaultId $targetVault.Id -Subscription $env.TestDPPVaultSoftDelete.SubscriptionId
                
                # Step 3: Verify soft deleted backup instances when the deleted vault contains any
                if ($null -ne $deletedBI) {
                    $deletedBI[0].CurrentProtectionState | Should -Be "SoftDeleted"
                    $deletedBI[0].FriendlyName | Should -Not -BeNullOrEmpty
                }
            }
            
            # Step 4: Undo the vault deletion
            $restoredVault = Undo-AzDataProtectionVaultDeletion -DeletedVaultName $targetVault.Name -Location $targetVault.Location -SubscriptionId $env.TestDPPVaultSoftDelete.SubscriptionId -ResourceGroupName $targetVault.OriginalBackupVaultResourceGroup
            
            # Step 5: Verify the vault is restored
            $restoredVault | Should -Not -BeNullOrEmpty
            $restoredVault.Name | Should -Be $targetVault.OriginalBackupVaultName
            $restoredVault.ProvisioningState | Should -Be "Succeeded"
            $restoredVault.Location | Should -Be $targetVault.Location
            
            # Step 6: Verify backup instances are accessible in the restored vault
            $activeVault = Get-AzDataProtectionBackupVault -SubscriptionId $env.TestDPPVaultSoftDelete.SubscriptionId -VaultName $targetVault.OriginalBackupVaultName -ResourceGroupName $targetVault.OriginalBackupVaultResourceGroup
            $activeVault | Should -Not -BeNullOrEmpty
            $activeVault.Name | Should -Be $targetVault.OriginalBackupVaultName
            
            if ($null -ne $deletedBI) {
                # Get and verify backup instances when the deleted vault contained any
                $backupInstances = Get-AzDataProtectionSoftDeletedBackupInstance -SubscriptionId $env.TestDPPVaultSoftDelete.SubscriptionId -ResourceGroupName $targetVault.OriginalBackupVaultResourceGroup -VaultName $targetVault.OriginalBackupVaultName
                $backupInstances | Should -Not -BeNullOrEmpty
                # In live mode, verify count matches previously soft deleted instances
                $backupInstances.Count | Should -BeGreaterOrEqual $deletedBI.Count
            }
        }
        finally {
            # Step 7: Soft delete the vault again to restore original state (skip in playback)
            if ($TestMode -ne 'playback' -and $null -ne $targetVault) {
                Remove-AzDataProtectionBackupVault -ResourceGroupName $targetVault.OriginalBackupVaultResourceGroup -VaultName $targetVault.OriginalBackupVaultName -SubscriptionId $env.TestDPPVaultSoftDelete.SubscriptionId
                
                # Verify the vault is soft deleted again
                Start-Sleep -Seconds 30  # Allow time for deletion to propagate
                $deletedVaultsAfter = Get-AzDataProtectionSoftDeletedBackupVault -Location $env.TestDPPVaultSoftDelete.Location -SubscriptionId $env.TestDPPVaultSoftDelete.SubscriptionId
                $deletedVaultsAfter | Where-Object { $_.OriginalBackupVaultName -eq $targetVault.OriginalBackupVaultName } | Should -Not -BeNullOrEmpty
            }
        }
    }
}
