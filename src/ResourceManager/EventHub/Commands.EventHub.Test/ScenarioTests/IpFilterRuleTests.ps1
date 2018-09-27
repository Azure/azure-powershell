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
Tests New Parameter names EventHubs Create List Remove operations.
#>

function IpFilterRuleTests
{
	# Setup    
	$location = Get-Location
	$resourceGroupName = getAssetName "RSG"
	$namespaceName = getAssetName "EH-NS-"
	$ipfilterrule = getAssetName "IPFilterRule-"
	$ipfilterrule2 = getAssetName "IPFilterRule-"

	Try
	{
		# Create Resource Group
		Write-Debug "Create resource group"    
		Write-Debug " Resource Group Name : $resourceGroupName"
		New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force	
		
		# Create EventHub Namespace
		Write-Debug "  Create new eventhub namespace"
		Write-Debug " Namespace name : $namespaceName"
		$result = New-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location

		# Assert
		Assert-AreEqual $result.Name $namespaceName	"New Namespace: Namespace created earlier is not found."

		# get the created Eventhub Namespace 
		Write-Debug " Get the created namespace within the resource group"
		$createdNamespace = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
	
		Assert-AreEqual $createdNamespace.Name $namespaceName "Get Namespace: Namespace created earlier is not found."
	
		# Create a IPFilterRule
		Write-Debug " Create new IpFilterRule "	
		$result = New-AzureRmEventHubIPFilterRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $ipfilterrule -IpMask "13.78.143.246/32" -Action "Accept"
			
		Write-Debug " Get the created IpFilterRule "
		$createdIpfilterRule = Get-AzureRmEventHubIPFilterRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $result.Name

		# Assert
		Assert-AreEqual $createdIpfilterRule.Name $ipfilterrule "Get IpFilter Rule: IPFilter Rule created earlier is not found."	
	
	
		# Create a IPFilterRule	-2
		Write-Debug " Create new IpFilterRule "	
		$result2 = New-AzureRmEventHubIPFilterRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $ipfilterrule2 -IpMask "13.78.143.221/32" -Action "Accept"
			
		Write-Debug " Get the created IpFilterRule "
		$createdIpfilterRule2 = Get-AzureRmEventHubIPFilterRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $result2.Name

		# Assert
		Assert-AreEqual $createdIpfilterRule2.Name $ipfilterrule2 "Get IpFilter Rule: IPFilter Rule created earlier is not found."    

		# Get all Created IP Filter Rule
		Write-Debug " Get all the created Filter rule "
		$ListAllIpfilterRule = Get-AzureRmEventHubIPFilterRule -ResourceGroup $resourceGroupName -Namespace $namespaceName

		# Assert
		Assert-AreEqual $ListAllIpfilterRule.Count 2 "List Eventhub: EventHub created earlier is not found in list"

		# Update the Created EventHub
		$createdIpfilterRule.IpMask = "13.78.143.219/32"
		$updatedIpfilterRule = Set-AzureRmEventHubIPFilterRule -InputObject $createdIpfilterRule
	
		# Assert
		Assert-AreEqual $updatedIpfilterRule.Name $createdIpfilterRule.Name
		Assert-AreEqual $updatedIpfilterRule.IpMask $createdIpfilterRule.IpMask
	
		# Cleanup
		# Delete all Created Eventhub
		Write-Debug " Delete the EventHub"
		for ($i = 0; $i -lt $ListAllIpfilterRule.Count; $i++)
		{
			$delete1 = Remove-AzureRmEventHubIPFilterRule -ResourceGroup $resourceGroupName -Namespace $namespaceName -Name $ListAllIpfilterRule[$i].Name		
		}
	}
	Finally
	{
		$getcreatednamespace = Get-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
		if($getcreatednamespace -ne $null)
		{
			Write-Debug " Delete namespaces"
			Remove-AzureRmEventHubNamespace -ResourceGroup $resourceGroupName -Namespace $namespaceName
		}

		Write-Debug " Delete resourcegroup"
		Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
	}	
}