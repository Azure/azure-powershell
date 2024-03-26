---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricdevice
schema: 2.0.0
---

# Get-AzNetworkFabricDevice

## SYNOPSIS
Gets the Network Device resource details.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricDevice [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricDevice -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricDevice -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricDevice -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the Network Device resource details.

## EXAMPLES

### Example 1: List Network Devices by Subscription
```powershell
Get-AzNetworkFabricDevice -SubscriptionId $subscriptionId
```

```output
Location    Name                                             SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------    ----                                             ------------------- -------------------        ----------------------- ------------------------ ----------------------
eastus2euap pipeline-GA-nf071423-AggrRack-CE2                07/14/2023 10:58:29 <identity>                 Application             08/02/2023 09:36:37      <identity>
eastus2euap pipeline-GA-nf071423-AggrRack-NPB1               07/14/2023 10:58:29 <identity>                 Application             08/02/2023 09:36:37      <identity>
eastus2euap pipeline-GA-nf071423-AggrRack-MgmtSwitch2        07/14/2023 10:58:29 <identity>                 Application             08/02/2023 09:36:37      <identity>
eastus2euap pipeline-GA-nf071423-AggrRack-TOR17              07/14/2023 10:58:29 <identity>                 Application             08/02/2023 09:36:37      <identity>
eastus2euap pipeline-GA-nf071423-AggrRack-NPB2               07/14/2023 10:58:29 <identity>                 Application             08/02/2023 09:36:37      <identity>
```

This command lists all the Network Devices under the given Subscription.

### Example 2: List Network Devices by Resource Group
```powershell
Get-AzNetworkFabricDevice -ResourceGroupName $resourceGroupName
```

```output
Location Name                            SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType
-------- ----                            ------------------- -------------------        ----------------------- ------------------------ ------------------------   -----
eastus   fabricName-AggrRack-CE1         09/21/2023 13:56:12 <identity>                 Application             09/21/2023 13:56:12      <identity>                 Appl…
eastus   fabricName-AggrRack-TOR18       09/21/2023 13:56:12 <identity>                 Application             09/21/2023 13:56:12      <identity>                 Appl…
eastus   fabricName-AggrRack-CE2         09/21/2023 13:56:12 <identity>                 Application             09/21/2023 13:56:12      <identity>                 Appl…
eastus   fabricName-AggrRack-NPB1        09/21/2023 13:56:12 <identity>                 Application             09/21/2023 13:56:12      <identity>                 Appl…
eastus   fabricName-AggrRack-TOR17       09/21/2023 13:56:12 <identity>                 Application             09/21/2023 13:56:12      <identity>                 Appl…
eastus   fabricName-AggrRack-NPB2        09/21/2023 13:56:12 <identity>                 Application             09/21/2023 13:56:12      <identity>                 Appl…
```

This command lists all the Network Devices under the given Resource Group.

### Example 3: Get Network Device
```powershell
Get-AzNetworkFabricDevice -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState HostName Id
------------------- ---------- ------------------ -------- --
Enabled                        Succeeded          AR-MGMT1 /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNet…
```

This command gets details of the given Network Device.

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
Name of the Network Device.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NetworkDeviceName

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
Parameter Sets: List1, Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INetworkDevice

## NOTES

## RELATED LINKS
