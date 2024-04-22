---
external help file: Az.Peering-help.xml
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringlegacy
schema: 2.0.0
---

# Get-AzPeeringLegacy

## SYNOPSIS
Lists all of the legacy peerings under the given subscription matching the specified kind and location.

## SYNTAX

```
Get-AzPeeringLegacy [-SubscriptionId <String[]>] -Kind <LegacyPeeringsKind> -PeeringLocation <String>
 [-Asn <Int32>] [-DirectPeeringType <DirectPeeringType>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Lists all of the legacy peerings under the given subscription matching the specified kind and location.

## EXAMPLES

### Example 1: Gets legacy peering object
```powershell
Get-AzPeeringLegacy -Kind Direct -PeeringLocation Seattle
```

```output
Name           SkuName             Kind     PeeringLocation ProvisioningState Location
----           -------             ----     --------------- ----------------- --------
DemoComp1      Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
DemoPeering    Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
TestEdgeZone   Premium_Direct_Free Direct   Atlanta         Succeeded         East US 2
```

Gets legacy peering object

## PARAMETERS

### -Asn
The ASN number associated with a legacy peering.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DirectPeeringType
The direct peering type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.DirectPeeringType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Kind
The kind of the peering.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Support.LegacyPeeringsKind
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringLocation
The location of the peering.

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

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeering

## NOTES

## RELATED LINKS
