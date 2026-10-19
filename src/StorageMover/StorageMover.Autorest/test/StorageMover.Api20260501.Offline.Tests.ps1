# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

# Offline tests for the API 2026-05-01 additions. The internal service cmdlets are mocked,
# so these tests need neither recordings nor an Azure context.
InModuleScope Az.StorageMover.custom {
    Describe 'Az.StorageMover API 2026-05-01 endpoint parameters (offline)' {
        BeforeEach {
            $pathParameters = @{
                Name              = 'endpoint'
                ResourceGroupName = 'rg'
                StorageMoverName  = 'mover'
                SubscriptionId    = '00000000-0000-0000-0000-000000000000'
            }
            $accountId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Storage/storageAccounts/account'
            $partnerAccountId = '/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/partner-rg/providers/Microsoft.Storage/storageAccounts/partner'
            $identity = [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.StorageMoverIdentity]::New()
            $identity.Id = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.StorageMover/storageMovers/mover/endpoints/endpoint'
            $crossTenantCreateCases = @(
                @{ Command = 'New-AzStorageMoverAzStorageContainerEndpoint'; Parameters = @{ StorageAccountResourceId = $accountId; BlobContainerName = 'container' } },
                @{ Command = 'New-AzStorageMoverAzSmbFileShareEndpoint'; Parameters = @{ StorageAccountResourceId = $accountId; FileShareName = 'share' } }
            )
            $crossTenantUpdateCommands = @('Update-AzStorageMoverAzStorageContainerEndpoint', 'Update-AzStorageMoverAzSmbFileShareEndpoint')

            Mock New-AzStorageMoverEndpoint {
                [pscustomobject]@{
                    Property     = $Property
                    IdentityType = $IdentityType
                    Name         = $Name
                }
            }
            Mock Update-AzStorageMoverEndpoint {
                [pscustomobject]@{
                    Property     = $Property
                    IdentityType = $IdentityType
                    InputObject  = $InputObject
                    Name         = $Name
                }
            }
        }

        It 'sends EndpointKind from every endpoint create cmdlet' {
            $cases = @(
                @{ Command = 'New-AzStorageMoverAzStorageContainerEndpoint'; Parameters = @{ StorageAccountResourceId = $accountId; BlobContainerName = 'container' } },
                @{ Command = 'New-AzStorageMoverAzSmbFileShareEndpoint'; Parameters = @{ StorageAccountResourceId = $accountId; FileShareName = 'share' } },
                @{ Command = 'New-AzStorageMoverAzNfsFileShareEndpoint'; Parameters = @{ StorageAccountResourceId = $accountId; FileShareName = 'share' } },
                @{ Command = 'New-AzStorageMoverMultiCloudConnectorEndpoint'; Parameters = @{ MultiCloudConnectorId = 'connectorId'; AWSS3BucketId = 'bucketId' } },
                @{ Command = 'New-AzStorageMoverNfsEndpoint'; Parameters = @{ Host = '10.0.0.1'; Export = '/' } },
                @{ Command = 'New-AzStorageMoverSmbEndpoint'; Parameters = @{ Host = '10.0.0.1'; ShareName = 'share' } },
                @{ Command = 'New-AzStorageMoverS3WithHmacEndpoint'; Parameters = @{ SourceUri = 'https://s3.example.com/bucket'; SourceType = 'MINIO' } }
            )
            foreach ($case in $cases) {
                $parameters = $pathParameters + $case.Parameters
                $result = & $case.Command @parameters -EndpointKind Target
                ($result.Property.ToJsonString() | ConvertFrom-Json).endpointKind | Should -Be 'Target'
            }
        }

        It 'omits EndpointKind when it is not specified' {
            $result = New-AzStorageMoverNfsEndpoint @pathParameters -Host '10.0.0.1' -Export '/'
            ($result.Property.ToJsonString() | ConvertFrom-Json).PSObject.Properties.Name | Should -Not -Contain 'endpointKind'
        }

        It 'sends the NFSv4_1 version and FSX-EFS source type for NFS mount endpoints' {
            $result = New-AzStorageMoverNfsEndpoint @pathParameters -Host '10.0.0.1' -Export '/' -NfsVersion NFSv4_1 -SourceType FSX-EFS
            $json = $result.Property.ToJsonString() | ConvertFrom-Json
            $json.endpointType | Should -Be 'NfsMount'
            $json.nfsVersion | Should -Be 'NFSv4_1'
            $json.sourceType | Should -Be 'FSX-EFS'
        }

        It 'sends the FSX-SMB source type for SMB mount endpoints and keeps the credentials' {
            $result = New-AzStorageMoverSmbEndpoint @pathParameters -Host '10.0.0.1' -ShareName 'share' -SourceType FSX-SMB -CredentialsUsernameUri 'https://vault.vault.azure.net/secrets/username' -CredentialsPasswordUri 'https://vault.vault.azure.net/secrets/password'
            $json = $result.Property.ToJsonString() | ConvertFrom-Json
            $json.endpointType | Should -Be 'SmbMount'
            $json.sourceType | Should -Be 'FSX-SMB'
            $json.credentials.usernameUri | Should -Be 'https://vault.vault.azure.net/secrets/username'
            $json.credentials.passwordUri | Should -Be 'https://vault.vault.azure.net/secrets/password'
        }

        It 'sends cross-tenant settings when creating Azure Storage endpoints' {
            foreach ($case in $crossTenantCreateCases) {
                $parameters = $pathParameters + $case.Parameters
                $result = & $case.Command @parameters -EnableCrossTenantTransfer -AllowedStorageAccount $partnerAccountId
                $json = $result.Property.ToJsonString() | ConvertFrom-Json
                $json.enableCrossTenantTransfer | Should -Be $true
                @($json.allowedStorageAccounts).Count | Should -Be 1
                $json.allowedStorageAccounts[0] | Should -Be $partnerAccountId
            }
        }

        It 'omits cross-tenant settings when creating Azure Storage endpoints without them' {
            foreach ($case in $crossTenantCreateCases) {
                $parameters = $pathParameters + $case.Parameters
                $result = & $case.Command @parameters
                $names = ($result.Property.ToJsonString() | ConvertFrom-Json).PSObject.Properties.Name
                $names | Should -Not -Contain 'enableCrossTenantTransfer'
                $names | Should -Not -Contain 'allowedStorageAccounts'
            }
        }

        It 'keeps the SystemAssigned identity when creating and updating Azure Storage container endpoints' {
            (New-AzStorageMoverAzStorageContainerEndpoint @pathParameters -StorageAccountResourceId $accountId -BlobContainerName 'container' -EnableCrossTenantTransfer).IdentityType | Should -Be 'SystemAssigned'
            (Update-AzStorageMoverAzStorageContainerEndpoint @pathParameters -EnableCrossTenantTransfer).IdentityType | Should -Be 'SystemAssigned'
        }

        It 'sends cross-tenant settings when updating by name and by identity' {
            foreach ($command in $crossTenantUpdateCommands) {
                $results = @(
                    & $command @pathParameters -EnableCrossTenantTransfer -AllowedStorageAccount $partnerAccountId, $accountId
                    $identity | & $command -EnableCrossTenantTransfer -AllowedStorageAccount $partnerAccountId, $accountId
                )
                foreach ($result in $results) {
                    $json = $result.Property.ToJsonString() | ConvertFrom-Json
                    $json.enableCrossTenantTransfer | Should -Be $true
                    @($json.allowedStorageAccounts).Count | Should -Be 2
                    $json.allowedStorageAccounts[0] | Should -Be $partnerAccountId
                }
                $results[1].InputObject.Id | Should -Be $identity.Id
            }
        }

        It 'sends false and an empty allow list to disable cross-tenant transfer' {
            foreach ($command in $crossTenantUpdateCommands) {
                $result = & $command @pathParameters -EnableCrossTenantTransfer:$false -AllowedStorageAccount @() -Description 'disabled'
                $json = $result.Property.ToJsonString() | ConvertFrom-Json
                $json.PSObject.Properties.Name | Should -Contain 'enableCrossTenantTransfer'
                $json.enableCrossTenantTransfer | Should -Be $false
                $json.PSObject.Properties.Name | Should -Contain 'allowedStorageAccounts'
                @($json.allowedStorageAccounts).Count | Should -Be 0
                $json.description | Should -Be 'disabled'
            }
        }

        It 'omits cross-tenant settings when updating only the description' {
            foreach ($command in $crossTenantUpdateCommands) {
                $result = & $command @pathParameters -Description 'description only'
                $json = $result.Property.ToJsonString() | ConvertFrom-Json
                $json.PSObject.Properties.Name | Should -Not -Contain 'enableCrossTenantTransfer'
                $json.PSObject.Properties.Name | Should -Not -Contain 'allowedStorageAccounts'
                $json.description | Should -Be 'description only'
            }
        }

        It 'does not expose create-only endpoint properties on update cmdlets' {
            foreach ($command in @('Update-AzStorageMoverAzStorageContainerEndpoint', 'Update-AzStorageMoverAzSmbFileShareEndpoint', 'Update-AzStorageMoverAzNfsFileShareEndpoint', 'Update-AzStorageMoverMultiCloudConnectorEndpoint', 'Update-AzStorageMoverNfsEndpoint', 'Update-AzStorageMoverSmbEndpoint', 'Update-AzStorageMoverS3WithHmacEndpoint')) {
                $parameterNames = (Get-Command $command).Parameters.Keys
                $parameterNames | Should -Not -Contain 'EndpointKind'
                $parameterNames | Should -Not -Contain 'SourceType'
            }
        }
    }
}

