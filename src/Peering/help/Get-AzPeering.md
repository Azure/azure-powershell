---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeering
schema: 2.0.0
---

# Get-AzPeering

## SYNOPSIS
Gets an existing peering with the specified name under the given subscription and resource group.

## SYNTAX

### List1 (Default)
```
Get-AzPeering [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPeering -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPeering -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzPeering -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an existing peering with the specified name under the given subscription and resource group.

## EXAMPLES

### Example 1: List all peerings
```powershell
 Get-AzPeering
```

```output
Name           SkuName             Kind     PeeringLocation ProvisioningState Location
----           -------             ----     --------------- ----------------- --------
DemoComp1      Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
DemoPeering    Premium_Direct_Free Direct   Dallas          Succeeded         South Central US
TestEdgeZone   Premium_Direct_Free Direct   Atlanta         Succeeded         East US 2
MapsIxRs       Premium_Direct_Free Direct   Ashburn         Succeeded         East US
DemoMapsConfig Premium_Direct_Free Direct   Seattle         Succeeded         West US 2
testexchange   Basic_Exchange_Free Exchange Amsterdam       Succeeded         West Europe
TestPeer1      Basic_Direct_Free   Direct   Amsterdam       Succeeded         West Europe
test1          Basic_Direct_Free   Direct   Athens          Succeeded         France Central
```

List all peerings in subscription

### Example 2: Get specific peering by name and resource group
```powershell
Get-AzPeering -Name DemoPeering -ResourceGroupName DemoRG
```

```output
Name        SkuName             Kind   PeeringLocation ProvisioningState Location
----        -------             ----   --------------- ----------------- --------
DemoPeering Premium_Direct_Free Direct Dallas          Succeeded         South Central US
```

Get a specific peering by resource group and name

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
The name of the peering.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: PeeringName

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
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IPeering

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

