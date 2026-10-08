# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

. (Join-Path $PSScriptRoot 'BackupInstance.Offline.Helpers.ps1')

Pester\Describe 'Initialize-AzDataProtectionBackupInstance offline generated models' -Tag 'DataProtectionBackupInstanceOffline', 'DataProtectionBackupInstanceInitializer' {
    Pester\It 'initializes a <SecurityType> <DiskRole> disk with <Assignment> snapshot RG assignment' -TestCases (Get-BackupInstanceOfflineDiskCases) {
        param($DiskName, $SecurityType, $DiskRole, $Assignment)

        $fixture = New-BackupInstanceOfflineFixture -DiskName $DiskName
        $parameters = @{
            DatasourceType = 'AzureDisk'
            DatasourceLocation = $fixture.Location
            DatasourceId = $fixture.DiskId
            PolicyId = $fixture.PolicyId
            ErrorAction = 'Stop'
        }
        if ($Assignment -eq 'Direct') {
            $parameters.SnapshotResourceGroupId = $fixture.SnapshotResourceGroupId
        }
        $instance = Az.DataProtection\Initialize-AzDataProtectionBackupInstance @parameters
        if ($Assignment -eq 'Deferred') {
            Assert-BackupInstanceOperationalStore -Instance $instance
            $list = $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList
            $element = $list[0]
            $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0].ResourceGroupId = $fixture.SnapshotResourceGroupId
            [object]::ReferenceEquals($list, $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList) | Should -Be $true
            [object]::ReferenceEquals($element, $list[0]) | Should -Be $true
        }
        Assert-BackupInstanceOperationalStore -Instance $instance -SnapshotResourceGroupId $fixture.SnapshotResourceGroupId
        $instance.Property.ObjectType | Should -Be 'BackupInstance'
        $instance.Property.DataSourceInfo.ResourceId | Should -Be $fixture.DiskId
        $instance.Property.DataSourceInfo.ResourceUri | Should -Be $fixture.DiskId
        $instance.Property.DataSourceInfo.ResourceName | Should -Be $fixture.DiskId.Split('/')[-1]
        $instance.Property.DataSourceInfo.ResourceLocation | Should -Be $fixture.Location
        $instance.Property.DataSourceInfo.Type | Should -Be 'Microsoft.Compute/disks'
        $instance.Property.PolicyInfo.PolicyId | Should -Be $fixture.PolicyId
        $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList | Should -BeNullOrEmpty
    }

    Pester\It 'does not share objects, lists or elements between successive initializations' {
        $firstFixture = New-BackupInstanceOfflineFixture -DiskName 'first'
        $secondFixture = New-BackupInstanceOfflineFixture -DiskName 'second'
        $first = Az.DataProtection\Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation $firstFixture.Location -DatasourceId $firstFixture.DiskId -PolicyId $firstFixture.PolicyId -SnapshotResourceGroupId $firstFixture.SnapshotResourceGroupId -ErrorAction Stop
        $second = Az.DataProtection\Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation $secondFixture.Location -DatasourceId $secondFixture.DiskId -PolicyId $secondFixture.PolicyId -ErrorAction Stop
        Assert-BackupInstanceOperationalStore -Instance $first -SnapshotResourceGroupId $firstFixture.SnapshotResourceGroupId
        Assert-BackupInstanceOperationalStore -Instance $second
        $firstList = $first.Property.PolicyInfo.PolicyParameter.DataStoreParametersList
        $secondList = $second.Property.PolicyInfo.PolicyParameter.DataStoreParametersList
        [object]::ReferenceEquals($first, $second) | Should -Be $false
        [object]::ReferenceEquals($first.Property, $second.Property) | Should -Be $false
        [object]::ReferenceEquals($first.Property.DataSourceInfo, $second.Property.DataSourceInfo) | Should -Be $false
        [object]::ReferenceEquals($first.Property.PolicyInfo, $second.Property.PolicyInfo) | Should -Be $false
        [object]::ReferenceEquals($first.Property.PolicyInfo.PolicyParameter, $second.Property.PolicyInfo.PolicyParameter) | Should -Be $false
        [object]::ReferenceEquals($firstList, $secondList) | Should -Be $false
        [object]::ReferenceEquals($firstList[0], $secondList[0]) | Should -Be $false

        $firstList[0].ResourceGroupId = $firstFixture.OtherSnapshotResourceGroupId
        $secondList[0].ResourceGroupId | Should -BeNullOrEmpty
        $secondList[0].ResourceGroupId = $secondFixture.SnapshotResourceGroupId
        $firstList[0].ResourceGroupId | Should -Be $firstFixture.OtherSnapshotResourceGroupId
        $first.Property.PolicyInfo.PolicyId = $firstFixture.SourcePolicyId
        $first.Property.DataSourceInfo.ResourceId = "$($firstFixture.DiskId)-changed"
        $firstList.Clear()
        Assert-BackupInstanceOperationalStore -Instance $second -SnapshotResourceGroupId $secondFixture.SnapshotResourceGroupId
        $second.Property.DataSourceInfo.ResourceId | Should -Be $secondFixture.DiskId
        $second.Property.DataSourceInfo.ResourceLocation | Should -Be $secondFixture.Location
        $second.Property.PolicyInfo.PolicyId | Should -Be $secondFixture.PolicyId

        $third = Az.DataProtection\Initialize-AzDataProtectionBackupInstance -DatasourceType AzureDisk -DatasourceLocation $firstFixture.Location -DatasourceId $firstFixture.DiskId -PolicyId $firstFixture.PolicyId -SnapshotResourceGroupId $firstFixture.SnapshotResourceGroupId -ErrorAction Stop
        Assert-BackupInstanceOperationalStore -Instance $third -SnapshotResourceGroupId $firstFixture.SnapshotResourceGroupId
        [object]::ReferenceEquals($third.Property.PolicyInfo.PolicyParameter.DataStoreParametersList, $secondList) | Should -Be $false
        [object]::ReferenceEquals($third.Property.PolicyInfo.PolicyParameter.DataStoreParametersList[0], $secondList[0]) | Should -Be $false
        $third.Property.DataSourceInfo.ResourceId | Should -Be $firstFixture.DiskId
        $third.Property.PolicyInfo.PolicyId | Should -Be $firstFixture.PolicyId
    }

    Pester\It 'leaves both parameter lists absent for AzureBlob without configuration' {
        $fixture = New-BackupInstanceOfflineFixture
        $instance = Az.DataProtection\Initialize-AzDataProtectionBackupInstance -DatasourceType AzureBlob -DatasourceLocation $fixture.Location -DatasourceId $fixture.StorageAccountId -PolicyId $fixture.PolicyId -ErrorAction Stop
        ($instance -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupInstanceResource]) | Should -Be $true
        $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList | Should -BeNullOrEmpty
        $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList | Should -BeNullOrEmpty
        $instance.Property.DataSourceInfo.ResourceId | Should -Be $fixture.StorageAccountId
        $instance.Property.PolicyInfo.PolicyId | Should -Be $fixture.PolicyId
    }

    Pester\It 'rejects a snapshot resource group for the datastore-disabled AzureBlob manifest' {
        $fixture = New-BackupInstanceOfflineFixture
        { Az.DataProtection\Initialize-AzDataProtectionBackupInstance -DatasourceType AzureBlob -DatasourceLocation $fixture.Location -DatasourceId $fixture.StorageAccountId -PolicyId $fixture.PolicyId -SnapshotResourceGroupId $fixture.SnapshotResourceGroupId -ErrorAction Stop } |
            Should -Throw 'Snapshot Resource Group Id parameter is invalid for this resource'
    }

    Pester\It 'preserves real <DatasourceType> container configuration without adding datastore parameters' -TestCases @(
        @{ DatasourceType = 'AzureBlob'; ObjectType = 'BlobBackupDatasourceParameters' }
        @{ DatasourceType = 'AzureDataLakeStorage'; ObjectType = 'AdlsBlobBackupDatasourceParameters' }
    ) {
        param($DatasourceType, $ObjectType)

        $fixture = New-BackupInstanceOfflineFixture
        $configuration = Az.DataProtection\New-AzDataProtectionBackupConfigurationClientObject -DatasourceType $DatasourceType -VaultedBackupContainer $fixture.Settings.VaultedContainers -ErrorAction Stop
        $instance = Az.DataProtection\Initialize-AzDataProtectionBackupInstance -DatasourceType $DatasourceType -DatasourceLocation $fixture.Location -DatasourceId $fixture.StorageAccountId -PolicyId $fixture.PolicyId -BackupConfiguration $configuration -ErrorAction Stop
        Assert-BackupInstanceDatasourceConfiguration -Instance $instance -Configuration $configuration
        $instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList | Should -BeNullOrEmpty
        $actual = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0]
        $actual.ObjectType | Should -Be $ObjectType
        ($actual.ContainersList -join ',') | Should -Be ($fixture.Settings.VaultedContainers -join ',')
    }

    Pester\It 'preserves AKS configuration fields and the operational store in real generated lists' {
        $fixture = New-BackupInstanceOfflineFixture
        $settings = $fixture.Settings.Kubernetes
        $hook = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.NamespacedNameResource]::new()
        $hook.Name = $settings.HookName
        $hook.Namespace = $settings.HookNamespace
        $configuration = Az.DataProtection\New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureKubernetesService -IncludedNamespace $settings.IncludedNamespace -ExcludedNamespace $settings.ExcludedNamespace -IncludedResourceType $settings.IncludedResourceType -ExcludedResourceType $settings.ExcludedResourceType -LabelSelector $settings.LabelSelector -SnapshotVolume $false -IncludeClusterScopeResource $false -BackupHookReference $hook -ErrorAction Stop
        $instance = Az.DataProtection\Initialize-AzDataProtectionBackupInstance -DatasourceType AzureKubernetesService -DatasourceLocation $fixture.Location -DatasourceId $fixture.KubernetesId -PolicyId $fixture.PolicyId -FriendlyName $fixture.FriendlyName -SnapshotResourceGroupId $fixture.SnapshotResourceGroupId -BackupConfiguration $configuration -ErrorAction Stop
        Assert-BackupInstanceOperationalStore -Instance $instance -SnapshotResourceGroupId $fixture.SnapshotResourceGroupId
        Assert-BackupInstanceDatasourceConfiguration -Instance $instance -Configuration $configuration
        $actual = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0]
        $actual.ObjectType | Should -Be 'KubernetesClusterBackupDatasourceParameters'
        foreach ($property in @('IncludedNamespace', 'ExcludedNamespace', 'IncludedResourceType', 'ExcludedResourceType', 'LabelSelector')) {
            ($actual.$property -join ',') | Should -Be ($settings.$property -join ',')
        }
        $actual.SnapshotVolume | Should -Be $false
        $actual.IncludeClusterScopeResource | Should -Be $false
        $actual.BackupHookReference.Count | Should -Be 1
        $actual.BackupHookReference[0].Name | Should -Be $settings.HookName
        $actual.BackupHookReference[0].Namespace | Should -Be $settings.HookNamespace
        $instance.Property.DataSourceInfo.ResourceId | Should -Be $fixture.KubernetesId
        $instance.Property.DataSourceInfo.ResourceLocation | Should -Be $fixture.Location
        $instance.Property.PolicyInfo.PolicyId | Should -Be $fixture.PolicyId
    }

    Pester\It 'requires AKS backup configuration even when a snapshot resource group is supplied' {
        $fixture = New-BackupInstanceOfflineFixture
        { Az.DataProtection\Initialize-AzDataProtectionBackupInstance -DatasourceType AzureKubernetesService -DatasourceLocation $fixture.Location -DatasourceId $fixture.KubernetesId -PolicyId $fixture.PolicyId -FriendlyName $fixture.FriendlyName -SnapshotResourceGroupId $fixture.SnapshotResourceGroupId -ErrorAction Stop } |
            Should -Throw 'Please input parameter BackupConfiguration'
    }

    Pester\It 'preserves the real ElasticSAN volume selector alongside its operational store' {
        $fixture = New-BackupInstanceOfflineFixture
        $configuration = Az.DataProtection\New-AzDataProtectionBackupConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceSelector $fixture.Settings.VolumeName -ErrorAction Stop
        $instance = Az.DataProtection\Initialize-AzDataProtectionBackupInstance -DatasourceType AzureElasticSAN -DatasourceLocation $fixture.Location -DatasourceId $fixture.ElasticSanId -PolicyId $fixture.PolicyId -FriendlyName $fixture.FriendlyName -SnapshotResourceGroupId $fixture.SnapshotResourceGroupId -BackupConfiguration $configuration -ErrorAction Stop
        Assert-BackupInstanceOperationalStore -Instance $instance -SnapshotResourceGroupId $fixture.SnapshotResourceGroupId
        Assert-BackupInstanceDatasourceConfiguration -Instance $instance -Configuration $configuration
        $actual = $instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList[0]
        $actual.ObjectType | Should -Be 'GenericBackupDatasourceParameters'
        $actual.ResourceSelector.Count | Should -Be 1
        $actual.ResourceSelector[0] | Should -Be $fixture.Settings.VolumeName
        $instance.Property.DataSourceInfo.ResourceId | Should -Be $fixture.ElasticSanId
    }
}
