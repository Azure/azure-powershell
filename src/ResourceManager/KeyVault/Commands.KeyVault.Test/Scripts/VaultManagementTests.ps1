$tagName = "testtag"
$tagValue = "testvalue"
$KeyVaultResourceType = "Microsoft.KeyVault/vaults"
$KeyVaultApiVersion = "2015-06-01"

#------------------------------New-AzureRmKeyVault--------------------------------------
function Test_CreateNewVault
{
    Test-CreateNewVault $global:resourceGroupName $global:location $tagName $tagValue
}

function Test_CreateNewPremiumVaultEnabledForDeployment
{
    Test-CreateNewPremiumVaultEnabledForDeployment $global:resourceGroupName $global:location
}

function Test_RecreateVaultFails
{
    Test-RecreateVaultFails $global:testVault $global:resourceGroupName $global:location
}

function Test_CreateVaultInUnknownResGrpFails
{
    Test-CreateVaultInUnknownResGrpFails $global:location
}

function Test_CreateVaultPositionalParams
{
    Test-CreateVaultPositionalParams $global:resourceGroupName $global:location
}

#-------------------------------------------------------------------------------------

#------------------------------Get-AzureRmKeyVault--------------------------------------

function Test_GetVaultByNameAndResourceGroup
{
    Test-GetVaultByNameAndResourceGroup $global:testVault $global:resourceGroupName
}

function Test_GetVaultByNameAndResourceGroupPositionalParams
{
    Test-GetVaultByNameAndResourceGroupPositionalParams $global:testVault $global:resourceGroupName
}

function Test_GetVaultByName
{
    Test-GetVaultByName $global:testVault
}

function Test_GetUnknownVaultFails
{
    Test-GetUnknownVaultFails $global:resourceGroupName
}

function Test_GetVaultFromUnknownResourceGroupFails
{
    Test-GetVaultFromUnknownResourceGroupFails $global:testVault
}

function Test_ListVaultsByResourceGroup
{
    Test-ListVaultsByResourceGroup $global:resourceGroupName
}

function Test_ListAllVaultsInSubscription
{
    Test-ListAllVaultsInSubscription
}

function Test_ListVaultsByTag
{
    Test-ListVaultsByTag $tagName $tagValue
}

function Test_ListVaultsByUnknownResourceGroupFails
{
    Test-ListVaultsByUnknownResourceGroupFails
}


#-------------------------------------------------------------------------------------

#------------------------------Remove-AzureRmKeyVault-----------------------------------
function Test_DeleteVaultByName
{
    Test-DeleteVaultByName $global:resourceGroupName $global:location
}

function Test_DeleteUnknownVaultFails
{
    Test-DeleteUnknownVaultFails
}

#-------------------------------------------------------------------------------------

#------------------------------Set-AzureRmKeyVaultAccessPolicy--------------------------
function Test_SetRemoveAccessPolicyByUPN
{
    $user = (Get-AzureRmContext).Account.Id
    Reset-PreCreatedVault
    Test-SetRemoveAccessPolicyByUPN $global:testVault $global:resourceGroupName $user
}

function Test_SetRemoveAccessPolicyBySPN
{
    Reset-PreCreatedVault

    $sp = 'testapp'

    # Create an app and service principal.
    if (-not $global:noADCmdLetMode)
    {
        $appName = [Guid]::NewGuid().ToString("N")
        $uri = 'http://localhost:8080/'+$appName
        $app = New-AzureRmADApplication -DisplayName $appName -HomePage 'http://contoso.com' -IdentifierUris $uri -Password $appName
        $sp = New-AzureRmADServicePrincipal -ApplicationId $app.ApplicationId
    }

    try
    {
        Test-SetRemoveAccessPolicyBySPN $global:testVault $global:resourceGroupName $uri
    }
    finally
    {
        if (-not $global:noADCmdLetMode)
        {
            Remove-AzureRmADApplication -ObjectId $app.ObjectId -Force
        }
    }
}

function Test_SetRemoveAccessPolicyByObjectId
{
    Reset-PreCreatedVault
    Test-SetRemoveAccessPolicyByObjectId $global:testVault $global:resourceGroupName $global:objectId
}

