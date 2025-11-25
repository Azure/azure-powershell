### Example 1: Create a PSHealthProbeSetting object for Front Door creation
```powershell
New-AzFrontDoorHealthProbeSettingObject -Name "healthProbeSetting1"
```

```output
EnabledState      : Enabled
HealthProbeMethod : HEAD
Id                :
IntervalInSeconds : 30
Name              : healthProbeSetting1
Path              : /
Protocol          : Http
ResourceState     :
Type              :
```

Note: HealthProbeMethod setting is not case sensitive.

Create a PSHealthProbeSetting object for Front Door creation