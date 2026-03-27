### Example 1
```powershell
New-AzFrontDoorBackendPoolObject -Name "backendpool1" -FrontDoorName $Name -ResourceGroupName $resourceGroupName -Backend $backend1 -HealthProbeSettingsName "healthProbeSetting1" -LoadBalancingSettingsName "loadBalancingSetting1"
```

```output
Backend                :
HealthProbeSettingId   : /subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups//providers/Microsoft.Network/frontDoors//HealthProbeSettings/healthProbeSetting1
Id                     :
LoadBalancingSettingId : /subscriptions/27cafca8-b9a4-4264-b399-45d0c9cca1ab/resourceGroups//providers/Microsoft.Network/frontDoors//LoadBalancingSettings/loadBalancingSetting1
Name                   : backendpool1
ResourceState          :
Type                   :
```

Create a PSBackendPool object for Front Door creation