function Test_SetRemoveAccessPolicyByBypassObjectIdValidation
{
    $securityGroupObjIdFromOtherTenant = [System.Guid]::NewGuid().toString()
    Reset-PreCreatedVault
    Test-SetRemoveAccessPolicyByObjectId $global:testVault $global:resourceGroupName $securityGroupObjIdFromOtherTenant -bypassObjectIdValidation
}

function Test_SetRemoveAccessPolicyByCompoundId
{
    $appId = [System.Guid]::NewGuid()
    Reset-PreCreatedVault
    Test-SetRemoveAccessPolicyByCompoundId $global:testVault $global:resourceGroupName $appId $global:objectId
}

function Test_RemoveAccessPolicyWithCompoundIdPolicies
{
    $appId1 = [System.Guid]::NewGuid()
    $appId2 = [System.Guid]::NewGuid()
    Reset-PreCreatedVault
    Test-RemoveAccessPolicyWithCompoundIdPolicies $global:testVault $global:resourceGroupName $appId1 $appId2 $global:objectId
}

function Test_SetCompoundIdAccessPolicy
{
    $appId = [System.Guid]::NewGuid()
    Reset-PreCreatedVault
    Test-SetCompoundIdAccessPolicy $global:testVault $global:resourceGroupName $appId $global:objectId
}

function Test_ModifyAccessPolicy
{
    Reset-PreCreatedVault
    Test-ModifyAccessPolicy $global:testVault $global:resourceGroupName $global:objectId
}

function Test_ModifyAccessPolicyEnabledForDeployment
{
    Reset-PreCreatedVault
    Test-ModifyAccessPolicyEnabledForDeployment $global:testVault $global:resourceGroupName
}

function Test_ModifyAccessPolicyEnabledForTemplateDeployment
{
    Reset-PreCreatedVault
    Test-ModifyAccessPolicyEnabledForTemplateDeployment $global:testVault $global:resourceGroupName
}

function Test_ModifyAccessPolicyEnabledForDiskEncryption
{
    Reset-PreCreatedVault
    Test-ModifyAccessPolicyEnabledForDiskEncryption $global:testVault $global:resourceGroupName
}

function Test_ModifyAccessPolicyNegativeCases
{
    Reset-PreCreatedVault
    Test-ModifyAccessPolicyNegativeCases $global:testVault $global:resourceGroupName $user $global:objectId
}


function Test_RemoveNonExistentAccessPolicyDoesNotThrow
{
    Reset-PreCreatedVault
    Test-RemoveNonExistentAccessPolicyDoesNotThrow $global:testVault $global:resourceGroupName $global:objectId
}
#-------------------------------------------------------------------------------------


#------------------------------Piping--------------------------

function Test_CreateDeleteVaultWithPiping
{
    Test-CreateDeleteVaultWithPiping $global:resourceGroupName $global:location
}

#-------------------------------------------------------------------------------------

#------------------------------------------Helper-------------------------------------
<#
.SYNOPSIS
Get the test vault name.

.PARAMETER suffix
The suffix to be used for the test vault name.
#>
function Get-VaultName([string]$suffix)
{
    if ($suffix -eq '')
    {
        $suffix = Get-Date -UFormat %m%d%H%M%S
    }

    return 'pshtv-' + $global:testns + '-' + $suffix
}

<#
.SYNOPSIS
Get the resource group name.

.PARAMETER suffix
The suffix to be used for the resource group name.
#>
function Get-ResourceGroupName([string]$suffix)
{
    if ($suffix -eq '')
    {
        $suffix = Get-Date -UFormat %m%d%H%M%S
    }

    return 'pshtrg-' + $global:testns + '-' + $suffix
}

<#
.SYNOPSIS
Reset the pre-created vault to the default state for the control plane tests.
#>
function Reset-PreCreatedVault
{
    $tenantId = (Get-AzureRmContext).Tenant.TenantId
    $sku = "premium"
    if ($global:standardVaultOnly)
    {
        $sku = "standard"
    }
    $vaultProperties = @{
        "enabledForDeployment" = $false
        "tenantId" = $tenantId
        "sku" = @{
            "family" = "A"
            "name" = $sku
        }
        "accessPolicies" = @()
    }

    Set-AzureRmResource -ApiVersion $KeyVaultApiVersion `
                    -ResourceType $KeyVaultResourceType `
                    -ResourceName $global:testVault `
                    -ResourceGroupName $global:resourceGroupName `
                    -PropertyObject $vaultProperties  `
                    -Tag  @{$tagName = $tagValue} `
                    -Force -Confirm:$false
}

