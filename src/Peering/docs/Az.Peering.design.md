#### New-AzPeering

#### SYNOPSIS
Creates a new peering or updates an existing peering with the specified name under the given subscription and resource group.

#### SYNTAX

```powershell
New-AzPeering -Name <String> -ResourceGroupName <String> -Kind <Kind> -Location <String>
 [-SubscriptionId <String>] [-DirectConnection <IDirectConnection[]>] [-DirectPeerAsnId <String>]
 [-DirectPeeringType <DirectPeeringType>] [-ExchangeConnection <IExchangeConnection[]>]
 [-ExchangePeerAsnId <String>] [-PeeringLocation <String>] [-Sku <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a new direct peering object
```powershell
$connection1 = New-AzPeeringDirectConnectionObject -BandwidthInMbps 10000 -BgpSessionMaxPrefixesAdvertisedV4 20000 ...
$directConnections = ,$connection1
New-AzPeering -Name TestPeeringPs -ResourceGroupName DemoRG -Kind Direct -Location "South Central US" -DirectConnection $directConnections -DirectPeeringType Cdn -DirectPeerAsnId $peerAsnId -PeeringLocation Dallas -Sku Premium_Direct_Unlimited
```

```output
Name        SkuName                  Kind   PeeringLocation ProvisioningState Location
----        -------                  ----   --------------- ----------------- --------
TestPeering Premium_Direct_Unlimited Direct Dallas          Succeeded         South Central US
```

Create a new direct peering object


#### Get-AzPeering

#### SYNOPSIS
Gets an existing peering with the specified name under the given subscription and resource group.

#### SYNTAX

+ List1 (Default)
```powershell
Get-AzPeering [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzPeering -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzPeering -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ List
```powershell
Get-AzPeering -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all peerings
```powershell
 Get-AzPeering
```

```output
Name           SkuName             Kind     PeeringLocation ProvisioningState Location
----           -------             ----     --------------- ----------------- --------
DemoComp1      Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
DemoPeering    Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
TestEdgeZone   Premium_Direct_Free Direct   Atlanta         Succeeded         East US 2
MapsIxRs       Premium_Direct_Free Direct   Ashburn         Succeeded         East US
DemoMapsConfig Premium_Direct_Free Direct   Seattle         Succeeded         West US 2
testexchange   Basic_Exchange_Free Exchange Amsterdam       Succeeded         West Europe
TestPeer1      Basic_Direct_Free   Direct   Amsterdam       Succeeded         West Europe
test1          Basic_Direct_Free   Direct   Athens          Succeeded         France Central
```

List all peerings in subscription

+ Example 2: Get specific peering by name and resource group
```powershell
Get-AzPeering -Name DemoPeering -ResourceGroupName DemoRG
```

```output
Name        SkuName             Kind   PeeringLocation ProvisioningState Location
----        -------             ----   --------------- ----------------- --------
DemoPeering Premium_Direct_Free Direct Dallas          Succeeded         South Central US
```

Get a specific peering by resource group and name


#### Remove-AzPeering

#### SYNOPSIS
Deletes an existing peering with the specified name under the given subscription and resource group.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzPeering -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzPeering -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove peering
```powershell
Remove-AzPeering -Name TestPeering -ResourceGroupName DemoRG
```

Remove a peering from the given resource group


#### Update-AzPeering

#### SYNOPSIS
Updates tags for a peering with the specified name under the given subscription and resource group.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzPeering -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>] [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzPeering -InputObject <IPeeringIdentity> [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update peering tags
```powershell
$tags=@{hello='world'}
Update-AzPeering -Name DemoPeering -ResourceGroupName DemoRG -Tag $tags
```

```output
Name        SkuName             Kind   PeeringLocation ProvisioningState Location
----        -------             ----   --------------- ----------------- --------
DemoPeering Premium_Direct_Free Direct Dallas          Succeeded         South Central US
```

Updates the specified peering's tags


#### New-AzPeeringAsn

#### SYNOPSIS
Creates a new peer ASN or updates an existing peer ASN with the specified name under the given subscription.

#### SYNTAX

```powershell
New-AzPeeringAsn -Name <String> [-SubscriptionId <String>] [-PeerAsn <Int32>]
 [-PeerContactDetail <IContactDetail[]>] [-PeerName <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a new peering asn
```powershell
$contactDetail = New-AzPeeringContactDetailObject -Email "abc@xyz.com" -Phone 1234567890 -Role "Noc"
$PeerContactList = ,$contactDetail
New-AzPeeringAsn -Name PsTestAsn -PeerAsn 65001 -PeerContactDetail $PeerContactList -PeerName DemoPeering
```

```output
Name      PeerName    PropertiesPeerAsn ValidationState PeerContactDetail
----      --------    ----------------- --------------- -----------------
PsTestAsn DemoPeering 65001             Pending         {{…
```

Create a new peering asn with the specified properties


#### Get-AzPeeringAsn

#### SYNOPSIS
Gets the peer ASN with the specified name under the given subscription.

#### SYNTAX

+ List (Default)
```powershell
Get-AzPeeringAsn [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzPeeringAsn -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzPeeringAsn -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List PeerAsns
```powershell
Get-AzPeeringAsn
```

```output
Name            PeerName PropertiesPeerAsn ValidationState PeerContactDetail
----            -------- ----------------- --------------- -----------------
ContosoEdgeTest Contoso  65000             Approved        {{…}}

```

List all the peer asns under subscription

+ Example 2: Get Specific PeerAsn
```powershell
Get-AzPeeringAsn -Name ContosoEdgeTest
```

```output
Name            PeerName PropertiesPeerAsn ValidationState PeerContactDetail
----            -------- ----------------- --------------- -----------------
ContosoEdgeTest Contoso  65000             Approved        {{…}}
```

Get peer asn by name


#### Remove-AzPeeringAsn

#### SYNOPSIS
Deletes an existing peer ASN with the specified name under the given subscription.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzPeeringAsn -Name <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzPeeringAsn -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove peer asn
```powershell
 Remove-AzPeeringAsn -Name PsTestAsn
 ```

Removes peer asn with the name specified


#### Get-AzPeeringCdnPrefix

#### SYNOPSIS
Lists all of the advertised prefixes for the specified peering location

#### SYNTAX

```powershell
Get-AzPeeringCdnPrefix -PeeringLocation <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get Cdn prefixes
```powershell
Get-AzPeeringCdnPrefix -PeeringLocation Seattle
```

```output
Prefix          AzureRegion AzureService IsPrimaryRegion BgpCommunity
------          ----------- ------------ --------------- ------------
20.157.110.0/24 West US 2   AzureCompute True            8069:51026
20.157.118.0/24 West US 2   AzureCompute True            8069:51026
20.157.125.0/24 West US 2   AzureCompute True            8069:51026
20.157.180.0/24 West US 2   AzureStorage True            8069:52026
20.157.25.0/24  West US 2   AzureCompute True            8069:51026
20.157.50.0/23  West US 2   AzureStorage True            8069:52026
20.47.120.0/23  West US 2   AzureCompute True            8069:51026
20.47.62.0/23   West US 2   AzureStorage True            8069:52026
```

Get all cdn prefixes for subscription


#### New-AzPeeringCheckServiceProviderAvailabilityInputObject

#### SYNOPSIS
Create an in-memory object for CheckServiceProviderAvailabilityInput.

#### SYNTAX

```powershell
New-AzPeeringCheckServiceProviderAvailabilityInputObject [-PeeringServiceLocation <String>]
 [-PeeringServiceProvider <String>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a check service provider availability object
```powershell
New-AzPeeringCheckServiceProviderAvailabilityInputObject -PeeringServiceLocation Osaka -PeeringServiceProvider IIJ
```

```output
PeeringServiceLocation PeeringServiceProvider
---------------------- ----------------------
Osaka                  IIJ
```

Creates a CheckServiceProviderAvailabilityInputObject with the specified location and provider and stores it in memory


#### New-AzPeeringConnectionMonitorTest

#### SYNOPSIS
Creates or updates a connection monitor test with the specified name under the given subscription, resource group and peering service.

#### SYNTAX

```powershell
New-AzPeeringConnectionMonitorTest -Name <String> -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Destination <String>] [-DestinationPort <Int32>] [-SourceAgent <String>]
 [-TestFrequencyInSec <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a new connection monitor test
```powershell
New-AzPeeringConnectionMonitorTest -Name TestName -PeeringServiceName DRTest -ResourceGroupName DemoRG
```

```output
SourceAgent Destination DestinationPort TestFrequency Sucessful ProvisioningState
----------- ----------- --------------- ------------- --------- -----------------
Agent 1     1.1.1.1     80              30            True      Succeeded
```

Creates a connection monitor test for the peering service


#### Get-AzPeeringConnectionMonitorTest

#### SYNOPSIS
Gets an existing connection monitor test with the specified name under the given subscription, resource group and peering service.

#### SYNTAX

+ List (Default)
```powershell
Get-AzPeeringConnectionMonitorTest -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzPeeringConnectionMonitorTest -Name <String> -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzPeeringConnectionMonitorTest -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Lists all connection monitor tests
```powershell
 Get-AzPeeringConnectionMonitorTest -ResourceGroupName DemoRG -PeeringServiceName DRTest
```

```output
SourceAgent Destination DestinationPort TestFrequency Sucessful ProvisioningState
----------- ----------- --------------- ------------- --------- -----------------
Agent 1     1.1.1.1     80              30            True      Succeeded
```

Lists all connection monitor test objects

+ Example 2: Get single connection monitor test
```powershell
 Get-AzPeeringConnectionMonitorTest -ResourceGroupName DemoRG -PeeringServiceName DRTest -Name TestName
```

```output
Connection Monitor Test Object
```

Gets a single connection monitor test


#### Remove-AzPeeringConnectionMonitorTest

#### SYNOPSIS
Deletes an existing connection monitor test with the specified name under the given subscription, resource group and peering service.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzPeeringConnectionMonitorTest -Name <String> -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzPeeringConnectionMonitorTest -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove connection monitor test
```powershell
Remove-AzPeeringConnectionMonitorTest -Name TestName -PeeringServiceName TestDRInterCloudZurich -ResourceGroupName DemoRG
```

Removes the given connection monitor test from the peering service


#### New-AzPeeringContactDetailObject

#### SYNOPSIS
Create an in-memory object for ContactDetail.

#### SYNTAX

```powershell
New-AzPeeringContactDetailObject [-Email <String>] [-Phone <String>] [-Role <Role>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a Contact Detail object
```powershell
New-AzPeeringContactDetailObject -Email "abc@xyz.com" -Phone 1234567890 -Role "Noc"
```

```output
Email       Phone      Role
-----       -----      ----
abc@xyz.com 1234567890 Noc
```

Creates a ContactDetail object with the specified email phone and role stores it in memory


#### New-AzPeeringDirectConnectionObject

#### SYNOPSIS
Create an in-memory object for DirectConnection.

#### SYNTAX

```powershell
New-AzPeeringDirectConnectionObject [-BandwidthInMbps <Int32>] [-BgpSessionMaxPrefixesAdvertisedV4 <Int32>]
 [-BgpSessionMaxPrefixesAdvertisedV6 <Int32>] [-BgpSessionMd5AuthenticationKey <String>]
 [-BgpSessionMicrosoftSessionIPv4Address <String>] [-BgpSessionMicrosoftSessionIPv6Address <String>]
 [-BgpSessionPeerSessionIPv4Address <String>] [-BgpSessionPeerSessionIPv6Address <String>]
 [-BgpSessionPrefixV4 <String>] [-BgpSessionPrefixV6 <String>] [-ConnectionIdentifier <String>]
 [-PeeringDbFacilityId <Int32>] [-SessionAddressProvider <SessionAddressProvider>]
 [-UseForPeeringService <Boolean>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a direct connection object
```powershell
New-AzPeeringDirectConnectionObject -BandwidthInMbps 10000 -BgpSessionMaxPrefixesAdvertisedV4 20000 -BgpSessionMaxPrefixesAdvertisedV6 0 -BgpSessionMd5AuthenticationKey $md5Key -BgpSessionMicrosoftSessionIPv4Address 1.1.1.1 -BgpSessionPeerSessionIPv4Address 1.1.1.0 -BgpSessionPrefixV4 1.1.1.1/31 -PeeringDbFacilityId 82 -SessionAddressProvider Peer -ConnectionIdentifier c111111111111
```

```output
BandwidthInMbps ConnectionIdentifier ConnectionState ErrorMessage MicrosoftTrackingId PeeringDbFacilityId ProvisionedBandwidthInMbps ... [more fields]
--------------- -------------------- --------------- ------------ ------------------- ------------------- -------------------------- ... -------------
10000           c111111111111        PendingApproval                                  82

```

Creates an in-memory direct connection object


#### New-AzPeeringExchangeConnectionObject

#### SYNOPSIS
Create an in-memory object for ExchangeConnection.

#### SYNTAX

```powershell
New-AzPeeringExchangeConnectionObject [-BgpSessionMaxPrefixesAdvertisedV4 <Int32>]
 [-BgpSessionMaxPrefixesAdvertisedV6 <Int32>] [-BgpSessionMd5AuthenticationKey <String>]
 [-BgpSessionMicrosoftSessionIPv4Address <String>] [-BgpSessionMicrosoftSessionIPv6Address <String>]
 [-BgpSessionPeerSessionIPv4Address <String>] [-BgpSessionPeerSessionIPv6Address <String>]
 [-BgpSessionPrefixV4 <String>] [-BgpSessionPrefixV6 <String>] [-ConnectionIdentifier <String>]
 [-PeeringDbFacilityId <Int32>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create an exchange connection object
```powershell
New-AzPeeringExchangeConnectionObject -BgpSessionMaxPrefixesAdvertisedV4 20000 -BgpSessionMaxPrefixesAdvertisedV6 0 -BgpSessionMd5AuthenticationKey $md5Key -BgpSessionMicrosoftSessionIPv4Address 1.1.1.1 -BgpSessionPeerSessionIPv4Address 1.1.1.0 -BgpSessionPrefixV4 1.1.1.1/31 -PeeringDbFacilityId 82 -ConnectionIdentifier c111111111111
```

```output
ConnectionIdentifier ConnectionState ErrorMessage PeeringDbFacilityId ... [more fields]
-------------------- --------------- ------------ ------------------- ... -------------
c111111111111                                     82
```

Create a exchange connection object in memory


#### Start-AzPeeringInvokeLookingGlass

#### SYNOPSIS
Run looking glass functionality

#### SYNTAX

+ Invoke (Default)
```powershell
Start-AzPeeringInvokeLookingGlass -Command <LookingGlassCommand> -DestinationIP <String>
 -SourceLocation <String> -SourceType <LookingGlassSourceType> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ InvokeViaIdentity
```powershell
Start-AzPeeringInvokeLookingGlass -InputObject <IPeeringIdentity> -Command <LookingGlassCommand>
 -DestinationIP <String> -SourceLocation <String> -SourceType <LookingGlassSourceType>
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Invoke looking glass command
```powershell
 Start-AzPeeringInvokeLookingGlass -Command Ping -DestinationIp 1.1.1.1 -SourceLocation Seattle -SourceType EdgeSite
 ```

```output
Command Output
------- ------
Ping    PING 1.1.1.1 (1.1.1.1): 56 data bytes…
```

Invoke the given looking glass command


#### Get-AzPeeringLegacy

#### SYNOPSIS
Lists all of the legacy peerings under the given subscription matching the specified kind and location.

#### SYNTAX

```powershell
Get-AzPeeringLegacy -Kind <LegacyPeeringsKind> -PeeringLocation <String> [-SubscriptionId <String[]>]
 [-Asn <Int32>] [-DirectPeeringType <DirectPeeringType>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Gets legacy peering object
```powershell
Get-AzPeeringLegacy -Kind Direct -PeeringLocation Seattle
```

```output
Name           SkuName             Kind     PeeringLocation ProvisioningState Location
----           -------             ----     --------------- ----------------- --------
DemoComp1      Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
DemoPeering    Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
TestEdgeZone   Premium_Direct_Free Direct   Atlanta         Succeeded         East US 2
```

Gets legacy peering object


#### Get-AzPeeringLocation

#### SYNOPSIS
Lists all of the available peering locations for the specified kind of peering.

#### SYNTAX

```powershell
Get-AzPeeringLocation -Kind <PeeringLocationsKind> [-SubscriptionId <String[]>]
 [-DirectPeeringType <PeeringLocationsDirectPeeringType>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get all direct peering locations
```powershell
Get-AzPeeringLocation -Kind Direct
```

```output
Get-AzPeeringLocation -Kind Direct

Name             Country AzureRegion         Kind
----             ------- -----------         ----
Amsterdam        NL      West Europe         Direct
Ashburn          US      East US             Direct
Athens           GR      France Central      Direct
Atlanta          US      East US 2           Direct
Auckland         NZ      Australia East      Direct
Barcelona        ES      France Central      Direct
Berlin           DE      West Europe         Direct
...
```

Gets all peering locations for direct peers


#### Get-AzPeeringReceivedRoute

#### SYNOPSIS
Lists the prefixes received over the specified peering under the given subscription and resource group.

#### SYNTAX

```powershell
Get-AzPeeringReceivedRoute -PeeringName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-AsPath <String>] [-OriginAsValidationState <String>] [-Prefix <String>] [-RpkiValidationState <String>]
 [-SkipToken <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Get all received routes for a specific peering
```powershell
Get-AzPeeringReceivedRoute -PeeringName DemoPeering -ResourceGroupName DemoRG
```

```output
AsPath               NextHop       OriginAsValidationState Prefix         ReceivedTimestamp            RpkiValidationState TrustAnchor
------               -------       ----------------------- ------         -----------------            ------------------- -----------
7018 13335           12.90.152.69  Valid                   1.0.0.0/24     2022-12-05T11:51:51.2062620Z Valid               None
7018 13335           12.90.152.69  Valid                   1.1.1.0/24     2022-12-05T11:51:51.2062620Z Valid               None
7018 4837 4808       12.90.152.69  Valid                   1.119.192.0/21 2021-12-07T05:21:11.7043790Z Unknown             None
7018 4837 4808       12.90.152.69  Valid                   1.119.200.0/22 2021-12-07T05:21:11.7043790Z Unknown             None
7018 4837 4808 59034 12.90.152.69  Valid                   1.119.204.0/24 2021-12-07T05:21:13.7045170Z Unknown             None
7018 9680 9680 3462  12.90.152.69  Valid                   1.160.0.0/12   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.160.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.161.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.162.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.163.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 15169 396982    12.90.152.69  Unknown                 1.179.112.0/20 2021-12-07T05:21:16.7056160Z Unknown             None
7018 9680 9680 3462  12.90.152.69  Valid                   1.164.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.165.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.166.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462  12.90.152.69  Valid                   1.167.0.0/16   2022-11-29T07:46:45.2062680Z Valid               None
...
```

Gets all the received routes for a specific peering

+ Example 2: Filter received routes based on optional parameters
```powershell
Get-AzPeeringReceivedRoute -PeeringName DemoPeering -ResourceGroupName DemoRG -AsPath "7018 9680 9680 3462"
```

```output
AsPath                          NextHop       OriginAsValidationState Prefix           ReceivedTimestamp            RpkiValidationState TrustAnchor
------                          -------       ----------------------- ------           -----------------            ------------------- -----------
7018 9680 9680 3462             12.90.152.69  Valid                   1.160.0.0/12     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.160.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.161.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.162.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.163.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
7018 9680 9680 3462             12.90.152.69  Valid                   1.164.0.0/16     2022-11-29T07:46:45.2062680Z Valid               None
...
```

Gets all received routes of a peering with a specific AsPath


#### New-AzPeeringRegisteredAsn

#### SYNOPSIS
Creates a new registered ASN with the specified name under the given subscription, resource group and peering.

#### SYNTAX

```powershell
New-AzPeeringRegisteredAsn -Name <String> -PeeringName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Asn <Int32>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create registered asn
```powershell
New-AzPeeringRegisteredAsn -Name TestAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo -Asn 65001
```

```output
Name    Asn   PeeringServicePrefixKey              ProvisioningState
----    ---   -----------------------              -----------------
TestAsn 65001 45a8db73-4b7c-4800-bb0f-d304a747d6f1 Succeeded
```

Create a new registered asn for a peering


#### Get-AzPeeringRegisteredAsn

#### SYNOPSIS
Gets an existing registered ASN with the specified name under the given subscription, resource group and peering.

#### SYNTAX

+ List (Default)
```powershell
Get-AzPeeringRegisteredAsn -PeeringName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzPeeringRegisteredAsn -Name <String> -PeeringName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzPeeringRegisteredAsn -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all registered asns for peering
```powershell
Get-AzPeeringRegisteredAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo
```

```output
Name          Asn   PeeringServicePrefixKey              ProvisioningState
----          ---   -----------------------              -----------------
fgfg          6500  767c9f30-7388-49ef-ba8e-e2d16d1c08e4 Succeeded
homedepottest 65000 32259ee0-ea01-495e-8279-06c24ef7aae0 Succeeded
JonOrmondTest 62540 e3f552c5-909e-434b-8fab-93e524a1aeed Succeeded
```

Lists all registered asn's for a peering

+ Example 2: Get specific registered asn for peering
```powershell
Get-AzPeeringRegisteredAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo -Name fgfg
```

```output
Name Asn  PeeringServicePrefixKey              ProvisioningState
---- ---  -----------------------              -----------------
fgfg 6500 767c9f30-7388-49ef-ba8e-e2d16d1c08e4 Succeeded
```

Gets a specific registered asn for a peering by name


#### Remove-AzPeeringRegisteredAsn

#### SYNOPSIS
Deletes an existing registered ASN with the specified name under the given subscription, resource group and peering.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzPeeringRegisteredAsn -Name <String> -PeeringName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzPeeringRegisteredAsn -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove a registered asn from the peering
```powershell
Remove-AzPeeringRegisteredAsn -Name TestAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo
```

Remove a registered asn from the peering object


#### New-AzPeeringRegisteredPrefix

#### SYNOPSIS
Creates a new registered prefix with the specified name under the given subscription, resource group and peering.

#### SYNTAX

```powershell
New-AzPeeringRegisteredPrefix -Name <String> -PeeringName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Prefix <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a new registered prefix
```powershell
New-AzPeeringRegisteredPrefix -Name accessibilityTesting6 -PeeringName DemoPeering -ResourceGroupName DemoRG -Prefix 240.0.5.0/24
```

```output
Name                  Prefix       PeeringServicePrefixKey              PrefixValidationState ProvisioningState
----                  ------       -----------------------              --------------------- -----------------
accessibilityTesting6 240.0.5.0/24 f5947454-80e3-4ce5-bcb3-2501537b6952 Pending                Updating
```

Create a new registered prefix object


#### Get-AzPeeringRegisteredPrefix

#### SYNOPSIS
Gets an existing registered prefix with the specified name under the given subscription, resource group and peering.

#### SYNTAX

+ List (Default)
```powershell
Get-AzPeeringRegisteredPrefix -PeeringName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzPeeringRegisteredPrefix -Name <String> -PeeringName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzPeeringRegisteredPrefix -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all registered prefixes for a peering
```powershell
Get-AzPeeringRegisteredPrefix -PeeringName DemoPeering -ResourceGroupName DemoRG
```

```output
Name                  Prefix       PeeringServicePrefixKey              PrefixValidationState ProvisioningState
----                  ------       -----------------------              --------------------- -----------------
accessibilityTesting1 240.0.0.0/24 f5947454-80e3-4ce5-bcb3-2501537b6952 Failed                Succeeded
accessibilityTesting2 240.0.1.0/24 249aa0dd-6177-4105-94fe-dfefcbf5ab48 Failed                Succeeded
accessibilityTesting3 240.0.2.0/24 4fb59e9e-d4eb-4847-b2ad-9939edda750b Failed                Succeeded
accessibilityTesting4 240.0.4.0/24 b725f16c-759b-4144-93ed-ed4eb89cb8f7 Failed                Succeeded
accessibilityTesting5 240.0.3.0/24 bb1262ca-0b31-45f3-a301-105b0615b21c Failed                Succeeded
```

List all registered prefixes

+ Example 2: Get specific registered prefix for a peering
```powershell
Get-AzPeeringRegisteredPrefix -PeeringName DemoPeering -ResourceGroupName DemoRG -Name accessibilityTesting1
```

```output
Name                  Prefix       PeeringServicePrefixKey              PrefixValidationState ProvisioningState
----                  ------       -----------------------              --------------------- -----------------
accessibilityTesting1 240.0.0.0/24 f5947454-80e3-4ce5-bcb3-2501537b6952 Failed                Succeeded
```

Get a specific registered prefix by name


#### Remove-AzPeeringRegisteredPrefix

#### SYNOPSIS
Deletes an existing registered prefix with the specified name under the given subscription, resource group and peering.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzPeeringRegisteredPrefix -Name <String> -PeeringName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzPeeringRegisteredPrefix -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove registered prefix
```powershell
Remove-AzPeeringRegisteredPrefix -Name accessibilityTesting6 -PeeringName DemoPeering -ResourceGroupName DemoRG
```

Removes the specified registered prefix from peering


#### Test-AzPeeringRegisteredPrefix

#### SYNOPSIS
Validates an existing registered prefix with the specified name under the given subscription, resource group and peering.

#### SYNTAX

+ Validate (Default)
```powershell
Test-AzPeeringRegisteredPrefix -Name <String> -PeeringName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ ValidateViaIdentity
```powershell
Test-AzPeeringRegisteredPrefix -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Test registered prefix
```powershell
Test-AzPeeringRegisteredPrefix -Name accessibilityTesting2 -PeeringName DemoPeering -ResourceGroupName DemoRG
```

```output
Name                  Prefix       PeeringServicePrefixKey              PrefixValidationState ProvisioningState
----                  ------       -----------------------              --------------------- -----------------
accessibilityTesting2 240.0.1.0/24 249aa0dd-6177-4105-94fe-dfefcbf5ab48 Pending               Succeeded
```

Tests the validity of the given registered prefix (shown in prefix validation state)


#### Get-AzPeeringRpUnbilledPrefix

#### SYNOPSIS
Lists all of the RP unbilled prefixes for the specified peering

#### SYNTAX

```powershell
Get-AzPeeringRpUnbilledPrefix -PeeringName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-Consolidate] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all unbilled prefixes for a peering
```powershell
Get-AzPeeringRpUnbilledPrefix -PeeringName DemoPeering -ResourceGroupName DemoRG
```

```output
Prefix      AzureRegion PeerASN
------      ----------- -------
2.16.0.0/13 West US 2   65010
23.0.0.0/12 West US 2   65010
...
```

Lists all the unbilled prefixes for a peering


#### New-AzPeeringService

#### SYNOPSIS
Creates a new peering service or updates an existing peering with the specified name under the given subscription and resource group.

#### SYNTAX

```powershell
New-AzPeeringService -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-PeeringServiceLocation <String>] [-PeeringServiceProvider <String>]
 [-ProviderBackupPeeringLocation <String>] [-ProviderPrimaryPeeringLocation <String>] [-Sku <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create a new peering service
```powershell
New-AzPeeringService -Name TestPeeringService -ResourceGroupName DemoRG -Location "East US 2" -PeeringServiceLocation Georgia -PeeringServiceProvider MicrosoftEdge -ProviderPrimaryPeeringLocation Atlanta
```

```output
Name               ResourceGroupName PeeringServiceLocation Provider      ProvisioningState   Location
----               ----------------- ---------------------- --------      -----------------   --------
TestPeeringService DemoRG            Georgia                MicrosoftEdge ProvisioningStarted East US 2
```

Create a new peering service in the resource group


#### Get-AzPeeringService

#### SYNOPSIS
Gets an existing peering service with the specified name under the given subscription and resource group.

#### SYNTAX

+ List1 (Default)
```powershell
Get-AzPeeringService [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzPeeringService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzPeeringService -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ List
```powershell
Get-AzPeeringService -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all peering services under subscription
```powershell
Get-AzPeeringService
```

```output
Name                               ResourceGroupName PeeringServiceLocation Provider      ProvisioningState Location
----                               ----------------- ---------------------- --------      ----------------- --------
TestPrefixForAtlanta               DemoRG            Georgia                MicrosoftEdge Succeeded         East US 2
TestExtension                      DemoRG            Virginia               MicrosoftEdge Succeeded         East US
TestExtension2                     DemoRG            Virginia               MicrosoftEdge Succeeded         East US
DemoPeeringServiceInterCloudLondon DemoRG            London                 InterCloud    Succeeded         UK South
DRTestInterCloud                   DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
Gaurav Thareja                     DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
TestDRInterCloudZurich             DemoRG            Zurich                 InterCloud    Succeeded         France Central
DRTest                             DemoRG            Ile-de-France          InterCloud    Succeeded         France Central
```

Lists all peering services under default subscription

+ Example 2: List all peering services under a specific resource group
```powershell
Get-AzPeeringService -ResourceGroupName DemoRG
```

```output
Name                               ResourceGroupName PeeringServiceLocation Provider      ProvisioningState Location
----                               ----------------- ---------------------- --------      ----------------- --------
TestPrefixForAtlanta               DemoRG            Georgia                MicrosoftEdge Succeeded         East US 2
TestExtension                      DemoRG            Virginia               MicrosoftEdge Succeeded         East US
TestExtension2                     DemoRG            Virginia               MicrosoftEdge Succeeded         East US
DemoPeeringServiceInterCloudLondon DemoRG            London                 InterCloud    Succeeded         UK South
DRTestInterCloud                   DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
Gaurav Thareja                     DemoRG            Ile-de-France          InterCloud    Succeeded         UK South
TestDRInterCloudZurich             DemoRG            Zurich                 InterCloud    Succeeded         France Central
DRTest                             DemoRG            Ile-de-France          InterCloud    Succeeded         France Central
```

Lists all the peering services under a resource group

+ Example 3: List all peering services under a specific resource group
```powershell
Get-AzPeeringService -ResourceGroupName DemoRG -Name TestExtension
```

```output
Name                               ResourceGroupName PeeringServiceLocation Provider      ProvisioningState Location
----                               ----------------- ---------------------- --------      ----------------- --------
TestExtension                      DemoRG            Virginia               MicrosoftEdge Succeeded         East US
```

Gets a peering service with matching name and resource group


#### Remove-AzPeeringService

#### SYNOPSIS
Deletes an existing peering service with the specified name under the given subscription and resource group.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzPeeringService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzPeeringService -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [-PassThru] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove peering service
```powershell
Remove-AzPeeringService -Name TestPeeringService -ResourceGroupName DemoRG
```

Removes a peering service from the given resource group


#### Update-AzPeeringService

#### SYNOPSIS
Updates tags for a peering service with the specified name under the given subscription and resource group.

#### SYNTAX

+ UpdateExpanded (Default)
```powershell
Update-AzPeeringService -Name <String> -ResourceGroupName <String> [-SubscriptionId <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ UpdateViaIdentityExpanded
```powershell
Update-AzPeeringService -InputObject <IPeeringIdentity> [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Update peering service tags
```powershell
$tags=@{hello='world'}
Update-AzPeeringService -Name DRTestInterCloud -ResourceGroupName DemoRG -Tag $tags
```

```output
Name             ResourceGroupName PeeringServiceLocation Provider   ProvisioningState Location
----             ----------------- ---------------------- --------   ----------------- --------
DRTestInterCloud DemoRG            Ile-de-France          InterCloud Succeeded         UK South
```

Updates the peering service tags


#### Initialize-AzPeeringServiceConnectionMonitor

#### SYNOPSIS
Initialize Peering Service for Connection Monitor functionality

#### SYNTAX

+ Initialize (Default)
```powershell
Initialize-AzPeeringServiceConnectionMonitor [-SubscriptionId <String>] [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ InitializeViaIdentity
```powershell
Initialize-AzPeeringServiceConnectionMonitor -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>]
 [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Initialize connection monitor functionality
```powershell
Initialize-AzPeeringServiceConnectionMonitor 
```

Initialize connection monitor functionality


#### Get-AzPeeringServiceCountry

#### SYNOPSIS
Lists all of the available countries for peering service.

#### SYNTAX

```powershell
Get-AzPeeringServiceCountry [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Lists all the peering service countries
```powershell
Get-AzPeeringServiceCountry
```

```output
Name
----
Australia
Belgium
Brazil
Canada
Denmark
Finland
France
Germany
Hong Kong
Japan
Kenya
Korea, South
Malaysia
Netherlands
New Zealand
...
```

Lists the countries available for peering service.


#### Get-AzPeeringServiceLocation

#### SYNOPSIS
Lists all of the available locations for peering service.

#### SYNTAX

```powershell
Get-AzPeeringServiceLocation [-SubscriptionId <String[]>] [-Country <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all peering service locations
```powershell
Get-AzPeeringServiceLocation
```

```output
Name                            State                           Country        AzureRegion
----                            -----                           -------        -----------
Obwalden                        Obwalden                        Switzerland    France Central
Sankt Gallen                    Sankt Gallen                    Switzerland    France Central
Schaffhausen                    Schaffhausen                    Switzerland    France Central
Schwyz                          Schwyz                          Switzerland    France Central
Solothurn                       Solothurn                       Switzerland    France Central
Thurgau                         Thurgau                         Switzerland    France Central
Ticino                          Ticino                          Switzerland    France Central
Uri                             Uri                             Switzerland    France Central
Valais                          Valais                          Switzerland    France Central
Vaud                            Vaud                            Switzerland    France Central
Zug                             Zug                             Switzerland    France Central
Zurich                          Zurich                          Switzerland    France Central
Aberdeen City                   Aberdeen City                   United Kingdom UK West
Angus                           Angus                           United Kingdom UK West
Antrim and Newtownabbey         Antrim and Newtownabbey         United Kingdom North Europe
Ards and North Down             Ards and North Down             United Kingdom North Europe
Argyll and Bute                 Argyll and Bute                 United Kingdom North Europe
Armagh, Banbridge and Craigavon Armagh, Banbridge and Craigavon United Kingdom North Europe
Barking and Dagenham            Barking and Dagenham            United Kingdom UK South
...
```

Retrieves all peering service locations

+ Example 2: List all peering service
```powershell
Get-AzPeeringServiceLocation -Country Japan
```

```output
Name      State     Country AzureRegion
----      -----     ------- -----------
Aichi     Aichi     Japan   Japan West
Akita     Akita     Japan   Japan East
Aomori    Aomori    Japan   Japan East
Chiba     Chiba     Japan   Japan East
Ehime     Ehime     Japan   Japan West
Fukui     Fukui     Japan   Japan West
Fukuoka   Fukuoka   Japan   Japan West
Fukushima Fukushima Japan   Japan East
Gifu      Gifu      Japan   Japan West
Gunma     Gunma     Japan   Japan East
Hiroshima Hiroshima Japan   Japan West
Hyogo     Hyogo     Japan   Japan West
Ibaraki   Ibaraki   Japan   Japan East
Ishikawa  Ishikawa  Japan   Japan West
...
```

Retrieves all peering service locations for a specific country


#### New-AzPeeringServicePrefix

#### SYNOPSIS
Creates a new prefix with the specified name under the given subscription, resource group and peering service.

#### SYNTAX

```powershell
New-AzPeeringServicePrefix -Name <String> -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-PeeringServicePrefixKey <String>] [-Prefix <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Create Peering service prefix
```powershell
New-AzPeeringServicePrefix -Name TestPrefix -PeeringServiceName TestDRInterCloudZurich -ResourceGroupName DemoRG -PeeringServicePrefixKey 6a7f0d42-e49c-4eea-a930-280610671c3f -Prefix 91.194.255.0/24
```

```output
Name        Prefix          Key                                  PrefixValidationState LearnedType ProvisioningState
----        ------          ---                                  --------------------- ----------- -----------------
TestPrefix  91.194.255.0/24 6a7f0d42-e49c-4eea-a930-280610671c3f Failed                None        Succeeded
```

Create a peering service prefix


#### Get-AzPeeringServicePrefix

#### SYNOPSIS
Gets an existing prefix with the specified name under the given subscription, resource group and peering service.

#### SYNTAX

+ List (Default)
```powershell
Get-AzPeeringServicePrefix -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ Get
```powershell
Get-AzPeeringServicePrefix -Name <String> -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-Expand <String>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

+ GetViaIdentity
```powershell
Get-AzPeeringServicePrefix -InputObject <IPeeringIdentity> [-Expand <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all peering service prefixes
```powershell
Get-AzPeeringServicePrefix -PeeringServiceName TestDRInterCloudZurich -ResourceGroupName DemoRG
```

```output
Name        Prefix          Key                                  PrefixValidationState LearnedType ProvisioningState
----        ------          ---                                  --------------------- ----------- -----------------
TestPrefix  91.194.255.0/24 6a7f0d42-e49c-4eea-a930-280610671c3f Failed                None        Succeeded
TestPrefix2 240.0.0.0/24                                         Failed                None        Succeeded
```

Lists all peering service prefixes for the peering service

+ Example 2: Get specific peering service prefix
```powershell
Get-AzPeeringServicePrefix -PeeringServiceName TestDRInterCloudZurich -ResourceGroupName DemoRG -Name TestPrefix
```

```output
Name        Prefix          Key                                  PrefixValidationState LearnedType ProvisioningState
----        ------          ---                                  --------------------- ----------- -----------------
TestPrefix  91.194.255.0/24 6a7f0d42-e49c-4eea-a930-280610671c3f Failed                None        Succeeded
```

Gets a specific peering service prefix


#### Remove-AzPeeringServicePrefix

#### SYNOPSIS
Deletes an existing prefix with the specified name under the given subscription, resource group and peering service.

#### SYNTAX

+ Delete (Default)
```powershell
Remove-AzPeeringServicePrefix -Name <String> -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-PassThru] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ DeleteViaIdentity
```powershell
Remove-AzPeeringServicePrefix -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Remove peering service prefix
```powershell
Remove-AzPeeringServicePrefix -Name TestPrefix -PeeringServiceName TestDRInterCloudZurich -ResourceGroup DemoRG
```

Removes peering service prefix from peering


#### Get-AzPeeringServiceProvider

#### SYNOPSIS
Lists all of the available peering service locations for the specified kind of peering.

#### SYNTAX

```powershell
Get-AzPeeringServiceProvider [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: List all peering service providers
```powershell
Get-AzPeeringServiceProvider
```

```output
Name                                        PeeringLocation                            ServiceProviderName
----                                        ---------------                            -------------------
IIJ                                         {Osaka, Tokyo}                             IIJ
NTTCom                                      {Osaka, Tokyo}                             NTTCom
Kordia Limited                              {Auckland, Sydney}                         Kordia Limited
Liquid Telecommunications Ltd               {Cape Town, Johannesburg, Nairobi}         Liquid Telecommunications Ltd
InterCloud                                  {london, Paris, Zurich, Geneva}            InterCloud
Computer Concepts Limited                   {Auckland}                                 Computer Concepts Limited
Singnet                                     {singapore}                                Singnet
NTT Communications - Flexible InterConnect  {Osaka, Tokyo}                             NTT Communications - Flexible InterConnect
NAPAfrica                                   {Johannesburg, Cape Town}                  NAPAfrica
Vocusgroup NZ                               {Sydney, Auckland}                         Vocusgroup NZ
CMC NETWORKS                                {Johannesburg, Nairobi, cape Town}         CMC NETWORKS
MainOne                                     {Lisbon, Lagos}                            MainOne
Swisscom Switzerland Ltd                    {Geneva, Zurich}                           Swisscom Switzerland Ltd
DE-CIX                                      {Frankfurt, Marseille, Newark, Madrid…}    DE-CIX
Lumen Technologies                          {denver, los Angeles}                      Lumen Technologies
Colt Technology Services                    {Amsterdam, Barcelona, Berlin, Frankfurt…} Colt Technology Services
```

Lists all peering service providers


#### Test-AzPeeringServiceProviderAvailability

#### SYNOPSIS
Checks if the peering service provider is present within 1000 miles of customer's location

#### SYNTAX

+ CheckExpanded (Default)
```powershell
Test-AzPeeringServiceProviderAvailability [-SubscriptionId <String>] [-PeeringServiceLocation <String>]
 [-PeeringServiceProvider <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ Check
```powershell
Test-AzPeeringServiceProviderAvailability
 -CheckServiceProviderAvailabilityInput <ICheckServiceProviderAvailabilityInput> [-SubscriptionId <String>]
 [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CheckViaIdentity
```powershell
Test-AzPeeringServiceProviderAvailability -InputObject <IPeeringIdentity>
 -CheckServiceProviderAvailabilityInput <ICheckServiceProviderAvailabilityInput> [-DefaultProfile <PSObject>]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

+ CheckViaIdentityExpanded
```powershell
Test-AzPeeringServiceProviderAvailability -InputObject <IPeeringIdentity> [-PeeringServiceLocation <String>]
 [-PeeringServiceProvider <String>] [-DefaultProfile <PSObject>] [-Confirm] [-WhatIf] [<CommonParameters>]
```

#### EXAMPLES

+ Example 1: Check if provider is available at a location
```powershell
$providerAvailability = New-AzPeeringCheckServiceProviderAvailabilityInputObject -PeeringServiceLocation Osaka -PeeringServiceProvider IIJ
Test-AzPeeringServiceProviderAvailability -CheckServiceProviderAvailabilityInput $providerAvailability
```

```output
"Available"
```

Check whether the given provider is available at the given location


