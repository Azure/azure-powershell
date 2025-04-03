---
external help file:
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-AzNetworkCloudNetworkAttachmentObject
schema: 2.0.0
---

# New-AzNetworkCloudNetworkAttachmentObject

## SYNOPSIS
Create an in-memory object for NetworkAttachment.

## SYNTAX

```
New-AzNetworkCloudNetworkAttachmentObject -AttachedNetworkId <String>
 -IPAllocationMethod <VirtualMachineIPAllocationMethod> [-DefaultGateway <DefaultGateway>]
 [-Ipv4Address <String>] [-Ipv6Address <String>] [-Name <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NetworkAttachment.

## EXAMPLES

### Example 1: Create an in-memory object for NetworkAttachment.
```powershell
New-AzNetworkCloudNetworkAttachmentObject -AttachedNetworkId "/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.NetworkCloud/l3Networks/l3NetworkName" -IPAllocationMethod "Dynamic" -DefaultGateway "True" -Ipv4Address "198.51.100.1" -Ipv6Address "2001:0db8:0000:0000:0000:0000:0000:0001" -Name "netAttachName01"
```

```output
AttachedNetworkId                                                                                                        DefaultGateway IPAllocationMethod Ipv4Address  Ipv6Address
-----------------                                                                                                        -------------- ------------------ -----------  -----------                   
/subscriptions/subscriptionId/resourceGroups/resourceGroupName/providers/Microsoft.NetworkCloud/l3Networks/l3NetworkName True           Dynamic            198.51.100.1 2001:0db8:0000:0000:0000:0000…

```

Create an in-memory object for NetworkAttachment.

## PARAMETERS

### -AttachedNetworkId
The resource ID of the associated network attached to the virtual machine.
        It can be one of cloudServicesNetwork, l3Network, l2Network or trunkedNetwork resources.

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

### -DefaultGateway
The indicator of whether this is the default gateway.
        Only one of the attached networks (including the CloudServicesNetwork attachment) for a single machine may be specified as True.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.DefaultGateway
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IPAllocationMethod
The IP allocation mechanism for the virtual machine.
        Dynamic and Static are only valid for l3Network which may also specify Disabled.
        Otherwise, Disabled is the only permitted value.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Support.VirtualMachineIPAllocationMethod
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Ipv4Address
The IPv4 address of the virtual machine.

        This field is used only if the attached network has IPAllocationType of IPV4 or DualStack.

        If IPAllocationMethod is:
        Static - this field must contain a user specified IPv4 address from within the subnet specified in the attached network.
        Dynamic - this field is read-only, but will be populated with an address from within the subnet specified in the attached network.
        Disabled - this field will be empty.

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

### -Ipv6Address
The IPv6 address of the virtual machine.

        This field is used only if the attached network has IPAllocationType of IPV6 or DualStack.

        If IPAllocationMethod is:
        Static - this field must contain an IPv6 address range from within the range specified in the attached network.
        Dynamic - this field is read-only, but will be populated with an range from within the subnet specified in the attached network.
        Disabled - this field will be empty.

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

### -Name
The associated network's interface name.
        If specified, the network attachment name has a maximum length of 15 characters and must be unique to this virtual machine.
        If the user doesn’t specify this value, the default interface name of the network resource will be used.
        For a CloudServicesNetwork resource, this name will be ignored.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.NetworkAttachment

## NOTES

## RELATED LINKS

