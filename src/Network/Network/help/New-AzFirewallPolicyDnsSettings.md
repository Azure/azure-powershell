---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://docs.microsoft.com/en-us/powershell/module/az.network/new-azfirewallpolicydnssettings
schema: 2.0.0
---

# New-AzFirewallPolicyDnsSettings

## SYNOPSIS
Creates a new DNS Settings for Azure Firewall Policy

## SYNTAX

```
New-AzFirewallPolicyDnsSettings [-EnableProxy] [-Server <String[]>] [-ProxyNotRequiredForNetworkRule]
```

## DESCRIPTION
The **New-AzFirewallPolicyDnsSettings** cmdlet creates a DNS Settings Object for Azure Firewall Policy

## EXAMPLES

### 1. Create an empty policy
```powershell
PS C:\> New-AzFirewallPolicyDnsSettings -EnableProxy
```

This example creates a dns settings object with setting enabling dns proxy.

### 2. Create an empty policy with ThreatIntel Mode
```powershell
PS C:\> $dnsServers = @("10.10.10.1", "20.20.20.2")
PS C:\> New-AzFirewallPolicyDnsSettings -EnableProxy -Server $dnsServers
```
This example creates a dns settings object with setting enabling dns proxy and setting custom dns servers.

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

### -EnableProxy
Enable DNS Proxy. By default it is disabled.
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

### -ProxyNotRequiredForNetworkRule
Requires DNS Proxy functionality for FQDNs within Network Rules.

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

### -Server
The list of DNS Servers to be used for DNS resolution.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicyDnsSettings

## NOTES

## RELATED LINKS