<#
.SYNOPSIS
Initialize the temporary state required to run all tests, if necessary.
#>
function Initialize-TemporaryState
{
    $suffix = Get-Date -UFormat %m%d%H%M%S
    if ($global:resourceGroupName -eq "")
    {
        # Create a resource group.
        $rg = Get-ResourceGroupName $suffix
        New-AzureRmResourceGroup -Name $rg -Location $global:location -Force

        $global:resourceGroupName = $rg
        Write-Host "Successfully initialized the temporary resource group $global:resourceGroupName."
    }
    else
    {
        Write-Host "Skipping resource group creation since the resource group $global:resourceGroupName is already provided."
    }
    
    if ($global:testVault -ne "" -and $global:testVault -ne $null)
    {
        Write-Host "Skipping vault creation since the vault $global:testVault is already provided."
        return
    }

    # Create a vault using ARM.
    $vaultName = Get-VaultName $suffix
    $tenantId = (Get-AzureRmContext).Tenant.TenantId
    $sku = "premium"
    if ($global:standardVaultOnly)
    {
        $sku = "standard"
    }
    $vaultId = @{
        "ResourceType" = $KeyVaultResourceType
        "ApiVersion" = $KeyVaultApiVersion
        "ResourceGroupName" = $global:resourceGroupName
        "Name" = $vaultName
    }
    $vaultProperties = @{
        "enabledForDeployment" = $false
        "tenantId" = $tenantId
        "sku" = @{
            "family" = "A"
            "name" = $sku
        }
        "accessPolicies" = @(
            @{
                "tenantId" = $tenantId
                "objectId" = $objectId
                "applicationId" = ""
                "permissions" = @{
                    "keys" = @("all")
                    "secrets" = @("all")
                    "certificates" = @("all")
                }
            }
        )
    }
    $keyVault = New-AzureRmResource @vaultId `
                -PropertyObject $vaultProperties `
                -Location $global:location `
                -Tag @{$tagName = $tagValue} `
                -Force -Confirm:$false
    if ($keyVault)
    {
        $global:testVault = $vaultName
        Write-Host "Successfully initialized the temporary vault $global:testVault."
    }
    else
    {
        # Clean up before throwing.
        Remove-ResourceGroup
        Throw "Failed to initialize the temporary vault $VaultName."
    }
}

<#
.SYNOPSIS
Retrieve the current vault as a resource of type System.Management.Automation.PSCustomObject.
#>
function Get-VaultResource
{
    return Get-AzureRmResource -ResourceType $KeyVaultResourceType `
                               -ResourceGroupName $global:resourceGroupName `
                               -ResourceName $global:testVault
}

<#
.SYNOPSIS
Restore the current vault resource.

.PARAMETER oldVaultResource
The old vault resource to be restored.
#>
function Restore-VaultResource($oldVaultResource)
{
    Write-Host "Restoring the vault resource $global:testVault..."

    $oldVaultResource | Set-AzureRmResource -Force
}

<#
.SYNOPSIS
Remove the resource group under which all resources for vault tests were created.

.PARAMETER $tempResourceGroup
True if the resource group was temporary (and not provided).

.PARAMETER $tempVault
True if the vault was temporary (and not provided).
#>
function Cleanup-TemporaryState([bool]$tempResourceGroup, [bool]$tempVault)
{
    if ($tempResourceGroup)
    {
        Write-Host "Starting the deletion of the temporary resource group. This can take a few minutes..."
        $groupRemoved = Remove-AzureRmResourceGroup -Name $global:resourceGroupname -Force -Confirm:$false
        if ($groupRemoved)
        {
            $global:resourceGroupname = ""
            Write-Host "Successfully completed the deletion of the temporary resource group."
        }
        else
        {
            Throw "Failed to remove the temporary resource group $global:resourceGroupname."
        }
    }
    elseif ($tempVault)
    {
        Write-Host "Starting the deletion of the temporary vault. This can take a minute or so..."
        $vaultRemoved = Remove-AzureRmKeyVault -VaultName $global:testVault -Force -Confirm:$false
        if ($vaultRemoved)
        {
            $global:testVault = ""
            Write-Host "Successfully completed the deletion of the temporary vault."
        }
        else
        {
            Throw "Failed to remove the temporary vault $global:testVault."
        }
    }
}
#-------------------------------------------------------------------------------------