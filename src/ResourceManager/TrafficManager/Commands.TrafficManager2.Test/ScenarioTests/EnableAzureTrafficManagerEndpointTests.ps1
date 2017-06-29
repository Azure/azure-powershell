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

<#
.SYNOPSIS
Enable Endpoint
#>
function Test-EnableEndpoint
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
		$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

		$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Disabled" -EndpointLocation "North Europe"

		Assert-AreEqual "Disabled" $endpoint.EndpointStatus

		$endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

		Assert-True { Enable-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }

		$endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

		Assert-AreEqual "Enabled" $endpoint.EndpointStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Enable Endpoint using piping
#>
function Test-EnableEndpointUsingPiping
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
		$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

		$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Disabled" -EndpointLocation "North Europe"

		Assert-AreEqual "Disabled" $endpoint.EndpointStatus

		$endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

		Assert-True { Enable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint }

		$endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

		Assert-AreEqual "Enabled" $endpoint.EndpointStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Enable Endpoint using piping
#>
function Test-EnableEndpointUsingPipingFromGetProfile
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
		$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

		$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Disabled" -EndpointLocation "North Europe"

		Assert-AreEqual "Disabled" $endpoint.EndpointStatus

		$retrievedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
	
		Assert-True { Enable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $retrievedProfile.Endpoints[0] }

		$endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

		Assert-AreEqual "Enabled" $endpoint.EndpointStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Enable non existing Endpoint
#>
function Test-EnableNonExistingEndpoint
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
		$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

		Assert-Throws { Enable-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}