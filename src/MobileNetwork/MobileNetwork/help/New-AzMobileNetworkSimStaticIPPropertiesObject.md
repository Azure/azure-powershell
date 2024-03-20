---
external help file: Az.MobileNetwork-help.xml
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.MobileNetwork/new-AzMobileNetworkSimStaticIPPropertiesObject
schema: 2.0.0
---

# New-AzMobileNetworkSimStaticIPPropertiesObject

## SYNOPSIS
Create an in-memory object for SimStaticIPProperties.

## SYNTAX

```
New-AzMobileNetworkSimStaticIPPropertiesObject [-AttachedDataNetworkId <String>] [-SliceId <String>]
 [-StaticIPIpv4Address <String>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SimStaticIPProperties.

## EXAMPLES

### Example 1: Create an in-memory object for SimStaticIPProperties.
```powershell
New-AzMobileNetworkSimStaticIPPropertiesObject -StaticIPIpv4Address 10.0.0.20
```

```output
AttachedDataNetworkId SlouseId StaticIPIpv4Address
--------------------- -------- -------------------
                               10.0.0.20
```

Create an in-memory object for SimStaticIPProperties.

## PARAMETERS

### -AttachedDataNetworkId
Attached data network resource ID.

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

### -SliceId
Slice resource ID.

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

### -StaticIPIpv4Address
The IPv4 address assigned to the SIM at this network scope.
This address must be in the userEquipmentStaticAddressPoolPrefix defined in the attached data network.

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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.SimStaticIPProperties

## NOTES

## RELATED LINKS
