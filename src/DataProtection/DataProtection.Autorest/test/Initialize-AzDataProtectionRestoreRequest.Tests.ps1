$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Initialize-AzDataProtectionRestoreRequest.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Initialize-AzDataProtectionRestoreRequest' {
    It '__AllParameterSets' {
        $sub = $env.TestBlobsRestore.SubscriptionId
        $rgName = $env.TestBlobsRestore.ResourceGroupName
        $vaultName = $env.TestBlobsRestore.VaultName

        # $Debug preference = "Continue"
        Write-Debug  -Message $sub
        Write-Debug  -Message $rgName
        Write-Debug  -Message $vaultName

        $instances  = Get-AzDataProtectionBackupInstance -Subscription $sub -ResourceGroup $rgName -Vault $vaultName | Where-Object {($_.Property.DataSourceInfo.Type -eq "Microsoft.Storage/storageAccounts/blobServices") -and ($_.Property.CurrentProtectionState -eq "ProtectionConfigured")}

        if($instances.Count -gt 0){

            $pointInTimeRange = Find-AzDataProtectionRestorableTimeRange -BackupInstanceName $instances[0].BackupInstanceName -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName -SourceDataStoreType OperationalStore -StartTime (Get-Date).AddDays(-30).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z") -EndTime (Get-Date).AddDays(0).ToString("yyyy-MM-ddTHH:mm:ss.0000000Z")
            $vault = Get-AzDataProtectionBackupVault -ResourceGroupName $rgName -SubscriptionId $sub -VaultName $vaultName
            $BlobResReq = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation $vault.Location -RestoreType OriginalLocation -BackupInstance $instances[0] -PointInTime (Get-Date -Date $pointInTimeRange.RestorableTimeRange.EndTime)

            $restoreJob = Start-AzDataProtectionBackupInstanceRestore -BackupInstanceName $instances[0].BackupInstanceName -ResourceGroupName $rgName -VaultName $vaultName -SubscriptionId $sub -Parameter $BlobResReq
            $jobid = $restoreJob.JobId.Split("/")[-1]
            $jobstatus = "InProgress"
            while($jobstatus -eq "InProgress")
            {
                Start-TestSleep -Seconds 10
                $currentjob = Get-AzDataProtectionJob -Id $jobid -SubscriptionId $sub -ResourceGroupName $rgName -VaultName $vaultName
                $jobstatus = $currentjob.Status
            }
            $jobstatus | Should be "Completed"
        }
    }
}

Describe 'Initialize-AzDataProtectionRestoreRequest -RenameTo rejection on unsupported workloads' {
    It 'AzureKubernetesService -RenameTo throws "does not support renaming containers"' {
        $renameMap = @{ "original-container" = "renamed-container" }
        { Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureKubernetesService -SourceDataStore VaultStore -RestoreLocation "westus" -RecoveryPoint "fake-rp" -ItemLevelRecovery -RestoreType AlternateLocation -TargetResourceId "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ContainerService/managedClusters/cluster" -RenameTo $renameMap -RestoreConfiguration ([PSCustomObject]@{}) -ErrorAction Stop } | Should -Throw "does not support renaming containers"
    }
}

