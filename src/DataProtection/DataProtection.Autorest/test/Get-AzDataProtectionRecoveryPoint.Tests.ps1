$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataProtectionRecoveryPoint.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Get-AzDataProtectionRecoveryPoint' -Tag 'LiveOnly' {
    It 'ListCRRRecoveryPoints' {
        $resourceGroupName  = $env.TestCrossRegionRestoreScenario.ResourceGroupName
        $vaultName = $env.TestCrossRegionRestoreScenario.VaultName
        $subscriptionId = $env.TestCrossRegionRestoreScenario.SubscriptionId

        $instance = Search-AzDataProtectionBackupInstanceInAzGraph -Subscription $subscriptionId  -ResourceGroup $resourceGroupName  -Vault $vaultName -DatasourceType AzureDatabaseForPostgreSQL

        ($instance[0] -ne $null) | Should be $true

        $recoveryPointsCRR = Get-AzDataProtectionRecoveryPoint -BackupInstanceName $instance.Name -ResourceGroupName $resourceGroupName -VaultName $vaultName -SubscriptionId $subscriptionId -UseSecondaryRegion

        ($recoveryPointsCRR.Length -gt 0) | Should be $true
    }

    It 'Get' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
