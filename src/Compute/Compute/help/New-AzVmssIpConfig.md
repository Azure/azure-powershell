---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Compute.dll-Help.xml
Module Name: Az.Compute
ms.assetid: 92F192A5-F75E-4EFE-B2D2-B0DF0B78D3B5
online version: https://docs.microsoft.com/powershell/module/az.compute/new-azvmssipconfig
schema: 2.0.0
---

# New-AzVmssIpConfig

## SYNOPSIS
Creates an IP configuration for a network interface of a VMSS.

## SYNTAX

```
New-AzVmssIpConfig [[-Name] <String>] [[-Id] <String>] [[-SubnetId] <String>]
 [[-ApplicationGatewayBackendAddressPoolsId] <String[]>] [[-LoadBalancerBackendAddressPoolsId] <String[]>]
 [[-LoadBalancerInboundNatPoolsId] <String[]>] [-Primary] [-PrivateIPAddressVersion <String>]
 [-PublicIPAddressConfigurationName <String>] [-PublicIPAddressConfigurationIdleTimeoutInMinutes <Int32>]
 [-DnsSetting <String>] [-IpTag <VirtualMachineScaleSetIpTag[]>] [-PublicIPPrefix <String>]
 [-PublicIPAddressVersion <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzVmssIpConfig** cmdlet creates an IP configuration object for a network interface of a Virtual Machine Scale Set (VMSS).
Specify the configuration from this cmdlet as the *IPConfiguration* parameter of the Add-AzVmssNetworkInterfaceConfiguration cmdlet.

## EXAMPLES

### Example 1: Create an IP configuration object for a VMSS interface
```
PS C:\> $IPConfiguration = New-AzVmssIPConfig -Name "ContosoVmssInterface02" -SubnetId $SubnetId
```

This command creates an IP configuration object named ContosoVmssInterface02.
The command uses a previously defined subnet ID stored in $SubnetId.
The command stores the configuration settings in the $IPConfiguration variable for later use with **Add-AzVmssNetworkInterfaceConfiguration**.

### Example 2: Create an IP configuration object that includes NAT pool settings
```
PS C:\> $IPConfiguration = New-AzVmssIPConfig -Name "ContosoVmssInterface03" -LoadBalancerInboundNatPoolsId $expectedLb.InboundNatPools[0].Id -LoadBalancerBackendAddressPoolsId $expectedLb.BackendAddressPools[0].Id -SubnetId $SubnetId
```

This command creates an IP configuration object named ContosoVmssInterface03, and then stores it in the $IPConfiguration variable for later use.
The command uses a previously defined subnet ID stored in $SubnetId.
The command stores the configuration settings in the $IPConfiguration variable for later use.
The command specifies values for the *LoadBalancerInboundNatPoolsId* and *LoadBalancerBackendAddressPoolsId* parameters.

## PARAMETERS

### -ApplicationGatewayBackendAddressPoolsId
Specifies an array of references to backend address pools of load balancers.
A scale set can reference backend address pools of one public and one internal load balancer.
Multiple scale sets cannot use the same load balancer.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
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

### -DnsSetting
The dns settings to be applied on the publicIP addresses.
The domain name label of the Dns settings to be applied on the publicIP addresses.
The concatenation of the domain name label and vm index will be the domain name labels of the Public IP Address resources that will be created.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PublicIPAddressDomainNameLabel

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Id
Specifies an ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -IpTag
Specifies an array of Ip Tag objects.

```yaml
Type: Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetIpTag[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LoadBalancerBackendAddressPoolsId
Specifies an array of references to incoming network address translation (NAT) pools of the load balancers.
A scale set can reference incoming NAT pools of one public and one internal load balancer.
Multiple scale sets cannot use the same load balancer.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -LoadBalancerInboundNatPoolsId
Specifies an array of references to incoming NAT pools of the load balancers.
A scale set can reference incoming NAT pools of one public and one internal load balancer.
Multiple scale sets cannot use the same load balancer.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
Specifies the name of the IP configuration.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Primary
Specifies the primary IP Configuration in case the network interface has more than one IP Configuration.

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

### -PrivateIPAddressVersion
Specify the IP configuration for private IP address.  Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.

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

### -PublicIPAddressConfigurationIdleTimeoutInMinutes
The idle timeout of the public IP address.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases: PublicIPAddressIdleTimeoutInMinutes

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PublicIPAddressConfigurationName
The publicIP address configuration name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PublicIPAddressName

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PublicIPAddressVersion
Specify the IP configuration for public IP address.  Default is taken as IPv4.  Possible values are: 'IPv4' and 'IPv6'.

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

### -PublicIPPrefix
The ID of Public IP Prefix

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

### -SubnetId
Specifies the subnet ID in which the configuration creates  the VMSS network interface.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
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
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

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

### System.String

### System.String[]

### System.Int32

### Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetIpTag[]

## OUTPUTS

### Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetIPConfiguration

## NOTES

## RELATED LINKS

[Add-AzVmssNetworkInterfaceConfiguration](./Add-AzVmssNetworkInterfaceConfiguration.md)


