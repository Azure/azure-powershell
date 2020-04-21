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

#cd ..
$dll = Get-ChildItem | Where-Object { $_.Name -match "Peering.Test.dll" } | ForEach-Object { $_.FullName };
[Reflection.Assembly]::LoadFile($dll);
$ipGenerator = New-Object Microsoft.Azure.Commands.Peering.Test.ScenarioTests.IPGenerator;
$serviceClient = New-Object Microsoft.Azure.Commands.Peering.Test.ScenarioTests.InternalServiceClient;
$serviceClient.SyncWithKusto();
<#
.SYNOPSIS
Creates a resource group to use in tests
#>
function TestSetup-CreateResourceGroup {
    $resourceGroupName = getAssetName "MockRg"
    Write-Debug "ResourceGroupName: $resourceGroupName"
    $rglocation = "Central US"
    $resourceGroup = New-AzResourceGroup -Name $resourceGroupName -location $rglocation -Force
    Write-Debug "Created $resourceGroupName"
    return $resourceGroup
}

function getPeeringLocation ($kind, $location) {
    return Get-AzPeeringLocation -Kind $kind -PeeringLocation $location
}

function isDirect ($t) {
    if ($t -eq $true) {
        return "Direct"
    }
    return "Exchange"
}

function newIpV4Address ($withPrefix, $maxPrefix, $offset, $randomNum) {
    $ipv4 = $ipGenerator.CreateIpv4Address($randomNum, $maxPrefix);
    return $ipGenerator.OffSet($ipv4, $false, $offset, $withPrefix);
}

function newIpV6Address ($withPrefix, $maxPrefix, $offset, $randomNum) {
    $ipv6 = $ipGenerator.CreateIpv6Address($randomNum, $maxPrefix);
    return $ipGenerator.OffSet($ipv6, $true, $offset, $withPrefix);
}

function changeIp($address, $isv6, $offset, $withPrefix) {
    return $ipGenerator.OffSet($address, $isv6, $offset, $withPrefix);
}

function maxAdvertisedIpv4 {
    $maxPrefixV4 = getPeeringVariable "MaxPrefixV4" $ipGenerator.BuildMaxPrefixes($false);
    return $maxPrefixV4
}

function maxAdvertisedIpv6 {
    $maxPrefixV6 = getPeeringVariable "MaxPrefixV6" $ipGenerator.BuildMaxPrefixes($true);
    return $maxPrefixV6
}

function getHash {
    $hash = getPeeringVariable "Hash" $ipGenerator.BuildHash()
    Write-Debug "The hash $hash";
    return "$hash"
}

function getBandwidth {
    $bandwidth = getPeeringVariable "bandwidth" $ipGenerator.GetBandwidth()
    Write-Debug "The bandwidth $bandwidth";
    return $bandwidth
}

function getRandomNumber {
    $num = Get-Random -Maximum 65010 -Minimum 1
    Write-Debug "The random $num";
    return $num
}

function NewContactDetail($role, $asnPeer) {
    $email = "$role@$asnPeer.com"
    return New-AzPeerAsnContactDetail -Role $role -Email $email -Phone "+1(888)-889-8088"
}

function NewAzPeerAsn($name, $peerName, $peerAsn, $contact) {
    return New-AzPeerAsn -Name $name -PeerName $peerName -PeerAsn $peerAsn -ContactDetail $contact
}

function approvePeerAsn($subscriptionId, $asnName) {
    $serviceClient.ApprovePeerAsn($subscriptionId, $asnName)
}

function makePeerAsn($asn) {
    $asnId = $asn
    $asnPeerName = getAssetName "$asn-Global"
    Write-Debug "PeerName $asnPeerName"
    $asnPeer = getAssetName "AS$asn-Global"
    Write-Debug "PeerName $asnPeer" 
    $contact0 = NewContactDetail "Noc" $asnPeer
    $contact1 = NewContactDetail "Policy" $asnPeer
    $contacts = @($contact0, $contact1)
    $created = NewAzPeerAsn $asnPeerName $asnPeer $asnId $contacts
    Write-Debug "PeerName $asnPeerName"
    $created.ValidationState = "Approved";
    Write-Debug "ValidationState: $created" 
    Write-Debug "Sleep 2 seconds..." 
    Wait-Seconds 1
    $created = $created | Set-AzPeerAsn
    Wait-Seconds 2
    return $created
}

function removePeerAsn($asn) {
    $asn | Remove-AzPeerAsn -Force
}

