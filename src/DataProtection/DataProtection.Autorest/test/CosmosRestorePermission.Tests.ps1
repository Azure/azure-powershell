# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See License.txt in the project root for license information.

# Local Pester 4 tests: the standard module runner imports the locally built module.
# Do not load recording/live environment fixtures or use the current Azure context.
# Exercise private helpers in their native module, with every Azure boundary mocked.
$cosmosPermissionResourcesBoundary = $null
if (-not (Get-Command 'Az.Resources\Get-AzRoleAssignment' -ErrorAction SilentlyContinue)) {
    # Playback does not install Az.Resources. Pester 4 still needs the qualified
    # command's parameter metadata before it can mock the production boundary.
    # This temporary module throws if any call escapes the mock; it cannot use Azure.
    $cosmosPermissionResourcesBoundary = New-Module -Name Az.Resources -ScriptBlock {
        function Get-AzRoleAssignment {
            [CmdletBinding()]
            param([string] $ObjectId)
            throw 'Unexpected offline role lookup; the Az.Resources boundary must be mocked.'
        }
        Export-ModuleMember -Function Get-AzRoleAssignment
    }
    Import-Module $cosmosPermissionResourcesBoundary -Global -ErrorAction Stop
}
try {
InModuleScope Az.DataProtection.custom {
    Describe 'CosmosRestorePermission' {
        # Derive model types from the native parameter contract rather than pinning an API
        # namespace. This works with both versioned and unversioned generated models.
        $script:cosmosPermissionContract = (Get-Command Set-AzDataProtectionMSIPermission).Parameters['RestoreRequest'].ParameterType
        $script:cosmosPermissionAssembly = $script:cosmosPermissionContract.Assembly
        $script:cosmosPermissionNamespace = $script:cosmosPermissionContract.Namespace

        function New-CosmosPermissionTestVault {
            param([hashtable] $Properties)
            $modelType = $script:cosmosPermissionAssembly.GetType("$($script:cosmosPermissionNamespace).BackupVaultResource", $true)
            [System.Management.Automation.LanguagePrimitives]::ConvertTo($Properties, $modelType)
        }

        function New-CosmosPermissionTestRequest {
            param(
                [string] $ResourceId = $script:cosmosPermissionTarget,
                [string] $ResourceType = 'Microsoft.DocumentDB/databaseAccounts'
            )
            $targetType = $script:cosmosPermissionAssembly.GetType("$($script:cosmosPermissionNamespace).RestoreTargetInfo", $true)
            $requestType = $script:cosmosPermissionAssembly.GetType("$($script:cosmosPermissionNamespace).AzureBackupRecoveryPointBasedRestoreRequest", $true)
            $target = [System.Management.Automation.LanguagePrimitives]::ConvertTo(@{
                ObjectType = 'RestoreTargetInfo'
                DatasourceInfo = @{
                    ObjectType = 'Datasource'
                    ResourceId = $ResourceId
                    ResourceUri = $ResourceId
                    Type = $ResourceType
                    ResourceType = $ResourceType
                    ResourceName = $ResourceId.Split('/')[-1]
                    ResourceLocation = 'eastus'
                }
            }, $targetType)
            $request = [System.Activator]::CreateInstance($requestType)
            $request.RestoreTargetInfo = $target
            $request
        }

        function New-SharedPermissionBackupInstance {
            param([string] $ResourceId, [string] $DatasourceType)
            $modelType = $script:cosmosPermissionAssembly.GetType("$($script:cosmosPermissionNamespace).BackupInstanceResource", $true)
            [System.Management.Automation.LanguagePrimitives]::ConvertTo(@{
                Property = @{
                    DatasourceInfo = @{
                        ObjectType = 'Datasource'; ResourceId = $ResourceId
                        ResourceType = $DatasourceType; Type = $DatasourceType
                    }
                }
            }, $modelType)
        }

        BeforeEach {
            $script:cosmosPermissionOriginalWarningPreference = $WarningPreference
            # Synthetic IDs only; no subscription or resource is looked up by these tests.
            $script:cosmosPermissionSubscription = '/subscriptions/00000000-0000-0000-0000-000000000001'
            $script:cosmosPermissionResourceGroup = "$script:cosmosPermissionSubscription/resourceGroups/restore-tests"
            $script:cosmosPermissionTarget = "$script:cosmosPermissionResourceGroup/providers/Microsoft.DocumentDB/databaseAccounts/cosmos-target"
            $script:cosmosPermissionUami = "$script:cosmosPermissionResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/selected"
            $script:cosmosPermissionUamiDifferentCase = $script:cosmosPermissionUami.Replace('/resourceGroups/restore-tests/', '/RESOURCEGROUPS/RESTORE-TESTS/').Replace('/providers/Microsoft.ManagedIdentity/', '/PROVIDERS/MICROSOFT.MANAGEDIDENTITY/').Replace('/userAssignedIdentities/selected', '/USERASSIGNEDIDENTITIES/SELECTED')
            $script:cosmosPermissionOtherUami = "$script:cosmosPermissionResourceGroup/providers/Microsoft.ManagedIdentity/userAssignedIdentities/other"
            $script:cosmosPermissionSamiPrincipal = '00000000-0000-0000-0000-000000000010'
            $script:cosmosPermissionUamiPrincipal = '00000000-0000-0000-0000-000000000020'
            $script:cosmosPermissionOtherPrincipal = '00000000-0000-0000-0000-000000000030'
            $script:cosmosPermissionVault = New-CosmosPermissionTestVault @{
                IdentityPrincipalId = $script:cosmosPermissionSamiPrincipal
                IdentityType = 'SystemAssigned,UserAssigned'
                IdentityUserAssignedIdentity = @{
                    $script:cosmosPermissionOtherUami = @{ PrincipalId = $script:cosmosPermissionOtherPrincipal }
                    $script:cosmosPermissionUami = @{ PrincipalId = $script:cosmosPermissionUamiPrincipal }
                }
            }
            $script:cosmosPermissionRequest = New-CosmosPermissionTestRequest
            $script:cosmosPermissionArguments = @{
                VaultResourceGroup = 'restore-tests'
                VaultName = 'test-vault'
                PermissionsScope = 'Resource'
                DatasourceType = 'AzureCosmosDB'
                RestoreRequest = $script:cosmosPermissionRequest
            }
            $script:cosmosPermissionRoles = @()
            Mock CheckResourcesModuleDependency {}
            Mock 'Az.DataProtection\Get-AzDataProtectionBackupVault' { $script:cosmosPermissionVault }
            Mock 'Az.Resources\Get-AzRoleAssignment' { $script:cosmosPermissionRoles }
            Mock AssignMissingRoles {}
            Mock Start-Sleep {}
            Mock Write-Host {}
        }

        AfterEach {
            # The existing cmdlet does not restore this preference on terminating errors.
            # Keep negative tests from changing the native module's subsequent test state.
            $WarningPreference = $script:cosmosPermissionOriginalWarningPreference
        }

        Context 'Get-VaultIdentity' {
            It 'resolves the explicitly selected UAMI from a generated public vault map' {
                $script:cosmosPermissionVault.IdentityUserAssignedIdentity.PSObject.Methods['ContainsKey'] | Should -Not -BeNullOrEmpty
                Get-VaultIdentity -vault $script:cosmosPermissionVault -UserAssignedIdentityARMId $script:cosmosPermissionUami |
                    Should -Be $script:cosmosPermissionUamiPrincipal
            }

            It 'matches generated public UAMI keys with different <CasePart> casing' -TestCases @(
                @{ CasePart = 'resource group' }
                @{ CasePart = 'provider' }
                @{ CasePart = 'UAMI name' }
                @{ CasePart = 'all ARM segments' }
            ) {
                param($CasePart)
                $requestedId = switch ($CasePart) {
                    'resource group' { $script:cosmosPermissionUami.Replace('/resourceGroups/restore-tests/', '/RESOURCEGROUPS/RESTORE-TESTS/') }
                    'provider' { $script:cosmosPermissionUami.Replace('/providers/Microsoft.ManagedIdentity/', '/PROVIDERS/MICROSOFT.MANAGEDIDENTITY/') }
                    'UAMI name' { $script:cosmosPermissionUami.Replace('/selected', '/SELECTED') }
                    'all ARM segments' { $script:cosmosPermissionUamiDifferentCase }
                }
                # Confirm this exercises the case-sensitive generated map, not a hashtable.
                $script:cosmosPermissionVault.IdentityUserAssignedIdentity.ContainsKey($requestedId) | Should -Be $false
                Get-VaultIdentity -vault $script:cosmosPermissionVault -UserAssignedIdentityARMId $requestedId |
                    Should -Be $script:cosmosPermissionUamiPrincipal
            }

            It 'matches differently cased <MapShape> keys with Nested=<Nested>' -TestCases @(
                @{ MapShape = 'TypedDictionary'; Nested = $false }
                @{ MapShape = 'Hashtable'; Nested = $false }
                @{ MapShape = 'CustomObject'; Nested = $false }
                @{ MapShape = 'TypedDictionary'; Nested = $true }
                @{ MapShape = 'Hashtable'; Nested = $true }
                @{ MapShape = 'CustomObject'; Nested = $true }
            ) {
                param($MapShape, $Nested)
                $principal = [pscustomobject]@{ PrincipalId = $script:cosmosPermissionUamiPrincipal }
                $map = switch ($MapShape) {
                    'TypedDictionary' {
                        $dictionary = New-Object 'System.Collections.Generic.Dictionary[string,object]'
                        $dictionary.Add($script:cosmosPermissionUami, $principal)
                        # Do not enumerate the dictionary when emitting it from the switch.
                        ,$dictionary
                    }
                    'Hashtable' { @{ $script:cosmosPermissionUami = $principal } }
                    'CustomObject' { [pscustomobject]@{ $script:cosmosPermissionUami = $principal } }
                }
                $vault = if ($Nested) {
                    [pscustomobject]@{ Identity = [pscustomobject]@{ UserAssignedIdentity = $map } }
                } else {
                    [pscustomobject]@{ IdentityUserAssignedIdentity = $map }
                }
                Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId $script:cosmosPermissionUamiDifferentCase |
                    Should -Be $script:cosmosPermissionUamiPrincipal
                { Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId "$script:cosmosPermissionUamiDifferentCase-missing" } |
                    Should -Throw 'not attached'
            }

            It 'rejects ambiguous case-variant keys in a generated map even for an exact match' {
                $map = $script:cosmosPermissionVault.IdentityUserAssignedIdentity
                $map.Add($script:cosmosPermissionUamiDifferentCase, $map[$script:cosmosPermissionOtherUami])
                { Get-VaultIdentity -vault $script:cosmosPermissionVault -UserAssignedIdentityARMId $script:cosmosPermissionUami } |
                    Should -Throw 'ambiguous'
                { Get-VaultIdentity -vault $script:cosmosPermissionVault -UserAssignedIdentityARMId $script:cosmosPermissionUamiDifferentCase } |
                    Should -Throw 'ambiguous'
            }

            It 'rejects ambiguous case-variant keys in a nested typed dictionary' {
                $map = New-Object 'System.Collections.Generic.Dictionary[string,object]'
                $map.Add($script:cosmosPermissionUami, [pscustomobject]@{ PrincipalId = $script:cosmosPermissionUamiPrincipal })
                $map.Add($script:cosmosPermissionUamiDifferentCase, [pscustomobject]@{ PrincipalId = $script:cosmosPermissionOtherPrincipal })
                $vault = [pscustomobject]@{ Identity = [pscustomobject]@{ UserAssignedIdentity = $map } }
                { Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId $script:cosmosPermissionUami } |
                    Should -Throw 'ambiguous'
            }

            It 'uses the public SAMI principal when no UAMI is requested even with multiple attached UAMIs' {
                Get-VaultIdentity -vault $script:cosmosPermissionVault | Should -Be $script:cosmosPermissionSamiPrincipal
            }

            It 'requires an explicit selection rather than picking the first UAMI when SAMI is absent' {
                $script:cosmosPermissionVault = New-CosmosPermissionTestVault @{
                    IdentityUserAssignedIdentity = @{
                        $script:cosmosPermissionOtherUami = @{ PrincipalId = $script:cosmosPermissionOtherPrincipal }
                        $script:cosmosPermissionUami = @{ PrincipalId = $script:cosmosPermissionUamiPrincipal }
                    }
                }
                { Get-VaultIdentity -vault $script:cosmosPermissionVault } | Should -Throw 'Vault identity could not be determined'
                Get-VaultIdentity -vault $script:cosmosPermissionVault -UserAssignedIdentityARMId $script:cosmosPermissionUami |
                    Should -Be $script:cosmosPermissionUamiPrincipal
            }

            It 'rejects a UAMI that is not attached instead of falling back to SAMI' {
                { Get-VaultIdentity -vault $script:cosmosPermissionVault -UserAssignedIdentityARMId "$script:cosmosPermissionUamiDifferentCase-missing" } |
                    Should -Throw 'not attached'
            }

            It 'rejects an attached generated UAMI without a principal instead of falling back to SAMI' {
                $script:cosmosPermissionVault = New-CosmosPermissionTestVault @{
                    IdentityPrincipalId = $script:cosmosPermissionSamiPrincipal
                    IdentityUserAssignedIdentity = @{ $script:cosmosPermissionUami = @{} }
                }
                { Get-VaultIdentity -vault $script:cosmosPermissionVault -UserAssignedIdentityARMId $script:cosmosPermissionUamiDifferentCase } |
                    Should -Throw 'has no principal ID'
            }

            It 'accepts a typed dictionary in a public-shaped vault' {
                $map = New-Object 'System.Collections.Generic.Dictionary[string,object]'
                $map.Add($script:cosmosPermissionUami, [pscustomobject]@{ PrincipalId = $script:cosmosPermissionUamiPrincipal })
                $vault = [pscustomobject]@{ IdentityUserAssignedIdentity = $map }
                Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId $script:cosmosPermissionUami |
                    Should -Be $script:cosmosPermissionUamiPrincipal
            }

            It 'accepts a PSCustomObject identity map' {
                $vault = [pscustomobject]@{
                    IdentityUserAssignedIdentity = [pscustomobject]@{
                        $script:cosmosPermissionUami = [pscustomobject]@{ PrincipalId = $script:cosmosPermissionUamiPrincipal }
                    }
                }
                Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId $script:cosmosPermissionUami |
                    Should -Be $script:cosmosPermissionUamiPrincipal
            }

            It 'keeps nested older-model UAMI and SAMI shapes compatible' {
                $vault = [pscustomobject]@{
                    Identity = [pscustomobject]@{
                        PrincipalId = $script:cosmosPermissionSamiPrincipal
                        UserAssignedIdentity = @{ $script:cosmosPermissionUami = @{ PrincipalId = $script:cosmosPermissionUamiPrincipal } }
                    }
                }
                Get-VaultIdentity -vault $vault | Should -Be $script:cosmosPermissionSamiPrincipal
                Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId $script:cosmosPermissionUami |
                    Should -Be $script:cosmosPermissionUamiPrincipal
            }

            It 'does not use a stale nested UAMI when the public map is empty' {
                $vault = [pscustomobject]@{
                    IdentityUserAssignedIdentity = @{}
                    Identity = @{ UserAssignedIdentity = @{ $script:cosmosPermissionUami = @{ PrincipalId = $script:cosmosPermissionOtherPrincipal } } }
                }
                { Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId $script:cosmosPermissionUami } | Should -Throw 'not attached'
            }

            It 'does not use a stale nested UAMI when the public map is null' {
                $vault = [pscustomobject]@{
                    IdentityUserAssignedIdentity = $null
                    Identity = @{ UserAssignedIdentity = @{ $script:cosmosPermissionUami = @{ PrincipalId = $script:cosmosPermissionOtherPrincipal } } }
                }
                { Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId $script:cosmosPermissionUami } | Should -Throw 'not attached'
            }

            It 'prefers the public SAMI principal over a conflicting nested older-model principal' {
                $vault = [pscustomobject]@{
                    IdentityPrincipalId = $script:cosmosPermissionSamiPrincipal
                    Identity = @{ PrincipalId = $script:cosmosPermissionOtherPrincipal }
                }
                Get-VaultIdentity -vault $vault | Should -Be $script:cosmosPermissionSamiPrincipal
            }

            It 'prefers a populated public UAMI map over a conflicting legacy nested map' {
                $vault = [pscustomobject]@{
                    IdentityUserAssignedIdentity = @{ $script:cosmosPermissionUami = @{ PrincipalId = $script:cosmosPermissionUamiPrincipal } }
                    Identity = @{ UserAssignedIdentity = @{ $script:cosmosPermissionUami = @{ PrincipalId = $script:cosmosPermissionOtherPrincipal } } }
                }
                Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId $script:cosmosPermissionUamiDifferentCase |
                    Should -Be $script:cosmosPermissionUamiPrincipal
            }

            It 'retains legacy SAMI fallback when the public principal is <Shape>' -TestCases @(
                @{ Shape = 'null'; Principal = $null }
                @{ Shape = 'empty'; Principal = '' }
                @{ Shape = 'whitespace'; Principal = ' ' }
            ) {
                param($Shape, $Principal)
                $vault = [pscustomobject]@{
                    IdentityPrincipalId = $Principal
                    Identity = @{ PrincipalId = $script:cosmosPermissionSamiPrincipal }
                }
                Get-VaultIdentity -vault $vault | Should -Be $script:cosmosPermissionSamiPrincipal
            }

            It 'rejects a whitespace-only UAMI principal' {
                $vault = [pscustomobject]@{ IdentityUserAssignedIdentity = @{ $script:cosmosPermissionUami = @{ PrincipalId = ' ' } } }
                { Get-VaultIdentity -vault $vault -UserAssignedIdentityARMId $script:cosmosPermissionUami } | Should -Throw 'has no principal ID'
            }

            It 'rejects a missing or whitespace-only SAMI principal' {
                { Get-VaultIdentity -vault ([pscustomobject]@{}) } | Should -Throw 'Vault identity could not be determined'
                { Get-VaultIdentity -vault ([pscustomobject]@{ IdentityPrincipalId = ' ' }) } | Should -Throw 'Vault identity could not be determined'
            }
        }

        Context 'Native Cosmos restore permission flow' {
            It 'performs zero assignments and no propagation wait for SAMI under WhatIf' {
                Set-AzDataProtectionMSIPermission @script:cosmosPermissionArguments -WhatIf
                Assert-MockCalled 'Az.Resources\Get-AzRoleAssignment' -Times 1 -Exactly -Scope It -ParameterFilter { $ObjectId -eq $script:cosmosPermissionSamiPrincipal }
                Assert-MockCalled AssignMissingRoles -Times 0 -Exactly -Scope It
                Assert-MockCalled Start-Sleep -Times 0 -Exactly -Scope It
                Assert-MockCalled Write-Host -Times 0 -Exactly -Scope It -ParameterFilter { "$Object" -like 'Assigned *' }
            }

            It 'performs zero assignments and no wait for the explicitly selected UAMI under WhatIf' {
                Set-AzDataProtectionMSIPermission @script:cosmosPermissionArguments -UserAssignedIdentityARMId $script:cosmosPermissionUami -WhatIf
                Assert-MockCalled 'Az.Resources\Get-AzRoleAssignment' -Times 1 -Exactly -Scope It -ParameterFilter { $ObjectId -eq $script:cosmosPermissionUamiPrincipal }
                Assert-MockCalled AssignMissingRoles -Times 0 -Exactly -Scope It
                Assert-MockCalled Start-Sleep -Times 0 -Exactly -Scope It
            }

            It 'assigns the missing Cosmos role to SAMI with the existing resource scope arguments' {
                Set-AzDataProtectionMSIPermission @script:cosmosPermissionArguments -Confirm:$false
                Assert-MockCalled AssignMissingRoles -Times 1 -Exactly -Scope It -ParameterFilter {
                    $ObjectId -eq $script:cosmosPermissionSamiPrincipal -and $Permission -eq 'Cosmos DB Operator' -and
                    $PermissionsScope -eq 'Resource' -and $Resource -eq $script:cosmosPermissionTarget -and
                    $ResourceGroup -eq $script:cosmosPermissionResourceGroup -and $Subscription -eq $script:cosmosPermissionSubscription
                }
                Assert-MockCalled Start-Sleep -Times 1 -Exactly -Scope It -ParameterFilter { $Seconds -eq 60 }
            }

            It 'assigns the missing role to the explicitly selected UAMI and never to another identity' {
                Set-AzDataProtectionMSIPermission @script:cosmosPermissionArguments -UserAssignedIdentityARMId $script:cosmosPermissionUami -Confirm:$false
                Assert-MockCalled AssignMissingRoles -Times 1 -Exactly -Scope It
                Assert-MockCalled AssignMissingRoles -Times 1 -Exactly -Scope It -ParameterFilter {
                    $ObjectId -eq $script:cosmosPermissionUamiPrincipal -and $Permission -eq 'Cosmos DB Operator'
                }
            }

            It 'preserves the requested <PermissionsScope> scope when assigning a missing role' -TestCases @(
                @{ PermissionsScope = 'ResourceGroup' }
                @{ PermissionsScope = 'Subscription' }
            ) {
                param($PermissionsScope)
                $script:cosmosPermissionArguments.PermissionsScope = $PermissionsScope
                Set-AzDataProtectionMSIPermission @script:cosmosPermissionArguments -Confirm:$false
                Assert-MockCalled AssignMissingRoles -Times 1 -Exactly -Scope It -ParameterFilter {
                    $PermissionsScope -eq $script:cosmosPermissionArguments.PermissionsScope -and
                    $Resource -eq $script:cosmosPermissionTarget -and $ResourceGroup -eq $script:cosmosPermissionResourceGroup -and
                    $Subscription -eq $script:cosmosPermissionSubscription
                }
            }

            It 'does not reassign an existing Cosmos role inherited at <ExistingScope> scope' -TestCases @(
                @{ ExistingScope = 'Resource' }
                @{ ExistingScope = 'ResourceGroup' }
                @{ ExistingScope = 'Subscription' }
            ) {
                param($ExistingScope)
                $scope = switch ($ExistingScope) {
                    Resource { $script:cosmosPermissionTarget }
                    ResourceGroup { $script:cosmosPermissionResourceGroup }
                    Subscription { $script:cosmosPermissionSubscription }
                }
                $script:cosmosPermissionRoles = @([pscustomobject]@{ Scope = $scope; RoleDefinitionName = 'Cosmos DB Operator' })
                Set-AzDataProtectionMSIPermission @script:cosmosPermissionArguments -Confirm:$false
                Assert-MockCalled AssignMissingRoles -Times 0 -Exactly -Scope It
                Assert-MockCalled Start-Sleep -Times 0 -Exactly -Scope It
            }

            It 'is idempotent after the first missing-role assignment' {
                Mock AssignMissingRoles {
                    $script:cosmosPermissionRoles = @([pscustomobject]@{ Scope = $Resource; RoleDefinitionName = $Permission })
                }
                Set-AzDataProtectionMSIPermission @script:cosmosPermissionArguments -Confirm:$false
                Set-AzDataProtectionMSIPermission @script:cosmosPermissionArguments -Confirm:$false
                Assert-MockCalled AssignMissingRoles -Times 1 -Exactly -Scope It
                Assert-MockCalled Start-Sleep -Times 1 -Exactly -Scope It
            }

            It 'does not treat a different role or another account scope as the required permission' {
                $script:cosmosPermissionRoles = @(
                    [pscustomobject]@{ Scope = $script:cosmosPermissionTarget; RoleDefinitionName = 'Reader' }
                    [pscustomobject]@{ Scope = "$script:cosmosPermissionTarget-other"; RoleDefinitionName = 'Cosmos DB Operator' }
                )
                Set-AzDataProtectionMSIPermission @script:cosmosPermissionArguments -Confirm:$false
                Assert-MockCalled AssignMissingRoles -Times 1 -Exactly -Scope It -ParameterFilter { $Permission -eq 'Cosmos DB Operator' }
            }

            It 'fails before role reads or assignments when the requested UAMI is not attached' {
                { Set-AzDataProtectionMSIPermission @script:cosmosPermissionArguments -UserAssignedIdentityARMId "$script:cosmosPermissionUami-missing" -Confirm:$false } |
                    Should -Throw 'not attached'
                Assert-MockCalled 'Az.Resources\Get-AzRoleAssignment' -Times 0 -Exactly -Scope It
                Assert-MockCalled AssignMissingRoles -Times 0 -Exactly -Scope It
                Assert-MockCalled Start-Sleep -Times 0 -Exactly -Scope It
            }

            It 'fails before role reads or assignments when the requested UAMI has no principal' {
                $script:cosmosPermissionVault = New-CosmosPermissionTestVault @{
                    IdentityPrincipalId = $script:cosmosPermissionSamiPrincipal
                    IdentityUserAssignedIdentity = @{ $script:cosmosPermissionUami = @{} }
                }
                { Set-AzDataProtectionMSIPermission @script:cosmosPermissionArguments -UserAssignedIdentityARMId $script:cosmosPermissionUami -Confirm:$false } |
                    Should -Throw 'has no principal ID'
                Assert-MockCalled 'Az.Resources\Get-AzRoleAssignment' -Times 0 -Exactly -Scope It
                Assert-MockCalled AssignMissingRoles -Times 0 -Exactly -Scope It
                Assert-MockCalled Start-Sleep -Times 0 -Exactly -Scope It
            }
        }

        Context 'Shared identity selection preserves existing non-Cosmos permission callers' {
            $backupCases = foreach ($workload in @(
                @{ Workload = 'Blob'; ResourceType = 'Microsoft.Storage/storageAccounts/blobServices'; Path = 'Microsoft.Storage/storageAccounts/blobsource'; Role = 'Storage Account Backup Contributor'; RGReader = $false }
                @{ Workload = 'ADLS'; ResourceType = 'Microsoft.Storage/storageAccounts/adlsBlobServices'; Path = 'Microsoft.Storage/storageAccounts/adlssource'; Role = 'Storage Account Backup Contributor'; RGReader = $false }
                @{ Workload = 'PGFlex'; ResourceType = 'Microsoft.DBforPostgreSQL/flexibleServers'; Path = 'Microsoft.DBforPostgreSQL/flexibleServers/pgsource'; Role = 'PostgreSQL Flexible Server Long Term Retention Backup Role'; RGReader = $true }
                @{ Workload = 'MySQL'; ResourceType = 'Microsoft.DBforMySQL/flexibleServers'; Path = 'Microsoft.DBforMySQL/flexibleServers/mysqlsource'; Role = 'MySQL Backup And Export Operator'; RGReader = $true }
            )) {
                foreach ($identity in @('SAMI', 'UAMI')) {
                    foreach ($existing in @($false, $true)) {
                        @{ Workload = $workload.Workload; ResourceType = $workload.ResourceType; Path = $workload.Path; Role = $workload.Role; RGReader = $workload.RGReader; Identity = $identity; Existing = $existing }
                    }
                }
            }
            It '<Workload> backup preserves <Identity> principal, roles and scopes with Existing=<Existing>' -TestCases $backupCases {
                param($Workload, $ResourceType, $Path, $Role, $RGReader, $Identity, $Existing)
                $script:sharedPermissionTarget = "$script:cosmosPermissionResourceGroup/providers/$Path"
                $script:sharedPermissionRole = $Role
                $script:sharedPermissionPrincipal = $script:cosmosPermissionSamiPrincipal
                $identityArguments = @{}
                if ($Identity -eq 'UAMI') {
                    $identityArguments.UserAssignedIdentityARMId = $script:cosmosPermissionUamiDifferentCase
                    $script:sharedPermissionPrincipal = $script:cosmosPermissionUamiPrincipal
                }
                if ($Existing) {
                    $script:cosmosPermissionRoles = @([pscustomobject]@{ Scope = $script:sharedPermissionTarget; RoleDefinitionName = $Role })
                    if ($RGReader) { $script:cosmosPermissionRoles += [pscustomobject]@{ Scope = $script:cosmosPermissionResourceGroup; RoleDefinitionName = 'Reader' } }
                }
                $instance = New-SharedPermissionBackupInstance -ResourceId $script:sharedPermissionTarget -DatasourceType $ResourceType
                Set-AzDataProtectionMSIPermission -BackupInstance $instance -VaultResourceGroup 'restore-tests' -VaultName 'test-vault' -PermissionsScope Resource @identityArguments -Confirm:$false
                Assert-MockCalled 'Az.Resources\Get-AzRoleAssignment' -Times 0 -Exactly -Scope It -ParameterFilter { $ObjectId -ne $script:sharedPermissionPrincipal }
                if ($Existing) {
                    Assert-MockCalled AssignMissingRoles -Times 0 -Exactly -Scope It
                    Assert-MockCalled Start-Sleep -Times 0 -Exactly -Scope It
                } else {
                    $expectedCount = 1
                    if ($RGReader) { $expectedCount++ }
                    Assert-MockCalled AssignMissingRoles -Times $expectedCount -Exactly -Scope It
                    Assert-MockCalled AssignMissingRoles -Times 1 -Exactly -Scope It -ParameterFilter {
                        $ObjectId -eq $script:sharedPermissionPrincipal -and $Permission -eq $script:sharedPermissionRole -and
                        $Resource -eq $script:sharedPermissionTarget -and $PermissionsScope -eq 'Resource' -and
                        $ResourceGroup -eq $script:cosmosPermissionResourceGroup -and $Subscription -eq $script:cosmosPermissionSubscription
                    }
                    if ($RGReader) {
                        Assert-MockCalled AssignMissingRoles -Times 1 -Exactly -Scope It -ParameterFilter {
                            $ObjectId -eq $script:sharedPermissionPrincipal -and $Permission -eq 'Reader' -and
                            $PermissionsScope -eq 'ResourceGroup' -and $ResourceGroup -eq $script:cosmosPermissionResourceGroup
                        }
                    }
                    Assert-MockCalled Start-Sleep -Times 1 -Exactly -Scope It -ParameterFilter { $Seconds -eq 60 }
                }
            }

            $restoreCases = foreach ($workload in @(
                @{ Workload = 'AzureKubernetesService'; ResourceType = 'Microsoft.ContainerService/managedclusters'; Path = 'Microsoft.ContainerService/managedClusters/aks-target'; ScopePath = 'Microsoft.ContainerService/managedClusters/aks-target'; Role = 'Reader' }
                @{ Workload = 'AzureElasticSAN'; ResourceType = 'Microsoft.ElasticSan/elasticSans/volumeGroups'; Path = 'Microsoft.ElasticSan/elasticSans/test-san/volumeGroups/target-group'; ScopePath = 'Microsoft.ElasticSan/elasticSans/test-san'; Role = 'Elastic SAN Volume Importer' }
            )) {
                foreach ($identity in @('SAMI', 'UAMI')) {
                    foreach ($preview in @($false, $true)) {
                        @{ Workload = $workload.Workload; ResourceType = $workload.ResourceType; Path = $workload.Path; ScopePath = $workload.ScopePath; Role = $workload.Role; Identity = $identity; Preview = $preview }
                    }
                }
            }
            It '<Workload> datasource restore retains <Identity> target scope with WhatIf=<Preview>' -TestCases $restoreCases {
                param($Workload, $ResourceType, $Path, $ScopePath, $Role, $Identity, $Preview)
                $script:sharedPermissionTarget = "$script:cosmosPermissionResourceGroup/providers/$Path"
                $script:sharedPermissionScope = "$script:cosmosPermissionResourceGroup/providers/$ScopePath"
                $script:sharedPermissionRole = $Role
                $script:sharedPermissionPrincipal = $script:cosmosPermissionSamiPrincipal
                $arguments = @{
                    SubscriptionId = $script:cosmosPermissionSubscription.Split('/')[-1]
                    VaultResourceGroup = 'restore-tests'; VaultName = 'test-vault'; PermissionsScope = 'Resource'
                    DatasourceType = $Workload
                    RestoreRequest = New-CosmosPermissionTestRequest -ResourceId $script:sharedPermissionTarget -ResourceType $ResourceType
                    # Deliberately omit snapshot RG: this test covers the shared
                    # datasource loop only, not unchanged snapshot/cluster grants.
                    WhatIf = $Preview; Confirm = $false
                }
                if ($Identity -eq 'UAMI') {
                    $arguments.UserAssignedIdentityARMId = $script:cosmosPermissionUamiDifferentCase
                    $script:sharedPermissionPrincipal = $script:cosmosPermissionUamiPrincipal
                }
                Set-AzDataProtectionMSIPermission @arguments
                Assert-MockCalled 'Az.Resources\Get-AzRoleAssignment' -Times 1 -Exactly -Scope It -ParameterFilter { $ObjectId -eq $script:sharedPermissionPrincipal }
                if ($Preview) {
                    Assert-MockCalled AssignMissingRoles -Times 0 -Exactly -Scope It
                    Assert-MockCalled Start-Sleep -Times 0 -Exactly -Scope It
                } else {
                    Assert-MockCalled AssignMissingRoles -Times 1 -Exactly -Scope It -ParameterFilter {
                        $ObjectId -eq $script:sharedPermissionPrincipal -and $Permission -eq $script:sharedPermissionRole -and
                        $PermissionsScope -eq 'Resource' -and $Resource -eq $script:sharedPermissionScope -and
                        $ResourceGroup -eq $script:cosmosPermissionResourceGroup -and $Subscription -eq $script:cosmosPermissionSubscription
                    }
                    Assert-MockCalled Start-Sleep -Times 1 -Exactly -Scope It -ParameterFilter { $Seconds -eq 60 }
                }
            }

            It '<Workload> file restore retains <Identity> and cross-subscription storage-account scope' -TestCases @(
                @{ Workload = 'AzureDatabaseForPGFlexServer'; Identity = 'SAMI' }
                @{ Workload = 'AzureDatabaseForPGFlexServer'; Identity = 'UAMI' }
                @{ Workload = 'AzureDatabaseForMySQL'; Identity = 'SAMI' }
                @{ Workload = 'AzureDatabaseForMySQL'; Identity = 'UAMI' }
            ) {
                param($Workload, $Identity)
                $script:sharedStorageSubscription = '/subscriptions/00000000-0000-0000-0000-000000000099'
                $script:sharedStorageRG = "$script:sharedStorageSubscription/resourceGroups/file-targets"
                $script:sharedStorageAccount = "$script:sharedStorageRG/providers/Microsoft.Storage/storageAccounts/restoredfiles"
                $script:sharedPermissionPrincipal = $script:cosmosPermissionSamiPrincipal
                $requestIdentity = @{ UseSystemAssignedIdentity = $true }
                if ($Identity -eq 'UAMI') {
                    $requestIdentity = @{ UseSystemAssignedIdentity = $false; UserAssignedIdentityArmId = $script:cosmosPermissionUamiDifferentCase }
                }
                # Use the real initializer so this fixture preserves the concrete
                # RestoreFilesTargetInfo rather than converting a polymorphic base.
                $request = Az.DataProtection\Initialize-AzDataProtectionRestoreRequest -DatasourceType $Workload `
                    -RestoreType RestoreAsFiles -SourceDataStore VaultStore -RestoreLocation eastus -RecoveryPoint 'offline-point' `
                    -TargetContainerURI 'https://restoredfiles.blob.core.windows.net/target' `
                    -TargetResourceIdForRestoreAsFile "$script:sharedStorageAccount/blobServices/default/containers/target" @requestIdentity
                $request.RestoreTargetInfo.ObjectType | Should -BeExactly 'RestoreFilesTargetInfo'
                $request.RestoreTargetInfo.TargetDetail.TargetResourceArmId | Should -BeExactly "$script:sharedStorageAccount/blobServices/default/containers/target"
                $arguments = @{
                    SubscriptionId = $script:cosmosPermissionSubscription.Split('/')[-1]
                    VaultResourceGroup = 'restore-tests'; VaultName = 'test-vault'; PermissionsScope = 'Resource'
                    DatasourceType = $Workload; RestoreRequest = $request; Confirm = $false
                }
                if ($Identity -eq 'UAMI') {
                    $arguments.UserAssignedIdentityARMId = $script:cosmosPermissionUamiDifferentCase
                    $script:sharedPermissionPrincipal = $script:cosmosPermissionUamiPrincipal
                }
                Set-AzDataProtectionMSIPermission @arguments
                Assert-MockCalled AssignMissingRoles -Times 1 -Exactly -Scope It -ParameterFilter {
                    $ObjectId -eq $script:sharedPermissionPrincipal -and $Permission -eq 'Storage Blob Data Contributor' -and
                    $PermissionsScope -eq 'Resource' -and $Resource -eq $script:sharedStorageAccount -and
                    $ResourceGroup -eq $script:sharedStorageRG -and $Subscription -eq $script:sharedStorageSubscription
                }
                Assert-MockCalled 'Az.Resources\Get-AzRoleAssignment' -Times 1 -Exactly -Scope It -ParameterFilter { $ObjectId -eq $script:sharedPermissionPrincipal }
                Assert-MockCalled Start-Sleep -Times 1 -Exactly -Scope It -ParameterFilter { $Seconds -eq 60 }
            }
        }
    }
}
} finally {
    if ($null -ne $cosmosPermissionResourcesBoundary) {
        Remove-Module -ModuleInfo $cosmosPermissionResourcesBoundary -ErrorAction Stop
    }
}