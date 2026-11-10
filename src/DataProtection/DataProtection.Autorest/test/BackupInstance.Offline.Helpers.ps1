# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

function New-BackupInstanceOfflineFixture {
    param([string]$DiskName = 'disk')

    $fixturePath = $env:AZ_DATAPROTECTION_OFFLINE_FIXTURE
    if ([string]::IsNullOrEmpty($fixturePath)) {
        $fixturePath = Join-Path $PSScriptRoot 'BackupInstance.Offline.Fixture.json'
    }
    $settings = Get-Content -Raw -Path $fixturePath -ErrorAction Stop | ConvertFrom-Json -ErrorAction Stop
    $environment = Get-Content -Raw -Path (Join-Path $PSScriptRoot 'env.json') -ErrorAction Stop | ConvertFrom-Json -ErrorAction Stop
    $subscriptionId = $settings.SubscriptionId
    $location = $settings.Location
    if ([string]::IsNullOrEmpty($subscriptionId)) {
        $subscriptionId = $environment.SubscriptionId
    }
    if ([string]::IsNullOrEmpty($location)) {
        $location = $environment.TestCmkEncryption.Location
    }
    if ([string]::IsNullOrEmpty($subscriptionId) -or [string]::IsNullOrEmpty($location)) {
        throw 'Set SubscriptionId and Location in AZ_DATAPROTECTION_OFFLINE_FIXTURE or the test environment.'
    }

    # Only subscription/location seeds come from env.json; no provisioned resource is used.
    $prefix = '{0}-{1}' -f $settings.NamePrefix, [Guid]::NewGuid().ToString('N').Substring(0, 8)
    $resourceGroupName = "$prefix-rg"
    $resourceGroupId = "/subscriptions/$subscriptionId/resourceGroups/$resourceGroupName"
    $targetVaultName = "$prefix-target-vault"
    $sourceVaultName = "$prefix-source-vault"
    $targetVaultId = "$resourceGroupId/providers/Microsoft.DataProtection/backupVaults/$targetVaultName"
    $sourceVaultId = "$resourceGroupId/providers/Microsoft.DataProtection/backupVaults/$sourceVaultName"
    [pscustomobject]@{
        Settings = $settings
        SubscriptionId = $subscriptionId
        Location = $location
        ResourceGroupName = $resourceGroupName
        TargetVaultName = $targetVaultName
        TargetVaultId = $targetVaultId
        SourceVaultName = $sourceVaultName
        SourceVaultId = $sourceVaultId
        SourceInstanceName = "$prefix-suspended"
        PolicyId = "$targetVaultId/backupPolicies/$prefix-target-policy"
        SourcePolicyId = "$sourceVaultId/backupPolicies/$prefix-source-policy"
        DiskId = "$resourceGroupId/providers/Microsoft.Compute/disks/$prefix-$DiskName"
        StorageAccountId = "$resourceGroupId/providers/Microsoft.Storage/storageAccounts/$($prefix.Replace('-', ''))"
        KubernetesId = "$resourceGroupId/providers/Microsoft.ContainerService/managedClusters/$prefix-cluster"
        ElasticSanId = "$resourceGroupId/providers/Microsoft.ElasticSan/elasticSans/$prefix-san/volumeGroups/$prefix-volumes"
        FriendlyName = "$prefix-instance"
        SnapshotResourceGroupId = "/subscriptions/$subscriptionId/resourceGroups/$prefix-snapshots"
        OtherSnapshotResourceGroupId = "/subscriptions/$subscriptionId/resourceGroups/$prefix-other-snapshots"
        SourceSnapshotResourceGroupId = "/subscriptions/$subscriptionId/resourceGroups/$prefix-source-snapshots"
    }
}

function Get-BackupInstanceOfflineDiskCases {
    # Security type and OS/data role are fixture metadata, not initializer branches or service support evidence.
    foreach ($profile in (New-BackupInstanceOfflineFixture).Settings.DiskProfiles) {
        foreach ($assignment in @('Direct', 'Deferred')) {
            @{
                DiskName = $profile.Name
                SecurityType = $profile.SecurityType
                DiskRole = $profile.DiskRole
                Assignment = $assignment
            }
        }
    }
}

