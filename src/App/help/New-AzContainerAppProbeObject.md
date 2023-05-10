---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerappprobeobject
schema: 2.0.0
---

# New-AzContainerAppProbeObject

## SYNOPSIS
Create an in-memory object for ContainerAppProbe.

## SYNTAX

```
New-AzContainerAppProbeObject [-FailureThreshold <Int32>] [-HttpGetHost <String>]
 [-HttpGetHttpHeader <IContainerAppProbeHttpGetHttpHeadersItem[]>] [-HttpGetPath <String>]
 [-HttpGetPort <Int32>] [-HttpGetScheme <Scheme>] [-InitialDelaySecond <Int32>] [-PeriodSecond <Int32>]
 [-SuccessThreshold <Int32>] [-TcpSocketHost <String>] [-TcpSocketPort <Int32>]
 [-TerminationGracePeriodSecond <Int64>] [-TimeoutSecond <Int32>] [-Type <Type>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ContainerAppProbe.

## EXAMPLES

### Example 1: Create a ContainerAppProb object for ContainerApp.
```powershell
New-AzContainerAppProbeObject -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -Type Liveness
```

```output
FailureThreshold InitialDelaySecond PeriodSecond SuccessThreshold TerminationGracePeriodSecond TimeoutSecond
---------------- ------------------ ------------ ---------------- ---------------------------- -------------
                 3                  3
```

Create a ContainerAppProb object for ContainerApp.

## PARAMETERS

### -FailureThreshold
Minimum consecutive failures for the probe to be considered failed after having succeeded.
Defaults to 3.
Minimum value is 1.
Maximum value is 10.

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

### -HttpGetHost
Host name to connect to, defaults to the pod IP.
You probably want to set "Host" in httpHeaders instead.

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

### -HttpGetHttpHeader
Custom headers to set in the request.
HTTP allows repeated headers.
To construct, see NOTES section for HTTPGETHTTPHEADER properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.IContainerAppProbeHttpGetHttpHeadersItem[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HttpGetPath
Path to access on the HTTP server.

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

### -HttpGetPort
Name or number of the port to access on the container.
Number must be in the range 1 to 65535.
Name must be an IANA_SVC_NAME.

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

### -HttpGetScheme
Scheme to use for connecting to the host.
Defaults to HTTP.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.Scheme
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InitialDelaySecond
Number of seconds after the container has started before liveness probes are initiated.
Minimum value is 1.
Maximum value is 60.

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

### -PeriodSecond
How often (in seconds) to perform the probe.
Default to 10 seconds.
Minimum value is 1.
Maximum value is 240.

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

### -SuccessThreshold
Minimum consecutive successes for the probe to be considered successful after having failed.
Defaults to 1.
Must be 1 for liveness and startup.
Minimum value is 1.
Maximum value is 10.

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

### -TcpSocketHost
Optional: Host name to connect to, defaults to the pod IP.

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

### -TcpSocketPort
Number or name of the port to access on the container.
Number must be in the range 1 to 65535.
Name must be an IANA_SVC_NAME.

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
Optional duration in seconds the pod needs to terminate gracefully upon probe failure.
The grace period is the duration in seconds after the processes running in the pod are sent a termination signal and the time when the processes are forcibly halted with a kill signal.
Set this value longer than the expected cleanup time for your process.
If this value is nil, the pod's terminationGracePeriodSeconds will be used.
Otherwise, this value overrides the value provided by the pod spec.
Value must be non-negative integer.
The value zero indicates stop immediately via the kill signal (no opportunity to shut down).
This is an alpha field and requires enabling ProbeTerminationGracePeriod feature gate.
Maximum value is 3600 seconds (1 hour).

```yaml
Type: System.Int64
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -TimeoutSecond
Number of seconds after which the probe times out.
Defaults to 1 second.
Minimum value is 1.
Maximum value is 240.

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

### -Type
The type of probe.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.Type
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.ContainerAppProbe

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


`HTTPGETHTTPHEADER <IContainerAppProbeHttpGetHttpHeadersItem[]>`: Custom headers to set in the request. HTTP allows repeated headers.
  - `Name <String>`: The header field name
  - `Value <String>`: The header field value

## RELATED LINKS

