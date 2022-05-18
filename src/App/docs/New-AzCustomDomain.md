---
external help file:
Module Name: Az.App
online version: https://docs.microsoft.com/powershell/module/az./new-AzCustomDomain
schema: 2.0.0
---

# New-AzCustomDomain

## SYNOPSIS
Create an in-memory object for CustomDomain.

## SYNTAX

```
New-AzCustomDomain -CertificateId <String> -Name <String> [-BindingType <BindingType>] [<CommonParameters>]
```

## DESCRIPTION
Create an in-memory object for CustomDomain.

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

### -BindingType
Custom Domain binding type.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.App.Support.BindingType
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -CertificateId
Resource Id of the Certificate to be bound to this hostname.
Must exist in the Managed Environment.

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

### -Name
Hostname.

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

### Microsoft.Azure.PowerShell.Cmdlets.App.Models.Api20220301.CustomDomain

## NOTES

ALIASES

## RELATED LINKS

