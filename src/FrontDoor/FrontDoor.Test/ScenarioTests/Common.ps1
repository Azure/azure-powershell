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
Gets valid resource group name
#>
function Get-ResourceGroupName
{
    return getAssetName
}

<#
.SYNOPSIS
Gets valid resource name
#>
function Get-ResourceName
{
    return getAssetName
}

<#
.SYNOPSIS
Creates a resource group to use in tests
#>
function TestSetup-CreateResourceGroup
{
    $resourceGroupName = getAssetName
    $rglocation = Get-Location "Microsoft.Resources" "resourceGroups" "West US"
    $tag = @{Owner='jingnanxu'}
    $resourceGroup = New-AzResourceGroup -Name $resourceGroupName -location $rglocation -Force -Tag $tag
    return $resourceGroup
}

<#
.SYNOPSIS
Asserts if two tags are equal
#>
function Assert-Tags($tags1, $tags2)
{
    if($tags1.count -ne $tags2.count)
    {
        throw "Tag size not equal. Tag1: $tags1.count Tag2: $tags2.count"
    }

    foreach($key in $tags1.Keys)
    {
        if($tags1[$key] -ne $tags2[$key])
        {
            throw "Tag content not equal. Key:$key Tags1:" +  $tags1[$key] + "Tags2:" + $tags2[$key]
        }
    }
}

<#
.SYNOPSIS
Disable the CustomDomain Https deployment
#>
function TestCleanUp-DisableCustomDomainHttps($resourceGroupName, $frontDoorName, $customFrontendEndpointName)
{
    $customDomain = Get-AzFrontDoorFrontendEndpoint -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name $customFrontendEndpointName
    Assert-AreEqual $customDomain.CustomHttpsProvisioningState "Enabling"
    [int]$counter = 0
    do 
    {
       Wait-Seconds 60
       $customDomain = Get-AzFrontDoorFrontendEndpoint -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name $customFrontendEndpointName
    } while ($customDomain.CustomHttpsProvisioningState -ne "Enabled" -and $counter++ -lt 60)
    Assert-AreEqual $customDomain.CustomHttpsProvisioningState "Enabled"
	Assert-AreEqual $customDomain.MinimumTlsVersion "1.2"

    $customDomain = Get-AzFrontDoorFrontendEndpoint -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name $customFrontendEndpointName
    $disabledCustomDomain = $customDomain | Disable-AzFrontDoorCustomDomainHttps
    Assert-AreEqual $disabledCustomDomain.CustomHttpsProvisioningState "Disabling"
    [int]$counter = 0
    do 
    {
       Wait-Seconds 60
       $disabledCustomDomain = Get-AzFrontDoorFrontendEndpoint -ResourceGroupName $resourceGroupName -FrontDoorName $frontDoorName -Name $customFrontendEndpointName
    } while ($disabledCustomDomain.CustomHttpsProvisioningState -ne "Disabled" -and $counter++ -lt 60)
    Assert-AreEqual $disabledCustomDomain.CustomHttpsProvisioningState "Disabled"
}