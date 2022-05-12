---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/powershell/module/az.network/new-azfirewallhubipaddress
schema: 2.0.0
---

# New-AzFirewallHubIpAddress

## SYNOPSIS
Ip addresses assoicated to the firewall on virtual hub

## SYNTAX

```
New-AzFirewallHubIpAddress [-PrivateIPAddress <String>] [-PublicIP <PSAzureFirewallHubPublicIpAddresses>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
Ip addresses assoicated to the firewall on virtual hub. These can be public and private addresses

## EXAMPLES

### Example 1
```powershell
$fwpips = New-AzFirewallHubPublicIpAddress -Count 2
New-AzFirewallHubIpAddress -PublicIP $fwpips
```

This example creates a Hub Ip address object with a count of 2 public IPs. The HubIPAddress object is associated to the firewall on the virtual hub.

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

### -PrivateIPAddress
The private Ip Address of the Firewall attached to a Hub

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

### -PublicIP
The IP Addresses of the Firewall attached to a hub

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubPublicIpAddresses
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

### None

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallHubIpAddresses

## NOTES

## RELATED LINKS
