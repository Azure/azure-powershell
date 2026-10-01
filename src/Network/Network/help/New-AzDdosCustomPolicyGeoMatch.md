---
external help file: Microsoft.Azure.PowerShell.Cmdlets.Network.dll-Help.xml
Module Name: Az.Network
online version: https://learn.microsoft.com/powershell/module/az.network/new-azddoscustompolicygeomatch
schema: 2.0.0
---

# New-AzDdosCustomPolicyGeoMatch

## SYNOPSIS
Creates a geographic source match for a DDoS custom policy mitigation rule.

## SYNTAX

```
New-AzDdosCustomPolicyGeoMatch [-Continent <String>] [-CountryCode <String>]
 [-DefaultProfile <IAzureContextContainer>] [-AcquirePolicyToken] [-ChangeReference <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Creates an in-memory geographic match used by **New-AzDdosCustomPolicySourcePolicyOverride**. Specify a continent, an uppercase two-letter country code, or both. Azure validates the country-to-continent relationship when both values are supplied.

## EXAMPLES

### Example 1: Match a country within a continent
```powershell
$geoMatch = New-AzDdosCustomPolicyGeoMatch -Continent Europe -CountryCode DE
```

## PARAMETERS

### -Continent
Specifies the continent to match. Suggested values include Africa, Antarctica, Asia, Europe, NorthAmerica, Oceania, and SouthAmerica. The service can accept future supported values.

```yaml
Type: System.String
Parameter Sets: (All)
Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CountryCode
Specifies an uppercase two-letter ISO 3166-1 alpha-2 country or territory code.

```yaml
Type: System.String
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

### Microsoft.Azure.Commands.Network.Models.PSDdosCustomPolicyGeoMatch

## NOTES

## RELATED LINKS

[New-AzDdosCustomPolicySourcePolicyOverride](./New-AzDdosCustomPolicySourcePolicyOverride.md)
