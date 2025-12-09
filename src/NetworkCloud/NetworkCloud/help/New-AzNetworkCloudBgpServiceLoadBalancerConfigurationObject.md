---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/Az.NetworkCloud/new-aznetworkcloudbgpserviceloadbalancerconfigurationobject
schema: 2.0.0
---

# New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject

## SYNOPSIS
Create an in-memory object for BgpServiceLoadBalancerConfiguration.

## SYNTAX

```
New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject [-BgpAdvertisement <IBgpAdvertisement[]>]
 [-BgpPeer <IServiceLoadBalancerBgpPeer[]>] [-FabricPeeringEnabled <String>]
 [-IPAddressPool <IIPAddressPool[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for BgpServiceLoadBalancerConfiguration.

## EXAMPLES

### Example 1: Create BGP service load balancer configuration with advertisement
```powershell
$bgpAdvertisement = New-AzNetworkCloudBgpAdvertisementObject -AdvertiseToFabric "True" -IPAddressPool @("pool1")
New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject -FabricPeeringEnabled "True" -BgpAdvertisement @($bgpAdvertisement)
```

```output
BgpAdvertisement      : {Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.BgpAdvertisement}
BgpPeer               : {}
FabricPeeringEnabled  : True
IPAddressPool         : {}
```

This example creates a BGP service load balancer configuration with fabric peering enabled and associated IP pools.

### Example 2: Create configuration with fabric peering disabled
```powershell
New-AzNetworkCloudBgpServiceLoadBalancerConfigurationObject -FabricPeeringEnabled "False"
```

```output
BgpAdvertisement      : {}
BgpPeer               : {}
FabricPeeringEnabled  : False
IPAddressPool         : {}
```

This example creates a BGP service load balancer configuration with fabric peering disabled.

## PARAMETERS

### -BgpAdvertisement
The association of IP address pools to the communities and peers, allowing for announcement of IPs.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IBgpAdvertisement[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -BgpPeer
The list of additional BgpPeer entities that the Kubernetes cluster will peer with.
All peering must be explicitly defined.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IServiceLoadBalancerBgpPeer[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FabricPeeringEnabled
The indicator to specify if the load balancer peers with the network fabric.

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

### -IPAddressPool
The list of pools of IP addresses that can be allocated to load balancer services.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.IIPAddressPool[]
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

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.BgpServiceLoadBalancerConfiguration

## NOTES

## RELATED LINKS
