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

