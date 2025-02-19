---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerapptemplateobject
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

### Example 1: Create an in-memory object for Container.
```powershell
$probeHttpGetHttpHeader = New-AzContainerAppProbeHeaderObject -Name "Custom-Header" -Value "Awesome"
$probe = New-AzContainerAppProbeObject -Type "Liveness" -HttpGetPath "/health" -HttpGetPort 8080 -InitialDelaySecond 3 -PeriodSecond 3 -HttpGetHttpHeader $probeHttpGetHttpHeader

New-AzContainerAppTemplateObject -Image "repo/testcontainerApp0:v1" -Name "testcontainerApp0" -Probe $probe
```

```output
Image                     Name              ResourceCpu ResourceEphemeralStorage ResourceMemory
-----                     ----              ----------- ------------------------ --------------
repo/testcontainerApp0:v1 testcontainerApp0
```

Create an in-memory object for Container.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IEnvironmentVar[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IContainerAppProbe[]
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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Models.IVolumeMount[]
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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Container

## NOTES

## RELATED LINKS

