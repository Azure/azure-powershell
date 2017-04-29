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
Get ResourceGroup name
#>
function Get-ResourceGroupName
{
  return "RGName-" + (getAssetName)
}

<#
.SYNOPSIS
Get Relay name
#>
function Get-RelayName
{
    return "Relay-" + (getAssetName)
}

<#
.SYNOPSIS
Get Namespace name
#>
function Get-NamespaceName
{
    return "Relay-Namespace-" + (getAssetName)
}

<#
.SYNOPSIS
Get valid AuthorizationRule name
#>
function Get-AuthorizationRuleName
{
    return "Relay-Namespace-AuthorizationRule" + (getAssetName)
	
}


<#
.SYNOPSIS
Tests Relay Namespace Create List Remove operations.
#>
function RelayNamespaceTests 
{
    # Setup    
    $location = Get-Location
	$namespaceName = Get-NamespaceName
	$namespaceName2 = Get-NamespaceName
    $resourceGroupName = Get-ResourceGroupName
	$secondResourceGroup = Get-ResourceGroupName
 
    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $resourceGroupName"
	New-AzureRmResourceGroup -Name $resourceGroupName -Location $location -Force 

    Write-Debug "Create resource group"
    Write-Debug "ResourceGroup name : $secondResourceGroup"
	New-AzureRmResourceGroup -Name $secondResourceGroup -Location $location -Force 
     
     
    Write-Debug " Create new Relay namespace"
    Write-Debug "NamespaceName : $namespaceName" 
    $result = New-AzureRmRelayNamespace -ResourceGroup $resourceGroupName -Name $namespaceName -Location $location
    Wait-Seconds 15
	
	# Assert 
	Assert-True {$result.ProvisioningState -eq "Succeeded"}

    Write-Debug "Get the created namespace within the resource group"
    $createdNamespace = Get-AzureRmRelayNamespace -ResourceGroup $resourceGroupName -Name $namespaceName
   
    Assert-True {$createdNamespace.Name -eq $namespaceName} "Get-AzureRmRelayNamespace Namespace created earlier is not found. "    

    
    Write-Debug "Namespace name : $namespaceName2" 
    $result = New-AzureRmRelayNamespace -ResourceGroup $secondResourceGroup -Name $namespaceName2 -Location $location
    Wait-Seconds 15

    Write-Debug "Get all the namespaces created in the resourceGroup"
    $allCreatedNamespace = Get-AzureRmRelayNamespace -ResourceGroup $secondResourceGroup 

    Assert-True {$allCreatedNamespace[0].Name -eq $namespaceName2} "Get-AzureRmRelayNamespace - ResourceGroup Namespace created earlier is not found"
    
    Write-Debug "Get all the namespaces created in the subscription"
    $allCreatedNamespace = Get-AzureRmRelayNamespace 

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

    Assert-True {$found -eq 0} "Get-AzureRmRelayNamespace - Subscription Namespaces created earlier is not found. 3"    

    Write-Debug " Delete namespaces"
    Remove-AzureRmRelayNamespace -ResourceGroup $secondResourceGroup -Name $namespaceName2
    Remove-AzureRmRelayNamespace -ResourceGroup $resourceGroupName -Name $namespaceName

	Write-Debug " Delete resourcegroup"
	Remove-AzureRmResourceGroup -Name $resourceGroupName -Force
}