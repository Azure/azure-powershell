---
external help file:
Module Name: Az.Peering
online version: https://learn.microsoft.com/powershell/module/az.peering/get-azpeeringconnectionmonitortest
schema: 2.0.0
---

# Get-AzPeeringConnectionMonitorTest

## SYNOPSIS
Gets an existing connection monitor test with the specified name under the given subscription, resource group and peering service.

## SYNTAX

### List (Default)
```
Get-AzPeeringConnectionMonitorTest -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzPeeringConnectionMonitorTest -Name <String> -PeeringServiceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzPeeringConnectionMonitorTest -InputObject <IPeeringIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets an existing connection monitor test with the specified name under the given subscription, resource group and peering service.

## EXAMPLES

### Example 1: Lists all connection monitor tests
```powershell
 Get-AzPeeringConnectionMonitorTest -ResourceGroupName DemoRG -PeeringServiceName DRTest
```

```output
SourceAgent Destination DestinationPort TestFrequency Sucessful ProvisioningState
----------- ----------- --------------- ------------- --------- -----------------
Agent 1     1.1.1.1     80              30            True      Succeeded
Agent 2     8.8.8.8     80              30            True      Succeeded
```

Lists all connection monitor test objects

### Example 2: Get single connection monitor test
```powershell
 Get-AzPeeringConnectionMonitorTest -ResourceGroupName DemoRG -PeeringServiceName DRTest -Name TestName
```

```output
SourceAgent Destination DestinationPort TestFrequency Sucessful ProvisioningState
----------- ----------- --------------- ------------- --------- -----------------
Agent 1     1.1.1.1     80              30            True      Succeeded
```

Gets a single connection monitor test

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
The name of the connection monitor test

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ConnectionMonitorTestName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -PeeringServiceName
The name of the peering service.

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

### Microsoft.Azure.PowerShell.Cmdlets.Peering.Models.Api20221001.IConnectionMonitorTest

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

