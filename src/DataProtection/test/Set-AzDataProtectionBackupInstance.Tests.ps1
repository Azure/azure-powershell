$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDataProtectionBackupInstance.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Set-AzDataProtectionBackupInstance' {
    It 'PutExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'Put' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'dppplatform' {
        write-host $env
        $vault = Get-AzDataProtectionBackupVault -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.VaultResourceGroupName -VaultName $env.VaultName
        $policy = Get-AzDataProtectionBackupPolicy -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.VaultResourceGroupName -VaultName $env.VaultName -Name $env.ConfigureBackupSettings.AzureDisk.PolicyName
        $instanceRequest = Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation $env.ConfigureBackupSettings.AzureDisk.DatasourceLocation -PolicyId $policy.Id -DatasourceId $env.ConfigureBackupSettings.AzureDisk.DatasourceId
        $instanceRequest.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = $env.ConfigureBackupSettings.AzureDisk.otdsrg
        write-host $instanceRequest
        Set-AzDataProtectionBackupInstance -VaultId $vault.ID -BackupInstance $instanceRequest
        $instance = Get-AzDataProtectionBackupInstance -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.VaultResourceGroupName -VaultName $env.VaultName | Where-Object {$_.Property.FriendlyName -eq $env.ConfigureBackupSettings.AzureDisk.ResourceName}
        if($instance -ne $null)
        {
            Remove-AzDataProtectionBackupInstance -SubscriptionId $env.SubscriptionId -ResourceGroupName $env.VaultResourceGroupName -VaultName $env.VaultName -Name $instance[0].Name
        }
    }
}
