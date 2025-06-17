### Example 1: List IpPrefixes by Subscription
```powershell
Get-AzNetworkFabricIPPrefix -SubscriptionId $subscriptionId
```

```output
Location    Name                          SystemDataCreatedAt SystemDataCreatedBy         SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy    SystemDataLastModifiedByType
--------    ----                          ------------------- -------------------         ----------------------- ------------------------ ------------------------    ----
eastus2euap ipprefixName1                 09/21/2023 07:48:48 <identity>                  User                    09/21/2023 10:41:48      <identity>                  App…
eastus2euap ipprefixName2                 09/21/2023 07:49:54 <identity>                  User                    09/21/2023 10:41:49      <identity>                  App…
eastus2euap ipprefix-v4-egress            09/21/2023 10:41:49 <identity>                  Application             09/21/2023 10:42:14      <identity>                  App…
eastus2euap ipprefix-v6-egress            09/21/2023 10:42:31 <identity>                  Application             09/22/2023 07:00:56      <identity>                  User
eastus2euap ipprefix-v4-ingress           09/21/2023 10:43:12 <identity>                  Application             09/22/2023 06:28:13      <identity>                  User
eastus2euap ipprefix-v6-ingress           09/21/2023 10:43:54 <identity>                  Application             09/21/2023 10:44:24      <identity>                  App…
eastus      ipprefixName                  09/21/2023 13:37:56 <identity>                  User                    09/22/2023 07:32:58      <identity>                  App…
eastus      ipPrefix092523                09/25/2023 07:36:13 <identity>                  User                    09/25/2023 07:36:13      <identity>                  User
```

This command lists all the IpPrefixes under the given Subscription.

### Example 2: List IpPrefixes by Resource Group
```powershell
Get-AzNetworkFabricIPPrefix -ResourceGroupName $resourceGroupName
```

```output
Location Name           SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy    SystemDataLastModifiedByType ResourceGroupName
-------- ----           ------------------- -------------------        ----------------------- ------------------------ ------------------------    ---------------------------- ---
eastus   ipprefixName   09/21/2023 13:37:56 <identity>                 User                    09/22/2023 07:32:58      <identity>                  Application                  nf…
eastus   ipPrefix092523 09/25/2023 07:36:13 <identity>                 User                    09/25/2023 07:36:13      <identity>                  User                         nf…
```

This command lists all the IpPrefixes under the given Resource Group.

### Example 3: Get IpPrefix
```powershell
Get-AzNetworkFabricIPPrefix -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState Id
------------------- ---------- ------------------ --
Disabled                       Succeeded          /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command gets details of the given IpPrefix.

