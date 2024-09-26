---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappinitcontainertemplateobject
schema: 2.0.0
---

# New-AzContainerAppInitContainerTemplateObject

## SYNOPSIS
Create an in-memory object for InitContainer.

## SYNTAX

```
New-AzContainerAppInitContainerTemplateObject [-Arg <String[]>] [-Command <String[]>]
 [-Env <IEnvironmentVar[]>] [-Image <String>] [-Name <String>] [-ResourceCpu <Double>]
 [-ResourceMemory <String>] [-VolumeMount <IVolumeMount[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for InitContainer.

## EXAMPLES

### Example 1: Create an in-memory object for InitContainer.
```powershell
New-AzContainerAppInitContainerTemplateObject -Image "mcr.microsoft.com/k8se/quickstart:latest" -Name "simple-hello-world-container2" -ResourceCpu 0.25 -ResourceMemory "0.5Gi" -Command "/bin/sh" -Arg "-c","while true; do echo hello; sleep 10;done"
```

```output
Image                                    Name                          ResourceCpu ResourceEphemeralStorage ResourceMemory
-----                                    ----                          ----------- ------------------------ --------------
mcr.microsoft.com/k8se/quickstart:latest simple-hello-world-container2 0.25                                 0.5Gi
```

Create an in-memory object for InitContainer.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.InitContainer

## NOTES

## RELATED LINKS
