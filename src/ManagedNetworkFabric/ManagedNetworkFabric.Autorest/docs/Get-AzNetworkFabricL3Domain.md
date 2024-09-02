---
external help file:
Module Name: Az.ManagedNetworkFabric
online version: https://learn.microsoft.com/powershell/module/az.managednetworkfabric/get-aznetworkfabricl3domain
schema: 2.0.0
---

# Get-AzNetworkFabricL3Domain

## SYNOPSIS
Retrieves details of this L3 Isolation Domain.

## SYNTAX

### List1 (Default)
```
Get-AzNetworkFabricL3Domain [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkFabricL3Domain -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkFabricL3Domain -InputObject <IManagedNetworkFabricIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzNetworkFabricL3Domain -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Retrieves details of this L3 Isolation Domain.

## EXAMPLES

### Example 1: List L3 Isolation Domains by Subscription
```powershell
Get-AzNetworkFabricL3Domain -SubscriptionId $subscriptionId
```

```output
Location    Name                                    SystemDataCreatedAt SystemDataCreatedBy            SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------    ----                                    ------------------- -------------------            ----------------------- ------------------------ ------------------------
eastus2euap nfa-tool-ts-GA-cli-l3Domain081423       08/18/2023 13:59:59 <identity>                     User                    08/25/2023 16:34:44      <identity>
eastus2euap pipeline-nf082823-l3domain-v6-2605-2606 09/15/2023 17:52:08 <identity>                     User                    09/15/2023 17:52:13      <identity>
eastus2euap nffab341-l3isd-patch                    09/22/2023 04:56:55 <identity>                     Application             09/22/2023 04:56:55      <identity>
eastus2euap nffab341-l3isd-patch2                   09/22/2023 05:00:15 <identity>                     Application             09/22/2023 05:00:15      <identity>
eastus2euap nffab341-l3isd-patch4                   09/22/2023 07:04:22 <identity>                     User                    09/25/2023 05:30:06      <identity>
eastus      l3DomainName                            09/25/2023 04:29:55 <identity>                     User                    09/25/2023 04:58:52      <identity>
```

This command lists all the L3 Isolation Domains under the given Subscription.

### Example 2: List L3 Isolation Domains by Resource Group
```powershell
Get-AzNetworkFabricL3Domain -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState AggregateRouteConfiguration   Annotation ConfigurationState ConnectedSubnetRoutePolicy
------------------- ---------------------------   ---------- ------------------ --------
Disabled                                                     Succeeded          
```

This command lists all the L3 Isolation Domains under the given Resource Group.

### Example 3: Get L3 Isolation Domain
```powershell
Get-AzNetworkFabricL3Domain -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState AggregateRouteConfiguration   Annotation ConfigurationState ConnectedSubnetRoutePolicy
------------------- ---------------------------   ---------- ------------------ --------
Disabled                                                     Succeeded          
```

This command gets details of the given L3 Isolation Domain.

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
Name of the L3 Isolation Domain.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: L3IsolationDomainName

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

### Microsoft.Azure.PowerShell.Cmdlets.ManagedNetworkFabric.Models.IL3IsolationDomain

## NOTES

## RELATED LINKS

