---
external help file:
Module Name: Az.ContainerInstance
online version: https://docs.microsoft.com/powershell/module//az.ContainerInstance/new-AzContainerInstanceObject
schema: 2.0.0
---

# New-AzContainerInstanceObject

## SYNOPSIS
Create a in-memory object for Container

## SYNTAX

```
New-AzContainerInstanceObject -Image <String> -Name <String> [-Command <String[]>]
 [-EnvironmentVariable <IEnvironmentVariable[]>] [-LimitCpu <Double>] [-LimitMemoryInGb <Double>]
 [-LimitsGpuCount <Int32>] [-LimitsGpuSku <String>] [-LivenessProbeExecCommand <String[]>]
 [-LivenessProbeFailureThreshold <Int32>] [-LivenessProbeHttpGetHttpHeadersName <String>]
 [-LivenessProbeHttpGetHttpHeadersValue <String>] [-LivenessProbeHttpGetPath <String>]
 [-LivenessProbeHttpGetPort <Int32>] [-LivenessProbeHttpGetScheme <String>]
 [-LivenessProbeInitialDelaySecond <Int32>] [-LivenessProbePeriodSecond <Int32>]
 [-LivenessProbeSuccessThreshold <Int32>] [-LivenessProbeTimeoutSecond <Int32>] [-Port <IContainerPort[]>]
 [-ReadinessProbeExecCommand <String[]>] [-ReadinessProbeFailureThreshold <Int32>]
 [-ReadinessProbeHttpGetHttpHeadersName <String>] [-ReadinessProbeHttpGetHttpHeadersValue <String>]
 [-ReadinessProbeHttpGetPath <String>] [-ReadinessProbeHttpGetPort <Int32>]
 [-ReadinessProbeHttpGetScheme <String>] [-ReadinessProbeInitialDelaySecond <Int32>]
 [-ReadinessProbePeriodSecond <Int32>] [-ReadinessProbeSuccessThreshold <Int32>]
 [-ReadinessProbeTimeoutSecond <Int32>] [-RequestCpu <Double>] [-RequestMemoryInGb <Double>]
 [-RequestsGpuCount <Int32>] [-RequestsGpuSku <String>] [-VolumeMount <IVolumeMount[]>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Container

## EXAMPLES

### Example 1: Create a container instance using image alphine with request cpu 1.0 and request memory 1.5Gb
```powershell
PS C:\> New-AzContainerInstanceObject -Name "test-container" -Image alpine -RequestCpu 1 -RequestMemoryInGb 1.5

Name
----
test-container
```

Create a container instance using image alphine with request cpu 1.0 and request memory 1.5Gb

### Example 2: {{ Add title here }}
```powershell
PS C:\> {{ Add code here }}

{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Command
The commands to execute within the container instance in exec form.

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

### -EnvironmentVariable
The environment variables to set in the container instance.
To construct, see NOTES section for ENVIRONMENTVARIABLE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IEnvironmentVariable[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Image
The name of the image used to create the container instance.

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

### -LimitCpu
The CPU limit of this container instance.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LimitMemoryInGb
The memory limit in GB of this container instance.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -LimitsGpuCount
The count of the GPU resource.

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

### -LimitsGpuSku
The SKU of the GPU resource.

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

### -LivenessProbeExecCommand
The commands to execute within the container.

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

### -LivenessProbeFailureThreshold
The failure threshold.

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

### -LivenessProbeHttpGetHttpHeadersName
The header name.

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

### -LivenessProbeHttpGetHttpHeadersValue
The header value.

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

### -LivenessProbeHttpGetPath
The path to probe.

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

### -LivenessProbeHttpGetPort
The port number to probe.

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

### -LivenessProbeHttpGetScheme
The scheme.

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

### -LivenessProbeInitialDelaySecond
The initial delay seconds.

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
The period seconds.

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
The success threshold.

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
The timeout seconds.

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
The user-provided name of the container instance.

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

### -Port
The exposed ports on the container instance.
To construct, see NOTES section for PORT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IContainerPort[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ReadinessProbeExecCommand
The commands to execute within the container.

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

### -ReadinessProbeFailureThreshold
The failure threshold.

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

### -ReadinessProbeHttpGetHttpHeadersName
The header name.

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

### -ReadinessProbeHttpGetHttpHeadersValue
The header value.

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

### -ReadinessProbeHttpGetPath
The path to probe.

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

### -ReadinessProbeHttpGetPort
The port number to probe.

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

### -ReadinessProbeHttpGetScheme
The scheme.

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

### -ReadinessProbeInitialDelaySecond
The initial delay seconds.

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
The period seconds.

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
The success threshold.

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
The timeout seconds.

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

### -RequestCpu
The CPU request of this container instance.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestMemoryInGb
The memory request in GB of this container instance.

```yaml
Type: System.Double
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RequestsGpuCount
The count of the GPU resource.

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

### -RequestsGpuSku
The SKU of the GPU resource.

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

### -VolumeMount
The volume mounts available to the container instance.
To construct, see NOTES section for VOLUMEMOUNT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.IVolumeMount[]
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.Container

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


ENVIRONMENTVARIABLE <IEnvironmentVariable[]>: The environment variables to set in the container instance.
  - `Name <String>`: The name of the environment variable.
  - `[SecureValue <String>]`: The value of the secure environment variable.
  - `[Value <String>]`: The value of the environment variable.

PORT <IContainerPort[]>: The exposed ports on the container instance.
  - `Port <Int32>`: The port number exposed within the container group.
  - `[Protocol <ContainerNetworkProtocol?>]`: The protocol associated with the port.

VOLUMEMOUNT <IVolumeMount[]>: The volume mounts available to the container instance.
  - `MountPath <String>`: The path within the container where the volume should be mounted. Must not contain colon (:).
  - `Name <String>`: The name of the volume mount.
  - `[ReadOnly <Boolean?>]`: The flag indicating whether the volume mount is read-only.

## RELATED LINKS

