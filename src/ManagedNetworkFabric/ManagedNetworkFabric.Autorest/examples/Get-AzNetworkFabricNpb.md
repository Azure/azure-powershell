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

