---
external help file: Az.ManagedNetworkFabric-help.xml
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricipcommunity
schema: 2.0.0
---

# Get-AzNetworkFabricIPCommunity

## SYNOPSIS
Implements an IP Community GET method.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricIPCommunity [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricIPCommunity -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricIPCommunity -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricIPCommunity -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Implements an IP Community GET method.

## EXAMPLES

### Example 1: List IpCommunities by Subscription
```powershell
Get-AzNetworkFabricIPCommunity -SubscriptionId $subscriptionId
```

```output
Location    Name                              SystemDataCreatedAt SystemDataCreatedBy            SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------    ----                              ------------------- -------------------            ----------------------- ------------------------ ------------------------
eastus2euap ipcommunityName1                  09/21/2023 07:51:19 <identity>                     User                    09/21/2023 10:41:47      <identity>
eastus2euap ipcommunityName2                  09/21/2023 07:52:49 <identity>                     User                    09/21/2023 10:41:49      <identity>
eastus2euap ipcommunity-nni-v4-egress         09/21/2023 10:42:01 <identity>                     Application             09/21/2023 10:42:14      <identity>
eastus2euap ipcommunity-nni-v6-egress         09/21/2023 10:42:43 <identity>                     Application             09/21/2023 10:43:01      <identity>
eastus2euap ipcommunity-nni-v4-ingress        09/21/2023 10:43:24 <identity>                     Application             09/21/2023 10:43:42      <identity>
eastus2euap ipcommunity-nni-v6-ingress        09/21/2023 10:44:06 <identity>                     Application             09/21/2023 10:44:24      <identity>
eastus2euap ipcommunity-2601-staticsubnet     07/14/2023 14:01:06 <identity>                     Application             09/05/2023 11:17:37      <identity>
eastus      ipcommunityName                   09/21/2023 13:39:13 <identity>                     User                    09/22/2023 07:32:58      <identity>
```

This command lists all the IpCommunities under the given Subscription.

### Example 2: List IpCommunities by Resource Group
```powershell
Get-AzNetworkFabricIPCommunity -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                       Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command lists all the IpCommunities under the given Resource Group.

### Example 3: Get IpCommunity
```powershell
Get-AzNetworkFabricIPCommunity -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                       Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command gets details of the given IpCommunity.

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
Name of the IP Community.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: IPCommunityName

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IIPCommunity

## NOTES

## RELATED LINKS
