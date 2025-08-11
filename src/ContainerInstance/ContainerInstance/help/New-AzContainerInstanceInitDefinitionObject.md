---
external help file: Az.ContainerInstance-help.xml
Module Name: Az.ContainerInstance
online version: https://learn.microsoft.com/powershell/module/Az.ContainerInstance/new-azcontainerinstanceinitdefinitionobject
schema: 2.0.0
---

# New-AzContainerInstanceInitDefinitionObject

## SYNOPSIS
Create an in-memory object for InitContainerDefinition.

## SYNTAX

```
New-AzContainerInstanceInitDefinitionObject -Name <String> [-CapabilityAdd <String[]>]
 [-CapabilityDrop <String[]>] [-Command <String[]>] [-EnvironmentVariable <IEnvironmentVariable[]>]
 [-Image <String>] [-SecurityContextAllowPrivilegeEscalation <Boolean>] [-SecurityContextPrivileged <Boolean>]
 [-SecurityContextRunAsGroup <Int32>] [-SecurityContextRunAsUser <Int32>]
 [-SecurityContextSeccompProfile <String>] [-VolumeMount <IVolumeMount[]>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for InitContainerDefinition.

## EXAMPLES

### Example 1: Set up the init container definition
```powershell
New-AzContainerInstanceInitDefinitionObject -Name "initDefinition" -Command "/bin/sh -c myscript.sh"
```

```output
Name
----
initDefinition
```

This command sets up the init container definition with command `/bin/sh -c myscript.sh`

## PARAMETERS

### -CapabilityAdd
The capabilities to add to the container.

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

### -CapabilityDrop
The capabilities to drop from the container.

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
The command to execute within the init container in exec form.

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
The environment variables to set in the init container.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IEnvironmentVariable[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Image
The image of the init container.

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
The name for the init container.

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

### -SecurityContextAllowPrivilegeEscalation
A boolean value indicating whether the init process can elevate its privileges.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityContextPrivileged
The flag to determine if the container permissions is elevated to Privileged.

```yaml
Type: System.Boolean
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SecurityContextRunAsGroup
Sets the User GID for the container.

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

### -SecurityContextRunAsUser
Sets the User UID for the container.

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

### -SecurityContextSeccompProfile
a base64 encoded string containing the contents of the JSON in the seccomp profile.

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
The volume mounts available to the init container.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.IVolumeMount[]
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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.InitContainerDefinition

## NOTES

## RELATED LINKS
