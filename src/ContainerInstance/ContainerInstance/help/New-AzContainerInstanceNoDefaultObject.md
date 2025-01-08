---
external help file: Az.ContainerInstance-help.xml
Module Name: Az.ContainerInstance
online version: https://learn.microsoft.com/powershell/module/az.ContainerInstance/New-AzContainerInstanceNoDefaultObject
schema: 2.0.0
---

# New-AzContainerInstanceNoDefaultObject

## SYNOPSIS
Create a in-memory object for Container with no default values

## SYNTAX

```
New-AzContainerInstanceNoDefaultObject -Name <String> [-Command <String[]>]
 [-ConfigMapKeyValuePair <IConfigMapKeyValuePairs>] [-EnvironmentVariable <IEnvironmentVariable[]>]
 [-Image <String>] [-LimitCpu <Double>] [-LimitMemoryInGb <Double>] [-LimitsGpuCount <Int32>]
 [-LimitsGpuSku <String>] [-LivenessProbeExecCommand <String[]>] [-LivenessProbeFailureThreshold <Int32>]
 [-LivenessProbeHttpGetHttpHeader <IHttpHeader[]>] [-LivenessProbeHttpGetPath <String>]
 [-LivenessProbeHttpGetPort <Int32>] [-LivenessProbeHttpGetScheme <String>]
 [-LivenessProbeInitialDelaySecond <Int32>] [-LivenessProbePeriodSecond <Int32>]
 [-LivenessProbeSuccessThreshold <Int32>] [-LivenessProbeTimeoutSecond <Int32>] [-Port <IContainerPort[]>]
 [-ReadinessProbeExecCommand <String[]>] [-ReadinessProbeFailureThreshold <Int32>]
 [-ReadinessProbeHttpGetHttpHeader <IHttpHeader[]>] [-ReadinessProbeHttpGetPath <String>]
 [-ReadinessProbeHttpGetPort <Int32>] [-ReadinessProbeHttpGetScheme <String>]
 [-ReadinessProbeInitialDelaySecond <Int32>] [-ReadinessProbePeriodSecond <Int32>]
 [-ReadinessProbeSuccessThreshold <Int32>] [-ReadinessProbeTimeoutSecond <Int32>] [-RequestCpu <Double>]
 [-RequestMemoryInGb <Double>] [-RequestsGpuCount <Int32>] [-RequestsGpuSku <String>]
 [-VolumeMount <IVolumeMount[]>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for Container with no default values

## EXAMPLES

### Example 1: Create a container instance using image alphine with request cpu 1.0 and request memory 1.5Gb
```powershell
New-AzContainerInstanceNoDefaultObject -Name "test-container" -Image alpine -RequestCpu 1 -RequestMemoryInGb 1.5
```

```output
Name
----
test-container
```

Create a container instance using image alphine with request cpu 1.0 and request memory 1.5Gb

### Example 2: Create a container instance using image alphine with limit cpu 2.0 and limit memory 2.5Gb
```powershell
New-AzContainerInstanceNoDefaultObject -Image alpine -Name "test-container" -LimitCpu 2 -LimitMemoryInGb 2.5
```

```output
Name
----
test-container
```

Create a container instance using image alphine with limit cpu 2.0 and limit memory 2.5Gb

### Example 3: Create a container group with a container instance
```powershell
$container = New-AzContainerInstanceNoDefaultObject -Name test-container -Image alpine
New-AzContainerGroup -ResourceGroupName testrg-rg -Name test-cg -Location eastus -Container $container
```

```output
Location Name    Zone ResourceGroupName
-------- ----    ---- -----------------
eastus   test-cg      test-rg
```

Create a container group with a container instance

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

### -ConfigMapKeyValuePair
The key value pairs dictionary in the config map to set in the container instance.
To construct, see NOTES section for CONFIGMAPKEYVALUEPAIR properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IConfigMapKeyValuePairs
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IEnvironmentVariable[]
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

Required: False
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

### -LivenessProbeHttpGetHttpHeader
The HTTP headers for liveness probe.
To construct, see NOTES section for LIVENESSPROBEHTTPGETHTTPHEADER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IHttpHeader[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IContainerPort[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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

### -ReadinessProbeHttpGetHttpHeader
The HTTP headers for readiness probe.
To construct, see NOTES section for READINESSPROBEHTTPGETHTTPHEADER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IHttpHeader[]
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
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.IVolumeMount[]
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20240501Preview.Container

## NOTES

## RELATED LINKS