function NewExchangeConnectionV4V6($facilityId, $v4, $v6) {
    #Create some data for the object
    Write-Debug "Creating Connection at $facilityId"
    $md5 = getHash
    $md5 = $md5.ToString()
    Write-Debug "Created Hash $md5"
    $offset = Get-Random -Maximum 64 -Minimum 3
    $sessionv4 = changeIp "$v4/32" $false $offset $false
    $sessionv6 = changeIp "$v6/128" $true $offset $false
    Write-Debug "Created IPs $sessionv4"
    $maxv4 = maxAdvertisedIpv4
    $maxv6 = maxAdvertisedIpv6
    Write-Debug "Created maxAdvertised $maxv4 $maxv6"
    #create Connection
    $createdConnection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxv4 -PeerSessionIPv4Address $sessionv4 -PeerSessionIPv6Address $sessionv6 -MaxPrefixesAdvertisedIPv6 $maxv6 -MD5AuthenticationKey $md5
    return $createdConnection
}

function NewExchangeConnectionV4($facilityId, $v4) {
    #Create some data for the object
    Write-Debug "Creating Connection at $facilityId"
    $md5 = getHash
    $md5 = $md5.ToString()
    Write-Debug "Created Hash $md5"
    $offset = Get-Random -Maximum 64 -Minimum 3
    $sessionv4 = changeIp "$v4/32" $false $offset $false
    Write-Debug "Created IPs $sessionv4"
    $maxv4 = maxAdvertisedIpv4
    Write-Debug "Created maxAdvertised $maxv4"
    #create Connection
    $createdConnection = New-AzPeeringExchangeConnectionObject -PeeringDbFacilityId $facilityId -MaxPrefixesAdvertisedIPv4 $maxv4 -PeerSessionIPv4Address $sessionv4 -MD5AuthenticationKey $md5
    return $createdConnection
}

