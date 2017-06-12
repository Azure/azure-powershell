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
Disable Endpoint
#>
function Test-DisableEndpoint
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
		$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

		$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

		Assert-AreEqual "Enabled" $endpoint.EndpointStatus

		$endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

		Assert-True { Disable-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Force }

		$endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

		Assert-NotNull $endpoint
		Assert-AreEqual "Disabled" $endpoint.EndpointStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Disable Endpoint using piping
#>
function Test-DisableEndpointUsingPiping
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
		$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

		$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

		Assert-AreEqual "Enabled" $endpoint.EndpointStatus

		$endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

		Assert-True { Disable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint -Force }

		$endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

		Assert-NotNull $endpoint
		Assert-AreEqual "Disabled" $endpoint.EndpointStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Disable non existing Endpoint
#>
function Test-DisableNonExistingEndpoint
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
		$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

		Assert-Throws { Disable-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}