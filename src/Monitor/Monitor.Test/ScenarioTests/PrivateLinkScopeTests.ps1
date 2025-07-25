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

function Test-PrivateLinkScopeCRUD
{
	# setup
    $rg_name = Get-ResourceGroupName

    $scope_name1 = Get-ResourceName
    $scope_name2 = Get-ResourceName
    $scope_name3 = Get-ResourceName

    $config_name = Get-ResourceName
    $vnet_name = Get-ResourceName
    $connection_name = Get-ResourceName
    $endpoint_name = Get-ResourceName

    $key1 = "key1"
    $key2 = "key2"
    $key3 = "key3"

    $val1 = "val1"
    $val2 = "val2"
    $val3 = "val3"
    
    $tag1 = $key1+":"+$val1
    $tag2 = $key2+":"+$val2
    $tag3 = $key3+":"+$val3

    try
    {
        #create resource group
        New-AzResourceGroup -Name $rg_name -Location "westus"

        #create private link scope
        New-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name1 -Location "global"
        New-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name2 -Location "global"
        New-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name3 -Location "global"

        #get private link scope
        $scope1 = Get-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name1
        $scope2 = Get-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name2
        $scope3 = Get-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name3

        Assert-NotNull $scope1
        Assert-NotNull $scope2
        Assert-NotNull $scope3

        Assert-AreEqual $scope_name1 $scope1.Name
        Assert-AreEqual $scope_name2 $scope2.Name
        Assert-AreEqual $scope_name3 $scope3.Name

        Assert-AreEqual "Succeeded" $scope1.ProvisioningState
        Assert-AreEqual "Succeeded" $scope2.ProvisioningState
        Assert-AreEqual "Succeeded" $scope3.ProvisioningState

        #update private link scope
        $scope1 = Update-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name1 -Tags $tag1
        $scope2 = Update-AzInsightsPrivateLinkScope -ResourceId $scope2.Id -Tags $tag2
        $scope3 = $scope3 | Update-AzInsightsPrivateLinkScope -Tags $tag3

        $valout1 = "abracadabra"
        $valout2 = "abracadabra"
        $valout3 = "abracadabra"

        $scope1.Tags.TryGetValue($key1, [ref]$valout1)
        $scope2.Tags.TryGetValue($key2, [ref]$valout2)
        $scope3.Tags.TryGetValue($key3, [ref]$valout3)

        Assert-AreEqual $val1 $valout1
        Assert-AreEqual $val2 $valout2
        Assert-AreEqual $val3 $valout3

        #get/list private-link-resource
        $private_link_resource = Get-AzPrivateLinkResource -PrivateLinkResourceId $scope1.Id
        
        Assert-NotNull $private_link_resource
        Assert-AreEqual 'azuremonitor' $private_link_resource[0].GroupId

        #create private endpoint connection
        $subnetConfig = New-AzVirtualNetworkSubnetConfig -Name $config_name -AddressPrefix "11.0.1.0/24" -PrivateEndpointNetworkPolicies "Disabled"
        New-AzVirtualNetwork -ResourceGroupName $rg_name -Name $vnet_name -Location "eastus2euap" -AddressPrefix "11.0.0.0/16" -Subnet $subnetConfig
        $vnet=Get-AzVirtualNetwork -Name $vnet_name -ResourceGroupName $rg_name
        $plsConnection = New-AzPrivateLinkServiceConnection -Name $connection_name -PrivateLinkServiceId $scope1.Id -GroupId $private_link_resource[0].GroupId
        New-AzPrivateEndpoint -ResourceGroupName $rg_name -Name $endpoint_name -Location "eastus2euap" -Subnet $vnet.subnets[0] -PrivateLinkServiceConnection $plsConnection -ByManualRequest

        $connection = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $scope1.Id

        Assert-NotNull $connection
        Assert-AreEqual "Pending" $connection.PrivateLinkServiceConnectionState.Status

        $connectionApprove = Approve-AzPrivateEndpointConnection -ResourceId $connection.Id
        Assert-NotNull $connectionApprove;
        Assert-AreEqual "Approved" $connectionApprove.PrivateLinkServiceConnectionState.Status

        Start-TestSleep -Seconds 20

        $connectionRemove = Remove-AzPrivateEndpointConnection -ResourceId $connection.Id -PassThru -Force
        Assert-AreEqual true $connectionRemove

        Start-TestSleep -Seconds 15

        $connection2 = Get-AzPrivateEndpointConnection -PrivateLinkResourceId $scope1.Id
        Assert-Null $connection2

        #delete private link scope
        $delete1 = Remove-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name1
        $delete2 = Remove-AzInsightsPrivateLinkScope -ResourceId $scope2.Id
        $delete3 = $scope3 | Remove-AzInsightsPrivateLinkScope

        Assert-AreEqual true $delete1
        Assert-AreEqual true $delete2
        Assert-AreEqual true $delete3
    }
    catch
    {
        throw $_;
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rg_name;
    }
}

function Test-PrivateLinkScopedResourceCRUD
{
    # setup
    $rg_name = Get-ResourceGroupName

    $scope_name1 = Get-ResourceName
    $scope_name2 = Get-ResourceName

    $la_name = Get-ResourceName
    $ai_name = Get-ResourceName

    $scoped_resource_name1 = Get-ResourceName
    $scoped_resource_name2 = Get-ResourceName

    try 
    {
        #create resource group
        New-AzResourceGroup -Name $rg_name -Location "westus"

        #create private link scope
        New-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name1 -Location "global"
        New-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name2 -Location "global"

        #create LA workspace
        $la = New-AzOperationalInsightsWorkspace -ResourceGroupName $rg_name -Name $la_name -Location "eastus"

        #create AI component
        $ai = New-AzApplicationInsights -ResourceGroupName $rg_name -Name $ai_name -Location "eastus"

        #create scoped resource for AI/LA
        New-AzInsightsPrivateLinkScopedResource -LinkedResourceId $ai.Id -ResourceGroupName $rg_name -ScopeName $scope_name1 -Name $scoped_resource_name1
        New-AzInsightsPrivateLinkScopedResource -LinkedResourceId $la.ResourceId -ResourceGroupName $rg_name -ScopeName $scope_name2 -Name $scoped_resource_name2

        #get scoped resource
        $scoped_resource1 = Get-AzInsightsPrivateLinkScopedResource -ResourceGroupName $rg_name -ScopeName $scope_name1 -Name $scoped_resource_name1
        $scoped_resource2 = Get-AzInsightsPrivateLinkScopedResource -ResourceGroupName $rg_name -ScopeName $scope_name2 -Name $scoped_resource_name2
        
        Assert-NotNull $scoped_resource1
        Assert-NotNull $scoped_resource2
        Assert-AreEqual $ai.Id $scoped_resource1.LinkedResourceId
        Assert-AreEqual $la.ResourceId $scoped_resource2.LinkedResourceId

        #delete scoped resource
        $delete1 = Remove-AzInsightsPrivateLinkScopedResource -ResourceGroupName $rg_name -ScopeName $scope_name1 -Name $scoped_resource_name1
        $delete2 = Remove-AzInsightsPrivateLinkScopedResource -ResourceGroupName $rg_name -ScopeName $scope_name2 -Name $scoped_resource_name2

        Assert-AreEqual true $delete1
        Assert-AreEqual true $delete2

        Remove-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name1
        Remove-AzInsightsPrivateLinkScope -ResourceGroupName $rg_name -Name $scope_name2
    }
    catch
    {
        throw $_
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rg_name;
    }
}