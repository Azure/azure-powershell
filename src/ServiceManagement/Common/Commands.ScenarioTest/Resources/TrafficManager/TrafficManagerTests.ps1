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

########################################################################### General TrafficManager Scenario Tests######################################################################

<#
.SYNOPSIS
Tests any cloud based cmdlet with invalid credentials and expect it'll throw an exception.
#>
function Test-WithInvalidCredentials
{
	param([ScriptBlock] $cloudCmdlet)
	
	# Setup
	Remove-AllSubscriptions

	# Test
	Assert-Throws $cloudCmdlet "No current subscription has been designated. Use Select-AzureSubscription -Current <subscriptionName> to set the current subscription."
}

########################################################################### Remove-Profile Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests New-AzureTrafficManagerProfile and Remove-AzureTrafficManagerProfile
#>
function Test-CreateAndRemoveProfile
{
	# Setup
	$profileName = Get-ProfileName
	New-Profile $profileName

	# Test
	$isDeleted = Remove-AzureTrafficManagerProfile -Name $profileName -Force -PassThru
	
	# Assert
	Assert-True { $isDeleted } "Failed to delete profile $profileName"
	Assert-Throws { Get-AzureTrafficManagerProfile -Name $profileName } "ResourceNotFound: The specified profile name $profileName does not exist."
}

<#
.SYNOPSIS
Tests Remove-AzureTrafficManagerProfile with non existing name
#>
function Test-RemoveProfileWithNonExistingName
{
	# Setup
	$existingProfileName = Get-ProfileName
	$nonExistingProfileName = Get-ProfileName "nonexisting"
	
	# Need to have at least one profile in the subscription or the error will be "missing subscription"
	New-Profile $existingProfileName
	
	# Assert
	Assert-Throws { Remove-AzureTrafficManagerProfile -Name $nonExistingProfileName -Force } "ResourceNotFound: The specified profile name $nonExistingProfileName does not exist."
}

########################################################################### Get-Profile Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Get-AzureTrafficManagerProfile <name>
#>
function Test-GetProfile
{
	# Setup
	$profileName = Get-ProfileName
	$createdProfile = New-Profile $profileName

	# Test
	$retrievedProfile = Get-AzureTrafficManagerProfile $profileName
	
	# Assert
	Assert-AreEqualObjectProperties $createdProfile $retrievedProfile
}

<#
.SYNOPSIS
Tests Get-AzureTrafficManagerProfile
#>
function Test-GetMultipleProfiles
{
    # Setup
	$profileName1 = Get-ProfileName 1
	$profileName2 = Get-ProfileName 2

	$createdProfile1 = New-Profile $profileName1
	$createdProfile2 = New-Profile $profileName2
	
	# Test
	$retrievedProfiles = Get-AzureTrafficManagerProfile
	
	# Assert
	Assert-True { $($retrievedProfiles | select -ExpandProperty Name) -Contains $profileName1 } "Assert failed, profile '$profileName1' not found"
	Assert-True { $($retrievedProfiles | select -ExpandProperty Name) -Contains $profileName2 } "Assert failed, profile '$profileName2' not found"
}

########################################################################### Enable-Profile, Disable-Profile Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Disable-AzureTrafficManagerProfile
#>
function Test-DisableProfile
{
	# Setup
	$profileName = Get-ProfileName
	New-Profile $profileName

	# Test
	Disable-AzureTrafficManagerProfile $profileName
	$disabledProfile = Get-AzureTrafficManagerProfile -Name $profileName
	
	# Assert
	Assert-AreEqual "Disabled" $disabledProfile.Status
}

<#
.SYNOPSIS
Tests  Enable-AzureTrafficManagerProfile
#>
function Test-EnableProfile
{
	# Setup
	$profileName = Get-ProfileName
	New-Profile $profileName

	# Test
	Disable-AzureTrafficManagerProfile $profileName
	Enable-AzureTrafficManagerProfile $profileName
	$enabledProfile = Get-AzureTrafficManagerProfile -Name $profileName
	
	# Assert
	Assert-AreEqual "Enabled" $enabledProfile.Status
}

