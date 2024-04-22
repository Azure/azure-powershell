---
external help file: Az.Peering-help.xml
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
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzPeeringRegisteredAsn -Name <String> -PeeringName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPeeringRegisteredAsn -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
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
Parameter Sets: List, Get
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

### -ResourceGroupName
The name of the resource group.

```yaml
Type: System.String
Parameter Sets: List, Get
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
Parameter Sets: List, Get
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

## RELATED LINKS
