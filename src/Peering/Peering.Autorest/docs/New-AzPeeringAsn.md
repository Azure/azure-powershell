---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/new-azpeeringasn
schema: 2.0.0
---

# New-AzPeeringAsn

## SYNOPSIS
Creates a new peer ASN or updates an existing peer ASN with the specified name under the given subscription.

## SYNTAX

```
New-AzPeeringAsn -Name <String> [-SubscriptionId <String>] [-PeerAsn <Int32>]
 [-PeerContactDetail <IContactDetail[]>] [-PeerName <String>] [-DefaultProfile <PSObject>] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates a new peer ASN or updates an existing peer ASN with the specified name under the given subscription.

## EXAMPLES

### Example 1: Create a new peering asn
```powershell
$contactDetail = New-AzPeeringContactDetailObject -Email "abc@xyz.com" -Phone 1234567890 -Role "Noc"
$PeerContactList = ,$contactDetail
New-AzPeeringAsn -Name PsTestAsn -PeerAsn 65001 -PeerContactDetail $PeerContactList -PeerName DemoPeering
```

```output
Name      PeerName    PropertiesPeerAsn ValidationState PeerContactDetail
----      --------    ----------------- --------------- -----------------
PsTestAsn DemoPeering 65001             Pending         {{…
```

Create a new peering asn with the specified properties

## PARAMETERS

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

### -Name
The peer ASN name.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PeerAsnName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeerAsn
The Autonomous System Number (ASN) of the peer.

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

### -PeerContactDetail
The contact details of the peer.
To construct, see NOTES section for PEERCONTACTDETAIL properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IContactDetail[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeerName
The name of the peer.

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

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeerAsn

## NOTES

## RELATED LINKS

