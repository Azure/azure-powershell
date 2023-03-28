---
external help file:
Module Name: Az.ContainerAppsApi
online version: https://learn.microsoft.com/powershell/module/az.containerappsapi/new-azcontainerappsapijob
schema: 2.0.0
---

# New-AzContainerAppsApiJob

## SYNOPSIS
Create or Update a Container Apps Job.

## SYNTAX

```
New-AzContainerAppsApiJob -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-ConfigurationRegistry <IRegistryCredentials[]>]
 [-ConfigurationReplicaRetryLimit <Int32>] [-ConfigurationReplicaTimeout <Int32>]
 [-ConfigurationSecret <ISecret[]>] [-ConfigurationTriggerType <TriggerType>] [-EnvironmentId <String>]
 [-IdentityType <ManagedServiceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-ManualTriggerConfigParallelism <Int32>] [-ManualTriggerConfigReplicaCompletionCount <Int32>]
 [-ScheduleTriggerConfigCronExpression <String>] [-ScheduleTriggerConfigParallelism <Int32>]
 [-ScheduleTriggerConfigReplicaCompletionCount <Int32>] [-Tag <Hashtable>] [-TemplateContainer <IContainer[]>]
 [-TemplateInitContainer <IBaseContainer[]>] [-TemplateVolume <IVolume[]>] [-WorkloadProfileName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create or Update a Container Apps Job.

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

### -ConfigurationRegistry
Collection of private container registry credentials used by a Container apps job
To construct, see NOTES section for CONFIGURATIONREGISTRY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.IRegistryCredentials[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationReplicaRetryLimit
Maximum number of retries before failing the job.

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

### -ConfigurationReplicaTimeout
Maximum number of seconds a replica is allowed to run.

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

### -ConfigurationSecret
Collection of secrets used by a Container Apps Job
To construct, see NOTES section for CONFIGURATIONSECRET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.ISecret[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationTriggerType
Trigger type of the job

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Support.TriggerType
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

### -EnvironmentId
Resource ID of environment.

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Support.ManagedServiceIdentityType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IdentityUserAssignedIdentity
The set of user assigned identities associated with the resource.
The userAssignedIdentities dictionary keys will be ARM resource ids in the form: '/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ManagedIdentity/userAssignedIdentities/{identityName}.
The dictionary values can be empty objects ({}) in requests.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ManualTriggerConfigParallelism
Number of parallel replicas of a job that can run at a given time.

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

### -ManualTriggerConfigReplicaCompletionCount
Minimum number of successful replica completions before overall job completion.

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

### -Name
Name of the Container Apps Job.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: JobName

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
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScheduleTriggerConfigCronExpression
Cron formatted repeating schedule ("* * * * *") of a Cron Job.

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

### -ScheduleTriggerConfigParallelism
Number of parallel replicas of a job that can run at a given time.

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

### -ScheduleTriggerConfigReplicaCompletionCount
Minimum number of successful replica completions before overall job completion.

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

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateContainer
List of container definitions for the Container App.
To construct, see NOTES section for TEMPLATECONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.IContainer[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateInitContainer
List of specialized containers that run before app containers.
To construct, see NOTES section for TEMPLATEINITCONTAINER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.IBaseContainer[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TemplateVolume
List of volume definitions for the Container App.
To construct, see NOTES section for TEMPLATEVOLUME properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.IVolume[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkloadProfileName
Workload profile name to pin for container apps job execution.

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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.IJob

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CONFIGURATIONREGISTRY <IRegistryCredentials[]>`: Collection of private container registry credentials used by a Container apps job
  - `[Identity <String>]`: A Managed Identity to use to authenticate with Azure Container Registry. For user-assigned identities, use the full user-assigned identity Resource ID. For system-assigned identities, use 'system'
  - `[PasswordSecretRef <String>]`: The name of the Secret that contains the registry login password
  - `[Server <String>]`: Container Registry Server
  - `[Username <String>]`: Container Registry Username

`CONFIGURATIONSECRET <ISecret[]>`: Collection of secrets used by a Container Apps Job
  - `[Identity <String>]`: Resource ID of a managed identity to authenticate with Azure Key Vault, or System to use a system-assigned identity.
  - `[KeyVaultUrl <String>]`: Azure Key Vault URL pointing to the secret referenced by the container app.
  - `[Name <String>]`: Secret Name.
  - `[Value <String>]`: Secret Value.

