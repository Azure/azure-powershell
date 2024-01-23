---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricnpb
schema: 2.0.0
---

# Get-AzNetworkFabricNpb

## SYNOPSIS
Retrieves details of this Network Packet Broker.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricNpb [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricNpb -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricNpb -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricNpb -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Retrieves details of this Network Packet Broker.

## EXAMPLES

### Example 1: List Network Packet Brokers by Subscription
```powershell
Get-AzNetworkFabricNpb -SubscriptionId $subscriptionId
```

```output
Location    Name                  SystemDataCreatedAt SystemDataCreatedBy       SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy             SystemDataLastModifiedByType
--------    ----                  ------------------- -------------------       ----------------------- ------------------------ ------------------------             ------------
eastus2euap pipeline-nf082823-npb 08/28/2023 09:49:37 <identity>                Application             08/28/2023 09:49:37      <identity> Application
eastus2euap nffab3-4-1-gf1-npb    09/21/2023 10:50:01 <identity>                Application             09/21/2023 10:50:01      <identity> Application
eastus2euap nffab1-4-1-bf-npb     09/24/2023 10:18:00 <identity>                Application             09/25/2023 03:08:33      <identity> Application
eastus      fabricname-npb        09/22/2023 06:54:04 <identity>                Application             09/25/2023 06:12:21      <identity> Application
```

This command lists all the Network Packet Brokers under the given Subscription.

### Example 2: List Network Packet Brokers by Resource Group
```powershell
Get-AzNetworkFabricNpb -ResourceGroupName $resourceGroupName
```

```output
Id                                                                                                                                                    Location Name
--                                                                                                                                                    -------- ----
/subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/microsoft.managednetworkfabric/networkpacketbrokers/fabricname-npb eastus   fab…
```

This command lists all the Network Packet Brokers under the given Resource Group.

### Example 3: Get Network Packet Brokers
```powershell
Get-AzNetworkFabricNpb -Name $name -ResourceGroupName $resourceGroupName
```

```output
Id                                                                                                                                                    Location Name
--                                                                                                                                                    -------- ----
/subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/microsoft.managednetworkfabric/networkpacketbrokers/fabricname-npb eastus   fab…
```

This command gets details of the given Network Packet Brokers.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the Network Packet Broker.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NetworkPacketBrokerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

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
The ID of the target subscription.
The value must be an UUID.

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IManagedNetworkFabricIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkPacketBroker

## NOTES

## RELATED LINKS

