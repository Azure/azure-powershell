function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
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
        CreateSubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        ResourceGroupName = "sarath-rg"
        VaultName = "sarath-vault"
        NewVaultName = "new-pstest-vault"
        NewCSRVault = "csr-pstest-vault"
    }

    $BackupJobTestVariables = @{
        ResourceGroupName = "sarath-rg"
        VaultName = "sarath-vault"
    }

    $newPolicyName = "newdiskpolicy-" + $env.RecordDate
    $restoreDiskId ="/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/pstest-diskrg/providers/Microsoft.Compute/disks/pstest-restoreddisk-" + $env.RecordDate
    $DiskE2ETestVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        ResourceGroupName = "pstest-diskrg"
        VaultName = "pstest-disk-vault"
        DiskId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourcegroups/pstest-diskrg/providers/Microsoft.Compute/disks/pstest-disk"
        SnapshotRG = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/pstest-diskrg"
        RestoreRG = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/pstest-diskrg"
        NewPolicyName = $newPolicyName
        RestoreDiskId = $restoreDiskId
    }

    $TriggerBackupTestVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        ResourceGroupName = "pstest-diskrg"
        VaultName = "pstest-disk-vault"
        DiskId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/pstest-diskrg/providers/Microsoft.Compute/disks/pstest-disk"
        BackupRuleName = "BackupHourly"
    }

    $SoftDeleteVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        ResourceGroupName = "pstest-diskrg"
        VaultName = "pstest-disk-vault2"
        DiskId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/pstest-diskrg/providers/Microsoft.Compute/disks/pstest-disk2"
        BackupRuleName = "BackupDaily"
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
        OssDbId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/hiagarg/providers/Microsoft.DBforPostgreSQL/flexibleServers/hiagaoss1"
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

    $AksPolicyVariables = @{
        SubscriptionId = "f0c630e0-2995-4853-b056-0b3c09cb673f"
        ResourceGroupName = "AKS-ps-shasha-test-source"
        VaultName = "ps-vault"
        NewPolicyName = "pstest-aks-policy"
        NewVaultedPolicyName = "vaulted-aks-pspol"
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

    $AksRestoreVariables = @{
        SubscriptionId = "f0c630e0-2995-4853-b056-0b3c09cb673f" #"62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "azk8ssvcs-cluster-r-ecy" #"aksbackuptestrg-rajat"
        VaultName = "azk8ssvcs-vault-ecy" #"demobackupvault"
        NewPolicyName = "" #"pstest-aks-policy"
        PolicyName = "azk8ssvcs-ad-policy-backupecy"
        DataSourceLocation = "eastus2euap"
        SourceClusterId = "/subscriptions/f0c630e0-2995-4853-b056-0b3c09cb673f/resourcegroups/azk8ssvcs-cluster-r-ecy/providers/Microsoft.ContainerService/managedClusters/azk8ssvcs-cluster-ecy"
        SnapshotResourceGroupId = "/subscriptions/f0c630e0-2995-4853-b056-0b3c09cb673f/resourceGroups/MC_azk8ssvcs-cluster-r-ecy_azk8ssvcs-cluster-ecy_eastus2euap"
        FriendlyName = "aksCluster3-ecy-araj-BI"
        ClusterName = "azk8ssvcs-bi-backupecy"
    }

    $BlobHardeningVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        CrossSubscriptionId = "349ea464-dc60-42e9-8c5d-46fa013b9546"
        Location = "eastus"
        ResourceGroupName = "dataprotectionpstest-rg"
        VaultName = "dataprotectionpstest-bv"
        PolicyName = "opvaultpolicy"
        UpdatePolicyName = "opvaultpolicy2"
        UpdatedContainersList = @( "con1", "con2", "con3", "con4", "con5" )
        StorageAccountName = "blobsourcesa1"
        OperationalPolicyName = "operationalpol2"
        VaultPolicyName = "vaultpolicy"
        OperationalVaultedPolicyName = "opvaultpolicy3"
        StorageAccId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/dataprotectionpstest-rg/providers/Microsoft.Storage/storageAccounts/blobsourcesa1"
        TargetStorageAccId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/dataprotectionpstest-rg/providers/Microsoft.Storage/storageAccounts/blobtargetsa"
        TargetStorageAccountName = "blobtargetsa"
        TargetStorageAccountRGName = "dataprotectionpstest-rg"
        TargetCrossSubStorageAccId = "/subscriptions/349ea464-dc60-42e9-8c5d-46fa013b9546/resourceGroups/dataprotectionpstest2-rg/providers/Microsoft.Storage/storageAccounts/crrblobtargetsa"
        TargetCrossSubStorageAccountName = "crrblobtargetsa"
        TargetCrossSubStorageAccountRGName = "dataprotectionpstest2-rg"
    }

    $AdlsBlobHardeningVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        CrossSubscriptionId = "349ea464-dc60-42e9-8c5d-46fa013b9546"
        Location = "eastus"
        ResourceGroupName = "dataprotectionpstest-rg"
        VaultName = "dataprotectionpstest-bv"
        PolicyName = "adlsvaultpolicy"
        UpdatePolicyName = "adlsvaultpolicy2"
        UpdatedContainersList = @( "con1", "con2", "con3", "con4", "con5" )
        StorageAccountName = "adlsblobsourcesa"
        VaultPolicyName = "adlsvaultpolicy"
        StorageAccId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/dataprotectionpstest-rg/providers/Microsoft.Storage/storageAccounts/adlsblobsourcesa"
        TargetStorageAccId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/dataprotectionpstest-rg/providers/Microsoft.Storage/storageAccounts/adlsblobtargetsa"
        TargetStorageAccountName = "adlsblobtargetsa"
        TargetStorageAccountRGName = "dataprotectionpstest-rg"
        TargetCrossSubStorageAccId = "/subscriptions/349ea464-dc60-42e9-8c5d-46fa013b9546/resourceGroups/dataprotectionpstest2-rg/providers/Microsoft.Storage/storageAccounts/crradlsblobtargetsa"
        TargetCrossSubStorageAccountName = "crradlsblobtargetsa"
        TargetCrossSubStorageAccountRGName = "dataprotectionpstest2-rg"
    }

    $UpdateBIWithUAMIVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        ResourceGroupName = "hiagarg"
        VaultName = "psbackupvault"
        UserIdentityARMId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/hiagarg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/hiagaDiskUami2"
        BackupInstanceName = "psDiskBI"
    }

    $BackupConfigVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        StorageAccountResourceGroup = "blob-pstest-rg"
        StorageAccountName = "blobpstestsa"
    }

    $CrossSubscriptionRestoreVariables = @{
        ResourceGroupName = "CSRTestRg"
        VaultName = "CSRPortalTestVault"
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        TargetContainerArmId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourceGroups/hiagarg/providers/Microsoft.Storage/storageAccounts/akneemasaecy/blobServices/default/containers/oss-csr-container"
        TargetContainerURI =  "https://akneemasaecy.blob.core.windows.net/oss-csr-container"
        FileNamePrefix = "oss-csr-pstest-restoreasfiles"
    }

    $CrossRegionRestoreVariables = @{
        ResourceGroupName =  "adigupt-rg"
        VaultName = "crr-wala-ecy-vault"
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        TargetResourceId = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/DppCrrRG/providers/Microsoft.DBforPostgreSQL/servers/crr-ccy-1/databases/oss-pstestrun-crr-1"
        SecretURI = "https://crr-ccy-kv.vault.azure.net/secrets/secret-for-crr-ccy-1"
        TargetContainerURI = "https://zftccypod01otds1.blob.core.windows.net/oss-crr-pstest"
        FileNamePrefix = "oss-pstest-crrasfiles-1"
    }

    $MUAVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        ResourceGroupName = "hiagarg"
        VaultName = "mua-pstest-backupvault" # "mua-pstest-vault-eacan"
        Location = "centraluseuap" #"eastasia"
        ResourceGuardName = "mua-pstest-dpp-ccy-resguard"
        ResourceGuardRGName = "hiaga-rg"
        ResourceGuardSubscription = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        BackupInstanceName = "alrpstestvm-datadisk-000-20220808-115835" # "eacan-pstest-disk"
        ResourceGuardId = "/subscriptions/62b829ee-7936-40c9-a1c9-47a93f9f3965/resourceGroups/hiaga-rg/providers/Microsoft.DataProtection/ResourceGuards/mua-pstest-dpp-ccy-resguard"
    }

    $PGFlexRestoreVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c" # "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "zubairRG" #"vdhingraRG"
        VaultName = "zpgflex" #"vdhingraBackupVault"
        NewPolicyName = "pstest-pgflex-policy"
        PolicyName = "OssFlexiblePolicy1" # "pgflexArchivePolicy1"
        TargetContainerURI = "https://akneemasaecy.blob.core.windows.net/oss-csr-container" # "https://vdhingra1psa.blob.core.windows.net/powershellpgflexrestore"
        BackupInstanceName = "zubair-pgflex-cli1" # "archive-test"
    }

    $MySQLRetoreVariables = @{
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "MySQLTest" # "vdhingraRG"
        VaultName = "MYSQLBugBashCCY" #"vdhingraBackupVault"
        NewPolicyName = "pstest-mysql-policy"
        PolicyName = "LowRetention" #"pstest-simple-mysql"
        TargetContainerURI = "https://adityaccy.blob.core.windows.net/ads" # "https://vdhingra1psa.blob.core.windows.net/powershellpgflexrestore"
        BackupInstanceName = "bugbash-02" # "arhive-test"
    }

    $PGFlexVariables = @{
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "vdhingraRG"
        VaultName = "vdhingraBackupVault"
        NewPolicyName = "pstest-pgflex-policy"
        PolicyName = "pgflexArchivePolicy1"
        TargetContainerURI = "https://vdhingra1psa.blob.core.windows.net/powershellpgflexrestore"
    }

    $MySQLVariables = @{
        SubscriptionId = "62b829ee-7936-40c9-a1c9-47a93f9f3965"
        ResourceGroupName = "vdhingraRG"
        VaultName = "vdhingraBackupVault"
        NewPolicyName = "pstest-mysql-policy"
        PolicyName = "pstest-simple-mysql"
        TargetContainerURI = "https://vdhingra1psa.blob.core.windows.net/powershellpgflexrestore"
    }

    $CmkEncryptionVariables = @{
        SubscriptionId = "38304e13-357e-405e-9e9a-220351dcce8c"
        ResourceGroupName = "dataprotectionpstest-rg"
        VaultName = "testcmkvault7"
        Location = "eastasia"
        CmkUserAssignedIdentityId = "/subscriptions/38304e13-357e-405e-9e9a-220351dcce8c/resourcegroups/dataprotectionpstest-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/userMSIpstest"
        CmkEncryptionKeyUri = "https://iannakeyvault.vault.azure.net/keys/pskey/acabb3f41e4e4266abf44100b81e7872"
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

