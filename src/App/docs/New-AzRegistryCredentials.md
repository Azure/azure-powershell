---
external help file:
Module Name: Az.App
online version: https://docs.microsoft.com/powershell/module/az./new-AzRegistryCredentials
schema: 2.0.0
---

# New-AzRegistryCredentials

## SYNOPSIS
Create an in-memory object for RegistryCredentials.

## SYNTAX

```
New-AzRegistryCredentials [-Identity <String>] [-PasswordSecretRef <String>] [-Server <String>]
 [-Username <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RegistryCredentials.

## EXAMPLES

### Example 1: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

### Example 2: {{ Add title here }}
```powershell
{{ Add code here }}
```

```output
{{ Add output here }}
```

{{ Add description here }}

## PARAMETERS

### -Identity
A Managed Identity to use to authenticate with Azure Container Registry.
For user-assigned identities, use the full user-assigned identity Resource ID.
For system-assigned identities, use 'system'.

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

### -PasswordSecretRef
The name of the Secret that contains the registry login password.

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

### -Server
Container Registry Server.

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

### -Username
Container Registry Username.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.RegistryCredentials

## NOTES

ALIASES

## RELATED LINKS

