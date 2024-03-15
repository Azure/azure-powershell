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















