# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
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

function Check-CmdletReturnType
{
    param($cmdletName, $cmdletReturn)

    $cmdletData = Get-Command $cmdletName
    Assert-NotNull $cmdletData
    [array]$cmdletReturnTypes = $cmdletData.OutputType.Name | Foreach-Object { return ($_ -replace "Microsoft.Azure.Commands.Network.Models.","") }
    [array]$cmdletReturnTypes = $cmdletReturnTypes | Foreach-Object { return ($_ -replace "System.","") }
    $realReturnType = $cmdletReturn.GetType().Name -replace "Microsoft.Azure.Commands.Network.Models.",""
    return $cmdletReturnTypes -contains $realReturnType
}

<#
.SYNOPSIS
Test creating ExpressRoutePort resource with MACsec configuration.
#>
function Test-ExpressRoutePortMacSecConfigCRUD
{
   
    # Setup
    # eastus --> Equinix-Ashburn-DC2 needed because MACsec can only be applied on juniper routers
    $rgname = Get-ResourceName
    $rglocation = "East US"
    $rname = Get-ResourceName
    $vaultName = Get-ResourceName
    $identityName = Get-ResourceName
	$resourceTypeParent = "Microsoft.Network/expressRoutePorts"
    $location = "East US"
	$peeringLocation = "Equinix-Ashburn-DC2"
	$encapsulation = "QinQ"
	$bandwidthInGbps = 10.0
    $gcmAes128Cipher = "GcmAes128"
    $cakName = "CAK"
    $cknName = "CKN"
    try
    {
        New-AzResourceGroup -Name $rgname -Location $location

        # Can't assign service principal access to key vault while deploying in dev pipeline.  
        # Service principal needs access to secret id value 
        # Solution: deploy key vault via arm template with service principal whitelisted 
        $pathToJson = ".\..\..\..\ScenarioTests\CreateKeyVaultParameters.json"
        $keyVaultParametersJson = (Get-Content $pathToJson | ConvertFrom-Json)
        $keyVaultParametersJson.tenantId.value = $tenantId
        $keyVaultParametersJson.vaultName.value = $vaultName
        $keyVaultParametersJson.secretName.value = $cakName
        $keyVaultParametersJson.secretName2.value = $cknName

        # Get tenant id for service principal whitelist 
        $context = get-azcontext
        $tenant = $context.Tenant.Id

        # hard code service principal object id -- following CMD returned null locally
        # $id = $context.Account.Id
        $servicePrincipalObjectId = "bc93052d-397e-4fba-b486-f5915bfd2a53"

        # Set service principal whitelist in ARM deployment parameters
        $keyVaultParametersJson.tenantId.value = $tenant
        $keyVaultParametersJson.objectId.value = $servicePrincipalObjectId
        $keyVaultParametersJson | ConvertTo-Json | set-content $pathToJson
        
        New-AzResourceGroupDeployment -Name $rgname -ResourceGroupName $rgname -TemplateParameterFile .\..\..\..\ScenarioTests\CreateKeyVaultParameters.json -TemplateFile .\..\..\..\ScenarioTests\CreateKeyVaultTemplate.json
        Start-Sleep -Seconds 60
        
        # Get key vault deployed via ARM 
        $keyVault = Get-AzKeyVault -VaultName $vaultName -ResourceGroupName $rgname 
        Assert-NotNull $keyVault

        # Keyvault with CAK/CKN secrets
        $MACsecCAKSecret = Get-AzKeyVaultSecret -VaultName $vaultName -Name $cakName
        $MACsecCKNSecret = Get-AzKeyVaultSecret -VaultName $vaultName -Name $cknName

        # Create ExpressRoutePort
        $vExpressRoutePort = New-AzExpressRoutePort -ResourceGroupName $rgname -Name $rname -Location $location -PeeringLocation $peeringLocation -Encapsulation $encapsulation -BandwidthInGbps $bandwidthInGbps
        Assert-NotNull $vExpressRoutePort
        Assert-True { Check-CmdletReturnType "New-AzExpressRoutePort" $vExpressRoutePort }
        Assert-NotNull $vExpressRoutePort.Links
        Assert-True { $vExpressRoutePort.Links.Count -eq 2 }
        Assert-AreEqual $rname $vExpressRoutePort.Name
        
        # Get ExpressRoutePort
        $vExpressRoutePort = Get-AzExpressRoutePort -ResourceGroupName $rgname -Name $rname
        Assert-NotNull $vExpressRoutePort
        Assert-True { Check-CmdletReturnType "Get-AzExpressRoutePort" $vExpressRoutePort }
        Assert-AreEqual $rname $vExpressRoutePort.Name

        # Create Managed Identity
        $identity = New-AzUserAssignedIdentity -Name $identityName -Location $rglocation -ResourceGroup $rgname
        
        # Set manager identity permission to keyvault
        # ERPort resource needs access to secret value and id 
        Set-AzKeyVaultAccessPolicy -VaultName $vaultName -PermissionsToSecrets get -ObjectId $identity.PrincipalId

        # Set this user identity to be used by ExpressRoute
        $erIdentity = New-AzExpressRoutePortIdentity -UserAssignedIdentityId $identity.Id
        
        # Add MACsec CAK/CKN/Cipher
        $vExpressRoutePort.Links[0].MacSecConfig.CknSecretIdentifier = $MacSecCKNSecret.Id
        $vExpressRoutePort.Links[0].MacSecConfig.CakSecretIdentifier = $MacSecCAKSecret.Id
        $vExpressRoutePort.Links[0].MacSecConfig.Cipher = $gcmAes128Cipher
        $vExpressRoutePort.Links[1].MacSecConfig.CknSecretIdentifier = $MacSecCKNSecret.Id
        $vExpressRoutePort.Links[1].MacSecConfig.CakSecretIdentifier = $MacSecCAKSecret.Id
        $vExpressRoutePort.Links[1].MacSecConfig.Cipher = $gcmAes128Cipher
        $vExpressRoutePort.identity = $erIdentity

        # Set admin state
        $vExpressRoutePort.Links[0].AdminState = "Enabled"
        $vExpressRoutePort.Links[1].AdminState = "Enabled"

        # Apply the update
		Set-AzExpressRoutePort -ExpressRoutePort $vExpressRoutePort
        
        # List ExpressRouteLinks
		$vExpressRouteLinksList = $vExpressRoutePort | Get-AzExpressRoutePortLinkConfig
		Assert-True { $vExpressRouteLinksList.Count -eq 2 }

		# Get ExpressRouteLink 1
		$vExpressRouteLink = $vExpressRoutePort | Get-AzExpressRoutePortLinkConfig -Name "Link1"
		Assert-NotNull $vExpressRouteLink;
		Assert-AreEqual $vExpressRouteLink.AdminState "Enabled"
        Assert-AreEqual $vExpressRouteLink.MacSecConfig.Cipher $gcmAes128Cipher
        Assert-Null $vExpressRouteLink.MacSecConfig.SciState

		# Get ExpressRouteLink 2
        $vExpressRouteLink = $vExpressRoutePort | Get-AzExpressRoutePortLinkConfig -Name "Link2"
		Assert-NotNull $vExpressRouteLink;
		Assert-AreEqual $vExpressRouteLink.AdminState "Enabled"  
        Assert-AreEqual $vExpressRouteLink.MacSecConfig.Cipher $gcmAes128Cipher
        Assert-Null $vExpressRouteLink.MacSecConfig.SciState

        # Remove ExpressRoutePort
        $removeExpressRoutePort = Remove-AzExpressRoutePort -ResourceGroupName $rgname -Name $rname -PassThru -Force
        Assert-AreEqual $true $removeExpressRoutePort
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}