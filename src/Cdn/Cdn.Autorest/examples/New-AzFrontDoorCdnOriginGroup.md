### Example 1: Create an AzureFrontDoor origin group under the AzureFrontDoor profile
```powershell
$healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" -ProbeProtocol "Https" -ProbeRequestType "GET"
$loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200  -SampleSize 5 -SuccessfulSamplesRequired 4
New-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```

Create an AzureFrontDoor origin group under the AzureFrontDoor profile