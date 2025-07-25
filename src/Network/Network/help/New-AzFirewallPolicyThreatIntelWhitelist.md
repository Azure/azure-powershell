---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azfirewallpolicythreatintelwhitelist
schema: 2.0.0
---

# New-AzFirewallPolicyThreatIntelWhitelist

## SYNOPSIS
Create a new threat intelligence allowlist for Azure Firewall Policy

## SYNTAX

```
New-AzFirewallPolicyThreatIntelWhitelist [-FQDN <String[]>] [-IpAddress <String[]>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
The **New-AzFirewallPolicyThreatIntelWhitelist** cmdlet creates a threat intel allowlist object, which can be used when creating or setting an Azure Firewall Policy.

## EXAMPLES

### Example 1
```powershell
New-AzFirewallPolicyThreatIntelWhitelist -IpAddress 23.46.72.91,192.79.236.79 -FQDN microsoft.com
```

This example creates a threat intel allowlist containing a FQDN allowlist of one entry and an Ip address allowlist of two entries

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

### -FQDN
The FQDNs of the Threat Intel allowlist

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpAddress
The IP Addresses of the Threat Intel allowlist

```yaml
Type: System.String[]
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

### Microsoft.Azure.Commands.Network.Models.PSAzureFirewallPolicyThreatIntelWhitelist

## NOTES

## RELATED LINKS
