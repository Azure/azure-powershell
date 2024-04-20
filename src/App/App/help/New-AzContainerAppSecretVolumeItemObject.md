---
external help file: Az.App-help.xml
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/Az.App/new-azcontainerappsecretvolumeitemobject
schema: 2.0.0
---

# New-AzContainerAppSecretVolumeItemObject

## SYNOPSIS
Create an in-memory object for SecretVolumeItem.

## SYNTAX

```
New-AzContainerAppSecretVolumeItemObject [-Path <String>] [-SecretRef <String>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SecretVolumeItem.

## EXAMPLES

### Example 1: Create an in-memory object for SecretVolumeItem.
```powershell
New-AzContainerAppSecretVolumeItemObject -Path "secretVolumePath" -SecretRef "redis-secret"
```

```output
Path             SecretRef
----             ---------
secretVolumePath redis-secret
```

Create an in-memory object for SecretVolumeItem.

## PARAMETERS

### -Path
Path to project secret to.
If no path is provided, path defaults to name of secret listed in secretRef.

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
Name of the Container App secret from which to pull the secret value.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.SecretVolumeItem

## NOTES

## RELATED LINKS
