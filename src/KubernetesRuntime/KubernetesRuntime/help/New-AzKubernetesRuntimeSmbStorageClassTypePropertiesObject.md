---
external help file: Az.KubernetesRuntime-help.xml
Module Name: Az.KubernetesRuntime
online version: https://learn.microsoft.com/powershell/module/Az.KubernetesRuntime/new-azkubernetesruntimesmbstorageclasstypepropertiesobject
schema: 2.0.0
---

# New-AzKubernetesRuntimeSmbStorageClassTypePropertiesObject

## SYNOPSIS
Create an in-memory object for SmbStorageClassTypeProperties.

## SYNTAX

```
New-AzKubernetesRuntimeSmbStorageClassTypePropertiesObject -Source <String> [-Domain <String>]
 [-Password <SecureString>] [-SubDir <String>] [-Username <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for SmbStorageClassTypeProperties.

## EXAMPLES

### Example 1: Create a SmbStorageClassTypeProperties object
```powershell
$typeProperties = New-AzKubernetesRuntimeSmbStorageClassTypePropertiesObject `
    -Source "//ip:port" `
    -Domain "domain" `
    -Username "username" `
    -Password $(ConvertTo-SecureString 'password' -AsPlainText) `
    -SubDir "subdir"
```

Create a `SmbStorageClassTypeProperties` object.

## PARAMETERS

### -Domain
Server domain.

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

### -Password
Server password.

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

### -Source
SMB Source.

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

### -SubDir
Sub directory under share.
If the sub directory doesn't exist, driver will create it.

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
Server username.

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

### Microsoft.Azure.PowerShell.Cmdlets.KubernetesRuntime.Models.SmbStorageClassTypeProperties

## NOTES

## RELATED LINKS
