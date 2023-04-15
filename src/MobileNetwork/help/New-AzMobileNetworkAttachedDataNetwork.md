---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.mobilenetwork/new-azmobilenetworkattacheddatanetwork
schema: 2.0.0
---

# New-AzMobileNetworkAttachedDataNetwork

## SYNOPSIS
Creates or updates an attached data network.
Must be created in the same location as its parent packet core data plane.

## SYNTAX

```
New-AzMobileNetworkAttachedDataNetwork -Name <String> -PacketCoreControlPlaneName <String>
 -PacketCoreDataPlaneName <String> -ResourceGroupName <String> -DnsAddress <String[]> -Location <String>
 [-SubscriptionId <String>] [-NaptConfigurationEnabled <NaptEnabled>] [-NaptConfigurationPinholeLimit <Int32>]
 [-PinholeTimeoutIcmp <Int32>] [-PinholeTimeoutTcp <Int32>] [-PinholeTimeoutUdp <Int32>]
 [-PortRangeMaxPort <Int32>] [-PortRangeMinPort <Int32>] [-PortReuseHoldTimeTcp <Int32>]
 [-PortReuseHoldTimeUdp <Int32>] [-Tag <Hashtable>] [-UserEquipmentAddressPoolPrefix <String[]>]
 [-UserEquipmentStaticAddressPoolPrefix <String[]>] [-UserPlaneDataInterfaceIpv4Address <String>]
 [-UserPlaneDataInterfaceIpv4Gateway <String>] [-UserPlaneDataInterfaceIpv4Subnet <String>]
 [-UserPlaneDataInterfaceName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

## DESCRIPTION
Creates or updates an attached data network.
Must be created in the same location as its parent packet core data plane.

## EXAMPLES

### Example 1: Creates or updates an attached data network.
```powershell
$dns=@("1.1.1.1", "1.1.1.2")

New-AzMobileNetworkAttachedDataNetwork -Name azps-mn-adn -PacketCoreControlPlaneName azps-mn-pccp -PacketCoreDataPlaneName azps-mn-pcdp -ResourceGroupName azps_test_group -DnsAddress $dns -Location eastus -UserPlaneDataInterfaceIpv4Address 10.0.0.10 -UserPlaneDataInterfaceIpv4Gateway 10.0.0.1 -UserPlaneDataInterfaceIpv4Subnet 10.0.0.0/24 -UserPlaneDataInterfaceName N6
```

```output
Location Name        ResourceGroupName ProvisioningState
-------- ----        ----------------- -----------------
eastus   azps-mn-adn azps_test_group   Succeeded
```

Creates or updates an attached data network.
Must be created in the same location as its parent packet core data plane.

## PARAMETERS

### -AsJob
Run the command as a job

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

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DnsAddress
The DNS servers to signal to UEs to use for this attached data network.
This configuration is mandatory - if you don't want DNS servers, you must provide an empty array.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the attached data network.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: AttachedDataNetworkName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NaptConfigurationEnabled
Whether NAPT is enabled for connections to this attached data network.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Support.NaptEnabled
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NaptConfigurationPinholeLimit
Maximum number of UDP and TCP pinholes that can be open simultaneously on the core interface.
For 5G networks, this is the N6 interface.
For 4G networks, this is the SGi interface.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

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

### -PacketCoreControlPlaneName
The name of the packet core control plane.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PacketCoreDataPlaneName
The name of the packet core data plane.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PinholeTimeoutIcmp
Pinhole timeout for ICMP pinholes in seconds.
Default for ICMP Echo is 30 seconds.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PinholeTimeoutTcp
Pinhole timeout for TCP pinholes in seconds.
Default for TCP is 3 minutes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PinholeTimeoutUdp
Pinhole timeout for UDP pinholes in seconds.
Default for UDP is 30 seconds.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PortRangeMaxPort
The maximum port number

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PortRangeMinPort
The minimum port number

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PortReuseHoldTimeTcp
Minimum time in seconds that will pass before a TCP port that was used by a closed pinhole can be reused.
Default for TCP is 2 minutes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PortReuseHoldTimeUdp
Minimum time in seconds that will pass before a UDP port that was used by a closed pinhole can be reused.
Default for UDP is 1 minute.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserEquipmentAddressPoolPrefix
The user equipment (UE) address pool prefixes for the attached data network from which the packet core instance will dynamically assign IP addresses to UEs.The packet core instance assigns an IP address to a UE when the UE sets up a PDU session.
You must define at least one of userEquipmentAddressPoolPrefix and userEquipmentStaticAddressPoolPrefix.
If you define both, they must be of the same size.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserEquipmentStaticAddressPoolPrefix
The user equipment (UE) address pool prefixes for the attached data network from which the packet core instance will assign static IP addresses to UEs.The packet core instance assigns an IP address to a UE when the UE sets up a PDU session.
The static IP address for a specific UE is set in StaticIPConfiguration on the corresponding SIM resource.At least one of userEquipmentAddressPoolPrefix and userEquipmentStaticAddressPoolPrefix must be defined.
If both are defined, they must be of the same size.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserPlaneDataInterfaceIpv4Address
The IPv4 address.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserPlaneDataInterfaceIpv4Gateway
The default IPv4 gateway (router).

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserPlaneDataInterfaceIpv4Subnet
The IPv4 subnet.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -UserPlaneDataInterfaceName
The logical name for this interface.
This should match one of the interfaces configured on your Azure Stack Edge device.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
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
Default value: None
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.IAttachedDataNetwork

## NOTES

ALIASES

## RELATED LINKS

