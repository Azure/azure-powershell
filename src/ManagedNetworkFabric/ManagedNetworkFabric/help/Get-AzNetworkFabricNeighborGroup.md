---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricneighborgroup
schema: 2.0.0
---

# Get-AzNetworkFabricNeighborGroup

## SYNOPSIS
Gets the Neighbor Group.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricNeighborGroup [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricNeighborGroup -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricNeighborGroup -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricNeighborGroup -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Gets the Neighbor Group.

## EXAMPLES

### Example 1: List Neighbor Groups by Subscription
```powershell
Get-AzNetworkFabricNeighborGroup -SubscriptionId $subscriptionId
```

```output
Location    Name              SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy   SystemDataLastModifiedByType ResourceGroupName
--------    ----              ------------------- -------------------        ----------------------- ------------------------ ------------------------   ---------------------------- -------
eastus2euap neighborgroupName 09/21/2023 10:52:59 <identity>                 User                    09/21/2023 10:52:59      <identity>                 User                         nfa-to…
eastus      NeighborGroupName 09/25/2023 05:33:29 <identity>                 User                    09/25/2023 05:33:29      <identity>                 User                         nfa-to…
```

This command lists all the Neighbor Groups under the given Subscription.

### Example 2: List Neighbor Groups by Resource Group
```powershell
Get-AzNetworkFabricNeighborGroup -ResourceGroupName $resourceGroupName
```

```output
Annotation Destination       Id
---------- -----------       --
                             /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/pr…
```

This command lists all the Neighbor Groups under the given Resource Group.

### Example 3: Get Neighbor Groups
```powershell
Get-AzNetworkFabricNeighborGroup -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation Destination       Id
---------- -----------       --
                             /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/pr…
```

This command gets details of the given Neighbor Groups.

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
Name of the Neighbor Group.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: NeighborGroupName

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.INeighborGroup

## NOTES

## RELATED LINKS
