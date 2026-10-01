---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azddoscustompolicysourcepolicyoverride
schema: 2.0.0
---

# New-AzDdosCustomPolicySourcePolicyOverride

## SYNOPSIS
Creates a source policy override for a DDoS custom policy mitigation rule.

## SYNTAX

```
New-AzDdosCustomPolicySourcePolicyOverride -ActionType <String> [-IpPrefix <String[]>]
 [-GeoMatch <PSDdosCustomPolicyGeoMatch[]>] [-DefaultProfile <IAzureContextContainer>]
 [-ProgressAction <ActionPreference>] [-WhatIf] [-Confirm] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
The **New-AzDdosCustomPolicySourcePolicyOverride** cmdlet creates an in-memory source-specific action and match condition. Use the returned object with **New-AzDdosCustomPolicyMitigationRule**, **Add-AzDdosCustomPolicyMitigationRule**, or **Set-AzDdosCustomPolicyMitigationRule**.

## EXAMPLES

### Example 1: Deny traffic from selected prefixes and geography
```powershell
$geoMatch = New-AzDdosCustomPolicyGeoMatch -Continent Europe -CountryCode DE
$override = New-AzDdosCustomPolicySourcePolicyOverride -ActionType Deny -IpPrefix "192.0.2.0/24" -GeoMatch $geoMatch
```

This example creates an override that denies traffic matching either the IPv4 prefix or geographic selector.

## PARAMETERS

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

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

### -ActionType
The action to apply to matching traffic.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ChangeReference
The change reference resource ID for this resource operation.

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

### -GeoMatch
The geographic matches to apply.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicyGeoMatch[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpPrefix
The IPv4 or IPv6 CIDR prefixes to match.

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

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

Required: False
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
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

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

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicySourcePolicyOverride

## NOTES

## RELATED LINKS

[New-AzDdosCustomPolicyGeoMatch](./New-AzDdosCustomPolicyGeoMatch.md)

[New-AzDdosCustomPolicyMitigationRule](./New-AzDdosCustomPolicyMitigationRule.md)
