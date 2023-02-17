---
external help file:
Module Name: Az.App
online version: https://learn.microsoft.com/powershell/module/az.app/new-azcontainerappregistrycredentialobject
schema: 2.0.0
---

# New-AzContainerAppRegistryCredentialObject

## SYNOPSIS
Create an in-memory object for RegistryCredentials.

## SYNTAX

```
New-AzContainerAppRegistryCredentialObject [-Identity <String>] [-PasswordSecretRef <String>]
 [-Server <String>] [-Username <String>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for RegistryCredentials.

## EXAMPLES

### Example 1: Create a RegistryCredentials object for ContainerApp.
```powershell
New-AzContainerAppRegistryCredentialObject -Identity system -PasswordSecretRef "myloginpassword" -Server azps-containerapp -Username azps-container-user
```

```output
Identity PasswordSecretRef Server            Username
-------- ----------------- ------            --------
system   myloginpassword   azps-containerapp azps-container-user
```

Create a RegistryCredentials object for ContainerApp.

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

