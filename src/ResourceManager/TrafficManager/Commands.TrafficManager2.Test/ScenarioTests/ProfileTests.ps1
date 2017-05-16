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
	$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

	Assert-NotNull $createdProfile
	Assert-AreEqual $profileName $createdProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdProfile.ResourceGroupName 
	Assert-AreEqual "Performance" $createdProfile.TrafficRoutingMethod

	$retrievedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedProfile
	Assert-AreEqual $profileName $retrievedProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $retrievedProfile.ResourceGroupName

	$createdProfile.TrafficRoutingMethod = "Priority"

	$updatedProfile = Set-AzureRmTrafficManagerProfile -TrafficManagerProfile $createdProfile

	Assert-NotNull $updatedProfile
	Assert-AreEqual $profileName $updatedProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $updatedProfile.ResourceGroupName
	Assert-AreEqual "Priority" $updatedProfile.TrafficRoutingMethod

	$removed = Remove-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName }
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
	$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

	$createdProfile.TrafficRoutingMethod = "Priority"

	$removed = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName | Set-AzureRmTrafficManagerProfile | Remove-AzureRmTrafficManagerProfile -Force

	Assert-True { $removed }

	Assert-Throws { Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } 
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
	$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

	Assert-NotNull $createdProfile
	Assert-AreEqual $profileName $createdProfile.Name 
	Assert-AreEqual $resourceGroup.ResourceGroupName $createdProfile.ResourceGroupName 
	Assert-AreEqual "Performance" $createdProfile.TrafficRoutingMethod

	Remove-AzureRmTrafficManagerProfile -TrafficManagerProfile $createdProfile -Force

	Assert-Throws { Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } 
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
	$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

	$profileWithEndpoint = Add-AzureRmTrafficManagerEndpointConfig -EndpointName "MyExternalEndpoint" -TrafficManagerProfile $createdProfile -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" -EndpointLocation "North Europe"

	$updatedProfile = Set-AzureRmTrafficManagerProfile -TrafficManagerProfile $profileWithEndpoint

	Assert-AreEqual 1 $updatedProfile.Endpoints.Count
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
	$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Geographic" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

	$profileWithEndpoint = Add-AzureRmTrafficManagerEndpointConfig -GeoMapping "RE","RO","RU","RW" -EndpointName "MyExternalEndpoint" -TrafficManagerProfile $createdProfile -Type "ExternalEndpoints" -Target "www.contoso.com" -EndpointStatus "Enabled" 

	$updatedProfile = Set-AzureRmTrafficManagerProfile -TrafficManagerProfile $profileWithEndpoint

	Assert-AreEqual 1 $updatedProfile.Endpoints.Count

	$retrievedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-AreEqual "Geographic" $retrievedProfile.TrafficRoutingMethod
	Assert-AreEqual 1 $retrievedProfile.Endpoints.Count
	Assert-AreEqual 4 $retrievedProfile.Endpoints[0].GeoMapping.Count
	Assert-AreEqual "RE" $retrievedProfile.Endpoints[0].GeoMapping[0]
	Assert-AreEqual "RO" $retrievedProfile.Endpoints[0].GeoMapping[1]
	Assert-AreEqual "RU" $retrievedProfile.Endpoints[0].GeoMapping[2]
	Assert-AreEqual "RW" $retrievedProfile.Endpoints[0].GeoMapping[3]
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
	$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

	$profiles = Get-AzureRmTrafficManagerProfile -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-AreEqual 1 $profiles.Count
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
	$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

	$profiles = Get-AzureRmTrafficManagerProfile

	Assert-NotNull $profiles
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
		
	$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName1 -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName1 -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
	$createdProfile = New-AzureRmTrafficManagerProfile -Name $profileName2 -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName2 -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 

	$profiles = Get-AzureRmTrafficManagerProfile -ResourceGroupName $resourceGroup.ResourceGroupName
	Assert-AreEqual System.Object[] $profiles.GetType()

	$profile2 = $profiles | where-object {$_.Name -eq $profileName2}

	Assert-AreEqual $profileName2 $profile2.Name
	Assert-AreEqual $relativeName2 $profile2.RelativeDnsName
}

<#
.SYNOPSIS
Create a Profile that already exists
#>
function Test-ProfileNewAlreadyExists
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$profileName = getAssetName

    $createdProfile = TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName
	$resourceGroupName = $createdProfile.ResourceGroupName

	Assert-NotNull $createdProfile
	
	Assert-Throws { TestSetup-CreateProfile $profileName $resourceGroup.ResourceGroupName } 

	$createdProfile | Remove-AzureRmTrafficManagerProfile -Force
}

<#
.SYNOPSIS
Remove a Profile that does not exist
#>
function Test-ProfileRemoveNonExisting
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup
	
	$removed = Remove-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force 
	Assert-False { $removed }
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
	
	$disabledProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Disabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
	Assert-AreEqual "Disabled" $disabledProfile.ProfileStatus

    Assert-True { Enable-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName }

    $updatedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual "Enabled" $updatedProfile.ProfileStatus
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
	
	$disabledProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Disabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
	Assert-AreEqual "Disabled" $disabledProfile.ProfileStatus

    Assert-True { Enable-AzureRmTrafficManagerProfile -TrafficManagerProfile $disabledProfile }

    $updatedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual "Enabled" $updatedProfile.ProfileStatus
}