`TEMPLATECONTAINER <IContainer[]>`: List of container definitions for the Container App.
  - `[Arg <String[]>]`: Container start command arguments.
  - `[Command <String[]>]`: Container start command.
  - `[Env <IEnvironmentVar[]>]`: Container environment variables.
    - `[Name <String>]`: Environment variable name.
    - `[SecretRef <String>]`: Name of the Container App secret from which to pull the environment variable value.
    - `[Value <String>]`: Non-secret environment variable value.
  - `[Image <String>]`: Container image tag.
  - `[Name <String>]`: Custom container name.
  - `[ResourceCpu <Double?>]`: Required CPU in cores, e.g. 0.5
  - `[ResourceMemory <String>]`: Required memory, e.g. "250Mb"
  - `[VolumeMount <IVolumeMount[]>]`: Container volume mounts.
    - `[MountPath <String>]`: Path within the container at which the volume should be mounted.Must not contain ':'.
    - `[VolumeName <String>]`: This must match the Name of a Volume.
  - `[Probe <IContainerAppProbe[]>]`: List of probes for the container.
    - `[FailureThreshold <Int32?>]`: Minimum consecutive failures for the probe to be considered failed after having succeeded. Defaults to 3. Minimum value is 1. Maximum value is 10.
    - `[HttpGetHost <String>]`: Host name to connect to, defaults to the pod IP. You probably want to set "Host" in httpHeaders instead.
    - `[HttpGetHttpHeader <IContainerAppProbeHttpGetHttpHeadersItem[]>]`: Custom headers to set in the request. HTTP allows repeated headers.
      - `Name <String>`: The header field name
      - `Value <String>`: The header field value
    - `[HttpGetPath <String>]`: Path to access on the HTTP server.
    - `[HttpGetPort <Int32?>]`: Name or number of the port to access on the container. Number must be in the range 1 to 65535. Name must be an IANA_SVC_NAME.
    - `[HttpGetScheme <Scheme?>]`: Scheme to use for connecting to the host. Defaults to HTTP.
    - `[InitialDelaySecond <Int32?>]`: Number of seconds after the container has started before liveness probes are initiated. Minimum value is 1. Maximum value is 60.
    - `[PeriodSecond <Int32?>]`: How often (in seconds) to perform the probe. Default to 10 seconds. Minimum value is 1. Maximum value is 240.
    - `[SuccessThreshold <Int32?>]`: Minimum consecutive successes for the probe to be considered successful after having failed. Defaults to 1. Must be 1 for liveness and startup. Minimum value is 1. Maximum value is 10.
    - `[TcpSocketHost <String>]`: Optional: Host name to connect to, defaults to the pod IP.
    - `[TcpSocketPort <Int32?>]`: Number or name of the port to access on the container. Number must be in the range 1 to 65535. Name must be an IANA_SVC_NAME.
    - `[TerminationGracePeriodSecond <Int64?>]`: Optional duration in seconds the pod needs to terminate gracefully upon probe failure. The grace period is the duration in seconds after the processes running in the pod are sent a termination signal and the time when the processes are forcibly halted with a kill signal. Set this value longer than the expected cleanup time for your process. If this value is nil, the pod's terminationGracePeriodSeconds will be used. Otherwise, this value overrides the value provided by the pod spec. Value must be non-negative integer. The value zero indicates stop immediately via the kill signal (no opportunity to shut down). This is an alpha field and requires enabling ProbeTerminationGracePeriod feature gate. Maximum value is 3600 seconds (1 hour)
    - `[TimeoutSecond <Int32?>]`: Number of seconds after which the probe times out. Defaults to 1 second. Minimum value is 1. Maximum value is 240.
    - `[Type <Type?>]`: The type of probe.

`TEMPLATEINITCONTAINER <IBaseContainer[]>`: List of specialized containers that run before app containers.
  - `[Arg <String[]>]`: Container start command arguments.
  - `[Command <String[]>]`: Container start command.
  - `[Env <IEnvironmentVar[]>]`: Container environment variables.
    - `[Name <String>]`: Environment variable name.
    - `[SecretRef <String>]`: Name of the Container App secret from which to pull the environment variable value.
    - `[Value <String>]`: Non-secret environment variable value.
  - `[Image <String>]`: Container image tag.
  - `[Name <String>]`: Custom container name.
  - `[ResourceCpu <Double?>]`: Required CPU in cores, e.g. 0.5
  - `[ResourceMemory <String>]`: Required memory, e.g. "250Mb"
  - `[VolumeMount <IVolumeMount[]>]`: Container volume mounts.
    - `[MountPath <String>]`: Path within the container at which the volume should be mounted.Must not contain ':'.
    - `[VolumeName <String>]`: This must match the Name of a Volume.

`TEMPLATEVOLUME <IVolume[]>`: List of volume definitions for the Container App.
  - `[Name <String>]`: Volume name.
  - `[Secret <ISecretVolumeItem[]>]`: List of secrets to be added in volume. If no secrets are provided, all secrets in collection will be added to volume.
    - `[Path <String>]`: Path to project secret to. If no path is provided, path defaults to name of secret listed in secretRef.
    - `[SecretRef <String>]`: Name of the Container App secret from which to pull the secret value.
  - `[StorageName <String>]`: Name of storage resource. No need to provide for EmptyDir and Secret.
  - `[StorageType <StorageType?>]`: Storage type for the volume. If not provided, use EmptyDir.

## RELATED LINKS

