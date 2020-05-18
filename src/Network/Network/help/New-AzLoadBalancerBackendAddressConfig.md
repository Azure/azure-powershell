---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version:
schema: 2.0.0
---

# New-AzLoadBalancerBackendAddressConfig

## SYNOPSIS
Returns a load balancer address config. 

## SYNTAX

```
New-AzLoadBalancerBackendAddressConfig -IpAddress <String> -Name <String> -VirtualNetwork <PSVirtualNetwork>
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Returns a load balancer address config. 

## EXAMPLES

### Example 1
### New loadbalancer address config with virtual network reference
```powershell
PS C:\> $virtualNetwork = Get-AzVirtualNetwork -Name $vnetName -ResourceGroupName $resourceGroup

New-AzLoadBalancerBackendAddressConfig -IpAddress "10.0.0.5" -Name "TestVNetRef" -VirtualNetwork $virtualNetwork


Name                    : TestVNetRef
IpAddress               : 10.0.0.5
BackendIpConfigurations : null
VirtualNetwork          : {
                            "AddressSpace": {
                              "AddressPrefixes": [
                                "10.0.0.0/16"
                              ]
                            },
                            "DhcpOptions": {},
                            "Subnets": [],
                            "VirtualNetworkPeerings": [],
                            "ProvisioningState": "Succeeded",
                            "EnableDdosProtection": false,
                            "ResourceGroupName": "xxxxxxxxxxx",
                            "Location": "brazilsouth",
                            "ResourceGuid": "xxxxxxxxxxxxxxxxxx",
                            "Type": "Microsoft.Network/virtualNetworks",
                            "Name": "xxxxx",
                            "Etag": "W/\"95f7ba63-642e-4ff0-b7dc-7b80bf1cc620\"",
                            "Id": 
                          "/subscriptions/xxxxxxxxx/resourceGroups/xxxxxxxxxx/providers/Microsoft.Network/virtualNetworks/xxxxxxxxxxxx"
                          }
```

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

### -IpAddress
The IPAddress to add to the backend pool

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
The name of the Backend Address config

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

### -VirtualNetwork
The virtual network associated with Backend Address config

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSVirtualNetwork
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### Microsoft.Azure.Commands.Network.Models.PSNetworkInterfaceIPConfiguration

### Microsoft.Azure.Commands.Network.Models.PSVirtualNetwork

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSLoadBalancerBackendAddress

## NOTES

## RELATED LINKS
