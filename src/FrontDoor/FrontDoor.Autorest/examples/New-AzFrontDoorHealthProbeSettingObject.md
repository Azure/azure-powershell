### Example 1: Create a PSHealthProbeSetting object for Front Door creation
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

Create a PSHealthProbeSetting object for Front Door creation