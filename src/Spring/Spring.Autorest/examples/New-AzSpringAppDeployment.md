### Example 1: {{ Add title here }}
```powershell
$settingObj = New-AzSpringAppDeploymentSettingObject -ResourceRequestCpu "1000m" -ResourceRequestMemory "3Gi" -TerminationGracePeriodSecond 30 -LivenessProbeDisableProbe:$false -LivenessProbeInitialDelaySecond 30 -LivenessProbePeriodSecond 10 -LivenessProbeFailureThreshold 3 -LivenessProbeActionType HTTPGetAction -ReadinessProbeDisableProbe:$false -ReadinessProbeInitialDelaySecond 30 -ReadinessProbePeriodSecond 10 -ReadinessProbeFailureThreshold 3 -ReadinessProbeActionType HTTPGetAction 
$source = New-AzSpringAppDeploymentSourceUploadedObject -ArtifactSelector sub-module-1 -RuntimeVersion 1.0 -RelativePath "resources/a172cedcae47474b615c54d510a5d84a8dea3032e958587430b413538be3f333-2019082605-e3095339-1723-44b7-8b5e-31b1003978bc" -Version 1.0
New-AzSpringAppDeployment -ResourceGroupName azps_test_group_spring -ServiceName azps-spring-01 -AppName tools -Name azps-appdeployment -Source $source -DeploymentSetting $settingObj -SkuName "S0" -SkuTier "Standard" -SkuCapacity 1
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here (remove the output block if the example doesn't have an output) }}
```

{{ Add description here }}

