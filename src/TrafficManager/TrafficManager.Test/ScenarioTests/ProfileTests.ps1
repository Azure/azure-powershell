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
Full Profile CRUD cycle
#>
function Test-ProfileCrud
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName

	
	try
	{
	$createdProfile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -ProfileStatus "Enabled" -Tags @{ ProfileTagA="firstProfileTag"; ProfileTagB="SecondProfileTag" }
	Assert-NotNull $createdProfile
	Assert-AreEqual $profileName $createdProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdProfile.ResourceGroupName 
	Assert-AreEqual "Performance" $createdProfile.TrafficRoutingMethod

	$createdProfile = Add-AzTrafficManagerEndpointConfig -EndpointName "MyExternalEndpoint" -TrafficManagerProfile $createdProfile -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"
	$createdProfile = Set-AzTrafficManagerProfile -TrafficManagerProfile $createdProfile

	$retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
	Assert-AreEqual "MyExternalEndpoint" $retrievedProfile.Endpoints[0].Name

	Assert-NotNull $retrievedProfile
	Assert-AreEqual $profileName $retrievedProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedProfile.ResourceGroupName
	Assert-AreEqual 2 $retrievedProfile.Tags.Count

	$createdProfile.TrafficRoutingMethod = "Priority"

	$updatedProfile = Set-AzTrafficManagerProfile -TrafficManagerProfile $createdProfile

	Assert-NotNull $updatedProfile
	Assert-AreEqual $profileName $updatedProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $updatedProfile.ResourceGroupName
	Assert-AreEqual "Priority" $updatedProfile.TrafficRoutingMethod

	$removed = Remove-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName }
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Full Profile CRUD cycle
#>
function Test-ProfileCrudWithPiping
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	
	try
	{
	$createdProfile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -ProfileStatus "Enabled"

	$createdProfile.TrafficRoutingMethod = "Priority"

	$removed = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName | Set-AzTrafficManagerProfile | Remove-AzTrafficManagerProfile -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } 
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Delete a profile using the object instead of the parameters
#>
function Test-CreateDeleteUsingProfile
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	
	try
	{
	$createdProfile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -ProfileStatus "Enabled"

	Assert-NotNull $createdProfile
	Assert-AreEqual $profileName $createdProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdProfile.ResourceGroupName 
	Assert-AreEqual "Performance" $createdProfile.TrafficRoutingMethod

	Remove-AzTrafficManagerProfile -TrafficManagerProfile $createdProfile -Force

	Assert-Throws { Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } 
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Full cycle to create an Endpoint in a Profile
#>
function Test-CrudWithEndpoint
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	
	try
	{
	$createdProfile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -ProfileStatus "Enabled"

	$createdEndpoint = New-AzTrafficManagerEndpoint -Name "MyExternalEndpoint" -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

	$updatedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName
	
	Assert-AreEqual 1 $updatedProfile.Endpoints.Count
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Full cycle to create an Endpoint in a Profile
#>
function Test-CrudWithEndpointGeo
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	
	try
	{
	$createdProfile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Geographic" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -ProfileStatus "Enabled"

	$createdEndpoint = New-AzTrafficManagerEndpoint -Name "MyExternalEndpoint" -ProfileName $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -GeoMapping "RE","RO","RU","RW" -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" 

	$updatedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-AreEqual 1 $updatedProfile.Endpoints.Count

	$retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-AreEqual "Geographic" $retrievedProfile.TrafficRoutingMethod
	Assert-AreEqual 1 $retrievedProfile.Endpoints.Count
	Assert-AreEqual 4 $retrievedProfile.Endpoints[0].GeoMapping.Count
	Assert-AreEqual "RE" $retrievedProfile.Endpoints[0].GeoMapping[0]
	Assert-AreEqual "RO" $retrievedProfile.Endpoints[0].GeoMapping[1]
	Assert-AreEqual "RU" $retrievedProfile.Endpoints[0].GeoMapping[2]
	Assert-AreEqual "RW" $retrievedProfile.Endpoints[0].GeoMapping[3]
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
List profiles in resource group
#>
function Test-ListProfilesInResourceGroup
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	
	try
	{
	$createdProfile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -ProfileStatus "Enabled"

	$profiles = Get-AzTrafficManagerProfile -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-AreEqual 1 $profiles.Count
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
List profiles in subscription
#>
function Test-ListProfilesInSubscription
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	
	try
	{
	$createdProfile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -ProfileStatus "Enabled"

	$profiles = Get-AzTrafficManagerProfile

	Assert-NotNull $profiles
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
List profiles in resource group and pipe results to where-object. VSO#942574
Also assert on the return type to prevent silent change
#>
function Test-ListProfilesWhereObject
{
	$resourceGroup = TestSetup-CreateResourceGroup

	$profileName1 = getAssetName
	$relativeName1 = getAssetName
	$profileName2 = getAssetName
	$relativeName2 = getAssetName
		
	
	try
	{
	$createdProfile = New-AzTrafficManagerProfile -Name $profileName1 -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName1 -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -ProfileStatus "Enabled"
	$createdProfile = New-AzTrafficManagerProfile -Name $profileName2 -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName2 -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -ProfileStatus "Enabled"

	$profiles = Get-AzTrafficManagerProfile -ResourceGroupName $resourceGroup.ResourceGroupName
	Assert-AreEqual System.Object[] $profiles.GetType()

	$profile2 = $profiles | where-object {$_.Name -eq $profileName2}

	Assert-AreEqual $profileName2 $profile2.Name
	Assert-AreEqual $relativeName2 $profile2.RelativeDnsName
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Create a Profile that already exists
#>
function Test-ProfileNewAlreadyExists
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$profileName = getAssetName

    
	try
	{
	$createdProfile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName
	$resourceGroupName = $createdProfile.ResourceGroupName

	Assert-NotNull $createdProfile
	
	Assert-Throws { TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName } 

	$createdProfile | Remove-AzTrafficManagerProfile -Force
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Remove a Profile that does not exist
#>
function Test-ProfileRemoveNonExisting
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	
	try
	{
	$removed = Remove-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force 
	Assert-False { $removed }
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Enable existing disabled profile
#>
function Test-ProfileEnable
{
	$profileName = getAssetName
	$relativeName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	
	try
	{
	$disabledProfile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Disabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp"
	Assert-AreEqual "Disabled" $disabledProfile.ProfileStatus

    Assert-True { Enable-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName }

    $updatedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual "Enabled" $updatedProfile.ProfileStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Enable existing disabled profile using pipeline
#>
function Test-ProfileEnablePipeline
{
	$profileName = getAssetName
	$relativeName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	
	try
	{
	$disabledProfile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Disabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp"
	Assert-AreEqual "Disabled" $disabledProfile.ProfileStatus

    Assert-True { Enable-AzTrafficManagerProfile -TrafficManagerProfile $disabledProfile }

    $updatedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual "Enabled" $updatedProfile.ProfileStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Enable non existing profile
#>
function Test-ProfileEnableNonExisting
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup

    
	try
	{
	Assert-Throws { Enable-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } 
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Disable existing disabled profile
#>
function Test-ProfileDisable
{
	$profileName = getAssetName
	$relativeName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	
	try
	{
	$enabledProfile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Enabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
	
	Assert-AreEqual "Enabled" $enabledProfile.ProfileStatus

    Assert-True { Disable-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force }

    $updatedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual "Disabled" $updatedProfile.ProfileStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Disable existing disabled profile using pipeline
#>
function Test-ProfileDisablePipeline
{
	$profileName = getAssetName
	$relativeName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	
	try
	{
	$enabledProfile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Enabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
	Assert-AreEqual "Enabled" $enabledProfile.ProfileStatus

    Assert-True { Disable-AzTrafficManagerProfile -TrafficManagerProfile $enabledProfile -Force }

    $updatedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual "Disabled" $updatedProfile.ProfileStatus
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Disable non existing profile
#>
function Test-ProfileDisableNonExisting
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup

	try
	{
	Assert-Throws { Disable-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force } 
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Create profile without specifying optional Monitor settings
#>
function Test-ProfileMonitorDefaults
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	
	try
	{
	$createdProfile = New-AzTrafficManagerProfile -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -Ttl 30 -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -TrafficRoutingMethod "Weighted" -ProfileStatus "Enabled"

	Assert-NotNull $createdProfile
	Assert-AreEqual 30 $createdProfile.MonitorIntervalInSeconds 
	Assert-AreEqual 10 $createdProfile.MonitorTimeoutInSeconds 
	Assert-AreEqual 3 $createdProfile.MonitorToleratedNumberOfFailures

	$retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedProfile
	Assert-AreEqual 30 $retrievedProfile.MonitorIntervalInSeconds 
	Assert-AreEqual 10 $retrievedProfile.MonitorTimeoutInSeconds 
	Assert-AreEqual 3 $retrievedProfile.MonitorToleratedNumberOfFailures

	Remove-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Create profile specifying optional Monitor settings
#>
function Test-ProfileMonitorCustom
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	
	try
	{
	$createdProfile = New-AzTrafficManagerProfile -MonitorIntervalInSeconds 10 -MonitorTimeoutInSeconds 7 -MonitorToleratedNumberOfFailures 1 -Ttl 0 -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -TrafficRoutingMethod "Weighted" -ProfileStatus "Enabled"

	Assert-NotNull $createdProfile
	Assert-AreEqual 10 $createdProfile.MonitorIntervalInSeconds 
	Assert-AreEqual 7 $createdProfile.MonitorTimeoutInSeconds 
	Assert-AreEqual 1 $createdProfile.MonitorToleratedNumberOfFailures
	Assert-AreEqual 0 $createdProfile.Ttl

	$retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedProfile
	Assert-AreEqual 10 $retrievedProfile.MonitorIntervalInSeconds 
	Assert-AreEqual 7 $retrievedProfile.MonitorTimeoutInSeconds 
	Assert-AreEqual 1 $retrievedProfile.MonitorToleratedNumberOfFailures
	Assert-AreEqual 0 $retrievedProfile.Ttl 

    $retrievedProfile.MonitorIntervalInSeconds = 30
	$retrievedProfile.MonitorTimeoutInSeconds = 8
	$retrievedProfile.MonitorToleratedNumberOfFailures = 0
	$retrievedProfile.Ttl = 5

	$updatedProfile = Set-AzTrafficManagerProfile -TrafficManagerProfile $retrievedProfile

	Assert-NotNull $updatedProfile
	Assert-AreEqual 30 $updatedProfile.MonitorIntervalInSeconds 
	Assert-AreEqual 8 $updatedProfile.MonitorTimeoutInSeconds 
	Assert-AreEqual 0 $updatedProfile.MonitorToleratedNumberOfFailures
	Assert-AreEqual 5 $updatedProfile.Ttl 

	Remove-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Create profile specifying TCP Monitor Protocol
#>
function Test-ProfileMonitorProtocol
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName

	try
	{
	$createdProfile = New-AzTrafficManagerProfile -MonitorProtocol "TCP" -MonitorPort 8080 -Ttl 50 -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -TrafficRoutingMethod "Weighted" -ProfileStatus "Enabled"

	Assert-NotNull $createdProfile
	Assert-AreEqual "TCP" $createdProfile.MonitorProtocol 
	Assert-AreEqual 8080 $createdProfile.MonitorPort 
	Assert-Null $createdProfile.MonitorPath

	$retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedProfile
	Assert-AreEqual "TCP" $retrievedProfile.MonitorProtocol 
	Assert-AreEqual 8080 $retrievedProfile.MonitorPort 
	Assert-Null $retrievedProfile.MonitorPath

    $retrievedProfile.MonitorPort = 81
	$retrievedProfile.MonitorProtocol = "HTTP"
	$retrievedProfile.MonitorPath = "/health.htm"

	$updatedProfile = Set-AzTrafficManagerProfile -TrafficManagerProfile $retrievedProfile

	Assert-NotNull $updatedProfile
	Assert-AreEqual "HTTP" $updatedProfile.MonitorProtocol 
	Assert-AreEqual 81 $updatedProfile.MonitorPort 
	Assert-AreEqual "/health.htm" $retrievedProfile.MonitorPath

    $updatedProfile.MonitorPort = 8086
	$updatedProfile.MonitorProtocol = "TCP"
	$updatedProfile.MonitorPath = $null

	$revertedProfile = Set-AzTrafficManagerProfile -TrafficManagerProfile $updatedProfile

	Assert-NotNull $revertedProfile
	Assert-AreEqual "TCP" $revertedProfile.MonitorProtocol 
	Assert-AreEqual 8086 $revertedProfile.MonitorPort 

	Assert-True { Remove-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force }
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Create profile specifying optional Monitor settings
#>
function Test-ProfileMonitorParameterAliases
{
	$profileName = getAssetName
	$resourceGroup = TestSetup-CreateResourceGroup
	$relativeName = getAssetName
	
	try
	{
		$createdProfile = New-AzTrafficManagerProfile -ProtocolForMonitor "HTTPS" -PortForMonitor 85 -PathForMonitor "/test" -IntervalInSecondsForMonitor 10 -TimeoutInSecondsForMonitor 9 -ToleratedNumberOfFailuresForMonitor 5 -Ttl 1 -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -TrafficRoutingMethod "Weighted" -ProfileStatus "Enabled"

		Assert-NotNull $createdProfile
		Assert-AreEqual "HTTPS" $createdProfile.MonitorProtocol
		Assert-AreEqual "85" $createdProfile.MonitorPort
		Assert-AreEqual "/test" $createdProfile.MonitorPath
		Assert-AreEqual 10 $createdProfile.MonitorIntervalInSeconds 
		Assert-AreEqual 9 $createdProfile.MonitorTimeoutInSeconds 
		Assert-AreEqual 5 $createdProfile.MonitorToleratedNumberOfFailures
		Assert-AreEqual 1 $createdProfile.Ttl

		$retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

		Assert-NotNull $retrievedProfile
		Assert-AreEqual "HTTPS" $retrievedProfile.MonitorProtocol
		Assert-AreEqual "85" $retrievedProfile.MonitorPort
		Assert-AreEqual "/test" $retrievedProfile.MonitorPath
		Assert-AreEqual 10 $retrievedProfile.MonitorIntervalInSeconds 
		Assert-AreEqual 9 $retrievedProfile.MonitorTimeoutInSeconds 
		Assert-AreEqual 5 $retrievedProfile.MonitorToleratedNumberOfFailures
		Assert-AreEqual 1 $retrievedProfile.Ttl
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Add and remove profile-level custom headers
#>
function Test-AddAndRemoveCustomHeadersFromProfile
{
	$profileName = getAssetName
	$relativeName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	try
	{
	$profile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Disabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp"

    $retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Add-AzTrafficManagerCustomHeaderToProfile -Name "profileHeaderNameA" -Value "profileHeaderValueA" -TrafficManagerProfile $profile
	Add-AzTrafficManagerCustomHeaderToProfile -Name "profileHeaderNameB" -Value "profileHeaderValueB" -TrafficManagerProfile $profile
	Set-AzTrafficManagerProfile -TrafficManagerProfile $profile
	$retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual 2 $retrievedProfile.CustomHeaders.Count
	Assert-AreEqual "profileHeaderNameA" $retrievedProfile.CustomHeaders[0].Name
	Assert-AreEqual "profileHeaderValueA" $retrievedProfile.CustomHeaders[0].Value
	Assert-AreEqual "profileHeaderNameB" $retrievedProfile.CustomHeaders[1].Name
	Assert-AreEqual "profileHeaderValueB" $retrievedProfile.CustomHeaders[1].Value

	Assert-True { Remove-AzTrafficManagerCustomHeaderFromProfile -Name "profileHeaderNameB"  -TrafficManagerProfile $retrievedProfile }
	Set-AzTrafficManagerProfile -TrafficManagerProfile $retrievedProfile
	$retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual 1 $retrievedProfile.CustomHeaders.Count
	Assert-AreEqual "profileHeaderNameA" $retrievedProfile.CustomHeaders[0].Name
	Assert-AreEqual "profileHeaderValueA" $retrievedProfile.CustomHeaders[0].Value
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}

<#
.SYNOPSIS
Add and remove expected status code ranges
#>
function Test-AddAndRemoveExpectedStatusCodeRanges
{
	$profileName = getAssetName
	$relativeName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	try
	{
	$profile = New-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Disabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp"

    $retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Add-AzTrafficManagerExpectedStatusCodeRange -Min 200 -Max 499 -TrafficManagerProfile $profile
	Add-AzTrafficManagerExpectedStatusCodeRange -Min 502 -Max 502 -TrafficManagerProfile $profile
	Set-AzTrafficManagerProfile -TrafficManagerProfile $profile
	$retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual 2 $retrievedProfile.ExpectedStatusCodeRanges.Count
	Assert-AreEqual 200 $retrievedProfile.ExpectedStatusCodeRanges[0].Min
	Assert-AreEqual 499 $retrievedProfile.ExpectedStatusCodeRanges[0].Max
	Assert-AreEqual 502 $retrievedProfile.ExpectedStatusCodeRanges[1].Min
	Assert-AreEqual 502 $retrievedProfile.ExpectedStatusCodeRanges[1].Max

	Assert-True { Remove-AzTrafficManagerExpectedStatusCodeRange -Min 200  -TrafficManagerProfile $retrievedProfile }
	Set-AzTrafficManagerProfile -TrafficManagerProfile $retrievedProfile
	$retrievedProfile = Get-AzTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual 1 $retrievedProfile.ExpectedStatusCodeRanges.Count
	Assert-AreEqual 502 $retrievedProfile.ExpectedStatusCodeRanges[0].Min
	Assert-AreEqual 502 $retrievedProfile.ExpectedStatusCodeRanges[0].Max
	}
    finally
    {
        # Cleanup
        TestCleanup-RemoveResourceGroup $resourceGroup.ResourceGroupName
    }
}
