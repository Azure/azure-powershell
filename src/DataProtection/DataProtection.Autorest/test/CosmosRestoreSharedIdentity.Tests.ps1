# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

# Pester 4.10.1, offline only. Exercise the artifact's exported initializer and
# native internal model proxy. Do not dot-source a replacement initializer, load
# recordings, obtain a context, or call Azure. Run in a fresh process through the
# unit-test runner after the main workflow builds/copies the current source.
Describe 'CosmosRestoreSharedIdentity' -Tag 'Unit', 'CosmosRestore' {
    BeforeAll {
        if ((Get-Module Pester).Version -ne [version]'4.10.1') {
            throw 'CosmosRestoreSharedIdentity requires Pester 4.10.1.'
        }
        $sourceRoot = Split-Path -Parent $PSScriptRoot
        $repoRoot = Split-Path -Parent (Split-Path -Parent (Split-Path -Parent $sourceRoot))
        $artifactRoot = Join-Path $repoRoot 'artifacts/Debug/Az.DataProtection/DataProtection.Autorest'
        $module = Get-Module Az.DataProtection
        if ($null -eq $module -or [IO.Path]::GetFullPath($module.Path) -ne [IO.Path]::GetFullPath((Join-Path $artifactRoot 'Az.DataProtection.psm1'))) {
            throw 'Import the locally built Az.DataProtection artifact in a fresh process before running these tests.'
        }
        $modelType = 'Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.AzureBackupRecoveryPointBasedRestoreRequest' -as [type]
        if ($null -eq $modelType -or [IO.Path]::GetFullPath($modelType.Assembly.Location) -ne [IO.Path]::GetFullPath((Join-Path $artifactRoot 'bin/Az.DataProtection.private.dll'))) {
            throw 'Tests require the tracked, unversioned artifact models, not Api20260301 models.'
        }
        $command = Get-Command 'Az.DataProtection\Initialize-AzDataProtectionRestoreRequest' -ErrorAction Stop
        if ($command.ModuleName -ne 'Az.DataProtection') {
            throw 'The native exported initializer must resolve through Az.DataProtection.'
        }

        # Reject stale source copies; never silently replace the public export
        # with a test-scope function or modify artifacts from inside this suite.
        $freshPaths = @(
            'custom/manifests/ManifestLoader.ps1'
            'custom/Helpers/CommonHelpers.ps1'
            'custom/Helpers/RestoreHelpers.ps1'
            'custom/Cmdlets/Platform/Restore/Initialize-AzDataProtectionRestoreRequest.ps1'
        )
        foreach ($workload in @('AzureDisk', 'AzureDatabaseForPostgreSQL', 'AzureDatabaseForPGFlexServer', 'AzureDatabaseForMySQL', 'AzureDataLakeStorage')) {
            $freshPaths += "custom/manifests/$workload.json"
        }
        foreach ($relativePath in $freshPaths) {
            $sourceText = Get-Content -LiteralPath (Join-Path $sourceRoot $relativePath) -Raw -ErrorAction Stop
            $artifactText = Get-Content -LiteralPath (Join-Path $artifactRoot $relativePath) -Raw -ErrorAction Stop
            if ($sourceText -cne $artifactText) {
                throw "Stale artifact source copy: $relativePath. Refresh it in the main workflow before running this suite."
            }
        }

        $resourceGroupId = '/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/shared-identity-tests'
        $uamiId = "$resourceGroupId/providers/Microsoft.ManagedIdentity/userAssignedIdentities/restore-identity"
        $containerUri = 'https://offlinefixture.blob.core.windows.net/restore-files'
        $containerId = "$resourceGroupId/providers/Microsoft.Storage/storageAccounts/offlinefixture/blobServices/default/containers/restore-files"
        $recoveryPoint = 'synthetic-recovery-point'
        $restoreLocation = 'eastus'

        function Get-SharedRestoreFixture([string] $Workload, [string] $RestoreType) {
            $manifest = Get-Content -LiteralPath (Join-Path $sourceRoot "custom/manifests/$Workload.json") -Raw | ConvertFrom-Json
            # Assert the intended supported branch instead of skipping cases or
            # treating rejection of an unsupported mode as a feature regression.
            @($manifest.allowedRestoreModes) -contains 'RecoveryPointBased' | Should -Be $true
            @($manifest.allowedRestoreTargetTypes) -contains $RestoreType | Should -Be $true
            switch ($Workload) {
                'AzureDisk' { $id = "$resourceGroupId/providers/Microsoft.Compute/disks/target-disk" }
                'AzureDatabaseForPostgreSQL' { $id = "$resourceGroupId/providers/Microsoft.DBforPostgreSQL/servers/target-server/databases/target-database" }
                'AzureDatabaseForPGFlexServer' { $id = "$resourceGroupId/providers/Microsoft.DBforPostgreSQL/flexibleServers/target-pgflex" }
                'AzureDatabaseForMySQL' { $id = "$resourceGroupId/providers/Microsoft.DBforMySQL/flexibleServers/target-mysql" }
                'AzureDataLakeStorage' { $id = "$resourceGroupId/providers/Microsoft.Storage/storageAccounts/targetadls" }
                default { throw "Unknown fixture workload: $Workload" }
            }
            return @{ Manifest = $manifest; ResourceId = $id }
        }

        function New-SharedRestoreParameters([string] $Workload, [string] $RestoreType, [hashtable] $Identity) {
            $fixture = Get-SharedRestoreFixture $Workload $RestoreType
            $parameters = @{
                DatasourceType = $Workload; RestoreType = $RestoreType
                RecoveryPoint = $recoveryPoint; RestoreLocation = $restoreLocation
                SourceDataStore = [string]$fixture.Manifest.policySettings.supportedDatastoreTypes[0]
                ErrorAction = 'Stop'
            }
            if ($RestoreType -eq 'RestoreAsFiles') {
                $parameters.TargetContainerURI = $containerUri
                $parameters.TargetResourceIdForRestoreAsFile = $containerId
                if (-not $fixture.Manifest.fileNamePrefixDisabled) {
                    $parameters.FileNamePrefix = 'offline-restore'
                }
            } else {
                $parameters.TargetResourceId = $fixture.ResourceId
            }
            # PostgreSQL secret-store authentication is optional and constructed
            # only when SecretStoreURI is bound. Do not bind either secret field.
            foreach ($key in $Identity.Keys) { $parameters[$key] = $Identity[$key] }
            return $parameters
        }

        function Get-SharedRestoreIdentity([string] $Selection) {
            switch ($Selection) {
                'Unbound' { return @{} }
                'SAMI' { return @{ UseSystemAssignedIdentity = $true } }
                'UAMI' { return @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = $uamiId } }
                'FalseOnly' { return @{ UseSystemAssignedIdentity = $false } }
                default { throw "Unknown identity selection: $Selection" }
            }
        }

        function ConvertTo-SharedRestoreWire($Request) {
            return ($Request.ToJson($null, [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode]::IncludeCreateOrUpdate).ToString() | ConvertFrom-Json)
        }

        function ConvertTo-SharedRestoreCanonical($Value) {
            if ($null -eq $Value) { return $null }
            if ($Value -is [System.Collections.IDictionary]) {
                $result = [ordered]@{}
                foreach ($key in @($Value.Keys | Sort-Object)) { $result[$key] = ConvertTo-SharedRestoreCanonical $Value[$key] }
                return $result
            }
            if ($Value -is [pscustomobject]) {
                $result = [ordered]@{}
                foreach ($property in @($Value.PSObject.Properties | Sort-Object Name)) { $result[$property.Name] = ConvertTo-SharedRestoreCanonical $property.Value }
                return $result
            }
            if ($Value -is [System.Collections.IEnumerable] -and $Value -isnot [string]) {
                return ,@(foreach ($entry in $Value) { ConvertTo-SharedRestoreCanonical $entry })
            }
            return $Value
        }

        function Assert-SharedRestoreSnapshot($Actual, $Expected) {
            $actualJson = ConvertTo-Json -InputObject (ConvertTo-SharedRestoreCanonical @{ value = $Actual }) -Depth 100 -Compress
            $expectedJson = ConvertTo-Json -InputObject (ConvertTo-SharedRestoreCanonical @{ value = $Expected }) -Depth 100 -Compress
            $actualJson | Should -BeExactly $expectedJson
        }

        function Get-SharedRestoreExpectedTarget([string] $Workload, [string] $RestoreType, [string] $ResourceId) {
            $fixture = Get-SharedRestoreFixture $Workload $RestoreType
            $manifest = $fixture.Manifest
            $target = @{
                objectType = 'RestoreTargetInfo'; recoveryOption = 'FailIfExists'
                restoreLocation = $restoreLocation
            }
            if ($RestoreType -eq 'RestoreAsFiles') {
                $prefix = 'offline-restore'
                if ($manifest.fileNamePrefixDisabled) { $prefix = 'dummyprefix' }
                $target.objectType = 'RestoreFilesTargetInfo'
                $target.targetDetails = @{
                    filePrefix = $prefix; restoreTargetLocationType = 'AzureBlobs'
                    url = $containerUri; targetResourceArmId = $containerId
                }
                return $target
            }
            # Mirror the documented GetDatasourceInfo contract explicitly, NOT
            # by calling that helper as the oracle. ADLS datasourceType differs
            # from resourceType; PostgreSQL's proxy resourceUri is empty.
            $uri = ''
            if (-not $manifest.isProxyResource -or $manifest.enableDataSourceSetInfo) { $uri = $ResourceId }
            $target.datasourceInfo = @{
                objectType = 'Datasource'; datasourceType = [string]$manifest.datasourceType
                resourceID = $ResourceId; resourceName = $ResourceId.Split('/')[-1]
                resourceType = [string]$manifest.resourceType; resourceLocation = $restoreLocation
                resourceUri = $uri
            }
            if ($manifest.isProxyResource) {
                $set = @{
                    objectType = 'DatasourceSet'; datasourceType = [string]$manifest.datasourceType
                    resourceLocation = $restoreLocation
                }
                if ($manifest.enableDataSourceSetInfo) {
                    $set.resourceID = $ResourceId; $set.resourceName = $ResourceId.Split('/')[-1]
                    $set.resourceType = [string]$manifest.resourceType; $set.resourceUri = $uri
                } else {
                    $segments = $ResourceId.Split('/')
                    $set.resourceID = $segments[0..($segments.Count - 3)] -join '/'
                    $set.resourceName = $segments[$segments.Count - 3]
                    $typeSegments = $manifest.resourceType.Split('/')
                    $set.resourceType = $typeSegments[0..($typeSegments.Count - 2)] -join '/'
                    $set.resourceUri = ''
                }
                $target.datasourceSetInfo = $set
            }
            return $target
        }

        function Assert-SharedRestoreRequest($Request, [hashtable] $Parameters, [hashtable] $ExpectedTarget) {
            ($Request -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.AzureBackupRecoveryPointBasedRestoreRequest]) | Should -Be $true
            $expected = @{
                objectType = 'AzureBackupRecoveryPointBasedRestoreRequest'; recoveryPointId = $recoveryPoint
                sourceDataStoreType = $Parameters.SourceDataStore; restoreTargetInfo = $ExpectedTarget
            }
            if ($Parameters.ContainsKey('UseSystemAssignedIdentity')) {
                $expected.identityDetails = @{ useSystemAssignedIdentity = $Parameters.UseSystemAssignedIdentity }
                if ($Parameters.ContainsKey('UserAssignedIdentityArmId')) {
                    $expected.identityDetails.userAssignedIdentityArmUrl = $Parameters.UserAssignedIdentityArmId
                }
            }
            $wire = ConvertTo-SharedRestoreWire $Request
            Assert-SharedRestoreSnapshot $wire $expected
            # Verify that a stable generated roundtrip retains the full typed
            # request as well as its wire fields; never compare display output.
            $roundtrip = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.AzureBackupRecoveryPointBasedRestoreRequest]::FromJsonString($Request.ToJsonString())
            $roundtrip.RestoreTargetInfo.GetType().FullName | Should -BeExactly $Request.RestoreTargetInfo.GetType().FullName
            Assert-SharedRestoreSnapshot (ConvertTo-SharedRestoreWire $roundtrip) $expected
        }
    }

    Context 'Supported full restore modes preserve native target and identity serialization' {
        # Six supported modes, four meaningful identity contracts = 24 cases.
        # No OLR is enabled in any of these five workload manifests.
        $fullCases = foreach ($mode in @(
            @{ Workload = 'AzureDisk'; RestoreType = 'AlternateLocation' }
            @{ Workload = 'AzureDatabaseForPostgreSQL'; RestoreType = 'AlternateLocation' }
            @{ Workload = 'AzureDatabaseForPostgreSQL'; RestoreType = 'RestoreAsFiles' }
            @{ Workload = 'AzureDatabaseForPGFlexServer'; RestoreType = 'RestoreAsFiles' }
            @{ Workload = 'AzureDatabaseForMySQL'; RestoreType = 'RestoreAsFiles' }
            @{ Workload = 'AzureDataLakeStorage'; RestoreType = 'AlternateLocation' }
        )) {
            foreach ($selection in @('Unbound', 'SAMI', 'UAMI', 'FalseOnly')) {
                @{ Workload = $mode.Workload; RestoreType = $mode.RestoreType; Selection = $selection }
            }
        }
        It '<Workload> <RestoreType> retains the complete request with <Selection> identity' -TestCases $fullCases {
            param($Workload, $RestoreType, $Selection)
            $parameters = New-SharedRestoreParameters $Workload $RestoreType (Get-SharedRestoreIdentity $Selection)
            $output = @(Az.DataProtection\Initialize-AzDataProtectionRestoreRequest @parameters)
            $output.Count | Should -Be 1
            $expectedTarget = Get-SharedRestoreExpectedTarget $Workload $RestoreType $parameters.TargetResourceId
            Assert-SharedRestoreRequest $output[0] $parameters $expectedTarget
        }
    }

    Context 'ADLS supported ILR retains container-path criteria rather than Cosmos selectors' {
        It 'ADLS ALR ILR preserves ordered container paths with <Selection> identity' -TestCases @(
            @{ Selection = 'Unbound' }
            @{ Selection = 'SAMI' }
            @{ Selection = 'UAMI' }
        ) {
            param($Selection)
            $fixture = Get-SharedRestoreFixture 'AzureDataLakeStorage' 'AlternateLocation'
            $fixture.Manifest.itemLevelRecoveyEnabled | Should -Be $true
            $parameters = New-SharedRestoreParameters 'AzureDataLakeStorage' 'AlternateLocation' (Get-SharedRestoreIdentity $Selection)
            $parameters.ItemLevelRecovery = $true
            $parameters.ContainersList = @('filesystem-first', 'filesystem-second')
            $output = @(Az.DataProtection\Initialize-AzDataProtectionRestoreRequest @parameters)
            $output.Count | Should -Be 1
            $expectedTarget = Get-SharedRestoreExpectedTarget 'AzureDataLakeStorage' 'AlternateLocation' $parameters.TargetResourceId
            $expectedTarget.objectType = 'ItemLevelRestoreTargetInfo'
            $expectedTarget.restoreCriteria = @(
                @{ objectType = 'ItemPathBasedRestoreCriteria'; itemPath = 'filesystem-first'; isPathRelativeToBackupItem = $true }
                @{ objectType = 'ItemPathBasedRestoreCriteria'; itemPath = 'filesystem-second'; isPathRelativeToBackupItem = $true }
            )
            ($output[0].RestoreTargetInfo -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ItemLevelRestoreTargetInfo]) | Should -Be $true
            foreach ($criterion in $output[0].RestoreTargetInfo.RestoreCriterion) {
                ($criterion -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ItemPathBasedRestoreCriteria]) | Should -Be $true
            }
            Assert-SharedRestoreRequest $output[0] $parameters $expectedTarget
        }
    }

    Context 'Cosmos-only ID hardening does not change other workloads local-construction contract' {
        It '<Workload> preserves synthetic noncanonical target and identity references without Cosmos validation' -TestCases @(
            @{ Workload = 'AzureDisk' }
            @{ Workload = 'AzureDatabaseForPostgreSQL' }
            @{ Workload = 'AzureDataLakeStorage' }
        ) {
            param($Workload)
            # These are deliberately not service-valid IDs. The pre-existing
            # non-Cosmos initializer constructs local objects without enforcing
            # Cosmos account-ID or UAMI-ID validation. Never submit this request.
            $parameters = New-SharedRestoreParameters $Workload 'AlternateLocation' @{
                UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = 'synthetic-legacy-identity-reference'
            }
            $parameters.TargetResourceId += '?synthetic#legacy'
            $output = @(Az.DataProtection\Initialize-AzDataProtectionRestoreRequest @parameters)
            $output.Count | Should -Be 1
            $expectedTarget = Get-SharedRestoreExpectedTarget $Workload 'AlternateLocation' $parameters.TargetResourceId
            Assert-SharedRestoreRequest $output[0] $parameters $expectedTarget
        }
    }
}
