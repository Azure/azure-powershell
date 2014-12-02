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
Tests creating new simple resource group.
#>
function Test-PublicIpAddressCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $rname = Get-ResourceName
	$domainNameLabel = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/publicIpAddresses"
    $location = Get-ProviderLocation $resourceTypeParent

    try 
	    {
        # Test
        $actual = New-AzureResourceGroup -Name $rgname -Location $rglocation -Tags @{Name = "testtag"; Value = "testval"} 
        $expected = Get-AzureResourceGroup -Name $rgname

        # Assert
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $expected.Tags[0]["Name"] $actual.Tags[0]["Name"]

        # Create publicIpAddres
        $actual = New-AzurePublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname -location $location -AllocationMethod Dynamic -DomainNameLabel $domainNameLabel
        $expected = Get-AzurePublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname
        Assert-AreEqual $expected.ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $expected.Name $actual.Name	
        Assert-AreEqual $expected.Location $actual.Location
        Assert-AreEqual "Dynamic" $expected.Properties.PublicIpAllocationMethod
        Assert-AreEqual "Succeeded" $expected.Properties.ProvisioningState
        Assert-AreEqual $domainNameLabel $expected.Properties.DnsSettings.DomainNameLabel
        
        # list
        $list = Get-AzurePublicIpAddress -ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual 1 @($list).Count
        Assert-AreEqual $list[0].ResourceGroupName $actual.ResourceGroupName	
        Assert-AreEqual $list[0].Name $actual.Name	
        Assert-AreEqual $list[0].Location $actual.Location
        Assert-AreEqual "Dynamic" $list[0].Properties.PublicIpAllocationMethod
        Assert-AreEqual "Succeeded" $list[0].Properties.ProvisioningState
        Assert-AreEqual $domainNameLabel $list[0].Properties.DnsSettings.DomainNameLabel
        
        # delete
        $delete = Remove-AzurePublicIpAddress -ResourceGroupName $actual.ResourceGroupName -name $rname
        Assert-AreEqual "Succeeded" $delete.Status
        Assert-AreEqual "OK" $delete.StatusCode
        
        $list = Get-AzurePublicIpAddress -ResourceGroupName $actual.ResourceGroupName
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}