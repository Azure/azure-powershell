---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerapptemplateobject
schema: 2.0.0
---

# New-AzContainerAppTemplateObject

## SYNOPSIS
Create an in-memory object for Container.

## SYNTAX

```
New-AzContainerAppTemplateObject [-Arg <String[]>] [-Command <String[]>] [-Env <IEnvironmentVar[]>]
 [-Image <String>] [-Name <String>] [-Probe <IContainerAppProbe[]>] [-ResourceCpu <Double>]
 [-ResourceMemory <String>] [-VolumeMount <IVolumeMount[]>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Container.

## EXAMPLES

### Example 1: Create an image object for Container.
```powershell
$containerAppHttpHeader = New-AzContainerAppProbeHeaderObject -Name Custom-Header -Value Awesome
$probeArray = @()
$probeArray += New-AzContainerAppProbeObject -HttpGetPath "/health01" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
$probeArray += New-AzContainerAppProbeObject -HttpGetPath "/health02" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness -HttpGetHttpHeader $containerAppHttpHeader
New-AzContainerAppTemplateObject -Name azps-containerapp -Image mcr.microsoft.com/azuredocs/containerapps-helloworld:latest -Probe $probeArray -ResourceCpu 2.0 -ResourceMemory 4.0Gi
```

```output
Arg Command Image                                                       Name
--- ------- -----                                                       ----
            mcr.microsoft.com/azuredocs/containerapps-helloworld:latest azps-containerapp
```

Create an image object for Container.

## PARAMETERS

### -Arg
Container start command arguments.

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

### -Command
Container start command.

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

### -Env
Container environment variables.
To construct, see NOTES section for ENV properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IEnvironmentVar[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Image
Container image tag.

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
Custom container name.

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

### -Probe
List of probes for the container.
To construct, see NOTES section for PROBE properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IContainerAppProbe[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceCpu
Required CPU in cores, e.g.
0.5.

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

### -ResourceMemory
Required memory, e.g.
"250Mb".

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
Container volume mounts.
To construct, see NOTES section for VOLUMEMOUNT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IVolumeMount[]
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.Container

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`ENV <IEnvironmentVar[]>`: Container environment variables.
  - `[Name <String>]`: Environment variable name.
  - `[SecretRef <String>]`: Name of the Container App secret from which to pull the environment variable value.
  - `[Value <String>]`: Non-secret environment variable value.

`PROBE <IContainerAppProbe[]>`: List of probes for the container.
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

`VOLUMEMOUNT <IVolumeMount[]>`: Container volume mounts.
  - `[MountPath <String>]`: Path within the container at which the volume should be mounted.Must not contain ':'.
  - `[VolumeName <String>]`: This must match the Name of a Volume.

## RELATED LINKS

