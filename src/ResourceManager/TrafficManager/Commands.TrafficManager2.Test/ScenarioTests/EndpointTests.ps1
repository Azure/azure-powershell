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
Full Endpoint CRUD for an endpoint in a Geographic profile
#>
function Test-EndpointCrudGeo
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Geographic"

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -GeoMapping "GEO-NA","GEO-SA"

	Assert-NotNull $endpoint
	Assert-AreEqual $endpointName $endpoint.Name 
	Assert-AreEqual $profileName $endpoint.ProfileName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $endpoint.ResourceGroupName 
	Assert-AreEqual "ExternalEndpoints" $endpoint.Type
	Assert-AreEqual "www.contoso.com" $endpoint.Target
	Assert-AreEqual "Enabled" $endpoint.EndpointStatus
	Assert-AreEqual "GEO-NA" $endpoint.GeoMapping[0];
	Assert-AreEqual "GEO-SA" $endpoint.GeoMapping[1];

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints"

	Assert-NotNull $endpoint
	Assert-AreEqual $endpointName $endpoint.Name 
	Assert-AreEqual $profileName $endpoint.ProfileName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $endpoint.ResourceGroupName 
	Assert-AreEqual "ExternalEndpoints" $endpoint.Type
	Assert-AreEqual "www.contoso.com" $endpoint.Target
	Assert-AreEqual "Enabled" $endpoint.EndpointStatus
	Assert-AreEqual "GEO-NA" $endpoint.GeoMapping[0];
	Assert-AreEqual "GEO-SA" $endpoint.GeoMapping[1];

    $endpoint.GeoMapping.Add("GEO-AP");

    $endpoint = Set-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints"

	Assert-NotNull $endpoint
	Assert-AreEqual $endpointName $endpoint.Name 
	Assert-AreEqual $profileName $endpoint.ProfileName 
	Assert-AreEqual $resourceGroup.ResourceGroupName $endpoint.ResourceGroupName 
	Assert-AreEqual "ExternalEndpoints" $endpoint.Type
	Assert-AreEqual "www.contoso.com" $endpoint.Target
	Assert-AreEqual "Enabled" $endpoint.EndpointStatus
	Assert-AreEqual "GEO-NA" $endpoint.GeoMapping[0];
	Assert-AreEqual "GEO-SA" $endpoint.GeoMapping[1];
	Assert-AreEqual "GEO-AP" $endpoint.GeoMapping[2];

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

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

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

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

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

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Disabled" -EndpointLocation "North Europe"

	Assert-AreEqual "Disabled" $endpoint.EndpointStatus

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

	Assert-True { Enable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint }

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

	Assert-AreEqual "Enabled" $endpoint.EndpointStatus
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

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Disabled" -EndpointLocation "North Europe"

	Assert-AreEqual "Disabled" $endpoint.EndpointStatus

    $retrievedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
	
	Assert-True { Enable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $retrievedProfile.Endpoints[0] }

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

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

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

<#
.SYNOPSIS
Disable Endpoint using piping
#>
function Test-EndpointTypeCaseInsensitive
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Priority"

	$type = "exTernalendpoInTS"
	$endpoint = New-AzureRmTrafficManagerEndpoint -Type $type -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"
	$type = "ExTernalendpoInTS"
	Assert-True { Disable-AzureRmTrafficManagerEndpoint -Type $type -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force }
	$type = "EXTernalendpoInTS"
	Assert-True { Enable-AzureRmTrafficManagerEndpoint -Type $type -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName }
	$type = "EXTErnalendpoInTS"
    $endpoint = Get-AzureRmTrafficManagerEndpoint -Type $type -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
	$type = "EXTERnalendpoInTS"
	$endpoint | Set-AzureRmTrafficManagerEndpoint
	$type = "EXTERNalendpoInTS"
	Remove-AzureRmTrafficManagerEndpoint -Type $type -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}

<#
.SYNOPSIS
Disable Endpoint using piping
#>
function Test-PipeEndpointFromGetEndpoint
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Priority"

	$type = "EXternalendpointS"
	New-AzureRmTrafficManagerEndpoint -Type $type -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"
	$endpoint = Get-AzureRmTrafficManagerEndpoint -Type $type -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-True { Disable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint -Force }
	Assert-True { Enable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint }
    
	Set-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint
	Remove-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint -Force
}


<#
.SYNOPSIS
Disable Endpoint using piping
#>
function Test-PipeEndpointFromGetProfile
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Priority"

	$type = "exterNAleNdpOints"
	New-AzureRmTrafficManagerEndpoint -Type $type -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"
	$profile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
	$endpoint = $profile.Endpoints[0]
	
	Assert-True { Disable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint -Force }
	Assert-True { Enable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint }
    
	Set-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint
	Remove-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint -Force
}