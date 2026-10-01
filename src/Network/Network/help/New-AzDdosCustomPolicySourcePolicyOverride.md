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
 [-AcquirePolicyToken] [-ChangeReference <String>] [<CommonParameters>]
```

## DESCRIPTION
Creates an in-memory source policy override. Matching sources are selected by IP prefixes or geographic matches, and the configured action overrides the rule's default mitigation behavior.

## EXAMPLES

### Example 1: Deny traffic from matching prefixes and locations
```powershell
$geo = New-AzDdosCustomPolicyGeoMatch -Continent Europe
$override = New-AzDdosCustomPolicySourcePolicyOverride -ActionType Deny `
    -IpPrefix "203.0.113.0/24" -GeoMatch $geo
```

## PARAMETERS

### -ActionType
Specifies the action for matching sources. Suggested values are Deny and Permit. The service can accept future supported values.

```yaml
Type: System.String
Parameter Sets: (All)
Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -GeoMatch
Specifies geographic source matches created with **New-AzDdosCustomPolicyGeoMatch**.

```yaml
Type: Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicyGeoMatch[]
Parameter Sets: (All)
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IpPrefix
Specifies IPv4 or IPv6 CIDR prefixes. Prefix and geographic entries use OR matching.

```yaml
Type: System.String[]
Parameter Sets: (All)
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AcquirePolicyToken
Acquire an Azure Policy token automatically for this resource operation.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Required: False
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

### CommonParameters
This cmdlet supports the common parameters. For more information, see [about_CommonParameters](https://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicySourcePolicyOverride

## NOTES

## RELATED LINKS

[New-AzDdosCustomPolicyGeoMatch](./New-AzDdosCustomPolicyGeoMatch.md)

[New-AzDdosCustomPolicyMitigationRule](./New-AzDdosCustomPolicyMitigationRule.md)
