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

# Pester 4.10.1; real loaded artifact models plus current source functions. No
# loadEnv.ps1, recordings, Azure context, or HTTP calls are needed. Wire snapshots
# MUST use IncludeCreateOrUpdate, as the generated request transport does; default
# ToJsonString/IncludeAll is used only for the explicit deserialization roundtrip.
Describe 'CosmosRestoreRegression' -Tag 'Unit', 'CosmosRestore' {
    BeforeAll {
        if (-not ('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.GenericRestoreDatasourceCriteria' -as [type])) {
            throw 'Import the current Az.DataProtection artifact with unversioned GenericRestoreDatasourceCriteria models before running these tests.'
        }
        $moduleRoot = Split-Path -Parent $PSScriptRoot
        . (Join-Path $moduleRoot 'custom/manifests/ManifestLoader.ps1')
        Get-ChildItem (Join-Path $moduleRoot 'custom/Helpers') -Filter '*.ps1' -Recurse -File | ForEach-Object { . $_.FullName }
        . (Join-Path $moduleRoot 'custom/Cmdlets/Platform/Restore/New-AzDataProtectionRestoreConfigurationClientObject.ps1')
        . (Join-Path $moduleRoot 'custom/Cmdlets/Platform/Restore/Initialize-AzDataProtectionRestoreRequest.ps1')

        $resourceGroupId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/restore-tests'
        $cosmosAccountId = "$resourceGroupId/providers/Microsoft.DocumentDB/databaseAccounts/target-account"
        $blobAccountId = "$resourceGroupId/providers/Microsoft.Storage/storageAccounts/targetstorage"
        $aksId = "$resourceGroupId/providers/Microsoft.ContainerService/managedClusters/target-aks"
        $sanId = "$resourceGroupId/providers/Microsoft.ElasticSan/elasticSans/target-san/volumeGroups/target-vg"

        function Get-TestRestoreUamiId {
            "$resourceGroupId/providers/Microsoft.ManagedIdentity/userAssignedIdentities/restore-identity"
        }

        function ConvertTo-TestRestoreWireObject($Model) {
            $Model.ToJson($null, [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode]::IncludeCreateOrUpdate).ToString() | ConvertFrom-Json
        }

        # Sort object properties only; never sort arrays or fold string case.
        # Comparing whole snapshots then catches extra keys and array shape/order
        # without relying on generated serializer property ordering.
        function ConvertTo-TestRestoreCanonicalObject($Value) {
            if ($null -eq $Value) { return $null }
            if ($Value -is [System.Collections.IDictionary]) {
                $result = [ordered]@{}
                foreach ($key in @($Value.Keys | Sort-Object)) {
                    $result[$key] = ConvertTo-TestRestoreCanonicalObject $Value[$key]
                }
                return $result
            }
            if ($Value -is [pscustomobject]) {
                $result = [ordered]@{}
                foreach ($property in @($Value.PSObject.Properties | Sort-Object Name)) {
                    $result[$property.Name] = ConvertTo-TestRestoreCanonicalObject $property.Value
                }
                return $result
            }
            if ($Value -is [System.Collections.IEnumerable] -and $Value -isnot [string]) {
                return ,@(foreach ($entry in $Value) { ConvertTo-TestRestoreCanonicalObject $entry })
            }
            return $Value
        }

        function Assert-TestRestoreSnapshot($Actual, [string]$ExpectedJson) {
            # An object envelope keeps ConvertFrom-Json from enumerating a root
            # array (especially [] and [one item]) into null or a scalar.
            $actualEnvelope = [ordered]@{ value = $Actual }
            $actualJson = ConvertTo-Json -InputObject (ConvertTo-TestRestoreCanonicalObject $actualEnvelope) -Depth 100 -Compress
            $expected = ConvertFrom-Json -InputObject ('{"value":' + $ExpectedJson + '}')
            $expectedJson = ConvertTo-Json -InputObject (ConvertTo-TestRestoreCanonicalObject $expected) -Depth 100 -Compress
            $actualJson | Should -BeExactly $expectedJson
        }

        function Assert-TestRestoreOptionalBackingFields($Target, [hashtable]$Expected) {
            foreach ($name in $Expected.Keys) {
                $field = $Target.GetType().GetField($name, [System.Reflection.BindingFlags]'Instance, NonPublic')
                $field | Should -Not -BeNullOrEmpty
                # Never use the generated getter here: it would recreate a
                # cleared object and hide a serializer mutation regression.
                [object]::ReferenceEquals($field.GetValue($Target), $Expected[$name]) | Should -Be $true
            }
        }

        function New-TestRestoreRequest([string]$Workload = 'CosmosILR', [hashtable]$Identity = @{}) {
            $parameters = @{
                SourceDataStore = 'VaultStore'; RestoreLocation = 'eastus'
                RestoreType = 'AlternateLocation'; RecoveryPoint = 'unit-test-recovery-point'
                ErrorAction = 'Stop'
            }
            switch ($Workload) {
                'CosmosILR' {
                    $parameters.DatasourceType = 'AzureCosmosDB'
                    $parameters.TargetResourceId = $cosmosAccountId
                    $parameters.ItemLevelRecovery = $true
                    $parameters.RestoreConfiguration = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @('DB1/col1', 'Db1/col2', 'db2') -ErrorAction Stop
                }
                'CosmosFull' {
                    $parameters.DatasourceType = 'AzureCosmosDB'
                    $parameters.TargetResourceId = $cosmosAccountId
                }
                'Blob' {
                    $parameters.DatasourceType = 'AzureBlob'
                    $parameters.TargetResourceId = $blobAccountId
                    $parameters.ItemLevelRecovery = $true
                    $parameters.ContainersList = @('first', 'second')
                }
                'AKS' {
                    $parameters.DatasourceType = 'AzureKubernetesService'
                    $parameters.TargetResourceId = $aksId
                    $parameters.RestoreConfiguration = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService
                }
                'ElasticSAN' {
                    $parameters.DatasourceType = 'AzureElasticSAN'
                    $parameters.SourceDataStore = 'OperationalStore'
                    $parameters.TargetResourceId = $sanId
                    $parameters.RestoreConfiguration = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @('source-volume')
                }
                default { throw "Unknown test workload: $Workload" }
            }
            foreach ($key in $Identity.Keys) { $parameters[$key] = $Identity[$key] }
            Initialize-AzDataProtectionRestoreRequest @parameters
        }

        function New-TestBlobBackupInstance {
            # Construct the minimal real model locally, never query a live BI.
            $instance = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.BackupInstanceResource]::new()
            $instance.Property = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.BackupInstance]::new()
            $instance.Property.DatasourceInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.Datasource]::new()
            $instance.Property.DatasourceInfo.ResourceId = $blobAccountId
            return $instance
        }
    }

    Context 'Snapshot comparison shape contract' {
        It 'preserves a one-element root array rather than accepting its scalar item' {
            $value = [pscustomobject]@{ objectType = 'GenericRestoreDatasourceCriteria' }
            Assert-TestRestoreSnapshot @($value) '[{"objectType":"GenericRestoreDatasourceCriteria"}]'
            { Assert-TestRestoreSnapshot @($value) '{"objectType":"GenericRestoreDatasourceCriteria"}' } | Should -Throw
            { Assert-TestRestoreSnapshot $value '[{"objectType":"GenericRestoreDatasourceCriteria"}]' } | Should -Throw
        }

        It 'distinguishes an empty root array from null' {
            Assert-TestRestoreSnapshot @() '[]'
            Assert-TestRestoreSnapshot $null 'null'
            { Assert-TestRestoreSnapshot @() 'null' } | Should -Throw
            { Assert-TestRestoreSnapshot $null '[]' } | Should -Throw
        }
    }

    Context 'Cosmos generated request wire snapshots' {
        It 'serializes the entire native ILR request without rename, Blob criteria, or optional empty objects' {
            $request = New-TestRestoreRequest
            $wire = ConvertTo-TestRestoreWireObject $request
            Assert-TestRestoreSnapshot $wire @"
{
  "objectType": "AzureBackupRecoveryPointBasedRestoreRequest",
  "recoveryPointId": "unit-test-recovery-point",
  "sourceDataStoreType": "VaultStore",
  "restoreTargetInfo": {
    "objectType": "ItemLevelRestoreTargetInfo",
    "recoveryOption": "FailIfExists",
    "restoreLocation": "eastus",
    "datasourceInfo": {
      "objectType": "Datasource",
      "datasourceType": "Microsoft.DocumentDB/databaseAccounts",
      "resourceID": "$cosmosAccountId",
      "resourceName": "target-account",
      "resourceType": "Microsoft.DocumentDB/databaseAccounts",
      "resourceLocation": "eastus",
      "resourceUri": "$cosmosAccountId"
    },
    "restoreCriteria": [{
      "objectType": "GenericRestoreDatasourceCriteria",
    "resourceSelectors": {
        "objectType": "ResourceListSelectionCriteria",
        "resourceIdentifiers": ["DB1/col1", "Db1/col2", "db2"]
      }
    }]
  }
}
"@
        }

        It 'preserves the entire Cosmos full restore request with no ILR configuration' {
            $wire = ConvertTo-TestRestoreWireObject (New-TestRestoreRequest -Workload CosmosFull)
            Assert-TestRestoreSnapshot $wire @"
{
  "objectType": "AzureBackupRecoveryPointBasedRestoreRequest",
  "recoveryPointId": "unit-test-recovery-point",
  "sourceDataStoreType": "VaultStore",
  "restoreTargetInfo": {
    "objectType": "RestoreTargetInfo",
    "recoveryOption": "FailIfExists",
    "restoreLocation": "eastus",
    "datasourceInfo": {
      "objectType": "Datasource",
      "datasourceType": "Microsoft.DocumentDB/databaseAccounts",
      "resourceID": "$cosmosAccountId",
      "resourceName": "target-account",
      "resourceType": "Microsoft.DocumentDB/databaseAccounts",
      "resourceLocation": "eastus",
      "resourceUri": "$cosmosAccountId"
    }
  }
}
"@
        }

        It 'retains selector typing and exact identifiers after generated model roundtrip' {
            $request = New-TestRestoreRequest
            $roundtrip = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.AzureBackupRecoveryPointBasedRestoreRequest]::FromJsonString($request.ToJsonString())
            ($roundtrip.RestoreTargetInfo.RestoreCriterion[0] -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericRestoreDatasourceCriteria]) | Should -Be $true
            $before = ConvertTo-TestRestoreWireObject $request
            $after = ConvertTo-TestRestoreWireObject $roundtrip
            Assert-TestRestoreSnapshot $after ($before | ConvertTo-Json -Depth 100)
            ($after.restoreTargetInfo.restoreCriteria[0].resourceSelectors.resourceIdentifiers -join '|') | Should -BeExactly 'DB1/col1|Db1/col2|db2'
        }
    }

    Context 'Optional target serialization preserves retained objects for every datasource' {
        $inspectionCases = foreach ($workload in @('CosmosILR', 'CosmosFull')) {
            foreach ($inspection in @('DatasourceSetInfo', 'DatasourceAuthCredentials', 'Both', 'Display', 'Reflection')) {
                @{ Workload = $workload; Inspection = $inspection }
            }
        }
        It '<Workload> omits materialized empty optional objects after <Inspection>' -TestCases $inspectionCases {
            param($Workload, $Inspection)
            $request = New-TestRestoreRequest -Workload $Workload
            $before = ConvertTo-TestRestoreWireObject $request
            $target = $request.RestoreTargetInfo
            switch ($Inspection) {
                'DatasourceSetInfo' { $null = $target.DatasourceSetInfo }
                'DatasourceAuthCredentials' { $null = $target.DatasourceAuthCredentials }
                'Both' { $null = $target.DatasourceSetInfo; $null = $target.DatasourceAuthCredentials }
                'Display' { $null = $target | Format-List * | Out-String }
                'Reflection' {
                    foreach ($property in $target.GetType().GetProperties()) {
                        if ($property.CanRead -and $property.GetIndexParameters().Count -eq 0) {
                            $null = $property.GetValue($target, $null)
                        }
                    }
                }
            }
            $set = $target.DatasourceSetInfo
            $credentials = $target.DatasourceAuthCredentials
            $expected = @{ _datasourceSetInfo = $set; _datasourceAuthCredentials = $credentials }
            $after = ConvertTo-TestRestoreWireObject $request
            Assert-TestRestoreOptionalBackingFields $target $expected
            @($after.restoreTargetInfo.PSObject.Properties.Name) -contains 'datasourceSetInfo' | Should -Be $false
            @($after.restoreTargetInfo.PSObject.Properties.Name) -contains 'datasourceAuthCredentials' | Should -Be $false
            # Display can materialize unrelated generated children. The regression
            # contract here is specifically the two optional target objects.
            # Windows PowerShell 5.1 emits no JSON for null; keep this explicit
            # at the caller so invalid expected JSON is never normalized away.
            $expectedCriteriaJson = if ($null -eq $before.restoreTargetInfo.restoreCriteria) {
                'null'
            } else {
                ConvertTo-Json -InputObject $before.restoreTargetInfo.restoreCriteria -Depth 100
            }
            Assert-TestRestoreSnapshot $after.restoreTargetInfo.restoreCriteria $expectedCriteriaJson
        }

        It 'preserves populated optional fields on <Workload>' -TestCases @(
            @{ Workload = 'CosmosILR' }
            @{ Workload = 'CosmosFull' }
        ) {
            param($Workload)
            $request = New-TestRestoreRequest -Workload $Workload
            $target = $request.RestoreTargetInfo
            $target.DatasourceSetInfo = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.DatasourceSet]::new()
            $target.DatasourceSetInfo.ObjectType = 'DatasourceSet'
            $target.DatasourceSetInfo.ResourceId = $cosmosAccountId
            $target.DatasourceAuthCredentials = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.SecretStoreBasedAuthCredentials]::new()
            $target.DatasourceAuthCredentials.ObjectType = 'SecretStoreBasedAuthCredentials'
            $target.DatasourceAuthCredentials.SecretStoreResource = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.SecretStoreResource]::new()
            $target.DatasourceAuthCredentials.SecretStoreResource.SecretStoreType = 'AzureKeyVault'
            $target.DatasourceAuthCredentials.SecretStoreResource.Uri = 'https://unit-test.vault.azure.net/secrets/example'
            $wire = ConvertTo-TestRestoreWireObject $request
            $wire.restoreTargetInfo.datasourceSetInfo.resourceID | Should -BeExactly $cosmosAccountId
            $wire.restoreTargetInfo.datasourceAuthCredentials.objectType | Should -BeExactly 'SecretStoreBasedAuthCredentials'
            $wire.restoreTargetInfo.datasourceAuthCredentials.secretStoreResource.uri | Should -BeExactly 'https://unit-test.vault.azure.net/secrets/example'
        }

        $populatedOptionalCases = foreach ($workload in @('CosmosILR', 'CosmosFull')) {
            foreach ($field in @('DatasourceSetInfo', 'DatasourceAuthCredentials')) {
                @{ Workload = $workload; Field = $field }
            }
        }
        It '<Workload> preserves a discriminator-only populated <Field> independently' -TestCases $populatedOptionalCases {
            param($Workload, $Field)
            $request = New-TestRestoreRequest -Workload $Workload
            $target = $request.RestoreTargetInfo
            # Materialize both. Populating one must neither delete it nor make
            # the other empty object start appearing on the wire.
            $null = $target.DatasourceSetInfo
            $null = $target.DatasourceAuthCredentials
            $target.$Field.ObjectType = 'UnitTestPopulatedDiscriminator'
            $wire = ConvertTo-TestRestoreWireObject $request
            if ($Field -eq 'DatasourceSetInfo') {
                $wire.restoreTargetInfo.datasourceSetInfo.objectType | Should -BeExactly 'UnitTestPopulatedDiscriminator'
                @($wire.restoreTargetInfo.PSObject.Properties.Name) -contains 'datasourceAuthCredentials' | Should -Be $false
            } else {
                $wire.restoreTargetInfo.datasourceAuthCredentials.objectType | Should -BeExactly 'UnitTestPopulatedDiscriminator'
                @($wire.restoreTargetInfo.PSObject.Properties.Name) -contains 'datasourceSetInfo' | Should -Be $false
            }
        }

        $optionalRetentionCases = foreach ($targetKind in @('Full', 'ItemLevel')) {
            foreach ($datasourceType in @('Microsoft.DocumentDB/databaseAccounts', 'Microsoft.Storage/storageAccounts/blobServices', 'Microsoft.ContainerService/managedClusters', 'Microsoft.ElasticSan/elasticSans/volumeGroups', 'UnitTest/arbitraryDatasource', '')) {
                @{ TargetKind = $targetKind; DatasourceType = $datasourceType }
            }
        }
        It 'retains empty references then serializes their later content for <TargetKind> with datasource <DatasourceType>' -TestCases $optionalRetentionCases {
            param($TargetKind, $DatasourceType)
            $target = if ($TargetKind -eq 'Full') {
                [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.RestoreTargetInfo]::new()
            } else {
                [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ItemLevelRestoreTargetInfo]::new()
            }
            $target.DatasourceInfo.Type = $DatasourceType
            # A conflicting ResourceType must not select any serializer guard.
            $target.DatasourceInfo.ResourceType = if ($DatasourceType -eq 'Microsoft.DocumentDB/databaseAccounts') { 'Microsoft.Storage/storageAccounts' } else { 'Microsoft.DocumentDB/databaseAccounts' }
            $set = $target.DatasourceSetInfo
            $credentials = $target.DatasourceAuthCredentials
            ($null -eq $set) | Should -Be $false
            ($null -eq $credentials) | Should -Be $false
            $expected = @{ _datasourceSetInfo = $set; _datasourceAuthCredentials = $credentials }
            $before = ConvertTo-TestRestoreWireObject $target
            Assert-TestRestoreOptionalBackingFields $target $expected
            @($before.PSObject.Properties.Name) -contains 'datasourceSetInfo' | Should -Be $false
            @($before.PSObject.Properties.Name) -contains 'datasourceAuthCredentials' | Should -Be $false
            $again = ConvertTo-TestRestoreWireObject $target
            Assert-TestRestoreSnapshot $again (ConvertTo-Json -InputObject $before -Depth 100)
            Assert-TestRestoreOptionalBackingFields $target $expected

            # Populate the retained instances AFTER serialization, without
            # assigning them back to the target: detaching either loses data.
            $set.ObjectType = 'DatasourceSet'
            $set.ResourceId = $blobAccountId
            # The optional getter returns base AuthCredentials, not the derived
            # secret-store type. Populate its actual public property; populated
            # derived credentials are covered independently above.
            $credentials.ObjectType = 'UnitTestRetainedAuthCredentials'
            $wire = ConvertTo-TestRestoreWireObject $target
            Assert-TestRestoreOptionalBackingFields $target $expected
            $wire.datasourceSetInfo.objectType | Should -BeExactly 'DatasourceSet'
            $wire.datasourceSetInfo.resourceID | Should -BeExactly $blobAccountId
            $wire.datasourceAuthCredentials.objectType | Should -BeExactly 'UnitTestRetainedAuthCredentials'
            [object]::ReferenceEquals($target.DatasourceSetInfo, $set) | Should -Be $true
            [object]::ReferenceEquals($target.DatasourceAuthCredentials, $credentials) | Should -Be $true
            $again = ConvertTo-TestRestoreWireObject $target
            Assert-TestRestoreSnapshot $again (ConvertTo-Json -InputObject $wire -Depth 100)
            Assert-TestRestoreOptionalBackingFields $target $expected
        }
    }

    Context 'AKS existing configuration snapshots' {
        It 'keeps AKS defaults and the existing full-recovery configuration route' {
            $wire = ConvertTo-TestRestoreWireObject (New-TestRestoreRequest -Workload AKS)
            $wire.restoreTargetInfo.objectType | Should -BeExactly 'ItemLevelRestoreTargetInfo'
            @($wire.restoreTargetInfo.restoreCriteria).Count | Should -Be 1
            Assert-TestRestoreSnapshot $wire.restoreTargetInfo.restoreCriteria[0] @'
{
  "objectType":"KubernetesClusterRestoreCriteria",
  "includeClusterScopeResources":true,
  "conflictPolicy":"Skip",
  "persistentVolumeRestoreMode":"RestoreWithVolumeData"
}
'@
        }

        It 'preserves explicit AKS filters and false cluster scope' {
            $configuration = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService -IncludedNamespace @('ns2', 'ns1') -ExcludedNamespace @('excluded') -IncludedResourceType @('pods') -ExcludedResourceType @('secrets') -LabelSelector @('app=test') -IncludeClusterScopeResource $false -ConflictPolicy Patch -PersistentVolumeRestoreMode RestoreWithoutVolumeData
            Assert-TestRestoreSnapshot (ConvertTo-TestRestoreWireObject $configuration) @'
{
  "objectType":"KubernetesClusterRestoreCriteria",
  "includeClusterScopeResources":false,
  "includedNamespaces":["ns2","ns1"], "excludedNamespaces":["excluded"],
  "includedResourceTypes":["pods"], "excludedResourceTypes":["secrets"],
  "labelSelectors":["app=test"], "conflictPolicy":"Patch",
  "persistentVolumeRestoreMode":"RestoreWithoutVolumeData"
}
'@
        }

        It 'retains vault-tier staging IDs and criterion type' {
            $configuration = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService -StagingResourceGroupId $resourceGroupId -StagingStorageAccountId $blobAccountId
            Assert-TestRestoreSnapshot (ConvertTo-TestRestoreWireObject $configuration) @"
{
  "objectType":"KubernetesClusterVaultTierRestoreCriteria",
  "includeClusterScopeResources":true, "conflictPolicy":"Skip",
  "persistentVolumeRestoreMode":"RestoreWithVolumeData",
  "stagingResourceGroupId":"$resourceGroupId", "stagingStorageAccountId":"$blobAccountId"
}
"@
        }

        It 'continues rejecting partial staging information' {
            { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService -StagingResourceGroupId $resourceGroupId -ErrorAction Stop } | Should -Throw
            { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService -StagingStorageAccountId $blobAccountId -ErrorAction Stop } | Should -Throw
        }
    }

    Context 'Blob existing request snapshots' {
        It 'emits one VaultStore ItemPath criterion per container with matching prefixes and rename' {
            $request = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore VaultStore -RestoreLocation eastus -RestoreType AlternateLocation -TargetResourceId $blobAccountId -RecoveryPoint unit-test-recovery-point -ItemLevelRecovery -ContainersList @('first', 'second') -PrefixMatch @{ first = @('a/', 'b/'); second = @('z/') } -RenameTo @{ first = 'renamed-first'; second = 'renamed-second' } -ErrorAction Stop
            $wire = ConvertTo-TestRestoreWireObject $request
            Assert-TestRestoreSnapshot $wire.restoreTargetInfo.restoreCriteria @'
[
  {"objectType":"ItemPathBasedRestoreCriteria","itemPath":"first","isPathRelativeToBackupItem":true,"subItemPathPrefix":["a/","b/"],"renameTo":"renamed-first"},
  {"objectType":"ItemPathBasedRestoreCriteria","itemPath":"second","isPathRelativeToBackupItem":true,"subItemPathPrefix":["z/"],"renameTo":"renamed-second"}
]
'@
            $wire.restoreTargetInfo.datasourceSetInfo.resourceID | Should -BeExactly $blobAccountId
        }

        It 'keeps VaultStore criteria without prefixes or rename unchanged' {
            $wire = ConvertTo-TestRestoreWireObject (New-TestRestoreRequest -Workload Blob)
            Assert-TestRestoreSnapshot $wire.restoreTargetInfo.restoreCriteria @'
[
  {"objectType":"ItemPathBasedRestoreCriteria","itemPath":"first","isPathRelativeToBackupItem":true},
  {"objectType":"ItemPathBasedRestoreCriteria","itemPath":"second","isPathRelativeToBackupItem":true}
]
'@
        }

        It 'preserves OperationalStore PIT container ranges and UTC recovery time' {
            $request = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation eastus -RestoreType OriginalLocation -BackupInstance (New-TestBlobBackupInstance) -PointInTime ([datetime]'2026-01-02T03:04:05Z') -ItemLevelRecovery -ContainersList @('first', 'second') -ErrorAction Stop
            $wire = ConvertTo-TestRestoreWireObject $request
            $wire.objectType | Should -BeExactly 'AzureBackupRecoveryTimeBasedRestoreRequest'
            ([datetime]$wire.recoveryPointTime).ToUniversalTime().ToString('yyyy-MM-ddTHH:mm:ss.fffffffZ') | Should -BeExactly '2026-01-02T03:04:05.0000000Z'
            Assert-TestRestoreSnapshot $wire.restoreTargetInfo.restoreCriteria @'
[
  {"objectType":"RangeBasedItemLevelRestoreCriteria","minMatchingValue":"first","maxMatchingValue":"first-0"},
  {"objectType":"RangeBasedItemLevelRestoreCriteria","minMatchingValue":"second","maxMatchingValue":"second-0"}
]
'@
        }

        It 'preserves OperationalStore PIT explicit prefix ranges in input order' {
            $request = Initialize-AzDataProtectionRestoreRequest -DatasourceType AzureBlob -SourceDataStore OperationalStore -RestoreLocation eastus -RestoreType OriginalLocation -BackupInstance (New-TestBlobBackupInstance) -PointInTime ([datetime]'2026-01-02T03:04:05Z') -ItemLevelRecovery -FromPrefixPattern @('second/a', 'first/b') -ToPrefixPattern @('second/z', 'first/y') -ErrorAction Stop
            Assert-TestRestoreSnapshot (ConvertTo-TestRestoreWireObject $request).restoreTargetInfo.restoreCriteria @'
[
  {"objectType":"RangeBasedItemLevelRestoreCriteria","minMatchingValue":"second/a","maxMatchingValue":"second/z"},
  {"objectType":"RangeBasedItemLevelRestoreCriteria","minMatchingValue":"first/b","maxMatchingValue":"first/y"}
]
'@
        }
    }

    Context 'Elastic SAN existing selector snapshots' {
        It 'preserves the one-volume generic selector without Cosmos slash validation' {
            $wire = ConvertTo-TestRestoreWireObject (New-TestRestoreRequest -Workload ElasticSAN)
            Assert-TestRestoreSnapshot $wire.restoreTargetInfo.restoreCriteria[0] @'
{"objectType":"GenericRestoreDatasourceCriteria","resourceSelectors":{"objectType":"ResourceListSelectionCriteria","resourceIdentifiers":["source-volume"]}}
'@
            $wire.restoreTargetInfo.datasourceSetInfo.resourceID | Should -BeExactly "$resourceGroupId/providers/Microsoft.ElasticSan/elasticSans/target-san"
        }

        It 'preserves the eSAN rename map in generated wire JSON' {
            $configuration = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @('source-volume') -ResourceNameOverride @{ 'source-volume' = 'renamed-volume' }
            Assert-TestRestoreSnapshot (ConvertTo-TestRestoreWireObject $configuration) @'
{"objectType":"GenericRestoreDatasourceCriteria","resourceSelectors":{"objectType":"ResourceListSelectionCriteria","resourceIdentifiers":["source-volume"],"resourceNameOverrides":{"source-volume":"renamed-volume"}}}
'@
        }

        It 'retains eSAN multiple-volume rejection' {
            { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @('one', 'two') -ErrorAction Stop } | Should -Throw
        }
    }

    Context 'Shared initializer explicit identity contract' {
        $identityWorkloads = @('CosmosILR', 'CosmosFull', 'Blob', 'AKS', 'ElasticSAN') | ForEach-Object { @{ Workload = $_ } }

        It '<Workload> omits identityDetails when identity parameters are unbound' -TestCases $identityWorkloads {
            param($Workload)
            $wire = ConvertTo-TestRestoreWireObject (New-TestRestoreRequest -Workload $Workload)
            @($wire.PSObject.Properties.Name) -contains 'identityDetails' | Should -Be $false
        }

        It '<Workload> sets flattened SAMI fields and serializes explicit true' -TestCases $identityWorkloads {
            param($Workload)
            $request = New-TestRestoreRequest -Workload $Workload -Identity @{ UseSystemAssignedIdentity = $true }
            $request.IdentityDetailUseSystemAssignedIdentity | Should -Be $true
            $wire = ConvertTo-TestRestoreWireObject $request
            Assert-TestRestoreSnapshot $wire.identityDetails '{"useSystemAssignedIdentity":true}'
        }

        It '<Workload> sets flattened UAMI fields and serializes explicit false with its ARM URL' -TestCases $identityWorkloads {
            param($Workload)
            $uamiId = Get-TestRestoreUamiId
            $request = New-TestRestoreRequest -Workload $Workload -Identity @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = $uamiId }
            $request.IdentityDetailUseSystemAssignedIdentity | Should -Be $false
            $request.IdentityDetailUserAssignedIdentityArmUrl | Should -BeExactly $uamiId
            $wire = ConvertTo-TestRestoreWireObject $request
            Assert-TestRestoreSnapshot $wire.identityDetails "{`"useSystemAssignedIdentity`":false,`"userAssignedIdentityArmUrl`":`"$uamiId`"}"
        }

        $invalidIdentityCases = foreach ($workload in @('CosmosILR', 'CosmosFull', 'Blob', 'AKS', 'ElasticSAN')) {
            $kinds = @('TrueAndUami', 'TrueAndEmptyUami', 'TrueAndNullUami', 'UamiOnly', 'EmptyUamiOnly', 'NullUamiOnly')
            if ($workload -in @('CosmosILR', 'CosmosFull')) {
                $kinds += @('FalseOnly', 'FalseNull', 'FalseEmpty', 'FalseWhitespace', 'FalseInvalidId', 'FalseWrongProvider', 'FalseChildId', 'FalseQuery', 'FalseFragment', 'NullOnly', 'NullWithUami')
            }
            foreach ($kind in $kinds) {
                @{ Workload = $workload; Kind = $kind }
            }
        }
        It '<Workload> rejects invalid explicit identity combination <Kind>' -TestCases $invalidIdentityCases {
            param($Workload, $Kind)
            $uamiId = Get-TestRestoreUamiId
            $identity = switch ($Kind) {
                'FalseOnly' { @{ UseSystemAssignedIdentity = $false } }
                'FalseNull' { @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = $null } }
                'FalseEmpty' { @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = '' } }
                'FalseWhitespace' { @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = '  ' } }
                'FalseInvalidId' { @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = 'identity-name' } }
                'FalseWrongProvider' { @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = $cosmosAccountId } }
                'FalseChildId' { @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = "$uamiId/child" } }
                'FalseQuery' { @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = "${uamiId}?query=1" } }
                'FalseFragment' { @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = "${uamiId}#fragment" } }
                'NullOnly' { @{ UseSystemAssignedIdentity = $null } }
                'NullWithUami' { @{ UseSystemAssignedIdentity = $null; UserAssignedIdentityArmId = $uamiId } }
                'TrueAndUami' { @{ UseSystemAssignedIdentity = $true; UserAssignedIdentityArmId = $uamiId } }
                'TrueAndEmptyUami' { @{ UseSystemAssignedIdentity = $true; UserAssignedIdentityArmId = '' } }
                'TrueAndNullUami' { @{ UseSystemAssignedIdentity = $true; UserAssignedIdentityArmId = $null } }
                'UamiOnly' { @{ UserAssignedIdentityArmId = $uamiId } }
                'EmptyUamiOnly' { @{ UserAssignedIdentityArmId = '' } }
                'NullUamiOnly' { @{ UserAssignedIdentityArmId = $null } }
            }
            { New-TestRestoreRequest -Workload $Workload -Identity $identity } | Should -Throw
        }

        $legacyIdentityCases = foreach ($workload in @('Blob', 'AKS', 'ElasticSAN')) {
            foreach ($kind in @('FalseOnly', 'FalseNull', 'FalseEmpty', 'FalseWhitespace', 'FalseInvalidId', 'FalseWrongProvider', 'NullOnly', 'NullWithUami')) {
                @{ Workload = $workload; Kind = $kind }
            }
        }
        It '<Workload> preserves legacy false identity serialization for <Kind>' -TestCases $legacyIdentityCases {
            param($Workload, $Kind)
            $identity = @{ UseSystemAssignedIdentity = $false }
            switch ($Kind) {
                'FalseNull' { $identity.UserAssignedIdentityArmId = $null }
                'FalseEmpty' { $identity.UserAssignedIdentityArmId = '' }
                'FalseWhitespace' { $identity.UserAssignedIdentityArmId = '  ' }
                'FalseInvalidId' { $identity.UserAssignedIdentityArmId = 'identity-name' }
                'FalseWrongProvider' { $identity.UserAssignedIdentityArmId = $cosmosAccountId }
                'NullOnly' { $identity.UseSystemAssignedIdentity = $null }
                'NullWithUami' { $identity.UseSystemAssignedIdentity = $null; $identity.UserAssignedIdentityArmId = Get-TestRestoreUamiId }
            }
            $request = New-TestRestoreRequest -Workload $Workload -Identity $identity
            $request.IdentityDetailUseSystemAssignedIdentity | Should -Be $false
            $wire = ConvertTo-TestRestoreWireObject $request
            $expected = [ordered]@{ useSystemAssignedIdentity = $false }
            # Bound null becomes an empty string at the public string parameter.
            # Generated JsonString serialization retains empty/whitespace values;
            # only an unbound UAMI leaves the wire property absent.
            if ($identity.ContainsKey('UserAssignedIdentityArmId')) {
                $expectedId = [string]$identity.UserAssignedIdentityArmId
                $request.IdentityDetailUserAssignedIdentityArmUrl | Should -BeExactly $expectedId
                $expected.userAssignedIdentityArmUrl = $expectedId
            }
            Assert-TestRestoreSnapshot $wire.identityDetails (ConvertTo-Json -InputObject $expected -Compress)
        }
    }

    Context 'Non-Cosmos restore configuration array construction regression' {
        It '<Workload> singleton array matches the scalar request with ItemLevelRecovery=<ItemLevelRecovery>' -TestCases @(
            @{ Workload = 'AKS'; ItemLevelRecovery = $false }
            @{ Workload = 'AKS'; ItemLevelRecovery = $true }
            @{ Workload = 'ElasticSAN'; ItemLevelRecovery = $false }
            @{ Workload = 'ElasticSAN'; ItemLevelRecovery = $true }
        ) {
            param($Workload, $ItemLevelRecovery)
            # Keep configuration construction outside typed helper arguments:
            # the public RestoreConfiguration parameter intentionally is PSObject.
            $parameters = @{
                SourceDataStore = 'VaultStore'; RestoreLocation = 'eastus'
                RestoreType = 'AlternateLocation'; RecoveryPoint = 'unit-test-recovery-point'
                ErrorAction = 'Stop'
            }
            if ($Workload -eq 'AKS') {
                $parameters.DatasourceType = 'AzureKubernetesService'
                $parameters.TargetResourceId = $aksId
                $config = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService -IncludedNamespace @('first') -ErrorAction Stop
            } else {
                $parameters.DatasourceType = 'AzureElasticSAN'
                $parameters.SourceDataStore = 'OperationalStore'
                $parameters.TargetResourceId = $sanId
                $config = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureElasticSAN -ResourceIdentifier @('source-volume') -ErrorAction Stop
            }
            if ($ItemLevelRecovery) { $parameters.ItemLevelRecovery = $true }
            $configBefore = ConvertTo-TestRestoreWireObject $config | ConvertTo-Json -Depth 100
            $parameters.RestoreConfiguration = $config
            $scalarRequest = Initialize-AzDataProtectionRestoreRequest @parameters
            $expectedJson = ConvertTo-TestRestoreWireObject $scalarRequest | ConvertTo-Json -Depth 100

            $configs = @($config)
            $parameters.RestoreConfiguration = $configs
            $arrayRequest = Initialize-AzDataProtectionRestoreRequest @parameters
            $wire = ConvertTo-TestRestoreWireObject $arrayRequest
            @($scalarRequest.RestoreTargetInfo.RestoreCriterion).Count | Should -Be 1
            @($arrayRequest.RestoreTargetInfo.RestoreCriterion).Count | Should -Be 1
            @($wire.restoreTargetInfo.restoreCriteria).Count | Should -Be 1
            Assert-TestRestoreSnapshot $wire $expectedJson
            $configs.Count | Should -Be 1
            [object]::ReferenceEquals($configs[0], $config) | Should -Be $true
            Assert-TestRestoreSnapshot (ConvertTo-TestRestoreWireObject $config) $configBefore
        }

        It 'AKS two-element array preserves ordered criteria with ItemLevelRecovery=<ItemLevelRecovery>' -TestCases @(
            @{ ItemLevelRecovery = $false }
            @{ ItemLevelRecovery = $true }
        ) {
            param($ItemLevelRecovery)
            # This asserts local request construction only, not service acceptance
            # of two criteria. Elastic SAN remains restricted to one source volume.
            $first = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService -IncludedNamespace @('first') -ErrorAction Stop
            $second = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureKubernetesService -IncludedNamespace @('second') -ErrorAction Stop
            $firstBefore = ConvertTo-TestRestoreWireObject $first | ConvertTo-Json -Depth 100
            $secondBefore = ConvertTo-TestRestoreWireObject $second | ConvertTo-Json -Depth 100
            $parameters = @{
                DatasourceType = 'AzureKubernetesService'; TargetResourceId = $aksId
                SourceDataStore = 'VaultStore'; RestoreLocation = 'eastus'
                RestoreType = 'AlternateLocation'; RecoveryPoint = 'unit-test-recovery-point'
                RestoreConfiguration = $first; ErrorAction = 'Stop'
            }
            if ($ItemLevelRecovery) { $parameters.ItemLevelRecovery = $true }
            $scalarRequest = Initialize-AzDataProtectionRestoreRequest @parameters
            $expected = ConvertTo-TestRestoreWireObject $scalarRequest
            @($expected.restoreTargetInfo.restoreCriteria).Count | Should -Be 1
            $expected.restoreTargetInfo.restoreCriteria = @(
                ConvertTo-TestRestoreWireObject $first
                ConvertTo-TestRestoreWireObject $second
            )

            $configs = @($first, $second)
            $parameters.RestoreConfiguration = $configs
            $arrayRequest = Initialize-AzDataProtectionRestoreRequest @parameters
            $wire = ConvertTo-TestRestoreWireObject $arrayRequest
            @($arrayRequest.RestoreTargetInfo.RestoreCriterion).Count | Should -Be 2
            @($wire.restoreTargetInfo.restoreCriteria).Count | Should -Be 2
            Assert-TestRestoreSnapshot $wire (ConvertTo-Json -InputObject $expected -Depth 100)
            $configs.Count | Should -Be 2
            [object]::ReferenceEquals($configs[0], $first) | Should -Be $true
            [object]::ReferenceEquals($configs[1], $second) | Should -Be $true
            Assert-TestRestoreSnapshot (ConvertTo-TestRestoreWireObject $first) $firstBefore
            Assert-TestRestoreSnapshot (ConvertTo-TestRestoreWireObject $second) $secondBefore
        }
    }
}