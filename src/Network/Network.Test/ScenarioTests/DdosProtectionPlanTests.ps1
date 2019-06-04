# ----------------------------------------------------------------------------------
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
DDoS protection plan management operations
#>
function Test-DdosProtectionPlanCRUD
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/DdosProtectionPlans"
    $location = Get-ProviderLocation $resourceTypeParent

    $rgName = Get-ResourceGroupName
    $ddosProtectionPlanName = Get-ResourceName

    try
    {
        # Create the resource group
        New-AzResourceGroup -Name $rgName -Location $location -Tags @{ testtag = "ddosProtectionPlan tag" }

        # Create the DDoS protection plan
        $job = New-AzDdosProtectionPlan -ResourceGroupName $rgName -Name $ddosProtectionPlanName -Location $rgLocation -AsJob
        $job | Wait-Job
        $ddosProtectionPlanNew = $job | Receive-Job

        Assert-AreEqual $rgName $ddosProtectionPlanNew.ResourceGroupName
        Assert-AreEqual $ddosProtectionPlanName $ddosProtectionPlanNew.Name
        Assert-NotNull $ddosProtectionPlanNew.Location
        Assert-NotNull $ddosProtectionPlanNew.Etag
        Assert-Null $ddosProtectionPlanNew.VirtualMachines

        # Get the DDoS protection plan
        $ddosProtectionPlanGet = Get-AzDdosProtectionPlan -ResourceGroupName $rgName -Name $ddosProtectionPlanName
        Assert-AreEqual $rgName $ddosProtectionPlanGet.ResourceGroupName
        Assert-AreEqual $ddosProtectionPlanName $ddosProtectionPlanGet.Name
        Assert-NotNull $ddosProtectionPlanGet.Location
        Assert-NotNull $ddosProtectionPlanGet.Etag
        Assert-Null $ddosProtectionPlanGet.VirtualMachines

        $ddosProtectionPlanList = Get-AzDdosProtectionPlan -ResourceGroupName $rgName
        Assert-NotNull $ddosProtectionPlanList
        Assert-True {$ddosProtectionPlanList.Count -ge 0}

        $ddosProtectionPlanList = Get-AzDdosProtectionPlan -ResourceGroupName "*"
        Assert-NotNull $ddosProtectionPlanList
        Assert-True {$ddosProtectionPlanList.Count -ge 0}

        $ddosProtectionPlanList = Get-AzDdosProtectionPlan -Name "*"
        Assert-NotNull $ddosProtectionPlanList
        Assert-True {$ddosProtectionPlanList.Count -ge 0}

        $ddosProtectionPlanList = Get-AzDdosProtectionPlan -ResourceGroupName "*" -Name "*"
        Assert-NotNull $ddosProtectionPlanList
        Assert-True {$ddosProtectionPlanList.Count -ge 0}

        # Remove the DDoS protection plan
        $ddosProtectionPlanDelete = Remove-AzDdosProtectionPlan -Name $ddosProtectionPlanName -ResourceGroupName $rgName -PassThru
        Assert-AreEqual $true $ddosProtectionPlanDelete
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}

<#
.SYNOPSIS
Tests the creation of a new DDoS protection plan and it associates it with a VNET.
#>
function Test-DdosProtectionPlanCRUDWithVirtualNetwork
{
    # Setup
    $rgname = Get-ResourceGroupName
    $vnetName = Get-ResourceName
    $subnetName = Get-ResourceName
    $ddosProtectionPlanName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/virtualNetworks"
    $location = Get-ProviderLocation $resourceTypeParent

    try 
    {
        # Create the resource group

        New-AzResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 

        # Create the DDoS Protection plan

        $ddosProtectionPlan = New-AzDdosProtectionPlan -Name $ddosProtectionPlanName -ResourceGroupName $rgname -Location $location

        # Create a Virtual Network with the DDoS protection plan

        $subnet = New-AzVirtualNetworkSubnetConfig -Name $subnetName -AddressPrefix 10.0.1.0/24
        $vnet = New-AzvirtualNetwork -Name $vnetName -ResourceGroupName $rgname -Location $location -AddressPrefix 10.0.0.0/16 -DnsServer 8.8.8.8 -Subnet $subnet -EnableDdoSProtection -DdosProtectionPlanId $ddosProtectionPlan.Id

        Assert-AreEqual true $vnet.EnableDdoSProtection
        Assert-AreEqual $ddosProtectionPlan.Id $vnet.DdosProtectionPlan.Id

        # Verify DDoS protection now shows the associated VNET

        $ddosProtectionPlanWithVnet = Get-AzDdosProtectionPlan -Name $ddosProtectionPlanName -ResourceGroupName $rgname

        Assert-AreEqual $vnet.Id $ddosProtectionPlanWithVnet.VirtualNetworks[0].Id

        # Delete the virtual network

        $deleteVnet = Remove-AzvirtualNetwork -ResourceGroupName $rgname -name $vnetName -PassThru -Force
        Assert-AreEqual true $deleteVnet

        # Delete the DDoS protection plan

        $deleteDdosProtectionPlan = Remove-AzDdosProtectionPlan -ResourceGroupName $rgname -name $ddosProtectionPlanName -PassThru
        Assert-AreEqual true $deleteDdosProtectionPlan
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
DDoS protection plan collection operations
#>
function Test-DdosProtectionPlanCollections
{
    $rgLocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/DdosProtectionPlans"
    $location = Get-ProviderLocation $resourceTypeParent
    $rgName = Get-ResourceGroupName
    $ddosProtectionPlanName = Get-ResourceName

    try
    {
        # Create the resource group
        
        New-AzResourceGroup -Name $rgName -Location $location -Tags @{ testtag = "ddosProtectionPlan tag" }

        # Create ddosProtectionPlan in resource group

        $ddosProtectionPlan = New-AzDdosProtectionPlan -Name $ddosProtectionPlanName -ResourceGroupName $rgName -Location $rgLocation

        # Get the ddosProtectionPlan in the resource group by using the collections API

        $listRg = Get-AzDdosProtectionPlan -ResourceGroupName $rgName
        Assert-AreEqual 1 @($listRg).Count
        Assert-AreEqual $listRg[0].ResourceGroupName $ddosProtectionPlan.ResourceGroupName
        Assert-AreEqual $listRg[0].Name $ddosProtectionPlan.Name
        Assert-AreEqual $listRg[0].Location $ddosProtectionPlan.Location
        Assert-AreEqual $listRg[0].Etag $ddosProtectionPlan.Etag

        # Get all DDoS protection plans in the subscription

        $listSub = Get-AzDdosProtectionPlan

        $ddosProtectionPlanFromList = @($listSub) | Where-Object Name -eq $ddosProtectionPlanName | Where-Object ResourceGroupName -eq $rgName
        Assert-AreEqual $ddosProtectionPlan.ResourceGroupName $ddosProtectionPlanFromList.ResourceGroupName
        Assert-AreEqual $ddosProtectionPlan.Name $ddosProtectionPlanFromList.Name
        Assert-AreEqual $ddosProtectionPlan.Location $ddosProtectionPlanFromList.Location
        Assert-AreEqual $ddosProtectionPlan.Etag $ddosProtectionPlanFromList.Etag
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgName
    }
}
