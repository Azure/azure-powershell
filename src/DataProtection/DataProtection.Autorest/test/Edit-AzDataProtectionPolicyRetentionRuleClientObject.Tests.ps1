$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)
$TestRecordingFile = Join-Path $PSScriptRoot 'Edit-AzDataProtectionPolicyRetentionRuleClientObject.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'Edit-AzDataProtectionPolicyRetentionRuleClientObject' {
    Context 'AzureBlob Default_OperationalStore enforcement' {
        It 'AddRetention AzureBlob -Name Default_OperationalStore Op lifecycle succeeds' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
            $opLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default_OperationalStore -LifeCycles $opLc -IsDefault $true

            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default_OperationalStore" }).Lifecycle[0].SourceDataStoreType | Should be "OperationalStore"
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default" }).Lifecycle[0].SourceDataStoreType | Should be "VaultStore"
        }

        It 'AddRetention AzureBlob -Name Default with Op lifecycle throws cross-store error' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
            $opLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
            { Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default -LifeCycles $opLc -IsDefault $true -OverwriteLifeCycle $true } | Should -Throw "reserved for source store"
            { Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default -LifeCycles $opLc -IsDefault $true -OverwriteLifeCycle $false } | Should -Throw "reserved for source store"
        }

        It 'AddRetention AzureBlob -Name Default_OperationalStore with Vault lifecycle throws cross-store error' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
            $vaultLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
            { Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default_OperationalStore -LifeCycles $vaultLc -IsDefault $true } | Should -Throw "reserved for source store"
        }

        It 'RemoveRetention AzureBlob -Name Default still hard-blocks (operational-only not supported via PS)' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
            { Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default -RemoveRule } | Should -Throw "Removing Default Retention Rule is not allowed"
        }

        It 'AddRetention AzureBlob -Name Default_OperationalStore -OverwriteLifeCycle $true updates existing Op rule (no duplicate)' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
            $opLc30 = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
            $opLc60 = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 60
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default_OperationalStore -LifeCycles $opLc30 -IsDefault $true
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default_OperationalStore -LifeCycles $opLc60 -IsDefault $true -OverwriteLifeCycle $true

            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default_OperationalStore" }).Count | Should be 1
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default_OperationalStore" }).Lifecycle[0].DeleteAfterDuration | Should be "P60D"
        }

        It 'RemoveRetention AzureBlob -Name Default_OperationalStore removes successfully' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
            $opLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default_OperationalStore -LifeCycles $opLc -IsDefault $true

            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default_OperationalStore" }) | Should -Not -BeNullOrEmpty

            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default_OperationalStore -RemoveRule

            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default_OperationalStore" }) | Should -BeNullOrEmpty
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default" }).Lifecycle[0].SourceDataStoreType | Should be "VaultStore"
        }

        It 'OverwriteLifeCycle $true on both Default and Default_OperationalStore updates each independently' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob

            # Add Default_OperationalStore with 30-day Op lifecycle
            $opLc30 = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default_OperationalStore -LifeCycles $opLc30 -IsDefault $true

            # Verify initial state
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default" }).Lifecycle[0].SourceDataStoreType | Should be "VaultStore"
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default_OperationalStore" }).Lifecycle[0].SourceDataStoreType | Should be "OperationalStore"
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default_OperationalStore" }).Lifecycle[0].DeleteAfterDuration | Should be "P30D"

            # Overwrite Default (VaultStore) with 90-day duration
            $vaultLc90 = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 90
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default -LifeCycles $vaultLc90 -IsDefault $true -OverwriteLifeCycle $true

            # Overwrite Default_OperationalStore with 60-day duration
            $opLc60 = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 60
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default_OperationalStore -LifeCycles $opLc60 -IsDefault $true -OverwriteLifeCycle $true

            # Verify both updated independently, no duplicates
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default" }).Count | Should be 1
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default" }).Lifecycle[0].DeleteAfterDuration | Should be "P90D"
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default" }).Lifecycle[0].SourceDataStoreType | Should be "VaultStore"

            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default_OperationalStore" }).Count | Should be 1
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default_OperationalStore" }).Lifecycle[0].DeleteAfterDuration | Should be "P60D"
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default_OperationalStore" }).Lifecycle[0].SourceDataStoreType | Should be "OperationalStore"
        }
    }

    Context 'AzureBlob OperationalStore exclusivity' {
        It 'AddRetention AzureBlob -Name Weekly with Op lifecycle throws exclusivity error' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
            $opLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
            { Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Weekly -LifeCycles $opLc -IsDefault $false } | Should -Throw "is exclusive"
        }

        It 'AddRetention AzureBlob -Name Monthly with Op lifecycle throws exclusivity error' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
            $opLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
            { Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Monthly -LifeCycles $opLc -IsDefault $false } | Should -Throw "is exclusive"
        }

        It 'AddRetention AzureBlob -Name Yearly with Op lifecycle throws exclusivity error' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
            $opLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
            { Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Yearly -LifeCycles $opLc -IsDefault $false } | Should -Throw "is exclusive"
        }

        It 'AddRetention AzureBlob -Name Weekly with mixed Vault+Op lifecycles throws exclusivity error' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
            $opLc    = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
            $vaultLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore       -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 12
            { Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Weekly -LifeCycles @($vaultLc,$opLc) -IsDefault $false } | Should -Throw "is exclusive"
        }

        It 'AddRetention AzureBlob -Name Weekly with Vault-only lifecycle still succeeds (vaulted LTR)' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob
            $vaultLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 12
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Weekly -LifeCycles $vaultLc -IsDefault $false
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Weekly" }).Lifecycle[0].SourceDataStoreType | Should be "VaultStore"
        }

        It 'AddRetention AzureBlob -Name Weekly/Monthly/Yearly Vault + Default_OperationalStore Op coexist on same policy' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureBlob

            # Add Default_OperationalStore with operational lifecycle
            $opLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 30
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default_OperationalStore -LifeCycles $opLc -IsDefault $true

            # Add Weekly with vault-only lifecycle
            $weeklyLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Weeks -SourceRetentionDurationCount 12
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Weekly -LifeCycles $weeklyLc -IsDefault $false

            # Add Monthly with vault-only lifecycle
            $monthlyLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Months -SourceRetentionDurationCount 6
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Monthly -LifeCycles $monthlyLc -IsDefault $false

            # Add Yearly with vault-only lifecycle
            $yearlyLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore VaultStore -SourceRetentionDurationType Years -SourceRetentionDurationCount 1
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Yearly -LifeCycles $yearlyLc -IsDefault $false

            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default_OperationalStore" }).Lifecycle[0].SourceDataStoreType | Should be "OperationalStore"
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Weekly" }).Lifecycle[0].SourceDataStoreType | Should be "VaultStore"
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Monthly" }).Lifecycle[0].SourceDataStoreType | Should be "VaultStore"
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Yearly" }).Lifecycle[0].SourceDataStoreType | Should be "VaultStore"
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default" }).Lifecycle[0].SourceDataStoreType | Should be "VaultStore"
        }
    }

    Context 'Cross-workload OverwriteLifeCycle=$false rejection on existing rule' {
        It 'AddRetention AzureKubernetesService -Name Default -OverwriteLifeCycle $false on existing rule throws "already exists"' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureKubernetesService
            $opLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 7
            { Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default -LifeCycles $opLc -IsDefault $true -OverwriteLifeCycle $false } | Should -Throw "already exists"
        }

        It 'AddRetention AzureDisk -Name Default -OverwriteLifeCycle $false on existing rule throws "already exists"' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureDisk
            $opLc = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 7
            { Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default -LifeCycles $opLc -IsDefault $true -OverwriteLifeCycle $false } | Should -Throw "already exists"
        }

        It 'AddRetention AzureKubernetesService -Name Default -OverwriteLifeCycle $true still updates in place' {
            $pol = Get-AzDataProtectionPolicyTemplate -DatasourceType AzureKubernetesService
            $opLc60 = New-AzDataProtectionRetentionLifeCycleClientObject -SourceDataStore OperationalStore -SourceRetentionDurationType Days -SourceRetentionDurationCount 60
            Edit-AzDataProtectionPolicyRetentionRuleClientObject -Policy $pol -Name Default -LifeCycles $opLc60 -IsDefault $true -OverwriteLifeCycle $true
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default" }).Count | Should be 1
            ($pol.PolicyRule | Where-Object { $_.Name -eq "Default" }).Lifecycle[0].DeleteAfterDuration | Should be "P60D"
        }
    }
}
