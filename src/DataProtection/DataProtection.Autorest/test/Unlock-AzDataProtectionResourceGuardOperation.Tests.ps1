if(($null -eq $TestName) -or ($TestName -contains 'Unlock-AzDataProtectionResourceGuardOperation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Unlock-AzDataProtectionResourceGuardOperation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Unlock-AzDataProtectionResourceGuardOperation' {
    It 'UnlockDelete' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    It 'MUAAndSoftDelete' -skip {
        # test MUA and soft delete
        $subscriptionId = $env.TestMUA.SubscriptionId
        $resourceGroupName = $env.TestMUA.ResourceGroupName
        $vaultName = $env.TestMUA.VaultName
        $location = $env.TestMUA.Location
        $resourceGuardName = $env.TestMUA.ResourceGuardName
        $resourceGuardRGName = $env.TestMUA.ResourceGuardRGName
        $resourceGuardSubscription = $env.TestMUA.ResourceGuardSubscription
        $resourceGuardId = $env.TestMUA.ResourceGuardId

        # CreateProxy
        # $resourceGuard = Get-AzDataProtectionResourceGuard -ResourceGroupName $ResourceGuardRGName -Name $resourceGuardName  -SubscriptionId $ResourceGuardSubscription 

        $proxy = Set-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName -ResourceGuardId $resourceGuardId
        
        $proxy.ResourceGuardId -eq $resourceGuardId | Should be $true
        
        # Get soft deleted item
        $softDeletedBI = Get-AzDataProtectionSoftDeletedBackupInstance -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName
        $softDeletedBI -eq $null | Should be $true     
        
        # disable protection (if possible one error wihtout MUA, one success)
        $instances = Get-AzDataProtectionBackupInstance -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        $instances -ne $null | Should be $true
                
        $unlockBI = Unlock-AzDataProtectionResourceGuardOperation -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName -ResourceGuardOperationRequest DeleteBackupInstance -ResourceToBeDeleted $instances[0].Id
        
        $unlockBI -match "2023" | Should be $true
        
        $removeBI = Remove-AzDataProtectionBackupInstance -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName -Name $instances[0].Name
        
        # Get soft deleted item
        $softDeletedBI = Get-AzDataProtectionSoftDeletedBackupInstance -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName
        $softDeletedBI -ne $null | Should be $true
        
        # Disable MUA
        
        $proxy = Get-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId
        $proxy -ne $null | Should be $true
        
        # pass full URL instead of DisableMUA
        
        $unlockProxy = Unlock-AzDataProtectionResourceGuardOperation -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName -ResourceGuardOperationRequest DisableMUA -ResourceToBeDeleted $proxy.Id
        
        $unlockProxy -match "2023" | Should be $true
        
        $proxy = Remove-AzDataProtectionResourceGuardMapping -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName
                
        # Undelete protection
        $UnDeleteBI = Undo-AzDataProtectionBackupInstanceDeletion -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $softDeletedBI.Name 
        
        $softDeletedBI = Get-AzDataProtectionSoftDeletedBackupInstance -ResourceGroupName $resourceGroupName -SubscriptionId $subscriptionId -VaultName $vaultName
        $softDeletedBI -eq $null | Should be $true
        
        # update vault soft delete
        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName
        
        # disable soft delete
        $vault = Update-AzDataProtectionBackupVault -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName -SoftDeleteState 'Off'
        $vault.SoftDeleteState -eq 'Off' | Should be $true
        
        # Enable soft delete
        $vault = Update-AzDataProtectionBackupVault -SubscriptionId $subscriptionId -ResourceGroupName $resourceGroupName -VaultName $vaultName -SoftDeleteState 'On' -SoftDeleteRetentionDurationInDay 10 
        $vault.SoftDeleteState -eq 'On' | Should be $true
    }
}
