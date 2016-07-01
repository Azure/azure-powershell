Param(
  [Parameter(Mandatory=$True,Position=0)]   
  [string]$TestRunNameSpace,
  [Parameter(Mandatory=$false,Position=1)]   
  [ValidateSet('ControlPlane','DataPlane', 'All')]
  [string]$TestMode = 'All',  
  [Parameter(Mandatory=$false,Position=2)]   
  [string]$Location = 'eastus2',
  [Parameter(Mandatory=$false, Position=3)]
  [string]$Vault = "",
  [Parameter(Mandatory=$false, Position=4)]
  [string]$ResourceGroup = "",
  [Parameter(Mandatory=$false, Position=5)]
  [bool]$StandardVaultOnly = $false,
  [Parameter(Mandatory=$false, Position=6)]
  [Guid]$UserObjectId
)

$invocationPath = Split-Path $MyInvocation.MyCommand.Definition;
. (Join-Path $invocationPath "PSHCommon\Common.ps1");
. (Join-Path $invocationPath "PSHCommon\Assert.ps1");
. (Join-Path $invocationPath "Common.ps1");
. (Join-Path $invocationPath "VaultKeyTests.ps1");
. (Join-Path $invocationPath "VaultSecretTests.ps1");
. (Join-Path $invocationPath "VaultManagementTests.ps1");
. (Join-Path $invocationPath "ControlPlane\KeyVaultManagementTests.ps1"); #shared between PSH scenario tests and KV-specific script based tests
. (Join-Path $invocationPath "ControlPlane\Common.ps1"); 

$global:totalCount = 0;
$global:passedCount = 0;
$global:passedTests = @()
$global:failedTests = @()
$global:times = @{}
$global:testEnv = 'PROD';
$global:testns = $TestRunNameSpace
$global:location = $location
$global:testVault = $Vault
$global:resourceGroupName = $ResourceGroup
$global:standardVaultOnly = $StandardVaultOnly
$global:objectId = $UserObjectId
$global:noADCmdLetMode = $false

if (-not $global:objectId)
{
    $upn = (Get-AzureRmContext).Account.Id 
    $user = Get-AzureRmADUser -UserPrincipalName $upn
    if ($user -eq $null)
    {
        $user = Get-AzureRmADUser -Mail $upn
    }
    Assert-NotNull $user
    $global:objectId = $user.Id
}

# AD powershell APIs are broken in Fairfax
if ((Get-AzureRmContext).Environment.AzureKeyVaultDnsSuffix -eq 'vault.usgovcloudapi.net')
{
    $global:noADCmdLetMode = $true
}

