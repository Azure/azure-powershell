---
external help file: Az.CloudService-help.xml
Module Name: Az.CloudService
online version: https://learn.microsoft.com/powershell/module/Az.CloudService/new-azcloudserviceloadbalancerconfigurationobject
schema: 2.0.0
---

# New-AzCloudServiceLoadBalancerConfigurationObject

## SYNOPSIS
Create an in-memory object for LoadBalancerConfiguration.

## SYNTAX

```
New-AzCloudServiceLoadBalancerConfigurationObject
 -FrontendIPConfiguration <ILoadBalancerFrontendIPConfiguration[]> -Name <String> [-Id <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for LoadBalancerConfiguration.

## EXAMPLES

### Example 1: Create load balancer configuration object
```powershell
$publicIP = Get-AzPublicIpAddress -ResourceGroupName 'ContosoOrg' -Name 'ContosoPublicIP'
$feIpConfig = New-AzCloudServiceLoadBalancerFrontendIPConfigurationObject -Name 'ContosoFe' -PublicIPAddressId $publicIP.Id
$loadBalancerConfig = New-AzCloudServiceLoadBalancerConfigurationObject -Name 'ContosoLB' -FrontendIPConfiguration $feIpConfig
```

This command creates load balancer configuration object which is used for creating or updating a cloud service.
For more details see New-AzCloudService.

## PARAMETERS

### -FrontendIPConfiguration
Specifies the frontend IP to be used for the load balancer.
Only IPv4 frontend IP address is supported.
Each load balancer configuration must have exactly one frontend IP configuration.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.ILoadBalancerFrontendIPConfiguration[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Id
Resource Id.

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
The name of the Load balancer.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.LoadBalancerConfiguration

## NOTES

## RELATED LINKS
