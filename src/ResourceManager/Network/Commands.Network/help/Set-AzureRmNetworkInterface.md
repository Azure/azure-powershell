---
external help file: Microsoft.Azure.Commands.Network.dll-Help.xml
Module Name: AzureRM.Network
ms.assetid: DDB38A77-E5C0-47DD-BADD-94488F661CD5
online version: https://docs.microsoft.com/en-us/powershell/module/azurerm.network/set-azurermnetworkinterface
schema: 2.0.0
---

# Set-AzureRmNetworkInterface

## SYNOPSIS
Sets the goal state for a network interface.

## SYNTAX

```
Set-AzureRmNetworkInterface -NetworkInterface <PSNetworkInterface> [-AsJob]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **Set-AzureRmNetworkInterface** sets the goal state for an Azure network interface.

## EXAMPLES

### Example 1: Configure a network interface
```
$Nic = Get-AzureRmNetworkInterface -ResourceGroupName "ResourceGroup1" -Name "NetworkInterface1"
$Nic.IpConfigurations[0].PrivateIpAddress = "10.0.1.20"
$Nic.IpConfigurations[0].PrivateIpAllocationMethod = "Static"
$Nic.Tag = @{Name = "Name"; Value = "Value"}
Set-AzureRmNetworkInterface -NetworkInterface $Nic
```

This example configures a network interface.
The first command gets a network interface named NetworkInterface1 in resource group ResourceGroup1.
The second command sets the private IP address of the IP configuration.
The third command sets the private IP allocation method to Static.
The fourth command sets a tag on the network interface.
The fifth command uses the information stored in the $Nic variable to set the network interface.

### Example 2: Change DNS settings on a network interface
```
$nic = Get-AzureRmNetworkInterface -ResourceGroupName "ResourceGroup1" -Name "NetworkInterface1"
$nic.DnsSettings.DnsServers.Add("192.168.1.100")
$nic | Set-AzureRmNetworkInterface
```

The first command gets a network interface named NetworkInterface1 that exists within resource group ResourceGroup1. The second command adds DNS server 192.168.1.100 to this interface. The third command applies these changes to the network interface. To remove a DNS server, follow the commands listed above, but replace ".Add" with ".Remove" in the second command.

### Example 3: Enable IP forwading on a network interface
```
$nic = Get-AzureRmNetworkInterface -ResourceGroupName "ResourceGroup1" -Name "NetworkInterface1"
$nic.EnableIPForwarding = 1
$nic | Set-AzureRmNetworkInterface
```

The first command gets an existing network interface called NetworkInterface1 and stores it in the $nic variable. The second command changes the IP forwarding value to true. Finally, the third command applies the changes to the network interface. To disable IP forwarding on a network interface, follow the sample example, but be sure to change the second command to "$nic.EnableIPForwarding = 0".

### Example 4: Change the subnet of a network interface
```
$nic = Get-AzureRmNetworkInterface -ResourceGroupName "ResourceGroup1" -Name "NetworkInterface1"
$vnet = Get-AzureRmVirtualNetwork -Name VNet1 -ResourceGroupName crosssubcrossversionpeering
$subnet2 = Get-AzureRmVirtualNetworkSubnetConfig -Name Subnet2 -VirtualNetwork $vnet
$nic.IpConfigurations[0].Subnet.Id = $subnet2.Id
$nic | Set-AzureRmNetworkInterface
```

The first command gets the network interface NetworkInterface1 and stores it in the $nic variable. The second command gets the virtual network associated with the subnet that the network interface is going to be associated with. The second command gets the subnet and stores it in the $subnet2 variable. The third command associated the primary private IP address of the network interface with the new subnet. Finally the last command applied these changes on the network interface.

>[!NOTE] 
>The IP configurations must be dynamic before you can change the subnet. If you have static IP configurations, change then to dynamic before proceeding. 

>[!NOTE]
>If the network interface has multiple IP configurations, the forth command must be done for all these IP configurations before the final Set-AzureRmNetworkInterface command is executed. This can be done as in the forth command but by replacing "0" with the appropriate number. If a network interface has N IP configurations, then N-1 of these commands must exist.

### Example 5: Associate/Dissociate a Network Security Group to a network interface
```
$nic = Get-AzureRmNetworkInterface -ResourceGroupName "ResourceGroup1" -Name "NetworkInterface1"
$nsg = Get-AzureRmNetworkSecurityGroup -ResourceGroupName "ResourceGroup1" -Name "MyNSG"
$nic.NetworkSecurityGroup = $nsg
$nic | Set-AzureRmNetworkInterface
```

The first command gets an existing network interface called NetworkInterface1 and stores it in the $nic variable. The second command gets an existing network security group called MyNSG and stores it in the $nsg variable. The forth command assigns the $nsg to the $nic. Finally, the fifth command applies the changes to the Network interface. To dissociate network security groups from a network interface, simple replace $nsg in the forth command with $null.

## PARAMETERS

### -AsJob
Run cmdlet in the background

```yaml
Type: SwitchParameter
Parameter Sets: (All)
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with azure.

```yaml
Type: IAzureContextContainer
Parameter Sets: (All)
Aliases: AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkInterface
Specifies a **NetworkInterface** object that represents the goal state for a network interface.

```yaml
Type: PSNetworkInterface
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PSNetworkInterface
Parameter 'NetworkInterface' accepts value of type 'PSNetworkInterface' from the pipeline

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSNetworkInterface

## NOTES

## RELATED LINKS

[Get-AzureRmNetworkInterface](./Get-AzureRmNetworkInterface.md)

[Get-AzureRmNetworkInterface](./Get-AzureRmNetworkInterface.md)

[New-AzureRmNetworkInterface](./New-AzureRmNetworkInterface.md)

[Remove-AzureRmNetworkInterface](./Remove-AzureRmNetworkInterface.md)
