### Example 1: Get runtime view of a standby container group pool
```powershell
Get-AzStandbyContainerGroupPoolStatus `
-SubscriptionId f8da6e30-a9d8-48ab-b05c-3f7fe482e13b `
-Name testPool `
-ResourceGroupName test-standbypool
```

```output
ForecastValueInstancesRequestedCount :
Id                           : /subscriptions/f8da6e30-a9d8-48ab-b05c-3f7fe482e13b/resourceGroups/test-standbypool/providers/Microsoft.Standb
                               yPool/standbyContainerGroupPools/testPool/runtimeViews/latest
InstanceCountSummary         : {{
                                  "zone": 1,
                                    "instanceCountsByState": [
                                    {
                                      "state": "Running",
                                      "count": 0
                                    },
                                    {
                                      "state": "Deleting",
                                      "count": 1
                                    },
                                    {
                                      "state": "Creating",
                                      "count": 0
                                    }
                                  ]
                                }}   
Name                         : latest
PredictionForecastInfo       :
PredictionForecastStartTime  :
ProvisioningState            : Succeeded
ResourceGroupName            : test-standbypool
StatusCode                   : HealthState/degraded
StatusMessage                :  
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : Microsoft.StandbyPool/standbyContainerGroupPools/runtimeViews
```

Above command is getting a runtime veiw of standby container group pool.