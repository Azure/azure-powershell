---
external help file: Az.DnsResolver-help.xml
Module Name: Az.DnsResolver
online version: https://learn.microsoft.com/powershell/module/az.dnsresolver/new-azdnsresolveripconfigurationobject
schema: 2.0.0
---

# New-AzDnsResolverIPConfigurationObject

## SYNOPSIS
Create a in-memory object for IPConfiguration

## SYNTAX

```
New-AzDnsResolverIPConfigurationObject [-PrivateIPAddress <String>]
 [-PrivateIPAllocationMethod <IPAllocationMethod>] [-SubnetId <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for IPConfiguration

## EXAMPLES

### Example 1: Create an IPConfiguration
```powershell
New-AzDnsResolverIPConfigurationObject -PrivateIPAddress 1.1.2.12 -PrivateIPAllocationMethod Dynamic -SubnetId /subscriptions/0e5a46b1-de0b-4ec3-a5d7-dda908b4e076/resourceGroups/powershell-test-rg/providers/Microsoft.Network/virtualNetworks/psvirtualnetworkname44yqt9mb/subnets/pssubnetname44c6v0lr
```

```output
PrivateIPAddress PrivateIPAllocationMethod
---------------- -------------------------
1.1.2.12         Dynamic
```

This command creates an IPConfiguration

## PARAMETERS

### -PrivateIPAddress
Private IP address of the IP configuration.

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

### -PrivateIPAllocationMethod
Private IP address allocation method.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Support.IPAllocationMethod
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubnetId
Resource ID.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20220701.IPConfiguration

## NOTES

## RELATED LINKS
