if(($null -eq $TestName) -or ($TestName -contains 'Get-AzRecoveryServicesBackupItem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzRecoveryServicesBackupItem.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzRecoveryServicesBackupItem' {
    It 'GetItemsForVault' {
        $subscriptionId = $env.TestCommon.SubscriptionId
        $resourceGroupName = $env.TestCommon.ResourceGroupName
        $vaultName = $env.TestCommon.VaultName
        
        $items = Get-AzRecoveryServicesBackupItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType AzureVM

        $vmItems = $items | Where-Object { $_.BackupManagementType -eq "AzureIaasVM" }
        $vmItems.Count -eq $items.Count | Should -Be $true
    }

    It 'GetItemsForContainer' {
        $subscriptionId = $env.TestCommon.SubscriptionId
        $resourceGroupName = $env.TestCommon.ResourceGroupName
        $vaultName = $env.TestCommon.VaultName
        $containerFriendlyName = "sql-pstest-vm1"  # "sql-migration-vm2"

        $container = Get-AzRecoveryServicesBackupContainer -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -ContainerType AzureVMAppContainer -DatasourceType MSSQL | Where-Object { $_.Name -match $containerFriendlyName }

        $items = Get-AzRecoveryServicesBackupItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -DatasourceType MSSQL -Container $container

        $sqlItems = $items | Where-Object { $_.WorkloadType -eq "SQLDataBase" -and $_.ContainerName -eq $container.Name }
        $sqlItems.Count -eq $items.Count | Should -Be $true
    }

    It 'GetItemsForpolicy' {
        $subscriptionId = $env.TestCommon.SubscriptionId
        $resourceGroupName = $env.TestCommon.ResourceGroupName
        $vaultName = $env.TestCommon.VaultName
        $policyId = $env.TestBackupItem.PolicyId

        $pol =  Get-AzRecoveryServicesBackupProtectionPolicy -ResourceGroupName $resourceGroupName -VaultName $vaultName -PolicySubType "Standard" -DatasourceType MSSQL | Where-Object { $_.Name -match "HourlyLogBackup"  }
        
        $items = Get-AzRecoveryServicesBackupItem -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -Policy $pol

        $policyItems = $items | Where-Object { $_.PolicyId -eq $policyId }
        $policyItems.Count -eq $items.Count | Should -Be $true
    }
}
