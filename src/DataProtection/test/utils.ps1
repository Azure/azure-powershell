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
    $env.RecordDate = (Get-Date -Year 2023 -Month 03 -Day 20 -Hour 11 -Minute 25 -Second 11).ToString('dd-MM-yyyy-h-m-s')
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

    $GrantPermissionVariables = @{
        VaultName = "TestBkpVault"
        VaultRG = "testBkpVaultRG"
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
       
        DiskId = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/Diskrg/providers/Microsoft.Compute/disks/Mydisk2" 
        Diskrg = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/Diskrg"
        Snapshotrg = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/testBkpVaultRG"
        DiskPolicyName = "diskBkpPolicy"

        BlobId = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/Blobrg/providers/Microsoft.Storage/storageAccounts/testblobacc4"
        Blobrg = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/Blobrg"
        BlobPolicyName = "blobBkpPolicy"

        OssPolicyName =  "TestOSSPolicy2"
        OssId = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourcegroups/Ossrg/providers/Microsoft.DBforPostgreSQL/servers/rishitserver3/databases/postgres"
        Ossrg = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourcegroups/Ossrg"
        KeyURI = "https://rishitkeyvault3.vault.azure.net/secrets/rishitnewsecret"
        KeyVaultId = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourcegroups/Sqlrg/providers/Microsoft.KeyVault/vaults/rishitkeyvault3" 
    }

    $AksVariables = @{
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "aksbackuptestrg-rajat"
        VaultName = "demobackupvault"
        NewPolicyName = "pstest-aks-policy"
        PolicyName = "demoaksbackuppolicy"
        DataSourceLocation = "eastus"
        SourceClusterId = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/aksbackuptestrg-rajat/providers/Microsoft.ContainerService/managedClusters/aks-pstest-cluster"
        TargetClusterId = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/aksbackuptestrg-rajat/providers/Microsoft.ContainerService/managedClusters/aks-clitest-cluster"
        SnapshotResourceGroupId = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/aksbackuptestrg-rajat"
        FriendlyName = "pstest-aks-cluster"        
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
    $env.add("TestGrantPermission", $GrantPermissionVariables) | Out-Null
    $env.add("TestAksBackupScenario", $AksVariables) | Out-Null

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

