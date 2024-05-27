---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/Az.SpringApps/new-azspringappdeploymentsettingobject
schema: 2.0.0
---

# New-AzSpringAppDeploymentSettingObject

## SYNOPSIS
Create an in-memory object for DeploymentSettings.

## SYNTAX

```
New-AzSpringAppDeploymentSettingObject [-AddonConfig <IDeploymentSettingsAddonConfigs>]
 [-Apm <IApmReference[]>] [-ContainerProbeSettingDisableProbe <Boolean>]
 [-EnvironmentVariable <IDeploymentSettingsEnvironmentVariables>] [-LivenessProbeActionType <String>]
 [-LivenessProbeDisableProbe <Boolean>] [-LivenessProbeFailureThreshold <Int32>]
 [-LivenessProbeInitialDelaySecond <Int32>] [-LivenessProbePeriodSecond <Int32>]
 [-LivenessProbeSuccessThreshold <Int32>] [-LivenessProbeTimeoutSecond <Int32>]
 [-ReadinessProbeActionType <String>] [-ReadinessProbeDisableProbe <Boolean>]
 [-ReadinessProbeFailureThreshold <Int32>] [-ReadinessProbeInitialDelaySecond <Int32>]
 [-ReadinessProbePeriodSecond <Int32>] [-ReadinessProbeSuccessThreshold <Int32>]
 [-ReadinessProbeTimeoutSecond <Int32>] [-ResourceRequestCpu <String>] [-ResourceRequestMemory <String>]
 [-StartupProbeActionType <String>] [-StartupProbeDisableProbe <Boolean>]
 [-StartupProbeFailureThreshold <Int32>] [-StartupProbeInitialDelaySecond <Int32>]
 [-StartupProbePeriodSecond <Int32>] [-StartupProbeSuccessThreshold <Int32>]
 [-StartupProbeTimeoutSecond <Int32>] [-TerminationGracePeriodSecond <Int32>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for DeploymentSettings.

## EXAMPLES

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

## PARAMETERS

### -AddonConfig
Collection of addons.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IDeploymentSettingsAddonConfigs
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Apm
Collection of ApmReferences.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IApmReference[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ContainerProbeSettingDisableProbe
Indicates whether disable the liveness and readiness probe.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -EnvironmentVariable
Collection of environment variables.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.IDeploymentSettingsEnvironmentVariables
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LivenessProbeActionType
The type of the action to take to perform the health check.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LivenessProbeDisableProbe
Indicate whether the probe is disabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LivenessProbeFailureThreshold
Minimum consecutive failures for the probe to be considered failed after having succeeded.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LivenessProbeInitialDelaySecond
Number of seconds after the App Instance has started before probes are initiated.
More info: https://kubernetes.io/docs/concepts/workloads/pods/pod-lifecycle#container-probes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LivenessProbePeriodSecond
How often (in seconds) to perform the probe.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LivenessProbeSuccessThreshold
Minimum consecutive successes for the probe to be considered successful after having failed.
Must be 1 for liveness and startup.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LivenessProbeTimeoutSecond
Number of seconds after which the probe times out.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadinessProbeActionType
The type of the action to take to perform the health check.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadinessProbeDisableProbe
Indicate whether the probe is disabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadinessProbeFailureThreshold
Minimum consecutive failures for the probe to be considered failed after having succeeded.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadinessProbeInitialDelaySecond
Number of seconds after the App Instance has started before probes are initiated.
More info: https://kubernetes.io/docs/concepts/workloads/pods/pod-lifecycle#container-probes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadinessProbePeriodSecond
How often (in seconds) to perform the probe.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadinessProbeSuccessThreshold
Minimum consecutive successes for the probe to be considered successful after having failed.
Must be 1 for liveness and startup.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadinessProbeTimeoutSecond
Number of seconds after which the probe times out.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceRequestCpu
Required CPU.
1 core can be represented by 1 or 1000m.
This should be 500m or 1 for Basic tier, and {500m, 1, 2, 3, 4} for Standard tier.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceRequestMemory
Required memory.
1 GB can be represented by 1Gi or 1024Mi.
This should be {512Mi, 1Gi, 2Gi} for Basic tier, and {512Mi, 1Gi, 2Gi, ..., 8Gi} for Standard tier.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartupProbeActionType
The type of the action to take to perform the health check.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartupProbeDisableProbe
Indicate whether the probe is disabled.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartupProbeFailureThreshold
Minimum consecutive failures for the probe to be considered failed after having succeeded.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartupProbeInitialDelaySecond
Number of seconds after the App Instance has started before probes are initiated.
More info: https://kubernetes.io/docs/concepts/workloads/pods/pod-lifecycle#container-probes.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartupProbePeriodSecond
How often (in seconds) to perform the probe.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartupProbeSuccessThreshold
Minimum consecutive successes for the probe to be considered successful after having failed.
Must be 1 for liveness and startup.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -StartupProbeTimeoutSecond
Number of seconds after which the probe times out.
Minimum value is 1.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TerminationGracePeriodSecond
Optional duration in seconds the App Instance needs to terminate gracefully.
May be decreased in delete request.
Value must be non-negative integer.
The value zero indicates stop immediately via the kill signal (no opportunity to shut down).
If this value is nil, the default grace period will be used instead.
The grace period is the duration in seconds after the processes running in the App Instance are sent a termination signal and the time when the processes are forcibly halted with a kill signal.
Set this value longer than the expected cleanup time for your process.
Defaults to 90 seconds.

```yaml
Type: System.Int32
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.DeploymentSettings

## NOTES

## RELATED LINKS

