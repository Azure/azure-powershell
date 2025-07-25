### Example 1: List NetworkFabrics by Subscription
```powershell
Get-AzNetworkFabric -SubscriptionId $subscriptionId
```

```output
Location    Name                        SystemDataCreatedAt SystemDataCreatedBy      SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy     SystemDataLastModifiedByType
--------    ----                        ------------------- -------------------      ----------------------- ------------------------ ------------------------     ------
eastus2euap pipeline-GA-nf071423        07/14/2023 10:58:25 <identity>               User                    09/05/2023 11:14:10      <identity>                   Appli…
eastus2euap pipeline-GA-nf080323-1      08/03/2023 13:49:42 <identity>               Application             08/03/2023 13:52:24      <identity>                   Appli…
eastus2euap nfa-automation-testing-nf-1 08/07/2023 13:18:40 <identity>               Application             08/07/2023 13:24:41      <identity>                   Appli…
eastus2euap nfa-automation-testing-nf-2 08/07/2023 15:36:56 <identity>               Application             08/07/2023 16:05:20      <identity>                   Appli…
eastus2euap nfa-tool-ts-GA-nf081123     08/11/2023 06:40:50 <identity>               User                    09/05/2023 09:42:59      <identity>                   Appli…
eastus2euap nfa-tool-ts-GA-nf081223     08/12/2023 14:01:45 <identity>               User                    09/20/2023 15:01:05      <identity>                   Appli…
eastus2euap nffab1-4-1-BF               09/24/2023 10:14:30 <identity>               Application             09/25/2023 07:22:46      <identity>                   Appli…
eastus2euap pipeline-nf082823           08/28/2023 07:24:46 <identity>               User                    09/22/2023 06:30:23      <identity>                   Appli…
eastus2euap nffab3-4-1-GF1              09/21/2023 10:38:54 <identity>               Application             09/25/2023 05:30:10      <identity>                   Appli…
eastus      fabricName                  09/21/2023 13:53:03 <identity>               User                    09/25/2023 05:53:50      <identity>                   Appli…
```

This command lists all the NetworkFabrics under the given Subscription.

### Example 2: List NetworkFabrics by Resource Group
```powershell
Get-AzNetworkFabric -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState ControllerId
------------------- ---------- ------------------ ------------
                               Provisioned        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command lists all the NetworkFabrics under the given Resource Group.

### Example 3: Get NetworkFabric
```powershell
Get-AzNetworkFabric -Name $name -ResourceGroupName $resourceGroupName
```

```output
AdministrativeState Annotation ConfigurationState ControllerId
------------------- ---------- ------------------ ------------
                               Provisioned        /subscriptions/<identity>/resourceGroups/nfa-tool-ts-powershell-rg092123/providers/Microsoft.ManagedNetworkFabri…
```

This command gets details of the given NetworkFabric.