function getPeeringVariable {
    param([string]$variableName, $value)
    if ($value) {
        $result = $value
    }
    else {
        $result = $null
    }
    if ([Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables.ContainsKey($variableName)) {
        $result = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables[$variableName]
    }
    if (![Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Variables.ContainsKey($variableName)) {
        return $result = [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::GetVariable($variableName, $value)
    }

    return $result
}

<#
.SYNOPSIS
Asserts if two tags are equal
#>
function Assert-Tags($tags1, $tags2) {
    if ($tags1.count -ne $tags2.count) {
        throw "Tag size not equal. Tag1: $tags1.count Tag2: $tags2.count"
    }

    foreach ($key in $tags1.Keys) {
        if ($tags1[$key] -ne $tags2[$key]) {
            throw "Tag content not equal. Key:$key Tags1:" + $tags1[$key] + "Tags2:" + $tags2[$key]
        }
    }
}

function Clean-ASN($name){
try{
    Remove-AzPeerAsn -Name $name -Force -PassThru
    }catch{}
}

function Clean-Peering($id){
try{
    Remove-AzPeering -ResourceId $id -Force -PassThru
    }catch{
    }
}

<#
.SYNOPSIS
Cleans the created resource groups
#>
function Clean-ResourceGroup($rgname) {
    $assemblies = [AppDomain]::Currentdomain.GetAssemblies() | Select-Object FullName | ForEach-Object { $_.FullName.Substring(0, $_.FullName.IndexOf(',')) }
    if ($assemblies -notcontains 'Microsoft.Azure.Test.HttpRecorder.HttpMockServer' `
            -or $assemblies -notcontains 'Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode' `
            -or [Microsoft.Azure.Test.HttpRecorder.HttpMockServer]::Mode -ne [Microsoft.Azure.Test.HttpRecorder.HttpRecorderMode]::Playback) {
        try{
            Remove-AzResourceGroup -Name $rgname -Force
        }catch{ }
    }
}

function NewDirectConnectionV4V6($facilityId, $bandwidth) {
    Write-Debug "Creating Connection at $facilityId"
    $md5 = getHash
    $md5 = $md5.ToString()
    Write-Debug "Created Hash $md5"
    $rand2 = Get-Random -Maximum 200 -Minimum 1
    $sessionv4 = newIpV4Address $true $true 0 $rand2
    $sessionv6 = newIpV6Address $true $true 0 $rand2
    Write-Debug "Created IPs $sessionv4 $SessionPrefixV6"
    $maxv4 = maxAdvertisedIpv4
    $maxv6 = maxAdvertisedIpv6
    Write-Debug "Created maxAdvertised $maxv4 $maxv6"

    $createdConnection = New-AzPeeringDirectConnectionObject -PeeringDbFacilityId $facilityId -SessionPrefixV4 $sessionv4 -SessionPrefixV6 $sessionv6 -MaxPrefixesAdvertisedIPv4 $maxv4 -MaxPrefixesAdvertisedIPv6 $maxv6 -BandwidthInMbps $bandwidth -MD5AuthenticationKey $md5
    Write-Debug "Created Connection $createdConnection"
    return $createdConnection
}

function SliceSubnet($prefix, $subnet) {
    Write-Debug $prefix
    return $serviceClient.SliceSubnet($prefix, $subnet);
}

function AddRoute($prefix, $asn) {
    return $serviceClient.AddRoute($prefix, $asn);
}

function CreateSubnetIpv4($subnet) {
    return $ipGenerator.CreateIpv4AddressCIDR((getRandomNumber), $subnet);
}

function RunProvisioningManager($location) {
    return $serviceClient.RunDirectProvisioningManager($location)
}

function CreateAndApproveCustomerAsn($asn) {
    $subsription = SelectCustomerSubscription
    Write-Output "$asn $subsription"
    $peerAsn = makeCustomerPeerAsn $asn $subsription.Id
    return $peerAsn
}

function CreateDirectPeeringForUseWithPeering($rgname, $randNum = $null) {
    $kind = "Direct";
    $loc = "Chicago"
    $resourceGroup = $rgname;
    Write-Debug $resourceGroup
    #Create Asn
    Write-Debug "Getting the Asn Information"
    if ($null -ne $randNum) {
        $randNum = getRandomNumber
        Write-Debug "Random Number $randNum";
        $peerAsn = makePeerAsn $randNum
    }
    else {
        $peerAsn = Get-AzPeerAsn -Name (getAssetName $randNum)
    }
    $asn = $peerAsn
    #Create Resource
    $resourceName = getAssetName "Direct_UseForPeeringService";
    Write-Debug "Setting $resourceName"
    $peeringLocation = getPeeringLocation $kind $loc;
    $facilityId = $peeringLocation[0].PeeringDBFacilityId
    #create Connection
    $bandwidth = getBandwidth
    $bandwidth2 = getBandwidth
    $tags = @{"tag1" = "value1" }
    $connection1 = NewDirectConnectionV4V6 $facilityId $bandwidth
    #connection2
    $connection2 = NewDirectConnectionV4V6 $facilityId $bandwidth2
    #create peering
    $connection2.UseForPeeringService = $true
    $createdPeering = New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation[0].PeeringLocation -MicrosoftNetwork AS8075 -Sku "Premium_Direct_Free" -PeerAsnResourceId $asn.Id -Tag $tags -DirectConnection $connection2, $connection1
    #$ipGenerator.ApproveConnection($createdPeering.Id, $connection1.ConnectionIdentifier)
    $serviceClient.ApproveConnection($createdPeering.Id, $connection2.ConnectionIdentifier)
    RunProvisioningManager $loc
    Assert-NotNull $createdPeering
    $serviceClient.FetchProvidersFromCosmos()
    return $createdPeering
}

function CreateExchangePeering($resourceGroup, $as) {
    #Hard Coded locations becuase of limitations in locations
    Write-Debug "Getting the Asn Information"
    $peerAsn = Get-AzPeerAsn -Name $as
    $asn = $peerAsn.Id
    $resourceName = getAssetName 
    $peeringLocation = "Seattle"
    $kind = "Exchange"
    Write-Debug "Getting the Facility Information"
    $randNum = getRandomNumber
    Write-Debug "Random Number $randNum";
    $facility = Get-AzPeeringLocation -PeeringLocation $peeringLocation -Kind $kind
    $microsoftIpAddressV4 = $facility[0].MicrosoftIPv4Address.Split(',') | Select-Object -First 1
    #$microsoftIpAddressV6 = $facility[0].MicrosoftIPv6Address.Split(',') | Select-Object -First 1
    $facilityId = $facility[0].PeeringDBFacilityId
    $peeringLocation = $facility[0].PeeringLocation
    Write-Debug "Creating Connections"
    $connection1 = NewExchangeConnectionV4 $facilityId $microsoftIpAddressV4
    $connection2 = NewExchangeConnectionV4 $facilityId $microsoftIpAddressV4
    Write-Debug "Created $connection1 $connection2"
    $tags = @{"tfs_$randNum" = "Active"; "tag2" = "value2" }
    Write-Debug "Tags: $tags";
    Write-Debug "Creating Resource $resourceName"
    $createdPeering = New-AzPeering -Name $resourceName -ResourceGroupName $resourceGroup -PeeringLocation $peeringLocation -PeerAsnResourceId $asn -ExchangeConnection $connection1, $connection2 -Tag $tags
    Assert-NotNull $createdPeering
    Assert-NotNull $createdPeering.Connections.ConnectionIdentifier
    return $createdPeering
}