########################################################################### New-Profile Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests New-AzureTrafficManagerProfile
#>
function Test-NewProfile
{
	# Setup
	$profileName = Get-ProfileName

	# Test
	$createdProfile = New-Profile $profileName
	
	# Assert
	Assert-AreEqual $($profileName  + ".trafficmanager.net") $createdProfile.DomainName
	Assert-AreEqual $profileName $createdProfile.Name
	Assert-AreEqual RoundRobin $createdProfile.LoadBalancingMethod
	Assert-AreEqual 80 $createdProfile.MonitorPort
	Assert-AreEqual Http $createdProfile.MonitorProtocol
	Assert-AreEqual "/" $createdProfile.MonitorRelativePath
	Assert-AreEqual 300 $createdProfile.TimeToLiveInSeconds
	Assert-AreEqual "Enabled" $createdProfile.Status
	Assert-AreEqual "Inactive" $createdProfile.MonitorStatus
}

<#
.SYNOPSIS
Tests New-AzureTrafficManagerProfile with invalid parameter
#>
function Test-NewProfileWithInvalidParameter
{
	# Setup
	$profileName = Get-ProfileName
	
	# Assert
	$expectedMessage = "A policy with the requested domain name could not be created because the name INVALID does not end with the expected value .trafficmanager.net."
	Assert-Throws { New-AzureTrafficManagerProfile -Name $profileName -DomainName "INVALID" -LoadBalancingMethod RoundRobin -MonitorPort 80 -MonitorProtocol Http -MonitorRelativePath "/" -Ttl 300 } 
}

########################################################################### Set-Profile Scenario Tests ###########################################################################

<#
.SYNOPSIS
Tests Set-AzureTrafficManagerProfile
#>
function Test-SetProfileProperty
{
	# Setup
	$profileName = Get-ProfileName
	$createdProfile = New-Profile $profileName

	# Test
	$updatedProfile = Set-AzureTrafficManagerProfile -TrafficManagerProfile $createdProfile -Name $createdProfile.Name -Ttl 333 
	
	# Assert
	Assert-AreEqual 333 $updatedProfile.TimeToLiveInSeconds
}

<#
.SYNOPSIS
Tests Add-AzureTrafficManagerEndpoint
#>
function Test-AddAzureTrafficManagerEndpoint
{
	# Setup
	$profileName = Get-ProfileName
	$createdProfile = New-Profile $profileName
	
	#Test
	$updatedProfile = $createdProfile | Add-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Type Any -Status Enabled -Weight 3 -Location "West US" | Set-AzureTrafficManagerProfile
	
	# Assert
	$profileMonitoringStatus = $updatedProfile.MonitorStatus
	$endpointMonitoringStatus = $updatedProfile.Endpoints[0].MonitorStatus
	
	Assert-AreEqual 1 $updatedProfile.Endpoints.Count
	Assert-True { $profileMonitoringStatus -eq "CheckingEndpoints" -or $profileMonitoringStatus -eq "Online" } "Assert failed as endpoint MonitoringStatus has an unexpected value: $profileMonitoringStatus"
	
	Assert-AreEqual Any $updatedProfile.Endpoints[0].Type
	Assert-AreEqual "www.microsoft.com" $updatedProfile.Endpoints[0].DomainName
	Assert-AreEqual Enabled $updatedProfile.Endpoints[0].Status
	Assert-AreEqual 3 $updatedProfile.Endpoints[0].Weight
	Assert-AreEqual "West US" $updatedProfile.Endpoints[0].Location
	Assert-True { $endpointMonitoringStatus -eq "CheckingEndpoint" -or $endpointMonitoringStatus -eq "Online" } "Assert failed as endpoint MonitoringStatus has an unexpected value: $endpointMonitoringStatus"
}

<#
.SYNOPSIS
Tests Add-AzureTrafficManagerEndpoint with no weight or location
#>
function Test-AddAzureTrafficManagerEndpointNoWeightLocation
{
	# Setup
	$profileName = Get-ProfileName
	$createdProfile = New-Profile $profileName
	
	#Test
	$updatedProfile = $createdProfile | Add-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Type Any -Status Enabled | Set-AzureTrafficManagerProfile
	
	# Assert
	$profileMonitoringStatus = $updatedProfile.MonitorStatus
	$endpointMonitoringStatus = $updatedProfile.Endpoints[0].MonitorStatus
	
	Assert-AreEqual 1 $updatedProfile.Endpoints.Count
	Assert-True { $profileMonitoringStatus -eq "CheckingEndpoints" -or $profileMonitoringStatus -eq "Online" } "Assert failed as endpoint MonitoringStatus has an unexpected value: $profileMonitoringStatus"
	
	Assert-AreEqual Any $updatedProfile.Endpoints[0].Type
	Assert-AreEqual "www.microsoft.com" $updatedProfile.Endpoints[0].DomainName
	Assert-AreEqual Enabled $updatedProfile.Endpoints[0].Status
	# Test for default values
	Assert-AreEqual 1 $updatedProfile.Endpoints[0].Weight
	Assert-Null $updatedProfile.Endpoints[0].Location
	Assert-True { $endpointMonitoringStatus -eq "CheckingEndpoint" -or $endpointMonitoringStatus -eq "Online" } "Assert failed as endpoint MonitoringStatus has an unexpected value: $endpointMonitoringStatus"
}

