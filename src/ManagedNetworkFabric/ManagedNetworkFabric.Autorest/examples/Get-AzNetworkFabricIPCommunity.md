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

