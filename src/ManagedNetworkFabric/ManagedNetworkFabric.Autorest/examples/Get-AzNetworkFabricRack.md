### Example 1: List Network Racks by Subscription
```powershell
Get-AzNetworkFabricRack -SubscriptionId $subscriptionId
```

```output
Location    Name                                  SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------    ----                                  ------------------- -------------------        ----------------------- ------------------------ ------------------------
eastus2euap pipeline-GA-nf071423-aggrack          07/14/2023 10:58:27 <identity>                 Application             08/02/2023 09:36:35      <identity>
eastus2euap pipeline-GA-nf071423-comprack1        07/14/2023 10:58:32 <identity>                 Application             08/02/2023 09:36:38      <identity>
eastus2euap pipeline-GA-nf071423-comprack2        07/14/2023 10:58:36 <identity>                 Application             08/02/2023 09:36:41      <identity>
eastus2euap nfa-automation-testing-nf-1-aggrack   08/07/2023 13:18:41 <identity>                 Application             08/07/2023 13:21:45      <identity>
eastus2euap nfa-automation-testing-nf-1-comprack1 08/07/2023 13:18:44 <identity>                 Application             08/07/2023 13:21:45      <identity>
eastus2euap nfa-automation-testing-nf-1-comprack2 08/07/2023 13:18:47 <identity>                 Application             08/07/2023 13:21:45      <identity>
eastus2euap nfa-automation-testing-nf-2-aggrack   08/07/2023 15:36:58 <identity>                 Application             08/07/2023 15:40:02      <identity>
eastus2euap nfa-automation-testing-nf-2-comprack1 08/07/2023 15:37:00 <identity>                 Application             08/07/2023 15:40:02      <identity>
eastus2euap nfa-automation-testing-nf-2-comprack2 08/07/2023 15:37:03 <identity>                 Application             08/07/2023 15:40:02      <identity>
eastus2euap nfa-tool-ts-GA-nf081123-aggrack       08/11/2023 06:40:52 <identity>                 Application             08/11/2023 07:15:22      <identity>
eastus2euap nfa-tool-ts-GA-nf081123-comprack1     08/11/2023 06:40:57 <identity>                 Application             08/11/2023 07:15:22      <identity>
eastus2euap nfa-tool-ts-GA-nf081123-comprack2     08/11/2023 06:41:00 <identity>                 Application             08/11/2023 07:15:22      <identity>
eastus2euap nfa-tool-ts-GA-nf081223-aggrack       08/12/2023 14:01:54 <identity>                 Application             08/12/2023 14:29:22      <identity>
eastus2euap nfa-tool-ts-GA-nf081223-comprack1     08/12/2023 14:01:58 <identity>                 Application             08/12/2023 14:29:22      <identity>
eastus2euap nfa-tool-ts-GA-nf081223-comprack2     08/12/2023 14:02:02 <identity>                 Application             08/12/2023 14:29:22      <identity>
eastus2euap nffab1-4-1-BF-aggrack                 09/24/2023 10:16:50 <identity>                 Application             09/25/2023 03:08:33      <identity>
eastus2euap nffab1-4-1-BF-comprack1               09/24/2023 10:16:53 <identity>                 Application             09/25/2023 03:08:33      <identity>
eastus2euap nffab1-4-1-BF-comprack2               09/24/2023 10:16:56 <identity>                 Application             09/25/2023 03:08:33      <identity>
eastus2euap pipeline-nf082823-aggrack             08/28/2023 07:25:14 <identity>                 Application             08/28/2023 09:48:51      <identity>
eastus2euap pipeline-nf082823-comprack1           08/28/2023 07:25:18 <identity>                 Application             08/28/2023 09:48:52      <identity>
eastus2euap pipeline-nf082823-comprack2           08/28/2023 07:25:21 <identity>                 Application             08/28/2023 09:48:52      <identity>
eastus2euap nffab3-4-1-GF1-aggrack                09/21/2023 10:40:55 <identity>                 Application             09/21/2023 10:45:16      <identity>
eastus2euap nffab3-4-1-GF1-comprack1              09/21/2023 10:40:57 <identity>                 Application             09/21/2023 10:45:17      <identity>
eastus2euap nffab3-4-1-GF1-comprack2              09/21/2023 10:41:00 <identity>                 Application             09/21/2023 10:45:17      <identity>
eastus      fabricName-aggrack                    09/21/2023 13:56:10 <identity>                 Application             09/22/2023 06:53:42      <identity>
eastus      fabricName-comprack1                  09/21/2023 13:56:13 <identity>                 Application             09/22/2023 06:53:42      <identity>
eastus      fabricName-comprack2                  09/21/2023 13:56:16 <identity>                 Application             09/22/2023 06:53:42      <identity>
```

This command lists all the Network Racks under the given Subscription.

### Example 2: List Network Racks by Resource Group
```powershell
Get-AzNetworkFabricRack -ResourceGroupName $resourceGroupName
```

```output
Location Name                 SystemDataCreatedAt SystemDataCreatedBy        SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy       SystemDataLastModifiedByType
-------- ----                 ------------------- -------------------        ----------------------- ------------------------ ------------------------       ----------------
eastus   fabricName-aggrack   09/21/2023 13:56:10 <identity>                 Application             09/22/2023 06:53:42      <identity>                     Application
eastus   fabricName-comprack1 09/21/2023 13:56:13 <identity>                 Application             09/22/2023 06:53:42      <identity>                     Application
eastus   fabricName-comprack2 09/21/2023 13:56:16 <identity>                 Application             09/22/2023 06:53:42      <identity>                     Application
```

This command lists all the Network Racks under the given Resource Group.

### Example 3: Get Network Rack
```powershell
Get-AzNetworkFabricRack -Name $name -ResourceGroupName $resourceGroupName
```

```output
Annotation Id                                                                                                                                                Location
---------- --                                                                                                                                                ------
           /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabric/networkRacks/fabricName-aggrack eastus
```

This command gets details of the given Network Rack.

