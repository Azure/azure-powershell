function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}
$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.RecordDate = (Get-Date -Year 2022 -Month 06 -Day 09 -Hour 21 -Minute 01 -Second 11).ToString('dd-MM-yyyy-h-m-s')
    # For any resources you created for test, you should add it to $env here.
        
    $BackupInstanceTestVariables = @{
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "sarath-rg"
        VaultName = "sarath-vault"
    }

    $BackupPolicyTestVariables = @{
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "sarath-rg"
        VaultName = "sarath-vault"
        DiskNewPolicyName = "sarath-disk-generated-policy"
    }

    $randomstring = RandomString -allChars $false -len 10    
    $BackupVaultTestVariables = @{
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "sarath-rg"
        VaultName = "sarath-vault"
        NewVaultName = "new-pstest-vault"
    }

    $BackupJobTestVariables = @{
        ResourceGroupName = "sarath-rg"
        VaultName = "sarath-vault"
    }

    $newPolicyName = "newdiskpolicy-" + $randomstring
    $restoreDiskId ="/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/sarath-restore-disk-rg/providers/Microsoft.Compute/disks/sarathdisk2-restored" + $randomstring
    $DiskE2ETestVariables = @{
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "sarath-rg"
        VaultName = "sarath-vault"
        DiskId = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/sarath-rg/providers/Microsoft.Compute/disks/sarathdisk2"
        SnapshotRG = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/sarath-snapshot-rg"
        RestoreRG = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/sarath-restore-disk-rg"
        NewPolicyName = $newPolicyName
        RestoreDiskId = $restoreDiskId
    }

    $TriggerBackupTestVariables = @{
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "sarath-rg"
        VaultName = "sarath-vault"
        DiskId = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/sarath-rg/providers/Microsoft.Compute/disks/sarathdisk"
        BackupRuleName = "BackupHourly"
    }

    $BlobsRestoreVariables = @{
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "BlobBackup-BugBash"
        VaultName = "jecECYBlobVault"
    }
    
    $OssVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        ResourceGroupName = "oss-pstest-rg"
        VaultName = "oss-pstest-vault"
        OssServerName = "oss-pstest-server"
        OssDbName = "oss-pstest-db"
        OssDbId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/hiagarg/providers/Microsoft.DBforPostgreSQL/servers/oss-pstest-server/databases/postgres"
        PolicyName = "oss-pstest-policy"
        NewPolicyName = "oss-pstest-policy-archive"        
        KeyVault = "oss-pstest-keyvault"
        SecretURI = "https://oss-pstest-keyvault.vault.azure.net/secrets/oss-pstest-secret"
        TargetResourceId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/hiagarg/providers/Microsoft.DBforPostgreSQL/servers/oss-pstest-server/databases/oss-pstest-dbrestore"
        TargetContainerURI = "https://osspstestsa.blob.core.windows.net/oss-pstest-container"
        FileNamePrefix = "oss-pstest-restoreasfiles"
    }

    $ResourceGuardVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        ResourceGroupName = "hiagarg"
        ResourceGuardName = "pstest-resourceguard"
        Location = "centraluseuap"
    }

    $env.add("TestBackupInstance", $BackupInstanceTestVariables) | Out-Null
    $env.add("TestBackupPolicy", $BackupPolicyTestVariables) | Out-Null
    $env.add("TestBackupVault", $BackupVaultTestVariables) | Out-Null
    $env.add("TestBackupJob", $BackupJobTestVariables) | Out-Null
    $env.add("TestDiskBackupScenario", $DiskE2ETestVariables) | Out-Null
    $env.add("TestTriggerBackup", $TriggerBackupTestVariables) | Out-Null
    $env.add("TestBlobsRestore", $BlobsRestoreVariables) | Out-Null
    $env.add("TestOssBackupScenario", $OssVariables) | Out-Null
    $env.add("TestResourceGuard", $ResourceGuardVariables) | Out-Null

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

