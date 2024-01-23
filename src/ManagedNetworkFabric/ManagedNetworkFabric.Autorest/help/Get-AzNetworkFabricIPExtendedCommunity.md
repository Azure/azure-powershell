---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricipextendedcommunity
schema: 2.0.0
---

# Get-AzNetworkFabricIPExtendedCommunity

## SYNOPSIS
Implements IP Extended Community GET method.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricIPExtendedCommunity [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricIPExtendedCommunity -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricIPExtendedCommunity -InputObject <IManagedNetworkFabricIdentity>
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricIPExtendedCommunity -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Implements IP Extended Community GET method.

## EXAMPLES

### Example 1: List IpExtendedCommunities by Subscription
```powershell
Get-AzNetworkFabricIPExtendedCommunity -SubscriptionId $subscriptionId
```

```output
Location    Name                                     SystemDataCreatedAt SystemDataCreatedBy         SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------    ----                                     ------------------- -------------------         ----------------------- ------------------------ ------------------------
eastus2euap ipextendedcommunityName1                 09/21/2023 07:50:26 <identity>                  User                    09/21/2023 10:41:47      <identity>
eastus2euap ipextendedcommunityName2                 09/21/2023 07:50:51 <identity>                  User                    09/21/2023 10:41:49      <identity>
eastus2euap ipextcommunity-2601-cn1                  07/14/2023 14:05:06 <identity>                  Application             09/05/2023 11:17:39      <identity>
eastus2euap ipextcommunity-2601-cn2                  07/14/2023 14:05:18 <identity>                  Application             09/05/2023 11:17:39      <identity>
eastus2euap ipextcommunity-2601                      07/14/2023 14:05:30 <identity>                  Application             09/05/2023 11:17:39      <identity>
eastus2euap ipextcommunity-2602-cn1                  07/14/2023 14:08:56 <identity>                  Application             09/05/2023 11:17:39      <identity>
eastus2euap ipextcommunity-2614-ext-imp              09/25/2023 04:02:03 <identity>                  Application             09/25/2023 07:24:10      <identity>
eastus2euap ipextcommunity-2613-ext-exp              09/25/2023 04:02:57 <identity>                  Application             09/25/2023 07:23:47      <identity>
eastus2euap ipextcommunity-2614-ext-exp              09/25/2023 04:03:09 <identity>                  Application             09/25/2023 07:23:47      <identity>
eastus      ipextendedcommunityName                  09/21/2023 13:38:52 <identity>                  User                    09/22/2023 07:32:58      <identity>
```

This command lists all the IpExtendedCommunities under the given Subscription.

### Example 2: List IpExtendedCommunities by Resource Group
```powershell
Get-AzNetworkFabricIPExtendedCommunity -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                       Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command lists all the IpExtendedCommunities under the given Resource Group.

### Example 3: Get IpExtendedCommunity
```powershell
Get-AzNetworkFabricIPExtendedCommunity -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                       Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command gets details of the given IpExtendedCommunity.

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
Name of the IP Extended Community.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: IPExtendedCommunityName

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IIPExtendedCommunity

## NOTES

## RELATED LINKS

