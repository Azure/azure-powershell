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

# Local only: these commands build request objects without calling the service.
Describe 'CosmosRestoreConfiguration' -Tag 'Unit', 'CosmosRestore' {
    BeforeAll {
        $restoreParameters = @{
            DatasourceType = 'AzureCosmosDB'
            SourceDataStore = 'VaultStore'
            RestoreLocation = 'eastus'
            RestoreType = 'AlternateLocation'
            TargetResourceId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/restore-tests/providers/Microsoft.DocumentDB/databaseAccounts/target-account'
            RecoveryPoint = 'unit-test-recovery-point'
            ErrorAction = 'Stop'
        }

        function ConvertTo-TestCosmosWireObject($Model) {
            $Model.ToJson($null, [Microsoft.Azure.PowerShell.Cmdlets.DataProtection.Runtime.SerializationMode]::IncludeCreateOrUpdate).ToString() | ConvertFrom-Json
        }
    }

    Context 'New-AzDataProtectionRestoreConfigurationClientObject' {
        It 'builds one resource list criterion for <Name>' -TestCases @(
            @{ Name = 'a container'; Identifiers = @('db1/col1') }
            @{ Name = 'a database'; Identifiers = @('db2') }
            @{ Name = 'containers and a database'; Identifiers = @('db1/col1', 'db1/col2', 'db2') }
        ) {
            param($Name, $Identifiers)
            $result = @(New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier $Identifiers -ErrorAction Stop)
            $result.Count | Should -Be 1
            $wire = ConvertTo-TestCosmosWireObject $result[0]
            $wire.objectType | Should -BeExactly 'GenericRestoreDatasourceCriteria'
            $wire.resourceSelectors.objectType | Should -BeExactly 'ResourceListSelectionCriteria'
            ($wire.resourceSelectors.resourceIdentifiers -join '|') | Should -BeExactly ($Identifiers -join '|')
            @($wire.resourceSelectors.PSObject.Properties.Name) -contains 'resourceNameOverrides' | Should -Be $false
        }

        It 'requires ResourceIdentifier' {
            { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ErrorAction Stop } | Should -Throw 'Please input parameter ResourceIdentifier'
            { New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @() -ErrorAction Stop } | Should -Throw 'Please input parameter ResourceIdentifier'
        }

        It 'rejects parameter <Name>' -TestCases @(
            @{ Name = 'IncludedNamespace'; Value = @('ns1') }
            @{ Name = 'StagingResourceGroupId'; Value = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/staging' }
            @{ Name = 'ResourceNameOverride'; Value = @{ 'db1/col1' = 'db1/col9' } }
        ) {
            param($Name, $Value)
            $parameters = @{ DatasourceType = 'AzureCosmosDB'; ResourceIdentifier = @('db1/col1'); ErrorAction = 'Stop' }
            $parameters[$Name] = $Value
            { New-AzDataProtectionRestoreConfigurationClientObject @parameters } | Should -Throw 'Only ResourceIdentifier is supported'
        }
    }

    Context 'Initialize-AzDataProtectionRestoreRequest' {
        It 'adds the restore configuration as the item level restore criterion' {
            $configuration = New-AzDataProtectionRestoreConfigurationClientObject -DatasourceType AzureCosmosDB -ResourceIdentifier @('db1/col1', 'db1/col2', 'db2') -ErrorAction Stop
            $request = Initialize-AzDataProtectionRestoreRequest @restoreParameters -ItemLevelRecovery -RestoreConfiguration $configuration
            $wire = ConvertTo-TestCosmosWireObject $request
            $wire.restoreTargetInfo.objectType | Should -BeExactly 'ItemLevelRestoreTargetInfo'
            @($wire.restoreTargetInfo.restoreCriteria).Count | Should -Be 1
            $criterion = $wire.restoreTargetInfo.restoreCriteria[0]
            $criterion.objectType | Should -BeExactly 'GenericRestoreDatasourceCriteria'
            $criterion.resourceSelectors.objectType | Should -BeExactly 'ResourceListSelectionCriteria'
            ($criterion.resourceSelectors.resourceIdentifiers -join '|') | Should -BeExactly 'db1/col1|db1/col2|db2'
        }

        It 'requires RestoreConfiguration for item level restore' {
            { Initialize-AzDataProtectionRestoreRequest @restoreParameters -ItemLevelRecovery } | Should -Throw 'Please input parameter RestoreConfiguration'
        }

        It 'keeps the full restore request without restore criteria' {
            $wire = ConvertTo-TestCosmosWireObject (Initialize-AzDataProtectionRestoreRequest @restoreParameters)
            $wire.restoreTargetInfo.objectType | Should -BeExactly 'RestoreTargetInfo'
            @($wire.restoreTargetInfo.PSObject.Properties.Name) -contains 'restoreCriteria' | Should -Be $false
        }
    }
}
