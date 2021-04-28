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

function Test-GetAfdSecurityPolicy
{
	# Set up required fields
    $resourceGroup = TestSetup-CreateResourceGroup
    $resourceGroupName = $resourceGroup.ResourceGroupName
	$profileName = getAssetName

	 # Profile specific properties
    $profileSku = "Standard_AzureFrontDoor"

    # Create a Microsoft AFD Profile
    $profile = New-AzFrontDoorCdnProfile -ResourceGroupName $resourceGroupName -ProfileName $profileName -Sku $profileSku

    $securityPolicyName = getAssetName

    Assert-ThrowsContains { Get-AzFrontDoorCdnSecurityPolicy -ResourceGroupName $resourceGroupName -ProfileName $profileName -SecurityPolicyName $securityPolicyName } "NotFound"

    Remove-AzResourceGroup -Name $resourceGroup.ResourceGroupName -Force
}

