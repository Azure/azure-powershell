### Example 1: Create an in-memory object for DeploymentSettings.
```powershell
New-AzSpringAppDeploymentSettingObject -ResourceRequestCpu "1000m" -ResourceRequestMemory "3Gi" -TerminationGracePeriodSecond 30 -LivenessProbeDisableProbe:$false -LivenessProbeInitialDelaySecond 30 -LivenessProbePeriodSecond 10 -LivenessProbeFailureThreshold 3 -LivenessProbeActionType HTTPGetAction -ReadinessProbeDisableProbe:$false -ReadinessProbeInitialDelaySecond 30 -ReadinessProbePeriodSecond 10 -ReadinessProbeFailureThreshold 3 -ReadinessProbeActionType HTTPGetAction
```

```output
AddonConfig                       : {
                                    }
ContainerProbeSettingDisableProbe :
EnvironmentVariable               : {
                                    }
LivenessProbeAction               : {
                                      "type": "HTTPGetAction"
                                    }
LivenessProbeActionType           : HTTPGetAction
LivenessProbeDisableProbe         : False
LivenessProbeFailureThreshold     : 3
LivenessProbeInitialDelaySecond   : 30
LivenessProbePeriodSecond         : 10
LivenessProbeSuccessThreshold     :
LivenessProbeTimeoutSecond        :
ReadinessProbeAction              : {
                                      "type": "HTTPGetAction"
                                    }
ReadinessProbeActionType          : HTTPGetAction
ReadinessProbeDisableProbe        : False
ReadinessProbeFailureThreshold    : 3
ReadinessProbeInitialDelaySecond  : 30
ReadinessProbePeriodSecond        : 10
ReadinessProbeSuccessThreshold    :
ReadinessProbeTimeoutSecond       :
ResourceRequestCpu                : 1000m
ResourceRequestMemory             : 3Gi
StartupProbeAction                : {
                                    }
StartupProbeActionType            :
StartupProbeDisableProbe          : False
StartupProbeFailureThreshold      :
StartupProbeInitialDelaySecond    :
StartupProbePeriodSecond          :
StartupProbeSuccessThreshold      :
StartupProbeTimeoutSecond         :
TerminationGracePeriodSecond      : 30
```

Create an in-memory object for DeploymentSettings.