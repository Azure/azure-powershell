---
external help file: Az.Nginx-help.xml
Module Name: Az.Nginx
online version: https://learn.microsoft.com/powershell/module/Az.Nginx/new-aznginxnetworkprofileobject
schema: 2.0.0
---

# New-AzNginxNetworkProfileObject

## SYNOPSIS
Create an in-memory object for NginxNetworkProfile.

## SYNTAX

```
New-AzNginxNetworkProfileObject [-FrontEndIPConfiguration <INginxFrontendIPConfiguration>]
 [-NetworkInterfaceConfiguration <INginxNetworkInterfaceConfiguration>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NginxNetworkProfile.

## EXAMPLES

### Example 1: Create an in-memory object for NginxNetworkProfile
```powershell
New-AzNginxNetworkProfileObject -FrontEndIPConfiguration @{PublicIPAddress=@($publicIp)} -NetworkInterfaceConfiguration @{SubnetId='/subscriptions/xxxxxxxxxx-xxxx-xxxxx-xxxxxxxxxxxx/resourceGroups/nginx-test-rg/providers/Microsoft.Network/virtualNetworks/nginx-test-vnet/subnets/default'}
```

```output
FrontEndIPConfiguration        NetworkInterfaceConfiguration
-----------------------        -----------------------------
{…                             {…
```

Create an in-memory object for NginxNetworkProfile.

## PARAMETERS

### -FrontEndIPConfiguration

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.INginxFrontendIPConfiguration
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NetworkInterfaceConfiguration

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.INginxNetworkInterfaceConfiguration
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

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.NginxNetworkProfile

## NOTES

## RELATED LINKS
