# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

# Pester 4.10.1, offline only. Select this file with Invoke-Pester in a fresh
# process after importing the built artifact. Do not dot-source custom
# functions or load loadEnv/HttpPipelineMocking: recording playback matches URLs,
# not request bodies. These tests exercise the artifact's exported public commands,
# native internal cmdlets and generated HTTP serializer, not a hand-made ToJson call.
. (Join-Path $PSScriptRoot 'CosmosRestoreTestHelpers.ps1')
Describe 'CosmosRestoreTransport' -Tag 'Unit', 'CosmosRestore' {
    BeforeAll {
        if ((Get-Module Pester).Version -ne [version]'4.10.1') {
            throw 'CosmosRestoreTransport requires Pester 4.10.1.'
        }
        $paths = Get-CosmosRestoreTestPaths -TestRoot $PSScriptRoot
        $repoRoot = $paths.RepoRoot
        $artifactRoot = $paths.ArtifactRoot
        $artifactManifest = Join-Path $artifactRoot 'Az.DataProtection.psd1'
        $module = Get-Module Az.DataProtection
        if ($null -eq $module) {
            Import-Module $artifactManifest -ErrorAction Stop
            $module = Get-Module Az.DataProtection
        }
        if ([IO.Path]::GetFullPath($module.Path) -ne [IO.Path]::GetFullPath((Join-Path $artifactRoot 'Az.DataProtection.psm1'))) {
            throw 'Import the local artifact module in a fresh process, not the source or installed Az.DataProtection module.'
        }
        $modelType = 'Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.GenericRestoreDatasourceCriteria' -as [type]
        if ($null -eq $modelType -or $modelType.Assembly.Location -ne (Join-Path $artifactRoot 'bin/Az.DataProtection.private.dll')) {
            throw 'The local artifact must contain the tracked, unversioned Cosmos restore models.'
        }

        # A pure CLR delegate needs no PowerShell runspace on HTTP continuation
        # threads. Object parameters bind contravariantly to IEventListener and
        # ISendAsync; no production assembly/types are added or modified. Never
        # invoke next, even for an unexpected URI, method, or polling request.
        if (-not ('CosmosRestoreTransportTests.LocalTransport' -as [type])) {
            $typeDefinition = @'
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
namespace CosmosRestoreTransportTests {
    public sealed class CapturedRequest {
        public string Method;
        public string Uri;
        public string ContentType;
        public string Body;
    }
    public sealed class LocalTransport {
        public readonly List<CapturedRequest> Requests = new List<CapturedRequest>();
        public string ExpectedUri;
        public bool RejectAll;
        public Task<HttpResponseMessage> Send(HttpRequestMessage request, object listener, object next) {
            var captured = new CapturedRequest {
                Method = request.Method.Method,
                Uri = request.RequestUri.AbsoluteUri,
                ContentType = request.Content == null ? null : request.Content.Headers.ContentType.MediaType,
                Body = request.Content == null ? null : request.Content.ReadAsStringAsync().GetAwaiter().GetResult()
            };
            lock (Requests) {
                Requests.Add(captured);
                if (RejectAll || Requests.Count != 1 || captured.Method != "POST" || captured.Uri != ExpectedUri) {
                    throw new InvalidOperationException("Offline transport rejected an unexpected request; no network fallback.");
                }
            }
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.RequestMessage = request;
            response.Content = new StringContent(
                "{\"objectType\":\"OperationJobExtendedInfo\",\"jobId\":\"offline-restore-job\"}",
                Encoding.UTF8, "application/json");
            return Task.FromResult(response);
        }
    }
}
'@
            if ($PSVersionTable.PSEdition -eq 'Core') {
                Add-Type -TypeDefinition $typeDefinition -ErrorAction Stop
            } else {
                Add-Type -TypeDefinition $typeDefinition -ReferencedAssemblies 'System.Net.Http', 'System.Core' -ErrorAction Stop
            }
        }

        $subscription = '00000000-0000-0000-0000-000000000001'
        $targetId = "/subscriptions/$subscription/resourceGroups/restore-tests/providers/Microsoft.DocumentDB/databaseAccounts/target-account"
        $baseUri = "https://management.azure.com/subscriptions/$subscription/resourceGroups/restore-tests/providers/Microsoft.DataProtection/backupVaults/test-vault/backupInstances/test-instance"
        $script:cosmosTransportArguments = @{ SubscriptionId = $subscription; ResourceGroupName = 'restore-tests'; VaultName = 'test-vault'; ErrorAction = 'Stop'; Confirm = $false }
        $script:cosmosTransportOriginalPlayback = $env:AzPSAutorestTestPlaybackMode
        $env:AzPSAutorestTestPlaybackMode = 'true'
        # Preserve unrelated fixture defaults; explicitly supply our own pipeline
        # on every transport call, so recording/live defaults cannot take over.
        $script:cosmosTransportOriginalDefaults = $PSDefaultParameterValues
        $PSDefaultParameterValues = @{}

        function New-CosmosTransportRequest {
            param([string[]] $Selectors, [string] $Identity = 'None')
            $parameters = @{
                DatasourceType = 'AzureCosmosDB'; SourceDataStore = 'VaultStore'
                RestoreLocation = 'eastus'; RestoreType = 'AlternateLocation'
                RecoveryPoint = 'offline-recovery-point'; TargetResourceId = $targetId
                ErrorAction = 'Stop'
            }
            if ($Selectors.Count -gt 0) {
                $configuration = @(Az.DataProtection\New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier $Selectors -ErrorAction Stop)
                $configuration.Count | Should -Be 1
                ($configuration[0] -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericRestoreDatasourceCriteria]) | Should -Be $true
                $parameters.ItemLevelRecovery = $true
                $parameters.RestoreConfiguration = $configuration[0]
            }
            if ($Identity -eq 'SAMI') { $parameters.UseSystemAssignedIdentity = $true }
            if ($Identity -eq 'UAMI') {
                $parameters.UseSystemAssignedIdentity = $false
                $parameters.UserAssignedIdentityArmId = "/subscriptions/$subscription/resourceGroups/restore-tests/providers/Microsoft.ManagedIdentity/userAssignedIdentities/restore-identity"
            }
            $request = @(Az.DataProtection\Initialize-AzDataProtectionRestoreRequest @parameters)
            $request.Count | Should -Be 1
            ($request[0] -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IAzureBackupRestoreRequest]) | Should -Be $true
            $request[0]
        }

        function New-CosmosLocalTransport {
            param([string] $Operation, [switch] $RejectAll)
            $transport = New-Object CosmosRestoreTransportTests.LocalTransport
            $transport.ExpectedUri = "$baseUri/${Operation}?api-version=2026-06-01"
            $transport.RejectAll = $RejectAll.IsPresent
            $stepType = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SendAsyncStep]
            # The MethodInfo overload supports relaxed delegate binding; the
            # name-based overload requires exact interface parameter types.
            $step = [Delegate]::CreateDelegate($stepType, $transport, $transport.GetType().GetMethod('Send'))
            @{ Transport = $transport; Step = $step }
        }

        function Assert-CosmosTransportRequest {
            param($Wire, [string[]] $Selectors, [string] $Identity = 'None')
            # Exact keys at every selection/envelope level detect double wrapping,
            # singular selectors, accidental Blob routing and extra empty objects.
            $keys = @('objectType', 'recoveryPointId', 'restoreTargetInfo', 'sourceDataStoreType')
            if ($Identity -ne 'None') { $keys += 'identityDetails' }
            ($Wire.PSObject.Properties.Name | Sort-Object) -join '|' | Should -BeExactly (($keys | Sort-Object) -join '|')
            $Wire.objectType | Should -BeExactly 'AzureBackupRecoveryPointBasedRestoreRequest'
            $Wire.recoveryPointId | Should -BeExactly 'offline-recovery-point'
            $Wire.sourceDataStoreType | Should -BeExactly 'VaultStore'
            $targetKeys = @('datasourceInfo', 'objectType', 'recoveryOption', 'restoreLocation')
            if ($Selectors.Count -gt 0) { $targetKeys += 'restoreCriteria' }
            ($Wire.restoreTargetInfo.PSObject.Properties.Name | Sort-Object) -join '|' | Should -BeExactly (($targetKeys | Sort-Object) -join '|')
            $Wire.restoreTargetInfo.recoveryOption | Should -BeExactly 'FailIfExists'
            $Wire.restoreTargetInfo.restoreLocation | Should -BeExactly 'eastus'
            $datasource = $Wire.restoreTargetInfo.datasourceInfo
            ($datasource.PSObject.Properties.Name | Sort-Object) -join '|' | Should -BeExactly 'datasourceType|objectType|resourceID|resourceLocation|resourceName|resourceType|resourceUri'
            $datasource.objectType | Should -BeExactly 'Datasource'
            $datasource.datasourceType | Should -BeExactly 'Microsoft.DocumentDB/databaseAccounts'
            $datasource.resourceType | Should -BeExactly 'Microsoft.DocumentDB/databaseAccounts'
            $datasource.resourceID | Should -BeExactly $targetId
            $datasource.resourceUri | Should -BeExactly $targetId
            $datasource.resourceName | Should -BeExactly 'target-account'
            $datasource.resourceLocation | Should -BeExactly 'eastus'
            if ($Selectors.Count -gt 0) {
                $Wire.restoreTargetInfo.objectType | Should -BeExactly 'ItemLevelRestoreTargetInfo'
                ($Wire.restoreTargetInfo.restoreCriteria -is [array]) | Should -Be $true
                $Wire.restoreTargetInfo.restoreCriteria.Count | Should -Be 1
                $criterion = $Wire.restoreTargetInfo.restoreCriteria[0]
                ($criterion.PSObject.Properties.Name | Sort-Object) -join '|' | Should -BeExactly 'objectType|resourceSelectors'
                $criterion.objectType | Should -BeExactly 'GenericRestoreDatasourceCriteria'
                ($criterion.resourceSelectors.PSObject.Properties.Name | Sort-Object) -join '|' | Should -BeExactly 'objectType|resourceIdentifiers'
                $criterion.resourceSelectors.objectType | Should -BeExactly 'ResourceListSelectionCriteria'
                ($criterion.resourceSelectors.resourceIdentifiers -is [array]) | Should -Be $true
                $criterion.resourceSelectors.resourceIdentifiers.Count | Should -Be $Selectors.Count
                for ($i = 0; $i -lt $Selectors.Count; $i++) {
                    $criterion.resourceSelectors.resourceIdentifiers[$i] | Should -BeExactly $Selectors[$i]
                }
            } else {
                $Wire.restoreTargetInfo.objectType | Should -BeExactly 'RestoreTargetInfo'
            }
            if ($Identity -eq 'SAMI') {
                ($Wire.identityDetails.PSObject.Properties.Name | Sort-Object) -join '|' | Should -BeExactly 'useSystemAssignedIdentity'
                $Wire.identityDetails.useSystemAssignedIdentity | Should -Be $true
            }
            if ($Identity -eq 'UAMI') {
                ($Wire.identityDetails.PSObject.Properties.Name | Sort-Object) -join '|' | Should -BeExactly ((@('useSystemAssignedIdentity', 'userAssignedIdentityArmUrl') | Sort-Object) -join '|')
                $Wire.identityDetails.useSystemAssignedIdentity | Should -Be $false
                $Wire.identityDetails.userAssignedIdentityArmUrl | Should -BeExactly "/subscriptions/$subscription/resourceGroups/restore-tests/providers/Microsoft.ManagedIdentity/userAssignedIdentities/restore-identity"
            }
        }
    }

    BeforeEach {
        # This wrapper's login check does not consult the playback environment
        # flag for arbitrary SendAsyncStep delegates (only PipelineMock.Playback).
        # Mock in its actual scope, not globally or in Az.DataProtection.custom.
        Mock Get-AzContext -ModuleName Az.DataProtection {
            [pscustomobject]@{
                Subscription = [pscustomobject]@{ Id = '00000000-0000-0000-0000-000000000001' }
                Tenant = [pscustomobject]@{ Id = '00000000-0000-0000-0000-000000000002' }
                Account = [pscustomobject]@{ Id = 'offline@example.invalid'; Type = 'User' }
            }
        }
    }

    AfterAll {
        $env:AzPSAutorestTestPlaybackMode = $script:cosmosTransportOriginalPlayback
        $PSDefaultParameterValues = $script:cosmosTransportOriginalDefaults
    }

    Context 'Existing public surface from the local artifact' {
        It 'resolves identical checkout, canonical source and artifact paths from either test layout' {
            $sourcePaths = Get-CosmosRestoreTestPaths -TestRoot (Join-Path $paths.SourceRoot 'test')
            $artifactPaths = Get-CosmosRestoreTestPaths -TestRoot (Join-Path $artifactRoot 'test')
            foreach ($property in @('RepoRoot', 'SourceRoot', 'GeneratedRoot', 'ArtifactRoot')) {
                $sourcePaths.$property | Should -BeExactly $artifactPaths.$property
            }
            $sourcePaths.SourceRoot | Should -BeExactly (Join-Path $repoRoot 'src/DataProtection/DataProtection.Autorest')
            $sourcePaths.GeneratedRoot | Should -BeExactly (Join-Path $repoRoot 'generated/DataProtection/DataProtection.Autorest')
            $sourcePaths.SourceRoot | Should -Not -Be $artifactRoot
            { Get-CosmosRestoreTestPaths -TestRoot ([IO.Path]::GetPathRoot($repoRoot)) } | Should -Throw 'Cannot find'
        }

        It 'exports only the existing manifest command surface, with no Cosmos-specific public command' {
            $sourceManifest = Join-Path $paths.GeneratedRoot 'Az.DataProtection.psd1'
            $expected = Import-PowerShellDataFile $sourceManifest
            $exported = @((Get-Module Az.DataProtection).ExportedCommands.Keys | Sort-Object)
            $exported.Count | Should -BeGreaterThan 0
            @(Compare-Object ($expected.FunctionsToExport | Sort-Object) $exported).Count | Should -Be 0
            @($exported | Where-Object { $_ -match 'Cosmos|TransportTests|New-Cosmos|Assert-Cosmos' }).Count | Should -Be 0
            foreach ($name in @('New-AzDataProtectionRestoreConfigurationClientObject', 'Initialize-AzDataProtectionRestoreRequest', 'Test-AzDataProtectionBackupInstanceRestore', 'Start-AzDataProtectionBackupInstanceRestore')) {
                $command = Get-Command "Az.DataProtection\$name" -ErrorAction Stop
                $command.ModuleName | Should -BeExactly 'Az.DataProtection'
                $command.Module.ModuleBase | Should -BeExactly $artifactRoot
            }
        }
    }

    Context 'Actual generated HTTP bodies via public commands (no internal dispatch mocks)' {
        $cases = @(
            @{ Scenario = 'full'; Selectors = @(); Identity = 'None' }
            @{ Scenario = 'single container'; Selectors = @('DB1/col1'); Identity = 'None' }
            @{ Scenario = 'database'; Selectors = @('db2'); Identity = 'None' }
            @{ Scenario = 'mixed ordered selectors'; Selectors = @('DB1/col1', 'Db1/col2', 'db2'); Identity = 'None' }
            @{ Scenario = 'mixed SAMI'; Selectors = @('DB1/col1', 'Db1/col2', 'db2'); Identity = 'SAMI' }
            @{ Scenario = 'mixed UAMI'; Selectors = @('DB1/col1', 'Db1/col2', 'db2'); Identity = 'UAMI' }
        )
        It 'validation wraps <Scenario> exactly once at the canonical 2026-06-01 endpoint' -TestCases $cases {
            param($Scenario, $Selectors, $Identity)
            $request = New-CosmosTransportRequest -Selectors $Selectors -Identity $Identity
            $fixture = New-CosmosLocalTransport -Operation 'validateRestore'
            $output = @(Az.DataProtection\Test-AzDataProtectionBackupInstanceRestore @script:cosmosTransportArguments -Name 'test-instance' -RestoreRequest $request -HttpPipelinePrepend $fixture.Step)
            $fixture.Transport.Requests.Count | Should -Be 1
            $capture = $fixture.Transport.Requests[0]
            $capture.Method | Should -BeExactly 'POST'
            $capture.Uri | Should -BeExactly "$baseUri/validateRestore?api-version=2026-06-01"
            $capture.ContentType | Should -BeExactly 'application/json'
            $body = $capture.Body | ConvertFrom-Json
            @($body.PSObject.Properties.Name).Count | Should -Be 1
            $body.PSObject.Properties.Name | Should -BeExactly 'restoreRequestObject'
            Assert-CosmosTransportRequest -Wire $body.restoreRequestObject -Selectors $Selectors -Identity $Identity
            $output.Count | Should -Be 1
            ($output[0] -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IOperationJobExtendedInfo]) | Should -Be $true
            $output[0].JobId | Should -BeExactly 'offline-restore-job'
            Assert-MockCalled Get-AzContext -ModuleName Az.DataProtection -Times 1 -Exactly -Scope It
        }

        It 'trigger sends raw <Scenario> through typed -Parameter at the canonical 2026-06-01 endpoint' -TestCases $cases {
            param($Scenario, $Selectors, $Identity)
            $request = New-CosmosTransportRequest -Selectors $Selectors -Identity $Identity
            $fixture = New-CosmosLocalTransport -Operation 'restore'
            $output = @(Az.DataProtection\Start-AzDataProtectionBackupInstanceRestore @script:cosmosTransportArguments -BackupInstanceName 'test-instance' -Parameter $request -HttpPipelinePrepend $fixture.Step)
            $fixture.Transport.Requests.Count | Should -Be 1
            $capture = $fixture.Transport.Requests[0]
            $capture.Method | Should -BeExactly 'POST'
            $capture.Uri | Should -BeExactly "$baseUri/restore?api-version=2026-06-01"
            $capture.ContentType | Should -BeExactly 'application/json'
            Assert-CosmosTransportRequest -Wire ($capture.Body | ConvertFrom-Json) -Selectors $Selectors -Identity $Identity
            $output.Count | Should -Be 1
            ($output[0] -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IOperationJobExtendedInfo]) | Should -Be $true
            $output[0].JobId | Should -BeExactly 'offline-restore-job'
            # The artifact's public trigger is a direct custom export, unlike
            # validation's telemetry proxy. Explicit subscription needs no context.
            Assert-MockCalled Get-AzContext -ModuleName Az.DataProtection -Times 0 -Exactly -Scope It
        }
    }

    Context 'ShouldProcess is honored before any HTTP send' {
        It 'validation WhatIf emits no operation result and sends zero requests' {
            $request = New-CosmosTransportRequest -Selectors @('DB1/col1', 'Db1/col2', 'db2')
            $fixture = New-CosmosLocalTransport -Operation 'validateRestore' -RejectAll
            $output = @(Az.DataProtection\Test-AzDataProtectionBackupInstanceRestore @script:cosmosTransportArguments -Name 'test-instance' -RestoreRequest $request -HttpPipelinePrepend $fixture.Step -WhatIf)
            $fixture.Transport.Requests.Count | Should -Be 0
            $output.Count | Should -Be 0
        }

        It 'trigger WhatIf emits no operation result and sends zero requests' {
            $request = New-CosmosTransportRequest -Selectors @('DB1/col1', 'Db1/col2', 'db2')
            $fixture = New-CosmosLocalTransport -Operation 'restore' -RejectAll
            $output = @(Az.DataProtection\Start-AzDataProtectionBackupInstanceRestore @script:cosmosTransportArguments -BackupInstanceName 'test-instance' -Parameter $request -HttpPipelinePrepend $fixture.Step -WhatIf)
            $fixture.Transport.Requests.Count | Should -Be 0
            $output.Count | Should -Be 0
        }
    }
}