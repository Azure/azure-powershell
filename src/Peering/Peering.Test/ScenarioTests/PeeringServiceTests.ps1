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
GetPeeringServiceProviders 
#>
function Test-GetPeeringServiceProviders {
    #static names are used because providers are not random.
    $name = "TestPeer1"
    $provider = Get-AzPeeringServiceProvider
    Assert-NotNull $provider
    Assert-AreEqual $name $provider[0].ServiceProviderName
}

<#
.SYNOPSIS
GetPeeringServiceLocations
#>
function Test-GetPeeringServiceLocations {
    $locations = Get-AzPeeringServiceLocation -Country "United States"
    Assert-NotNull $locations
    $state = $locations | Where-Object { $_.Name -match "Washington" }
    Assert-NotNull "Washington" $state
    $locations = Get-AzPeeringServiceLocation -Country "United States"
    Assert-NotNull $locations
}

<#
.SYNOPSIS
GetPeeringServiceProviders 
#>
function Test-GetPeeringServiceByResourceGroup {
    #Hard Coded locations becuase of limitations in locations
    $name = getAssetName "myPeeringService";
    $loc = "Florida"
    $provider = "AS56845-Global1191"
    $resourceGroup = "Building40"
    $peeringService = New-AzPeeringService -ResourceGroupName $resourceGroup -Name $name -PeeringLocation $loc -PeeringServiceProvider $provider
    Assert-NotNull $peeringService
    Assert-AreEqual $peeringService.Name $name
    Assert-AreEqual $loc $peeringService.PeeringServiceLocation
    Assert-AreEqual $provider $peeringService.PeeringServiceProvider
    $peeringService = Get-AzPeeringService -ResourceGroupName $resourceGroup -Name $name
    Assert-NotNull $peeringService
    Assert-AreEqual $peeringService.Name $name
    Assert-AreEqual $loc $peeringService.PeeringServiceLocation
    Assert-AreEqual $provider $peeringService.PeeringServiceProvider
}

<#
.SYNOPSIS
GetPeeringServiceLocations
#>
function Test-GetPeeringServiceByResourceId {
    #Hard Coded locations becuase of limitations in locations
    $name = getAssetName "myPeeringService";
    $loc = "Florida"
    $provider = "AS56845-Global1191"
    $resourceGroup = "Building40"
    $peeringService = New-AzPeeringService -ResourceGroupName $resourceGroup -Name $name -PeeringLocation $loc -PeeringServiceProvider $provider
    Assert-NotNull $peeringService
    Assert-AreEqual $peeringService.Name $name
    Assert-AreEqual $loc $peeringService.PeeringServiceLocation
    Assert-AreEqual $provider $peeringService.PeeringServiceProvider
    $peeringService = Get-AzPeeringService -ResourceId $peeringService.Id
    Assert-NotNull $peeringService
    Assert-AreEqual $peeringService.Name $name
    Assert-AreEqual $loc $peeringService.PeeringServiceLocation
    Assert-AreEqual $provider $peeringService.PeeringServiceProvider
}

<#
.SYNOPSIS
GetPeeringServiceProviders 
#>
function Test-ListPeeringService {
    $peeringService = Get-AzPeeringService
    Assert-NotNull $peeringService
}

<#
.SYNOPSIS
GetPeeringServiceLocations
#>
function Test-NewPeeringService {
    #Hard Coded locations becuase of limitations in locations
    $name = getAssetName "myPeeringService";
    $loc = "Florida"
    $provider = "AS56845-Global1191"
    $resourceGroup = "Building40"
    $peeringService = New-AzPeeringService -ResourceGroupName $resourceGroup -Name $name -PeeringLocation $loc -PeeringServiceProvider $provider
    Assert-NotNull $peeringService
    Assert-AreEqual $peeringService.Name $name
    Assert-AreEqual $loc $peeringService.PeeringServiceLocation
    Assert-AreEqual $provider $peeringService.PeeringServiceProvider
}

<#
.SYNOPSIS
GetPeeringServiceLocations
#>
function Test-NewPeeringServicePrefix {
    #Hard Coded locations becuase of limitations in locations
    $name = getAssetName "myPeeringService";
    $prefixName = getAssetName "myPrefix";
	$loc = "Florida"
    $provider = "AS56845-Global1191"
    $resourceGroup = "Building40"
    $prefix = newIpV4Address $true $true 0 4
	$peeringService = New-AzPeeringService -ResourceGroupName $resourceGroup -Name $name -PeeringLocation $loc -PeeringServiceProvider $provider
    $peeringService = Get-AzPeeringService -ResourceGroupName $resourceGroup -Name $name
    $prefixService = $peeringService | New-AzPeeringServicePrefix -Name $prefixName -Prefix $prefix
    Assert-NotNull $prefixService
    <#
	.SYNOPSIS
	GetPeeringServicePrefix 
	#>
    $getPrefixService = Get-AzPeeringServicePrefix -ResourceGroupName $resourceGroup -PeeringServiceName $name -Name $prefixName
    Assert-NotNull $getPrefixService

    <#
	.SYNOPSIS
	DeletePeeringServicePrefx 
	#>
    $isRemoved = Remove-AzPeeringServicePrefix -ResourceId $getPrefixService.Id -Force -PassThru
    Assert-AreEqual $isRemoved $true
}
