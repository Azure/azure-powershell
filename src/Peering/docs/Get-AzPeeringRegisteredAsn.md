---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringregisteredasn
schema: 2.0.0
---

# Get-AzPeeringRegisteredAsn

## SYNOPSIS
Gets an existing registered ASN with the specified name under the given subscription, resource group and peering.

## SYNTAX

### List (Default)
```
Get-AzPeeringRegisteredAsn -PeeringName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPeeringRegisteredAsn -Name <String> -PeeringName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPeeringRegisteredAsn -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets an existing registered ASN with the specified name under the given subscription, resource group and peering.

## EXAMPLES

### Example 1: List all registered asns for peering
```powershell
Get-AzPeeringRegisteredAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo
```

```output
Name          Asn   PeeringServicePrefixKey              ProvisioningState
----          ---   -----------------------              -----------------
fgfg          6500  767c9f30-7388-49ef-ba8e-e2d16d1c08e4 Succeeded
homedepottest 65000 32259ee0-ea01-495e-8279-06c24ef7aae0 Succeeded
JonOrmondTest 62540 e3f552c5-909e-434b-8fab-93e524a1aeed Succeeded
```

Lists all registered asn's for a peering

### Example 2: Get specific registered asn for peering
```powershell
Get-AzPeeringRegisteredAsn -PeeringName MapsIxRs -ResourceGroupName MAPSDemo -Name fgfg
```

```output
Name Asn  PeeringServicePrefixKey              ProvisioningState
---- ---  -----------------------              -----------------
fgfg 6500 767c9f30-7388-49ef-ba8e-e2d16d1c08e4 Succeeded
```

Gets a specific registered asn for a peering by name

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
The name of the registered ASN.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: RegisteredAsnName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringName
The name of the peering.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeeringRegisteredAsn

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`INPUTOBJECT <IPeeringIdentity>`: Identity Parameter
  - `[ConnectionMonitorTestName <String>]`: The name of the connection monitor test
  - `[Id <String>]`: Resource identity path
  - `[PeerAsnName <String>]`: The peer ASN name.
  - `[PeeringName <String>]`: The name of the peering.
  - `[PeeringServiceName <String>]`: The name of the peering service.
  - `[PrefixName <String>]`: The name of the prefix.
  - `[RegisteredAsnName <String>]`: The name of the registered ASN.
  - `[RegisteredPrefixName <String>]`: The name of the registered prefix.
  - `[ResourceGroupName <String>]`: The name of the resource group.
  - `[SubscriptionId <String>]`: The Azure subscription ID.

## RELATED LINKS

