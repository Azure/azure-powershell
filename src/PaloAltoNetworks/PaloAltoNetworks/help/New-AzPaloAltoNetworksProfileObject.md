---
external help file: Az.PaloAltoNetworks-help.xml
Module Name: Az.PaloAltoNetworks
online version: https://learn.microsoft.com/powershell/module/Az.PaloAltoNetworks/new-azpaloaltonetworksprofileobject
schema: 2.0.0
---

# New-AzPaloAltoNetworksProfileObject

## SYNOPSIS
Create an in-memory object for NetworkProfile.

## SYNTAX

```
New-AzPaloAltoNetworksProfileObject -EnableEgressNat <String> -NetworkType <String> -PublicIP <IIPAddress[]>
 [-EgressNatIP <IIPAddress[]>] [-TrustedRange <String[]>] [-VHubAddressSpace <String>]
 [-VHubResourceId <String>] [-VnetAddressSpace <String>]
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

### Example 1: Create an in-memory object for NetworkProfile.
```powershell
$publicIP = New-AzPaloAltoNetworksIPAddressObject -ResourceId /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/publicIPAddresses/azps-network-publicipaddresses

New-AzPaloAltoNetworksProfileObject -EnableEgressNat DISABLED -PublicIP $publicIP -NetworkType VNET -VnetConfigurationIPOfTrustSubnetForUdrAddress 10.1.1.0/24 -VnetConfigurationTrustSubnetResourceId /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network/subnets/default -VnetConfigurationUnTrustSubnetResourceId /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network/subnets/default2 -VnetResourceId /subscriptions/XXXXXXXX-XXXX-XXXX-XXXX-XXXXXXXXXXXX/resourceGroups/azps_test_group_pan/providers/Microsoft.Network/virtualNetworks/azps-network
```

```output
EnableEgressNat NetworkType
--------------- -----------
DISABLED        VNET
```

Create an in-memory object for NetworkProfile.

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
