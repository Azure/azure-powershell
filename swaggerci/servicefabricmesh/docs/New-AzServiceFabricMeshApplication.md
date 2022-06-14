---
external help file:
Module Name: Az.ServiceFabricMesh
online version: https://docs.microsoft.com/en-us/powershell/module/az.servicefabricmesh/new-azservicefabricmeshapplication
schema: 2.0.0
---

# New-AzServiceFabricMeshApplication

## SYNOPSIS
Creates an application resource with the specified name, description and properties.
If an application resource with the same name exists, then it is updated with the specified description and properties.

## SYNTAX

```
New-AzServiceFabricMeshApplication -ResourceGroupName <String> -ResourceName <String> -Location <String>
 [-SubscriptionId <String>] [-DebugParam <String>] [-Description <String>]
 [-DiagnosticDefaultSinkRef <String[]>] [-DiagnosticEnabled] [-DiagnosticSink <IDiagnosticsSinkProperties[]>]
 [-Service <IServiceResourceDescription[]>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-PassThru]
 [-Confirm] [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Creates an application resource with the specified name, description and properties.
If an application resource with the same name exists, then it is updated with the specified description and properties.

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

### -DebugParam
Internal - used by Visual Studio to setup the debugging session on the local development environment.

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

### -Description
User readable description of the application.

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

### -DiagnosticDefaultSinkRef
The sinks to be used if diagnostics is enabled.
Sink choices can be overridden at the service and code package level.

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DiagnosticEnabled
Status of whether or not sinks are enabled.

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

### -DiagnosticSink
List of supported sinks that can be referenced.
To construct, see NOTES section for DIAGNOSTICSINK properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.Api20180901Preview.IDiagnosticsSinkProperties[]
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

### -PassThru
Returns true when the command succeeds

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
Azure resource group name

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

### -ResourceName
The identity of the application.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: ApplicationResourceName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Service
Describes the services in the application.
This property is used to create or modify services of the application.
On get only the name of the service is returned.
The service description can be obtained by querying for the service resource.
To construct, see NOTES section for SERVICE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.Api20180901Preview.IServiceResourceDescription[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The customer subscription identifier

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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceFabricMesh.Models.Api20180901Preview.IApplicationResourceDescription

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


DIAGNOSTICSINK <IDiagnosticsSinkProperties[]>: List of supported sinks that can be referenced.
  - `Kind <DiagnosticsSinkKind>`: The kind of DiagnosticsSink.
  - `[Description <String>]`: A description of the sink.
  - `[Name <String>]`: Name of the sink. This value is referenced by DiagnosticsReferenceDescription

SERVICE <IServiceResourceDescription[]>: Describes the services in the application. This property is used to create or modify services of the application. On get only the name of the service is returned. The service description can be obtained by querying for the service resource.
  - `CodePackage <IContainerCodePackageProperties[]>`: Describes the set of code packages that forms the service. A code package describes the container and the properties for running it. All the code packages are started together on the same host and share the same context (network, process etc.).
    - `Image <String>`: The Container image to use.
    - `Name <String>`: The name of the code package.
    - `RequestCpu <Double>`: Requested number of CPU cores. At present, only full cores are supported.
    - `RequestMemoryInGb <Double>`: The memory request in GB for this container.
    - `[Command <String[]>]`: Command array to execute within the container in exec form.
    - `[CurrentState <String>]`: The state of this container
    - `[CurrentStateDetailStatus <String>]`: Human-readable status of this state.
    - `[CurrentStateExitCode <String>]`: The container exit code.
    - `[CurrentStateFinishTime <DateTime?>]`: Date/time when the container state finished.
    - `[CurrentStateStartTime <DateTime?>]`: Date/time when the container state started.
    - `[DiagnosticEnabled <Boolean?>]`: Status of whether or not sinks are enabled.
    - `[DiagnosticSinkRef <String[]>]`: List of sinks to be used if enabled. References the list of sinks in DiagnosticsDescription.
    - `[Endpoint <IEndpointProperties[]>]`: The endpoints exposed by this container.
      - `Name <String>`: The name of the endpoint.
      - `[Port <Int32?>]`: Port used by the container.
    - `[Entrypoint <String>]`: Override for the default entry point in the container.
    - `[EnvironmentVariable <IEnvironmentVariable[]>]`: The environment variables to set in this container
      - `[Name <String>]`: The name of the environment variable.
      - `[Value <String>]`: The value of the environment variable.
    - `[ImageRegistryCredentialPassword <String>]`: The password for the private registry. The password is required for create or update operations, however it is not returned in the get or list operations.
    - `[ImageRegistryCredentialServer <String>]`: Docker image registry server, without protocol such as `http` and `https`.
    - `[ImageRegistryCredentialUsername <String>]`: The username for the private registry.
    - `[InstanceViewEvent <IContainerEvent[]>]`: The events of this container instance.
      - `[Count <Int32?>]`: The count of the event.
      - `[FirstTimestamp <String>]`: Date/time of the first event.
      - `[LastTimestamp <String>]`: Date/time of the last event.
      - `[Message <String>]`: The event message
      - `[Name <String>]`: The name of the container event.
      - `[Type <String>]`: The event type.
    - `[InstanceViewRestartCount <Int32?>]`: The number of times the container has been restarted.
    - `[Label <IContainerLabel[]>]`: The labels to set in this container.
      - `Name <String>`: The name of the container label.
      - `Value <String>`: The value of the container label.
    - `[LimitCpu <Double?>]`: CPU limits in cores. At present, only full cores are supported.
    - `[LimitMemoryInGb <Double?>]`: The memory limit in GB.
    - `[PreviouState <String>]`: The state of this container
    - `[PreviouStateDetailStatus <String>]`: Human-readable status of this state.
    - `[PreviouStateExitCode <String>]`: The container exit code.
    - `[PreviouStateFinishTime <DateTime?>]`: Date/time when the container state finished.
    - `[PreviouStateStartTime <DateTime?>]`: Date/time when the container state started.
    - `[ReliableCollectionsRef <IReliableCollectionsRef[]>]`: A list of ReliableCollection resources used by this particular code package. Please refer to ReliableCollectionsRef for more details.
      - `Name <String>`: Name of ReliableCollection resource. Right now it's not used and you can use any string.
      - `[DoNotPersistState <Boolean?>]`: False (the default) if ReliableCollections state is persisted to disk as usual. True if you do not want to persist state, in which case replication is still enabled and you can use ReliableCollections as distributed cache.
    - `[Setting <ISetting[]>]`: The settings to set in this container. The setting file path can be fetched from environment variable "Fabric_SettingPath". The path for Windows container is "C:\\secrets". The path for Linux container is "/var/secrets".
      - `[Name <String>]`: The name of the setting.
      - `[Value <String>]`: The value of the setting.
    - `[Volume <IApplicationScopedVolume[]>]`: Volumes to be attached to the container. The lifetime of these volumes is scoped to the application's lifetime.
      - `DestinationPath <String>`: The path within the container at which the volume should be mounted. Only valid path characters are allowed.
      - `Name <String>`: Name of the volume being referenced.
      - `[ReadOnly <Boolean?>]`: The flag indicating whether the volume is read only. Default is 'false'.
      - `[CreationParameterDescription <String>]`: User readable description of the volume.
    - `[VolumeRef <IVolumeReference[]>]`: Volumes to be attached to the container. The lifetime of these volumes is independent of the application's lifetime.
      - `DestinationPath <String>`: The path within the container at which the volume should be mounted. Only valid path characters are allowed.
      - `Name <String>`: Name of the volume being referenced.
      - `[ReadOnly <Boolean?>]`: The flag indicating whether the volume is read only. Default is 'false'.
  - `OSType <OperatingSystemType>`: The operation system required by the code in service.
  - `[Name <String>]`: The name of the resource
  - `[AutoScalingPolicy <IAutoScalingPolicy[]>]`: Auto scaling policies
    - `Name <String>`: The name of the auto scaling policy.
  - `[Description <String>]`: User readable description of the service.
  - `[DiagnosticEnabled <Boolean?>]`: Status of whether or not sinks are enabled.
  - `[DiagnosticSinkRef <String[]>]`: List of sinks to be used if enabled. References the list of sinks in DiagnosticsDescription.
  - `[NetworkRef <INetworkRef[]>]`: The names of the private networks that this service needs to be part of.
    - `[EndpointRef <IEndpointRef[]>]`: A list of endpoints that are exposed on this network.
      - `[Name <String>]`: Name of the endpoint.
    - `[Name <String>]`: Name of the network
  - `[ReplicaCount <Int32?>]`: The number of replicas of the service to create. Defaults to 1 if not specified.

## RELATED LINKS

