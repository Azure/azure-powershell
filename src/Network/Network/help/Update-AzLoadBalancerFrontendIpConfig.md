---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/update-azloadbalancerfrontendipconfig
schema: 2.0.0
---

# Update-AzLoadBalancerFrontendIpConfig

## SYNOPSIS
Incrementally updates frontend ip configuration of a load balancer.

## SYNTAX

### SetByResourceSubnetParent (Default)
```
Update-AzLoadBalancerFrontendIpConfig -LoadBalancer <PSLoadBalancer> -Name <String>
 [-PrivateIpAddress <String>] [-Zone <String[]>] [-Subnet <PSSubnet>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceIdSubnetParent
```
Update-AzLoadBalancerFrontendIpConfig -LoadBalancer <PSLoadBalancer> -Name <String>
 [-PrivateIpAddress <String>] [-Zone <String[]>] [-SubnetId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceIdPublicIpAddressParent
```
Update-AzLoadBalancerFrontendIpConfig -LoadBalancer <PSLoadBalancer> -Name <String> [-Zone <String[]>]
 [-PublicIpAddressId <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByResourcePublicIpAddressParent
```
Update-AzLoadBalancerFrontendIpConfig -LoadBalancer <PSLoadBalancer> -Name <String> [-Zone <String[]>]
 [-PublicIpAddress <PSPublicIpAddress>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

### SetByResourceSubnetParentName
```
Update-AzLoadBalancerFrontendIpConfig -ResourceGroupName <String> -LoadBalancerName <String> -Name <String>
 [-PrivateIpAddress <String>] [-Zone <String[]>] [-Subnet <PSSubnet>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceIdSubnetParentName
```
Update-AzLoadBalancerFrontendIpConfig -ResourceGroupName <String> -LoadBalancerName <String> -Name <String>
 [-PrivateIpAddress <String>] [-Zone <String[]>] [-SubnetId <String>]
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### SetByResourceIdPublicIpAddressParentName
```
Update-AzLoadBalancerFrontendIpConfig -ResourceGroupName <String> -LoadBalancerName <String> -Name <String>
 [-Zone <String[]>] [-PublicIpAddressId <String>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

### SetByResourcePublicIpAddressParentName
```
Update-AzLoadBalancerFrontendIpConfig -ResourceGroupName <String> -LoadBalancerName <String> -Name <String>
 [-Zone <String[]>] [-PublicIpAddress <PSPublicIpAddress>] [-DefaultProfile <IAzureContextContainer>] [-WhatIf]
 [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The **Update-AzLoadBalancerFrontendIpConfig** incrementally updates frontend ip configuration of a load balancer. I.e. only the specified parameters values are changed and values of the unspecified properties are kept unlike of Set-AzLoadBalancerFrontendIpConfig cmdlet.

## EXAMPLES

### Example 1
```powershell
PS C:> Update-AzLoadBalancerFrontendIpConfig -LoadBalancer $lb -Name $frontendName2 -PrivateIpAddress "10.0.1.6"
```

This command updates private ip address of frontend ip configuration keeping other properties unchanged.

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -LoadBalancer
The reference of the load balancer resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSLoadBalancer
Parameter Sets: SetByResourceSubnetParent, SetByResourceIdSubnetParent, SetByResourceIdPublicIpAddressParent, SetByResourcePublicIpAddressParent
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -LoadBalancerName
The reference of the load balancer resource.

```yaml
Type: System.String
Parameter Sets: SetByResourceSubnetParentName, SetByResourceIdSubnetParentName, SetByResourceIdPublicIpAddressParentName, SetByResourcePublicIpAddressParentName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Name
Name of the frontend ip configuration.

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

### -PrivateIpAddress
The private IP address of the IP configuration.

```yaml
Type: System.String
Parameter Sets: SetByResourceSubnetParent, SetByResourceIdSubnetParent, SetByResourceSubnetParentName, SetByResourceIdSubnetParentName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PublicIpAddress
The reference of the Public IP resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSPublicIpAddress
Parameter Sets: SetByResourcePublicIpAddressParent, SetByResourcePublicIpAddressParentName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -PublicIpAddressId
The reference of the Public IP resource.

```yaml
Type: System.String
Parameter Sets: SetByResourceIdPublicIpAddressParent, SetByResourceIdPublicIpAddressParentName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
The reference of the load balancer resource.

```yaml
Type: System.String
Parameter Sets: SetByResourceSubnetParentName, SetByResourceIdSubnetParentName, SetByResourceIdPublicIpAddressParentName, SetByResourcePublicIpAddressParentName
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName, ByValue)
Accept wildcard characters: False
```

### -Subnet
The reference of the subnet resource.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSSubnet
Parameter Sets: SetByResourceSubnetParent, SetByResourceSubnetParentName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -SubnetId
The reference of the subnet resource.

```yaml
Type: System.String
Parameter Sets: SetByResourceIdSubnetParent, SetByResourceIdSubnetParentName
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Zone
A list of availability zones denoting the IP allocated for the resource needs to come from.

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
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.Commands.Network.Models.PSLoadBalancer

### System.String

### System.String[]

### Microsoft.Azure.Commands.Network.Models.PSSubnet

### Microsoft.Azure.Commands.Network.Models.PSPublicIpAddress

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSLoadBalancer

## NOTES

## RELATED LINKS
