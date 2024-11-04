---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
ms.assetid: 81D55C43-C9A3-4DA7-A469-A3A7550FE9A4
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualnetwork
schema: 2.0.0
---

# New-AzVirtualNetwork

## SYNOPSIS
Creates a virtual network.

## SYNTAX

```
New-AzVirtualNetwork -Name <String> -ResourceGroupName <String> -Location <String> -AddressPrefix <String[]>
 [-IpamPoolPrefixAllocation <PSIpamPoolPrefixAllocation[]>] [-DnsServer <String[]>] [-FlowTimeout <Int32>] [-Subnet <PSSubnet[]>] [-BgpCommunity <String>]
 [-EnableEncryption <String>] [-EncryptionEnforcementPolicy <String>] [-Tag <Hashtable>]
 [-EnableDdosProtection] [-DdosProtectionPlanId <String>] [-IpAllocation <PSIpAllocation[]>]
 [-EdgeZone <String>] [-PrivateEndpointVNetPoliciesValue <String>] [-Force] [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzVirtualNetwork** cmdlet creates an Azure virtual network.

## EXAMPLES

### Example 1: Create a virtual network with two subnets
```powershell
New-AzResourceGroup -Name TestResourceGroup -Location centralus
$frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.0.1.0/24"
$backendSubnet  = New-AzVirtualNetworkSubnetConfig -Name backendSubnet  -AddressPrefix "10.0.2.0/24"
New-AzVirtualNetwork -Name MyVirtualNetwork -ResourceGroupName TestResourceGroup -Location centralus -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet
```

This example creates a virtual network with two subnets. First, a new resource group is created in
the centralus region. Then, the example creates in-memory representations of two subnets. The
New-AzVirtualNetworkSubnetConfig cmdlet will not create any subnet on the server side. There
is one subnet called frontendSubnet and one subnet called backendSubnet. The
New-AzVirtualNetwork cmdlet then creates a virtual network using the CIDR 10.0.0.0/16 as the
address prefix and two subnets.

### Example 2: Create a virtual network with DNS settings
```powershell
New-AzResourceGroup -Name TestResourceGroup -Location centralus
$frontendSubnet = New-AzVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.0.1.0/24"
$backendSubnet  = New-AzVirtualNetworkSubnetConfig -Name backendSubnet  -AddressPrefix "10.0.2.0/24"
New-AzVirtualNetwork -Name MyVirtualNetwork -ResourceGroupName TestResourceGroup -Location centralus -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet -DnsServer 10.0.1.5,10.0.1.6
```

This example create a virtual network with two subnets and two DNS servers. The effect of
specifying the DNS servers on the virtual network is that the NICs/VMs that are deployed into this
virtual network inherit these DNS servers as defaults. These defaults can be overwritten per NIC
through a NIC-level setting. If no DNS servers are specified on a VNET and no DNS servers on the
NICs, then the default Azure DNS servers are used for DNS resolution.

### Example 3: Create a virtual network with a subnet referencing a network security group
```powershell
New-AzResourceGroup -Name TestResourceGroup -Location centralus
$rdpRule              = New-AzNetworkSecurityRuleConfig -Name rdp-rule -Description "Allow RDP" -Access Allow -Protocol Tcp -Direction Inbound -Priority 100 -SourceAddressPrefix Internet -SourcePortRange * -DestinationAddressPrefix * -DestinationPortRange 3389
$networkSecurityGroup = New-AzNetworkSecurityGroup -ResourceGroupName TestResourceGroup -Location centralus -Name "NSG-FrontEnd" -SecurityRules $rdpRule
$frontendSubnet       = New-AzVirtualNetworkSubnetConfig -Name frontendSubnet -AddressPrefix "10.0.1.0/24" -NetworkSecurityGroup $networkSecurityGroup
$backendSubnet        = New-AzVirtualNetworkSubnetConfig -Name backendSubnet  -AddressPrefix "10.0.2.0/24" -NetworkSecurityGroup $networkSecurityGroup
New-AzVirtualNetwork -Name MyVirtualNetwork -ResourceGroupName TestResourceGroup -Location centralus -AddressPrefix "10.0.0.0/16" -Subnet $frontendSubnet,$backendSubnet
```

This example creates a virtual network with subnets that reference a network security group. First,
the example creates a resource group as a container for the resources that will be created. Then, a
network security group is created that allows inbound RDP access, but otherwise enforces the
default network security group rules. The New-AzVirtualNetworkSubnetConfig cmdlet then creates
in-memory representations of two subnets that both reference the network security group that was
created. The New-AzVirtualNetwork command then creates the virtual network.

### Example 4: Create a virtual network with an IPAM Pool to auto allocate from for address prefixes
```powershell
New-AzNetworkManagerIpamPool -ResourceGroupName "testRG" -NetworkManagerName "testNM" -Name "testIpamPool" -Location "centralus" -AddressPrefix @("10.0.0.0/16")
$ipamPool = Get-AzNetworkManagerIpamPool -ResourceGroupName "testRG" -NetworkManagerName "testNM" -Name "testIpamPool"
$ipamPoolPrefixAllocation = [PSCustomObject]@{
     Id = $ipamPool.Id
     NumberOfIpAddresses = "256"
 }
