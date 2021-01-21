﻿<#
.SYNOPSIS
Run a suite of Azure Key Vault tests via the PowerShell cmdlets.

.PARAMETER TestRunNameSpace
Used as a namespace for each test run. It is used as a substring for key
and vault names during tests, so be sure to keep it short.

.PARAMETER TestMode
The test mode (optional). Must be either 'ControlPlane', 'DataPlane',
or 'All'.

.PARAMETER Location
The location of both the provided vault as well as its corresponding
resource group, if such a vault is provided (optional).

.PARAMETER Vault
The vault to run the tests against (optional). If no vault is provided,
then a temporary vault will be used instead.

.PARAMETER ResourceGroup
The name of the resource group of the given vault, if such a vault is
provided (optional).

.PARAMETER StandardVaultOnly
If true, then tests that require a premium vault are skipped (optional).

.PARAMETER UserObjectId
The object ID of the user (optional). If no object ID is provided, then
the object ID is extracted from whomever is currently logged in.

.PARAMETER SoftDeleteEnabled
If true, turns on 'soft-delete' mode for tests: vault is created as soft-delete-enabled (if not exists), soft-delete 
tests are executed, delete + purge sequence is used for clean-up. 

.PARAMETER NoADCmdLetMode
If true, then active directory related tests are skipped.

.EXAMPLE
.\RunKeyVaultTests.ps1 -TestRunNameSpace "test1"

Run all tests against a temporary vault.

.EXAMPLE
.\RunKeyVaultTests.ps1 -TestRunNameSpace "test2" -TestMode "DataPlane" -Location "westus" -Vault "MyAwesomeVault" -ResourceGroup "MyAwesomeResourceGroup" -StorageResourceId "/subscriptions/76fb41ba-5387-4dff-89f5-24ae457ade99/resourceGroups/kvstoragetestrg/providers/Microsoft.Storage/storageAccounts/azkvteststorage1westus"

Run only the data plane tests against a provided vault.
#>
param(
    [Parameter(Mandatory=$true, Position=0)]
    [string] $TestRunNameSpace,
    [Parameter(Mandatory=$false, Position=1)]
    [ValidateSet('ControlPlane','DataPlane', 'All')]
    [string] $TestMode = 'All',
    [Parameter(Mandatory=$false, Position=2)]
    [string] $Location = 'eastus2',
    [Parameter(Mandatory=$false, Position=3)]
    [string] $Vault = "",
    [Parameter(Mandatory=$false, Position=4)]
    [string] $ResourceGroup = "",
    [Parameter(Mandatory=$false, Position=5)]
    [bool] $StandardVaultOnly = $false,
    [Parameter(Mandatory=$false, Position=6)]
    [bool] $SoftDeleteEnabled = $false,
    [Parameter(Mandatory=$false, Position=7)]
    [Guid] $UserObjectId,
    [Parameter(Mandatory=$false, Position=8)]
    [Nullable[bool]] $NoADCmdLetMode = $null,
    [Parameter(Mandatory=$false, Position=9)]
    [string] $StorageResourceId = $null
)

. (Join-Path $PSScriptRoot "..\..\..\..\tools\ScenarioTest.ResourceManager\Common.ps1")
. (Join-Path $PSScriptRoot "..\..\..\..\tools\ScenarioTest.ResourceManager\Assert.ps1")
. (Join-Path $PSScriptRoot "Common.ps1")
. (Join-Path $PSScriptRoot "VaultKeyTests.ps1")
. (Join-Path $PSScriptRoot "VaultSecretTests.ps1")
. (Join-Path $PSScriptRoot "VaultCertificateTests.ps1");
. (Join-Path $PSScriptRoot "VaultManagedStorageAccountTests.ps1");
. (Join-Path $PSScriptRoot "VaultManagementTests.ps1")
. (Join-Path $PSScriptRoot "ControlPlane\KeyVaultManagementTests.ps1")  # Shared between PSH scenario tests and KV-specific script based tests.

$global:totalCount = 0
$global:passedCount = 0
$global:passedTests = @()
$global:failedTests = @()
$global:times = @{}
$global:testEnv = 'PROD'
$global:testns = $TestRunNameSpace
$global:location = $Location
$global:testVault = $Vault
$global:resourceGroupName = $ResourceGroup
$global:standardVaultOnly = $StandardVaultOnly
$global:softDeleteEnabled = $SoftDeleteEnabled
$global:objectId = $UserObjectId
$global:noADCmdLetMode = $NoADCmdLetMode
$global:storageResourceId = $StorageResourceId

if (-not $global:objectId)
{
    $upn = (Get-AzContext).Account.Id
    $user = Get-AzADUser -UserPrincipalName $upn
    if ($user -eq $null)
    {
        $user = Get-AzADUser -Mail $upn
    }
    Assert-NotNull $user
    $global:objectId = $user.Id
}

if ($global:noADCmdLetMode -eq $null)
{
    # AD PowerShell APIs are broken in Fairfax. Otherwise, the default mode is $false.
    if ((Get-AzContext).Environment.AzureKeyVaultDnsSuffix -eq 'vault.usgovcloudapi.net')
    {
        $global:noADCmdLetMode = $true
    }
    else
    {
        $global:noADCmdLetMode = $false
    }
}

<#
.SYNOPSIS
Run the test in a protected context.

.PARAMETER script
The test code to run.

