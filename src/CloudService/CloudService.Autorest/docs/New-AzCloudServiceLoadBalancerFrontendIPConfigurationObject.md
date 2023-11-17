---
external help file:
Module Name: Az.CloudService
online version: https://learn.microsoft.com/powershell/module/az.cloudservice/new-azcloudserviceloadbalancerfrontendipconfigurationobject
schema: 2.0.0
---

# New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject

## SYNOPSIS
Create a in-memory object for LoadBalancerFrontendIPConfiguration

## SYNTAX

### DefaultParameterSet (Default)
```
New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject [-Name <String>] [-PublicIPAddressId <String>]
 [<CommonParameters>]
```

### PrivateIP
```
New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject [-Name <String>] [-PrivateIPAddress <String>]
 [-SubnetId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for LoadBalancerFrontendIPConfiguration

## EXAMPLES

### Example 1: Create load balancer frontend IP configuration object
```powershell
$publicIP = Get-AzPublicIpAddress -ResourceGroupName 'ContosoOrg' -Name 'ContosoPublicIP'
$feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -PublicIPAddressId $publicIp.Id
$loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig
```

This command creates load balancer frontend IP configuration object which is used for creating or updating a cloud service.
For more details see New-AzCloudService.

### Example 2: Create load balancer frontend IP configuration object with Private ID address
```powershell
# Create role profile object
$subnet = New-AzVirtualNetworkSubnetConfig -Name "WebTier" -AddressPrefix "10.0.0.0/24" -WarningAction SilentlyContinue 
$feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -privateIPAddress '10.0.0.6' -subnetId $Subnet.Id
$loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig

```

This command creates load balancer frontend IP configuration object with a Private IP address

## PARAMETERS

### -Name
Name of FrontendIpConfigration.

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

### -PrivateIPAddress
Private IP Address

```yaml
Type: System.String
Parameter Sets: PrivateIP
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PublicIPAddressId
Resource Id.

```yaml
Type: System.String
Parameter Sets: DefaultParameterSet
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
Subnet ID

```yaml
Type: System.String
Parameter Sets: PrivateIP
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

### Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.LoadBalancerFrontendIPConfiguration

## NOTES

ALIASES

## RELATED LINKS

