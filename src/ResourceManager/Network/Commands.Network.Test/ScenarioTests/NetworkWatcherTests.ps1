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
Tests creating new simple public networkinterface.
#>
function Test-NetworkWatcherCRUD
{
    # Setup
    $rgname = Get-ResourceGroupName
    $nwName = Get-ResourceName
    $rglocation = Get-ProviderLocation ResourceManagement
    $resourceTypeParent = "Microsoft.Network/networkWatchers"
    $location = "westcentralus"
    
    try 
    {
        # Create the resource group
        $resourceGroup = New-AzureRmResourceGroup -Name $rgname -Location $rglocation -Tags @{ testtag = "testval" }
        
        # Create the Network Watcher
        $tags = @{"key1" = "value1"; "key2" = "value2"}
        $nw = New-AzureRmNetworkWatcher -Name $nwName -ResourceGroupName $rgname -Location $location -Tag $tags

        Assert-AreEqual $nw.Name $nwName
        Assert-AreEqual "Succeeded" $nw.ProvisioningState

        # Get Network Watcher
        $getNW = Get-AzureRmNetworkWatcher -ResourceGroupName $rgname -Name $nwName

        Assert-AreEqual $getNW.Name $nwName		
        Assert-AreEqual "Succeeded" $nw.ProvisioningState

        # List Network Watchers
        $listNWByRg = Get-AzureRmNetworkWatcher -ResourceGroupName $rgname
        $listNW = Get-AzureRmNetworkWatcher

        Assert-AreEqual 1 @($listNWByRg).Count

        # Delete Network Watcher
        $job = Remove-AzureRmNetworkWatcher -ResourceGroupName $rgname -name $nwName -AsJob
		$job | Wait-Job
		$delete = $job | Receive-Job

        $list = Get-AzureRmNetworkWatcher -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