<#
.SYNOPSIS
Tests Add-AddAzureTrafficManagerEndpointNoWeightLocation with no MinChildEndpoints
#>
function Test-AddAzureTrafficManagerEndpointNoMinChildEndpoints
{
	# Setup
	$profileName = Get-ProfileName
	$createdProfile = New-Profile $profileName
	
	#Test
	$updatedProfile = $createdProfile | Add-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Type Any -Status Enabled | Set-AzureTrafficManagerProfile
	
	# Assert
	Assert-AreEqual 1 $updatedProfile.Endpoints.Count
	Assert-AreEqual $null $updatedProfile.Endpoints[0].MinChildEndpoints
}

<#
.SYNOPSIS
Tests Add-AddAzureTrafficManagerEndpointTypeTrafficManager
#>
function Test-AddAzureTrafficManagerEndpointTypeTrafficManager
{
	# Setup
	$nestedProfileName = Get-ProfileName
	$nestedDomainName = $nestedProfileName + $TrafficManagerDomain
	$randomValue = Get-Random -Maximum 10000
	$topLevelProfileName = "toplevelprofile" + $randomValue
	$nestedProfile = New-Profile $nestedProfileName
	$topLevelProfile = New-Profile $topLevelProfileName
	
	#Test
	$updatedNestedProfile = $nestedProfile | Add-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Type Any -Status Enabled | Set-AzureTrafficManagerProfile
	$updatedTopLevelProfile = $topLevelProfile | Add-AzureTrafficManagerEndpoint -DomainName $nestedDomainName -Type TrafficManager -Status Enabled | Set-AzureTrafficManagerProfile
	
	# Assert
	Assert-AreEqual 1 $updatedNestedProfile.Endpoints.Count
	Assert-AreEqual Any $updatedNestedProfile.Endpoints[0].Type
	Assert-AreEqual 1 $updatedTopLevelProfile.Endpoints.Count
	Assert-AreEqual TrafficManager $updatedTopLevelProfile.Endpoints[0].Type
	
	Remove-AzureTrafficManagerProfile -Name $topLevelProfileName -Force -PassThru
}

<#
.SYNOPSIS
Tests Set-AzureTrafficManagerEndpoint not updating Weight or Location
#>
function Test-SetAzureTrafficManagerEndpoint
{
	# Setup
	$profileName = Get-ProfileName
	$createdProfile = New-Profile $profileName | Add-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Type Any -Status Enabled -Weight 3 -Location "West US" | Set-AzureTrafficManagerProfile
	
	# Assert
	Assert-AreEqual 3 $createdProfile.Endpoints[0].Weight
	Assert-AreEqual "West US" $createdProfile.Endpoints[0].Location

	# Test
	$updatedProfile = $createdProfile | Set-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Status Disabled | Set-AzureTrafficManagerProfile
	
	# Assert
	Assert-AreEqual 1 $updatedProfile.Endpoints.Count
	Assert-AreEqual "www.microsoft.com" $updatedProfile.Endpoints[0].DomainName
	Assert-AreEqual Disabled $updatedProfile.Endpoints[0].Status
	Assert-AreEqual 3 $updatedProfile.Endpoints[0].Weight
	Assert-AreEqual "West US" $updatedProfile.Endpoints[0].Location
}

