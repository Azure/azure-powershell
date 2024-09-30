---
external help file:
Module Name: Az.ImageBuilder
online version: https://learn.microsoft.com/powershell/module/az.ImageBuilder/new-azimagebuildertemplatevalidatorobject
schema: 2.0.0
---

# New-AzImageBuilderTemplateValidatorObject

## SYNOPSIS
Create an in-memory object for ImageTemplateValidator.

## SYNTAX

### PowerShellValidator (Default)
```
New-AzImageBuilderTemplateValidatorObject -PowerShellValidator [-Inline <String[]>] [-Name <String>]
 [-RunAsSystem <Boolean>] [-RunElevated <Boolean>] [-ScriptUri <String>] [-Sha256Checksum <String>]
 [-ValidExitCode <Int32[]>] [<CommonParameters>]
```

### ShellValidator
```
New-AzImageBuilderTemplateValidatorObject -ShellValidator [-Inline <String[]>] [-Name <String>]
 [-ScriptUri <String>] [-Sha256Checksum <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ImageTemplateValidator.

## EXAMPLES

### Example 1: Create a PowerShell validator.
```powershell
New-AzImageBuilderTemplateValidatorObject -PowerShellValidator -Name PowerShellValidator -ScriptUri "https://example.com/path/to/script.sh"
```

```output
Name                Inline RunAsSystem RunElevated ScriptUri                             Sha256Checksum ValidExitCode
----                ------ ----------- ----------- ---------                             -------------- -------------
PowerShellValidator                                https://example.com/path/to/script.sh
```

This command creates a powershell validator.

### Example 2: Create a Shell validator.
```powershell
New-AzImageBuilderTemplateValidatorObject -ShellValidator -Name ShellValidator -ScriptUri "https://example.com/path/to/script.sh"
```

```output
Name           Inline ScriptUri                             Sha256Checksum
----           ------ ---------                             --------------
ShellValidator        https://example.com/path/to/script.sh
```

This command creates a shell validator.

## PARAMETERS

### -Inline
Array of PowerShell commands to execute.

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

### -Name
Friendly Name to provide context on what this validation step does.

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

### -PowerShellValidator
Runs the specified PowerShell script during the validation phase (Windows).
Corresponds to Packer powershell provisioner.
Exactly one of 'scriptUri' or 'inline' can be specified.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: PowerShellValidator
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunAsSystem
If specified, the PowerShell script will be run with elevated privileges using the Local System user.
Can only be true when the runElevated field above is set to true.

```yaml
Type: System.Boolean
Parameter Sets: PowerShellValidator
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -RunElevated
If specified, the PowerShell script will be run with elevated privileges.

```yaml
Type: System.Boolean
Parameter Sets: PowerShellValidator
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ScriptUri
URI of the PowerShell script to be run for validation.
It can be a github link, Azure Storage URI, etc.

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

### -Sha256Checksum
SHA256 checksum of the power shell script provided in the scriptUri field above.

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

### -ShellValidator
Runs the specified shell script during the validation phase (Linux).
Corresponds to Packer shell provisioner.
Exactly one of 'scriptUri' or 'inline' can be specified.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: ShellValidator
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ValidExitCode
Valid exit codes for the PowerShell script.
[Default: 0].

```yaml
Type: System.Int32[]
Parameter Sets: PowerShellValidator
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

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.ImageTemplatePowerShellValidator

### Microsoft.Azure.PowerShell.Cmdlets.ImageBuilder.Models.Api20220701.ImageTemplateShellValidator

## NOTES

## RELATED LINKS

