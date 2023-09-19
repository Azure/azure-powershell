### Example 1: Update trunked network
```powershell
Update-AzNetworkCloudTrunkedNetwork -Name trunkedNetworkName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId -Tag @{ tag = "newTag" }
```

```output
Location  Name                    SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                         -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      00654edb-d266  08/02/2023 16:36:04     <identity>                         Application                              08/02/2023 21:35:00           <identity>
```

This command updates the tags of a provided trunked network.
