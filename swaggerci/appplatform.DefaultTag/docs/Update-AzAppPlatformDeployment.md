---
external help file:
Module Name: Az.AppPlatform
online version: https://learn.microsoft.com/powershell/module/az.appplatform/update-azappplatformdeployment
schema: 2.0.0
---

# Update-AzAppPlatformDeployment

## SYNOPSIS
Operation to update an exiting Deployment.

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzAppPlatformDeployment -AppName <String> -Name <String> -ResourceGroupName <String>
 -ServiceName <String> [-SubscriptionId <String>] [-Active] [-DeploymentSetting <IDeploymentSettings>]
 [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>] [-SourceType <String>]
 [-SourceVersion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzAppPlatformDeployment -InputObject <IAppPlatformIdentity> [-Active]
 [-DeploymentSetting <IDeploymentSettings>] [-SkuCapacity <Int32>] [-SkuName <String>] [-SkuTier <String>]
 [-SourceType <String>] [-SourceVersion <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Operation to update an exiting Deployment.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Active
Indicates whether the Deployment is active

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AppName
The name of the App resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DeploymentSetting
Deployment settings of the Deployment
To construct, see NOTES section for DEPLOYMENTSETTING properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.Api20230301Preview.IDeploymentSettings
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.IAppPlatformIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the Deployment resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: DeploymentName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group that contains the resource.
You can obtain this value from the Azure Resource Manager API or the portal.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The name of the Service resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SkuCapacity
Current capacity of the target resource

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

### -SkuName
Name of the Sku

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

### -SkuTier
Tier of the Sku

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

### -SourceType
Type of the source uploaded

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

### -SourceVersion
Version of the source

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

### -SubscriptionId
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.IAppPlatformIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.AppPlatform.Models.Api20230301Preview.IDeploymentResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`DEPLOYMENTSETTING <IDeploymentSettings>`: Deployment settings of the Deployment
  - `[AddonConfig <IDeploymentSettingsAddonConfigs>]`: Collection of addons
    - `[(Any) <Object>]`: This indicates any property can be added to this object.
  - `[ContainerProbeSettingDisableProbe <Boolean?>]`: Indicates whether disable the liveness and readiness probe
  - `[EnvironmentVariable <IDeploymentSettingsEnvironmentVariables>]`: Collection of environment variables
    - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[LivenessProbeActionType <ProbeActionType?>]`: The type of the action to take to perform the health check.
  - `[LivenessProbeDisableProbe <Boolean?>]`: Indicate whether the probe is disabled.
  - `[LivenessProbeFailureThreshold <Int32?>]`: Minimum consecutive failures for the probe to be considered failed after having succeeded. Minimum value is 1.
  - `[LivenessProbeInitialDelaySecond <Int32?>]`: Number of seconds after the App Instance has started before probes are initiated. More info: https://kubernetes.io/docs/concepts/workloads/pods/pod-lifecycle#container-probes
  - `[LivenessProbePeriodSecond <Int32?>]`: How often (in seconds) to perform the probe. Minimum value is 1.
  - `[LivenessProbeSuccessThreshold <Int32?>]`: Minimum consecutive successes for the probe to be considered successful after having failed. Must be 1 for liveness and startup. Minimum value is 1.
  - `[LivenessProbeTimeoutSecond <Int32?>]`: Number of seconds after which the probe times out. Minimum value is 1.
  - `[ReadinessProbeActionType <ProbeActionType?>]`: The type of the action to take to perform the health check.
  - `[ReadinessProbeDisableProbe <Boolean?>]`: Indicate whether the probe is disabled.
  - `[ReadinessProbeFailureThreshold <Int32?>]`: Minimum consecutive failures for the probe to be considered failed after having succeeded. Minimum value is 1.
  - `[ReadinessProbeInitialDelaySecond <Int32?>]`: Number of seconds after the App Instance has started before probes are initiated. More info: https://kubernetes.io/docs/concepts/workloads/pods/pod-lifecycle#container-probes
  - `[ReadinessProbePeriodSecond <Int32?>]`: How often (in seconds) to perform the probe. Minimum value is 1.
  - `[ReadinessProbeSuccessThreshold <Int32?>]`: Minimum consecutive successes for the probe to be considered successful after having failed. Must be 1 for liveness and startup. Minimum value is 1.
  - `[ReadinessProbeTimeoutSecond <Int32?>]`: Number of seconds after which the probe times out. Minimum value is 1.
  - `[ResourceRequestCpu <String>]`: Required CPU. 1 core can be represented by 1 or 1000m. This should be 500m or 1 for Basic tier, and {500m, 1, 2, 3, 4} for Standard tier.
  - `[ResourceRequestMemory <String>]`: Required memory. 1 GB can be represented by 1Gi or 1024Mi. This should be {512Mi, 1Gi, 2Gi} for Basic tier, and {512Mi, 1Gi, 2Gi, ..., 8Gi} for Standard tier.
  - `[ScaleMaxReplica <Int32?>]`: Optional. Maximum number of container replicas. Defaults to 10 if not set.
  - `[ScaleMinReplica <Int32?>]`: Optional. Minimum number of container replicas.
  - `[ScaleRule <IScaleRule[]>]`: Scaling rules.
    - `[AzureQueueAuth <IScaleRuleAuth[]>]`: Authentication secrets for the queue scale rule.
      - `[SecretRef <String>]`: Name of the Azure Spring Apps App Instance secret from which to pull the auth params.
      - `[TriggerParameter <String>]`: Trigger Parameter that uses the secret
    - `[AzureQueueLength <Int32?>]`: Queue length.
    - `[AzureQueueName <String>]`: Queue name.
    - `[CustomAuth <IScaleRuleAuth[]>]`: Authentication secrets for the custom scale rule.
    - `[CustomMetadata <ICustomScaleRuleMetadata>]`: Metadata properties to describe custom scale rule.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[CustomType <String>]`: Type of the custom scale rule         eg: azure-servicebus, redis etc.
    - `[HttpAuth <IScaleRuleAuth[]>]`: Authentication secrets for the custom scale rule.
    - `[HttpMetadata <IHttpScaleRuleMetadata>]`: Metadata properties to describe http scale rule.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
    - `[Name <String>]`: Scale Rule Name
    - `[TcpAuth <IScaleRuleAuth[]>]`: Authentication secrets for the tcp scale rule.
    - `[TcpMetadata <ITcpScaleRuleMetadata>]`: Metadata properties to describe tcp scale rule.
      - `[(Any) <String>]`: This indicates any property can be added to this object.
  - `[StartupProbeActionType <ProbeActionType?>]`: The type of the action to take to perform the health check.
  - `[StartupProbeDisableProbe <Boolean?>]`: Indicate whether the probe is disabled.
  - `[StartupProbeFailureThreshold <Int32?>]`: Minimum consecutive failures for the probe to be considered failed after having succeeded. Minimum value is 1.
  - `[StartupProbeInitialDelaySecond <Int32?>]`: Number of seconds after the App Instance has started before probes are initiated. More info: https://kubernetes.io/docs/concepts/workloads/pods/pod-lifecycle#container-probes
  - `[StartupProbePeriodSecond <Int32?>]`: How often (in seconds) to perform the probe. Minimum value is 1.
  - `[StartupProbeSuccessThreshold <Int32?>]`: Minimum consecutive successes for the probe to be considered successful after having failed. Must be 1 for liveness and startup. Minimum value is 1.
  - `[StartupProbeTimeoutSecond <Int32?>]`: Number of seconds after which the probe times out. Minimum value is 1.
  - `[TerminationGracePeriodSecond <Int32?>]`: Optional duration in seconds the App Instance needs to terminate gracefully. May be decreased in delete request. Value must be non-negative integer. The value zero indicates stop immediately via the kill signal (no opportunity to shut down). If this value is nil, the default grace period will be used instead. The grace period is the duration in seconds after the processes running in the App Instance are sent a termination signal and the time when the processes are forcibly halted with a kill signal. Set this value longer than the expected cleanup time for your process. Defaults to 90 seconds.

`INPUTOBJECT <IAppPlatformIdentity>`: Identity Parameter
  - `[AgentPoolName <String>]`: The name of the build service agent pool resource.
  - `[ApiPortalName <String>]`: The name of API portal.
  - `[AppName <String>]`: The name of the App resource.
  - `[ApplicationAcceleratorName <String>]`: The name of the application accelerator.
  - `[ApplicationLiveViewName <String>]`: The name of Application Live View.
  - `[BindingName <String>]`: The name of the Binding resource.
  - `[BuildName <String>]`: The name of the build resource.
  - `[BuildResultName <String>]`: The name of the build result resource.
  - `[BuildServiceName <String>]`: The name of the build service resource.
  - `[BuilderName <String>]`: The name of the builder resource.
  - `[BuildpackBindingName <String>]`: The name of the Buildpack Binding Name
  - `[BuildpackName <String>]`: The name of the buildpack resource.
  - `[CertificateName <String>]`: The name of the certificate resource.
  - `[ConfigurationServiceName <String>]`: The name of Application Configuration Service.
  - `[ContainerRegistryName <String>]`: The name of the container registry.
  - `[CustomizedAcceleratorName <String>]`: The name of the customized accelerator.
  - `[DeploymentName <String>]`: The name of the Deployment resource.
  - `[DevToolPortalName <String>]`: The name of Dev Tool Portal.
  - `[DomainName <String>]`: The name of the custom domain resource.
  - `[GatewayName <String>]`: The name of Spring Cloud Gateway.
  - `[Id <String>]`: Resource identity path
  - `[Location <String>]`: the region
  - `[PredefinedAcceleratorName <String>]`: The name of the predefined accelerator.
  - `[ResourceGroupName <String>]`: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  - `[RouteConfigName <String>]`: The name of the Spring Cloud Gateway route config.
  - `[ServiceName <String>]`: The name of the Service resource.
  - `[ServiceRegistryName <String>]`: The name of Service Registry.
  - `[StackName <String>]`: The name of the stack resource.
  - `[StorageName <String>]`: The name of the storage resource.
  - `[SubscriptionId <String>]`: Gets subscription ID which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.

## RELATED LINKS

