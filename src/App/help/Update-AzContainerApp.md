---
external help file:
Module Name: Az.App
online version: https://docs.microsoft.com/powershell/module/az.app/update-azcontainerapp
schema: 2.0.0
---

# Update-AzContainerApp

## SYNOPSIS
Patches a Container App using JSON Merge Patch

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzContainerApp -Name <String> -ResourceGroupName <String> -Location <String> [-SubscriptionId <String>]
 [-ConfigurationActiveRevisionsMode <ActiveRevisionsMode>] [-ConfigurationRegistry <IRegistryCredentials[]>]
 [-ConfigurationSecret <ISecret[]>] [-DaprAppId <String>] [-DaprAppPort <Int32>]
 [-DaprAppProtocol <AppProtocol>] [-DaprEnabled] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-IngressAllowInsecure] [-IngressCustomDomain <ICustomDomain[]>]
 [-IngressExternal] [-IngressTargetPort <Int32>] [-IngressTraffic <ITrafficWeight[]>]
 [-IngressTransport <IngressTransportMethod>] [-ManagedEnvironmentId <String>] [-ScaleMaxReplica <Int32>]
 [-ScaleMinReplica <Int32>] [-ScaleRule <IScaleRule[]>] [-Tag <Hashtable>] [-TemplateContainer <IContainer[]>]
 [-TemplateRevisionSuffix <String>] [-TemplateVolume <IVolume[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzContainerApp -InputObject <IAppIdentity> -Location <String>
 [-ConfigurationActiveRevisionsMode <ActiveRevisionsMode>] [-ConfigurationRegistry <IRegistryCredentials[]>]
 [-ConfigurationSecret <ISecret[]>] [-DaprAppId <String>] [-DaprAppPort <Int32>]
 [-DaprAppProtocol <AppProtocol>] [-DaprEnabled] [-IdentityType <ManagedServiceIdentityType>]
 [-IdentityUserAssignedIdentity <Hashtable>] [-IngressAllowInsecure] [-IngressCustomDomain <ICustomDomain[]>]
 [-IngressExternal] [-IngressTargetPort <Int32>] [-IngressTraffic <ITrafficWeight[]>]
 [-IngressTransport <IngressTransportMethod>] [-ManagedEnvironmentId <String>] [-ScaleMaxReplica <Int32>]
 [-ScaleMinReplica <Int32>] [-ScaleRule <IScaleRule[]>] [-Tag <Hashtable>] [-TemplateContainer <IContainer[]>]
 [-TemplateRevisionSuffix <String>] [-TemplateVolume <IVolume[]>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Patches a Container App using JSON Merge Patch

## EXAMPLES

### Example 1: Update a Container App.
```powershell
Update-AzContainerApp -Name azps-containerapp -ResourceGroupName azpstest_gp -Location canadacentral -DaprEnabled -DaprAppProtocol 'http' -DaprAppId "container-app-1" -DaprAppPort 8080
```

```output
Location       Name              ResourceGroupName
--------       ----              -----------------
Canada Central azps-containerapp azpstest_gp
```

Update a Container App.

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

### -ConfigurationActiveRevisionsMode
ActiveRevisionsMode controls how active revisions are handled for the Container app:\<list\>\<item\>Multiple: multiple revisions can be active.\</item\>\<item\>Single: Only one revision can be active at a time.
Revision weights can not be used in this mode.
If no value if provided, this is the default.\</item\>\</list\>

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.ActiveRevisionsMode
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationRegistry
Collection of private container registry credentials for containers used by the Container app
To construct, see NOTES section for CONFIGURATIONREGISTRY properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IRegistryCredentials[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ConfigurationSecret
Collection of secrets used by a Container app
To construct, see NOTES section for CONFIGURATIONSECRET properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.ISecret[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaprAppId
Dapr application identifier

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

### -DaprAppPort
Tells Dapr which port your application is listening on

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

### -DaprAppProtocol
Tells Dapr which protocol your application is using.
Valid options are http and grpc.
Default is http

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.AppProtocol
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DaprEnabled
Boolean indicating if the Dapr side car is enabled

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
The credentials, account, tenant, and subscription used for communication with Azure.

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

### -IdentityType
Type of managed service identity (where both SystemAssigned and UserAssigned types are allowed).

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.ManagedServiceIdentityType
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

### -IngressAllowInsecure
Bool indicating if HTTP connections to is allowed.
If set to false HTTP connections are automatically redirected to HTTPS connections

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

### -IngressCustomDomain
custom domain bindings for Container Apps' hostnames.
To construct, see NOTES section for INGRESSCUSTOMDOMAIN properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.ICustomDomain[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressExternal
Bool indicating if app exposes an external http endpoint

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

### -IngressTargetPort
Target Port in containers for traffic from ingress

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

### -IngressTraffic
Traffic weights for app's revisions
To construct, see NOTES section for INGRESSTRAFFIC properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.ITrafficWeight[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -IngressTransport
Ingress transport protocol

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.IngressTransportMethod
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
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity
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

### -ManagedEnvironmentId
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
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IScaleRule[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IContainer[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IVolume[]
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.IAppIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IContainerApp

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


CONFIGURATIONREGISTRY <IRegistryCredentials[]>: Collection of private container registry credentials for containers used by the Container app
  - `[Identity <String>]`: A Managed Identity to use to authenticate with Azure Container Registry. For user-assigned identities, use the full user-assigned identity Resource ID. For system-assigned identities, use 'system'
  - `[PasswordSecretRef <String>]`: The name of the Secret that contains the registry login password
  - `[Server <String>]`: Container Registry Server
  - `[Username <String>]`: Container Registry Username

CONFIGURATIONSECRET <ISecret[]>: Collection of secrets used by a Container app
  - `[Name <String>]`: Secret Name.
  - `[Value <String>]`: Secret Value.

INGRESSCUSTOMDOMAIN <ICustomDomain[]>: custom domain bindings for Container Apps' hostnames.
  - `CertificateId <String>`: Resource Id of the Certificate to be bound to this hostname. Must exist in the Managed Environment.
  - `Name <String>`: Hostname.
  - `[BindingType <BindingType?>]`: Custom Domain binding type.

INGRESSTRAFFIC <ITrafficWeight[]>: Traffic weights for app's revisions
  - `[Label <String>]`: Associates a traffic label with a revision
  - `[LatestRevision <Boolean?>]`: Indicates that the traffic weight belongs to a latest stable revision
  - `[RevisionName <String>]`: Name of a revision
  - `[Weight <Int32?>]`: Traffic weight assigned to a revision

INPUTOBJECT <IAppIdentity>: Identity Parameter
  - `[AuthConfigName <String>]`: Name of the Container App AuthConfig.
  - `[CertificateName <String>]`: Name of the Certificate.
  - `[ComponentName <String>]`: Name of the Dapr Component.
  - `[ContainerAppName <String>]`: Name of the Container App.
  - `[EnvironmentName <String>]`: Name of the Managed Environment.
  - `[Id <String>]`: Resource identity path
  - `[ReplicaName <String>]`: Name of the Container App Revision Replica.
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RevisionName <String>]`: Name of the Container App Revision.
  - `[SourceControlName <String>]`: Name of the Container App SourceControl.
  - `[StorageName <String>]`: Name of the storage.
  - `[SubscriptionId <String>]`: The ID of the target subscription.

SCALERULE <IScaleRule[]>: Scaling rules.
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

TEMPLATECONTAINER <IContainer[]>: List of container definitions for the Container App.
  - `[Arg <String[]>]`: Container start command arguments.
  - `[Command <String[]>]`: Container start command.
  - `[Env <IEnvironmentVar[]>]`: Container environment variables.
    - `[Name <String>]`: Environment variable name.
    - `[SecretRef <String>]`: Name of the Container App secret from which to pull the environment variable value.
    - `[Value <String>]`: Non-secret environment variable value.
  - `[Image <String>]`: Container image tag.
  - `[Name <String>]`: Custom container name.
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
  - `[ResourceCpu <Double?>]`: Required CPU in cores, e.g. 0.5
  - `[ResourceMemory <String>]`: Required memory, e.g. "250Mb"
  - `[VolumeMount <IVolumeMount[]>]`: Container volume mounts.
    - `[MountPath <String>]`: Path within the container at which the volume should be mounted.Must not contain ':'.
    - `[VolumeName <String>]`: This must match the Name of a Volume.

TEMPLATEVOLUME <IVolume[]>: List of volume definitions for the Container App.
  - `[Name <String>]`: Volume name.
  - `[StorageName <String>]`: Name of storage resource. No need to provide for EmptyDir.
  - `[StorageType <StorageType?>]`: Storage type for the volume. If not provided, use EmptyDir.

## RELATED LINKS

