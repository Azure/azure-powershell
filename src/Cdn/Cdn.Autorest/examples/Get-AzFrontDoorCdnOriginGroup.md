### Example 1: List AzureFrontDoor origin groups under the profile
```powershell
Get-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
org002 testps-rg-da16jm
```

List AzureFrontDoor origin groups under the profile



### Example 2: Get an AzureFrontDoor origin group under the profile
```powershell
Get-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```
Get an AzureFrontDoor origin group under the profile


### Example 3: Get an AzureFrontDoor origin group under the profile via identity
```powershell
$healthProbeSetting = New-AzFrontDoorCdnOriginGroupHealthProbeSettingObject -ProbeIntervalInSecond 1 -ProbePath "/" -ProbeProtocol "Https" -ProbeRequestType "GET"
$loadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200  -SampleSize 5 -SuccessfulSamplesRequired 4
New-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -LoadBalancingSetting $loadBalancingSetting -HealthProbeSetting $healthProbeSetting | Get-AzFrontDoorCdnOriginGroup
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```
Get an AzureFrontDoor origin group under the profile via identity