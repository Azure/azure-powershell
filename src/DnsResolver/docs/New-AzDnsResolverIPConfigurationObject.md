---
external help file:
Module Name: Az.DnsResolver
online version: https://docs.microsoft.com/en-us/powershell/module/az.DnsResolver/new-AzDnsResolverIPConfigurationObject
schema: 2.0.0
---

# New-AzDnsResolverIPConfigurationObject

## SYNOPSIS
Create a in-memory object for IPConfiguration

## SYNTAX

```
New-AzDnsResolverIPConfigurationObject [-PrivateIPAddress <String>]
 [-PrivateIPAllocationMethod <IPAllocationMethod>] [-SubnetId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for IPConfiguration

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

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

### Microsoft.Azure.PowerShell.Cmdlets.DnsResolver.Models.Api20200401Preview.IPConfiguration

## NOTES

ALIASES

## RELATED LINKS

