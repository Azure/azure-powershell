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

$ResourceGroupNamePrefix = "powershell-signalr-unit-test-"

<#
.SYNOPSIS
Test common SignalR cmdlets.
#>
function Test-AzureRmSignalR {
    # Setup
    $resourceGroupName = Get-RandomResourceGroupName
    $signalrName = Get-RandomSignalRName
    $freeSignalRName = Get-RandomSignalRName "signalr-free-test-"
    $location = Get-ProviderLocation "Microsoft.SignalRService/SignalR"

    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location

        # New Standard SignalR
        $signalr = New-AzSignalR -ResourceGroupName $resourceGroupName -Name $signalrName -Sku "Standard_S1"
        Verify-SignalR $signalr $signalrName $location "Standard_S1" 1

        # List the SignalR instances by resource group, should return a single SignalR instance
        $signalrs = Get-AzSignalR -ResourceGroupName $resourceGroupName
        Assert-NotNull $signalrs
        Assert-AreEqual "PSSignalRResource" $signalrs.GetType().Name
        Verify-SignalR $signalrs $signalrName $location "Standard_S1" 1

        # Get the SignalR instance by name
        $retrievedSignalR = Get-AzSignalR -ResourceGroupName $resourceGroupName -Name $signalrName
        Verify-SignalR $retrievedSignalR $signalrName $location "Standard_S1" 1

        # create another free instance in the same resource group
        $freeSignalR = New-AzSignalR -ResourceGroupName $resourceGroupName -Name $freeSignalRName -Sku "Free_F1"
        Verify-SignalR $freeSignalR $freeSignalRName $location "Free_F1" 1

        # List all the SignalR instances in the resource group
        $signalrs = Get-AzSignalR -ResourceGroupName $resourceGroupName
        Assert-NotNull $signalrs
        Assert-AreEqual "Object[]" $signalrs.GetType().Name
        Assert-AreEqual 2 $signalrs.Length
        $freeSignalR = $signalrs | Where-Object -FilterScript {$_.Sku.Name -eq "Free_F1"}
        $standardSignalR = $signalrs | Where-Object -FilterScript {$_.Sku.Name -eq "Standard_S1"}
        Assert-NotNull $freeSignalR
        Assert-NotNull $standardSignalR
        Verify-SignalR $freeSignalR $freeSignalRName $location "Free_F1" 1

        # Get the SignalR instance keys
        $keys = Get-AzSignalRKey -ResourceGroupName $resourceGroupName -Name $signalrName
        Assert-NotNull $keys
        Assert-NotNull $keys.PrimaryKey
        Assert-NotNull $keys.PrimaryConnectionString
        Assert-NotNull $keys.SecondaryKey
        Assert-NotNull $keys.SecondaryConnectionString

        # regenerate the primary key
        $ret = New-AzSignalRKey -ResourceGroupName $resourceGroupName -Name $signalrName -KeyType Primary -PassThru
        Assert-True { $ret }
        $newKeys1 = Get-AzSignalRKey -ResourceGroupName $resourceGroupName -Name $signalrName
        Assert-NotNull $newKeys1
        Assert-AreNotEqual $keys.PrimaryKey $newKeys1.PrimaryKey
        Assert-AreNotEqual $keys.PrimaryConnectionString $newKeys1.PrimaryConnectionString
        Assert-AreEqual $keys.SecondaryKey $newKeys1.SecondaryKey
        Assert-AreEqual $keys.SecondaryConnectionString $newKeys1.SecondaryConnectionString

        # regenerate the secondary key
        $ret = New-AzSignalRKey -ResourceGroupName $resourceGroupName -Name $signalrName -KeyType Secondary
        Assert-Null $ret
        $newKeys2 = Get-AzSignalRKey -ResourceGroupName $resourceGroupName -Name $signalrName
        Assert-NotNull $newKeys2
        Assert-AreEqual $newKeys1.PrimaryKey $newKeys2.PrimaryKey
        Assert-AreEqual $newKeys1.PrimaryConnectionString $newKeys2.PrimaryConnectionString
        Assert-AreNotEqual $newKeys1.SecondaryKey $newKeys2.SecondaryKey
        Assert-AreNotEqual $newKeys1.SecondaryConnectionString $newKeys2.SecondaryConnectionString

        Remove-AzSignalR -ResourceGroupName $resourceGroupName -Name $signalrName

        Get-AzSignalR -ResourceGroupName $resourceGroupName | Remove-AzSignalR
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

<#
.SYNOPSIS
Test SignalR cmdlets using default arguments.
#>
function Test-AzureRmSignalRWithDefaultArgs {
    $resourceGroupName = Get-RandomResourceGroupName
    $signalrName = Get-RandomSignalRName
    $freeSignalRName = Get-RandomSignalRName "signalr-free-test-"
    $location = Get-ProviderLocation "Microsoft.SignalRService/SignalR"

    try {
		New-AzResourceGroup -Name $resourceGroupName -Location $location

        # New without SignalR resource group, use the SignalR instance name as the resource group
        $signalr = New-AzSignalR -Name $resourceGroupName
        Verify-SignalR $signalr $resourceGroupName $location "Standard_S1" 1

        $signalrs = Get-AzSignalR -ResourceGroupName $resourceGroupName
        Assert-NotNull $signalrs
        Assert-AreEqual "PSSignalRResource" $signalrs.GetType().Name
        Verify-SignalR $signalrs $resourceGroupName $location "Standard_S1" 1

        # Set AzureRm default resource group name, and subsequent calls will use this as the resource group if missing.
        Set-AzDefault -ResourceGroupName $resourceGroupName
        $signalr = New-AzSignalR -Name $signalrName -Sku "Free_F1"

        # List all the SignalR instances in the resource group
        $signalrs = Get-AzSignalR -ResourceGroupName $resourceGroupName
        Assert-NotNull $signalrs
        Assert-AreEqual "Object[]" $signalrs.GetType().Name
        Assert-AreEqual 2 $signalrs.Length
        $freeSignalR = $signalrs | Where-Object -FilterScript {$_.Sku.Name -eq "Free_F1"}
        $standardSignalR = $signalrs | Where-Object -FilterScript {$_.Sku.Name -eq "Standard_S1"}
        Assert-NotNull $freeSignalR
        Assert-NotNull $standardSignalR
        Verify-SignalR $freeSignalR $signalrName $location "Free_F1" 1

        #Get keys from the SignalR instance in the default resource group
        $keys = Get-AzSignalRKey -Name $signalrName
        Assert-NotNull $keys
        Assert-NotNull $keys.PrimaryKey
        Assert-NotNull $keys.PrimaryConnectionString
        Assert-NotNull $keys.SecondaryKey
        Assert-NotNull $keys.SecondaryConnectionString

        # Regenerate keys for the SignalR instance in the default resource group
        $ret = New-AzSignalRKey -Name $signalrName -KeyType Primary -PassThru
        Assert-True { $ret }
        $newKeys1 = Get-AzSignalRKey -Name $signalrName
        Assert-NotNull $newKeys1
        Assert-AreNotEqual $keys.PrimaryKey $newKeys1.PrimaryKey
        Assert-AreNotEqual $keys.PrimaryConnectionString $newKeys1.PrimaryConnectionString
        Assert-AreEqual $keys.SecondaryKey $newKeys1.SecondaryKey
        Assert-AreEqual $keys.SecondaryConnectionString $newKeys1.SecondaryConnectionString

        # Remove the SignalR instance with the given name in the default resource group
        Remove-AzSignalR -Name $signalrName

        # Get the SignalR instance with the given name in the default resource group and remove
        Get-AzSignalR -Name $resourceGroupName | Remove-AzSignalR
    }
    finally {
        Remove-AzResourceGroup -Name $resourceGroupName -Force
    }
}

<#
.SYNOPSIS
Verify basic SignalR object properties.
#>
function Verify-SignalR {
    param(
        [Microsoft.Azure.Commands.SignalR.Models.PSSignalRResource] $signalr,
        [string] $signalrName,
        [string] $location,
        [string] $sku,
        [int] $unitCount
    )
    Assert-NotNull $signalr
    Assert-NotNull $signalr.Id
    Assert-NotNull $signalr.Type
    Assert-AreEqual $signalrName $signalr.Name
    Assert-LocationEqual $location $signalr.Location

    Assert-NotNull $signalr.Sku
    Assert-AreEqual ([Microsoft.Azure.Commands.SignalR.Models.PSResourceSku]) $signalr.Sku.GetType()
    Assert-AreEqual $sku $signalr.Sku.Name
    Assert-AreEqual $unitCount $signalr.Sku.Capacity
    Assert-AreEqual "Succeeded" $signalr.ProvisioningState
    Assert-AreEqual "$signalrName.service.signalr.net" $signalr.HostName
    Assert-NotNull $signalr.ExternalIP
    Assert-NotNull $signalr.PublicPort
    Assert-NotNull $signalr.ServerPort
    Assert-NotNull $signalr.Version
}

<#
.SYNOPSIS
Test Update networkAcl cmdlets
#>
function Test-AzureRmSignalRUpdateNetworkAcl {
    $nameSuffix = "update-networkAcl"
    $resourceGroupName = Get-RandomResourceGroupName  $nameSuffix
    $signalrName =  Get-RandomSignalRName  $nameSuffix


    try {
        New-Environment -signalRName $signalrName -resourceGroupName $resourceGroupName
        Set-AzDefault -ResourceGroupName $resourceGroupName      
        
        # Set AzureRm default resource group name, and subsequent calls will use this as the resource group if missing.
        Set-AzDefault -ResourceGroupName $resourceGroupName      

        # Test Parameters Set
        # a. default parameter set / ResourceGroupParameterSet
        $networkAcl = Update-AzSignalRNetworkAcl -name $signalrName -ResourceGroupName $resourceGroupName  -PublicNetwork -Allow RESTAPI  -Deny ClientConnection, ServerConnection
        Assert-AreEqual $networkAcl.PublicNetwork.Allow RESTAPI
        Assert-AreEqualArray $networkAcl.PublicNetwork.Deny ServerConnection, ClientConnection
  
        # b.  ResourceId parameter set
        $signalr = Get-AzSignalR  -name $signalrName -ResourceGroupName $resourceGroupName 
        $networkAcl = Update-AzSignalRNetworkAcl -ResourceId $signalr.id    -PublicNetwork -Deny RESTAPI  -Allow ClientConnection, ServerConnection
        $signalr = Get-AzSignalR  -name $signalrName 
        Assert-AreEqual $networkAcl.PublicNetwork.Deny RESTAPI
        Assert-AreEqualArray $networkAcl.PublicNetwork.Allow ServerConnection, ClientConnection
  
        # c. InputObject parameter Set
        $signalr | Update-AzSignalRNetworkAcl -Deny ClientConnection, ServerConnection -Allow RESTAPI   -PublicNetwork
        $networkAcl = Update-AzSignalRNetworkAcl -name $signalrName -ResourceGroupName $resourceGroupName
        Assert-AreEqualArray ServerConnection, ClientConnection    $networkAcl.PublicNetwork.Deny
        Assert-AreEqual $networkAcl.PublicNetwork.Allow RESTAPI
  
        # Test update default action, private endpoint , public network all together
        $privateEndpointName = $networkAcl.PrivateEndpoints[0].Name;
        $networkAcl = Update-AzSignalRNetworkAcl -name $signalrName -ResourceGroupName $resourceGroupName  -PrivateEndpointName $privateEndpointName  -Allow RESTAPI, ClientConnection  -Deny ServerConnection -PublicNetwork -DefaultAction Deny
        Assert-AreEqual $networkAcl.DefaultAction Deny
        Assert-AreEqual $networkAcl.PublicNetwork.Deny ServerConnection
        Assert-AreEqualArray $networkAcl.PublicNetwork.Allow ClientConnection, RESTAPI
        Assert-AreEqual $networkAcl.PrivateEndpoints[0].Deny ServerConnection
        Assert-AreEqualArray $networkAcl.PrivateEndpoints[0].Allow ClientConnection, RESTAPI
  
        # Test update default action
        $networkAcl = Update-AzSignalRNetworkAcl -name $signalrName -ResourceGroupName $resourceGroupName  -DefaultAction Deny
        Assert-AreEqual $networkAcl.DefaultAction deny
        $networkAcl = Update-AzSignalRNetworkAcl -name $signalrName -ResourceGroupName $resourceGroupName  -DefaultAction Allow
        Assert-AreEqual $networkAcl.DefaultAction Allow
  
        # Test update private endpoint network Acl
        # update only one private endpoint
        $unmodifiedAllow = $networkAcl.PrivateEndpoints[1].Allow;
        $unmodifiedDeny = $networkAcl.PrivateEndpoints[1].Deny;
        $networkAcl = Update-AzSignalRNetworkAcl -name $signalrName -ResourceGroupName $resourceGroupName  -PrivateEndpointName $privateEndpointName  -Deny RESTAPI  -Allow ClientConnection, ServerConnection
        Assert-AreEqual $networkAcl.PrivateEndpoints[0].Deny RESTAPI
        Assert-AreEqualArray $networkAcl.PrivateEndpoints[0].Allow ServerConnection, ClientConnection
        Assert-AreEqualArray $unmodifiedAllow $networkAcl.PrivateEndpoints[1].Allow
        Assert-Null $unmodifiedDeny 
        Assert-Null $networkAcl.PrivateEndpoints[1].Deny
        $networkAcl = Update-AzSignalRNetworkAcl -name $signalrName -ResourceGroupName $resourceGroupName  -PrivateEndpointName $privateEndpointName  -Allow RESTAPI  -Deny ClientConnection, ServerConnection
        Assert-AreEqual $networkAcl.PrivateEndpoints[0].Allow RESTAPI
        Assert-AreEqualArray $networkAcl.PrivateEndpoints[0].Deny ServerConnection, ClientConnection   # order of deny/allow Acls are defined by server
        Assert-AreEqualArray $unmodifiedAllow $networkAcl.PrivateEndpoints[1].Allow
        Assert-Null $unmodifiedDeny 
        Assert-Null $networkAcl.PrivateEndpoints[1].Deny
        # update two private endpoint network Acls
        $privateEndpointName1 = $networkAcl.PrivateEndpoints[1].Name;
        $networkAcl = Update-AzSignalRNetworkAcl -name $signalrName -ResourceGroupName $resourceGroupName  -PrivateEndpointName $privateEndpointName, $privateEndpointName1  -Deny RESTAPI, ServerConnection  -Allow ClientConnection
        Assert-AreEqualArray $networkAcl.PrivateEndpoints[0].Deny RESTAPI, ServerConnection
        Assert-AreEqual $networkAcl.PrivateEndpoints[0].Allow ClientConnection
        Assert-AreEqualArray $networkAcl.PrivateEndpoints[1].Deny RESTAPI, ServerConnection
        Assert-AreEqual $networkAcl.PrivateEndpoints[1].Allow ClientConnection
    }
    finally {
        Remove-Environment -resourceGroupName $resourceGroupName -signalRName $signalRName
    }
}

<#
.SYNOPSIS
Test Set Upstream cmdlets
#>
function Test-AzureRmSignalRSetUpstream {
    $location = Get-ProviderLocation "Microsoft.SignalRService/SignalR"
    $nameSuffix = "set-upstream"
    $resourceGroupName = Get-RandomResourceGroupName $nameSuffix
    $signalrName =  Get-RandomSignalRName  $nameSuffix
    try {
        New-AzResourceGroup -Name $resourceGroupName -Location $location
        $signalr = New-AzSignalR -ResourceGroupName $resourceGroupName -Name $signalrName
    
        $upstream = Set-AzSignalRUpstream -ResourceGroupName $resourceGroupName -Name $signalrName `
            -Template @{UrlTemplate = 'http://host-connections1.com' }
        Assert-AreEqualObjectProperties @{UrlTemplate = 'http://host-connections1.com' } $upstream.Templates
    
        # b. ResourceId parameter set
        $upstream = Set-AzSignalRUpstream -ResourceId $signalr.Id `
            -Template @{UrlTemplate = 'http://host-connections2.com' }
        Assert-AreEqualObjectProperties @{UrlTemplate = 'http://host-connections2.com' } $upstream.Templates
    
        # c. InputObject parameter set
        $signalr | Set-AzSignalRUpstream -Template @{UrlTemplate = 'http://host-connections3.com' }
        Assert-AreEqualObjectProperties @{UrlTemplate = 'http://host-connections3.com' } $upstream.Templates
    
        # Test set multiple upstream Template
        $upstream = Set-AzSignalRUpstream  -ResourceId $signalr.Id `
            -Template @{UrlTemplate = 'http://host-connections4.com'; HubPattern = 'chat'; EventPattern = 'broadcast' }, @{UrlTemplate = 'http://host-connections5.com'; HubPattern = 'chat'; CategoryPattern = 'broadcast' } 
        Assert-AreEqualObjectProperties @{UrlTemplate = 'http://host-connections4.com'; HubPattern = 'chat'; EventPattern = 'broadcast' }, @{UrlTemplate = 'http://host-connections5.com'; HubPattern = 'chat'; CategoryPattern = 'broadcast' }   $upstream.Templates
    
        # 
    }
    finally {
        Remove-AzResourceGroup  -Name $resourceGroupName 
    }

}
function New-Environment {
    param (
        [string] $signalRName,
        [string] $resourceGroupName
    )

    $location = Get-ProviderLocation "Microsoft.SignalRService/SignalR"
    $virtualNetworkName = "virtualNetwork"+(getAssetName)
    $subnetName = "subnet"+(getAssetName)
    $zoneName = "zone"+(getAssetName)+".contoso.com"
    $linkName = "link" +(getAssetName)
    $privateEndpointName = "privateEndpoint" + (getAssetName)

    New-AzResourceGroup -Name $resourceGroupName -Location $location

    # set up the first private endpoint
    $virtualNetwork = New-AzVirtualNetwork `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -Name $virtualNetworkName `
        -AddressPrefix 10.0.0.0/16

    $signalr = New-AzSignalR -ResourceGroupName $resourceGroupName -Name $signalrName -Sku "Standard_S1"
    

    $subnetConfig = Add-AzVirtualNetworkSubnetConfig -Name $subnetName  -AddressPrefix 10.0.0.0/24  -PrivateEndpointNetworkPoliciesFlag "Disabled"  -VirtualNetwork $virtualNetwork

    $virtualNetwork | Set-AzVirtualNetwork

    $zone = New-AzPrivateDnsZone -Name $zoneName  -ResourceGroupName $resourceGroupName

    $link = New-AzPrivateDnsVirtualNetworkLink -ZoneName $zoneName `
        -ResourceGroupName $resourceGroupName -Name $linkName  `
        -VirtualNetworkId $virtualNetwork.id -EnableRegistration

    $privateEndpointConnection = New-AzPrivateLinkServiceConnection -Name  $privateEndpointName  ` -PrivateLinkServiceId $signalr.Id ` -GroupId "signalr" 

    $virtualNetwork = Get-AzVirtualNetwork -ResourceGroupName "$resourceGroupName" -Name  $virtualNetworkName

    $subnet = $virtualNetwork ` | Select -ExpandProperty subnets ` | Where-Object { $_.Name -eq $subnetName } 

    $privateEndpoint = New-AzPrivateEndpoint -ResourceGroupName "$resourceGroupName" ` -Name $privateEndpointName ` -Location $location ` -Subnet $subnet ` -PrivateLinkServiceConnection $privateEndpointConnection

    $virtualNetworkName2 = "virtualNetwork2"+(getAssetName)
    $subnetName2 = "subnet2"+(getAssetName)
    $zoneName2 = "zone2"+(getAssetName)+".contoso.com"
    $linkName2 = "link2" +(getAssetName)
    $privateEndpointName2 = "privateEndpoint2" + (getAssetName)

    # set up the second private endpoint
    $virtualNetwork = New-AzVirtualNetwork `
        -ResourceGroupName $resourceGroupName `
        -Location $location `
        -Name $virtualNetworkName2 `
        -AddressPrefix 10.0.0.0/16


    $subnetConfig = Add-AzVirtualNetworkSubnetConfig  -Name $subnetName2 -AddressPrefix 10.0.0.0/24 -PrivateEndpointNetworkPoliciesFlag "Disabled" -VirtualNetwork $virtualNetwork

    $virtualNetwork | Set-AzVirtualNetwork

    $zone = New-AzPrivateDnsZone -Name  $zoneName2 -ResourceGroupName $resourceGroupName

    $link = New-AzPrivateDnsVirtualNetworkLink -ZoneName $zoneName2   -ResourceGroupName $resourceGroupName -Name $linkName2   -VirtualNetworkId $virtualNetwork.id -EnableRegistration

    $privateEndpointConnection = New-AzPrivateLinkServiceConnection -Name $privateEndpointName2 ` -PrivateLinkServiceId $signalr.Id ` -GroupId "signalr" 

    $virtualNetwork = Get-AzVirtualNetwork -ResourceGroupName $resourceGroupName -Name $virtualNetworkName2

    $subnet = $virtualNetwork ` | Select -ExpandProperty subnets ` | Where-Object { $_.Name -eq $subnetName2 } 

    $privateEndpoint = New-AzPrivateEndpoint -ResourceGroupName "$resourceGroupName" ` -Name $privateEndpointName2 ` -Location $location ` -Subnet $subnet ` -PrivateLinkServiceConnection $privateEndpointConnection

}

function Remove-Environment {
    param(
        [string] $resourceGroupName
    )
    Remove-AzResourceGroup -Name $resourceGroupName
}