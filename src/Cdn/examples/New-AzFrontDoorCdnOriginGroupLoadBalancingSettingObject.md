### Example 1: Create an in-memory object for AzureFrontDoor origin group `LoadBalancingSetting` object
```powershell
New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200  -SampleSize 5 -SuccessfulSamplesRequired 4
```

```output
AdditionalLatencyInMillisecond SampleSize SuccessfulSamplesRequired
------------------------------ ---------- -------------------------
200                            5          4
```

Create an in-memory object for AzureFrontDoor origin group `LoadBalancingSetting` object
