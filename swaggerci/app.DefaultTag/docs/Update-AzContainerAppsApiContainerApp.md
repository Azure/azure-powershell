---
external help file:
Module Name: Az.ContainerAppsApi
online version: https://learn.microsoft.com/powershell/module/az.containerappsapi/update-azcontainerappsapicontainerapp
schema: 2.0.0
---

# Update-AzContainerAppsApiContainerApp

## SYNOPSIS
Patches a Container App using JSON Merge Patch

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzContainerAppsApiContainerApp -Name <String> -ResourceGroupName <String> -Location <String>
 [-SubscriptionId <String>] [-Configuration <IConfiguration>] [-EnvironmentId <String>]
 [-ExtendedLocationName <String>] [-ExtendedLocationType <ExtendedLocationTypes>]
 [-IdentityType <ManagedServiceIdentityType>] [-IdentityUserAssignedIdentity <Hashtable>]
 [-ManagedBy <String>] [-ManagedEnvironmentId <String>] [-ScaleMaxReplica <Int32>] [-ScaleMinReplica <Int32>]
 [-ScaleRule <IScaleRule[]>] [-Tag <Hashtable>] [-TemplateContainer <IContainer[]>]
 [-TemplateInitContainer <IBaseContainer[]>] [-TemplateRevisionSuffix <String>] [-TemplateVolume <IVolume[]>]
 [-WorkloadProfileName <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf]
 [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzContainerAppsApiContainerApp -InputObject <IContainerAppsApiIdentity> -Location <String>
 [-Configuration <IConfiguration>] [-EnvironmentId <String>] [-ExtendedLocationName <String>]
 [-ExtendedLocationType <ExtendedLocationTypes>] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-ManagedBy <String>] [-ManagedEnvironmentId <String>]
 [-ScaleMaxReplica <Int32>] [-ScaleMinReplica <Int32>] [-ScaleRule <IScaleRule[]>] [-Tag <Hashtable>]
 [-TemplateContainer <IContainer[]>] [-TemplateInitContainer <IBaseContainer[]>]
 [-TemplateRevisionSuffix <String>] [-TemplateVolume <IVolume[]>] [-WorkloadProfileName <String>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patches a Container App using JSON Merge Patch

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

### -Configuration
Non versioned Container App configuration properties.
To construct, see NOTES section for CONFIGURATION properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.IConfiguration
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

### -ExtendedLocationName
The name of the extended location.

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

### -ExtendedLocationType
The type of the extended location.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Support.ExtendedLocationTypes
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.IContainerAppsApiIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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

### -ManagedBy
The fully qualified resource ID of the resource that manages this resource.
Indicates if this resource is managed by another Azure resource.
If this is present, complete mode deployment will not delete the resource if it is removed from the template since it is managed by another resource.

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

### -ManagedEnvironmentId
Deprecated.
Resource ID of the Container App's environment.

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

### -Name
Name of the Container App.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded
Aliases: ContainerAppName

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
Parameter Sets: UpdateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScaleMaxReplica
Optional.
Maximum number of container replicas.
Defaults to 10 if not set.

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

### -ScaleMinReplica
Optional.
Minimum number of container replicas.

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

### -ScaleRule
Scaling rules.
To construct, see NOTES section for SCALERULE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.IScaleRule[]
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
Parameter Sets: UpdateExpanded
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

### -TemplateRevisionSuffix
User friendly suffix that is appended to the revision name

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
Workload profile name to pin for container app execution.

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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.IContainerAppsApiIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ContainerAppsApi.Models.Api20221101Preview.IContainerApp

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`CONFIGURATION <IConfiguration>`: Non versioned Container App configuration properties.
  - `[ActiveRevisionsMode <ActiveRevisionsMode?>]`: ActiveRevisionsMode controls how active revisions are handled for the Container app:         <list><item>Multiple: multiple revisions can be active.</item><item>Single: Only one revision can be active at a time. Revision weights can not be used in this mode. If no value if provided, this is the default.</item></list>
  - `[CorPolicyAllowCredentials <Boolean?>]`: Specifies whether the resource allows credentials
  - `[CorPolicyAllowedHeader <String[]>]`: Specifies the content for the access-control-allow-headers header
  - `[CorPolicyAllowedMethod <String[]>]`: Specifies the content for the access-control-allow-methods header
  - `[CorPolicyAllowedOrigin <String[]>]`: Specifies the content for the access-control-allow-origins header
  - `[CorPolicyExposeHeader <String[]>]`: Specifies the content for the access-control-expose-headers header 
  - `[CorPolicyMaxAge <Int32?>]`: Specifies the content for the access-control-max-age header
  - `[DaprAppId <String>]`: Dapr application identifier
  - `[DaprAppPort <Int32?>]`: Tells Dapr which port your application is listening on
  - `[DaprAppProtocol <AppProtocol?>]`: Tells Dapr which protocol your application is using. Valid options are http and grpc. Default is http
  - `[DaprEnableApiLogging <Boolean?>]`: Enables API logging for the Dapr sidecar
  - `[DaprEnabled <Boolean?>]`: Boolean indicating if the Dapr side car is enabled
  - `[DaprHttpMaxRequestSize <Int32?>]`: Increasing max size of request body http and grpc servers parameter in MB to handle uploading of big files. Default is 4 MB.
  - `[DaprHttpReadBufferSize <Int32?>]`: Dapr max size of http header read buffer in KB to handle when sending multi-KB headers. Default is 65KB.
  - `[DaprLogLevel <LogLevel?>]`: Sets the log level for the Dapr sidecar. Allowed values are debug, info, warn, error. Default is info.
  - `[IngressAllowInsecure <Boolean?>]`: Bool indicating if HTTP connections to is allowed. If set to false HTTP connections are automatically redirected to HTTPS connections
  - `[IngressClientCertificateMode <IngressClientCertificateMode?>]`: Client certificate mode for mTLS authentication. Ignore indicates server drops client certificate on forwarding. Accept indicates server forwards client certificate but does not require a client certificate. Require indicates server requires a client certificate.
  - `[IngressCustomDomain <ICustomDomain[]>]`: custom domain bindings for Container Apps' hostnames.
    - `Name <String>`: Hostname.
    - `[BindingType <BindingType?>]`: Custom Domain binding type.
    - `[CertificateId <String>]`: Resource Id of the Certificate to be bound to this hostname. Must exist in the Managed Environment.
  - `[IngressExposedPort <Int32?>]`: Exposed Port in containers for TCP traffic from ingress
  - `[IngressExternal <Boolean?>]`: Bool indicating if app exposes an external http endpoint
  - `[IngressIPSecurityRestriction <IIPSecurityRestrictionRule[]>]`: Rules to restrict incoming IP address.
    - `Action <Action>`: Allow or Deny rules to determine for incoming IP. Note: Rules can only consist of ALL Allow or ALL Deny
    - `IPAddressRange <String>`: CIDR notation to match incoming IP address
    - `Name <String>`: Name for the IP restriction rule.
    - `[Description <String>]`: Describe the IP restriction rule that is being sent to the container-app. This is an optional field.
  - `[IngressTargetPort <Int32?>]`: Target Port in containers for traffic from ingress
  - `[IngressTraffic <ITrafficWeight[]>]`: Traffic weights for app's revisions
    - `[Label <String>]`: Associates a traffic label with a revision
    - `[LatestRevision <Boolean?>]`: Indicates that the traffic weight belongs to a latest stable revision
    - `[RevisionName <String>]`: Name of a revision
    - `[Weight <Int32?>]`: Traffic weight assigned to a revision
  - `[IngressTransport <IngressTransportMethod?>]`: Ingress transport protocol
  - `[MaxInactiveRevision <Int32?>]`: Optional. Max inactive revisions a Container App can have.
  - `[Registry <IRegistryCredentials[]>]`: Collection of private container registry credentials for containers used by the Container app
    - `[Identity <String>]`: A Managed Identity to use to authenticate with Azure Container Registry. For user-assigned identities, use the full user-assigned identity Resource ID. For system-assigned identities, use 'system'
    - `[PasswordSecretRef <String>]`: The name of the Secret that contains the registry login password
    - `[Server <String>]`: Container Registry Server
    - `[Username <String>]`: Container Registry Username
  - `[Secret <ISecret[]>]`: Collection of secrets used by a Container app
    - `[Identity <String>]`: Resource ID of a managed identity to authenticate with Azure Key Vault, or System to use a system-assigned identity.
    - `[KeyVaultUrl <String>]`: Azure Key Vault URL pointing to the secret referenced by the container app.
    - `[Name <String>]`: Secret Name.
    - `[Value <String>]`: Secret Value.
  - `[StickySessionAffinity <Affinity?>]`: Sticky Session Affinity

`INPUTOBJECT <IContainerAppsApiIdentity>`: Identity Parameter
  - `[AuthConfigName <String>]`: Name of the Container App AuthConfig.
  - `[CertificateName <String>]`: Name of the Certificate.
  - `[ComponentName <String>]`: Name of the Dapr Component.
  - `[ConnectedEnvironmentName <String>]`: Name of the connectedEnvironment.
  - `[ContainerAppName <String>]`: Name of the Container App.
  - `[DetectorName <String>]`: Name of the Container App Detector.
  - `[EnvironmentName <String>]`: Name of the Environment.
  - `[Id <String>]`: Resource identity path
  - `[JobExecutionName <String>]`: Job execution name.
  - `[JobName <String>]`: Name of the Container Apps Job.
  - `[Location <String>]`: The name of Azure region.
  - `[ManagedCertificateName <String>]`: Name of the Managed Certificate.
  - `[ReplicaName <String>]`: Name of the Container App Revision Replica.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RevisionName <String>]`: Name of the Container App Revision.
  - `[SourceControlName <String>]`: Name of the Container App SourceControl.
  - `[StorageName <String>]`: Name of the storage.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

`SCALERULE <IScaleRule[]>`: Scaling rules.
  - `[AzureQueueAuth <IScaleRuleAuth[]>]`: Authentication secrets for the queue scale rule.
    - `[SecretRef <String>]`: Name of the Container App secret from which to pull the auth params.
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

