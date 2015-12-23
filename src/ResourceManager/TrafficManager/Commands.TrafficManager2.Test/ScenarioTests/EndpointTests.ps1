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

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

    TestSetup-AddEndpoint $endpointName $profile

	Assert-AreEqual 1 $profile.Endpoints.Count
}

<#
.SYNOPSIS
Remove an endpoint from a profile
#>
function Test-DeleteEndpoint
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

    TestSetup-AddEndpoint $endpointName $profile

	Remove-AzureRmTrafficManagerEndpointConfig -EndpointName $endpointName -TrafficManagerProfile $profile

	Assert-AreEqual 0 $profile.Endpoints.Count
}

<#
.SYNOPSIS
Full Endpoint CRUD
#>
function Test-EndpointCrud
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

	Assert-NotNull $endpoint
	Assert-AreEqual $endpointName $endpoint.Name 
	Assert-AreEqual $profileName $endpoint.ProfileName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $endpoint.ResourceGroupName 
	Assert-AreEqual "ExternalEndpoints" $endpoint.Type
	Assert-AreEqual "www.contoso.com" $endpoint.Target
	Assert-AreEqual "Enabled" $endpoint.EndpointStatus
	<# Assert-AreEqual "North Europe" $endpoint.EndpointLocation #>

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints"

	Assert-NotNull $endpoint
	Assert-AreEqual $endpointName $endpoint.Name 
	Assert-AreEqual $profileName $endpoint.ProfileName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $endpoint.ResourceGroupName 
	Assert-AreEqual "ExternalEndpoints" $endpoint.Type
	Assert-AreEqual "www.contoso.com" $endpoint.Target
	Assert-AreEqual "Enabled" $endpoint.EndpointStatus
	<# Assert-AreEqual "North Europe" $endpoint.EndpointLocation #>

    $endpoint.EndpointStatus = "Disabled"

    $endpoint = Set-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints"

	Assert-NotNull $endpoint
	Assert-AreEqual $endpointName $endpoint.Name 
	Assert-AreEqual $profileName $endpoint.ProfileName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $endpoint.ResourceGroupName 
	Assert-AreEqual "ExternalEndpoints" $endpoint.Type
	Assert-AreEqual "www.contoso.com" $endpoint.Target
	Assert-AreEqual "Disabled" $endpoint.EndpointStatus
	<# Assert-AreEqual "North Europe" $endpoint.EndpointLocation #>

	$removed = Remove-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Force

    Assert-True { $removed }

    Assert-Throws { Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
}

<#
.SYNOPSIS
Full Endpoint CRUD with piping
#>
function Test-EndpointCrudPiping
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

	Assert-NotNull $endpoint
	Assert-AreEqual $endpointName $endpoint.Name 
	Assert-AreEqual $profileName $endpoint.ProfileName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $endpoint.ResourceGroupName 
	Assert-AreEqual "ExternalEndpoints" $endpoint.Type
	Assert-AreEqual "www.contoso.com" $endpoint.Target
	Assert-AreEqual "Enabled" $endpoint.EndpointStatus
	<# Assert-AreEqual "North Europe" $endpoint.EndpointLocation #>

    $removed = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints" | Set-AzureRmTrafficManagerEndpoint | Remove-AzureRmTrafficManagerEndpoint -Force

    Assert-True { $removed }

    Assert-Throws { Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
}

<#
.SYNOPSIS
Create existing endpoint
#>
function Test-CreateExistingEndpoint
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

    Assert-Throws { New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe" }
}

<#
.SYNOPSIS
Create endpoint non existing profile
#>
function Test-CreateExistingEndpointFromNonExistingProfile
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

    Assert-Throws { New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe" }
}

<#
.SYNOPSIS
Remove endpoint non existing profile
#>
function Test-RemoveExistingEndpointFromNonExistingProfile
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

    Assert-Throws { Remove-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
}

<#
.SYNOPSIS
Get endpoint non existing profile
#>
function Test-GetExistingEndpointFromNonExistingProfile
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

    Assert-Throws { Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
}

<#
.SYNOPSIS
Remove non existing endpoint from profile
#>
function Test-RemoveNonExistingEndpointFromProfile
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

    $profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

    Assert-Throws { Remove-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
}

<#
.SYNOPSIS
Enable Endpoint
#>
function Test-EnableEndpoint
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Disabled" -EndpointLocation "North Europe"

	Assert-AreEqual "Disabled" $endpoint.EndpointStatus

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

	Assert-True { Enable-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

	Assert-AreEqual "Enabled" $endpoint.EndpointStatus
}

<#
.SYNOPSIS
Disable Endpoint
#>
function Test-DisableEndpoint
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

	Assert-AreEqual "Enabled" $endpoint.EndpointStatus

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

	Assert-True { Disable-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Force }

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

	Assert-NotNull $endpoint
	Assert-AreEqual "Disabled" $endpoint.EndpointStatus
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

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Disabled" -EndpointLocation "North Europe"

	Assert-AreEqual "Disabled" $endpoint.EndpointStatus

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

	Assert-True { Enable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint }

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

	Assert-AreEqual "Enabled" $endpoint.EndpointStatus
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

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

	Assert-AreEqual "Enabled" $endpoint.EndpointStatus

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

	Assert-True { Disable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint -Force }

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

	Assert-NotNull $endpoint
	Assert-AreEqual "Disabled" $endpoint.EndpointStatus
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

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

	Assert-Throws { Enable-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
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

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

	Assert-Throws { Disable-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
}