function Run-TestProtected
{
   param([ScriptBlock]$script, [string] $testName)
   $testStart = Get-Date
   try 
   {
     Write-Host  -ForegroundColor Green =====================================
	 Write-Host  -ForegroundColor Green "Running test $testName"
     Write-Host  -ForegroundColor Green =====================================
	 Write-Host
     &$script
	 $global:passedCount = $global:passedCount + 1
	 Write-Host
     Write-Host -ForegroundColor Green =====================================
	 Write-Host -ForegroundColor Green "Test Passed"
     Write-Host -ForegroundColor Green =====================================
	 Write-Host
	 $global:passedTests += $testName
   }
   catch
   {
     Out-String -InputObject $_.Exception | Write-Host -ForegroundColor Red
	 Write-Host
     Write-Host  -ForegroundColor Red =====================================
	 Write-Host -ForegroundColor Red "Test Failed"
     Write-Host  -ForegroundColor Red =====================================
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

function Run-AllControlPlaneTests
{
    try
    {        
        #New-AzureRmKeyVault tests
        if($global:standardVaultOnly -eq $false)
        {
          Run-TestProtected { Run-VaultTest { Test_CreateNewPremiumVaultEnabledForDeployment } "Test_CreateNewPremiumVaultEnabledForDeployment" } "Test_CreateNewPremiumVaultEnabledForDeployment"
        }
        Run-TestProtected { Run-VaultTest { Test_CreateNewVault } "Test_CreateNewVault" } "Test_CreateNewVault"
        Run-TestProtected { Run-VaultTest { Test_RecreateVaultFails } "Test_RecreateVaultFails" } "Test_RecreateVaultFails"
        Run-TestProtected { Run-VaultTest { Test_CreateVaultInUnknownResGrpFails } "Test_CreateVaultInUnknownResGrpFails" } "Test_CreateVaultInUnknownResGrpFails"
        Run-TestProtected { Run-VaultTest { Test_CreateVaultPositionalParams } "Test_CreateVaultPositionalParams" } "Test_CreateVaultPositionalParams"

        #Get-AzureRmKeyVault tests
        Run-TestProtected { Run-VaultTest { Test_GetVaultByNameAndResourceGroup } "Test_GetVaultByNameAndResourceGroup" } "Test_GetVaultByNameAndResourceGroup"
        Run-TestProtected { Run-VaultTest { Test_GetVaultByNameAndResourceGroupPositionalParams } "Test_GetVaultByNameAndResourceGroupPositionalParams" } "Test_GetVaultByNameAndResourceGroupPositionalParams"
        Run-TestProtected { Run-VaultTest { Test_GetVaultByName } "Test_GetVaultByName" } "Test_GetVaultByName"
        Run-TestProtected { Run-VaultTest { Test_GetUnknownVaultFails } "Test_GetUnknownVaultFails" } "Test_GetUnknownVaultFails"
        Run-TestProtected { Run-VaultTest { Test_GetVaultFromUnknownResourceGroupFails } "Test_GetVaultFromUnknownResourceGroupFails" } "Test_GetVaultFromUnknownResourceGroupFails"
        Run-TestProtected { Run-VaultTest { Test_ListVaultsByResourceGroup } "Test_ListVaultsByResourceGroup" } "Test_ListVaultsByResourceGroup"
        Run-TestProtected { Run-VaultTest { Test_ListAllVaultsInSubscription } "Test_ListAllVaultsInSubscription" } "Test_ListAllVaultsInSubscription"
        Run-TestProtected { Run-VaultTest { Test_ListVaultsByTag } "Test_ListVaultsByTag" } "Test_ListVaultsByTag"
        Run-TestProtected { Run-VaultTest { Test_ListVaultsByUnknownResourceGroupFails } "Test_ListVaultsByUnknownResourceGroupFails" } "Test_ListVaultsByUnknownResourceGroupFails"

        #Remove-AzureRmKeyVault tests
        Run-TestProtected { Run-VaultTest { Test_DeleteVaultByName } "Test_DeleteVaultByName" } "Test_DeleteVaultByName"
        Run-TestProtected { Run-VaultTest { Test_DeleteUnknownVaultFails } "Test_DeleteUnknownVaultFails" } "Test_DeleteUnknownVaultFails"

        #Set-AzureRmKeyVaultAccessPolicy & Remove-AzureRmKeyVaultAccessPolicy tests
        Run-TestProtected { Run-VaultTest { Test_SetRemoveAccessPolicyByUPN } "Test_SetRemoveAccessPolicyByUPN" } "Test_SetRemoveAccessPolicyByUPN"
        Run-TestProtected { Run-VaultTest { Test_SetRemoveAccessPolicyBySPN } "Test_SetRemoveAccessPolicyBySPN" } "Test_SetRemoveAccessPolicyBySPN"
        Run-TestProtected { Run-VaultTest { Test_SetRemoveAccessPolicyByObjectId } "Test_SetRemoveAccessPolicyByObjectId" } "Test_SetRemoveAccessPolicyByObjectId"
        Run-TestProtected { Run-VaultTest { Test_SetRemoveAccessPolicyByCompoundId } "Test_SetRemoveAccessPolicyByCompoundId" } "Test_SetRemoveAccessPolicyByCompoundId"
        Run-TestProtected { Run-VaultTest { Test_RemoveAccessPolicyWithCompoundIdPolicies } "Test_RemoveAccessPolicyWithCompoundIdPolicies" } "Test_RemoveAccessPolicyWithCompoundIdPolicies"
        Run-TestProtected { Run-VaultTest { Test_SetCompoundIdAccessPolicy } "Test_SetCompoundIdAccessPolicy" } "Test_SetCompoundIdAccessPolicy"
        Run-TestProtected { Run-VaultTest { Test_ModifyAccessPolicy } "Test_ModifyAccessPolicy" } "Test_ModifyAccessPolicy"
        Run-TestProtected { Run-VaultTest { Test_ModifyAccessPolicyEnabledForDeployment } "Test_ModifyAccessPolicyEnabledForDeployment" } "Test_ModifyAccessPolicyEnabledForDeployment"
        Run-TestProtected { Run-VaultTest { Test_ModifyAccessPolicyNegativeCases } "Test_ModifyAccessPolicyNegativeCases" } "Test_ModifyAccessPolicyNegativeCases"
        Run-TestProtected { Run-VaultTest { Test_RemoveNonExistentAccessPolicyDoesNotThrow } "Test_RemoveNonExistentAccessPolicyDoesNotThrow" } "Test_RemoveNonExistentAccessPolicyDoesNotThrow"

        #Piping tests
        Run-TestProtected { Run-VaultTest { Test_CreateDeleteVaultWithPiping } "Test_CreateDeleteVaultWithPiping" } "Test_CreateDeleteVaultWithPiping"

    }
    finally
    {
        if($ResourceGroup -eq "")
        {
            # only clean up if we created it.
            Write-Host Starting clean up for vault tests. This can take upto a minute or more...
            Cleanup-VaultTest
            Write-Host Completed clean up for vault tests
        }
    }
}

function Run-AllDataPlaneTests
{
    # Add-AzureKeyVaultKey tests
    Run-TestProtected { Run-KeyTest {Test_CreateSoftwareKeyWithDefaultAttributes} "Test_CreateSoftwareKeyWithDefaultAttributes" } "Test_CreateSoftwareKeyWithDefaultAttributes"
    Run-TestProtected { Run-KeyTest {Test_CreateSoftwareKeyWithCustomAttributes} "Test_CreateSoftwareKeyWithCustomAttributes" } "Test_CreateSoftwareKeyWithCustomAttributes"
    
    # All operations involving HSM keys
    if($global:standardVaultOnly -eq $false)
    {
      Run-TestProtected { Run-KeyTest {Test_CreateHsmKeyWithDefaultAttributes} "Test_CreateHsmKeyWithDefaultAttributes" } "Test_CreateHsmKeyWithDefaultAttributes"
      Run-TestProtected { Run-KeyTest {Test_CreateHsmKeyWithCustomAttributes} "Test_CreateHsmKeyWithCustomAttributes" } "Test_CreateHsmKeyWithCustomAttributes"
      Run-TestProtected { Run-KeyTest {Test_ImportPfxAsHsmWithDefaultAttributes} "Test_ImportPfxAsHsmWithDefaultAttributes" } "Test_ImportPfxAsHsmWithDefaultAttributes"
      Run-TestProtected { Run-KeyTest {Test_ImportPfxAsHsmWithCustomAttributes} "Test_ImportPfxAsHsmWithCustomAttributes" } "Test_ImportPfxAsHsmWithCustomAttributes"
      Run-TestProtected { Run-KeyTest {Test_ImportByokWithDefaultAttributes} "Test_ImportByokWithDefaultAttributes" } "Test_ImportByokWithDefaultAttributes"
      Run-TestProtected { Run-KeyTest {Test_ImportByokWith1024BitKey} "Test_ImportByokWith1024BitKey" } "Test_ImportByokWith1024BitKey"
      Run-TestProtected { Run-KeyTest {Test_ImportByokWithCustomAttributes} "Test_ImportByokWithCustomAttributes" } "Test_ImportByokWithCustomAttributes"
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

    # Set-AzureKeyVaultKeyAttribute tests
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

    # Get-AzureKeyVaultKey tests
    Run-TestProtected { Run-KeyTest {Test_GetOneKey} "Test_GetOneKey" } "Test_GetOneKey"
    Run-TestProtected { Run-KeyTest {Test_GetPreviousVersionOfKey} "Test_GetPreviousVersionOfKey" } "Test_GetPreviousVersionOfKey"
    Run-TestProtected { Run-KeyTest {Test_GetKeyPositionalParameter} "Test_GetKeyPositionalParameter" } "Test_GetKeyPositionalParameter"
    Run-TestProtected { Run-KeyTest {Test_GetKeyAliasParameter} "Test_GetKeyAliasParameter" } "Test_GetKeyAliasParameter"
    Run-TestProtected { Run-KeyTest {Test_GetKeysInNonExistVault} "Test_GetKeysInNonExistVault" } "Test_GetKeysInNonExistVault"
    Run-TestProtected { Run-KeyTest {Test_GetNonExistKey} "Test_GetNonExistKey" } "Test_GetNonExistKey"
    Run-TestProtected { Run-KeyTest {Test_GetKeyInNoPermissionVault} "Test_GetKeyInNoPermissionVault" } "Test_GetKeyInNoPermissionVault"
    Run-TestProtected { Run-KeyTest {Test_GetAllKeys} "Test_GetAllKeys" } "Test_GetAllKeys"
    Run-TestProtected { Run-KeyTest {Test_GetKeyVersions} "Test_GetKeyVersions" } "Test_GetKeyVersions"

    # Remove-AzureKeyVaultKey tests
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyWithoutPrompt} "Test_RemoveKeyWithoutPrompt" } "Test_RemoveKeyWithoutPrompt"
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyWhatIf} "Test_RemoveKeyWhatIf" } "Test_RemoveKeyWhatIf"
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyPositionalParameter} "Test_RemoveKeyPositionalParameter" } "Test_RemoveKeyPositionalParameter"
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyAliasParameter} "Test_RemoveKeyAliasParameter" } "Test_RemoveKeyAliasParameter"
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyInNonExistVault} "Test_RemoveKeyInNonExistVault" } "Test_RemoveKeyInNonExistVault"
    Run-TestProtected { Run-KeyTest {Test_RemoveNonExistKey} "Test_RemoveNonExistKey" } "Test_RemoveNonExistKey"
    Run-TestProtected { Run-KeyTest {Test_RemoveKeyInNoPermissionVault} "Test_RemoveKeyInNoPermissionVault" } "Test_RemoveKeyInNoPermissionVault"

    # Backup-AzureKeyVaultKey and Restore-AzureKeyVaultKey tests
    Run-TestProtected { Run-KeyTest {Test_BackupRestoreKey} "Test_BackupRestoreKey" } "Test_BackupRestoreKey"
    Run-TestProtected { Run-KeyTest {Test_BackupNonExisitingKey} "Test_BackupNonExisitingKey" } "Test_BackupNonExisitingKey"
    Run-TestProtected { Run-KeyTest {Test_BackupToANamedFile} "Test_BackupToANamedFile" } "Test_BackupToANamedFile"
    Run-TestProtected { Run-KeyTest {Test_BackupToExistingFile} "Test_BackupToExistingFile" } "Test_BackupToExistingFile"
    Run-TestProtected { Run-KeyTest {Test_RestoreFromNonExistingFile} "Test_RestoreFromNonExistingFile" } "Test_RestoreFromNonExistingFile"

    # *-AzureRmKeyVaultKey pipeline tests
    Run-TestProtected { Run-KeyTest {Test_PipelineUpdateKeys} "Test_PipelineUpdateKeys" } "Test_PipelineUpdateKeys"
    Run-TestProtected { Run-KeyTest {Test_PipelineRemoveKeys} "Test_PipelineRemoveKeys" } "Test_PipelineRemoveKeys"
    Run-TestProtected { Run-KeyTest {Test_PipelineUpdateKeyVersions} "Test_PipelineUpdateKeyVersions" } "Test_PipelineUpdateKeyVersions"


    # Set-AzureKeyVaultSecret tests
    Run-TestProtected { Run-SecretTest {Test_CreateSecret} "Test_CreateSecret" } "Test_CreateSecret"
    Run-TestProtected { Run-SecretTest {Test_CreateSecretWithCustomAttributes} "Test_CreateSecretWithCustomAttributes" } "Test_CreateSecretWithCustomAttributes"
    Run-TestProtected { Run-SecretTest {Test_UpdateSecret} "Test_UpdateSecret" } "Test_UpdateSecret"

    Run-TestProtected { Run-SecretTest {Test_SetSecretPositionalParameter} "Test_SetSecretPositionalParameter" } "Test_SetSecretPositionalParameter"
    Run-TestProtected { Run-SecretTest {Test_SetSecretAliasParameter} "Test_SetSecretAliasParameter" } "Test_SetSecretAliasParameter"
    Run-TestProtected { Run-SecretTest {Test_SetSecretInNonExistVault} "Test_SetSecretInNonExistVault" } "Test_SetSecretInNonExistVault"
    Run-TestProtected { Run-SecretTest {Test_SetSecretInNoPermissionVault} "Test_SetSecretInNoPermissionVault" } "Test_SetSecretInNoPermissionVault"

    # Set-AzureKeyVaultSecretAttribute tests
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

    # Get-AzureKeyVaultSecret tests
    Run-TestProtected { Run-SecretTest {Test_GetOneSecret} "Test_GetOneSecret" } "Test_GetOneSecret"
    Run-TestProtected { Run-SecretTest {Test_GetAllSecrets} "Test_GetAllSecrets" } "Test_GetAllSecrets"
    Run-TestProtected { Run-SecretTest {Test_GetPreviousVersionOfSecret} "Test_GetPreviousVersionOfSecret" } "Test_GetPreviousVersionOfSecret"
    Run-TestProtected { Run-SecretTest {Test_GetSecretVersions} "Test_GetSecretVersions" } "Test_GetSecretVersions"
    Run-TestProtected { Run-SecretTest {Test_GetSecretPositionalParameter} "Test_GetSecretPositionalParameter" } "Test_GetSecretPositionalParameter"
    Run-TestProtected { Run-SecretTest {Test_GetSecretAliasParameter} "Test_GetSecretAliasParameter" } "Test_GetSecretAliasParameter"
    Run-TestProtected { Run-SecretTest {Test_GetSecretInNonExistVault} "Test_GetSecretInNonExistVault" } "Test_GetSecretInNonExistVault"
    Run-TestProtected { Run-SecretTest {Test_GetNonExistSecret} "Test_GetNonExistSecret" } "Test_GetNonExistSecret"
    Run-TestProtected { Run-SecretTest {Test_GetSecretInNoPermissionVault} "Test_GetSecretInNoPermissionVault" } "Test_GetSecretInNoPermissionVault"

    # Remove-AzureKeyVaultSecret tests
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretWithoutPrompt} "Test_RemoveSecretWithoutPrompt" } "Test_RemoveSecretWithoutPrompt"
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretWhatIf} "Test_RemoveSecretWhatIf" } "Test_RemoveSecretWhatIf"
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretPositionalParameter} "Test_RemoveSecretPositionalParameter" } "Test_RemoveSecretPositionalParameter"
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretAliasParameter} "Test_RemoveSecretAliasParameter" } "Test_RemoveSecretAliasParameter"
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretInNonExistVault} "Test_RemoveSecretInNonExistVault" } "Test_RemoveSecretInNonExistVault"
    Run-TestProtected { Run-SecretTest {Test_RemoveNonExistSecret} "Test_RemoveNonExistSecret" } "Test_RemoveNonExistSecret"
    Run-TestProtected { Run-SecretTest {Test_RemoveSecretInNoPermissionVault} "Test_RemoveSecretInNoPermissionVault" } "Test_RemoveSecretInNoPermissionVault"

    # *-AzureRmKeyVaultKey pipeline tests
    Run-TestProtected { Run-SecretTest {Test_PipelineUpdateSecrets} "Test_PipelineUpdateSecrets" } "Test_PipelineUpdateSecrets"
    Run-TestProtected { Run-SecretTest {Test_PipelineUpdateSecretAttributes} "Test_PipelineUpdateSecretAttributes" } "Test_PipelineUpdateSecretAttributes"
    Run-TestProtected { Run-SecretTest {Test_PipelineUpdateSecretVersions} "Test_PipelineUpdateSecretVersions" } "Test_PipelineUpdateSecretVersions"
    Run-TestProtected { Run-SecretTest {Test_PipelineRemoveSecrets} "Test_PipelineRemoveSecrets" } "Test_PipelineRemoveSecrets"

}

# Initialize 
Write-Host Delete log files
Cleanup-Log $invocationPath

if (($TestMode -eq 'ControlPlane') -or ($TestMode -eq 'All'))
{
    Write-Host Initializing Vault Tests
    Initialize-VaultTest
    Write-Host The pre-created key vault for control plane test is $global:precreatedVaultName
}

if (($TestMode -eq 'DataPlane') -or ($TestMode -eq 'All'))
{
    $testkeyVault = Get-KeyVault
    Write-Host Test key vault for data plane test is $testKeyVault
    Write-Host Initializing Key Tests
    Initialize-KeyTest
    Write-Host Initializing Secret Tests
    Initialize-SecretTest
}

Write-Host Initialization Completed

$global:startTime = Get-Date
if (($TestMode -eq 'ControlPlane') -or ($TestMode -eq 'All'))
{
    Write-Host Starting Vault Tests
    Run-AllControlPlaneTests    
}

if (($TestMode -eq 'DataPlane') -or ($TestMode -eq 'All'))
{
    Write-Host Starting data plane tests
    Run-AllDataPlaneTests    
}

$global:endTime = Get-Date

# Report
Write-FileReport
Write-ConsoleReport


# Post run
Move-Log $invocationPath


