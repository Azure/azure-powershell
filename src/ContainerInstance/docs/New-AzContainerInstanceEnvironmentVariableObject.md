---
external help file:
Module Name: Az.ContainerInstance
online version: https://docs.microsoft.com/powershell/module//az.ContainerInstance/new-AzContainerInstanceEnvironmentVariableObject
schema: 2.0.0
---

# New-AzContainerInstanceEnvironmentVariableObject

## SYNOPSIS
Create a in-memory object for EnvironmentVariable

## SYNTAX

```
New-AzContainerInstanceEnvironmentVariableObject -Name <String> [-SecureValue <SecureString>]
 [-Value <String>] [<CommonParameters>]
```

## DESCRIPTION
Create a in-memory object for EnvironmentVariable

## EXAMPLES

### Example 1: Create an environment variable within a container instance
```powershell
PS C:\> {{ Add code here }}

New-AzContainerInstanceEnvironmentVariableObject -Name "env1" -Value "value1"

Name SecureValue Value
---- ----------- -----
env1             value1
```

This command creates an environment variable within a container instance.

### Example 2: Create a secure environment variable within a container instance
```powershell
PS C:\> New-AzContainerInstanceEnvironmentVariableObject -Name "env2" -SecureValue (ConvertTo-SecureString -String "******" -AsPlainText -Force)

Name SecureValue Value
---- ----------- -----
env2 ******
```

This command creates a secure environment variable within a container instance

## PARAMETERS

### -Name
The name of the environment variable.

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

### -SecureValue
The value of the secure environment variable.

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

### -Value
The value of the environment variable.

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

### Microsoft.Azure.PowerShell.Cmdlets.ContainerInstance.Models.Api20210301.EnvironmentVariable

## NOTES

ALIASES

## RELATED LINKS