<#
.SYNOPSIS
Enable non existing profile
#>
function Test-ProfileEnableNonExisting
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup

    Assert-Throws { Enable-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName } 
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
	
	$enabledProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Enabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
	
	Assert-AreEqual "Enabled" $enabledProfile.ProfileStatus

    Assert-True { Disable-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force }

    $updatedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual "Disabled" $updatedProfile.ProfileStatus
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
	
	$enabledProfile = New-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -ProfileStatus "Enabled" -RelativeDnsName $relativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
	Assert-AreEqual "Enabled" $enabledProfile.ProfileStatus

    Assert-True { Disable-AzureRmTrafficManagerProfile -TrafficManagerProfile $enabledProfile -Force }

    $updatedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-AreEqual "Disabled" $updatedProfile.ProfileStatus
}

<#
.SYNOPSIS
Disable non existing profile
#>
function Test-ProfileDisableNonExisting
{
	$profileName = getAssetName
    $resourceGroup = TestSetup-CreateResourceGroup

    Assert-Throws { Disable-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force } 
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
	$createdProfile = New-AzureRmTrafficManagerProfile -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -Ttl 30 -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -TrafficRoutingMethod "Weighted"  

	Assert-NotNull $createdProfile
	Assert-AreEqual 30 $createdProfile.MonitorInterval 
	Assert-AreEqual 10 $createdProfile.MonitorTimeout 
	Assert-AreEqual 3 $createdProfile.MonitorToleratedNumberOfFailures

	$retrievedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedProfile
	Assert-AreEqual 30 $retrievedProfile.MonitorInterval 
	Assert-AreEqual 10 $retrievedProfile.MonitorTimeout 
	Assert-AreEqual 3 $retrievedProfile.MonitorToleratedNumberOfFailures

	Remove-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
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
	$createdProfile = New-AzureRmTrafficManagerProfile -MonitorInterval 10 -MonitorTimeout 7 -MonitorToleratedNumberOfFailures 1 -Ttl 0 -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -TrafficRoutingMethod "Weighted"  

	Assert-NotNull $createdProfile
	Assert-AreEqual 10 $createdProfile.MonitorInterval 
	Assert-AreEqual 7 $createdProfile.MonitorTimeout 
	Assert-AreEqual 1 $createdProfile.MonitorToleratedNumberOfFailures
	Assert-AreEqual 0 $createdProfile.Ttl

	$retrievedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedProfile
	Assert-AreEqual 10 $retrievedProfile.MonitorInterval 
	Assert-AreEqual 7 $retrievedProfile.MonitorTimeout 
	Assert-AreEqual 1 $retrievedProfile.MonitorToleratedNumberOfFailures
	Assert-AreEqual 0 $retrievedProfile.Ttl 

    $retrievedProfile.MonitorInterval = 30
	$retrievedProfile.MonitorTimeout = 8
	$retrievedProfile.MonitorToleratedNumberOfFailures = 0
	$retrievedProfile.Ttl = 5

	$updatedProfile = Set-AzureRmTrafficManagerProfile -TrafficManagerProfile $retrievedProfile

	Assert-NotNull $updatedProfile
	Assert-AreEqual 30 $updatedProfile.MonitorInterval 
	Assert-AreEqual 8 $updatedProfile.MonitorTimeout 
	Assert-AreEqual 0 $updatedProfile.MonitorToleratedNumberOfFailures
	Assert-AreEqual 5 $updatedProfile.Ttl 

	Remove-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
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
	$createdProfile = New-AzureRmTrafficManagerProfile -MonitorProtocol "TCP" -MonitorPort 8080 -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $relativeName -TrafficRoutingMethod "Weighted"

	Assert-NotNull $createdProfile
	Assert-AreEqual "TCP" $createdProfile.MonitorProtocol 
	Assert-AreEqual 8080 $createdProfile.MonitorPort 
	Assert-Null $createdProfile.MonitorPath

	$retrievedProfile = Get-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedProfile
	Assert-AreEqual "TCP" $retrievedProfile.MonitorProtocol 
	Assert-AreEqual 8080 $retrievedProfile.MonitorPort 
	Assert-Null $retrievedProfile.MonitorPath

    $retrievedProfile.MonitorPort = 81
	$retrievedProfile.MonitorProtocol = HTTP
	$retrievedProfile.MonitorPath = "/health.htm"

	$updatedProfile = Set-AzureRmTrafficManagerProfile -TrafficManagerProfile $retrievedProfile

	Assert-NotNull $updatedProfile
	Assert-AreEqual "HTTP" $updatedProfile.MonitorProtocol 
	Assert-AreEqual 81 $updatedProfile.MonitorPort 
	Assert-AreEqual "/health.htm" $retrievedProfile.MonitorPath

    $updatedProfile.MonitorPort = 8086
	$updatedProfile.MonitorProtocol = TCP
	$updatedProfile.MonitorPath = $null

	$revertedProfile = Set-AzureRmTrafficManagerProfile -TrafficManagerProfile $updatedProfile

	Assert-NotNull $revertedProfile
	Assert-AreEqual "TCP" $revertedProfile.MonitorProtocol 
	Assert-AreEqual 8086 $revertedProfile.MonitorPort 
	Assert-Null $revertedProfile.MonitorPath

	Remove-AzureRmTrafficManagerProfile -Name $profileName -ResourceGroupName $resourceGroup.ResourceGroupName -Force
}