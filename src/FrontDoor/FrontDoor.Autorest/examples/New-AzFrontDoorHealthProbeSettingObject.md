### Example 1
```powershell
New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1"
```

```output
Path              : /
Protocol          : Http
IntervalInSeconds : 30
ResourceState     :
HealthProbeMethod : Head
EnabledState      : Enabled
Id                :
Name              : healthProbeSetting1
Type              :
```

Note: HealthProbeMethod setting is not case sensitive.

Create a HealthProbeSetting object for Front Door creation