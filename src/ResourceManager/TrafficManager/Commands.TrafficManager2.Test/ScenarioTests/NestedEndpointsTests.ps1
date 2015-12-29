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
Profile with Nested Endpoint
#>
function Test-NestedEndpointsCreateUpdate
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$childProfileName = getAssetName
	$childProfileRelativeName = getAssetName
	$anotherChildProfileName = getAssetName
	$anotherChildProfileRelativeName = getAssetName
	$parentProfileName = getAssetName
	$parentProfileRelativeName = getAssetName

	$createdChildProfile = New-AzureRmTrafficManagerProfile -Name $childProfileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $childProfileRelativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
	Assert-NotNull $createdChildProfile.Id

	$createdParentProfile = New-AzureRmTrafficManagerProfile -Name $parentProfileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $parentProfileRelativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
	$createdParentProfile = Add-AzureRmTrafficManagerEndpointConfig -EndpointName "MyNestedEndpoint" -TrafficManagerProfile $createdParentProfile -Type "NestedEndpoints" -TargetResourceId $createdChildProfile.Id -EndpointStatus "Enabled" -EndpointLocation "North Europe" -MinChildEndpoints 2
	$updatedParentProfile = Set-AzureRmTrafficManagerProfile -TrafficManagerProfile $createdParentProfile

	Assert-NotNull $updatedParentProfile
	Assert-AreEqual 1 $updatedParentProfile.Endpoints.Count
	Assert-AreEqual 2 $updatedParentProfile.Endpoints[0].MinChildEndpoints
	Assert-AreEqual "North Europe" $updatedParentProfile.Endpoints[0].Location

	$retrievedParentProfile = Get-AzureRmTrafficManagerProfile -Name $parentProfileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedParentProfile
	Assert-AreEqual 1 $retrievedParentProfile.Endpoints.Count
	Assert-AreEqual 2 $retrievedParentProfile.Endpoints[0].MinChildEndpoints
	Assert-AreEqual "North Europe" $retrievedParentProfile.Endpoints[0].Location

	$anotherCreatedChildProfile = New-AzureRmTrafficManagerProfile -Name $anotherChildProfileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $anotherChildProfileRelativeName -Ttl 50 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testpath.asp" 
	Assert-NotNull $anotherCreatedChildProfile.Id

	$anotherNestedEndpoint = New-AzureRmTrafficManagerEndpoint -Name "MySecondNestedEndpoint" -ProfileName $parentProfileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "NestedEndpoints" -TargetResourceId $anotherCreatedChildProfile.Id -EndpointStatus "Enabled" -EndpointLocation "West Europe" -MinChildEndpoints 3

	Assert-NotNull $anotherNestedEndpoint
	Assert-AreEqual 3 $anotherNestedEndpoint.MinChildEndpoints
	Assert-AreEqual "West Europe" $anotherNestedEndpoint.Location
	
	$retrievedParentProfile = Get-AzureRmTrafficManagerProfile -Name $parentProfileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedParentProfile
	Assert-AreEqual 2 $retrievedParentProfile.Endpoints.Count
	Assert-AreEqual 3 $retrievedParentProfile.Endpoints[1].MinChildEndpoints
	Assert-AreEqual "West Europe" $retrievedParentProfile.Endpoints[1].Location

	$anotherNestedEndpoint.MinChildEndpoints = 4
	$anotherNestedEndpoint.Location = "West US"

	$anotherNestedEndpoint = Set-AzureRmTrafficManagerEndpoint -TrafficManagerEndpoint $anotherNestedEndpoint

	Assert-NotNull $anotherNestedEndpoint
	Assert-AreEqual 4 $anotherNestedEndpoint.MinChildEndpoints
	Assert-AreEqual "West US" $anotherNestedEndpoint.Location

	$retrievedParentProfile = Get-AzureRmTrafficManagerProfile -Name $parentProfileName -ResourceGroupName $resourceGroup.ResourceGroupName

	Assert-NotNull $retrievedParentProfile
	Assert-AreEqual 2 $retrievedParentProfile.Endpoints.Count
	Assert-AreEqual 4 $retrievedParentProfile.Endpoints[1].MinChildEndpoints
	Assert-AreEqual "West US" $retrievedParentProfile.Endpoints[1].Location
}

<#
.SYNOPSIS
Tests the Get-Put pattern for a profile with a nested endpoint
#>
function Test-ProfileWithNestedEndpointsGetPut
{
	$resourceGroup = TestSetup-CreateResourceGroup
	$childProfileName = getAssetName
	$childProfileRelativeName = getAssetName
	$parentProfileName = getAssetName
	$parentProfileRelativeName = getAssetName

	$createdChildProfile = New-AzureRmTrafficManagerProfile -Name $childProfileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $childProfileRelativeName -Ttl 30 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTP" -MonitorPort 80 -MonitorPath "/testchild.asp" 
	Assert-NotNull $createdChildProfile.Id

	$createdParentProfile = New-AzureRmTrafficManagerProfile -Name $parentProfileName -ResourceGroupName $resourceGroup.ResourceGroupName -RelativeDnsName $parentProfileRelativeName -Ttl 51 -TrafficRoutingMethod "Performance" -MonitorProtocol "HTTPS" -MonitorPort 111 -MonitorPath "/testparent.asp" 
	$nestedEndpoint = New-AzureRmTrafficManagerEndpoint -Name "MyNestedEndpoint" -ProfileName $parentProfileName -ResourceGroupName $resourceGroup.ResourceGroupName -Type "NestedEndpoints" -TargetResourceId $createdChildProfile.Id -EndpointStatus "Enabled" -EndpointLocation "West Europe" -MinChildEndpoints 1

	$retrievedParentProfile = Get-AzureRmTrafficManagerProfile -Name $parentProfileName -ResourceGroupName $resourceGroup.ResourceGroupName
	$retrievedParentProfile | Set-AzureRmTrafficManagerProfile

	$retrievedParentProfile = Get-AzureRmTrafficManagerProfile -Name $parentProfileName -ResourceGroupName $resourceGroup.ResourceGroupName

    Assert-NotNull $retrievedParentProfile
	Assert-AreEqual 51 $retrievedParentProfile.Ttl
	Assert-AreEqual 111 $retrievedParentProfile.MonitorPort
	Assert-AreEqual "HTTPS" $retrievedParentProfile.MonitorProtocol
	Assert-AreEqual "/testparent.asp" $retrievedParentProfile.MonitorPath 
	Assert-AreEqual "Performance" $retrievedParentProfile.TrafficRoutingMethod

	Assert-AreEqual 1 $retrievedParentProfile.Endpoints.Count
	Assert-AreEqual 1 $retrievedParentProfile.Endpoints[0].MinChildEndpoints
    Assert-AreEqual 1 $retrievedParentProfile.Endpoints[0].Weight
	Assert-AreEqual 1 $retrievedParentProfile.Endpoints[0].Priority
	Assert-AreEqual "Microsoft.Network/trafficManagerProfiles/nestedEndpoints" $retrievedParentProfile.Endpoints[0].Type
	Assert-AreEqual "MyNestedEndpoint" $retrievedParentProfile.Endpoints[0].Name
	Assert-AreEqual "Enabled" $retrievedParentProfile.Endpoints[0].EndpointStatus
	Assert-AreEqual "West Europe" $retrievedParentProfile.Endpoints[0].Location
	Assert-AreEqual $createdChildProfile.Id $retrievedParentProfile.Endpoints[0].TargetResourceId
	Assert-AreEqual $retrievedParentProfile.Name $retrievedParentProfile.Endpoints[0].ProfileName
}
