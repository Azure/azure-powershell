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
Tests Relay Namespace Create List Remove operations.
#>
function RelayNamespaceTests 
{
    # Setup    
    $location = "West US"
	$namespaceName = getAssetName "Relay-NS"
	$namespaceName2 = getAssetName "Relay-NS"
    $resourceGroupName = getAssetName
	$secondResourceGroup = getAssetName
 
    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
	New-AzResourceGroup -Name $resourceGroupName -Location $location -Force 

    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $secondResourceGroup"
	New-AzResourceGroup -Name $secondResourceGroup -Location $location -Force 
     
     
    Write-Debug " Create new Relay namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName -Location $location
    Wait-Seconds 15
	
	# Assert 
	Assert-True {$result.ProvisioningState -eq "Succeeded"}
	
    Write-Debug "Namespace name : $namespaceName2" 
    $result1 = New-AzRelayNamespace -ResourceGroupName $secondResourceGroup -Name $namespaceName2 -Location $location
    Wait-Seconds 15

	# Assert 
	Assert-True {$result1.ProvisioningState -eq "Succeeded"}

   Try
   {
		Write-Debug "Get the created namespace within the resource group"
		$createdNamespace = Get-AzRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName
   
		Assert-True {$createdNamespace.Name -eq $namespaceName} "Get-AzRelayNamespace Namespace created earlier is not found. "      

		Write-Debug "Get all the namespaces created in the resourceGroup"
		$allCreatedNamespace = Get-AzRelayNamespace -ResourceGroupName $secondResourceGroup 

		Assert-True {$allCreatedNamespace[0].Name -eq $namespaceName2} "Get-AzRelayNamespace - ResourceGroup Namespace created earlier is not found"
    
		Write-Debug "Get all the namespaces created in the subscription"
		$allCreatedNamespace = Get-AzRelayNamespace 

		$found = 0
		for ($i = 0; $i -lt $allCreatedNamespace.Items.Count; $i++)
		{
			if ($allCreatedNamespace[$i].Name -eq $namespaceName)
			{
				$found = $found + 1
				Assert-AreEqual $location $allCreatedNamespace[$i].Location
			}

			if ($allCreatedNamespace[$i].Name -eq $namespaceName2)
			{
				$found = $found + 1
				Assert-AreEqual $location $allCreatedNamespace[$i].Location
			}
		}

		Assert-True {$found -eq 0} "Get-AzRelayNamespace - Subscription Namespaces created earlier is not found."    
   }
   Finally
   {
		Write-Debug " Delete namespaces"
		Remove-AzRelayNamespace -ResourceGroupName $secondResourceGroup -Name $namespaceName2
		Remove-AzRelayNamespace -ResourceGroupName $resourceGroupName -Name $namespaceName

		Write-Debug " Delete resourcegroup"
		Remove-AzResourceGroup -Name $resourceGroupName -Force
   }

    
}