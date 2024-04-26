---
external help file: Az.Nginx-help.xml
Module Name: Az.Nginx
online version: https://learn.microsoft.com/powershell/module/Az.Nginx/new-AzNginxConfigurationFileObject
schema: 2.0.0
---

# New-AzNginxConfigurationFileObject

## SYNOPSIS
Create an in-memory object for NginxConfigurationFile.

## SYNTAX

```
New-AzNginxConfigurationFileObject [-Content <String>] [-VirtualPath <String>]
 [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for NginxConfigurationFile.

## EXAMPLES

### Example 1: Create an in-memory object for NginxConfigurationFile
```powershell
New-AzNginxConfigurationFileObject -Content aHR0cCB7 -VirtualPath nginx.conf
```

```output
Content  VirtualPath
-------  -----------
aHR0cCB7 nginx.conf
```

Create an in-memory object for NginxConfigurationFile.

## PARAMETERS

### -Content

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

### -VirtualPath

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

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api20230401.NginxConfigurationFile

## NOTES

## RELATED LINKS
