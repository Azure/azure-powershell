function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % { [char]$_ })
    }
    else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % { [char]$_ })
    }
}
function Start-TestSleep {
    [CmdletBinding(DefaultParameterSetName = 'SleepBySeconds')]
    param(
        [parameter(Mandatory = $true, Position = 0, ParameterSetName = 'SleepBySeconds')]
        [ValidateRange(0.0, 2147483.0)]
        [double] $Seconds,

        [parameter(Mandatory = $true, ParameterSetName = 'SleepByMilliseconds')]
        [ValidateRange('NonNegative')]
        [Alias('ms')]
        [int] $Milliseconds
    )

    if ($TestMode -ne 'playback') {
        switch ($PSCmdlet.ParameterSetName) {
            'SleepBySeconds' {
                Start-Sleep -Seconds $Seconds
            }
            'SleepByMilliseconds' {
                Start-Sleep -Milliseconds $Milliseconds
            }
        }
    }
}

$env = @{}
function setupEnv() {
    # Preload subscriptionId and tenant from context, which will be used in test
    # as default. You could change them if needed.
    $env.SubscriptionId = (Get-AzContext).Subscription.Id
    $env.Tenant = (Get-AzContext).Tenant.Id
    $env.RecordDate = (Get-Date -Year 2025 -Month 10 -Day 25 -Hour 17 -Minute 31 -Second 02).ToString('dd-MM-yyyy-h-m-s')
    # For any resources you created for test, you should add it to $env here.

    $BackupInstanceTestVariables = @{
        SubscriptionId    = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName = "jkjk-rg"
        VaultName         = "jktest-vault"
    }

    $BackupPolicyTestVariables = @{
        SubscriptionId    = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName = "jkjk-rg"
        VaultName         = "jktest-vault"
        DiskNewPolicyName = "pjk-disk-generated-policy"
    }

    $randomstring = RandomString -allChars $false -len 10
    $BackupVaultTestVariables = @{
        SubscriptionId       = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        CreateSubscriptionId = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName    = "jkjk-rg"
        VaultName            = "jktest-vault"
        NewVaultName         = "new-jktest-vault"
        NewCSRVault          = "csr-jktest-vault"
    }

    $BackupJobTestVariables = @{
        ResourceGroupName = "jkjk-rg"
        VaultName         = "jktest-vault"
    }

    $newPolicyName = "newdiskpolicy-" + $env.RecordDate
    $restoreDiskId = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/jkjk-rg/providers/Microsoft.Compute/disks/jktest-restoreddisk-" + $env.RecordDate
    $DiskE2ETestVariables = @{
        SubscriptionId    = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName = "jkjk-rg"
        VaultName         = "jktest-vault"
        DiskId            = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourcegroups/jkjk-rg/providers/Microsoft.Compute/disks/jktest-disk-2"
        SnapshotRG        = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/jkjk-rg"
        RestoreRG         = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/jkjk-rg"
        NewPolicyName     = $newPolicyName
        RestoreDiskId     = $restoreDiskId
    }

    $TriggerBackupTestVariables = @{
        SubscriptionId    = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName = "jkjk-rg"
        VaultName         = "jktest-vault"
        DiskId            = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/jkjk-rg/providers/Microsoft.Compute/disks/jktest-disk-2"
        BackupRuleName    = "BackupDaily"
    }

    $SoftDeleteVariables = @{
        SubscriptionId    = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName = "jkjk-rg"
        VaultName         = "jktest-disk-vault2"
        DiskId            = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/jkjk-rg/providers/Microsoft.Compute/disks/jktest-disk-2"
        BackupRuleName    = "BackupDaily"
    }

    $BlobsRestoreVariables = @{
        SubscriptionId    = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName = "jkjk-rg"
        VaultName         = "jktest-vault"
    }

    $OssVariables = @{
        SubscriptionId     = "38304e13-357e-405e-9e9a-220351dcce8c"
        ResourceGroupName  = "oss-pstest-rg"
        VaultName          = "oss-pstest-vault"
        OssServerName      = "oss-pstest-server"
        OssDbName          = "oss-pstest-db"
        OssDbId            = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/hiagarg/providers/Microsoft.DBforPostgreSQL/flexibleServers/hiagaoss1"
        PolicyName         = "oss-pstest-policy"
        NewPolicyName      = "oss-pstest-policy-archive"
        KeyVault           = "oss-pstest-keyvault"
        SecretURI          = "https://oss-pstest-keyvault.vault.azure.net/secrets/oss-pstest-secret"
        TargetResourceId   = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/hiagarg/providers/Microsoft.DBforPostgreSQL/servers/oss-pstest-server/databases/oss-pstest-dbrestore"
        TargetContainerURI = "https://osspstestsa.blob.core.windows.net/oss-pstest-container"
        FileNamePrefix     = "oss-pstest-restoreasfiles"
    }

    $ResourceGuardVariables = @{
        SubscriptionId    = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName = "jkjk-rg"
        ResourceGuardName = "jktest-resourceguard"
        Location          = "centraluseuap"
    }

    $GrantPermissionVariables = @{
        VaultName      = "TestBkpVault"
        VaultRG        = "testBkpVaultRG"
        SubscriptionId = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"

        DiskId         = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/Diskrg/providers/Microsoft.Compute/disks/Mydisk2"
        Diskrg         = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/Diskrg"
        Snapshotrg     = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/testBkpVaultRG"
        DiskPolicyName = "diskBkpPolicy"

        BlobId         = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/Blobrg/providers/Microsoft.Storage/storageAccounts/testblobacc4"
        Blobrg         = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/Blobrg"
        BlobPolicyName = "blobBkpPolicy"

        OssPolicyName  = "TestOSSPolicy2"
        OssId          = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourcegroups/Ossrg/providers/Microsoft.DBforPostgreSQL/servers/rishitserver3/databases/postgres"
        Ossrg          = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourcegroups/Ossrg"
        KeyURI         = "https://rishitkeyvault3.vault.azure.net/secrets/rishitnewsecret"
        KeyVaultId     = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourcegroups/Sqlrg/providers/Microsoft.KeyVault/vaults/rishitkeyvault3"
    }

    $AksPolicyVariables = @{
        SubscriptionId       = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName    = "jkjk-rg"
        VaultName            = "jktest-vault"
        NewPolicyName        = "jktest-aks-policy"
        NewVaultedPolicyName = "vaulted-aks-pspol"
    }

    $AksVariables = @{
        SubscriptionId          = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName       = "aksbackuptestrg-rajat"
        VaultName               = "demobackupvault"
        NewPolicyName           = "pstest-aks-policy"
        PolicyName              = "demoaksbackuppolicy"
        DataSourceLocation      = "eastus"
        SourceClusterId         = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/aksbackuptestrg-rajat/providers/Microsoft.ContainerService/managedClusters/aks-pstest-cluster"
        TargetClusterId         = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/aksbackuptestrg-rajat/providers/Microsoft.ContainerService/managedClusters/aks-clitest-cluster"
        SnapshotResourceGroupId = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/aksbackuptestrg-rajat"
        FriendlyName            = "pstest-aks-cluster"
    }

    $AksRestoreVariables = @{
        SubscriptionId          = "e77b08cc-d20a-411b-aa8e-6b453f1f7971" #"e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName       = "jkjk-rg" #"aksbackuptestrg-rajat"
        VaultName               = "jktest-vault" #"demobackupvault"
        NewPolicyName           = "" #"pstest-aks-policy"
        PolicyName              = "MyPolicy"
        DataSourceLocation      = "eastus2euap"
        SourceClusterId         = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourcegroups/jkjk-rg/providers/Microsoft.ContainerService/managedClusters/azk8ssvcs-cluster-ecy"
        SnapshotResourceGroupId = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/MC_azk8ssvcs-cluster-r-ecy_azk8ssvcs-cluster-ecy_eastus2euap"
        FriendlyName            = "aksCluster3-ecy-araj-BI"
        ClusterName             = "azk8ssvcs-bi-backupecy"
    }

    $BlobHardeningVariables = @{
        SubscriptionId                     = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        CrossSubscriptionId                = "349ea464-dc60-42e9-8c5d-46fa013b9546"
        Location                           = "eastus"
        ResourceGroupName                  = "jkjk-rg"
        VaultName                          = "jktest-vault"
        PolicyName                         = "MyPolicy"
        UpdatePolicyName                   = "opvaultpolicy2"
        UpdatedContainersList              = @( "con1", "con2", "con3", "con4", "con5" )
        StorageAccountName                 = "blobsourcesa1"
        OperationalPolicyName              = "operationalpol2"
        VaultPolicyName                    = "vaultpolicy"
        OperationalVaultedPolicyName       = "opvaultpolicy3"
        StorageAccId                       = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/jkjk-rg/providers/Microsoft.Storage/storageAccounts/blobsourcesa1"
        TargetStorageAccId                 = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/jkjk-rg/providers/Microsoft.Storage/storageAccounts/blobtargetsa"
        TargetStorageAccountName           = "blobtargetsa"
        TargetStorageAccountRGName         = "dataprotectionpstest-rg"
        TargetCrossSubStorageAccId         = "/subscriptions/349ea464-dc60-42e9-8c5d-46fa013b9546/resourceGroups/dataprotectionpstest2-rg/providers/Microsoft.Storage/storageAccounts/crrblobtargetsa"
        TargetCrossSubStorageAccountName   = "crrblobtargetsa"
        TargetCrossSubStorageAccountRGName = "dataprotectionpstest2-rg"
    }

    $AdlsBlobHardeningVariables = @{
        SubscriptionId                     = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        CrossSubscriptionId                = "349ea464-dc60-42e9-8c5d-46fa013b9546"
        Location                           = "eastus"
        ResourceGroupName                  = "dataprotectionpstest-rg"
        VaultName                          = "dataprotectionpstest-bv"
        PolicyName                         = "adlsvaultpolicy"
        UpdatePolicyName                   = "adlsvaultpolicy2"
        UpdatedContainersList              = @( "con1", "con2", "con3", "con4", "con5" )
        StorageAccountName                 = "adlsblobsourcesa"
        VaultPolicyName                    = "adlsvaultpolicy"
        StorageAccId                       = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/dataprotectionpstest-rg/providers/Microsoft.Storage/storageAccounts/adlsblobsourcesa"
        TargetStorageAccId                 = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/dataprotectionpstest-rg/providers/Microsoft.Storage/storageAccounts/adlsblobtargetsa"
        TargetStorageAccountName           = "adlsblobtargetsa"
        TargetStorageAccountRGName         = "dataprotectionpstest-rg"
        TargetCrossSubStorageAccId         = "/subscriptions/349ea464-dc60-42e9-8c5d-46fa013b9546/resourceGroups/dataprotectionpstest2-rg/providers/Microsoft.Storage/storageAccounts/crradlsblobtargetsa"
        TargetCrossSubStorageAccountName   = "crradlsblobtargetsa"
        TargetCrossSubStorageAccountRGName = "dataprotectionpstest2-rg"
    }

    $UpdateBIWithUAMIVariables = @{
        SubscriptionId     = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName  = "hiagarg"
        VaultName          = "psbackupvault"
        UserIdentityARMId  = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/hiagarg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/hiagaDiskUami2"
        BackupInstanceName = "psDiskBI"
    }

    $BackupConfigVariables = @{
        SubscriptionId              = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        StorageAccountResourceGroup = "blob-pstest-rg"
        StorageAccountName          = "blobpstestsa"
    }

    $CrossSubscriptionRestoreVariables = @{
        ResourceGroupName    = "CSRTestRg"
        VaultName            = "CSRPortalTestVault"
        SubscriptionId       = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        TargetContainerArmId = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/hiagarg/providers/Microsoft.Storage/storageAccounts/akneemasaecy/blobServices/default/containers/oss-csr-container"
        TargetContainerURI   = "https://akneemasaecy.blob.core.windows.net/oss-csr-container"
        FileNamePrefix       = "oss-csr-pstest-restoreasfiles"
    }

    $CrossRegionRestoreVariables = @{
        ResourceGroupName  = "adigupt-rg"
        VaultName          = "crr-wala-ecy-vault"
        SubscriptionId     = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        TargetResourceId   = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/DppCrrRG/providers/Microsoft.DBforPostgreSQL/servers/crr-ccy-1/databases/oss-pstestrun-crr-1"
        SecretURI          = "https://crr-ccy-kv.vault.azure.net/secrets/secret-for-crr-ccy-1"
        TargetContainerURI = "https://zftccypod01otds1.blob.core.windows.net/oss-crr-pstest"
        FileNamePrefix     = "oss-pstest-crrasfiles-1"
    }

    $MUAVariables = @{
        SubscriptionId            = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName         = "hiagarg"
        VaultName                 = "mua-pstest-backupvault" # "mua-pstest-vault-eacan"
        Location                  = "centraluseuap" #"eastasia"
        ResourceGuardName         = "mua-pstest-dpp-ccy-resguard"
        ResourceGuardRGName       = "hiaga-rg"
        ResourceGuardSubscription = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        BackupInstanceName        = "alrpstestvm-datadisk-000-20220808-115835" # "eacan-pstest-disk"
        ResourceGuardId           = "/subscriptions/e77b08cc-d20a-411b-aa8e-6b453f1f7971/resourceGroups/hiaga-rg/providers/Microsoft.DataProtection/ResourceGuards/mua-pstest-dpp-ccy-resguard"
    }

    $PGFlexRestoreVariables = @{
        SubscriptionId     = "e77b08cc-d20a-411b-aa8e-6b453f1f7971" # "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName  = "jkjk-rg" #"vdhingraRG"
        VaultName          = "jktest-vault" #"vdhingraBackupVault"
        NewPolicyName      = "pstest-pgflex-policy"
        PolicyName         = "OssFlexiblePolicy1" # "pgflexArchivePolicy1"
        TargetContainerURI = "https://akneemasaecy.blob.core.windows.net/oss-csr-container" # "https://vdhingra1psa.blob.core.windows.net/powershellpgflexrestore"
        BackupInstanceName = "zubair-pgflex-cli1" # "archive-test"
    }

    $MySQLRetoreVariables = @{
        SubscriptionId     = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName  = "MySQLTest" # "vdhingraRG"
        VaultName          = "MYSQLBugBashCCY" #"vdhingraBackupVault"
        NewPolicyName      = "pstest-mysql-policy"
        PolicyName         = "LowRetention" #"pstest-simple-mysql"
        TargetContainerURI = "https://adityaccy.blob.core.windows.net/ads" # "https://vdhingra1psa.blob.core.windows.net/powershellpgflexrestore"
        BackupInstanceName = "bugbash-02" # "arhive-test"
    }

    $PGFlexVariables = @{
        SubscriptionId     = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName  = "jkjk-rg"
        VaultName          = "jktest-vault"
        NewPolicyName      = "jktest-policy-2"
        PolicyName         = "jktest-policy-1"
        TargetContainerURI = "https://vdhingra1psa.blob.core.windows.net/powershellpgflexrestore"
    }

    $MySQLVariables = @{
        SubscriptionId     = "e77b08cc-d20a-411b-aa8e-6b453f1f7971"
        ResourceGroupName  = "jkjk-rg"
        VaultName          = "jktest-vault"
        NewPolicyName      = "pstest-mysql-policy"
        PolicyName         = "MyPolicy"
        TargetContainerURI = "https://vdhingra1psa.blob.core.windows.net/powershellpgflexrestore"
    }

    $CmkEncryptionVariables = @{
        SubscriptionId             = "38304e13-357e-405e-9e9a-220351dcce8c"
        ResourceGroupName          = "dataprotectionpstest-rg"
        VaultName                  = "testcmkvault7"
        Location                   = "eastasia"
        CmkUserAssignedIdentityId  = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourcegroups/dataprotectionpstest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/userMSIpstest"
        CmkEncryptionKeyUri        = "https://iannakeyvault.vault.azure.net/keys/pskey/acabb3f41e4e4266abf44100b81e7872"
        CmkEncryptionKeyUriUpdated = "https://iannakeyvault.vault.azure.net/keys/pskey2/759c6ee414554dd7a6225bc22a90871d"
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
    $env.add("TestAksPolicyScenario", $AksPolicyVariables) | Out-Null
    $env.add("TestAksRestoreScenario", $AksRestoreVariables) | Out-Null
    $env.add("TestBlobHardeningScenario", $BlobHardeningVariables) | Out-Null
    $env.add("TestAdlsBlobHardeningScenario", $AdlsBlobHardeningVariables) | Out-Null
    $env.add("TestCrossSubscriptionRestoreScenario", $CrossSubscriptionRestoreVariables) | Out-Null
    $env.add("TestCrossRegionRestoreScenario", $CrossRegionRestoreVariables) | Out-Null
    $env.add("TestSoftDelete", $SoftDeleteVariables) | Out-Null
    $env.add("TestBackupConfig", $BackupConfigVariables) | Out-Null
    $env.add("TestMUA", $MUAVariables) | Out-Null
    $env.add("TestPGFlex", $PGFlexVariables) | Out-Null
    $env.add("TestMySQL", $MySQLVariables) | Out-Null
    $env.add("TestPGFlexRestore", $PGFlexRestoreVariables) | Out-Null
    $env.add("TestMySQLRestore", $MySQLRestoreVariables) | Out-Null
    $env.add("TestCmkEncryption", $CmkEncryptionVariables) | Out-Null
    $env.add("TestUpdateBIWithUAMI", $UpdateBIWithUAMIVariables) | Out-Null

    $envFile = 'env.json'
    if ($TestMode -eq 'live') {
        $envFile = 'localEnv.json'
    }

    set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
}
function cleanupEnv() {
    # Clean resources you create for testing
}

