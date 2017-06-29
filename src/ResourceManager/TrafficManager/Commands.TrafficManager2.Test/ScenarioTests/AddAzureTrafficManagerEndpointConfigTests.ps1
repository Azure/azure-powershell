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
Add an endpoint to an existing profile
#>
function Test-AddEndpoint
{
	$endpointName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup
	$profileName = getAssetname

	try
	{
		$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

		Add-AzureRmTrafficManagerEndpointConfig -EndpointName $endpointName -TrafficManagerProfile $profile -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

		Assert-AreEqual 1 $profile.Endpoints.Count
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}