<#
.SYNOPSIS
Tests Set-AzureTrafficManagerEndpoint updating Weight and Location
#>
function Test-SetAzureTrafficManagerEndpointUpdateWeightLocation
{
	# Setup
	$profileName = Get-ProfileName
	$createdProfile = New-Profile $profileName | Add-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Type Any -Status Enabled | Set-AzureTrafficManagerProfile
	
	# Assert
	Assert-AreEqual 1 $createdProfile.Endpoints[0].Weight
	Assert-Null $createdProfile.Endpoints[0].Location
	
	#Test
	$updatedProfile = $createdProfile | Set-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Status Disabled -Weight 3 -Location "West US" | Set-AzureTrafficManagerProfile
	
	# Assert
	Assert-AreEqual 1 $updatedProfile.Endpoints.Count
	Assert-AreEqual "www.microsoft.com" $updatedProfile.Endpoints[0].DomainName
	Assert-AreEqual Disabled $updatedProfile.Endpoints[0].Status
	Assert-AreEqual 3 $updatedProfile.Endpoints[0].Weight
	Assert-AreEqual "West US" $updatedProfile.Endpoints[0].Location
}

<#
.SYNOPSIS
Tests Set-AzureTrafficManagerEndpoint when it adds endpoints
#>
function Test-SetAzureTrafficManagerEndpointAdds
{
	# Setup
	$profileName = Get-ProfileName
	$createdProfile = New-Profile $profileName
	
	$createdProfile = $createdProfile |
	Set-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Type Any -Status Enabled |
	Set-AzureTrafficManagerEndpoint -DomainName "www.windows.com" -Type Any -Status Enabled |
	Set-AzureTrafficManagerProfile
	
	# Assert
	Assert-AreEqual 2 $createdProfile.Endpoints.Count
	Assert-True { $($createdProfile.Endpoints | select -ExpandProperty DomainName) -Contains "www.microsoft.com" } "Assert failed, endpoint 'www.microsoft.com' not found"
	Assert-True { $($createdProfile.Endpoints | select -ExpandProperty DomainName) -Contains "www.windows.com" } "Assert failed, endpoint 'www.microsoft.com' not found"
	
	# Test
	$updatedProfile = $createdProfile | Set-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Status Disabled | Set-AzureTrafficManagerProfile
	
	# Assert
	Assert-AreEqual 2 $updatedProfile.Endpoints.Count
	Assert-True { $($updatedProfile.Endpoints | select -ExpandProperty DomainName) -Contains "www.microsoft.com" } "Assert failed, endpoint 'www.microsoft.com' not found"
	Assert-AreEqual Disabled $($updatedProfile.Endpoints | where {$_.DomainName -eq "www.microsoft.com"}).Status
}

<#
.SYNOPSIS
Tests Remove-AzureTrafficManagerEndpoint
#>
function Test-RemoveAzureTrafficManagerEndpoint
{
	# Setup
	$profileName = Get-ProfileName
	$createdProfile = New-Profile $profileName | Add-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Type Any -Status Enabled | Set-AzureTrafficManagerProfile
	
	#Test
	$updatedProfile = $createdProfile | Remove-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" | Set-AzureTrafficManagerProfile
	
	# Assert
	Assert-AreEqual 0 $updatedProfile.Endpoints.Count
}

<#
.SYNOPSIS
Tests multiple Add-AzureTrafficManagerEndpoint
#>
function Test-AddMultipleAzureTrafficManagerEndpoint
{
	# Setup
	$profileName = Get-ProfileName
	$createdProfile = New-Profile $profileName | Add-AzureTrafficManagerEndpoint -DomainName "www.microsoft.com" -Type Any -Status Enabled
	$createdProfile = $createdProfile | Add-AzureTrafficManagerEndpoint -DomainName "www.bing.com" -Type Any -Status Enabled 
	
	#Test
	$updatedProfile = $createdProfile | Set-AzureTrafficManagerProfile
	
	# Assert
	Assert-AreEqual 2 $updatedProfile.Endpoints.Count
}

########################################################################### Test-TrafficManagerDomainName Scenario Tests ###########################################################################
<#
.SYNOPSIS
Tests Test-AzureTrafficManagerDomainName
#>
function Test-TestAzureTrafficManagerDomainName
{
	$profileName = Get-ProfileName
	Assert-True { Test-AzureTrafficManagerDomainName -DomainName $profileName$TrafficManagerDomain } "Assert failed, domain name $profileName$TrafficManagerDomain is not available"
	$createdProfile = New-Profile $profileName
	Assert-False { Test-AzureTrafficManagerDomainName -DomainName $profileName$TrafficManagerDomain } "Assert failed, domain name $profileName$TrafficManagerDomain is available after creating a profile with that name"
}