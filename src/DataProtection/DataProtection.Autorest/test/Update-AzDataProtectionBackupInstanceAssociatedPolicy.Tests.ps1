$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDataProtectionBackupInstanceAssociatedPolicy.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Update-AzDataProtectionBackupInstanceAssociatedPolicy' {
    It '__AllParameterSets' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
    
    It 'UpdateMSI' {
        $subscriptionId = $env.TestUpdateBIWithUAMI.SubscriptionId
        $resourceGroupName = $env.TestUpdateBIWithUAMI.ResourceGroupName
        $vaultName = $env.TestUpdateBIWithUAMI.VaultName
        $userAssignedIdentityARMId = $env.TestUpdateBIWithUAMI.UserIdentityARMId
        $backupInstanceName = $env.TestUpdateBIWithUAMI.BackupInstanceName
   
        $instance = Get-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId | Where-Object { $_.Name -match $backupInstanceName }

        $updateBI = Update-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name -SubscriptionId $subscriptionId -UseSystemAssignedIdentity $false -UserAssignedIdentityArmId $userAssignedIdentityARMId

        Start-Sleep -Seconds 40

        $instance = Get-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId | Where-Object { $_.Name -match $backupInstanceName }

        $instance.Property.IdentityDetail.UseSystemAssignedIdentity | Should be $false
        $instance.Property.IdentityDetail.UserAssignedIdentityArmUrl -eq $userAssignedIdentityARMId | Should be $true

        $updateBI = Update-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -BackupInstanceName $instance.Name -SubscriptionId $subscriptionId -UseSystemAssignedIdentity $true

        Start-Sleep -Seconds 10

        $instance = Get-AzDataProtectionBackupInstance -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId | Where-Object { $_.Name -match $backupInstanceName }

        $instance.Property.IdentityDetail.UseSystemAssignedIdentity -eq $true | Should be $true    
    }
}
