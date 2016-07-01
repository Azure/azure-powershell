$tagName = "testtag"
$tagValue = "testvalue"
$KeyVaultResourceType = "Microsoft.KeyVault/vaults";
$KeyVaultApiVersion = "2015-06-01";

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
    Test-RecreateVaultFails $global:precreatedVaultName $global:resourceGroupName $global:location
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
    Test-GetVaultByNameAndResourceGroup $global:precreatedVaultName $global:resourceGroupName
}

function Test_GetVaultByNameAndResourceGroupPositionalParams
{
    Test-GetVaultByNameAndResourceGroupPositionalParams $global:precreatedVaultName $global:resourceGroupName
}

function Test_GetVaultByName
{
    Test-GetVaultByName $global:precreatedVaultName
}

function Test_GetUnknownVaultFails
{
    Test-GetUnknownVaultFails $global:resourceGroupName
}

function Test_GetVaultFromUnknownResourceGroupFails
{
    Test-GetVaultFromUnknownResourceGroupFails $global:precreatedVaultName
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
    Test-SetRemoveAccessPolicyByUPN $global:precreatedVaultName $global:resourceGroupName $user
}

function Test_SetRemoveAccessPolicyBySPN
{     
    Reset-PreCreatedVault

    $sp = 'testapp'

    #Create an app and service principal
    if (-not $global:noADCmdLetMode) {
        $appName = [Guid]::NewGuid().ToString("N")
        $uri = 'http://localhost:8080/'+$appName
        $app = New-AzureRmADApplication -DisplayName $appName -HomePage 'http://contoso.com' -IdentifierUris $uri -Password $appName
        $sp = New-AzureRmADServicePrincipal -ApplicationId $app.ApplicationId
    }

    try
    {
        Test-SetRemoveAccessPolicyBySPN $global:precreatedVaultName $global:resourceGroupName $uri
    }
    finally
    {
        if (-not $global:noADCmdLetMode) {        
            Remove-AzureRmADApplication -ApplicationObjectId $app.ApplicationObjectId -Force
        }
    }

}

function Test_SetRemoveAccessPolicyByObjectId
{
    Reset-PreCreatedVault
    Test-SetRemoveAccessPolicyByObjectId $global:precreatedVaultName $global:resourceGroupName $global:objectId
}


function Test_SetRemoveAccessPolicyByCompoundId
{
    $appId = [System.Guid]::NewGuid()
    Reset-PreCreatedVault
    Test-SetRemoveAccessPolicyByCompoundId $global:precreatedVaultName $global:resourceGroupName $appId $global:objectId
}

function Test_RemoveAccessPolicyWithCompoundIdPolicies
{
    $appId1 = [System.Guid]::NewGuid()
    $appId2 = [System.Guid]::NewGuid()
    Reset-PreCreatedVault
    Test-RemoveAccessPolicyWithCompoundIdPolicies $global:precreatedVaultName $global:resourceGroupName $appId1 $appId2 $global:objectId
}

function Test_SetCompoundIdAccessPolicy
{ 
    $appId = [System.Guid]::NewGuid()
    Reset-PreCreatedVault
    Test-SetCompoundIdAccessPolicy $global:precreatedVaultName $global:resourceGroupName $appId $global:objectId
}

function Test_ModifyAccessPolicy
{
    Reset-PreCreatedVault
    Test-ModifyAccessPolicy $global:precreatedVaultName $global:resourceGroupName $global:objectId
}

function Test_ModifyAccessPolicyEnabledForDeployment
{
    Reset-PreCreatedVault
    Test-ModifyAccessPolicyEnabledForDeployment $global:precreatedVaultName $global:resourceGroupName
}

function Test_ModifyAccessPolicyEnabledForTemplateDeployment
{
    Reset-PreCreatedVault
    Test-ModifyAccessPolicyEnabledForTemplateDeployment $global:precreatedVaultName $global:resourceGroupName
}