.PARAMETER testName
The name of the test.
#>
function Run-TestProtected
{
    param(
        [ScriptBlock] $script,
        [string] $testName
    )

    $testStart = Get-Date
    try
    {
        Write-Host -ForegroundColor Green "====================================="
        Write-Host -ForegroundColor Green "Running test $testName"
        Write-Host -ForegroundColor Green "====================================="
        Write-Host
        &$script
        $global:passedCount = $global:passedCount + 1
        Write-Host
        Write-Host -ForegroundColor Green "====================================="
        Write-Host -ForegroundColor Green "Test Passed"
        Write-Host -ForegroundColor Green "====================================="
        Write-Host
        $global:passedTests += $testName
    }
    catch
    {
        Out-String -InputObject $_.Exception | Write-Host -ForegroundColor Red
        Write-Host
        Write-Host -ForegroundColor Red "====================================="
        Write-Host -ForegroundColor Red "Test Failed"
        Write-Host -ForegroundColor Red "====================================="
        Write-Host
        $global:failedTests += $testName
    }
    finally
    {
        $testEnd = Get-Date
        $testElapsed = $testEnd - $testStart
        $global:times[$testName] = $testElapsed
        $global:totalCount = $global:totalCount + 1
    }
}

<#
.SYNOPSIS
Run all of the control plane tests.
#>
function Run-AllControlPlaneTests
{
    Write-Host "Starting the control plane tests..."

    # New-AzKeyVault tests.
    if ($global:standardVaultOnly -eq $false)
    {
        Run-TestProtected { Run-VaultTest { Test_CreateNewPremiumVaultEnabledForDeployment } "Test_CreateNewPremiumVaultEnabledForDeployment" } "Test_CreateNewPremiumVaultEnabledForDeployment"
    }

    Run-TestProtected { Run-VaultTest { Test_CreateNewVault } "Test_CreateNewVault" } "Test_CreateNewVault"
    Run-TestProtected { Run-VaultTest { Test_RecreateVaultFails } "Test_RecreateVaultFails" } "Test_RecreateVaultFails"
    Run-TestProtected { Run-VaultTest { Test_CreateVaultInUnknownResGrpFails } "Test_CreateVaultInUnknownResGrpFails" } "Test_CreateVaultInUnknownResGrpFails"
    Run-TestProtected { Run-VaultTest { Test_CreateVaultPositionalParams } "Test_CreateVaultPositionalParams" } "Test_CreateVaultPositionalParams"
    Run-TestProtected { Run-VaultTest { Test_CreateNewStandardVaultEnableSoftDelete } "Test_CreateNewStandardVaultEnableSoftDelete" } "Test_CreateNewStandardVaultEnableSoftDelete"

    # soft-delete tests.
    Run-TestProtected { Run-VaultTest { Test_RecoverDeletedVault } "Test_RecoverDeletedVault" } "Test_RecoverDeletedVault"
    Run-TestProtected { Run-VaultTest { Test_GetNoneexistingDeletedVault } "Test_GetNoneexistingDeletedVault" } "Test_GetNoneexistingDeletedVault"
    Run-TestProtected { Run-VaultTest { Test_PurgeDeletedVault } "Test_PurgeDeletedVault" } "Test_PurgeDeletedVault"

    # Get-AzKeyVault tests.
    Run-TestProtected { Run-VaultTest { Test_GetVaultByNameAndResourceGroup } "Test_GetVaultByNameAndResourceGroup" } "Test_GetVaultByNameAndResourceGroup"
    Run-TestProtected { Run-VaultTest { Test_GetVaultByNameAndResourceGroupPositionalParams } "Test_GetVaultByNameAndResourceGroupPositionalParams" } "Test_GetVaultByNameAndResourceGroupPositionalParams"
    Run-TestProtected { Run-VaultTest { Test_GetVaultByName } "Test_GetVaultByName" } "Test_GetVaultByName"
    Run-TestProtected { Run-VaultTest { Test_GetUnknownVaultFails } "Test_GetUnknownVaultFails" } "Test_GetUnknownVaultFails"
    Run-TestProtected { Run-VaultTest { Test_GetVaultFromUnknownResourceGroupFails } "Test_GetVaultFromUnknownResourceGroupFails" } "Test_GetVaultFromUnknownResourceGroupFails"
    Run-TestProtected { Run-VaultTest { Test_ListVaultsByResourceGroup } "Test_ListVaultsByResourceGroup" } "Test_ListVaultsByResourceGroup"
    Run-TestProtected { Run-VaultTest { Test_ListAllVaultsInSubscription } "Test_ListAllVaultsInSubscription" } "Test_ListAllVaultsInSubscription"
    Run-TestProtected { Run-VaultTest { Test_ListVaultsByTag } "Test_ListVaultsByTag" } "Test_ListVaultsByTag"
    Run-TestProtected { Run-VaultTest { Test_ListVaultsByUnknownResourceGroupFails } "Test_ListVaultsByUnknownResourceGroupFails" } "Test_ListVaultsByUnknownResourceGroupFails"

    # Remove-AzKeyVault tests.
    Run-TestProtected { Run-VaultTest { Test_DeleteVaultByName } "Test_DeleteVaultByName" } "Test_DeleteVaultByName"
    Run-TestProtected { Run-VaultTest { Test_DeleteUnknownVaultFails } "Test_DeleteUnknownVaultFails" } "Test_DeleteUnknownVaultFails"

    # Set-AzKeyVaultAccessPolicy & Remove-AzKeyVaultAccessPolicy tests.
    Run-TestProtected { Run-VaultTest { Test_SetRemoveAccessPolicyByUPN } "Test_SetRemoveAccessPolicyByUPN" } "Test_SetRemoveAccessPolicyByUPN"

    # This test will fail for users that do not have the same email address as their UPN.
    Run-TestProtected { Run-VaultTest { Test_SetRemoveAccessPolicyByEmailAddress } "Test_SetRemoveAccessPolicyByEmailAddress" } "Test_SetRemoveAccessPolicyByEmailAddress"

    Run-TestProtected { Run-VaultTest { Test_SetRemoveAccessPolicyBySPN } "Test_SetRemoveAccessPolicyBySPN" } "Test_SetRemoveAccessPolicyBySPN"
    Run-TestProtected { Run-VaultTest { Test_SetRemoveAccessPolicyByObjectId } "Test_SetRemoveAccessPolicyByObjectId" } "Test_SetRemoveAccessPolicyByObjectId"
    Run-TestProtected { Run-VaultTest { Test_SetRemoveAccessPolicyByBypassObjectIdValidation } "Test_SetRemoveAccessPolicyByBypassObjectIdValidation" } "Test_SetRemoveAccessPolicyByBypassObjectIdValidation"
    Run-TestProtected { Run-VaultTest { Test_SetRemoveAccessPolicyByCompoundId } "Test_SetRemoveAccessPolicyByCompoundId" } "Test_SetRemoveAccessPolicyByCompoundId"
    Run-TestProtected { Run-VaultTest { Test_RemoveAccessPolicyWithCompoundIdPolicies } "Test_RemoveAccessPolicyWithCompoundIdPolicies" } "Test_RemoveAccessPolicyWithCompoundIdPolicies"
    Run-TestProtected { Run-VaultTest { Test_SetCompoundIdAccessPolicy } "Test_SetCompoundIdAccessPolicy" } "Test_SetCompoundIdAccessPolicy"
    Run-TestProtected { Run-VaultTest { Test_ModifyAccessPolicy } "Test_ModifyAccessPolicy" } "Test_ModifyAccessPolicy"
    Run-TestProtected { Run-VaultTest { Test_ModifyAccessPolicyEnabledForDeployment } "Test_ModifyAccessPolicyEnabledForDeployment" } "Test_ModifyAccessPolicyEnabledForDeployment"
    Run-TestProtected { Run-VaultTest { Test_ModifyAccessPolicyNegativeCases } "Test_ModifyAccessPolicyNegativeCases" } "Test_ModifyAccessPolicyNegativeCases"
    Run-TestProtected { Run-VaultTest { Test_RemoveNonExistentAccessPolicyDoesNotThrow } "Test_RemoveNonExistentAccessPolicyDoesNotThrow" } "Test_RemoveNonExistentAccessPolicyDoesNotThrow"
    Run-TestProtected { Run-VaultTest { Test_AllPermissionExpansion } "Test_AllPermissionExpansion" } "Test_AllPermissionExpansion"


    # Piping tests.
    Run-TestProtected { Run-VaultTest { Test_CreateDeleteVaultWithPiping } "Test_CreateDeleteVaultWithPiping" } "Test_CreateDeleteVaultWithPiping"
}

