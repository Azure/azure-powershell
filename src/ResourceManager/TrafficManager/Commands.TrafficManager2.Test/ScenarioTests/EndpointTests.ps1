﻿# ----------------------------------------------------------------------------------
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

    TestSetup-AddEndpoint $endpointName $profile

	Assert-AreEqual 1 $profile.Endpoints.Count
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
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

	try
	{
	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

    TestSetup-AddEndpoint $endpointName $profile

	Remove-AzureRmTrafficManagerEndpointConfig -EndpointName $endpointName -TrafficManagerProfile $profile

	Assert-AreEqual 0 $profile.Endpoints.Count
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
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

	try
	{
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
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
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

	try
	{
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
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
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

	try
	{
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
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
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

	try
	{
	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

    Assert-Throws { New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName  -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe" }
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
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

    try
	{
	Assert-Throws { New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe" }
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
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

    try
	{
	Assert-Throws { Remove-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
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

    try
	{
	Assert-Throws { Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
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

    try
	{
	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName

    Assert-Throws { Remove-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" }
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
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

<#
.SYNOPSIS
Disable Endpoint using piping
#>
function Test-EndpointTypeCaseInsensitive
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
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
function Test-PipeEndpointFromGetEndpoint
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Priority"

	$type = "EXternalendpointS"
	New-AzureRmTrafficManagerEndpoint -Type $type -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"
	$endpoint = Get-AzureRmTrafficManagerEndpoint -Type $type -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-True { Disable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint -Force }
	Assert-True { Enable-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint }
    
	Set-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint
	Remove-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint -Force
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
function Test-PipeEndpointFromGetProfile
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
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
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Add and remove custom headers
#>
function Test-AddAndRemoveCustomHeadersFromEndpoint
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Disabled" -EndpointLocation "West US"

    $retrievedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
	
    $retrievedEndpoint = $retrievedProfile.Endpoints[0]

	Assert-True { Add-AzureRmTrafficManagerCustomHeaderToEndpoint -Name "foo" -Value "bar" -TrafficManagerEndpoint $retrievedEndpoint }

    Set-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $retrievedEndpoint

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

	Assert-AreEqual "foo" $endpoint.CustomHeaders[0].Name
	Assert-AreEqual "bar" $endpoint.CustomHeaders[0].Value
	Assert-AreEqual 1 $endpoint.CustomHeaders.Count

	Assert-True { Remove-AzureRmTrafficManagerCustomHeaderFromEndpoint -Name "foo" -TrafficManagerEndpoint $endpoint }

    Set-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

    Assert-AreEqual 0 $endpoint.CustomHeaders.Count

	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Add and remove IP address ranges
#>
function Test-AddAndRemoveIpAddressRanges
{
	$endpointName = getAssetname
	$profileName = getAssetname
	$resourceGroup = TestSetup-CreateResourceGroup

	try
	{
	$profile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName "Weighted"

	$endpoint = New-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Disabled" -EndpointLocation "West US"

    $retrievedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
	
    $retrievedEndpoint = $retrievedProfile.Endpoints[0]

	Assert-True { Add-AzureRmTrafficManagerIpAddressRange -TrafficManagerEndpoint $retrievedEndpoint -First "2.3.4.0" -Scope 24 }
	Assert-True { Add-AzureRmTrafficManagerIpAddressRange -TrafficManagerEndpoint $retrievedEndpoint -First "5.6.0.0" -Last "5.6.255.255" }

    Set-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $retrievedEndpoint

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

    Assert-AreEqual 2 $endpoint.SubnetMapping.Count
	Assert-AreEqual "2.3.4.0" $endpoint.SubnetMapping[0].First
	Assert-AreEqual 24 $endpoint.SubnetMapping[0].Scope
	Assert-AreEqual "5.6.0.0" $endpoint.SubnetMapping[1].First
	Assert-AreEqual "5.6.255.255" $endpoint.SubnetMapping[1].Last

	Assert-True { Remove-AzureRmTrafficManagerIpAddressRange -First 2.3.4.0 -TrafficManagerEndpoint $endpoint }

    Set-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $endpoint

    $endpoint = Get-AzureRmTrafficManagerEndpoint -Name $endpointName -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints"

    Assert-AreEqual 1 $endpoint.SubnetMapping.Count
	Assert-AreEqual "5.6.0.0" $endpoint.SubnetMapping[0].First
	Assert-AreEqual "5.6.255.255" $endpoint.SubnetMapping[0].Last
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}