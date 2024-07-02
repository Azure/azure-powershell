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

