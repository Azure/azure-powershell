---
external help file: Azs.Network.Admin-help.xml
Module Name: Azs.Network.Admin
online version: 
schema: 2.0.0
---

# Get-AzsNetworkAdminOverview

## SYNOPSIS
Get an overview of the state of the network resource provider.

## SYNTAX

```
Get-AzsNetworkAdminOverview [<CommonParameters>]
```

## DESCRIPTION
Get an overview of the state of the network resource provider. 
Individual properties provide detailed counts of resource usage and health by component.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsNetworkAdminOverview
```

ProvisioningState     : Succeeded
VirtualNetworkHealth  : Microsoft.AzureStack.Management.Network.Admin.Models.AdminOverviewResourceHealth
LoadBalancerMuxHealth : Microsoft.AzureStack.Management.Network.Admin.Models.AdminOverviewResourceHealth
VirtualGatewayHealth  : Microsoft.AzureStack.Management.Network.Admin.Models.AdminOverviewResourceHealth
PublicIpAddressUsage  : Microsoft.AzureStack.Management.Network.Admin.Models.AdminOverviewResourceUsage
BackendIpUsage        : Microsoft.AzureStack.Management.Network.Admin.Models.AdminOverviewResourceUsage
MacAddressUsage       : Microsoft.AzureStack.Management.Network.Admin.Models.AdminOverviewResourceUsage
Id                    : /subscriptions/df5abebb-3edc-40c5-9155-b4ab239d79d3/providers/Microsoft.Network.Admin/adminOverview/
Name                  :
Type                  : Microsoft.Network.Admin/adminOverview
Location              :
Tags                  :

   Get network admin overview.

### -------------------------- EXAMPLE 2 --------------------------
```
(Get-AzsNetworkAdminOverview).PublicIpAddressUsage
```

TotalResourceCount InUseResourceCount
------------------ ------------------
   255                 31

Get public ip address usage.

## PARAMETERS

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Network.Admin.Models.AdminOverview

## NOTES

## RELATED LINKS