<#
.SYNOPSIS
Run all of the data plane tests.
#>
function Run-AllDataPlaneTests
{
    Write-Host "Starting the data plane tests..."

    # All operations that invlove soft delete
    if($global:softDeleteEnabled -eq $true)
    {
        # Key soft delete tests
        Run-TestProtected { Run-KeyTest {Test_GetDeletedKey} "Test_GetDeletedKey" } "Test_GetDeletedKey"
        Run-TestProtected { Run-KeyTest {Test_GetDeletedKeys} "Test_GetDeletedKeys" } "Test_GetDeletedKeys"
        Run-TestProtected { Run-KeyTest {Test_UndoRemoveKey} "Test_UndoRemoveKey" } "Test_UndoRemoveKey"
        Run-TestProtected { Run-KeyTest {Test_RemoveDeletedKey} "Test_RemoveDeletedKey" } "Test_RemoveDeletedKey"
        Run-TestProtected { Run-KeyTest {Test_RemoveNonExistDeletedKey} "Test_RemoveNonExistDeletedKey" } "Test_RemoveNonExistDeletedKey"
        Run-TestProtected { Run-KeyTest {Test_PipelineRemoveDeletedKeys} "Test_PipelineRemoveDeletedKeys" } "Test_PipelineRemoveDeletedKeys"

        # Secret soft delete tests
        Run-TestProtected { Run-KeyTest {Test_GetDeletedKey} "Test_GetDeletedSecret" } "Test_GetDeletedSecret"
        Run-TestProtected { Run-KeyTest {Test_GetDeletedKeys} "Test_GetDeletedSecrets" } "Test_GetDeletedSecrets"
        Run-TestProtected { Run-KeyTest {Test_UndoRemoveSecret} "Test_UndoRemoveSecret" } "Test_UndoRemoveSecret"
        Run-TestProtected { Run-KeyTest {Test_RemoveDeletedSecret} "Test_RemoveDeletedSecret" } "Test_RemoveDeletedSecret"
        Run-TestProtected { Run-KeyTest {Test_RemoveNonExistDeletedSecret} "Test_RemoveNonExistDeletedSecret" } "Test_RemoveNonExistDeletedSecret"
        Run-TestProtected { Run-KeyTest {Test_PipelineRemoveDeletedSecrets} "Test_PipelineRemoveDeletedSecrets" } "Test_PipelineRemoveDeletedSecrets"

        # certificate soft delete tests
        Run-TestProtected { Run-KeyTest {Test_GetDeletedCertificate} "Test_GetDeletedCertificate" } "Test_GetDeletedCertificate"
        Run-TestProtected { Run-KeyTest {Test_GetDeletedCertificates} "Test_GetDeletedCertificates" } "Test_GetDeletedCertificates"
        Run-TestProtected { Run-KeyTest {Test_UndoRemoveCertificate} "Test_UndoRemoveCertificate" } "Test_UndoRemoveCertificate"
        Run-TestProtected { Run-KeyTest {Test_RemoveDeletedCertificate} "Test_RemoveDeletedCertificate" } "Test_RemoveDeletedCertificate"
        Run-TestProtected { Run-KeyTest {Test_RemoveNonExistDeletedCertificate} "Test_RemoveNonExistDeletedCertificate" } "Test_RemoveNonExistDeletedCertificate"
        Run-TestProtected { Run-KeyTest {Test_PipelineRemoveDeletedCertificates} "Test_PipelineRemoveDeletedCertificate" } "Test_PipelineRemoveDeletedCertificates"
    }

    # Add-AzKeyVaultKey tests.
    Run-TestProtected { Run-KeyTest {Test_CreateSoftwareKeyWithDefaultAttributes} "Test_CreateSoftwareKeyWithDefaultAttributes" } "Test_CreateSoftwareKeyWithDefaultAttributes"
    Run-TestProtected { Run-KeyTest {Test_CreateSoftwareKeyWithCustomAttributes} "Test_CreateSoftwareKeyWithCustomAttributes" } "Test_CreateSoftwareKeyWithCustomAttributes"

    # All operations involving HSM keys.
    if (-not $global:standardVaultOnly)
    {
        Run-TestProtected { Run-KeyTest {Test_CreateHsmKeyWithDefaultAttributes} "Test_CreateHsmKeyWithDefaultAttributes" } "Test_CreateHsmKeyWithDefaultAttributes"
        Run-TestProtected { Run-KeyTest {Test_CreateHsmKeyWithCustomAttributes} "Test_CreateHsmKeyWithCustomAttributes" } "Test_CreateHsmKeyWithCustomAttributes"
        Run-TestProtected { Run-KeyTest {Test_ImportPfxAsHsmWithDefaultAttributes} "Test_ImportPfxAsHsmWithDefaultAttributes" } "Test_ImportPfxAsHsmWithDefaultAttributes"
        Run-TestProtected { Run-KeyTest {Test_ImportPfxAsHsmWithCustomAttributes} "Test_ImportPfxAsHsmWithCustomAttributes" } "Test_ImportPfxAsHsmWithCustomAttributes"

        # All operations involving BYOK keys. For these tests to run correctly, the user running the tests
        # must have a subscription ID that matches the subscription ID of the person who initially
        # generated the dummy *.byok files located in the proddata folder.
        #
        # TODO: Consider generating these *.byok files on the fly.
        $byokSubscriptionId = "c2619f08-57f7-492b-a9c3-45dee233805b"
        if ((Get-AzContext).Subscription.SubscriptionId -eq "c2619f08-57f7-492b-a9c3-45dee233805b")
        {
            Run-TestProtected { Run-KeyTest {Test_ImportByokWithDefaultAttributes} "Test_ImportByokWithDefaultAttributes" } "Test_ImportByokWithDefaultAttributes"
            Run-TestProtected { Run-KeyTest {Test_ImportByokWith1024BitKey} "Test_ImportByokWith1024BitKey" } "Test_ImportByokWith1024BitKey"
            Run-TestProtected { Run-KeyTest {Test_ImportByokWithCustomAttributes} "Test_ImportByokWithCustomAttributes" } "Test_ImportByokWithCustomAttributes"
        }
    }

    Run-TestProtected { Run-KeyTest {Test_ImportPfxWithDefaultAttributes} "Test_ImportPfxWithDefaultAttributes" } "Test_ImportPfxWithDefaultAttributes"
    Run-TestProtected { Run-KeyTest {Test_ImportPfxWith1024BitKey} "Test_ImportPfxWith1024BitKey" } "Test_ImportPfxWith1024BitKey"
    Run-TestProtected { Run-KeyTest {Test_ImportPfxWithCustomAttributes} "Test_ImportPfxWithCustomAttributes" } "Test_ImportPfxWithCustomAttributes"
    Run-TestProtected { Run-KeyTest {Test_AddKeyPositionalParameter} "Test_AddKeyPositionalParameter" } "Test_AddKeyPositionalParameter"
    Run-TestProtected { Run-KeyTest {Test_AddKeyAliasParameter} "Test_AddKeyAliasParameter" } "Test_AddKeyAliasParameter"
    Run-TestProtected { Run-KeyTest {Test_ImportNonExistPfxFile} "Test_ImportNonExistPfxFile" } "Test_ImportNonExistPfxFile"
    Run-TestProtected { Run-KeyTest {Test_ImportPfxFileWithIncorrectPassword} "Test_ImportPfxFileWithIncorrectPassword" } "Test_ImportPfxFileWithIncorrectPassword"
    Run-TestProtected { Run-KeyTest {Test_ImportNonExistByokFile} "Test_ImportNonExistByokFile" } "Test_ImportNonExistByokFile"
    Run-TestProtected { Run-KeyTest {Test_CreateKeyInNonExistVault} "Test_CreateKeyInNonExistVault" } "Test_CreateKeyInNonExistVault"
    Run-TestProtected { Run-KeyTest {Test_ImportByokAsSoftwareKey} "Test_ImportByokAsSoftwareKey" } "Test_ImportByokAsSoftwareKey"
    Run-TestProtected { Run-KeyTest {Test_CreateKeyInNoPermissionVault} "Test_CreateKeyInNoPermissionVault" } "Test_CreateKeyInNoPermissionVault"

    # Set-AzKeyVaultKeyAttribute tests.
    Run-TestProtected { Run-KeyTest {Test_UpdateIndividualKeyAttributes} "Test_UpdateIndividualKeyAttributes" } "Test_UpdateIndividualKeyAttributes"
    Run-TestProtected { Run-KeyTest {Test_UpdateAllEditableKeyAttributes} "Test_UpdateAllEditableKeyAttributes" } "Test_UpdateAllEditableKeyAttributes"
    Run-TestProtected { Run-KeyTest {Test_UpdateKeyWithNoChange} "Test_UpdateKeyWithNoChange" } "Test_UpdateKeyWithNoChange"
    Run-TestProtected { Run-KeyTest {Test_SetKeyPositionalParameter} "Test_SetKeyPositionalParameter" } "Test_SetKeyPositionalParameter"
    Run-TestProtected { Run-KeyTest {Test_SetKeyAliasParameter} "Test_SetKeyAliasParameter" } "Test_SetKeyAliasParameter"
    Run-TestProtected { Run-KeyTest {Test_SetKeyVersion} "Test_SetKeyVersion" } "Test_SetKeyVersion"
    Run-TestProtected { Run-KeyTest {Test_SetKeyInNonExistVault} "Test_SetKeyInNonExistVault" } "Test_SetKeyInNonExistVault"
    Run-TestProtected { Run-KeyTest {Test_SetNonExistKey} "Test_SetNonExistKey" } "Test_SetNonExistKey"
    Run-TestProtected { Run-KeyTest {Test_SetInvalidKeyAttributes} "Test_SetInvalidKeyAttributes" } "Test_SetInvalidKeyAttributes"
    Run-TestProtected { Run-KeyTest {Test_SetKeyInNoPermissionVault} "Test_SetKeyInNoPermissionVault" } "Test_SetKeyInNoPermissionVault"

    # Get-AzKeyVaultKey tests.
    Run-TestProtected { Run-KeyTest {Test_GetOneKey} "Test_GetOneKey" } "Test_GetOneKey"
    Run-TestProtected { Run-KeyTest {Test_GetPreviousVersionOfKey} "Test_GetPreviousVersionOfKey" } "Test_GetPreviousVersionOfKey"
    Run-TestProtected { Run-KeyTest {Test_GetKeyPositionalParameter} "Test_GetKeyPositionalParameter" } "Test_GetKeyPositionalParameter"
    Run-TestProtected { Run-KeyTest {Test_GetKeyAliasParameter} "Test_GetKeyAliasParameter" } "Test_GetKeyAliasParameter"
    Run-TestProtected { Run-KeyTest {Test_GetKeysInNonExistVault} "Test_GetKeysInNonExistVault" } "Test_GetKeysInNonExistVault"
    Run-TestProtected { Run-KeyTest {Test_GetNonExistKey} "Test_GetNonExistKey" } "Test_GetNonExistKey"
    Run-TestProtected { Run-KeyTest {Test_GetKeyInNoPermissionVault} "Test_GetKeyInNoPermissionVault" } "Test_GetKeyInNoPermissionVault"
    Run-TestProtected { Run-KeyTest {Test_GetAllKeys} "Test_GetAllKeys" } "Test_GetAllKeys"
    Run-TestProtected { Run-KeyTest {Test_GetKeyVersions} "Test_GetKeyVersions" } "Test_GetKeyVersions"

    # Remove-AzKeyVaultKey tests.
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyWithoutPrompt} "Test_RemoveKeyWithoutPrompt" } "Test_RemoveKeyWithoutPrompt"
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyWhatIf} "Test_RemoveKeyWhatIf" } "Test_RemoveKeyWhatIf"
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyPositionalParameter} "Test_RemoveKeyPositionalParameter" } "Test_RemoveKeyPositionalParameter"
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyAliasParameter} "Test_RemoveKeyAliasParameter" } "Test_RemoveKeyAliasParameter"
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyInNonExistVault} "Test_RemoveKeyInNonExistVault" } "Test_RemoveKeyInNonExistVault"
    Run-TestProtected { Run-KeyTest {Test_RemoveNonExistKey} "Test_RemoveNonExistKey" } "Test_RemoveNonExistKey"
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyInNoPermissionVault} "Test_RemoveKeyInNoPermissionVault" } "Test_RemoveKeyInNoPermissionVault"

    # Backup-AzKeyVaultKey and Restore-AzKeyVaultKey tests.
    Run-TestProtected { Run-KeyTest {Test_BackupRestoreKeyByName} "Test_BackupRestoreKeyByName" } "Test_BackupRestoreKeyByName"
    Run-TestProtected { Run-KeyTest {Test_BackupRestoreKeyByRef} "Test_BackupRestoreKeyByRef" } "Test_BackupRestoreKeyByRef"
    Run-TestProtected { Run-KeyTest {Test_BackupNonExistingKey} "Test_BackupNonExistingKey" } "Test_BackupNonExistingKey"
    Run-TestProtected { Run-KeyTest {Test_BackupKeyToANamedFile} "Test_BackupKeyToANamedFile" } "Test_BackupKeyToANamedFile"
    Run-TestProtected { Run-KeyTest {Test_BackupKeyToExistingFile} "Test_BackupKeyToExistingFile" } "Test_BackupKeyToExistingFile"
    Run-TestProtected { Run-KeyTest {Test_RestoreKeyFromNonExistingFile} "Test_RestoreKeyFromNonExistingFile" } "Test_RestoreKeyFromNonExistingFile"

    # *-AzKeyVaultKey pipeline tests.
    Run-TestProtected { Run-KeyTest {Test_PipelineUpdateKeys} "Test_PipelineUpdateKeys" } "Test_PipelineUpdateKeys"
    Run-TestProtected { Run-KeyTest {Test_PipelineRemoveKeys} "Test_PipelineRemoveKeys" } "Test_PipelineRemoveKeys"
    Run-TestProtected { Run-KeyTest {Test_PipelineUpdateKeyVersions} "Test_PipelineUpdateKeyVersions" } "Test_PipelineUpdateKeyVersions"

    # Set-AzKeyVaultSecret tests.
    Run-TestProtected { Run-SecretTest {Test_CreateSecret} "Test_CreateSecret" } "Test_CreateSecret"
    Run-TestProtected { Run-SecretTest {Test_CreateSecretWithCustomAttributes} "Test_CreateSecretWithCustomAttributes" } "Test_CreateSecretWithCustomAttributes"
    Run-TestProtected { Run-SecretTest {Test_UpdateSecret} "Test_UpdateSecret" } "Test_UpdateSecret"

    Run-TestProtected { Run-SecretTest {Test_SetSecretPositionalParameter} "Test_SetSecretPositionalParameter" } "Test_SetSecretPositionalParameter"
    Run-TestProtected { Run-SecretTest {Test_SetSecretAliasParameter} "Test_SetSecretAliasParameter" } "Test_SetSecretAliasParameter"
    Run-TestProtected { Run-SecretTest {Test_SetSecretInNonExistVault} "Test_SetSecretInNonExistVault" } "Test_SetSecretInNonExistVault"
    Run-TestProtected { Run-SecretTest {Test_SetSecretInNoPermissionVault} "Test_SetSecretInNoPermissionVault" } "Test_SetSecretInNoPermissionVault"

    # Set-AzKeyVaultSecretAttribute tests.
    Run-TestProtected { Run-SecretTest {Test_UpdateIndividualSecretAttributes} "Test_UpdateIndividualSecretAttributes" } "Test_UpdateIndividualSecretAttributes"
    Run-TestProtected { Run-SecretTest {Test_UpdateSecretWithNoChange} "Test_UpdateSecretWithNoChange" } "Test_UpdateSecretWithNoChange"
    Run-TestProtected { Run-SecretTest {Test_UpdateAllEditableSecretAttributes} "Test_UpdateAllEditableSecretAttributes" } "Test_UpdateAllEditableSecretAttributes"
    Run-TestProtected { Run-SecretTest {Test_SetSecretAttributePositionalParameter} "Test_SetSecretAttributePositionalParameter" } "Test_SetSecretAttributePositionalParameter"
    Run-TestProtected { Run-SecretTest {Test_SetSecretAttributeAliasParameter} "Test_SetSecretAttributeAliasParameter" } "Test_SetSecretAttributeAliasParameter"
    Run-TestProtected { Run-SecretTest {Test_SetSecretVersion} "Test_SetSecretVersion" } "Test_SetSecretVersion"
    Run-TestProtected { Run-SecretTest {Test_SetSecretInNonExistVault} "Test_SetSecretInNonExistVault" } "Test_SetSecretInNonExistVault"
    Run-TestProtected { Run-SecretTest {Test_SetNonExistSecret} "Test_SetNonExistSecret" } "Test_SetNonExistSecret"
    Run-TestProtected { Run-SecretTest {Test_SetInvalidSecretAttributes} "Test_SetInvalidSecretAttributes" } "Test_SetInvalidSecretAttributes"
    Run-TestProtected { Run-SecretTest {Test_SetSecretAttrInNoPermissionVault} "Test_SetSecretAttrInNoPermissionVault" } "Test_SetSecretAttrInNoPermissionVault"

    # Get-AzKeyVaultSecret tests.
    Run-TestProtected { Run-SecretTest {Test_GetOneSecret} "Test_GetOneSecret" } "Test_GetOneSecret"
    Run-TestProtected { Run-SecretTest {Test_GetAllSecrets} "Test_GetAllSecrets" } "Test_GetAllSecrets"
    Run-TestProtected { Run-SecretTest {Test_GetPreviousVersionOfSecret} "Test_GetPreviousVersionOfSecret" } "Test_GetPreviousVersionOfSecret"
    Run-TestProtected { Run-SecretTest {Test_GetSecretVersions} "Test_GetSecretVersions" } "Test_GetSecretVersions"
    Run-TestProtected { Run-SecretTest {Test_GetSecretPositionalParameter} "Test_GetSecretPositionalParameter" } "Test_GetSecretPositionalParameter"
    Run-TestProtected { Run-SecretTest {Test_GetSecretAliasParameter} "Test_GetSecretAliasParameter" } "Test_GetSecretAliasParameter"
    Run-TestProtected { Run-SecretTest {Test_GetSecretInNonExistVault} "Test_GetSecretInNonExistVault" } "Test_GetSecretInNonExistVault"
    Run-TestProtected { Run-SecretTest {Test_GetNonExistSecret} "Test_GetNonExistSecret" } "Test_GetNonExistSecret"
    Run-TestProtected { Run-SecretTest {Test_GetSecretInNoPermissionVault} "Test_GetSecretInNoPermissionVault" } "Test_GetSecretInNoPermissionVault"

    # Remove-AzKeyVaultSecret tests.
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretWithoutPrompt} "Test_RemoveSecretWithoutPrompt" } "Test_RemoveSecretWithoutPrompt"
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretWhatIf} "Test_RemoveSecretWhatIf" } "Test_RemoveSecretWhatIf"
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretPositionalParameter} "Test_RemoveSecretPositionalParameter" } "Test_RemoveSecretPositionalParameter"
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretAliasParameter} "Test_RemoveSecretAliasParameter" } "Test_RemoveSecretAliasParameter"
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretInNonExistVault} "Test_RemoveSecretInNonExistVault" } "Test_RemoveSecretInNonExistVault"
    Run-TestProtected { Run-SecretTest {Test_RemoveNonExistSecret} "Test_RemoveNonExistSecret" } "Test_RemoveNonExistSecret"
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretInNoPermissionVault} "Test_RemoveSecretInNoPermissionVault" } "Test_RemoveSecretInNoPermissionVault"

    # Backup-AzKeyVaultSecret and Restore-AzKeyVaultSecret tests.
    Run-TestProtected { Run-SecretTest {Test_BackupRestoreSecretByName} "Test_BackupRestoreSecretByName" } "Test_BackupRestoreSecretByName"
    Run-TestProtected { Run-SecretTest {Test_BackupRestoreSecretByRef} "Test_BackupRestoreSecretByRef" } "Test_BackupRestoreSecretByRef"
    Run-TestProtected { Run-SecretTest {Test_BackupNonExistingSecret} "Test_BackupNonExistingSecret" } "Test_BackupNonExistingSecret"
    Run-TestProtected { Run-SecretTest {Test_BackupSecretToANamedFile} "Test_BackupSecretToANamedFile" } "Test_BackupSecretToANamedFile"
    Run-TestProtected { Run-SecretTest {Test_BackupSecretToExistingFile} "Test_BackupSecretToExistingFile" } "Test_BackupSecretToExistingFile"
    Run-TestProtected { Run-SecretTest {Test_RestoreSecretFromNonExistingFile} "Test_RestoreSecretFromNonExistingFile" } "Test_RestoreSecretFromNonExistingFile"

    # *-AzKeyVaultSecret pipeline tests.
    Run-TestProtected { Run-SecretTest {Test_PipelineUpdateSecrets} "Test_PipelineUpdateSecrets" } "Test_PipelineUpdateSecrets"
    Run-TestProtected { Run-SecretTest {Test_PipelineUpdateSecretAttributes} "Test_PipelineUpdateSecretAttributes" } "Test_PipelineUpdateSecretAttributes"
    Run-TestProtected { Run-SecretTest {Test_PipelineUpdateSecretVersions} "Test_PipelineUpdateSecretVersions" } "Test_PipelineUpdateSecretVersions"
    Run-TestProtected { Run-SecretTest {Test_PipelineRemoveSecrets} "Test_PipelineRemoveSecrets" } "Test_PipelineRemoveSecrets"

    # Import scenario : Add-AzKeyVaultCertificate tests
    Run-TestProtected { Run-CertificateTest {Test_ImportPfxAsCertificate} "Test_ImportPfxAsCertificate" } "Test_ImportPfxAsCertificate"
    Run-TestProtected { Run-CertificateTest {Test_ImportPfxAsCertificateNonSecurePassword} "Test_ImportPfxAsCertificateNonSecurePassword" } "Test_ImportPfxAsCertificateNonSecurePassword"
    Run-TestProtected { Run-CertificateTest {Test_ImportPfxAsCertificateWithoutPassword} "Test_ImportPfxAsCertificateWithoutPassword" } "Test_ImportPfxAsCertificateWithoutPassword"
    Run-TestProtected { Run-CertificateTest {Test_ImportX509Certificate2CollectionAsCertificate} "Test_ImportX509Certificate2CollectionAsCertificate" } "Test_ImportX509Certificate2CollectionAsCertificate"
    Run-TestProtected { Run-CertificateTest {Test_ImportX509Certificate2CollectionNotExportableAsCertificate} "Test_ImportX509Certificate2CollectionNotExportableAsCertificate" } "Test_ImportX509Certificate2CollectionNotExportableAsCertificate"
    Run-TestProtected { Run-CertificateTest {Test_ImportBase64EncodedStringAsCertificate} "Test_ImportBase64EncodedStringAsCertificate" } "Test_ImportBase64EncodedStringAsCertificate"
    Run-TestProtected { Run-CertificateTest {Test_ImportBase64EncodedStringWithoutPasswordAsCertificate} "Test_ImportBase64EncodedStringWithoutPasswordAsCertificate" } "Test_ImportBase64EncodedStringWithoutPasswordAsCertificate"

    # Merge scenario : Add-AzKeyVaultCertificate tests
    Run-TestProtected { Run-CertificateTest {Test_MergeCerWithNonExistantKeyPair} "Test_MergeCerWithNonExistantKeyPair" } "Test_MergeCerWithNonExistantKeyPair"
    Run-TestProtected { Run-CertificateTest {Test_MergeCerWithMismatchKeyPair} "Test_MergeCerWithMismatchKeyPair" } "Test_MergeCerWithMismatchKeyPair"

    # Get-AzKeyVaultCertificate tests
    Run-TestProtected { Run-CertificateTest {Test_GetCertificate} "Test_GetCertificate" } "Test_GetCertificate"
    Run-TestProtected { Run-CertificateTest {Test_GetCertificateNonExistant} "Test_GetCertificateNonExistant" } "Test_GetCertificateNonExistant"
    Run-TestProtected { Run-CertificateTest {Test_ListCertificates} "Test_ListCertificates" } "Test_ListCertificates"

    # Add-AzKeyVaultCertificateContact, Get-AzKeyVaultCertificateContact and Remove-AzKeyVaultCertificateContact tests
    Run-TestProtected { Run-CertificateTest {Test_AddAndGetCertificateContacts} "Test_AddAndGetCertificateContacts" } "Test_AddAndGetCertificateContacts"

    # Certificate Policy tests
    Run-TestProtected { Run-CertificateTest {Test_GetNonExistingCertificatePolicy} "Test_GetNonExistingCertificatePolicy" } "Test_GetNonExistingCertificatePolicy"
    Run-TestProtected { Run-CertificateTest {Test_NewCertificatePolicy} "Test_NewCertificatePolicy" } "Test_NewCertificatePolicy"
    Run-TestProtected { Run-CertificateTest {Test_SetCertificatePolicy} "Test_SetCertificatePolicy" } "Test_SetCertificatePolicy"

    # Certificate Issuer Organization Details tests
    Run-TestProtected { Run-CertificateTest {Test_NewOrganizationDetails} "Test_NewOrganizationDetails" } "Test_NewOrganizationDetails"

    # Certificate Issuer tests
    Run-TestProtected { Run-CertificateTest {Test_CreateAndGetTestIssuer} "Test_CreateAndGetTestIssuer" } "Test_CreateAndGetTestIssuer"

    # Add-AzKeyVaultCertificate, Get-AzKeyVaultCertificateOperation, Remove-AzKeyVaultCertificateOperation tests
    Run-TestProtected { Run-CertificateTest {Test_Add_AzureKeyVaultCertificate} "Test_Add_AzureKeyVaultCertificate" } "Test_Add_AzureKeyVaultCertificate"
    Run-TestProtected { Run-CertificateTest {Test_CertificateTags} "Test_CertificateTags" } "Test_CertificateTags"
    Run-TestProtected { Run-CertificateTest {Test_UpdateCertificateTags} "Test_UpdateCertificateTags" } "Test_UpdateCertificateTags"

   # AzureKeyVaultManagedStorageAccount, AzureKeyVaultManagedStorageSasDefinition tests
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_SetAzureKeyVaultManagedStorageAccountAndRawSasDefinition} "Test_SetAzureKeyVaultManagedStorageAccountAndRawSasDefinition" } "Test_SetAzureKeyVaultManagedStorageAccountAndRawSasDefinition"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_SetAzureKeyVaultManagedStorageAccountAndBlobSasDefinition} "Test_SetAzureKeyVaultManagedStorageAccountAndBlobSasDefinition" } "Test_SetAzureKeyVaultManagedStorageAccountAndBlobSasDefinition"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_SetAzureKeyVaultManagedStorageAccountAndBlobStoredPolicySasDefinition} "Test_SetAzureKeyVaultManagedStorageAccountAndBlobStoredPolicySasDefinition" } "Test_SetAzureKeyVaultManagedStorageAccountAndBlobStoredPolicySasDefinition"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_SetAzureKeyVaultManagedStorageAccountAndContainerSasDefinition} "Test_SetAzureKeyVaultManagedStorageAccountAndContainerSasDefinition" } "Test_SetAzureKeyVaultManagedStorageAccountAndContainerSasDefinition"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_SetAzureKeyVaultManagedStorageAccountAndShareSasDefinition} "Test_SetAzureKeyVaultManagedStorageAccountAndShareSasDefinition" } "Test_SetAzureKeyVaultManagedStorageAccountAndShareSasDefinition"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_SetAzureKeyVaultManagedStorageAccountAndFileSasDefinition} "Test_SetAzureKeyVaultManagedStorageAccountAndFileSasDefinition" } "Test_SetAzureKeyVaultManagedStorageAccountAndFileSasDefinition"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_SetAzureKeyVaultManagedStorageAccountAndQueueSasDefinition} "Test_SetAzureKeyVaultManagedStorageAccountAndQueueSasDefinition" } "Test_SetAzureKeyVaultManagedStorageAccountAndQueueSasDefinition"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_SetAzureKeyVaultManagedStorageAccountAndTableSasDefinition} "Test_SetAzureKeyVaultManagedStorageAccountAndTableSasDefinition" } "Test_SetAzureKeyVaultManagedStorageAccountAndTableSasDefinition"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_SetAzureKeyVaultManagedStorageAccountAndAccountSasDefinition} "Test_SetAzureKeyVaultManagedStorageAccountAndAccountSasDefinition" } "Test_SetAzureKeyVaultManagedStorageAccountAndAccountSasDefinition"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinitionPipeTest} "Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinitionPipeTest" } "Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinitionPipeTest"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinitionAttribute} "Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinitionAttribute" } "Test_SetAzureKeyVaultManagedStorageAccountAndSasDefinitionAttribute"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_UpdateAzureKeyVaultManagedStorageAccount} "Test_UpdateAzureKeyVaultManagedStorageAccount" } "Test_UpdateAzureKeyVaultManagedStorageAccount"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_RegenerateAzureKeyVaultManagedStorageAccountAndSasDefinition} "Test_RegenerateAzureKeyVaultManagedStorageAccountAndSasDefinition" } "Test_RegenerateAzureKeyVaultManagedStorageAccountAndSasDefinition"
    Run-TestProtected { Run-ManagedStorageAccountTest {Test_ListKeyVaultAzureKeyVaultManagedStorageAccounts} "Test_ListKeyVaultAzureKeyVaultManagedStorageAccounts" } "Test_ListKeyVaultAzureKeyVaultManagedStorageAccounts"
}

# Clean up and initialize the temporary state required to run all tests, if necessary.
Cleanup-LogFiles $PSScriptRoot
Initialize-TemporaryState
if (($Vault -ne "") -and (@('DataPlane', 'All') -contains $TestMode))
{
    Cleanup-OldCertificates
    Cleanup-OldManagedStorageAccounts
    Cleanup-OldKeys
    Cleanup-OldSecrets
}

Write-Host "Clean up and initialization completed."

$global:startTime = Get-Date

try
{
    if (@('ControlPlane', 'All') -contains $TestMode)
    {
        $oldVaultResource = Get-VaultResource
        try
        {
            Run-AllControlPlaneTests
        }
        finally
        {
            Restore-VaultResource $oldVaultResource
        }
    }

    if (@('DataPlane', 'All') -contains $TestMode)
    {
        $oldVaultResource = Get-VaultResource
        try
        {
            Run-AllDataPlaneTests
        }
        finally
        {
            Restore-VaultResource $oldVaultResource
        }
    }
}
finally
{
    Cleanup-TemporaryState ($ResourceGroup -eq "") ($Vault -eq "")
}

$global:endTime = Get-Date

# Report.
Write-FileReport
Write-ConsoleReport

# Post run.
Move-Log $PSScriptRoot