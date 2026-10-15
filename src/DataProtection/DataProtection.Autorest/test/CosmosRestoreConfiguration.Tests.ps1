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

# Pester 4.10.1. Import the newly built Az.DataProtection artifact first. Intentionally
# do not load loadEnv.ps1/HttpPipelineMocking.ps1: all operations here are local.
# Source the current scripts over the loaded real models so stale exported wrappers
# cannot hide a validation change. An old/versioned assembly must fail, not skip.
Describe 'CosmosRestoreConfiguration' -Tag 'Unit', 'CosmosRestore' {
    BeforeAll {
        if (-not ('Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.GenericRestoreDatasourceCriteria' -as [type])) {
            throw 'Import the current Az.DataProtection artifact with unversioned GenericRestoreDatasourceCriteria models before running these tests.'
        }
        $moduleRoot = Split-Path -Parent $PSScriptRoot
        . (Join-Path $moduleRoot 'custom/manifests/ManifestLoader.ps1')
        Get-ChildItem (Join-Path $moduleRoot 'custom/Helpers') -Filter '*.ps1' -Recurse -File | ForEach-Object { . $_.FullName }
        . (Join-Path $moduleRoot 'custom/Cmdlets/Platform/Restore/New-AzDataProtectionRestoreConfigurationClientObject.ps1')
        . (Join-Path $moduleRoot 'custom/Cmdlets/Platform/Restore/Initialize-AzDataProtectionRestoreRequest.ps1')

        $accountId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/restore-tests/providers/Microsoft.DocumentDB/databaseAccounts/target-account'
        $cosmosParameters = @{
            DatasourceType = 'AzureCosmosDB'
            SourceDataStore = 'VaultStore'
            RestoreLocation = 'eastus'
            RestoreType = 'AlternateLocation'
            TargetResourceId = $accountId
            RecoveryPoint = 'unit-test-recovery-point'
            ItemLevelRecovery = $true
            ErrorAction = 'Stop'
        }

        function New-TestCosmosConfiguration {
            New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @('DB1/col1', 'Db1/col2', 'db2') -ErrorAction Stop
        }

        function ConvertTo-TestCosmosWireObject($Model) {
            $Model.ToJson($null, [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode]::IncludeCreateOrUpdate).ToString() | ConvertFrom-Json
        }
    }

    # These tables deliberately include case-distinct parents/children. Ordinal,
    # not PowerShell's default case-insensitive comparison, defines overlap.
    $validSelectors = @(
        @{ Name = 'database only'; Identifiers = @('db1') }
        @{ Name = 'container only'; Identifiers = @('DB1/col1') }
        @{ Name = 'approved mixed selection'; Identifiers = @('DB1/col1', 'Db1/col2', 'db2') }
        @{ Name = 'case-distinct databases'; Identifiers = @('DB1', 'db1') }
        @{ Name = 'case-distinct containers'; Identifiers = @('db1/Col', 'db1/col') }
        @{ Name = 'case-distinct parent is not overlap'; Identifiers = @('DB1', 'db1/col') }
        @{ Name = 'case-distinct child then parent'; Identifiers = @('db1/col', 'DB1') }
        @{ Name = 'similar prefixes are not overlap'; Identifiers = @('db1', 'db10/col') }
        @{ Name = 'literal punctuation in database IDs'; Identifiers = @('db*name', 'db{name', 'db}name', 'db,name') }
        @{ Name = 'literal punctuation in container IDs'; Identifiers = @('db/col*name', 'db/col{name', 'db/col}name', 'db/col,name') }
        @{ Name = 'literal punctuation in mixed selectors'; Identifiers = @('db*{one},', 'db*{two},/col*{three},', 'plain/col}') }
        @{ Name = 'literal star does not match another database'; Identifiers = @('db*', 'db1/col') }
        @{ Name = 'literal star child does not match another parent'; Identifiers = @('db1/col', 'db*') }
        @{ Name = 'literal star containers remain distinct'; Identifiers = @('db/col*', 'db/col1') }
        @{ Name = 'fifty identifiers'; Identifiers = @(1..50 | ForEach-Object { 'db{0}/col' -f $_ }) }
    )
    $invalidSelectors = @(
        @{ Name = 'null list'; Identifiers = $null }
        @{ Name = 'empty list'; Identifiers = @() }
        @{ Name = 'null entry'; Identifiers = @($null) }
        @{ Name = 'empty entry'; Identifiers = @('') }
        @{ Name = 'whitespace entry'; Identifiers = @('   ') }
        @{ Name = 'whitespace database'; Identifiers = @(' /col') }
        @{ Name = 'whitespace container'; Identifiers = @('db/ ') }
        @{ Name = 'leading slash'; Identifiers = @('/db') }
        @{ Name = 'trailing slash'; Identifiers = @('db/') }
        @{ Name = 'slash only'; Identifiers = @('/') }
        @{ Name = 'empty middle segment'; Identifiers = @('db//col') }
        @{ Name = 'three segments'; Identifiers = @('db/col/item') }
        @{ Name = 'extra terminal slash'; Identifiers = @('db/col/') }
        @{ Name = 'duplicate database'; Identifiers = @('db', 'db') }
        @{ Name = 'duplicate container'; Identifiers = @('db/col', 'db/col') }
        @{ Name = 'parent before child'; Identifiers = @('db', 'db/col') }
        @{ Name = 'child before parent'; Identifiers = @('db/col', 'db') }
        @{ Name = 'duplicate literal punctuation database'; Identifiers = @('db*{one},', 'db*{one},') }
        @{ Name = 'duplicate literal punctuation container'; Identifiers = @('db/col*{one},', 'db/col*{one},') }
        @{ Name = 'literal punctuation parent before child'; Identifiers = @('db*{one},', 'db*{one},/col') }
        @{ Name = 'literal punctuation child before parent'; Identifiers = @('db*{one},/col', 'db*{one},') }
        @{ Name = 'invalid entry among valid entries'; Identifiers = @('DB1/col1', '', 'db2') }
        @{ Name = 'fifty one identifiers'; Identifiers = @(1..51 | ForEach-Object { 'db{0}' -f $_ }) }
    )
    foreach ($character in @('\', '?', '#')) {
        $invalidSelectors += @{ Name = "forbidden database character $character"; Identifiers = @("db${character}name/col") }
        $invalidSelectors += @{ Name = "forbidden container character $character"; Identifiers = @("db/col${character}name") }
    }
    foreach ($code in @((0..31) + 127 + (128..159))) {
        $invalidSelectors += @{ Name = "database control U+$('{0:X4}' -f $code)"; Identifiers = @("db$([char]$code)name/col") }
        $invalidSelectors += @{ Name = "container control U+$('{0:X4}' -f $code)"; Identifiers = @("db/col$([char]$code)name") }
    }

    Context 'Manifest and private selector contract' {
        It 'enables Cosmos ILR in the real manifest without expanding restore modes' {
            $manifest = LoadManifest -DatasourceType AzureCosmosDB
            $manifest.itemLevelRecoveyEnabled | Should -Be $true
            @($manifest.allowedRestoreModes).Count | Should -Be 1
            $manifest.allowedRestoreModes[0] | Should -BeExactly 'RecoveryPointBased'
            @($manifest.allowedRestoreTargetTypes).Count | Should -Be 1
            $manifest.allowedRestoreTargetTypes[0] | Should -BeExactly 'AlternateLocation'
            $manifest.isProxyResource | Should -Be $false
        }

        It 'keeps the selector validator private and marked DoNotExport' {
            $command = Get-Command Test-CosmosDbRestoreResourceIdentifier -CommandType Function -ErrorAction Stop
            @($command.ScriptBlock.Attributes | Where-Object { $_.GetType().Name -eq 'DoNotExportAttribute' }).Count | Should -Be 1
            foreach ($module in @(Get-Module -Name 'Az.DataProtection*')) {
                $module.ExportedCommands.ContainsKey('Test-CosmosDbRestoreResourceIdentifier') | Should -Be $false
            }
        }

        It 'uses the existing helper surface rather than adding Cosmos-specific public parameters' {
            $command = Get-Command New-AzDataProtectionRestoreConfigurationClientObject -CommandType Function
            $expected = @('DatasourceType', 'ExcludedResourceType', 'IncludedResourceType', 'ExcludedNamespace', 'IncludedNamespace', 'LabelSelector', 'IncludeClusterScopeResource', 'ConflictPolicy', 'NamespaceMapping', 'PersistentVolumeRestoreMode', 'RestoreHookReference', 'ResourceModifierReference', 'StagingResourceGroupId', 'StagingStorageAccountId', 'ResourceIdentifier', 'ResourceNameOverride')
            # Function/proxy script blocks do not always expose a root ParamBlock.
            # Compare the callable surface, excluding only PowerShell's own parameters.
            $powerShellParameters = @([System.Management.Automation.PSCmdlet]::CommonParameters) + @([System.Management.Automation.PSCmdlet]::OptionalCommonParameters)
            $declared = @($command.Parameters.Keys | Where-Object { $_ -notin $powerShellParameters })
            ($declared | Sort-Object) -join '|' | Should -BeExactly (($expected | Sort-Object) -join '|')
        }

        It 'validates <Name> with no success output' -TestCases $validSelectors {
            param($Name, $Identifiers)
            @(Test-CosmosDbRestoreResourceIdentifier -ResourceIdentifier $Identifiers -ErrorAction Stop).Count | Should -Be 0
        }

        It 'private validator rejects <Name>' -TestCases $invalidSelectors {
            param($Name, $Identifiers)
            { Test-CosmosDbRestoreResourceIdentifier -ResourceIdentifier $Identifiers -ErrorAction Stop } | Should -Throw
        }
    }

    Context 'Configuration helper' {
        It 'builds one typed canonical criterion for <Name> preserving exact order and case' -TestCases $validSelectors {
            param($Name, $Identifiers)
            $result = @(New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier $Identifiers -ErrorAction Stop)
            $result.Count | Should -Be 1
            ($result[0] -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IGenericRestoreDatasourceCriteria]) | Should -Be $true
            $result[0].ObjectType | Should -BeExactly 'GenericRestoreDatasourceCriteria'
            $result[0].ResourceSelector.ObjectType | Should -BeExactly 'ResourceListSelectionCriteria'
            @($result[0].ResourceSelector.ResourceIdentifier).Count | Should -Be $Identifiers.Count
            for ($i = 0; $i -lt $Identifiers.Count; $i++) {
                $result[0].ResourceSelector.ResourceIdentifier[$i] | Should -BeExactly $Identifiers[$i]
            }
            $wire = ConvertTo-TestCosmosWireObject $result[0]
            @($wire.resourceSelectors.resourceIdentifiers).Count | Should -Be $Identifiers.Count
            for ($i = 0; $i -lt $Identifiers.Count; $i++) {
                $wire.resourceSelectors.resourceIdentifiers[$i] | Should -BeExactly $Identifiers[$i]
            }
            @($wire.resourceSelectors.PSObject.Properties.Name) -contains 'resourceNameOverrides' | Should -Be $false
        }

        It 'rejects an omitted ResourceIdentifier without prompting' {
            { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ErrorAction Stop } | Should -Throw
        }

        It 'helper rejects <Name>' -TestCases $invalidSelectors {
            param($Name, $Identifiers)
            { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier $Identifiers -ErrorAction Stop } | Should -Throw
        }

        It 'rejects ResourceNameOverride binding even when <Name>' -TestCases @(
            @{ Name = 'null'; Value = $null }
            @{ Name = 'empty'; Value = @{} }
            @{ Name = 'populated'; Value = @{ 'DB1/col1' = 'other/col' } }
        ) {
            param($Name, $Value)
            { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @('DB1/col1') -ResourceNameOverride $Value -ErrorAction Stop } | Should -Throw
        }

        $foreignParameters = @(
            @{ Name = 'ExcludedResourceType'; Value = @('secrets') }
            @{ Name = 'IncludedResourceType'; Value = @('pods') }
            @{ Name = 'ExcludedNamespace'; Value = @('excluded') }
            @{ Name = 'IncludedNamespace'; Value = @('included') }
            @{ Name = 'LabelSelector'; Value = @('app=test') }
            @{ Name = 'IncludeClusterScopeResource'; Value = $false }
            @{ Name = 'ConflictPolicy'; Value = 'Skip' }
            @{ Name = 'NamespaceMapping'; Value = @{ source = 'target' } }
            @{ Name = 'PersistentVolumeRestoreMode'; Value = 'RestoreWithoutVolumeData' }
            @{ Name = 'RestoreHookReference'; Value = @(@{ Name = 'hook'; Namespace = 'default' }) }
            @{ Name = 'ResourceModifierReference'; Value = @{ Name = 'modifier'; Namespace = 'default' } }
            @{ Name = 'StagingResourceGroupId'; Value = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/staging' }
            @{ Name = 'StagingStorageAccountId'; Value = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/staging/providers/Microsoft.Storage/storageAccounts/stagingtests' }
        )
        It 'rejects foreign helper parameter <Name>' -TestCases $foreignParameters {
            param($Name, $Value)
            $parameters = @{ DatasourceType = 'AzureCosmosDB'; ResourceIdentifier = @('db/col'); ErrorAction = 'Stop' }
            $parameters[$Name] = $Value
            { New-AzDataProtectionRestoreConfigurationClientObject @parameters } | Should -Throw
        }
    }

    Context 'Initializer validation' {
        It 'constructs a local VaultStore AlternateLocation ILR request from the approved mixed selection' {
            $request = Initialize-AzDataProtectionRestoreRequest @cosmosParameters -RestoreConfiguration (New-TestCosmosConfiguration)
            $request.ObjectType | Should -BeExactly 'AzureBackupRecoveryPointBasedRestoreRequest'
            $request.RestoreTargetInfo.ObjectType | Should -BeExactly 'ItemLevelRestoreTargetInfo'
            @($request.RestoreTargetInfo.RestoreCriterion).Count | Should -Be 1
            $wire = ConvertTo-TestCosmosWireObject $request
            $wire.restoreTargetInfo.restoreCriteria[0].objectType | Should -BeExactly 'GenericRestoreDatasourceCriteria'
            ($wire.restoreTargetInfo.restoreCriteria[0].resourceSelectors.resourceIdentifiers -join '|') | Should -BeExactly 'DB1/col1|Db1/col2|db2'
        }

        It 'accepts and preserves initializer selection <Name>' -TestCases $validSelectors {
            param($Name, $Identifiers)
            $configuration = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier $Identifiers -ErrorAction Stop
            $request = Initialize-AzDataProtectionRestoreRequest @cosmosParameters -RestoreConfiguration $configuration
            $actual = @($request.RestoreTargetInfo.RestoreCriterion[0].ResourceSelector.ResourceIdentifier)
            $actual.Count | Should -Be $Identifiers.Count
            for ($i = 0; $i -lt $Identifiers.Count; $i++) {
                $actual[$i] | Should -BeExactly $Identifiers[$i]
            }
        }

        It 'requires RestoreConfiguration when ILR is enabled' {
            { Initialize-AzDataProtectionRestoreRequest @cosmosParameters } | Should -Throw
        }

        It 'rejects a supplied configuration when ILR is <Name>' -TestCases @(
            @{ Name = 'unbound'; BindFalse = $false }
            @{ Name = 'explicitly false'; BindFalse = $true }
        ) {
            param($Name, $BindFalse)
            $parameters = $cosmosParameters.Clone()
            $parameters.Remove('ItemLevelRecovery')
            if ($BindFalse) { $parameters.ItemLevelRecovery = $false }
            { Initialize-AzDataProtectionRestoreRequest @parameters -RestoreConfiguration (New-TestCosmosConfiguration) } | Should -Throw
        }

        It 'rejects configuration shape <Name>' -TestCases @(
            @{ Name = 'null'; Kind = 'Null' }
            @{ Name = 'empty array'; Kind = 'Empty' }
            @{ Name = 'untyped object'; Kind = 'Untyped' }
            @{ Name = 'untyped canonical lookalike'; Kind = 'Lookalike' }
            @{ Name = 'two typed criteria'; Kind = 'Multiple' }
            @{ Name = 'AKS criteria'; Kind = 'AKS' }
            @{ Name = 'Blob criteria'; Kind = 'Blob' }
            @{ Name = 'base criterion with canonical discriminator'; Kind = 'BaseCanonical' }
            @{ Name = 'base criterion with wrong discriminator'; Kind = 'BaseWrong' }
            @{ Name = 'base criterion with wrong discriminator case'; Kind = 'BaseCase' }
            @{ Name = 'base criterion with empty discriminator'; Kind = 'BaseEmpty' }
        ) {
            param($Name, $Kind)
            $configuration = switch ($Kind) {
                'Null' { $null }
                'Empty' { ,@() }
                'Untyped' { [pscustomobject]@{} }
                'Lookalike' { [pscustomobject]@{ ObjectType = 'GenericRestoreDatasourceCriteria'; ResourceSelector = [pscustomobject]@{ ObjectType = 'ResourceListSelectionCriteria'; ResourceIdentifier = @('db/col') } } }
                'Multiple' { New-TestCosmosConfiguration; New-TestCosmosConfiguration }
                'AKS' { [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.KubernetesClusterRestoreCriteria]::new() }
                'Blob' { [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ItemPathBasedRestoreCriteria]::new() }
                { $_ -like 'Base*' } {
                    # The base model has a mutable discriminator but does not
                    # implement the required generic criterion interface.
                    $criterion = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ItemLevelRestoreCriteria]::new()
                    $criterion.ObjectType = switch ($Kind) {
                        'BaseCanonical' { 'GenericRestoreDatasourceCriteria' }
                        'BaseWrong' { 'ItemPathBasedRestoreCriteria' }
                        'BaseCase' { 'genericRestoreDatasourceCriteria' }
                        'BaseEmpty' { '' }
                    }
                    $criterion
                }
            }
            { Initialize-AzDataProtectionRestoreRequest @cosmosParameters -RestoreConfiguration $configuration } | Should -Throw
        }

        It 'revalidates mutated identifiers: <Name>' -TestCases $invalidSelectors {
            param($Name, $Identifiers)
            $configuration = New-TestCosmosConfiguration
            $configuration.ResourceSelector.ResourceIdentifier = $Identifiers
            { Initialize-AzDataProtectionRestoreRequest @cosmosParameters -RestoreConfiguration $configuration } | Should -Throw
        }

        It 'accepts a directly constructed public typed criterion for <Name>' -TestCases $validSelectors {
            param($Name, $Identifiers)
            # The derived criterion has a constant discriminator. Exercise its
            # public accepted shape, not impossible discriminator mutations.
            $configuration = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.GenericRestoreDatasourceCriteria]::new()
            $selector = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.ResourceListSelectionCriteria]::new()
            $selector.ObjectType = 'ResourceListSelectionCriteria'
            $selector.ResourceIdentifier = $Identifiers
            $configuration.ResourceSelector = $selector
            $configuration.ObjectType | Should -BeExactly 'GenericRestoreDatasourceCriteria'
            $request = Initialize-AzDataProtectionRestoreRequest @cosmosParameters -RestoreConfiguration $configuration
            $wire = ConvertTo-TestCosmosWireObject $request
            $wire.restoreTargetInfo.restoreCriteria[0].objectType | Should -BeExactly 'GenericRestoreDatasourceCriteria'
            $actual = @($wire.restoreTargetInfo.restoreCriteria[0].resourceSelectors.resourceIdentifiers)
            $actual.Count | Should -Be $Identifiers.Count
            for ($i = 0; $i -lt $Identifiers.Count; $i++) {
                $actual[$i] | Should -BeExactly $Identifiers[$i]
            }
        }

        It 'rejects mutated selector structure <Name>' -TestCases @(
            @{ Name = 'unset selector rematerialized as empty'; Mutation = 'NullSelector' }
            @{ Name = 'wrong selector discriminator'; Mutation = 'Selector' }
            @{ Name = 'wrong selector case'; Mutation = 'SelectorCase' }
            @{ Name = 'empty selector discriminator'; Mutation = 'EmptySelector' }
            @{ Name = 'populated rename map'; Mutation = 'Override' }
        ) {
            param($Name, $Mutation)
            $configuration = New-TestCosmosConfiguration
            switch ($Mutation) {
                'NullSelector' {
                    $configuration.ResourceSelector = $null
                    # Reading the public getter materializes an empty selector,
                    # not a persistent null; its missing discriminator is invalid.
                    ($configuration.ResourceSelector -is [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.IResourceListSelectionCriteria]) | Should -Be $true
                    $configuration.ResourceSelector.ObjectType | Should -BeNullOrEmpty
                }
                'Selector' { $configuration.ResourceSelector.ObjectType = 'OtherSelectionCriteria' }
                'SelectorCase' { $configuration.ResourceSelector.ObjectType = 'resourceListSelectionCriteria' }
                'EmptySelector' { $configuration.ResourceSelector.ObjectType = '' }
                'Override' {
                    $map = [System.Collections.Generic.Dictionary[string,string]]::new()
                    $map.Add('DB1/col1', 'renamed')
                    $configuration.ResourceSelector.ResourceNameOverride = $map
                }
            }
            { Initialize-AzDataProtectionRestoreRequest @cosmosParameters -RestoreConfiguration $configuration } | Should -Throw
        }

        It 'accepts valid identifiers after mutation without normalizing them' {
            $configuration = New-TestCosmosConfiguration
            $configuration.ResourceSelector.ResourceIdentifier = @('Db/Col', 'db', 'DB/col')
            $request = Initialize-AzDataProtectionRestoreRequest @cosmosParameters -RestoreConfiguration $configuration
            ($request.RestoreTargetInfo.RestoreCriterion[0].ResourceSelector.ResourceIdentifier -join '|') | Should -BeExactly 'Db/Col|db|DB/col'
        }

        It 'rejects source datastore <Store>' -TestCases @(
            @{ Store = 'OperationalStore' }
            @{ Store = 'ArchiveStore' }
        ) {
            param($Store)
            $parameters = $cosmosParameters.Clone()
            $parameters.SourceDataStore = $Store
            { Initialize-AzDataProtectionRestoreRequest @parameters -RestoreConfiguration (New-TestCosmosConfiguration) } | Should -Throw
        }

        It 'rejects target ARM ID <Name>' -TestCases @(
            @{ Name = 'empty'; Id = '' }
            @{ Name = 'whitespace'; Id = ' ' }
            @{ Name = 'account name only'; Id = 'target-account' }
            @{ Name = 'wrong provider'; Id = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/tests/providers/Microsoft.Storage/storageAccounts/target' }
            @{ Name = 'database child'; Id = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/tests/providers/Microsoft.DocumentDB/databaseAccounts/target/sqlDatabases/db' }
            @{ Name = 'container child'; Id = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/tests/providers/Microsoft.DocumentDB/databaseAccounts/target/sqlDatabases/db/containers/col' }
            @{ Name = 'missing account'; Id = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/tests/providers/Microsoft.DocumentDB/databaseAccounts/' }
            @{ Name = 'query'; Id = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/tests/providers/Microsoft.DocumentDB/databaseAccounts/target?x=1' }
        ) {
            param($Name, $Id)
            $parameters = $cosmosParameters.Clone()
            $parameters.TargetResourceId = $Id
            { Initialize-AzDataProtectionRestoreRequest @parameters -RestoreConfiguration (New-TestCosmosConfiguration) } | Should -Throw
        }

        It 'rejects OriginalLocation ILR locally' {
            $parameters = $cosmosParameters.Clone()
            $parameters.Remove('TargetResourceId')
            $parameters.RestoreType = 'OriginalLocation'
            $instance = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.BackupInstanceResource]::new()
            { Initialize-AzDataProtectionRestoreRequest @parameters -BackupInstance $instance -RestoreConfiguration (New-TestCosmosConfiguration) } | Should -Throw
        }

        It 'rejects point-in-time Cosmos recovery locally' {
            $parameters = $cosmosParameters.Clone()
            $parameters.Remove('RecoveryPoint')
            $parameters.Remove('TargetResourceId')
            $parameters.RestoreType = 'OriginalLocation'
            $instance = [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Models.BackupInstanceResource]::new()
            { Initialize-AzDataProtectionRestoreRequest @parameters -BackupInstance $instance -PointInTime ([datetime]'2026-01-02T03:04:05Z') -RestoreConfiguration (New-TestCosmosConfiguration) } | Should -Throw
        }

        It 'rejects Blob-only Cosmos initializer parameter <Name>' -TestCases @(
            @{ Name = 'ContainersList'; Value = @('container') }
            @{ Name = 'PrefixMatch'; Value = @{ container = @('prefix/') } }
            @{ Name = 'RenameTo'; Value = @{ container = 'renamed' } }
            @{ Name = 'FromPrefixPattern'; Value = @('container/a') }
            @{ Name = 'ToPrefixPattern'; Value = @('container/z') }
        ) {
            param($Name, $Value)
            $parameters = $cosmosParameters.Clone()
            $parameters[$Name] = $Value
            { Initialize-AzDataProtectionRestoreRequest @parameters -RestoreConfiguration (New-TestCosmosConfiguration) } | Should -Throw
        }
    }
}