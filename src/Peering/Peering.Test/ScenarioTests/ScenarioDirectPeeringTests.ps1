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
Helper Function CreateDirectPeeringPrefix 
#>
function Test-CreateGetListRemovePeeringServicePrefix {
    #setting local variables
    $name = getAssetName "peeringService";
    $prefixName = getAssetName "prefix";
    $loc = "Illinois"
    $resourceGroup = getAssetName "rg"
    $registeredPrefix = (CreateSubnetIpv4 24)

    #running cmdlets
    try {
        $item = CreateDirectPeeringForUseWithPeering $resourceGroup
        Write-Output $item
        $peering = Get-AzPeering -ResourceId $item.Id
        NewRegisteredPrefix $resourceGroup $peering.Name $prefixName $registeredPrefix
        $prefix = $peering | Get-AzPeeringRegisteredPrefix -Name $prefixName
        Assert-NotNull $prefix
        $providerName = Get-AzPeerAsn -ResourceId $peering.PeerAsn.Id
        if (AddRoute $prefix.Prefix $providerName.PeerAsnProperty) {
            Write-Output $prefix.Prefix
        }
    
        #From the customer now
        Assert-ThrowsContains {NewPeeringServicePrefix $resourceGroup $name $prefixName $loc $providerName.PeerName $prefix.PeeringServicePrefixKey $prefix.Prefix} "error"
        #Assert-NotNull $peeringService
        #Assert-AreEqual $prefix.PeeringServicePrefixKey $peeringService.PeeringServicePrefixKey 
        #Assert-AreEqual $registeredPrefix $peeringService.Prefix
    } 
    catch {
        #get and remove
        #Assert-True {Remove-AzPeeringServicePrefix -ResourceId $peeringService.Id -Force -PassThru}
        #Assert-True {Remove-AzPeeringService -ResourceGroupName $resourceGroup -Name $name -Force -PassThru}
    }
}

<#
.SYNOPSIS
NewPeeringServicePrefix
#>
function NewPeeringServicePrefix($resourceGroup, $name, $prefixName, $loc, $provider, $key, $prefix) {
    $peeringService = New-AzPeeringService -ResourceGroupName $resourceGroup -Name $name -PeeringLocation $loc -PeeringServiceProvider $provider
    $peeringService = Get-AzPeeringService -ResourceGroupName $resourceGroup -Name $name
    $prefixService = $peeringService | New-AzPeeringServicePrefix -Name $prefixName -Prefix $prefix -ServiceKey $key
    Assert-NotNull $prefixService
    $getPrefixService = Get-AzPeeringServicePrefix -ResourceGroupName $resourceGroup -PeeringServiceName $name -Name $prefixName 
    Assert-NotNull $getPrefixService
    return $getPrefixService
}

function NewRegisteredPrefix($resourceGroup, $name, $prefixName, $prefix) {
    return New-AzPeeringRegisteredPrefix -ResourceGroupName $resourceGroup -PeeringName $name -Name $prefixName -Prefix $prefix
}