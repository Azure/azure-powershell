---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azvirtualapplianceinternetingressipsproperty
schema: 2.0.0
---

# New-AzVirtualApplianceInternetIngressIpsProperty

## SYNOPSIS
Define a Network Virtual Appliance Internet Ingress IPs Property for the resource.

## SYNTAX

```
New-AzVirtualApplianceInternetIngressIpsProperty -InternetIngressPublicIpId <String[]>
 [-DefaultProfile <IAzureContextContainer>] [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
The New-AzVirtualApplianceInternetIngressIpsProperty command defines Public IPs which can be attached for Internet Ingress with Network Virtual Appliance resource.

## EXAMPLES

### Example 1
```powershell
$IngressIps=New-AzVirtualApplianceInternetIngressIpsProperty -InternetIngressPublicIpId "/subscriptions/{subscriptionid}/resourceGroups/{rgname}/providers/Microsoft.Network/publicIPAddresses/{publicipname}"
```

Create an Internet Ingress Property object to be used with New-AzNetworkVirtualAppliance command.

### Example 2
```powershell
$IngressIps=New-AzVirtualApplianceInternetIngressIpsProperty -InternetIngressPublicIpId "/subscriptions/{subscriptionid}/resourceGroups/{rgname}/providers/Microsoft.Network/publicIPAddresses/{publicipname}", "/subscriptions/{subscriptionid}/resourceGroups/{rgname}/providers/Microsoft.Network/publicIPAddresses/{publicipname}"
```

Creates a list of Internet Ingress Property object which has 2 Public IPs which can be attached to the Network Virtual Appliance resource.

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

### -InternetIngressPublicIpId
The IDs of the Public IPs which can be given as comma separated input.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs. The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

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

### Microsoft.Azure.Commands.Network.Models.PSVirtualApplianceInternetIngressIpsProperties

## NOTES

## RELATED LINKS

## RELATED LINKS
