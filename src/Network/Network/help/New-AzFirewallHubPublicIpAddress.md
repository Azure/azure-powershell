---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azfirewallhubpublicipaddress
schema: 2.0.0
---

# New-AzFirewallHubPublicIpAddress

## SYNOPSIS
Public Ip assoicated to the firewall on virtual hub

## SYNTAX

```
New-AzFirewallHubPublicIpAddress [-Count <Int32>] [-Address <PSAzureFirewallPublicIpAddress[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Public Ip assoicated to the firewall on virtual hub

## EXAMPLES

### Example 1
```powershell
New-AzFirewallHubPublicIpAddress -Count 2
```

This will create 2 public ips on the firewall attached to the virtual hub. This will create the ip address in the backend.We cannot provide the ipaddresses explicitly for a new firewall.

### Example 2
```powershell
$publicIp1 = New-AzFirewallPublicIpAddress -Address 10.2.3.4
$publicIp2 = New-AzFirewallPublicIpAddress -Address 20.56.37.46
New-AzFirewallHubPublicIpAddress -Count 3 -Address $publicIp1, $publicIp2
```

This will create 1 new public ip on the firewall by retain $publicIp1, $publicIp2 which are already exist on the firewall.

## PARAMETERS

### -Address
The Public IP Addresses of the Firewall attached to a hub

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPublicIpAddress[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Count
The count of public Ip addresses

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubPublicIpAddresses

## NOTES

## RELATED LINKS
