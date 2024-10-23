---
external help file: Az.DnsResolver-help.xml
Module Name: Az.DnsResolver
online version: https://learn.microsoft.com/powershell/module/az.dnsresolver/new-azdnsresolvertargetdnsserverobject
schema: 2.0.0
---

# New-AzDnsResolverTargetDnsServerObject

## SYNOPSIS
Create a in-memory object for Target DNS server

## SYNTAX

```
New-AzDnsResolverTargetDnsServerObject [-IPAddress <String>] [-Port <Int32>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Target DNS server

## EXAMPLES

### Example 1: Create an Target DNS server
```powershell
New-AzDnsResolverIPConfigurationObject -PrivateIPAddress 10.0.0.3 -PrivateIPAllocationMethod Dynamic -SubnetId /subscriptions/ea40042d-63d8-4d02-9261-fb31450e6c67/resourceGroups/sampleRG/providers/Microsoft.Network/virtualNetworks/vnet-hub/subnets/test-subnet
```

```output
PrivateIPAddress PrivateIPAllocationMethod
---------------- -------------------------
1.1.2.12       Dynamic
```

This command creates an target DNS server.

## PARAMETERS

### -IPAddress
DNS server IP address.

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

### -Port
DNS server port.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.TargetDnsServer

## NOTES

## RELATED LINKS