function Assert-BackupInstanceOperationalStore {
    param($Instance, [string]$SnapshotResourceGroupId)

    ($Instance -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupInstanceResource]) | Should -Be $true
    $store = $Instance.Property.PolicyInfo.PolicyParameter.DataStoreParametersList
    ($store -is [System.Collections.Generic.List[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IDataStoreParameters]]) | Should -Be $true
    $store.Count | Should -Be 1
    ($store[0] -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.AzureOperationalStoreParameters]) | Should -Be $true
    $store[0].ObjectType | Should -Be 'AzureOperationalStoreParameters'
    $store[0].DataStoreType | Should -Be 'OperationalStore'
    if ([string]::IsNullOrEmpty($SnapshotResourceGroupId)) {
        $store[0].ResourceGroupId | Should -BeNullOrEmpty
    } else {
        $store[0].ResourceGroupId | Should -Be $SnapshotResourceGroupId
    }
}

function Assert-BackupInstanceDatasourceConfiguration {
    param($Instance, $Configuration)

    $parameters = $Instance.Property.PolicyInfo.PolicyParameter.BackupDatasourceParametersList
    ($parameters -is [System.Collections.Generic.List[Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IBackupDatasourceParameters]]) | Should -Be $true
    $parameters.Count | Should -Be 1
    [object]::ReferenceEquals($parameters[0], $Configuration) | Should -Be $true
    $parameters[0].ObjectType | Should -Be $Configuration.ObjectType
}

function New-BackupInstanceOfflinePipeline {
    param([string]$RecordingFile, [string]$GetResponse = '{}')

    $replay = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.PipelineMock]::new($RecordingFile)
    $replay.SetPlayback()
    $sent = [System.Collections.Generic.List[object]]::new()
    $terminal = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep]{
        param($request, $callback, $next)

        if ($request.Method.Method -notin @('GET', 'PUT')) {
            throw "Unexpected backup instance request: $($request.Method) $($request.RequestUri)"
        }
        $body = $null
        if ($null -ne $request.Content) {
            $body = $request.Content.ReadAsStringAsync().GetAwaiter().GetResult()
        }
        $sent.Add([pscustomobject]@{
            Method = $request.Method.Method
            Uri = $request.RequestUri
            Body = $body
        })
        $responseBody = '{}'
        if ($request.Method.Method -eq 'GET') {
            $responseBody = $GetResponse
        }
        $response = [System.Net.Http.HttpResponseMessage]::new([System.Net.HttpStatusCode]::OK)
        $response.RequestMessage = $request
        $response.Content = [System.Net.Http.StringContent]::new($responseBody)
        $completed = New-Object 'System.Threading.Tasks.TaskCompletionSource[System.Net.Http.HttpResponseMessage]'
        $completed.SetResult($response)
        return $completed.Task
    }.GetNewClosure()

    # The last prepend step runs first and never calls next: neither Azure nor a recording file is accessed.
    [pscustomobject]@{ Sent = $sent; Steps = @($replay, $terminal) }
}

function Assert-BackupInstanceDiskCreateRequest {
    param($Request, $Fixture, $Instance)

    $Request.Method | Should -Be 'PUT'
    $Request.Uri.AbsolutePath | Should -Be "$($Fixture.TargetVaultId)/backupInstances/$($Instance.BackupInstanceName)"
    $body = $Request.Body | ConvertFrom-Json
    $body.properties.objectType | Should -Be 'BackupInstance'
    $body.properties.policyInfo.policyId | Should -Be $Fixture.PolicyId
    $body.properties.dataSourceInfo.resourceID | Should -Be $Fixture.DiskId
    $body.properties.dataSourceInfo.resourceLocation | Should -Be $Fixture.Location
    $body.properties.dataSourceInfo.datasourceType | Should -Be 'Microsoft.Compute/disks'
    $store = $body.properties.policyInfo.policyParameters.dataStoreParametersList
    ($store -is [System.Array]) | Should -Be $true
    $store.Count | Should -Be 1
    $store[0].objectType | Should -Be 'AzureOperationalStoreParameters'
    $store[0].dataStoreType | Should -Be 'OperationalStore'
    $store[0].resourceGroupId | Should -Be $Fixture.SnapshotResourceGroupId
}
