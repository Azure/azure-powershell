if(($null -eq $TestName) -or ($TestName -contains 'Enable-AzRecoveryServicesProtection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Enable-AzRecoveryServicesProtection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Enable-AzRecoveryServicesProtection' {
        It 'EnableProtection' {
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
        
        $pol=Get-AzRecoveryServicesBackupPolicy -ResourceGroupName $rgName -VaultName $vaultName -PolicyName EnhancedBackupTesting
        $item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match $vmName}
        if($item -ne $null) #modify protection
        {
            Enable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName $rgName -VaultName $vaultName -Item $item -PolicyId $pol.Id -InclusionDisksList "1","2"
            $item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match $vmName}
            $item.Property.ProtectionState | Should be "IRPending"
            $item.Property.PolicyId | Should be $pol.Id
            $item.Property.DiskExclusionPropertyDiskLunList | Should be "1","2"
            $item.Property.DiskExclusionPropertyIsInclusionList | Should be $true
        }
        else    #configure protection
        {
            Enable-AzRecoveryServicesProtection -DatasourceType AzureVM -ResourceGroupName $rgName -VaultName $vaultName -VMName $vmName -PolicyId $pol.Id -InclusionDisksList "1","2"
            $item=Get-AzRecoveryServicesBackupProtectedItem -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Filter "backupManagementType eq 'AzureIaasVM' and WorkloadType -eq 'AzureVM'" | Where-Object { $_.Property.FriendlyName -match $vmName}
            $item.Property.ProtectionState | Should be "IRPending"
            $item.Property.PolicyId | Should be $pol.Id
            $item.Property.DiskExclusionPropertyDiskLunList | Should be "1","2"
            $item.Property.DiskExclusionPropertyIsInclusionList | Should be $true
        }
        
    }
}
