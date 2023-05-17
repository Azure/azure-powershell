if(($null -eq $TestName) -or ($TestName -contains 'Disable-AzRecoveryServicesProtection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Disable-AzRecoveryServicesProtection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Disable-AzRecoveryServicesProtection' {
     
    It 'RetainRecoveryPointsForever' {
        $sub = $env.TestBackup.SubscriptionId
        $rgName = $env.TestBackup.ResourceGroupName
        $vaultName = $env.TestBackup.VaultName
        $vmName = $env.TestBackup.VirtualMachineName
        
        $DebugPreference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName
        Write-Debug  -Message $vmName
        $DebugPreference = "SilentlyContinue"
    
        $item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match $vmName}
        if($item -ne $null)
        {
            Disable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName $rgName -VaultName $vaultName -Item $item -RetainRecoveryPointsForever
            $item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match $vmName}
            $item.Property.ProtectionState | Should be "ProtectionStopped"
        }
        else
        {
            $item | Should be $null
        }
        
    }

    It 'RetainRecoveryPointsAsPerPolicy' {
        #first unlock the immutable state
        $sub = $env.TestBackup.SubscriptionId
        $rgName = $env.TestBackup.ResourceGroupName
        $vaultName = $env.TestBackup.VaultName
        $vmName = $env.TestBackup.VirtualMachineName
        
        $DebugPreference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName
        Write-Debug  -Message $vmName
        $DebugPreference = "SilentlyContinue"
 
        $item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match $vmName}
        $pol=Get-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -PolicyName EnhancedBackupTesting
        if($item -ne $null)
        {
            Disable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName $rgName -VaultName $vaultName -Item $item -RetainRecoveryPointsAsPerPolicy
            $item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match $vmName}
            $item.Property.ProtectionState | Should be "BackupsSuspended"
        }
        else
        {
            $item | Should be $null
        }
    }

    It 'RemoveRecoveryPoints' {
        $sub = $env.TestBackup.SubscriptionId
        $rgName = $env.TestBackup.ResourceGroupName
        $vaultName = $env.TestBackup.VaultName
        $vmName = $env.TestBackup.VirtualMachineName
        
        $DebugPreference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName
        Write-Debug  -Message $vmName
        $DebugPreference = "SilentlyContinue"
    
        $item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match $vmName}
        if($item -ne $null)
        {
            Disable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName $rgName -VaultName $vaultName -Item $item -RemoveRecoveryPoints 
        }
        $item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match $vmName}
    
        $item | Should be $null
    }
 
}
