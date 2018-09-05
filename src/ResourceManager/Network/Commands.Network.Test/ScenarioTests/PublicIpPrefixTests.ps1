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
Tests creating new simple publicIpPrefix.
#>
function Test-PublicIpPrefixCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpPrefixes"
    $location = Get-ProviderLocation $resourceTypeParent
   
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
        # Create publicIpPrefix
        $job = New-AzureRmPublicIpPrefix -ResourceGroupName $rgname -name $rname -location $location -Sku Standard -PrefixLength 30 -AsJob
        $job | Wait-Job
        $actual = $job | Receive-Job
        $expected = Get-AzureRmPublicIpPrefix -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual $expected.Name $actual.Name	
        Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual 30 $expected.PrefixLength
        Assert-NotNull $expected.ResourceGuid
        Assert-AreEqual "Succeeded" $expected.ProvisioningState

      
        # list
        $list = Get-AzureRmPublicIpPrefix -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName  
        Assert-AreEqual $list[0].Name $actual.Name    
        Assert-AreEqual $list[0].Location $actual.Location
        Assert-AreEqual 30 $list[0].PrefixLength
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState
      
        # delete
        $job = Remove-AzureRmPublicIpPrefix -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete
      
        $list = Get-AzureRmPublicIpPrefix -ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}

<#
.SYNOPSIS
Tests creating new simple publicIpPrefix and allocating Ip from it.
#>
function Test-PublicIpPrefixAllocatePublicIpAddress
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
    $pipname = $rname+"pip"
    $domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpPrefixes"
    $location = Get-ProviderLocation $resourceTypeParent
   
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" } 
      
        # Create publicIpPrefix
        $job = New-AzureRmPublicIpPrefix -ResourceGroupName $rgname -name $rname -location $location -Sku Standard -PrefixLength 30 -AsJob
        $job | Wait-Job
        $actual = $job | Receive-Job
        $expected = Get-AzureRmPublicIpPrefix -ResourceGroupName $rgname -name $rname
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName "AreEqual ResourceGroupName"
        Assert-AreEqual $expected.Name $actual.Name "AreEqual Name"
        Assert-AreEqual $expected.Location $actual.Location "AreEqual Location"
        Assert-AreEqual $expected.PrefixLength $actual.PrefixLength "AreEqual PrefixLength"
        Assert-NotNull $expected.ResourceGuid "AreEqual ResourceGuid"
        Assert-AreEqual "Succeeded" $expected.ProvisioningState "AreEqual ProvisioningState"

        # list
        $list = Get-AzureRmPublicIpPrefix -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list).Count "List PublicIpPrefix AreEqual Count 1"
        Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName "List PublicIpPrefix AreEqual ResourceGroupName"
        Assert-AreEqual $list[0].Name $actual.Name "List PublicIpPrefix AreEqual Name"
        Assert-AreEqual $list[0].Location $actual.Location "List PublicIpPrefix AreEqual Location"
        Assert-AreEqual 30 $list[0].PrefixLength "List PublicIpPrefix AreEqual PrefixLength 30"
        Assert-AreEqual "Succeeded" $list[0].ProvisioningState "List PublicIpPrefix ProvisioningState"
        Assert-NotNull $list[0].IPPrefix "List PublicIpPrefix NotNull IPPrefix"
        $PublicIpPrefix = $list[0]

        # Allocate publicIpAddress
        $job=New-AzureRmPublicIpAddress -ResourceGroupName $rgname -AllocationMethod Static -IpAddressVersion IPv4 -PublicIpPrefix $PublicIpPrefix -ResourceName $pipname -location $location -Sku Standard -DomainNameLabel $domainNameLabel -AsJob
        $job | Wait-Job
        $actualIpAddress = $job | Receive-Job
        $expected = Get-AzureRmPublicIpAddress -ResourceGroupName $rgname -name $pipname
        Assert-AreEqual $expected.ResourceGroupName $actualIpAddress.ResourceGroupName "PublicIpAddress AreEqual ResourceGroupName"
        Assert-AreEqual $expected.Name $actualIpAddress.Name "PublicIpAddress AreEqual Name"
        Assert-AreEqual $expected.Location $actualIpAddress.Location "PublicIpAddress AreEqual Location"
        Assert-AreEqual "Static" $expected.PublicIpAllocationMethod "PublicIpAddress AreEqual PublicIpAllocationMethod Static"
        Assert-NotNull $expected.ResourceGuid "PublicIpAddress AreEqual ResourceGuid"
        Assert-AreEqual "Succeeded" $expected.ProvisioningState "PublicIpAddress AreEqual ProvisioningState Succeeded"
        Assert-AreEqual $domainNameLabel $expected.DnsSettings.DomainNameLabel "PublicIpAddress AreEqual DomainNameLabel"
        
        # list again
        $list = Get-AzureRmPublicIpPrefix -ResourceGroupName $rgname
        Assert-AreEqual 1 @($list[0].PublicIpAddresses).Count "List2 PublicIpAddresses AreEqual Count 1"

        # delete address - should Succeed
        $job = Remove-AzureRmPublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $pipname -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete "Delete PublicIpAddress failed"

        # delete prefix - should succeed
        $job = Remove-AzureRmPublicIpPrefix -ResourceGroupName $actual.ResourceGroupName -name $rname -PassThru -Force -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
        Assert-AreEqual true $delete "Delete PublicIpPrefix failed"

        $list = Get-AzureRmPublicIpPrefix -ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual 0 @($list).Count "Hmmmm PublicIpPrefix is still present after delete"
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}