function Test_ModifyAccessPolicyEnabledForDiskEncryption
{
    Reset-PreCreatedVault
    Test-ModifyAccessPolicyEnabledForDiskEncryption $global:precreatedVaultName $global:resourceGroupName
}

function Test_ModifyAccessPolicyNegativeCases
{
    Reset-PreCreatedVault
    Test-ModifyAccessPolicyNegativeCases $global:precreatedVaultName $global:resourceGroupName $user $global:objectId
}


function Test_RemoveNonExistentAccessPolicyDoesNotThrow
{
    Reset-PreCreatedVault
    Test-RemoveNonExistentAccessPolicyDoesNotThrow $global:precreatedVaultName $global:resourceGroupName $global:objectId
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
Get test vault name
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
Get test vault name
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
Set up for control plane test
#>
function Initialize-VaultTest
{    
    $suffix = Get-Date -UFormat %m%d%H%M%S
    if($global:resourceGroupName -eq "")
    {
        #create a resource group
        $rg = Get-ResourceGroupName $suffix
        New-AzureRmResourceGroup -Name $rg -Location $global:location -Force
        
        $global:resourceGroupName = $rg
    }
    if($global:precreatedVaultName -ne "" -and $global:precreatedVaultName -ne $null)
    {
        Write-Host "Skipping vault creation for control plane tests since vault: $global:precreatedVaultName is already provided."
        return;
    }
    #create a vault using ARM    
    $vaultName = Get-VaultName $suffix
    $tenantId = (Get-AzureRmContext).Tenant.TenantId
    $tagName = "testtag"
    $tagValue = "testvalue"
    $sku = "premium"
    if($global:standardVaultOnly)
    {
        $sku = "standard"
    }
    $vaultId = @{
        "ResourceType" = $KeyVaultResourceType;
        "ApiVersion" = $KeyVaultApiVersion;
        "ResourceGroupName" = $global:resourceGroupName;
        "Name" = $vaultName;
    }

    $vaultProperties = @{
        "enabledForDeployment" = $false;
        "tenantId" = $tenantId;

        "sku" = @{
            "family" = "A";
            "name" = $sku;
        }
        "accessPolicies" = @();
    }    
    $keyVault = New-AzureRmResource @vaultId `
                -PropertyObject $vaultProperties `
                -Location $global:location `
                -Tag  @{Name = $tagName; Value = $tagValue} `
                -Force `
                -Confirm:$false
    if($keyVault)
    {
        $global:precreatedVaultName = $vaultName
    }
    else
    {
        Throw "Key Vault $VaultName was not created successfully. Initialization for vault tests failed."
    }
}

<#
.SYNOPSIS
Reset the pre-created vault to default state for control plane test
#>
function Reset-PreCreatedVault
{ 
    $tagName = "testtag"
    $tagValue = "testvalue"
    $tenantId = (Get-AzureRmContext).Tenant.TenantId
    $sku = "premium"
    if($global:standardVaultOnly)
    {
        $sku = "standard"
    }
    $vaultProperties = @{
        "enabledForDeployment" = $false;
        "tenantId" = $tenantId;

        "sku" = @{
            "family" = "A";
            "name" = $sku;
        }
        "accessPolicies" = @();
    } 

    Set-AzureRmResource -ApiVersion $KeyVaultApiVersion `
                    -ResourceType $KeyVaultResourceType `
                    -ResourceName $global:precreatedVaultName `
                    -ResourceGroupName $global:resourceGroupName `
                    -PropertyObject $vaultProperties  `
                    -Tag  @{Name = $tagName; Value = $tagValue} `
                    -Force `
                    -Confirm:$false
}

<#
.SYNOPSIS
Removes the resource group under which all resources for vault tests were created
#>
function Cleanup-VaultTest
{
    Remove-AzureRmResourceGroup -Name $global:resourceGroupname -Force -Confirm:$false
    $global:resourceGroupname = ''
}
#-------------------------------------------------------------------------------------