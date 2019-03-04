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
Deployment of new Network Watcher.
#>
function DeleteIfExistsNetworkWatcher($location)
{
	# Get Network Watcher
	$nwlist = Get-AzNetworkWatcher
	foreach ($i in $nwlist)
	{
		if($i.Location -eq "$location") 
		{
			$nw=$i
		}
	}

	# Delete Network Watcher if existing nw
	if ($nw) 
	{
		$job = Remove-AzNetworkWatcher -NetworkWatcher $nw -AsJob
		$job | Wait-Job
	}
}

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
    $location = Get-ProviderLocation $resourceTypeParent "westcentralus"
    
    try 
    {
        $resourceGroup = New-AzResourceGroup -Name $rgname -Location  $rglocation -Tags @{ testtag = "testval" }
        
		DeleteIfExistsNetworkWatcher -location $location

        # Create the Network Watcher
        $tags = @{"key1" = "value1"; "key2" = "value2"}
        $nw = New-AzNetworkWatcher -Name $nwName -ResourceGroupName $rgname -Location $location -Tag $tags

        Assert-AreEqual $nw.Name $nwName
        Assert-AreEqual "Succeeded" $nw.ProvisioningState
		
        # Get Network Watcher
        $getNW = Get-AzNetworkWatcher -ResourceGroupName $rgname -Name $nwName
		
        Assert-AreEqual $getNW.Name $nwName		
        Assert-AreEqual "Succeeded" $nw.ProvisioningState
		
        # List Network Watchers
        $listNWByRg = Get-AzNetworkWatcher -ResourceGroupName $rgname
        $listNW = Get-AzNetworkWatcher
		
        Assert-AreEqual 1 @($listNWByRg).Count

        $listNW = Get-AzNetworkWatcher -ResourceGroupName "*"
        Assert-True { $listNW.Count -ge 0 }

        $listNW = Get-AzNetworkWatcher -Name "*"
        Assert-True { $listNW.Count -ge 0 }

        $listNW = Get-AzNetworkWatcher -ResourceGroupName "*" -Name "*"
        Assert-True { $listNW.Count -ge 0 }
		
        # Delete Network Watcher
        $job = Remove-AzNetworkWatcher -ResourceGroupName $rgname -name $nwName -AsJob
        $job | Wait-Job
        $delete = $job | Receive-Job
		
        $list = Get-AzNetworkWatcher -ResourceGroupName $rgname
        Assert-AreEqual 0 @($list).Count
    }
    finally
    {
        # Cleanup
        Clean-ResourceGroup $rgname
    }
}
