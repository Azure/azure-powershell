### Example 1: Update an AzureFrontDoor origin group under the profile
```powershell
$updateLoadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 -SampleSize 5 -SuccessfulSamplesRequired 3
Update-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 -LoadBalancingSetting $updateLoadBalancingSetting
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```

Update an AzureFrontDoor origin group under the profile


### Example 2: Update an AzureFrontDoor origin group under the profile via identity
```powershell
$updateLoadBalancingSetting = New-AzFrontDoorCdnOriginGroupLoadBalancingSettingObject -AdditionalLatencyInMillisecond 200 -SampleSize 5 -SuccessfulSamplesRequired 3
Get-AzFrontDoorCdnOriginGroup -ResourceGroupName testps-rg-da16jm -ProfileName fdp-v542q6 -OriginGroupName org001 | Update-AzFrontDoorCdnOriginGroup -LoadBalancingSetting $updateLoadBalancingSetting
```

```output
Name   ResourceGroupName
----   -----------------
org001 testps-rg-da16jm
```

Update an AzureFrontDoor origin group under the profile via identity

