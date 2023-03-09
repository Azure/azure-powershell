---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerappsecretobject
schema: 2.0.0
---

# New-AzContainerAppSecretObject

## SYNOPSIS
Create an in-memory object for Secret.

## SYNTAX

```
New-AzContainerAppSecretObject [-Name <String>] [-Value <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for Secret.

## EXAMPLES

### Example 1: Create a Secret object for ManagedEnvDaprSecret.
```powershell
New-AzContainerAppSecretObject -Name "masterkey" -Value "keyvalue"
```

```output
Name      Value
----      -----
masterkey keyvalue
```

Create a Secret object for ManagedEnvDaprSecret.

## PARAMETERS

### -Name
Secret Name.

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
Secret Value.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.Secret

## NOTES

ALIASES

## RELATED LINKS

