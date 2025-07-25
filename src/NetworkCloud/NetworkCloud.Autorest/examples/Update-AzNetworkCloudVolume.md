### Example 1: Update volume
```powershell
Update-AzNetworkCloudVolume -Name volumeName -ResourceGroupName resourceGroupName -SubscriptionId subscriptionId -Tag @{ tag = "newTag" }
```

```output
Location  Name                    SystemDataCreatedAt   SystemDataCreatedBy    SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy
--------       ----                         -------------------                 -------------------                  -----------------------                   ------------------------                 --------
eastus      00654edb-d266  08/02/2023 16:36:04     <identity>                         Application                              08/02/2023 21:35:00           <identity>
```

This command updates the tags of a provided volume.