Describe 'Az.StorageMover API 2026-05-01 generated surface (offline)' {
    It 'targets API version 2026-05-01 for every service operation' {
        $assembly = [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.JobDefinition].Assembly
        $apiVersions = @($assembly.GetTypes() | ForEach-Object {
            $_.GetCustomAttributes($false) | Where-Object { $_.GetType().Name -eq 'HttpPathAttribute' } | ForEach-Object { $_.ApiVersion }
        })
        $apiVersions.Count | Should -BeGreaterThan 0
        @($apiVersions | Where-Object { $_ -ne '2026-05-01' }).Count | Should -Be 0
    }

    It 'exports Invoke-AzStorageMoverReconcileJobDefinition with name and identity parameter sets' {
        $command = Get-Command Invoke-AzStorageMoverReconcileJobDefinition -Module Az.StorageMover
        $parameterSets = $command.ParameterSets.Name
        foreach ($parameterSet in @('Reconcile', 'ReconcileViaIdentity', 'ReconcileViaIdentityProject', 'ReconcileViaIdentityStorageMover')) {
            $parameterSets | Should -Contain $parameterSet
        }
    }

    It 'exposes the new job definition parameters, with cross-tenant settings only at creation' {
        $newParameters = (Get-Command New-AzStorageMoverJobDefinition -Module Az.StorageMover).Parameters.Keys
        foreach ($name in @('IsCrossTenantJob', 'CrossTenantEndpointTenantId', 'CrossTenantEndpointResourceId', 'SyncMode', 'MoverSyncedUntil', 'ScheduleRepeatInterval')) {
            $newParameters | Should -Contain $name
        }
        $updateParameters = (Get-Command Update-AzStorageMoverJobDefinition -Module Az.StorageMover).Parameters.Keys
        foreach ($name in @('SyncMode', 'MoverSyncedUntil', 'ScheduleRepeatInterval')) {
            $updateParameters | Should -Contain $name
        }
        foreach ($name in @('IsCrossTenantJob', 'CrossTenantEndpointTenantId', 'CrossTenantEndpointResourceId')) {
            $updateParameters | Should -Not -Contain $name
        }
    }

    It 'serializes cross-tenant, synchronization, and hourly schedule job definition properties' {
        $jobDefinition = [Microsoft.Azure.PowerShell.Cmdlets.StorageMover.Models.JobDefinition]::New()
        $jobDefinition.JobType = 'OnPremToCloudAgentLess'
        $jobDefinition.IsCrossTenantJob = $true
        $jobDefinition.CrossTenantEndpointTenantId = '11111111-1111-1111-1111-111111111111'
        $jobDefinition.CrossTenantEndpointResourceId = '/subscriptions/11111111-1111-1111-1111-111111111111/resourceGroups/rg/providers/Microsoft.StorageMover/storageMovers/mover/endpoints/target'
        $jobDefinition.SyncMode = 'SnapshotBased'
        $jobDefinition.ScheduleFrequency = 'Hourly'
        $jobDefinition.ScheduleRepeatInterval = 'PT1H'
        $properties = ($jobDefinition.ToJsonString() | ConvertFrom-Json).properties
        $properties.jobType | Should -Be 'OnPremToCloudAgentLess'
        $properties.isCrossTenantJob | Should -Be $true
        $properties.crossTenantEndpointTenantId | Should -Be '11111111-1111-1111-1111-111111111111'
        $properties.crossTenantEndpointResourceId | Should -Be $jobDefinition.CrossTenantEndpointResourceId
        $properties.syncMode | Should -Be 'SnapshotBased'
        $properties.schedule.frequency | Should -Be 'Hourly'
        $properties.schedule.repeatInterval | Should -Be 'PT1H'
    }
}
