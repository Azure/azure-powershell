---
external help file:
Module Name: Az.SpringApps
online version: https://learn.microsoft.com/powershell/module/Az.SpringApps/new-azspringcontainerregistrycredentialobject
schema: 2.0.0
---

# New-AzSpringContainerRegistryCredentialObject

## SYNOPSIS
Create an in-memory object for ContainerRegistryBasicCredentials.

## SYNTAX

```
New-AzSpringContainerRegistryCredentialObject -Password <String> -Server <String> -Username <String>
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for ContainerRegistryBasicCredentials.

## EXAMPLES

### Example 1: Create an in-memory object for ContainerRegistryBasicCredentials.
```powershell
New-AzSpringContainerRegistryCredentialObject -Password "ibOL0******887K" -Server azpsacr.azurecr.io -Username azpsacr
```

```output
Password        Server             Type      Username
--------        ------             ----      --------
ibOL0******887K azpsacr.azurecr.io BasicAuth azpsacr
```

Create an in-memory object for ContainerRegistryBasicCredentials.

## PARAMETERS

### -Password
The password of the Container Registry.

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

### -Server
The login server of the Container Registry.

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

### -Username
The username of the Container Registry.

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SpringApps.Models.ContainerRegistryBasicCredentials

## NOTES

## RELATED LINKS

