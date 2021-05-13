---
external help file:
Module Name: Az.ContainerInstance
online version: https://docs.microsoft.com/powershell/module//az.ContainerInstance/new-AzContainerGroupImageRegistryCredentialObject
schema: 2.0.0
---

# New-AzContainerGroupImageRegistryCredentialObject

## SYNOPSIS
Create a in-memory object for ImageRegistryCredential

## SYNTAX

```
New-AzContainerGroupImageRegistryCredentialObject -Server <String> -Username <String>
 [-Password <SecureString>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for ImageRegistryCredential

## EXAMPLES

### Example 1: Set up an image registry credential to create a container group
```powershell
PS C:\> New-AzContainerGroupImageRegistryCredentialObject -Server "myserver.com" -Username "username" -Password (ConvertTo-SecureString "******" -AsPlainText -Force) 


Password          Server       Username
--------          ------       --------
****** myserver.com username
```

This command sets up an image registry credential to create a container group

## PARAMETERS

### -Password
The password for the private registry.

```yaml
Type: System.Security.SecureString
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Server
The Docker image registry server without a protocol such as "http" and "https".

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
The username for the private registry.

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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.ImageRegistryCredential

## NOTES

ALIASES

## RELATED LINKS

