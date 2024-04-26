---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringasn
schema: 2.0.0
---

# Get-AzPeeringAsn

## SYNOPSIS
Gets the peer ASN with the specified name under the given subscription.

## SYNTAX

### List (Default)
```
Get-AzPeeringAsn [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPeeringAsn -Name <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPeeringAsn -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets the peer ASN with the specified name under the given subscription.

## EXAMPLES

### Example 1: List PeerAsns
```powershell
Get-AzPeeringAsn
```

```output
Name            PeerName PropertiesPeerAsn ValidationState PeerContactDetail
----            -------- ----------------- --------------- -----------------
ContosoEdgeTest Contoso  65000             Approved        {{…}}

```

List all the peer asns under subscription

### Example 2: Get Specific PeerAsn
```powershell
Get-AzPeeringAsn -Name ContosoEdgeTest
```

```output
Name            PeerName PropertiesPeerAsn ValidationState PeerContactDetail
----            -------- ----------------- --------------- -----------------
ContosoEdgeTest Contoso  65000             Approved        {{…}}
```

Get peer asn by name

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The peer ASN name.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PeerAsnName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The Azure subscription ID.

```yaml
Type: System.String[]
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.IPeeringIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeerAsn

## NOTES

## RELATED LINKS

