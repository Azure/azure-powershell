---
external help file:
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/Az.PaloAltoNetworks/new-azpaloaltonetworksnetworkprofileobject
schema: 2.0.0
---

# New-AzPaloAltoNetworksNetworkProfileObject

## SYNOPSIS
Create an in-memory object for NetworkProfile.

## SYNTAX

```
New-AzPaloAltoNetworksNetworkProfileObject -EnableEgressNat <String> -NetworkType <String>
 -PublicIP <IIPAddress[]> [-EgressNatIP <IIPAddress[]>] [-TrustedRange <String[]>]
 [-VHubAddressSpace <String>] [-VHubResourceId <String>] [-VnetAddressSpace <String>]
 [-VnetConfigurationIPOfTrustSubnetForUdrAddress <String>]
 [-VnetConfigurationIPOfTrustSubnetForUdrResourceId <String>]
 [-VnetConfigurationTrustSubnetAddressSpace <String>] [-VnetConfigurationTrustSubnetResourceId <String>]
 [-VnetConfigurationUnTrustSubnetAddressSpace <String>] [-VnetConfigurationUnTrustSubnetResourceId <String>]
 [-VnetResourceId <String>] [-VwanConfigurationIPOfTrustSubnetForUdrAddress <String>]
 [-VwanConfigurationIPOfTrustSubnetForUdrResourceId <String>]
 [-VwanConfigurationNetworkVirtualApplianceId <String>] [-VwanConfigurationTrustSubnetAddressSpace <String>]
 [-VwanConfigurationTrustSubnetResourceId <String>] [-VwanConfigurationUnTrustSubnetAddressSpace <String>]
 [-VwanConfigurationUnTrustSubnetResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NetworkProfile.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

## PARAMETERS

### -EgressNatIP
Egress nat IP to use.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IIPAddress[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnableEgressNat
Enable egress NAT, enabled by default.

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

### -NetworkType
vnet or vwan, cannot be updated.

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

### -PublicIP
List of IPs associated with the Firewall.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.IIPAddress[]
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TrustedRange
Non-RFC 1918 address.

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

### -VHubAddressSpace
Address Space.

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

### -VHubResourceId
Resource Id.

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

### -VnetAddressSpace
Address Space.

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

### -VnetConfigurationIPOfTrustSubnetForUdrAddress
Address value.

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

### -VnetConfigurationIPOfTrustSubnetForUdrResourceId
Resource Id.

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

### -VnetConfigurationTrustSubnetAddressSpace
Address Space.

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

### -VnetConfigurationTrustSubnetResourceId
Resource Id.

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

### -VnetConfigurationUnTrustSubnetAddressSpace
Address Space.

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

### -VnetConfigurationUnTrustSubnetResourceId
Resource Id.

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

### -VnetResourceId
Resource Id.

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

### -VwanConfigurationIPOfTrustSubnetForUdrAddress
Address value.

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

### -VwanConfigurationIPOfTrustSubnetForUdrResourceId
Resource Id.

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

### -VwanConfigurationNetworkVirtualApplianceId
Network Virtual Appliance resource ID .

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

### -VwanConfigurationTrustSubnetAddressSpace
Address Space.

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

### -VwanConfigurationTrustSubnetResourceId
Resource Id.

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

### -VwanConfigurationUnTrustSubnetAddressSpace
Address Space.

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

### -VwanConfigurationUnTrustSubnetResourceId
Resource Id.

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

### Microsoft.Azure.PowerShell.Cmdlets.PaloAltoNetworks.Models.NetworkProfile

## NOTES

## RELATED LINKS

