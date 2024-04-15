---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappenvironmentvarobject
schema: 2.0.0
---

# New-AzContainerAppEnvironmentVarObject

## SYNOPSIS
Create an in-memory object for EnvironmentVar.

## SYNTAX

```
New-AzContainerAppEnvironmentVarObject [-Name <String>] [-SecretRef <String>] [-Value <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for EnvironmentVar.

## EXAMPLES

### Example 1: Create an EnvironmentVar object for Env.
```powershell
New-AzContainerAppEnvironmentVarObject -Name "envVarName" -SecretRef "redis-secret" -Value "value"
```

```output
Name       SecretRef    Value
----       ---------    -----
envVarName redis-secret value
```

Create an EnvironmentVar object for Env.

## PARAMETERS

### -Name
Environment variable name.

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

### -SecretRef
Name of the Container App secret from which to pull the environment variable value.

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

### -Value
Non-secret environment variable value.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.EnvironmentVar

## NOTES

## RELATED LINKS
