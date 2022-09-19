---
external help file:
Module Name: Az.Nginx
online version: https://docs.microsoft.com/powershell/module/az.Nginx/new-AzNginxNetworkProfileObject
schema: 2.0.0
---

# New-AzNginxNetworkProfileObject

## SYNOPSIS
Create an in-memory object for NginxNetworkProfile.

## SYNTAX

```
New-AzNginxNetworkProfileObject [-FrontEndIPConfiguration <INginxFrontendIPConfiguration>]
 [-NetworkInterfaceConfiguration <INginxNetworkInterfaceConfiguration>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NginxNetworkProfile.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -FrontEndIPConfiguration
To construct, see NOTES section for FRONTENDIPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api20220801.INginxFrontendIPConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkInterfaceConfiguration
To construct, see NOTES section for NETWORKINTERFACECONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api20220801.INginxNetworkInterfaceConfiguration
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

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api20220801.NginxNetworkProfile

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`FRONTENDIPCONFIGURATION <INginxFrontendIPConfiguration>`: 
  - `[PrivateIPAddress <INginxPrivateIPAddress[]>]`: 
    - `[PrivateIPAddress <String>]`: 
    - `[PrivateIPAllocationMethod <NginxPrivateIPAllocationMethod?>]`: 
    - `[SubnetId <String>]`: 
  - `[PublicIPAddress <INginxPublicIPAddress[]>]`: 
    - `[Id <String>]`: 

`NETWORKINTERFACECONFIGURATION <INginxNetworkInterfaceConfiguration>`: 
  - `[SubnetId <String>]`: 

## RELATED LINKS

