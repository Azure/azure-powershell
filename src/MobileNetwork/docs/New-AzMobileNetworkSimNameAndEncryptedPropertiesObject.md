---
external help file:
Module Name: Az.MobileNetwork
online version: https://learn.microsoft.com/powershell/module/az.MobileNetwork/new-AzMobileNetworkSimNameAndEncryptedPropertiesObject
schema: 2.0.0
---

# New-AzMobileNetworkSimNameAndEncryptedPropertiesObject

## SYNOPSIS
Create an in-memory object for SimNameAndEncryptedProperties.

## SYNTAX

```
New-AzMobileNetworkSimNameAndEncryptedPropertiesObject -InternationalMobileSubscriberIdentity <String>
 -Name <String> [-DeviceType <String>] [-EncryptedCredentials <String>]
 [-IntegratedCircuitCardIdentifier <String>] [-SimPolicyId <String>]
 [-StaticIPConfiguration <ISimStaticIPProperties[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SimNameAndEncryptedProperties.

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

### -DeviceType
An optional free-form text field that can be used to record the device type this SIM is associated with, for example 'Video camera'.
The Azure portal allows SIMs to be grouped and filtered based on this value.

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

### -EncryptedCredentials
The encrypted SIM credentials.

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

### -IntegratedCircuitCardIdentifier
The integrated circuit card ID (ICCID) for the SIM.

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

### -InternationalMobileSubscriberIdentity
The international mobile subscriber identity (IMSI) for the SIM.

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

### -Name
The name of the SIM.

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

### -SimPolicyId
SIM policy resource ID.

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

### -StaticIPConfiguration
A list of static IP addresses assigned to this SIM.
Each address is assigned at a defined network scope, made up of {attached data network, slice}.
To construct, see NOTES section for STATICIPCONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.ISimStaticIPProperties[]
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

### Microsoft.Azure.PowerShell.Cmdlets.MobileNetwork.Models.Api20221101.SimNameAndEncryptedProperties

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


STATICIPCONFIGURATION <ISimStaticIPProperties[]>: A list of static IP addresses assigned to this SIM. Each address is assigned at a defined network scope, made up of {attached data network, slice}.
  - `[AttachedDataNetworkId <String>]`: Attached data network resource ID.
  - `[SlouseId <String>]`: Slice resource ID.
  - `[StaticIPIpv4Address <String>]`: The IPv4 address assigned to the SIM at this network scope. This address must be in the userEquipmentStaticAddressPoolPrefix defined in the attached data network.

## RELATED LINKS