$subnet = New-AzVirtualNetworkSubnetConfig -Name "testSubnet" -IpamPoolPrefixAllocation $ipamPoolPrefixAllocation
New-AzVirtualNetwork -Name "testVnet" -ResourceGroupName "testRG" -Location "centralus" -Subnet $subnet -IpamPoolPrefixAllocation $ipamPoolPrefixAllocation
```

This example creates a virtual network with an IPAM (IP Address Management) pool to automatically allocate address prefixes. 
First, an IPAM pool named testIpamPool is created in the testRG resource group and testNM network manager in the centralus region with the address prefix 10.0.0.0/16.
The Get-AzNetworkManagerIpamPool cmdlet retrieves the IPAM pool that was just created.
Next, a custom object representing the IPAM pool prefix allocation is created. This object includes the Id of the IPAM pool and the NumberOfIpAddresses to allocate. 
The New-AzVirtualNetworkSubnetConfig cmdlet creates a subnet named testSubnet configured to use the IPAM pool prefix allocation object.
Finally, the New-AzVirtualNetwork cmdlet creates a virtual network named testVnet in the testRG resource group and centralus location. 
The virtual network includes the subnet created in the previous step and uses the IPAM pool prefix allocation for address prefix allocation.

## PARAMETERS

### -AddressPrefix
Specifies a range of IP addresses for a virtual network.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IpamPoolPrefixAllocation
Specifies a list of PSIpamPoolPrefixAllocation objects to auto allocate from for virtual network address prefixes.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSIpamPoolPrefixAllocation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -AsJob
Run cmdlet in the background

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpCommunity
The BGP Community advertised over ExpressRoute.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DdosProtectionPlanId
Reference to the DDoS protection plan resource associated with the virtual network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DnsServer
Specifies the DNS server for a subnet.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EdgeZone
{{ Fill EdgeZone Description }}

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EnableDdosProtection
A switch parameter which represents if DDoS protection is enabled or not.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableEncryption
Indicates if encryption is enabled on the virtual network. The value should be true to enable encryption on the virtual network, false to disable encryption.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -EncryptionEnforcementPolicy
Set the Encryption EnforcementPolicy. The value should be allowUnencrypted to allow VMs without encryption capability inside an encrypted virtual network, or dropUnencrypted to disable any VM without encryption capability from being added into an encrypted virtual network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -FlowTimeout
FlowTimeout enables connection tracking for intra-VM flows. The value should be between 4 and 30 minutes (inclusive) to enable tracking, or null to disable tracking.

```yaml
Type: System.Nullable`1[System.Int32]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Force
Forces the command to run without asking for user confirmation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpAllocation
Specifies IpAllocations for a virtual network.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSIpAllocation[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Location
Specifies the region for the virtual network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the virtual network that this cmdlet creates.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PrivateEndpointVNetPoliciesValue
The PrivateEndpointVNetPolicies of the virtual network

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of a resource group to contain the virtual network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Subnet
Specifies a list of subnets to associate with the virtual network.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSSubnet[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Key-value pairs in the form of a hash table. For example:
@{key0="value0";key1=$null;key2="value2"}

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.String[]

### Microsoft.Azure.Commands.Network.Models.PSSubnet[]

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetwork

## NOTES

## RELATED LINKS

[Get-AzVirtualNetwork](./Get-AzVirtualNetwork.md)

[Remove-AzVirtualNetwork](./Remove-AzVirtualNetwork.md)

[Set-AzVirtualNetwork](./Set-AzVirtualNetwork.md)

[New-AzDdosProtectionPlan](./New-AzDdosProtectionPlan.md)
